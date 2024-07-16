using System;
using System.ComponentModel.DataAnnotations;

namespace ExportHistoryViewer.ViewModels
{
    public class ExportHistoryVm
    {
        [Display(Order = -1)]
        public int ID { get; set; }
        
        [Display(Name ="Nazwa", Order = 0)]
        public string ExportName { get; set; }
        [Display(Name ="Data", Order = 1)]
        public DateOnly ExportDate { get; set; }
        [Display(Name ="Godzina", Order = 2)]
        public string ExportTime { get; set; }
        [Display(Name ="Użytkownik", Order = 3)]
        public string UserName { get; set; }
        [Display(Name ="Lokal", Order = 4)]
        public string LocationName { get; set; }
    }
}
