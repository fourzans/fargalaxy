using FarGalaxy.Dto;
using FarGalaxy.Entities.Weather;
using static AutoMapper.Mapper;

namespace FarGalaxy.IoC
{
    public class WebApiBuilder : BuilderBase
    {
        public WebApiBuilder()
        {
            Initialize(config =>
            {
                config.CreateMap<WeatherForecastSummary, WeatherForecastSummaryDto>();
                config.CreateMap<Day, DaysSummaryDto>()
                    .ForMember(source => source.Weather, option => option.MapFrom(source => source.GetType().Name))
                    .ForMember(source => source.Day, option => option.MapFrom(source => source.DayNumber));
            });
        }
    }
}
