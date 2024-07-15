using ExportHistoryLib.Infrastructure.Interfaces;
using System.Data.SqlClient;
using Dapper;
using ExportHistoryLib.Models;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Common;
using Serilog;
using ExportHistoryLib.Common.Error;


namespace ExportHistoryLib.Infrastructure.Repositories
{
    public class ExportHistoryRepository : IExportHistoryRepository
    {
        private readonly string _connectionString;

        public ExportHistoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IOption<IError>> CreateExportHistoryTableIfNotExistsAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"
IF 
 ( NOT EXISTS 
   (select object_id from sys.objects where object_id = OBJECT_ID(N'[dbo].[ExportHistory]') and type = 'U')
 )
BEGIN

CREATE TABLE [dbo].[ExportHistory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExportName] [nvarchar](255) NULL,
	[ExportDate] [datetime] NULL,
	[UserName] [nvarchar](255) NULL,
	[LocationName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

END;";

                    var result = await connection.ExecuteAsync(query);

                    Log.Debug($"Create ExportHistory table successfully");
                    return new Option.None<IError>();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Create ExportHistory table failed with error: {ex.Message}");
                return new Option.Some<IError>(new Error(ex.Message, ErrorType.DbError));
            }
        }

        public async Task<Either<IError, ExportHistoryList>> GetExportHistoriesAsync(DateTime? startDate, DateTime? endDate, string location, PaginationFilter pagination)
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

                    result.Items = await connection.QueryAsync<ExportHistory>(query, new { StartDate = startDate, EndDate = endDate, Location = location, Skip = pagination.Skip, Take = pagination.Take });


                    string queryTotalCount = @"
SELECT 
    Count(*) 
FROM 
    [ExportHistory]
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
                return dbEitherError<ExportHistoryList>(ex.Message, $"GerExportHistories failed with error: {ex.Message}");
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
    [ExportHistory]";

                    var result = await connection.QueryAsync<string>(query);
                    Log.Debug($"GetLocations successfully");
                    return Either<IError, List<string>>.Success(result.ToList());
                }
            }
            catch (Exception ex)
            {
                return dbEitherError<List<string>>(ex.Message, $"GetLocations failed with error: {ex.Message}");
            }
        }

        public Either<IError, T> dbEitherError<T>(string errorMessage, string logMessage)
        {
            Log.Error($"GetLocations failed with error: {logMessage}");
            if (errorMessage == $"Invalid object name '{ServiceConstants.ExportHistoryTableName}'.")
            {
                return Either<IError, T>.Error(new Error(errorMessage, ErrorType.DbError_TableNotExists));
            }
            return Either<IError, T>.Error(new Error(errorMessage, ErrorType.DbError));
        }
    }
}
