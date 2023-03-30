using Bogus;
using FakeDataDriverDbGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FakeDataDriverDbGenerator.Seeders
{
    public enum Gender
    {
        Male,
        Female
    }
    public enum ExpenseCategory
    {
        Fuel,
        Fine,
        Maintenance
    }

    public class DriversManagementDatabaseSeeder
    {
        private int quantity;
        public IReadOnlyCollection<Company> Companies { get; } = new List<Company>();
        public IReadOnlyCollection<Driver> Drivers { get; } = new List<Driver>();
        public IReadOnlyCollection<Expense> Expenses { get; } = new List<Expense>();
        public IReadOnlyCollection<Inspection> Inspections { get; } = new List<Inspection>();
        public IReadOnlyCollection<Repair> Repairs { get; } = new List<Repair>();
        public IReadOnlyCollection<Truck> Trucks { get; } = new List<Truck>();
        public IReadOnlyCollection<Photo> Photos { get; } = new List<Photo>();

        public DriversManagementDatabaseSeeder(int number_of_rows = 20)
        {
            quantity = number_of_rows;
            Companies = GenerateCompanies(amount: quantity);
            //Drivers = GenerateDrivers(amount: quantity);
            //Expenses = GenerateExpenses(amount: quantity);
            Trucks = GenerateTrucks(amount: quantity);

            Inspections = GenerateInspections(amount: quantity, Trucks);
            this.quantity = quantity;
            //Repairs = GenerateRepairs(amount: quantity);

            Photos = GeneratePhotos(amount: quantity);
        }

        private IReadOnlyCollection<Company> GenerateCompanies(int amount)
        {
            var CompanyId = 1;
            var companyFaker = new Faker<Company>()
                    .RuleFor(c => c.CompanyId, f => CompanyId++)
                    .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress())
                    .RuleFor(c => c.Phone, f => f.Phone.PhoneNumberFormat())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.ContactPerson, f => f.Name.FullName())
                    .RuleFor(c => c.ContactPhone, f => f.Phone.PhoneNumberFormat())
                    .RuleFor(c => c.ContactEmail, f => f.Internet.Email())
                    .RuleFor(c => c.CreatedAt, f => f.Date.Past())
                    .RuleFor(c => c.UpdatedAt, f => null as DateTime?)
                    .RuleFor(c => c.DeletedAt, f => null as DateTime?)
                    .RuleFor(c => c.Driver, f => null);
            var companies = Enumerable.Range(1, amount)
                    .Select(i => SeedRow(companyFaker, i))
                    .ToList();
            return companies;
        }

        //private IReadOnlyCollection<Driver> GenerateDrivers(int amount)
        //{
        //    var DriverId = 1;
        //    var driverFaker = new Faker<Driver>()
        //        .RuleFor(c => c.DriverId, f => f.DriverId++)
        //        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
        //        .RuleFor(c => c.LastName, f => f.Name.LastName())
        //        .RuleFor(c => c.MiddleName, f => null)
        //        .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
        //        .RuleFor

        //}

        //private IReadOnlyCollection<Expense> GenerateExpenses(int amount)
        //{
        //    var ExpenseId = 1;
        //    var ExpenseFaker = new Faker<Expense>()
        //        //.RuleFor(c => c.ExpensesId, f => f.ExpenseId++)
        //        //.RuleFor(c => c.DriverId, f => f.)
        //        .RuleFor(c => c.DriverPayment, f => f.Finance.Amount())
        //        .RuleFor(c => c.FuelCost, f => f.Finance.Amount())
        //        .RuleFor(c => c.MaintenanceCost, f => f.Finance.Amount())
        //        //.RuleFor(c => c.Category, f => f.PickRandom<ExpenseCategory>())
        //        .RuleFor(c => c.Date, f => f.Date.Past())
        //        .RuleFor(c => c.Note, f => f.Rant.Review())
        //        .RuleFor(c => c.CreatedAt, f => f.Date.Past())
        //        .RuleFor(c => c.UpdatedAt, f => null as DateTime?)
        //        .RuleFor(c => c.DeletedAt, f => null as DateTime?)
        //        .RuleFor(c => c.Driver, f => null)
        //        .RuleFor(c => c.Truck, f => null);

        //}

        private IReadOnlyCollection<Truck> GenerateTrucks(int amount)
        {
            var TruckId = 1;
            var truckFaker = new Faker<Truck>()
                 .RuleFor(t => t.TruckId, f => TruckId++)
                 .RuleFor(c => c.TruckNumber, f => f.Vehicle.Vin())
                 .RuleFor(c => c.Model, f => f.Vehicle.Model())
                 .RuleFor(c => c.Year, f => f.Date.Past().Year)
                 .RuleFor(c => c.Capacity, f => f.Random.Number(100, 1000))
                 .RuleFor(c => c.FuelType, f => f.Vehicle.Fuel())
                 .RuleFor(c => c.FuelConsumption, f => f.Random.Decimal(1, 5))
                 .RuleFor(c => c.RegistrationNumber, f => f.Vehicle.Vin())
                 .RuleFor(c => c.Vin, f => f.Vehicle.Vin())
                 .RuleFor(c => c.EngineNumber, f => Guid.NewGuid().ToString())
                 .RuleFor(c => c.ChassisNumber, f => Guid.NewGuid().ToString())
                 .RuleFor(c => c.InsurancePolicyNumber, f => Guid.NewGuid().ToString())
                 .RuleFor(c => c.InsuranceExpirationDate, f => f.Date.Future())
                 .RuleFor(c => c.CreatedAt, f => f.Date.Past())
                 .RuleFor(c => c.UpdatedAt, f => null as DateTime?)
                 .RuleFor(c => c.DeletedAt, f => null as DateTime?);
            var trucks = Enumerable.Range(1, amount)
                .Select(i => SeedRow(truckFaker, i))
                .ToList();
            return trucks;
        }


        private IReadOnlyCollection<Inspection> GenerateInspections(int amount, IEnumerable<Truck> trucks)
        {
            var InspectionId = 1;
            var inspectionFaker = new Faker<Inspection>()
                .RuleFor(c => c.InspectionId, f => InspectionId++)
                .RuleFor(c => c.InspectionDate, f => f.Date.Past())
                .RuleFor(c => c.Description, f => f.Lorem.Text())
                .RuleFor(c => c.Result, f => f.Random.Bool())
                .RuleFor(c => c.TruckId, f => f.PickRandom(trucks).TruckId)
                .RuleFor(c => c.CreatedAt, f => f.Date.Past())
                .RuleFor(c => c.UpdatedAt, f => null as DateTime?)
                .RuleFor(c => c.DeletedAt, f => null as DateTime?)
                .RuleFor(c => c.Truck, f => null);
            var inspections = Enumerable.Range(1, amount)
                .Select(i => SeedRow(inspectionFaker, i))
                .ToList();
            return inspections;
        }




        // private static IReadOnlyCollection<ProductProductCategory> GenerateProductProductCategories(
        //int amount,
        //IEnumerable<Product> products,
        //IEnumerable<ProductCategory> productCategories)
        // {
        //     // Now we set up the faker for our join table.
        //     // We do this by grabbing a random product and category that were generated.
        //     var productProductCategoryFaker = new Faker<ProductProductCategory>()
        //         .RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
        //         .RuleFor(x => x.CategoryId, f => f.PickRandom(productCategories).Id);

        //     var productProductCategories = Enumerable.Range(1, amount)
        //         .Select(i => SeedRow(productProductCategoryFaker, i))
        //         // We do this GroupBy() + Select() to remove the duplicates
        //         // from the generated join table entities
        //         .GroupBy(x => new { x.ProductId, x.CategoryId })
        //         .Select(x => x.First())
        //         .ToList();

        //     return productProductCategories;
        // }






        //private IReadOnlyCollection<Repair> GenerateRepairs(int amount)
        //{
        //    var RepairId = 1;
        //    var RepairFaker = new Faker<Repair>()
        //        .RuleFor(c => c.RepairDate, f => f.Date.Past())
        //        .RuleFor(c => c.Description, f => f.Lorem.Text())
        //        .RuleFor(c => c.Cost, f => f.Finance.Amount())
        //        //.RuleFor(c => c.TruckId, f => )
        //        .RuleFor(c => c.CreatedAt, f => f.Date.Past())
        //        .RuleFor(c => c.UpdatedAt, f => null as DateTime?)
        //        .RuleFor(c => c.DeletedAt, f => null as DateTime?)
        //        .RuleFor(c => c.Truck, f => null);
        //}

        private IReadOnlyCollection<Photo> GeneratePhotos(int amount)
        {
            var PhotoId = 1;
            var photoFaker = new Faker<Photo>()
                .RuleFor(c => c.PhotoId, f => PhotoId++)
                .RuleFor(c => c.PhotoData, f => Convert.FromBase64String(f.Image.DataUri(100, 100).Split(',')[1]))
                .RuleFor(c => c.ContentType, (f, u) => f.Commerce.Categories(1)[0])
                .RuleFor(c => c.FileName, f => f.Lorem.Word())
                .RuleFor(c => c.FileSize, f => f.Random.Number(1000, 50000))
                .RuleFor(c => c.CreatedAt, f => f.Date.Past())
                .RuleFor(c => c.UpdatedAt, f => null as DateTime?)
                .RuleFor(c => c.DeletedAt, f => null as DateTime?);
            var photos = Enumerable.Range(1, amount)
                .Select(i => SeedRow(photoFaker, i))
                .ToList();
            return photos;
        }


        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }


    }
}
