using AutoMapper;
using FullAppApi.Models;

namespace FullAppApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NbaPlayerViewModel, NbaPlayerDTO>();
            CreateMap<NbaPlayerDTO, NbaPlayerViewModel>();
        }
    }
}
