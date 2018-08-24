using FarGalaxy.Contracts;
using Newtonsoft.Json;

namespace FarGalaxy.Dto
{
    public class DaysSummaryDto : BaseDto
    {
        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("weather")]
        public string Weather { get; set; }
    }
}
