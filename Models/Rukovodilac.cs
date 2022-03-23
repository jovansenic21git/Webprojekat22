using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Rukovodilac
    {
        [Key]
        public int ID_rk{get;set;}

        [Required]
        [MaxLength(30)]
        public string ime_rk{get; set;}

        [Required]
        [MaxLength(30)]
        public string prezime_rk{get; set;}

        [Required]
        [Range(21, 60)]
        public int godine_rk{get; set;}

        [JsonIgnore]
        public virtual List<Ansambl> ansambli{get; set;}
    }
}