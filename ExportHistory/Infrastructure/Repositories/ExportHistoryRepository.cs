using ExportHistoryLib.Infrastructure.Interfaces;
using System.Data.SqlClient;
using Dapper;
using ExportHistoryLib.Models;
using ExportHistoryLib.Infrastructure.Filters;


namespace ExportHistoryLib.Infrastructure.Repositories
{
    public class ExportHistoryRepository : IExportHistoryRepository
    {
        private readonly string _connectionString;

        public ExportHistoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ExportHistoryList> GetExportHistories(DateTime? startDate, DateTime? endDate, string location, Pagination pagination)
        {
            try
            {
                var result = new ExportHistoryList();

                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"
SELECT * FROM 
    ExportHistory 
WHERE 
    (@StartDate IS NULL OR ExportDate >= @StartDate)
AND 
    (@EndDate IS NULL OR ExportDate <= @EndDate)
AND 
    (@Location IS NULL OR @Location = '' OR LocationName = @Location)
ORDER BY
    ExportDate
OFFSET
    @Skip ROWS
FETCH NEXT
    @Take ROWS ONLY";

                    result.Items = await connection.QueryAsync<ExportHistory>(query, new { StartDate = startDate, EndDate = endDate, Location = location, Skip = pagination.Skip, Take = pagination.Take});


                    string queryTotalCount = @"
SELECT 
    Count(*) 
FROM 
    [LSI].[dbo].[ExportHistory]";

                    result.TotalCount = await connection.ExecuteScalarAsync<int>(queryTotalCount);


                    return result;
                }
            }
            catch (Exception ex)
            {
                //
            }
            return new ExportHistoryList();
        }

        public async Task<List<string>> GetLocations()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"
SELECT 
    Distinct [LocationName]
FROM 
    [LSI].[dbo].[ExportHistory]";

                    var result = await connection.QueryAsync<string>(query);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                //
            }
            return new List<string>();
        }
    }
}
