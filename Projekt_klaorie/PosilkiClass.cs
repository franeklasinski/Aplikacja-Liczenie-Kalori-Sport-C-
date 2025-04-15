using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_klaorie
{
    internal class PosilkiClass
    {
        public int ID_posilku { get; set; }
        public int ID_osoby { get; set; }
        public int ID_potrawy { get; set; }
        public DateTime Data { get; set; }
        internal class PosilekDisplay
        {
            public PosilkiClass Posilek { get; set; }
            public string Opis { get; set; }

            public override string ToString()
            {
                return Opis;
            }
        }
    }
}
