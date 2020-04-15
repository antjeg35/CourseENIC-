using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Cercle:Forme
    {
        public int Rayon { get; set; }


        public override double getAire()
        {
            return Math.PI* Rayon *Rayon;
        }

        public override double getPerimetre()
        {
            return 2 * Math.PI * Rayon;
        }

        public override string ToString()
        {
            return $"Cercle de rayon {Rayon}" + Environment.NewLine + base.ToString();
        }
    }
}
