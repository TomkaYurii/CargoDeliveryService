using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Data;
using Drivers.DAL_EF.Entities;
using MyEventsEntityFrameworkDb.EFRepositories;

namespace Drivers.DAL_EF.Repositories
{
    public class EFExpenseRepository : EFGenericRepository<EFExpense>, IEFExpenseRepository
    {
        public EFExpenseRepository(DriversManagementContext databaseContext) : base(databaseContext)
        {
        }

        /// <summary>
        /// Отримання повної інформації з таблиці Expense по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task<EFExpense> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
