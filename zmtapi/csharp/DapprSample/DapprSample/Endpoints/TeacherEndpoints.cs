using Dapper;
using DapprSample.Models;
using DapprSample.Services;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Data.SqlClient;

namespace DapprSample.Endpoints
{
    public static class TeacherEndpoints
    {
        public static void MapTeacherEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("teachers", async (SqlConnectionFactory   sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();
                LogIngestor ingestor = new LogIngestor(connection);
                try
                {
                    const string sql = "SELECT Id, Name, SubjectId, DepartmentId FROM Teachers";
                    var teachers = await connection.QueryAsync<Teachers>(sql);
                    return Results.Ok(teachers);

                }
                catch (Exception ex)
                {
                    ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "GET: teachers", "26");
                    throw;
                }

            });
            builder.MapGet("teachers/{id}", async (int id, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();
                LogIngestor ingestor = new LogIngestor(connection);
                try
                {
                    const string sql = @"
                    SELECT Id, Name, SubjectId, DepartmentId 
                    FROM Teachers
                    WHERE ID = @TeacherId
                    ";
                    var teacher = await connection.QuerySingleOrDefaultAsync<Teachers>(
                        sql,
                        new { TeacherId = id } );
                    return teacher is not null ?  Results.Ok(teacher) : Results.NotFound();

                }
                catch (Exception ex)
                {
                    ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "GET: teachers/{id}", "26");
                    throw;
                }
            });

            builder.MapPost("teachers", async(Teachers teacher, SqlConnectionFactory sqlConnectionFactory) =>
                {
                    using var connection = sqlConnectionFactory.Create();
                    LogIngestor ingestor = new LogIngestor(connection);
                    try
                    {
                        const string sql = @" 
                                              INSERT INTO Teachers (Name, SubjectId, DepartmentId)
                                               VALUES (@Name, @SubjectId, @DepartmentId)
                                            ";

                        await connection.ExecuteAsync(sql, teacher);
                        return Results.Ok();
                    }
                    catch (Exception ex)
                    {
                        ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "POST: teachers", "26");
                        throw;
                    }

                }); 

            builder.MapPut("teachers/{id}", async (int id, Teachers teacher, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();
                LogIngestor ingestor = new LogIngestor(connection);
                try
                {

                    teacher.Id = id;

                    const string sql = @" 
                                              UPDATE Teachers 
                                              SET Name=@Name, 
                                                  SubjectId=SubjectId, 
                                                  DepartmentId=DepartmentId
                                              WHERE Id=@Id
                                        ";

                    await connection.ExecuteAsync(sql, teacher);
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "PUT: teachers/{id}", "26");
                    throw;
                }

            });

            builder.MapDelete("teachers/{id}", async (int id, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();
                LogIngestor ingestor = new LogIngestor(connection);
                try
                { 
                    const string sql = "DELETE FROM Teachers WHERE Id= @TeacherId";


                    await connection.ExecuteAsync(sql, new { TeacherId = id });
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "DELETE: teachers/{id}", "26");
                    throw;
                }

            });

            builder.MapGet("teachers/sub" , async (int subid, SqlConnectionFactory sqlConnectionFactory) =>
            {
                using var connection = sqlConnectionFactory.Create();
                LogIngestor ingestor = new LogIngestor(connection);
                try
                {
                    const string sql = "SELECT Id, Name, SubjectId, DepartmentId FROM Teachers  WHERE SubjectId= @SubjectId";
                    var teachers = await connection.QueryAsync<Teachers>(sql, new { SubjectId = subid });
                    return Results.Ok(teachers);
                }
                catch (Exception ex)
                {
                    ingestor.IngestLog("error", ex.Message, "TeacherEndpoints", "GET: teachers/sub", "26");
                    throw;
                }
            });

        }
    }
}
