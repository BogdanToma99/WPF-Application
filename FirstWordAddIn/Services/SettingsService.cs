using FirstWordAddIn.Models;
using FirstWordAddIn.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using OfficeOpenXml;
using System.Runtime.InteropServices;
using ApplicationWord = Microsoft.Office.Interop.Word.Application;
using Paragraph = Microsoft.Office.Interop.Word.Paragraph;
using System.Windows;

namespace FirstWordAddIn.Services
{
    public class SettingsService
    {

        private SettingsService()
        {

        }
        private static readonly Lazy<SettingsService> lazy = new Lazy<SettingsService>(() => new SettingsService());

        public static SettingsService Instance
        {
            get => lazy.Value;
        }

        public string GetApplicationPath(string relativePath)
        {
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            return absolutePath;
        }

        public void SerialiazeSettings(UserSettings settings)
        {
            string settingsJson = JsonConvert.SerializeObject(settings, Formatting.Indented);
            string settingsPath = GetApplicationPath("settings.json");
            using (var tw = new StreamWriter(settingsPath, append: false))
            {
                tw.Write(settingsJson);
                tw.Close();
            }
        }

        public UserSettings DeserializeSettings()
        {
            UserSettings userSettings = new UserSettings();
            string settingsPath = GetApplicationPath("settings.json");
            string settingsJson = File.ReadAllText(settingsPath);
            if (!string.IsNullOrEmpty(settingsJson))
            {
                JToken settingsToken = JsonConvert.DeserializeObject(settingsJson) as JToken;
                JToken sourcesToken = settingsToken["Sources"];
                JToken mergeTagsToken = settingsToken["MergeTags"];
                JToken dataSetsToken = settingsToken["DataSets"];
                List<Source> sources = new List<Source>();
                List<MergeTag> mergeTags = new List<MergeTag>();
                List<DataSet> dataSets = new List<DataSet>();
                foreach (var token in sourcesToken.Children())
                {
                    var type = token["Type"].ToObject<int>();
                    if (type == 1)
                    {
                        var idScanner = JsonConvert.DeserializeObject<IdScanner>(token.ToString());
                        sources.Add(idScanner);
                    }
                    else if (type == 2)
                    {
                        var excelSheet = JsonConvert.DeserializeObject<ExcelSheet>(token.ToString());
                        sources.Add(excelSheet);
                    }
                    else if (type == 3)
                    {
                        var googleSheet = JsonConvert.DeserializeObject<GoogleSheet>(token.ToString());
                        sources.Add(googleSheet);
                    }
                }
                userSettings.Sources = sources;
                foreach (var token in mergeTagsToken.Children())
                {
                    var mergeTag = JsonConvert.DeserializeObject<MergeTag>(token.ToString());
                    mergeTags.Add(mergeTag);
                }
                userSettings.MergeTags = mergeTags;
                foreach (var token in dataSetsToken.Children())
                {
                    var dataSet = JsonConvert.DeserializeObject<DataSet>(token.ToString());
                    dataSets.Add(dataSet);
                }
                userSettings.DataSets = dataSets;
            }

            return userSettings;
        }

        public List<List<string>> ReadExcelFile(string path)
        {
            Application xlApp = null;
            Workbook xlWorkbook = null;
            Sheets xlSheets = null;
            Worksheet xlSheet = null;
            var results = new List<List<string>>();
            var columnsHeaders = new List<string>();


            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(path, Type.Missing, true, Type.Missing, Type.Missing, Type.Missing, true, XlPlatform.xlWindows, Type.Missing, false, false, Type.Missing, false, Type.Missing, Type.Missing);
                xlSheets = xlWorkbook.Sheets as Sheets;
                xlSheet = (Worksheet)xlSheets[1];
                var cells = xlSheet.UsedRange;
                results = ExcelRangeToListsParallel(cells);
                var colNumber = xlSheet.UsedRange.Columns.Count;
                for (int i = 0; i < colNumber; i++)
                {
                    columnsHeaders.Add(results[i][0]);
                }
            }
            catch (Exception)
            {
                results = null;
            }
            finally
            {
                xlWorkbook.Close(false);
                xlApp.Quit();

                if (xlSheet != null)
                    Marshal.ReleaseComObject(xlSheet);
                if (xlSheets != null)
                    Marshal.ReleaseComObject(xlSheets);
                if (xlWorkbook != null)
                    Marshal.ReleaseComObject(xlWorkbook);
                if (xlApp != null)
                    Marshal.ReleaseComObject(xlApp);
                xlApp = null;
            }

            return results;
        }

        private List<List<String>> ExcelRangeToListsParallel(Microsoft.Office.Interop.Excel.Range cells)
        {

            return cells.Columns.Cast<Microsoft.Office.Interop.Excel.Range>().AsParallel().Select(column =>
            {
                return column.Cells.Cast<Microsoft.Office.Interop.Excel.Range>().Select(cell =>
                {
                    var cellContent = cell.Value2;
                    return (cellContent == null) ? String.Empty : cellContent.ToString();
                }).Cast<string>().ToList();
            }).ToList();
        }

