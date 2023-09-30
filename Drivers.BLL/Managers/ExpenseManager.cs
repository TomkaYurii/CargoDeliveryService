using Drivers.BLL.Contracts;
using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_EF.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BLL.Managers
{
    public class ExpenseManager : IExpenseManager
    {
        private readonly ILogger<ExpenseManager> _logger;
        private IUnitOfWork _ADOuow;
        private IEFUnitOfWork _EFuow;

        public ExpenseManager(ILogger<ExpenseManager> logger,
            IUnitOfWork ado_unitofwork,
            IEFUnitOfWork eFUnitOfWork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
            _EFuow = eFUnitOfWork;
        }
    }
}
