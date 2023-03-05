using FakeDataDriverDbGenerator.Data;
using FakeDataDriverDbGenerator.Seeders;

var seeder = new DriverDatabaseSeeder();
var commp = seeder.Companies;


var context = new DriversManagementContext();
context.Companies.AddRange(commp);
context.SaveChanges();

Console.Write("Press <Enter> to exit... ");
while (Console.ReadKey().Key != ConsoleKey.Enter) { }