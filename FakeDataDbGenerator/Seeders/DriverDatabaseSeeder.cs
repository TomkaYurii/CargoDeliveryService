using Bogus;
using FakeDataDriverDbGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDataDriverDbGenerator.Seeders
{
    public class DriverDatabaseSeeder
    {
        public IReadOnlyCollection<Company> Companies { get; } = new List<Company>();
        public DriverDatabaseSeeder()
        {
            Companies = GenerateCompanies(amount: 20);
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

        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }


    }
}
