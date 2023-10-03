using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.DTO.Users;
using MongoMflix.API.Models.Domain;
using MongoMflix.API.Services.UsersService;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MongoMflix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _usersService.GetAllAsycn();
                var resultDto = new List<UsersDto>();
                foreach (var ele in result)
                {
                    resultDto.Add(new UsersDto()
                    {
                        Id = ele.Id,
                        name = ele.name,
                        email = ele.email,
                        password = ele.password
                    });
                }
                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            try
            {
                var result = await _usersService.GetByName(name);
                var resultDto = new List<UsersDto>();
                foreach (var ele in result)
                {
                    resultDto.Add(new UsersDto()
                    {
                        Id = ele.Id,
                        name = ele.name,
                        email = ele.email,
                        password = ele.password
                    });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] Users user)
        {
            try
            {
                await _usersService.PostUserAsync(user);
                return Ok("User Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserName(string currentName, string newName )
        {
            try
            {
                await _usersService.UpdateUserNameAsync(currentName, newName);
                return Ok("User updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletUser([FromBody] string email)
        {
            try
            {
                await _usersService.DeleteUserAsync(email);
                return Ok("User Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
