using AutoMapper;
using MetatraderApi.Dto;
using MetatraderApi.Models;

namespace MetatraderApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UseForGetDataDto, MetaTraderInfo>();
        }
    }
}
