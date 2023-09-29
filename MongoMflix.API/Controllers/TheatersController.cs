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

        // GET ALL THEATERS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _theatersService.GetAllAsync();
            return Ok(result);
        }

        // GET THEATER BY THEATER ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _theatersService.GetByIdASync(id);
            return Ok(result);
        }

        // GET ALL CITIES NAME WHRE THEATERS ARE PRESENT
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await _theatersService.GetAllCitiesAsync();
            List<string> cities = new List<string>();
            foreach (Theaters ele in result)
            {
                cities.Add(ele.location.address.city);
            }
            return Ok(cities);
        }

        // GET THEATER BY ZIPCODE
        [HttpGet("[action]/{zipcode}")]
        public async Task<IActionResult> GetTheaterByPin([FromRoute] string zipcode)
        {
            var result = await _theatersService.GetByZipcode(zipcode);
            return Ok(result);
        }

    }
}
