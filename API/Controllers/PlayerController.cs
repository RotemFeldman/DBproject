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

        [HttpGet("GetStatus/{name}")]
        public int Get2(string name)
        {
            return DBHandler.GetPlayerStatus(name);
        }

        [HttpGet("SetStatus/{name}")]
        public void Get3(string name)
        {
            DBHandler.SetPlayerStatus(name);
        }

        [HttpGet("AddScore/{name}")]
        public void Get4(string name)
        {
            DBHandler.AddScore(name);
        }

        [HttpGet("GetScore/{name}")]
        public void Get5(string name)
        {
            DBHandler.GetPlayerScore(name);
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
