using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Clan
    {
        [Key]
        public int ClanID{get; set;}

        [Required]
        [MaxLength(30)]
        public string Ime_cl{get; set;}

        [Required]
        [MaxLength(30)]
        public string Prezime_cl{get; set;}

        [Required]
        [Range(7,80)]
        public int godine_cl{get; set;}

        [Required]
        public DateTime datumupisa{get; set;}
        public int dolasci{get; set;}

        [JsonIgnore]
        public Ansambl ansambl{get; set;}

        public List<Spoj> clan_clanarina{get; set;}
    }
}