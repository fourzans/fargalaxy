using FarGalaxy.Dto;
using FarGalaxy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace FarGalaxy.Api.Controllers
{
    public class WeatherController : BaseApiController
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
       
        [Route("weather/{day?}")]
        [HttpGet]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100, AnonymousOnly = true)]
        public DaysSummaryDto GetDaysSummaryDto(int day)
        {
            return Get(day, resourceId => _weatherRepository.GetSummaryDto(day),
                $"Condition for {day} is not available. ");
        }
    }
}