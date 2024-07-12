using Dapper;
using ExportHistoryLib.Infrastructure.Interfaces;
using ExportHistoryLib.Models;
using System.Data.SqlClient;

namespace ExportHistoryLib.Infrastructure.Repositories
{
    public class SeedDataRepository : ISeedDataRepository
    {
        private readonly string _connectionString;

        public SeedDataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task SeedExportHistoryData(List<ExportHistory> seedData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO [ExportHistory]
        (ExportName
        ,ExportDate
        ,UserName
        ,LocationName)
    VALUES
        (@ExportName
        ,@ExportDate
        ,@UserName
        ,@LocationName)
";

                var rowsAffected = await connection.ExecuteAsync(query, seedData.Select(export => new { export.ExportName , export.ExportDate, export.UserName,  export.LocationName }));
            }
        }
    }
}
