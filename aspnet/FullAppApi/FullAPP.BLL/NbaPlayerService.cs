using AutoMapper;
using FullAppApi.Data;
using FullAppApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAPP.BLL
{
    public class NbaPlayerService
    {
        public enum UpdateResult
        {
            NotFound,
            Success,
            Failure
        }

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public NbaPlayerService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<UpdateResult> UpdateNbaPlayer(UpdateNbaPlayerDto player)
        {
            var dbPlayer = await _dataContext.NbaPlayer.FindAsync(player.Id);
            if (dbPlayer == null)
                return UpdateResult.NotFound;

            // Validate the player data (you can add validation logic here)

            _mapper.Map(player, dbPlayer);

            try
            {
                _dataContext.NbaPlayer.Update(dbPlayer);
                await _dataContext.SaveChangesAsync();
                return UpdateResult.Success;
            }
            catch (Exception)
            {
                // Handle any database-related errors
                return UpdateResult.Failure;
            }
        }
    }
}
