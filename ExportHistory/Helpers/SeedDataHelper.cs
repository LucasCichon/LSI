using ExportHistoryLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TddXt.AnyRoot.Root;


namespace ExportHistoryLib.Helpers
{
    public static class SeedDataHelper
    {
        public static List<ExportHistory> GenerateExportHistorySeedData (int count)
        {
            List<ExportHistory> exportHistorySeedData = new List<ExportHistory>();
            Random random = new Random();

            int locationsCount = Enum.GetValues(typeof(Location)).Length;
            int usersCount = Enum.GetValues(typeof(User)).Length;

            for (int i = 0; i < count; i++)
            {
                exportHistorySeedData.Add(new ExportHistory(){ 
                    ExportName = $"Export-{Any.Instance<String>()}", 
                    ExportDate = Any.Instance<DateTime>(), 
                    UserName = ((User)random.Next(usersCount)).ToString(), 
                    LocationName = ((Location)random.Next(locationsCount)).ToString() 
                });
            }

            return exportHistorySeedData;
        }

        private enum Location
        {
            [Display(Name = "Lokal w Opolu")]
            Opole,
            [Display(Name = "Lokal w Gnieźnie")]
            Gniezno,
            [Display(Name = "Lokal we Warszawie")]
            Warszawa,
            [Display(Name = "Lokal w Krakowie")]
            Kraków,
            [Display(Name = "Lokal we Wrocławiu")]
            Wrocłac,
            [Display(Name = "Lokal w Gliwicach")]
            Gliwice,
            [Display(Name = "Lokal w Sosnowcu")]
            Sosnowiec,
            [Display(Name = "Lokal w Katowicach")]
            Katowice,
        }

        private enum User
        {
            Marcin,
            Agnieszka,
            Wojtek,
            Aleksandra,
            Zbigniew,
            Urszula,
            Dorota,
            Mateusz,
            Jan,
            Kacper,
            Irena, 
            Ireneusz
            
        }

       


    }
}
