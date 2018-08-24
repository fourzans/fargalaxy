using FarGalaxy.Contracts.Weather;
using FarGalaxy.Entities.Objects;
using System.Collections.Generic;
using System.Linq;

namespace FarGalaxy.Entities
{
    public class SolarSystem : IGravitationalSystem
    {
        public Star Sun { get; set; }

        public List<Planet> Planets { get; set; }

        public Planet Ferengi => Planets.Single(planet => planet.Name.Equals(nameof(Ferengi)));

        public Planet Betazoid => Planets.Single(planet => planet.Name.Equals(nameof(Betazoid)));

        public Planet Vulcan => Planets.Single(planet => planet.Name.Equals(nameof(Vulcan)));
    }
}
