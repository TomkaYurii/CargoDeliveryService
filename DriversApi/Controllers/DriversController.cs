using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs;
using Drivers.BLL.DTOs.Responces;
using Drivers.DAL_EF.Contracts;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Drivers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private IDriversManager _DriversManager;

        public DriversController(ILogger<DriversController> logger,
            IDriversManager driversManager)
        {
            _logger = logger;
            _DriversManager= driversManager;
        }


        //GET: api/driver/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<FullDriverResponceDTO>> GetFullInfoAboutDriver(int id)
        {
            try
            {
                var result = await _DriversManager.GetFullInfoAboutDriver(id);
                if (result == null)
                {
                    _logger.LogInformation($"Driver із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали Driver з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Потрібно дивитись!");
            }
        }









        //GET: api/driver
        [HttpGet]
        public async Task<ActionResult<PagedList<EFDriver>>> GetAllEventsAsync([FromQuery] DriverParameters driverParameters)
        {
            if (!driverParameters.ValidYearRange)
            {
                return BadRequest("Max year of birth cannot be less than min year of birth");
            }
            try
            {
                var drivers = await _DriversManager.GetPaginatedDrivers(driverParameters);
                var metadata = new
                {
                    drivers.TotalCount,
                    drivers.PageSize,
                    drivers.CurrentPage,
                    drivers.TotalPages,
                    drivers.HasNext,
                    drivers.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInformation($"Returned {drivers.TotalCount} owners from database.");

                return Ok(drivers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Запит не відпрацював, щось пішло не так! - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }






        ////GET: api/driver/Id
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Driver>> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        var result = await _ADOuow._driverRepository.GetAsync(id);
        //        if (result == null)
        //        {
        //            _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInformation($"Отримали івент з бази даних!");
        //            return Ok(result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
        //    }
        //}

        ////POST: api/driver
        //[HttpPost]
        //public async Task<ActionResult> PostDriverAsync([FromBody] AddAllInfoAboutDriverDTO model)
        //{
        //    try
        //    {
        //        if (model == null)
        //        {
        //            _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
        //            return BadRequest("Обєкт івенту є null");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
        //            return BadRequest("Обєкт івенту є некоректним");
        //        }

        //        var obj_DriverLicense = new DriverLicense();
        //        obj_DriverLicense.LicenseId = model.LicenseId;
        //        obj_DriverLicense.ExpiryDate = model.ExpiryDate;
        //        obj_DriverLicense.Type = model.Type;

        //        var created_id_license = await _ADOuow._driverlicenseRepository.AddAsync(obj_DriverLicense);

        //        var obj_Car = new Car();
        //        obj_Car.PlateNumber = model.PlateNumber;
        //        obj_Car.Model = model.Model;
        //        obj_Car.Capacity = model.Capacity;

        //        var created_id_car = await _ADOuow._carRepository.AddAsync(obj_Car);

        //        var obj_Country = new Country();
        //        obj_Country.CountryName = model.CountryName;

        //        var created_id_country = await _ADOuow._countryRepository.AddAsync(obj_Country);

        //        var obj_Rating = new Rating();
        //        obj_Rating.Ratings = model.Ratings;

        //        var created_id_rating = await _ADOuow._ratingRepository.AddAsync(obj_Rating);

        //        var obj_Route = new DAL.Entities.Route();
        //        obj_Route.FromPoint = model.FromPoint;
        //        obj_Route.ToPoint = model.ToPoint;

        //        var created_id_route = await _ADOuow._routeRepository.AddAsync(obj_Route);

        //        var obj_Driver = new Driver();
        //        obj_Driver.Name = model.Name;
        //        obj_Driver.Surname = model.Surname;
        //        obj_Driver.Experience = model.Experience;
        //        obj_Driver.Email = model.Email;
        //        obj_Driver.Phone = model.Phone;
        //        obj_Driver.DriverLicense_Id = created_id_license;
        //        obj_Driver.Car_Id = created_id_car;
        //        obj_Driver.Country_Id = created_id_country;
        //        obj_Driver.Rating_Id = created_id_rating;
        //        obj_Driver.Route_Id = created_id_route;

        //        var created_id = await _ADOuow._driverRepository.AddAsync(obj_Driver);
        //        _ADOuow.Commit();
        //        return StatusCode(StatusCodes.Status201Created);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
        //    }
        //}

        ////PUT: api/driver/id
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Driver drv)
        //{
        //    try
        //    {
        //        if (drv == null)
        //        {
        //            _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
        //            return BadRequest("Обєкт івенту є null");
        //        }
        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
        //            return BadRequest("Обєкт івенту є некоректним");
        //        }

        //        var driver_entity = await _ADOuow._driverRepository.GetAsync(id);
        //        if (driver_entity == null)
        //        {
        //            _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
        //            return NotFound();
        //        }

        //        await _ADOuow._driverRepository.ReplaceAsync(drv);
        //        _ADOuow.Commit();
        //        return StatusCode(StatusCodes.Status204NoContent);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
        //    }
        //}

        ////GET: api/driver/Id
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteByIdAsync(int id)
        //{
        //    try
        //    {
        //        var driver_entity = await _ADOuow._driverRepository.GetAsync(id);
        //        if (driver_entity == null)
        //        {
        //            _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
        //            return NotFound();
        //        }

        //        await _ADOuow._driverRepository.DeleteAsync(id);
        //        _ADOuow.Commit();
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
        //    }
        //}


        ////GET: api/events/name
        //[HttpGet("{name:alpha}")]
        //public async Task<ActionResult<Event>> GetEventsByName(string name)
        //{
        //    try
        //    {
        //        var result = await _ADOuow.EFEventRepository.GetEventsByName(name);
        //        if (result == null)
        //        {
        //            _logger.LogInformation($"Івент із іменем: {name}, не був знайдейний у базі даних");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInformation($"Отримали івент з бази даних!");
        //            return Ok(result);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Запис до БД сфейлився! Щось пішло не так  - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
        //    }
        //}
    }
}
