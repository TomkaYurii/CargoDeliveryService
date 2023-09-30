using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Helpers;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL_EF.Repositories
{
    public class EFCompanyRepository : EFGenericRepository<EFCompany>, IEFCompanyRepository
    {
        public EFCompanyRepository(DriversManagementContext databaseContext) : base(databaseContext)
        {
        }

        /// <summary>
        /// Отримання повної інформації з таблиці компанії по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<EFCompany> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
