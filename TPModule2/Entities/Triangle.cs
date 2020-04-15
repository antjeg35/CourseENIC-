using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        private double P => (A + B + C) / 2d;
        public override double getAire()
        { return Math.Sqrt(P * (P - A) * (P - B) * (P - C)); }
        public override double getPerimetre()
        { return A + B + C; }
        public override string ToString()
        {
            return $"Triangle de coté A = {A}, B = {B}, C = {C}" + Environment.NewLine + base.ToString();
        }
    }



}
