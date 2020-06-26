using AutoMapper;
using MetatraderApi.Dto;
using MetatraderApi.Models;

namespace MetatraderApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UseForGetDataDto, TbTimeFrameM5>();

            CreateMap<UseToCalculateM10Dto ,TbTimeFrameM10>();

            CreateMap<UseToSaveMovingAverangeDto, MovingAverage>();

            CreateMap<UseToSavePriceDto, PriceIndicator>();
        }
    }
}
