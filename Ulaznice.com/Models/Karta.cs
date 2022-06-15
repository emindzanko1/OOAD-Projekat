using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ulaznice.com.Models
{

    public class ValidateDate : ValidationAttribute
    {
        protected override ValidationResult IsValid
                         (object date, ValidationContext validationContext)
        {
            return ((DateTime)date <= DateTime.Now.AddDays(90) && (DateTime)date >= DateTime.Now)
                ? ValidationResult.Success
                : new ValidationResult("Možete kupiti kartu samo za manifestacije u narednih 90 dana!");
        }
    }
    public class Karta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Naziv mjesta događaja mora imati između 2 i 50 karaktera!")]
        public string MjestoDogađaja { get; set; }

        
        [DataType(DataType.Date)]
        [ValidateDate]
        public DateTime DatumDogađaja { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Naziv izvođača mora imati između 2 i 50 karaktera!")]
        public string IzvođačiDogađaja { get; set; }

        [Required]
        [Range(1F, 1000F, ErrorMessage = "Cijena mora biti u opsegu između 1 i 1000 KM")]
        public float CijenaKarte { get; set; }

        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 10, ErrorMessage = "Opis događaja mora sadržavati najmanje 20 slova, a najviše 1000!")]
        public string OpisDogađaja { get; set; }

        [Required]
        [ForeignKey("PovratniMail")]
        public int PovratniMailId { get; set; }
        public PovratniMail Mail { get; set; }
        public Karta () { }

    }
}
