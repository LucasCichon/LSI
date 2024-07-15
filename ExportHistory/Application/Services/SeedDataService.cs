using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;
using ExportHistoryLib.Helpers;
using ExportHistoryLib.Infrastructure.Interfaces;


namespace ExportHistoryLib.Application.Services
{
    public class SeedDataService : ISeedDataService
    {
        private readonly ISeedDataRepository _seedDataRepository;

        public SeedDataService(ISeedDataRepository seedDataRepository)
        {
            _seedDataRepository = seedDataRepository;
        }
        public async Task<IOption<IError>> SeedExportHistoryDataAsync(int count)
        {
            var data = SeedDataHelper.GenerateExportHistorySeedData(count);
            return await _seedDataRepository.SeedExportHistoryDataAsync(data);
        }
    }
}
