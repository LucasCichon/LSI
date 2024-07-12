using ExportHistoryLib.Common;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Infrastructure.Interfaces
{
    public interface IExportHistoryRepository
    {
        Task<Either<IError, ExportHistoryList>> GetExportHistories(DateTime? startDate, DateTime? endDate, string location, Pagination pagination);
        Task<Either<IError, List<string>>> GetLocations();

    }
}
