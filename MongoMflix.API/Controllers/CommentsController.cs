using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoMflix.API.Models.Domain;
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
            try
            {
                var result = await _commentsService.GetCommentsByEmail(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{date}")]
        public async Task<IActionResult> GetByDate([FromRoute] DateTime date)
        {
            try
            {
                var result = await _commentsService.GetCommentsByDate(date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST A COMMENT
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] Comments comment)
        {
            try
            {
                await _commentsService.PostComment(comment);
                return Ok("Posted Succesfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // UPDATE A COMMENT
        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateComment([FromRoute] string email, [FromBody] string comment)
        {
            try
            {
                await _commentsService.UpateCommentAsync(email, comment);
                return Ok("Comment Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE A COMMENT
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteComment([FromRoute] string email)
        {
            try
            {
                await _commentsService.DeleteCommentAsync(email);
                return Ok("Comment Deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
    }
}
