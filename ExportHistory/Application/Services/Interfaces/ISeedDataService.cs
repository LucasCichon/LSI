
using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;

namespace ExportHistoryLib.Application.Services.Interfaces
{
    public interface ISeedDataService
    {
        public Task<IOption<IError>> SeedExportHistoryDataAsync(int count);
    }
}
