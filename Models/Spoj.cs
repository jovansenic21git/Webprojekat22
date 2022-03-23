using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Spoj{
        [Key]
        public int ID{get; set;}

        [Required]
        public bool uplata{get; set;}
        [JsonIgnore]
        public Clan clan{get; set;}
        [JsonIgnore]
        public Clanarina clanarina{get; set;}

    }
}