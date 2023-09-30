using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using MyEventsEntityFrameworkDb.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL_EF.Repositories
{
    public class EFPhotoRepository : EFGenericRepository<EFPhoto>, IEFPhotoRepository
    {
        public EFPhotoRepository(DriversManagementContext databaseContext) : base(databaseContext)
        {
        }

        /// <summary>
        /// Отримання повної інформації з таблиці Photo по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<EFPhoto> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
