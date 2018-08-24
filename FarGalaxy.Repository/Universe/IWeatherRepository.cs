using FarGalaxy.Dto;

namespace FarGalaxy.Repositories
{
    public interface IWeatherRepository
    {
        DaysSummaryDto GetSummaryDto(int day);
    }
}
