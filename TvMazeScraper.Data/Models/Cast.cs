using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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


        public DateTime? Birthday { get; set; }

        [JsonProperty("birthday")]
        [NotMapped]
        public string BirthdayString { get; set; }

        [JsonIgnore]
        public int ShowId { get; set; }

        [JsonIgnore]
        public Show Show { get; set; }
    }
}
