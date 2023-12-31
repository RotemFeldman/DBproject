﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public int Get()
        {
            return DBHandler.GetPlayerCount();
        }

        [HttpGet("Statuses")]
        public int Get2()
        {
            return DBHandler.GetPlayerStatusSum();
        }

        [HttpGet("Winner")]
        public string Get3()
        {
            return DBHandler.GetWinner();
        }
    }
}
