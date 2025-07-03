using Dapper;
using DapprSample.Endpoints;
using DapprSample.Models;
using DapprSample.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(serviceProvider =>
{ 
var configuration = serviceProvider.GetRequiredService<IConfiguration>();

var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                         throw new ApplicationException("The connection String is Null");

return new SqlConnectionFactory(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapLogsEndpoints();

app.MapTeacherEndpoints();

app.Run();
