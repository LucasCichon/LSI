using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Common;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Infrastructure.Interfaces;
using ExportHistoryLib.Models;

namespace ExportHistoryLib.Application.Services
{
    public class ExportHistoryService : IExportHistoryService
    {
        private readonly IExportHistoryRepository _repository;

        public ExportHistoryService(IExportHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Either<IError, ExportHistoryList>> GetExportHistoriesAsync(DateTime? startDate, DateTime? endDate, string location, Pagination pagination) => await  _repository.GetExportHistoriesAsync(startDate, endDate, location, pagination);
        

        public async Task<Either<IError, List<string>>> GetLocationsAsync() => await _repository.GetLocationsAsync();
    }
}
