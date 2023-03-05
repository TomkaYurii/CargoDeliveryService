using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Post.BLL.Services.Contracts;
using Post.DAL.Entities;

namespace Post.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ILogger<TopicController> _logger;

        private ITopicService _topicService;
        public TopicController(ILogger<TopicController> logger,
            ITopicService topicService)
        {
            _logger = logger;
            _topicService= topicService;
        }


        [HttpPut]
        public async Task<ActionResult> UpdateEventAsync([FromBody] ForumTopic ftp)
        {
            try
            {
                if (ftp == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                //var driver_entity = await _ADOuow._driverRepository.GetAsync(id);
                //if (driver_entity == null)
                //{
                //    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                //    return NotFound();
                //}

                await _topicService.UpdateLast(ftp);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
