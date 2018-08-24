using FarGalaxy.Entities;
using FarGalaxy.Entities.Weather;
using FarGalaxy.Entities.Weather.Conditions;
using FarGalaxy.Entities.WeatherConditions.Rules;

namespace FarGalaxy.Services.WeatherConditions.Rules
{
    public class UnknownRule : BaseRule<SolarSystem>
    {
        public override Day Request(SolarSystem solarSystem)
        {
            return new UnknownDay();
        }
    }
}
