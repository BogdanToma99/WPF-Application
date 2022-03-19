using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWordAddIn.Models
{
    public class DataSet
    {
        public string Label { get; set; }
        public string Source { get; set; }
        public string DataSetMember { get; set; }
        
        public string DataSetId { get; set; }
    }
}
