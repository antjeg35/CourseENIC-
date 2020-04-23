using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TP1Module6EntityFrameworkBODojoPart2;
using TP1Module6EntityFrameworkBODojoPart2.Entities;

namespace TP1Module6EntityFrameworkBODojoPart2
{
    public class Samourai: Identifiant
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        [Display(Name ="Arts martiaux maitrisés")]
        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
        public int Potentiel { get; set; }
    }
}
