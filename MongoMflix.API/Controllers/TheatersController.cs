using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Models.Domain;
using MongoMflix.API.Services.TheaterService;

namespace MongoMflix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly ITheatersService _theatersService;

        public TheatersController(ITheatersService theatersService)
        {
            _theatersService = theatersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _theatersService.GetAllAsync();
            return Ok(result);
        }
    }
}
