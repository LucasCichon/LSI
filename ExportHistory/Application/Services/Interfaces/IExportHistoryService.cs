using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Application.Services.Interfaces
{
    public interface IExportHistoryService
    {
        public Task<ExportHistoryList> GetExportHistories(DateTime? start, DateTime? end, string location, Pagination pagination);
        public Task<List<string>> GetLocations();
    }
}
