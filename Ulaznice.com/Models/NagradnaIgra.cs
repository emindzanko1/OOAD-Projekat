using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ulaznice.com.Models
{
    public class NagradnaIgra
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public Korisnik Osoba { get; set; }

        [Required]
        public string OpisNagradneIgre { get; set; }

        [ForeignKey("Nagrada")]
        public int NagradaId { get; set; }

        [Required]
        public Nagrada Nagrada { get; set; }

        [Required]
        public string InformacijeODobitniku { get; set;}

        [ForeignKey("PorukaDobitnik")]
        public int PorukaDobitnikId { get; set; }

        [Required]
        public PorukaDobitnik Poruka { get; set; }
        public NagradnaIgra() { }
    }
}
