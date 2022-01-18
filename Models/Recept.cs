using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Recept")]
    public class Recept
    {
        [Key]
        public int ID { get; set; }  

        [MaxLength(100)]
        [Required]
        public string Naziv { get; set; }

        [MaxLength(1000)]
        public string Opis { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Sastojci { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Instrukcija { get; set; }

        [MaxLength(500)]
        [Required]
        public string VremePripreme { get; set; }

        [MaxLength(255)]
        [Required]
        public string slika { get; set; }

        public TezinaPripreme TezinaPripreme { get; set; }
        public Kategorija Kategorija { get; set; }
        public Tip Tip { get; set; }
    }
}