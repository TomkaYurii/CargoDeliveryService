using AutoMapper;
using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs.Requests;
using Drivers.BLL.DTOs.Responses;
using Drivers.BLL.Exceptions;
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
                throw new NotFoundException($"Driver with {id} cant be found in database!");
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
        /// ОТРИМАННЯ CКОРОЧЕНОї ІНФОРМАЦІЇ ПРО ВСІХ ВСІХ ВОДІЇВ
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<ShortDriverResponceDTO>> GetListOfAllDrivers()
        {
            var alldrv = await _EFuow.EFDriverRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShortDriverResponceDTO>>(alldrv);
        }

        /// <summary>
        /// ДОДАВАННЯ ВОДІЯ
        /// </summary>
        /// <param name="driverDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<EFDriver> AddDriverToSystemAsync(MiniDriverReqDTO driverDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _EFuow.BeginTransactionAsync(cancellationToken);
                    var result = await _EFuow.EFDriverRepository.AddAsync(_mapper.Map<EFDriver>(driverDTO));
                    await _EFuow.CompleteAsync(cancellationToken);
                await _EFuow.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                await _EFuow.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException("Error in transaction while adding information about driver", ex);
            }
        }

        /// <summary>
        /// ОНОВЛЕННЯ ІНФОРМАЦІЇ ПРО ВОДІЯ
        /// </summary>
        /// <param name="driverDTO">Скорочена інфа про водія</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<EFDriver> UpdateDriverInSystemAsync(int id, MiniDriverReqDTO driverDTO, CancellationToken cancellationToken)
        {
            var driverEntity = await _EFuow.EFDriverRepository.GetByIdAsNoTrackingAsync(id);
            if (driverEntity == null)
            {
                throw new NotFoundException($"Driver with {id} cant be found and updated in database!");
            }
            try
            {
                await _EFuow.BeginTransactionAsync(cancellationToken);
                await _EFuow.EFDriverRepository.UpdateAsync(_mapper.Map<EFDriver>(driverDTO));
                await _EFuow.CompleteAsync(cancellationToken);

                await _EFuow.CommitTransactionAsync(cancellationToken);
                return await _EFuow.EFDriverRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                await _EFuow.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException("Error in transaction while updating information about driver", ex);
            }
        }

        /// <summary>
        /// Видалення запису водія
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task DeleteDriverFromSystemAsync(int id, CancellationToken cancellationToken)
        {
            var driverEntity = await _EFuow.EFDriverRepository.GetByIdAsNoTrackingAsync(id);
            if (driverEntity == null)
            {
                throw new NotFoundException($"Driver with {id} cant be found and deleted from database!");
            }
            try
            {
                await _EFuow.BeginTransactionAsync(cancellationToken);
                await _EFuow.EFDriverRepository.DeleteByIdAsync(id);
                await _EFuow.CompleteAsync(cancellationToken);
                await _EFuow.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await _EFuow.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException("Error in transaction while updating information about driver", ex);
            }
        }
    }
}
