using ExportHistoryLib.Common;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Application.Services.Interfaces
{
    public interface IExportHistoryService
    {
        public Task<Either<IError, ExportHistoryList>> GetExportHistories(DateTime? start, DateTime? end, string location, Pagination pagination);
        public Task<Either<IError, List<string>>> GetLocations();
    }
}
