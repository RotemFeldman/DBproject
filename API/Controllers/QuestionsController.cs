﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
 
        [HttpGet("{id}")]
        public Question Get(int id)
        {         
           return DBHandler.GetQuestion(id);
        }

    }
}
