using Dapper;
using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;
using ExportHistoryLib.Infrastructure.Interfaces;
using ExportHistoryLib.Models;
using Serilog;
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
        public async Task<IOption<IError>> SeedExportHistoryDataAsync(List<ExportHistory> seedData)
        {
            try
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
                Log.Debug($"SeedExportHistoryDataAsync successfully");
                return new Option.None<IError>();
            }
            catch (Exception ex)
            {
                Log.Error($"SeedExportHistoryDataAsync failed with error: {ex.Message}");
                if (ex.Message == $"Invalid object name '{ServiceConstants.ExportHistoryTableName}'.")
                {
                    return new Option.Some<IError>(new Error(ex.Message, ErrorType.DbError_TableNotExists));
                }
                return new Option.Some<IError>(new Error(ex.Message, ErrorType.DbError));
            }
        }
    }
}
