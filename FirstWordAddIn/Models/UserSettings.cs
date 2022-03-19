using FirstWordAddIn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWordAddIn.Models
{
    public class UserSettings
    {
        public List<Source> Sources { get; set; }
        public List<MergeTag> MergeTags { get; set; }
        public List<DataSet> DataSets { get; set; }

        
    }
}
