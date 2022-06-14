using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Ulaznice.com.Models
{
    public class SlobodnaMjesta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BrojSlobodnihMjesta { get; set; }

        [Required]
        public int BrojMjesta { get; set; }

        [Required]
        public string PrikazMjesta { get; set; }
        public SlobodnaMjesta() { }


    }
}
