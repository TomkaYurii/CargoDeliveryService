using Drivers.DAL.Contracts;
using Drivers.DAL.Repositories;
using Microsoft.Data.SqlClient;
using MyEventsAdoNetDB.Repositories;
using System.Data;


//ÊÎÍÔ²ÃÐÓÂÀÍÍß: 1) ôàéëè êîíô³ãóðàö³é 2) IOC 3)ëîã³þâàííÿ
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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