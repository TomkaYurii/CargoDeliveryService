using AutoMapper;
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
        private readonly IMapper _mapper;
        private IUnitOfWork _ADOuow;
        private IEFUnitOfWork _EFuow;
        
        public DriversManager(ILogger<DriversManager> logger,
            IMapper mapper,
            IUnitOfWork ado_unitofwork,
            IEFUnitOfWork eFUnitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
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
            var driver = await _EFuow.EFDriverRepository.GetByIdAsync(id);
            if (driver == null)
            {
                // Обработка случая, когда водитель с указанным id не найден.
                return null;
            }

            if (driver.CompanyId.HasValue)
            {
                var company = await _EFuow.EFCompanyRepository.GetByIdAsync(driver.CompanyId.Value);
                driver.Company = company;
            }

            if (driver.PhotoId.HasValue)
            {
                var photo = await _EFuow.EFPhotoRepository.GetByIdAsync(driver.PhotoId.Value);
                driver.Photo = photo;
            }

            var expenses = await _EFuow.EFExpenseRepository.GetExpencesByDriver(driver.Id);
            driver.Expenses = expenses.ToList();

            result = _mapper.Map<FullDriverResponceDTO>(driver);

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
