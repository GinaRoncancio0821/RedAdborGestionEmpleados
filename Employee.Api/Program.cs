using Employe.Core.BundleEmployee.Repositories;
using Employe.Core.BundleEmployee.Services;
using Employe.Core.BundleEmployee.Services.Impl;
using Employee.Core.BundleEmployee.Services;
using Employee.Core.BundleEmployee.Validator;
using Employee.Data.Commands;
using Employee.Data.Commands.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

//  ApplicationDbContext (EF)
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Dapper and Repository
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeCommandService, EmployeeCommandService>();
builder.Services.AddScoped<IEmployeeQueriesService, EmployeeQueriesServices>();
// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter("yyyy-MM-dd HH:mm:ss"));
    })
    .AddNewtonsoftJson(options =>
    {
     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
     });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
