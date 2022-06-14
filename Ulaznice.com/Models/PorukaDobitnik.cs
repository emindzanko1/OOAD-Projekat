using System.ComponentModel.DataAnnotations;

namespace Ulaznice.com.Models
{
    public class PorukaDobitnik
    {
        [Key]
        public int Id { get; set; }
        public string OdabirDobitnika { get; set; }
        public PorukaDobitnik() { }

    }
}
