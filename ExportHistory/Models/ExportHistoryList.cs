

namespace ExportHistoryLib.Models
{
    public class ExportHistoryList
    {
        public IEnumerable<ExportHistory> Items { get; set; } 
        public int TotalCount { get; set; }
    }
}
