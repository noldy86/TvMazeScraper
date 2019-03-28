using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvMazeScraper.Data.Models
{
    public class Cast
    {
        [JsonIgnore][Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonProperty("id")]
        public int CastId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonIgnore]
        public int ShowId { get; set; }

        [JsonIgnore]
        public Show Show { get; set; }
    }
}
