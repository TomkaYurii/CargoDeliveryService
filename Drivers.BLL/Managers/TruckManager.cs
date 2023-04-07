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
    public class TruckManager : ITruckManager
    {
        private readonly ILogger<TruckManager> _logger;
        private IUnitOfWork _ADOuow;
        private IEFUnitOfWork _EFuow;

        public TruckManager(ILogger<TruckManager> logger,
            IUnitOfWork ado_unitofwork,
            IEFUnitOfWork eFUnitOfWork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
            _EFuow = eFUnitOfWork;
        }
    }
}
