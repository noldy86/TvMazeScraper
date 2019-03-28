using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TvMazeScraper.Data.Models;

namespace TvMazeScraper.Models
{
    public class ShowResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cast")]
        public List<CastResponse> Cast { get; set; }

        public ShowResponse(Show show)
        {
            this.Id = show.Id;
            this.Name = show.Name;
            this.Cast = show.Casts.Select(s=>new CastResponse()
            {
                Id = s.Id,
                Name = s.Name,
                BirthDay = s.Birthday
            }).ToList();
        }
    }
}
