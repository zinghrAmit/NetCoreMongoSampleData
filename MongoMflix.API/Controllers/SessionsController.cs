using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Models.Domain;
using MongoMflix.API.Services.SessionsService;
using System.Collections.Generic;
using MongoMflix.API.DTO.Sessions;

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
           var resultDto = new List<SessionsDto>();
           foreach(var ele in result)
            {
                resultDto.Add(new SessionsDto() 
                {
                    Id = ele.Id,
                    user_id =  ele.user_id,
                    jwt = ele.jwt,
                });
            }
            
           return Ok(resultDto);
        }


        [HttpGet("{user_id}")]
        public async Task<IActionResult> GetById([FromRoute] string user_id)
        {
            var result = await _sessionsService.GetByUserIdAsync(user_id);
            var resultDto = new List<SessionsDto>();
            resultDto.Add(new SessionsDto()
            {
                Id = result[0].Id,
                user_id = result[0].user_id,
                jwt = result[0].jwt,
            });
            return Ok(resultDto);
        }
    }
}
