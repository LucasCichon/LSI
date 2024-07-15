using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Infrastructure.Interfaces
{
    public interface IExportHistoryRepository
    {
        Task<Either<IError, ExportHistoryList>> GetExportHistoriesAsync(DateTime? startDate, DateTime? endDate, string location, PaginationFilter pagination);
        Task<Either<IError, List<string>>> GetLocationsAsync();
        Task<IOption<IError>> CreateExportHistoryTableIfNotExistsAsync();

    }
}
