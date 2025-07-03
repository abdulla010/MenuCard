using Microsoft.Data.SqlClient;
using Dapper;

namespace DapprSample.Models
{
    public class LogIngestor
    {
        private SqlConnection conn;

        public LogIngestor(SqlConnection _conn)
        {
            conn = _conn;
        }
        public async void IngestLog(string level, string message, string className, string methodName, string lineNo)
        {
            try
            {
                LogModel logdata = new LogModel() {
                    Level = level,
                    Message = message,
                    ResourceId = methodName,
                    SpanId = lineNo,
                    Timestamp = DateTime.Now, 
                    Commit = Guid.NewGuid().ToString(),
                    Metadata = className
                };
                const string sql = @"
INSERT INTO Logs (Level, Message, ResourceId, Timestamp, SpanId, [Commit], Metadata)
VALUES (@Level, @Message, @ResourceId, @Timestamp, @SpanId, @Commit, @Metadata)";

                await conn.ExecuteAsync(sql, logdata);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading the log file: " + e.Message);
            }
        }

        public async Task<List<LogModel>> GetLogsByLevel(string level, DateTime startDate, DateTime endDate)
        {
            const string sql = @"
                SELECT Level, Message, ResourceId, Timestamp, SpanId,  [Commit], Metadata
FROM Logs
WHERE 
Level = @Level and
Timestamp >= @StartDate AND Timestamp < @EndDate;";
            var filteredLogs = await conn.QueryAsync<LogModel>(
                sql,
                new { Level = level, StartDate = startDate.Date, EndDate = endDate.AddDays(1).Date });

            return filteredLogs != null ? filteredLogs.ToList() : new List<LogModel>();
        }

    }
}
