using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Kud
    {
        [Key]
        public int ID{ get; set;}
        
        [Required]
        [MaxLength(100)]
        public string naziv_kud {get; set;}

        [Required]
        [MaxLength(150)]
        public string Adresa{ get; set;}

        [Required]
        [MaxLength(150)]
        public string mesto{get; set;}

        
        [JsonIgnore]
        public virtual List<Ansambl> anasambli{get; set;}
    }
}