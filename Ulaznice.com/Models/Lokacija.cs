using System.ComponentModel.DataAnnotations;

namespace Ulaznice.com.Models
{
    public class Lokacija
    {
        [Key]
        public int Id { get; set; }
        public string MjestoDogađaja { get; set; }
        public string GeografskaŠirina { get; set; }
        public string GeografskaDužina { get; set; }    
        public string OpisMjesta { get; set; }
        public Lokacija() { }


    }
}