        public List<string> GetColumnHeaders(string label)
        {
            List<string> columnHeaders = new List<string>();
            List<Source> sources = new List<Source>();
            string filePath;
            sources = SettingsService.Instance.DeserializeSettings().Sources;
            ExcelSheet element = (ExcelSheet)sources.Where(x => x.Label.Contains(label)).FirstOrDefault();
            filePath = element.FilePath;
            var excelResults = ReadExcelFile(filePath);
            var colNumber = excelResults.Count();
            for (int i = 0; i < colNumber; i++)
            {
                columnHeaders.Add(excelResults[i][0]);
            }
            return columnHeaders;
        }
        public List<string> GetColumn(string columnHeader)
        {
            List<string> column = new List<string>();
            List<MergeTag> mergeTags = new List<MergeTag>();
            string source;
            string filePath;
            mergeTags = SettingsService.Instance.DeserializeSettings().MergeTags;
            MergeTag element = (MergeTag)mergeTags.Where(y => y.Column.Contains(columnHeader)).FirstOrDefault();
            source = element.Source;
            List<Source> sources = new List<Source>();
            sources = SettingsService.Instance.DeserializeSettings().Sources;
            ExcelSheet sourceElement = (ExcelSheet)sources.Where(x => x.Label.Contains(source)).FirstOrDefault();
            filePath = sourceElement.FilePath;
            var excelResults = ReadExcelFile(filePath);
            column = excelResults.Where(x => x.Contains(columnHeader)).FirstOrDefault();

            return column;
        }
        public void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
        public int GetLineNumber(string path, string sourceLabel, string referenceValue)
        {
            int lineNumber = 0;

            List<DataSet> dataSets = SettingsService.Instance.DeserializeSettings().DataSets;
            string dataSetSource = dataSets.Where(x => x.Source.Contains(sourceLabel)).FirstOrDefault().Source;
            List<MergeTag> mergeTags = SettingsService.Instance.DeserializeSettings().MergeTags;
            List<MergeTag> rightMergeTags = mergeTags.Where(x => x.Source.Contains(dataSetSource)).ToList();
            object fileName = path;
            List<string> data = new List<string>();
            ApplicationWord app = new ApplicationWord();
            Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)app.Documents.Open(ref fileName);
            var docPath = doc.FullName;
            app.Visible = true;
            int count;
            foreach (Paragraph objParagraph in doc.Paragraphs)
                data.Add(objParagraph.Range.Text.Trim());
            foreach (var paragraph in data)
            {
                for (int i = 0; i <= rightMergeTags.Count(); i++)
                {
                    for (int j = 0; j <= rightMergeTags.Count(); j++)
                    {
                        var column = GetColumn(rightMergeTags[j].Column);
                        foreach (var kkt in column)
                        {
                            int index = column.IndexOf(referenceValue);
                            if (index > 0)
                            {
                                var value = column[index];
                                //SettingsService.Instance.FindAndReplace(app, $"{{{rightMergeTags[j].Column}}}", value.ToString());
                                lineNumber = index;
                                break;
                            }
                        }
                    }
                }
            }
            doc.Close();
            app.Quit();
            return lineNumber;

        }
        public void InsertData(bool LastLineChecked, int lineNumber, string path, string sourceLabel, string referenceValue)
        {
            object word;

            try
            {
                word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                Microsoft.Office.Interop.Word.Application app = (Microsoft.Office.Interop.Word.Application)word;
                object fileName = app.ActiveDocument.FullName;

                //If there is a running Word instance, it gets saved into the word variable
                List<DataSet> dataSets = SettingsService.Instance.DeserializeSettings().DataSets;
                string dataSetSource = dataSets.Where(x => x.Source.Contains(sourceLabel)).FirstOrDefault().Source;
                List<MergeTag> mergeTags = SettingsService.Instance.DeserializeSettings().MergeTags;
                List<MergeTag> rightMergeTags = mergeTags.Where(x => x.Source.Contains(dataSetSource)).ToList();
                List<string> data = new List<string>();
                List<Source> sources = SettingsService.Instance.DeserializeSettings().Sources;
                ExcelSheet source = (ExcelSheet)sources.Where(u => u.Label.Contains(sourceLabel)).FirstOrDefault();
                var filePath = source.FilePath;
                var excelResults = ReadExcelFile(filePath);
                var column2 = excelResults.Where(x => x.Contains(referenceValue)).FirstOrDefault();
                Microsoft.Office.Interop.Word.Document doc = (Microsoft.Office.Interop.Word.Document)app.Documents.Open(ref fileName);
                app.Visible = true;
                foreach (Paragraph objParagraph in doc.Paragraphs)
                    data.Add(objParagraph.Range.Text.Trim());
                foreach (var paragraph in data)
                {
                    for (int i = 0; i <= rightMergeTags.Count(); i++)
                    {
                        for (int j = 0; j <= rightMergeTags.Count(); j++)
                        {
                            var column = GetColumn(rightMergeTags[j].Column);
                            if (LastLineChecked)
                            {
                                var value = column[column.Count() - 1];
                                SettingsService.Instance.FindAndReplace(app, $"{{{rightMergeTags[j].Column}}}", value.ToString());
                            }
                            else if (lineNumber != 0)
                            {
                                var value = column[lineNumber];
                                SettingsService.Instance.FindAndReplace(app, $"{{{rightMergeTags[j].Column}}}", value.ToString());
                            }
                            else
                            {
                                var index = column2.IndexOf(referenceValue);
                                var value = column[index];
                                SettingsService.Instance.FindAndReplace(app, $"{{{rightMergeTags[j].Column}}}", value.ToString());
                            }
                        }
                    }
                }
                doc.Close();
                app.Quit();
            }
            catch (COMException e)
            {
                MessageBox.Show(e.ToString());
                //If there is no running instance, it creates a new one
                Type type = Type.GetTypeFromProgID("Word.Application");
                word = System.Activator.CreateInstance(type);
            }

        }
    }
}

