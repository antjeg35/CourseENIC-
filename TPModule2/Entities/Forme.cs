using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public abstract class Forme
    {
        public int Aire { get; set;}
        public int Perimetre { get; set; }


        public abstract double getAire();
        public abstract double getPerimetre();

        public override string ToString()
        {
            return $"Aire = {getAire()}" + Environment.NewLine + $"Périmetre =  {getPerimetre()}" + Environment.NewLine;
        }
    }
}
