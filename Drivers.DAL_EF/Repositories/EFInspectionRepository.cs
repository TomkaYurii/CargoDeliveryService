using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Repositories.Contracts;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL_EF.Repositories
{
    public class EFInspectionRepository : EFGenericRepository<EFInspection>, IEFInspectionRepository
    {
        public EFInspectionRepository(DriversManagementContext databaseContext) : base(databaseContext)
        {
        }

        /// <summary>
        /// Отримання повної інформації з таблиці Inspection по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<EFInspection> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
