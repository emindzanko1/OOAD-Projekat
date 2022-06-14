using System.ComponentModel.DataAnnotations;

namespace Ulaznice.com.Models
{
    public class NacinPlacanja
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Plaćanje { get; set; }
        public NacinPlacanja() { }

    }
}
