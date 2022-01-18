using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Kategorija")]
    public class Kategorija
    {
        [Key]
        public int ID { get; set; }  

        [MaxLength(50)]
        [Required]
        public string Naziv { get; set; }
        [JsonIgnore]
        public List<Recept> Recepti { get; set; }
    }
}