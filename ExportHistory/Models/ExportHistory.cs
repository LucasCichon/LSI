
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
