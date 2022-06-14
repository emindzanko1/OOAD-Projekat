using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Ulaznice.com.Models
{
    public class SlobodnaMjesta
    {
        [Key]
        public int Id { get; set; }
        public int BrojSlobodnihMjesta { get; set; }
        public int BrojMjesta { get; set; }
        public string PrikazMjesta { get; set; }
        public SlobodnaMjesta() { }


    }
}
