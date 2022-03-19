using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWordAddIn.Service
{
    public abstract class Source
    {
        public int Type { get; set; }
        public string Label { get; set; }
        public string SourceId { get; set; }

    }
}
