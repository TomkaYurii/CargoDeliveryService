using Microsoft.AspNetCore.Mvc;
using Post.DAL.Entities;
using Post.DAL.UOW.Contracts;

namespace Post.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class PostController : ControllerBase
        {
            private readonly ILogger<PostController> _logger;

            private IUnitOfWork _ADOuow;
            public PostController(ILogger<PostController> logger,
                IUnitOfWork ado_unitofwork)
            {
                _logger = logger;
                _ADOuow = ado_unitofwork;
            }

            //GET: api/post
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ForumPost>>> GetAllEventsAsync(int topicId)
            {
                try
                {
                    var results = await _ADOuow._postRepository.GetLastInTopic(topicId);

                    _logger.LogInformation($"Last Post from topic");
                    return Ok(results);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Запит не відпрацював, щось пішло не так! - {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
                }
            }


            ////GET: api/driver
            //[HttpGet]
            //public async Task<ActionResult<IEnumerable<pf_Post>>> GetAllEventsAsync()
            //{
            //    try
            //    {
            //        var results = await _ADOuow._pf_postRepository.GetAllAsync();

            //        _logger.LogInformation($"Отримали всі івенти з БД");
            //        return Ok(results);
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogError($"Запит не відпрацював, щось пішло не так! - {ex.Message}");
            //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            //    }
            //}

            ////GET: api/driver/Id
            //[HttpGet("{id}")]
            //public async Task<ActionResult<pf_Post>> GetByIdAsync(int id)
            //{
            //    try
            //    {
            //        var result = await _ADOuow._pf_postRepository.GetAsync(id);
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
            //public async Task<ActionResult> PostDriverAsync([FromBody] AddAllInfoAboutPostDTO model)
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

            //        var obj_Post = new pf_Post();
            //        obj_Post.PostId = model.PostId;
            //        obj_Post.ParentPostId = model.ParentPostId;
            //        obj_Post.Ip = model.Ip;
            //        obj_Post.UserId = model.UserId;
            //        obj_Post.FullText = model.FullText;
            //        obj_Post.IsDeleted = model.IsDeleted;
            //        obj_Post.IsEdited = model.IsEdited;
            //        obj_Post.IsFirstInTopic = model.IsFirstInTopic;
            //        obj_Post.LastEditName = model.LastEditName;
            //        obj_Post.LastEditTime = model.LastEditTime;
            //        obj_Post.Title = model.Title;
            //        obj_Post.Name = model.Name;
            //        obj_Post.Votes = model.Votes;
            //        obj_Post.TopicId = model.TopicId;
            //        obj_Post.PostTime = model.PostTime;

            //        var created_id = await _ADOuow._pf_postRepository.AddAsync(obj_Post);
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
            //public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] pf_Post drv)
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

            //        var driver_entity = await _ADOuow._pf_postRepository.GetAsync(id);
            //        if (driver_entity == null)
            //        {
            //            _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
            //            return NotFound();
            //        }

            //        await _ADOuow._pf_postRepository.ReplaceAsync(drv);
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
            //        var driver_entity = await _ADOuow._pf_postRepository.GetAsync(id);
            //        if (driver_entity == null)
            //        {
            //            _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
            //            return NotFound();
            //        }

            //        await _ADOuow._pf_postRepository.DeleteAsync(id);
            //        _ADOuow.Commit();
            //        return NoContent();
            //    }
            //    catch (Exception ex)
            //    {
            //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
            //        return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            //    }
            //}
        }
    }

