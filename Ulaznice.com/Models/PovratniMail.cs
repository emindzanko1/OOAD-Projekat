using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Ulaznice.com.Models
{
    public class PovratniMail
    {
        [Key]
        public int Id { get; set; }
        public string Zahvalnica { get; set; }
        public string PrikazKarte { get; set; }
        public PovratniMail() { }
    }
}
