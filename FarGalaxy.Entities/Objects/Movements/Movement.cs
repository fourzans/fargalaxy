namespace FarGalaxy.Entities.Objects.Movements
{
    public abstract class Movement
    {
        public abstract void Move(Planet planet, double theta, int interval);
    }
}
