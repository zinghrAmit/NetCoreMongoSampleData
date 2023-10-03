using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Services.EmbeddedMoviesService;
using MongoMflix.API.DTO.EmbeddedMovies;
using MongoMflix.API.Models.Domain;
using SharpCompress.Writers;

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
            var resultDto = new List<EmbeddedMoviesDto>();
            foreach (var item in result)
            {
                var dto = new EmbeddedMoviesDto()
                {
                    genres = item.genres,
                    cast = item.cast,
                    num_mflix_comments = item.num_mflix_comments,
                    poster = item.poster,
                    title = item.title,
                    fullplot = item.fullplot,
                    languages = item.languages,
                    released = item.released,
                    directors = item.directors,
                    writers = item.writers,
                    year = item.year,
                    countries = item.countries,
                    type = item.type,
                    //awards = (DTO.EmbeddedMovies.Awards)item.awards,
                    //imdb = (DTO.EmbeddedMovies.Imdb)item.imdb,
                    //tomatoes = (DTO.EmbeddedMovies.Tomatoes)item.tomatoes,
                };

            }
            return Ok(resultDto);
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
