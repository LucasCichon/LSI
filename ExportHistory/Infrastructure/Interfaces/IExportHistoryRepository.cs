
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Infrastructure.Interfaces
{
    public interface IExportHistoryRepository
    {
        Task<ExportHistoryList> GetExportHistories(DateTime? startDate, DateTime? endDate, string location, Pagination pagination);
        Task<List<string>> GetLocations();

    }
}
