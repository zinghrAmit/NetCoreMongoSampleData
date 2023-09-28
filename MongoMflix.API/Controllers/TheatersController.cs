using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Models.Domain;
using MongoMflix.API.Services.TheaterService;
using System.Collections.Generic;

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _theatersService.GetByIdASync(id);
            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllLocations()
        //{
        //    var result = await _theatersService.GetAllLocationAsync();
        //    return Ok(result);
        //} 
    }
}
