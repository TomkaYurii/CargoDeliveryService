using Bogus;
using FakeDataDriverDbGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class DriverDatabaseSeeder
    {
        public IReadOnlyCollection<Company> Companies { get; } = new List<Company>();
        //public IReadOnlyCollection<Driver> Drivers { get; } new List<Driver>();
        public IReadOnlyCollection<Expense> Expenses { get; } new List<Expense>();
        public DriverDatabaseSeeder()
        {
            Companies = GenerateCompanies(amount: 20);
            //Drivers = GenerateDrivers(amount: 20);
            Expenses = GenerateExpenses(amount: 20);
        }

        private IReadOnlyCollection<Company> GenerateCompanies(int amount)
        {
            var CompanyId = 1;
            var companyFaker = new Faker<Company>()
                    //.RuleFor(c => c.CompanyId, f => CompanyId++)
                    .RuleFor(c => c.CompanyName, f => f.Company.CompanyName())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress())
                    .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.ContactPerson, f => f.Name.FullName())
                    .RuleFor(c => c.ContactPhone, f => null)
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

        private IReadOnlyCollection<Expense> GenerateExpenses(int amount)
        {
            var ExpenseId = 1;
            var ExpenseFaker = new Faker<Expense>()
                //.RuleFor(c => c.ExpensesId, f => f.ExpenseId++)
                //.RuleFor(c => c.DriverId, )
                .RuleFor(c => c.DriverPayment, f => f.Finance.Amount())
                .RuleFor(c => c.FuelCost, f => f.Finance.Amount())
                .RuleFor(c => c.MaintenanceCost, f => f.Finance.Amount())
                //.RuleFor(c => c.Category, f => f.PickRandom<ExpenseCategory>())
                .RuleFor(c => c.Date, f => f.Date.Past())
                .RuleFor(c => c.Note, f => f.)

        }



        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }


    }
}
