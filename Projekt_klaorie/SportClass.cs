using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_klaorie
{
    internal class SportClass
    {
        public int ID_sportu { get; set; }
        public string Nazwa { get; set; }
        public int Kalorie { get; set; }


        public override string ToString()
        {
            return $"{Nazwa} - {Kalorie} kcal";
        }
    }
}
