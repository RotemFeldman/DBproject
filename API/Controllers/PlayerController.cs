using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpGet("AddPlayer/{name}")]
        public void Get(string name)
        {
            DBHandler.AddPlayer(name);
        }

        [HttpGet("Status/{name}")]
        public int Get2(string name)
        {
            return DBHandler.GetPlayerStatus(name);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return DBHandler.GetPlayerName(id);
        }

        //[HttpPost("playerId")]
        //public void Post(int playerId)
        //{
        //    DBHandler.AddScore(playerId);
        //}

        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    DBHandler.DeleteAllPlayersData();
        //}
    }
}
