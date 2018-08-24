using FarGalaxy.Contracts.Weather;
using FarGalaxy.Entities.Weather;

namespace FarGalaxy.Entities.WeatherConditions.Rules
{
    public abstract class BaseRule<T> where T : IGravitationalSystem
    {
        protected BaseRule<T> Next;

        public BaseRule<T> SetNext(BaseRule<T> rule)
        {
            Next = rule;
            return this;
        }

        public abstract Day Request(T system);
    }
}
