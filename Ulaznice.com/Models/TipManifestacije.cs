using System.ComponentModel.DataAnnotations;

namespace Ulaznice.com.Models
{
    public enum TipManifestacije
    {
        [Display(Name = "Sportska manifestacija")]
        Sportska,
        [Display(Name = "Kino predstava")]
        KinoPredstava,
        [Display(Name = "Pozorišna predstava")]
        PozorišnaPredstava,
        [Display(Name = "Sajam")]
        Sajam,
        [Display(Name = "Izložba")]
        Izložba,
        [Display(Name = "Koncert")]
        Koncert
    }
}
