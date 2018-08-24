using FarGalaxy.Entities;

namespace FarGalaxy.Repositories
{
    public interface IGalaxyRepository
    {
        Galaxy GetDefaultGalaxy();
        
        SolarSystem GetSolarSystem();
    }
}
