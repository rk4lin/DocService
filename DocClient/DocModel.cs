using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocClient
{
    class DocModel
    {
        public long docNumber { get; set; }
        public string dateDoc { get; set; }
        public string lastUpdateDate { get; set; }
        public bool checkDateUpdate { get; set; }
    }
}
