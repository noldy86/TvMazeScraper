using System;
using Newtonsoft.Json;

namespace TvMazeScraper.Models
{
    public class CastResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public string BirthDayDate {
            get
            {
                if (BirthDay.HasValue)
                {
                    return BirthDay.Value.ToString("yyyy-MM-dd");
                }

                return "";
            } }

        [JsonIgnore]
        public DateTime? BirthDay { get; set; }
    }
}
