using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportHistoryLib.Application.Services.Interfaces
{
    public interface ISeedDataService
    {
        public Task SeedExportHistoryData(int count);
    }
}
