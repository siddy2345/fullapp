using AutoMapper;
using FullAppApi.DTOs;
using FullAppApi.Models;

namespace FullAppApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NbaPlayerViewModel, GetNbaPlayerDto>();
            CreateMap<AddNbaPlayerDto, NbaPlayerViewModel>();
            CreateMap<UpdateNbaPlayerDto, NbaPlayerViewModel>();
        }
    }
}
