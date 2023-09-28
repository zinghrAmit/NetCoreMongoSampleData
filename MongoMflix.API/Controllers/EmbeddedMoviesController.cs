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
    }
}
