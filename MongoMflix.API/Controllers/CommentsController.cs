using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Services.CommentsService;

namespace MongoMflix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;     
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentsService.GetAllAsync();
            return Ok(comments);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var result = await _commentsService.GetCommentsById(id);
            return Ok(result);
        }

        // TO REMOVE MULTIPLE END POINT ERROR WHILE CALLING API, WE ARE ADDINT "ACTION NAME" IN THE ROUTE
        [HttpGet("[action]/{email}")]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var result = await _commentsService.GetCommentsByEmail(email);
            return Ok(result);
        }

        [HttpGet("[action]/{date}")]
        public async Task<IActionResult> GetByDate([FromRoute] DateTime date)
        {
            var result = await _commentsService.GetCommentsByDate(date);
            return Ok(result);
        }
    }
}
