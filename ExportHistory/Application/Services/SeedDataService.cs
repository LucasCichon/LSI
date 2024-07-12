using ExportHistoryLib.Application.Services.Interfaces;
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
        public async Task SeedExportHistoryData(int count)
        {
            var data = SeedDataHelper.GenerateExportHistorySeedData(count);
            await _seedDataRepository.SeedExportHistoryData(data);
        }
    }
}
