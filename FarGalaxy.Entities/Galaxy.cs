using FarGalaxy.Contracts.Weather;

namespace FarGalaxy.Entities
{
    public class Galaxy : IGravitationalSystem
    {
        public SolarSystem SolarSystem { get; set; }
    }
}
