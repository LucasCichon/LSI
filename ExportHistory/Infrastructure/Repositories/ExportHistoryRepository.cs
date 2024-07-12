using ExportHistoryLib.Infrastructure.Interfaces;
using System.Data.SqlClient;
using Dapper;
using ExportHistoryLib.Models;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Common;
using Serilog;


namespace ExportHistoryLib.Infrastructure.Repositories
{
    public class ExportHistoryRepository : IExportHistoryRepository
    {
        private readonly string _connectionString;

        public ExportHistoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Either<IError, ExportHistoryList>> GetExportHistoriesAsync(DateTime? startDate, DateTime? endDate, string location, Pagination pagination)
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
    [LSI].[dbo].[ExportHistory]
WHERE 
    (@StartDate IS NULL OR ExportDate >= @StartDate)
AND 
    (@EndDate IS NULL OR ExportDate <= @EndDate)
AND 
    (@Location IS NULL OR @Location = '' OR LocationName = @Location)";

                    result.TotalCount = await connection.ExecuteScalarAsync<int>(queryTotalCount, new { StartDate = startDate, EndDate = endDate, Location = location });

                    Log.Debug($"GetExportHistories successfully");
                    return Either<IError, ExportHistoryList>.Success(result);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"GerExportHistories failed with error: {ex.Message}");
                return Either<IError, ExportHistoryList>.Error(new Error(ex.Message));
            }
        }

        public async Task<Either<IError, List<string>>> GetLocationsAsync()
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
                    Log.Debug($"GetLocations successfully");
                    return Either<IError, List<string>>.Success(result.ToList());
                }
            }
            catch (Exception ex)
            {
                Log.Error($"GetLocations failed with error: {ex.Message}");
                return Either<IError, List<string>>.Error(new Error(ex.Message));
            }
        }
    }
}
