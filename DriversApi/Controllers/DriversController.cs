using Drivers.Api.Exceptions;
using Drivers.BLL.Contracts;
using Drivers.BLL.DTOs.Requests;
using Drivers.BLL.DTOs.Responses;
using Drivers.DAL_EF.Entities;
using Drivers.DAL_EF.Entities.HelpModels;
using Drivers.DAL_EF.Helpers;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Drivers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private IDriversManager _driversManager;

        public DriversController(ILogger<DriversController> logger,
            IDriversManager driversManager)
        {
            _logger = logger;
            _driversManager= driversManager;
        }

        /// <summary>
        /// Get Driver by Id
        /// </summary>
        /// <param name="id">Key</param>
        /// <returns></returns>
        /// <exception cref="NotFoundException">Not found any driver</exception>
        //GET: api/driver/Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FullDriverResponceDTO>> GetFullInfoAboutDriver(int id)
        {
            var result = await _driversManager.GetFullInfoAboutDriver(id);
            if (result == null)
            {
                throw new NotFoundException($"A driver from the database with ID: {id} could not be found.");
            }
            return Ok(result);
        }

        /// <summary>
        /// Get paganated drivers
        /// </summary>
        /// <param name="driverParameters">Model for paginated drivers</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("alldriverspaginated")]
        public async Task<ActionResult<PagedList<EFDriver>>> GetAllDriversPaginatedAsync([FromQuery] DriverParameters driverParameters)
        {
            if (!driverParameters.ValidYearRange)
            {
                return BadRequest("Max year of birth cannot be less than min year of birth");
            }
            try
            {
                var drivers = await _driversManager.GetPaginatedDrivers(driverParameters);
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

        /// <summary>
        /// Get all drivers from database
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("alldrivers")]
        public async Task<ActionResult<IEnumerable<ShortDriverResponceDTO>>> GetAllDriversAsync()
        {

            var result = await _driversManager.GetListOfAllDrivers();
            if (result == null)
            {
                _logger.LogInformation($"Records are absent in database");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Кeceived drivers from the database!");
                return Ok(result);
            }
        }

        /// <summary>
        /// Add driver
        /// </summary>
        /// <param name="model">Information about driver - MiniDriverReqDTO</param>
        /// <param name="validator">FluentValidation validator of MiniDriverReqDTO </param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> PostDriverAsync([FromBody] MiniDriverReqDTO model,
            [FromServices] IValidator<MiniDriverReqDTO> validator,
            CancellationToken cancellationToken)
        {
            this._logger.LogInformation($"==>> API Input : {{ Driver: {model.LastName}}}");
            ValidationResult validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
            {
                // Если есть ошибки из FluentValidation, возвращайте их
                return BadRequest(validationResult.Errors);
            }
            if (!ModelState.IsValid)
            {
                // Если есть ошибки из встроенной валидации атрибутов модели, также возвращайте их
                return BadRequest(ModelState);
            }
            var created_driver = await _driversManager.AddDriverToSystemAsync(model, cancellationToken);
            this._logger.LogInformation($"==>> Added driver : {{ Driver: {created_driver.LastName}-{created_driver.Id}}}");
            return CreatedAtAction(nameof(GetFullInfoAboutDriver), new { id = created_driver.Id }, created_driver);
        }

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
