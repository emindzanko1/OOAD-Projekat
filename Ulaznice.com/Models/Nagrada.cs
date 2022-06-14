using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Ulaznice.com.Models
{
    public class Nagrada
    {
        [Key]
        public int Id { get; set; }
        public string SlikaNagrade { get; set; }
        public Nagrada() { }

    }
}
