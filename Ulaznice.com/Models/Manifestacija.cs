using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ulaznice.com.Models;

namespace Ulaznice.com.Models
{
    public class Manifestacija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Karta")]
        public int KartaId { get; set; }

        [Required]
        public Karta Karta { get; set; }

        [Required]
        public string OpisKupnjeKarte { get; set; }

        [Required]
        [ForeignKey("NacinPlacanja")]
        public int NacinPlacanjaId { get; set; }

        [Required]
        public NacinPlacanja NacinPlacanja { get; set; }

        [Required]
        [ForeignKey("NagradnaIgra")]
        public int NagradnaIgraId { get; set; }

        [Required]
        public NagradnaIgra NagradnaIgra { get; set; }
        
        [Required]
        public string Legenda { get; set; }

        [Required]
        [ForeignKey("SlobodnaMjesta")]
        public int SlobodnaMjestaId { get; set; }

        [Required]
        public SlobodnaMjesta SlobodnaMjesta { get; set; }
        
        [Required]
        public DateTime VrijemeOdržavanja { get; set; }

        [ForeignKey("Lokacija")]
        public int LokacijaId { get; set; }
        public Lokacija Lokacija { get; set; }

        [Required]
        [EnumDataType(typeof(TipManifestacije))]
        public TipManifestacije Tip { get; set; }
        public Manifestacija() { }
    }
}
