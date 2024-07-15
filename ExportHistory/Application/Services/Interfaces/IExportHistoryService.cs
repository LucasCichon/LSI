using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Application.Services.Interfaces
{
    public interface IExportHistoryService
    {
        public Task<Either<IError, ExportHistoryList>> GetExportHistoriesAsync(DateTime? start, DateTime? end, string location, PaginationFilter pagination);
        public Task<Either<IError, List<string>>> GetLocationsAsync();
        Task<IOption<IError>> CreateExportHistoryTableIfNotExistsAsync();
    }
}
