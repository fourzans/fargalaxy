using Autofac;
using AutoMapper;
using FarGalaxy.Contracts.DataAccess;
using FarGalaxy.Dto;
using FarGalaxy.Entities.Weather;
using FarGalaxy.Jobs.Contracts;
using FarGalaxy.Services.WeatherConditions.Weather;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.ConsoleColor;

namespace FarGalaxy.Jobs.Manager.Jobs
{
    public class CreateModelJob : IJob
    {
        private readonly int _years;

        public CreateModelJob(int years)
        {
            _years = years;
        }

        public void Execute()
        {
            ForegroundColor = Yellow;
            WriteLine($"\n Creating database weather forecast for {_years / 365} day(s)...\n");
            using (ILifetimeScope scope = Program.Container.BeginLifetimeScope())
            {
                IWeatherConditionsService weatherConditions = scope.Resolve<IWeatherConditionsService>();
                INoSqlProvider provider = scope.Resolve<INoSqlProvider>();

                WeatherForecast forecast = weatherConditions.GetWeatherForecast(_years);
                List<DaysSummaryDto> summaryDto = forecast.Days.Select(Mapper.Map<DaysSummaryDto>).ToList();

                provider.Add("Forecast", summaryDto);
            }

            ForegroundColor = Green;
            WriteLine("Done. ");
            ResetColor();
        }
    }
}
