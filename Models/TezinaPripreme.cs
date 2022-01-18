using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("TezinaPripreme")]
    public class TezinaPripreme
    {
        [Key]
        public int ID { get; set; }  

        [MaxLength(50)]
        [Required]
        public string Tezina { get; set; }
        
        [JsonIgnore]
        public List<Recept> Recepti { get; set; }
    }
}