﻿using Drivers.DAL_EF.Data;
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
    public class EFTruckRepository : EFGenericRepository<EFTruck>, IEFTruckRepository
    {
        public EFTruckRepository(DriversManagementContext databaseContext) : base(databaseContext)
        {
        }

        /// <summary>
        /// Отримання повної інформації з таблиці Truck по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<EFTruck> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}