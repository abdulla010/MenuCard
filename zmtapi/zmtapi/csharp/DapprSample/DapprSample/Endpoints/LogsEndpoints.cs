using Dapper;
using DapprSample.Models;
using DapprSample.Services;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Data.SqlClient;

namespace DapprSample.Endpoints
{
    public static class LogsEndpoints
    {
        public static void MapLogsEndpoints(this IEndpointRouteBuilder builder)
        { 
            builder.MapGet("GetErrorLogs", async (DateTime startDate, DateTime endDate, SqlConnectionFactory sqlConnectionFactory, string level = "error") =>
            {
                using var connection = sqlConnectionFactory.Create();
                LogIngestor ingestor = new LogIngestor(connection);
                try
                { 
                    return await ingestor.GetLogsByLevel(level, startDate, endDate); 
                }
                catch (Exception ex)
                {
                    ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "GET: teachers/{id}", ex.StackTrace ?? "26");
                    throw;
                }
            }); 

        }
    }
}
