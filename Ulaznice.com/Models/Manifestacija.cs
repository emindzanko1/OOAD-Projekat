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

        [ForeignKey("Karta")]
        public int KartaId { get; set; }
        public Karta Karta { get; set; }
        public string OpisKupnjeKarte { get; set; }

        [ForeignKey("NacinPlacanja")]
        public int NacinPlacanjaId { get; set; }
        public NacinPlacanja NacinPlacanja { get; set; }

        [ForeignKey("NagradnaIgra")]
        public int NagradnaIgraId { get; set; }
        public NagradnaIgra NagradnaIgra { get; set; }  
        public string Legenda { get; set; }

        [ForeignKey("SlobodnaMjesta")]
        public int SlobodnaMjestaId { get; set; }
        public SlobodnaMjesta SlobodnaMjesta { get; set; }
        public DateTime VrijemeOdržavanja { get; set; }

        [ForeignKey("Lokacija")]
        public int LokacijaId { get; set; }
        public Lokacija Lokacija { get; set; }

        [EnumDataType(typeof(TipManifestacije))]
        public TipManifestacije Tip { get; set; }
        public Manifestacija() { }
    }
}
