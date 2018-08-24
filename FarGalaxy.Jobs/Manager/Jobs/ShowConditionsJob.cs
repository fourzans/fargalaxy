using Autofac;
using FarGalaxy.Dto;
using FarGalaxy.Jobs.Contracts;
using FarGalaxy.Services.WeatherConditions.Weather;
using static AutoMapper.Mapper;
using static FarGalaxy.Jobs.Program;
using static System.Console;
using static System.ConsoleColor;

namespace FarGalaxy.Jobs.Manager.Jobs
{
    public class ShowConditionsJob : IJob
    {
        private readonly int _years;

        public ShowConditionsJob(int years)
        {
            _years = years;
        }

        public void Execute()
        {
            ForegroundColor = Yellow;
            WriteLine("\n Retrieving conditions for year(s)...\n");
            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IWeatherConditionsService weatherConditions = scope.Resolve<IWeatherConditionsService>();
                WeatherForecastSummaryDto summaryDto =
                    Map<WeatherForecastSummaryDto>(
                        weatherConditions.GetWeatherForecastSummary(_years));

                WriteLine($"\t1) Drought days: [{summaryDto.DroughtDays}]");
                WriteLine($"\t2) Rainy days: [{summaryDto.RainDays}]");
                WriteLine($"\t\ta) Maximum day of instability: [{summaryDto.DayOfMaximumInstability}]");
                WriteLine($"\t\tb) Perimeter: [{summaryDto.Perimeter} Km]");
                WriteLine($"\t3) Periods of optimal pressure and temperature conditions: [{summaryDto.OptimalDays}]");
            }

            ResetColor();
        }
    }


}
