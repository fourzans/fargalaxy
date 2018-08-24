using Newtonsoft.Json;

namespace FarGalaxy.Entities.Weather.Conditions
{
    [JsonObject(Title = "Desconocido")]
    public class UnknownDay : Day
    {
        public override void Sum(WeatherForecastSummary weatherForecastSummary)
        {
            //Do not anything.
        }

        public override string ToString()
        {
            return "Desconocido";
        }
    }
}
