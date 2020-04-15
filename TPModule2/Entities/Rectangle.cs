using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Rectangle:Forme
    {
        public int Largeur { get; set; }
        public int Longueur { get; set; }

        public override double getAire()
        {
            return Largeur * Longueur;
        }

        public override double getPerimetre()
        {
            return Largeur * 2 + Longueur * 2;
        }

        public override string ToString()
        {
            return $"Rectangle de longueur = {Longueur} et largueur = {Largeur}" + Environment.NewLine + base.ToString();
        }
    }
}
