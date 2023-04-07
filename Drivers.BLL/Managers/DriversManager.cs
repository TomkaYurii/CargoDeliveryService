using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs.Responses;
using Drivers.DAL_ADO.Contracts;
using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;
using Microsoft.Extensions.Logging;

namespace Drivers.BLL.Managers
{
    public class DriversManager : IDriversManager
    {
        private readonly ILogger<DriversManager> _logger;
        private IUnitOfWork _ADOuow;
        private IEFUnitOfWork _EFuow;
        
        public DriversManager(ILogger<DriversManager> logger,
            IUnitOfWork ado_unitofwork,
            IEFUnitOfWork eFUnitOfWork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
            _EFuow = eFUnitOfWork;
        }

        /// <summary>
        /// ПОВНА ІНФОРМАЦІЯ ПРО ВОДІЯ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ОТРИМАННЯ ПАГІНОВАНИХ ДАНИХ ПРО ВОДІЯ
        /// </summary>
        /// <param name="driverParameters"></param>
        /// <returns></returns>
        public async Task<PagedList<EFDriver>> GetPaginatedDrivers(DriverParameters driverParameters)
        {
            return await _EFuow.EFDriverRepository.GetPaginatedDriversAsync(driverParameters);
        }

        /// <summary>
        /// ОТРИМАННЯ СПИСКУ ВСІХ ВОДІЇВ
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<ShortDriverResponceDTO>> GetListOfAllDrivers()
        {
            throw new NotImplementedException();
        }
    }
}
