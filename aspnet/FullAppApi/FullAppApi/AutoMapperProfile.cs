using AutoMapper;
using FullAppApi.API.DTOs;
using FullAppApi.DTOs;
using FullAppApi.Models;

namespace FullAppApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NbaPlayerViewModel, NbaPlayerDto>().ReverseMap();
            CreateMap<UpdateNbaPlayerDto, NbaPlayerViewModel>();
        }
    }
}
