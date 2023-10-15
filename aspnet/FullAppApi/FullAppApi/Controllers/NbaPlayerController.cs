using FullAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaPlayerController : ControllerBase
    {
        [Route("players")]
        [HttpGet]
        public async Task<ActionResult<List<NbaPlayerViewModel>>> GetNbaPlayers()
        {
            return new List<NbaPlayerViewModel> 
            {
                new NbaPlayerViewModel
                {
                    Surname = "LeBron",
                    LastName = "James",
                    Franchise = "Lakers",
                    Number = 6
                },
                new NbaPlayerViewModel
                {
                    Surname = "Stephen",
                    LastName = "Curry",
                    Franchise = "Warriors",
                    Number = 30
                }
            };
        }
    }
}
