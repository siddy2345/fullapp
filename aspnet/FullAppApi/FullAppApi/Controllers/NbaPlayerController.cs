using AutoMapper;
using FullAppApi.Data;
using FullAppApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FullAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbaPlayerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public NbaPlayerController(DataContext context, IMapper mapper)
        {
            _dataContext = context;
            _mapper = mapper;
        }

        [Route("players")]
        [HttpGet]
        public async Task<ActionResult<List<NbaPlayerViewModel>>> GetNbaPlayers()
        {
            
            var players = await _dataContext.NbaPlayer.ToListAsync();
            var mappedPlayers = players.Select(player => _mapper.Map<NbaPlayerDTO>(player));
            return Ok(mappedPlayers);
        }

        [HttpPost]
        public async Task<ActionResult<List<NbaPlayerViewModel>>> CreateNbaPlayer(NbaPlayerDTO player)
        {
            var playersMapped = _mapper.Map<NbaPlayerViewModel>(player);

            _dataContext.NbaPlayer.Add(playersMapped);
            await _dataContext.SaveChangesAsync();

            return Ok(player.Id);
        }

        [HttpPut]
        public async Task<ActionResult<List<NbaPlayerViewModel>>> UpdateNbaPlayer(NbaPlayerDTO player)
        {
            var dbPlayer = await _dataContext.NbaPlayer.FindAsync(player.Id);
            if (dbPlayer == null)
                return BadRequest("Nicht vorhanden");

            var playersMapped = _mapper.Map<NbaPlayerViewModel>(player);



            _dataContext.NbaPlayer.Add(playersMapped);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<List<NbaPlayerViewModel>>> UpdateNbaPlayer(int id)
        {
            var dbPlayer = await _dataContext.NbaPlayer.FindAsync(id);
            if (dbPlayer == null)
                return BadRequest("Nicht vorhanden");

            _dataContext.NbaPlayer.Remove(dbPlayer);
            _dataContext.SaveChanges();

            return Ok();
        }
    }
}
