using FarGalaxy.Entities.Objects.Movements;
using System;

namespace FarGalaxy.Entities.Objects
{
    public class Planet : CelestialObject
    {
        public Movement Movement { get; set; }

        public void Move(int interval)
        {
            Movement.Move(this, Speed * Math.PI / 180, interval);
        }
    }
}
