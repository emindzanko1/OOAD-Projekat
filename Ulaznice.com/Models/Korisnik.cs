using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ulaznice.com.Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[0-9| |a-z|A-Z]*", ErrorMessage = "Dozvoljeno je samo korištenje velikih i malih slova, brojeva i razmaka!")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"[0-9| |a-z|A-Z]*", ErrorMessage = "Dozvoljeno je samo korištenje velikih i malih slova, brojeva i razmaka!")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string BrojBankovnogRačuna { get; set; }

        [Required]
        public int KartaId { get; set; }

        [ForeignKey("KartaId")]
        public virtual Karta Karta { get; set; }

        [Required]
        public int NagradnaIgraId { get; set; }

        [ForeignKey("NagradnaIgraId")]
        public virtual NagradnaIgra Nagradna { get; set; }

        [Required]
        public int PorukaId { get; set; }

        [ForeignKey("PorukaDobitnikId")]
        public virtual PorukaDobitnik Poruka { get; set; } 
        public Korisnik() { }

    }
}
