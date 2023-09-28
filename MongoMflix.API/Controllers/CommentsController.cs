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
            // "GetAllAsync()" is defined in "commentsService.cs"
            var comments = await _commentsService.GetAllAsync();
            return Ok(comments);
        }
    }
}
