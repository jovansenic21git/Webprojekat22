using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{ 
    public class Ansambl
    {
        [Key]
        public int ID_an{get; set;}

        [Required]
        [MaxLength(50)]
        public string naziv{get; set;}

        [Required]
        [Range(5,20)]
        public int probe{get; set;}

        [JsonIgnore]
        public virtual Kud kud{get; set;}
        [JsonIgnore]
        public virtual Rukovodilac rukovodilac{get; set;}
        [JsonIgnore]
        public virtual List<Clan> clanovi{get; set;}
        
    }
}