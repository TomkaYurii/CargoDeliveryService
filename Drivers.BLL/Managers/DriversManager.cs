using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs.Responces;
using Drivers.DAL.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.BLL.Managers
{
    public class DriversManager : IDriversManager
    {
        private readonly ILogger<DriversManager> _logger;
        private IUnitOfWork _ADOuow;
        public DriversManager(ILogger<DriversManager> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }

        public Task<IEnumerable<ShortDriverResponceDTO>> GetListOfAllDrivers()
        {
            throw new NotImplementedException();
        }

        public async Task<FullDriverResponceDTO> GetFullInfoAboutDriver(int id)
        {
            var result = new FullDriverResponceDTO();
            var driver = await _ADOuow._driverRepository.GetAsync(id);
            var company = await _ADOuow._companyRepository.GetAsync(driver.CompanyID);
            var photo = await _ADOuow._photoRepository.GetAsync(driver.PhotoID);

            result.drv = driver;
            result.cmp = company;
            result.pht = photo;

            return result;

        }
    }
}
