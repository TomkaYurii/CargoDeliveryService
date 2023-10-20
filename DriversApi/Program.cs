using Drivers.Api.Middleware;
using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs.Requests;
using Drivers.BLL.DTOs.Validation;
using Drivers.BLL.Managers;
using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_ADO.Repositories;
using Drivers.DAL_ADO.UOW;
using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Helpers;
using Drivers.DAL_EF.Repositories;
using Drivers.DAL_EF.UOW;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;



//КОНФІГРУВАННЯ: 1) файли конфігурацій 2) IOC 3) логіювання
var builder = WebApplication.CreateBuilder(args);


////////////////////////////////////////////////////////////////////////////////////
/// ADO.NET = Dapper
////////////////////////////////////////////////////////////////////////////////////

// Connection/Transaction for ADO.NET/DAPPER database
builder.Services.AddScoped((s) => new SqlConnection(builder.Configuration.GetConnectionString("MSSQLConnection")));
    builder.Services.AddScoped<IDbTransaction>(s =>
    {
        SqlConnection conn = s.GetRequiredService<SqlConnection>();
        conn.Open();
        return conn.BeginTransaction();
    });

// Dependendency Injection for Repositories/UOW from ADO.NET DAL
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IExpensesRepository, ExpensesRepository>();
builder.Services.AddScoped<IInspectionRepository, InspectionRepository>();
builder.Services.AddScoped<ITruckRepository, TruckRepository>();
builder.Services.AddScoped<IRepairRepository, RepairRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

////////////////////////////////////////////////////////////////////////////////////
/// Enity Framework
////////////////////////////////////////////////////////////////////////////////////
//Connection for EF database + DbContext
builder.Services.AddDbContext<DriversManagementContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);
});

// Dependendency Injection for Repositories/UOW from EF DAL
builder.Services.AddScoped<IEFDriverRepository, EFDriverRepository>();
builder.Services.AddScoped<IEFCompanyRepository, EFCompanyRepository>();
builder.Services.AddScoped<IEFExpenseRepository, EFExpenseRepository>();
builder.Services.AddScoped<IEFInspectionRepository, EFInspectionRepository>();
builder.Services.AddScoped<IEFPhotoRepository, EFPhotoRepository>();
builder.Services.AddScoped<IEFRepairRepository, EFRepairRepository>();
builder.Services.AddScoped<IEFTruckRepository, EFTruckRepository>();
builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

// Dependendency Injection for Helpers
builder.Services.AddScoped<ISortHelper<EFDriver>, SortHelper<EFDriver>>();

// Dependendency Injection for Managers
builder.Services.AddScoped<IDriversManager, DriversManager>();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<IExpenseManager, ExpenseManager>();
builder.Services.AddScoped<IInspectationManager, InspectationManager>();
builder.Services.AddScoped<IPhotoManager, PhotoManager>();
builder.Services.AddScoped<IRepairManager, RepairManager>();
builder.Services.AddScoped<ITruckManager, TruckManager>();

builder.Services.AddTransient<ExceptionMiddleware>();
//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//FLUENT VALIDATION
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddScoped<IValidator<MiniDriverReqDTO>, MiniDriverReqDTO_Validator>();

// Controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();


app.MapControllers();
app.Run();