using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Services.SessionsService;

namespace MongoMflix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionsService _sessionsService;
        public SessionsController(ISessionsService sessionsService)
        {
            _sessionsService = sessionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var result =  await _sessionsService.GetAllAsync();
           return Ok(result);
        }
    }
}
