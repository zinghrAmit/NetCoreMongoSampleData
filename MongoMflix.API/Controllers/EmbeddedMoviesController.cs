using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Services.EmbeddedMoviesService;

namespace MongoMflix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbeddedMoviesController : ControllerBase
    {
        private readonly IEmbeddedService _embeddedService;
        public EmbeddedMoviesController(IEmbeddedService embeddedService)
        {
            _embeddedService = embeddedService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _embeddedService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("{title}")]
        public async Task<IActionResult> GetByTitle([FromRoute] string title)
        {
            var result = await _embeddedService.GetByTitle(title);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetByYear([FromRoute] int year)
        //{
        //    var result = await _embeddedService.GetByTitle(year);
        //    return Ok(result);
        //}
    }
}
