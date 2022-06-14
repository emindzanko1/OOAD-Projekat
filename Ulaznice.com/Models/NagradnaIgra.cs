using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ulaznice.com.Models
{
    public class NagradnaIgra
    {
        [Key]
        public int Id { get; set; }
        public Korisnik Osoba { get; set; }
        public string OpisNagradneIgre { get; set; }

        [ForeignKey("Nagrada")]
        public int NagradaId { get; set; }
        public Nagrada Nagrada { get; set; }
        public string InformacijeODobitniku { get; set;}

        [ForeignKey("PorukaDobitnik")]
        public int PorukaDobitnikId { get; set; }
        public PorukaDobitnik Poruka { get; set; }
        public NagradnaIgra() { }


    }
}
