using Drivers.BLL.Contracts;
using Drivers.BLL.Managers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drivers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private readonly ILogger<PhotoController> _logger;
        private IPhotoManager _PhotoManager;

        public PhotoController(ILogger<PhotoController> logger,
            IPhotoManager photoManager)
        {
            _logger = logger;
            _PhotoManager = photoManager;
        }



        // GET: api/<PhotoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PhotoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PhotoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PhotoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhotoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
