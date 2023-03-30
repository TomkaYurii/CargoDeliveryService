using FakeDataDriverDbGenerator.Data;
using FakeDataDriverDbGenerator.Entities;
using FakeDataDriverDbGenerator.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var db_seeder = new DriversManagementDatabaseSeeder();


//var comp = db_seeder.Companies;

//var trucks = db_seeder.Trucks;
//var insp = db_seeder.Inspections;

//var context = new DriversManagementContext();

////var result = context.Trucks.FromSqlRaw("SELECT * FROM Trucks WHERE TruckId = {0}", 1).ToList();
//context.Companies.FromSqlRaw("SET IDENTITY_INSERT Companies ON;");
//context.Companies.AddRange(comp);
//context.Trucks.AddRange(trucks);
//context.Inspections.AddRange(insp);


//context.SaveChanges();
//context.Companies.FromSqlRaw("SET IDENTITY_INSERT Companies OFF;");

////context.Trucks.FromSqlRaw("ALTER TABLE Trucks ALTER COLUMN TruckId INT IDENTITY(1,1)");

Console.Write("Press <Enter> to exit... ");
while (Console.ReadKey().Key != ConsoleKey.Enter) { }