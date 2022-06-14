using System.ComponentModel.DataAnnotations;

namespace Ulaznice.com.Models
{
    public class Lokacija
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MjestoDogađaja { get; set; }

        [Required]
        public string GeografskaŠirina { get; set; }

        [Required]
        public string GeografskaDužina { get; set; }

        [Required]
        public string OpisMjesta { get; set; }
        public Lokacija() { }


    }
}
