using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models{
    public class Clanarina
    {
        [Key]
        public int ID{get; set;}
        
        [Required]
        public string naziv{get; set;}
        [JsonIgnore]
        public List<Spoj> clan_clanarina{get; set;}
    }
}