using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Carre:Forme
    {
        public int Longueur { get; set; }

        public override double getAire()
        {
            return Longueur* Longueur;
        }

        public override double getPerimetre()
        {
            return Longueur * 4;
        }

        public override string ToString()
        {
            return $"Carre de coté A = {Longueur}" + Environment.NewLine + base.ToString();
        }
    }


}
