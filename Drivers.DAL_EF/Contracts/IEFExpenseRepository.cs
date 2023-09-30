using Drivers.DAL_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.DAL_EF.Contracts
{
    public interface IEFExpenseRepository : IEFGenericRepository<EFExpense>
    {
        Task<IEnumerable<EFExpense>> GetExpencesByDriver(int driver_id);
    }
}
