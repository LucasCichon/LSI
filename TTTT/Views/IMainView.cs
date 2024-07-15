using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.Threading;

namespace ExportHistoryViewer.Views
{
    public interface IMainView
    {
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
        string Location { get; }
        List<string> Locations { get; set; }

        int Skip { get; set; }
        int Take { get; set; }
        int TotalCount { get; set; }

        bool IsSuccessfull { get; set; }
        string Message { get; set; }

        event AsyncEventHandler SearchEventAsync;
        event AsyncEventHandler SeedEventAsync;
        event AsyncEventHandler OnLoad;
        event EventHandler PaginationIncrease;
        event EventHandler PaginationDecrease;
        event EventHandler ClearEvent;

        void SetExportHistories(BindingSource exportHistories);
        void SetLocations(List<string> locations);
        void SetPagination();
        void SaveLayoutToRegistry();
        void TryRestoreLayoutFromRegistry();
    }
}
