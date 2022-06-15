using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ulaznice.com.Models
{
    public class KorisnikNagradnaIgra
    {
		[Key]
		public int Id { get; set; }

		[Required]
		public int KorisnikId { get; set; }
		[ForeignKey("KorisnikId")]
		public virtual Korisnik korisnik { get; set; }

		[Required]
		public int NagradnaIgraId { get; set; }
		[ForeignKey("NagradnaIgraId")]
		public virtual NagradnaIgra nagradnaIgra { get; set; }
		public KorisnikNagradnaIgra() { }
	}
}
