﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoMflix.API.Models.Domain;
using MongoMflix.API.Services.SessionsService;
using System.Collections.Generic;

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


        [HttpGet("{user_id}")]
        public async Task<IActionResult> GetById([FromRoute] string user_id)
        {
            var result = await _sessionsService.GetByUserIdAsync(user_id);
            return Ok(result);
        }
    }
}
