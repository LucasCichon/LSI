using ExportHistoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportHistoryLib.Infrastructure.Interfaces
{
    public interface ISeedDataRepository
    {
        public Task SeedExportHistoryData(List<ExportHistory> seedData);
    }
}
