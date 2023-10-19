using AutoMapper;
using FullAppApi.Data;
using FullAppApi.DTOs;
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
            var mappedPlayers = players.Select(player => _mapper.Map<GetNbaPlayerDto>(player));
            return Ok(mappedPlayers);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateNbaPlayer(AddNbaPlayerDto player)
        {
            var playersMapped = _mapper.Map<NbaPlayerViewModel>(player);

            _dataContext.NbaPlayer.Add(playersMapped);
            await _dataContext.SaveChangesAsync();

            return Ok(playersMapped.Id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNbaPlayer(UpdateNbaPlayerDto player)
        {
            var dbPlayer = await _dataContext.NbaPlayer.FindAsync(player.Id);
            if (dbPlayer == null)
                return BadRequest("Nicht vorhanden");

            //_dataContext.Entry(dbPlayer).State = EntityState.Detached; // hier wuerde es Update brauchen
            //da es diese Zeile fuer eine Neue Instanz brauchen wuerde

            _mapper.Map(player, dbPlayer); // direkt in dbPlayer instanz mappen
                                           // und somit dieselbe instanz von anfang
                                           // an bearbeiten, sonst wird es zu einer neuesn Instanz

            _dataContext.NbaPlayer.Update(dbPlayer); // braucht es nicht mal, da EF Core weiss,
                                                     // dass die Entity Instanz veraendert wird und
                                                     // bei saveChangesAsync, uebernimmt es einfach die gemachten aenderungen

            await _dataContext.SaveChangesAsync();

            return Ok();


            ///////

            //var dbPlayer = await _dataContext.NbaPlayer.FindAsync(player.Id);
            //if (dbPlayer == null)
            //    return BadRequest("Nicht vorhanden");

            //dbPlayer.LastName = player.LastName;
            //dbPlayer.Number = player.Number;

            //await _dataContext.SaveChangesAsync();

            //return Ok();




            //////

            //var dbPlayer = await _dataContext.NbaPlayer.FindAsync(player.Id);
            //if (dbPlayer == null)
            //    return BadRequest("Nicht vorhanden");




            //_mapper.Map(player, dbPlayer); 

            //_dataContext.NbaPlayer.Update(dbPlayer); 

            //await _dataContext.SaveChangesAsync();

            //return Ok();

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
