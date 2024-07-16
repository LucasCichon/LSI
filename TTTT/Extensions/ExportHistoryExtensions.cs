using ExportHistoryLib.Models;
using ExportHistoryViewer.ViewModels;
using System;

namespace ExportHistoryViewer.Converters
{
    public static class ExportHistoryExtensions
    {
        public static ExportHistoryVm ToExportHistoryVm(this ExportHistory export)
        {
            if(export == null) throw new ArgumentNullException(nameof(export));

            return new ExportHistoryVm()
            {
                ID = export.ID,
                ExportDate = DateOnly.FromDateTime(export.ExportDate),
                ExportTime = TimeOnly.FromDateTime(export.ExportDate).ToString(),
                ExportName = export.ExportName,
                LocationName = export.LocationName,
                UserName = export.UserName
            };
        }
    }
}
