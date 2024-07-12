using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportHistoryLib.Models
{
    public class ExportHistory
    {
        public int ID { get; set; }
        public string ExportName { get; set; }
        public DateTime ExportDate { get; set; }
        public string UserName { get; set; }
        public string LocationName { get; set; }

    }
}
