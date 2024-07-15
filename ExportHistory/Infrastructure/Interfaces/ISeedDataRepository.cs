using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;
using ExportHistoryLib.Models;


namespace ExportHistoryLib.Infrastructure.Interfaces
{
    public interface ISeedDataRepository
    {
        public Task<IOption<IError>> SeedExportHistoryDataAsync(List<ExportHistory> seedData);
    }
}
