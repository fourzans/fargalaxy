using FarGalaxy.Contracts;
using FarGalaxy.Contracts.DataAccess;
using FarGalaxy.Dto;
using FarGalaxy.Repositories;
using FarGalaxy.Repository.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.String;
using static System.Threading.Tasks.Task;
using static System.TimeSpan;

namespace FarGalaxy.Repository
{
    public class NoSqlWeatherRepository : IWeatherRepository
    {
        
        private const string ForecastKeyName = NoSql.Keys.Forecast;

        private readonly INoSqlProvider _noSqlProvider;

        public NoSqlWeatherRepository(INoSqlProvider noSqlProvider)
        {
            _noSqlProvider = noSqlProvider;
        }

        public DaysSummaryDto GetSummaryDto(int day)
        {
            return GetSummaryDtoInternal(day);
        }

        private DaysSummaryDto GetSummaryDtoInternal(int day)
        {
            var key = Format(NoSql.Keys.Volatile, day);
            DaysSummaryDto summaryDto = _noSqlProvider.Get<DaysSummaryDto>(key);

            if (summaryDto != null)
                return summaryDto;

            summaryDto = _noSqlProvider.Get<DaysSummaryDto>(key);

            if (summaryDto != null)
                return summaryDto;

            List<DaysSummaryDto> forecast = _noSqlProvider.Get<List<DaysSummaryDto>>(ForecastKeyName);

            if (forecast != null)
            {
                summaryDto = forecast.FirstOrDefault(item => item.Day == day);
                if (summaryDto != null)
                {
                    Task[] tasks =
                    {
                        Factory.StartNew(() => { _noSqlProvider.Add(key, summaryDto, FromHours(1)); })
                    };

                    WaitAll(tasks);
                }
            }

            return summaryDto;
        }
    }
}
