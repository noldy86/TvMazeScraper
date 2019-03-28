using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TvMazeScraper.Data.Models
{
    public class Show
    {
        [JsonIgnore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonProperty("id")]
        public int ShowId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cast> Casts  { get; set; }

        public Show()
        {
        }
    }
}
