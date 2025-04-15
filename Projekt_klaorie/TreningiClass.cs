using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_klaorie
{
    internal class TreningiClass
    {

        public int ID_treningu { get; set; }
        public int ID_osoby { get; set; }
        public int ID_sportu { get; set; }
        public DateTime Data { get; set; }
        internal class TreningiDisplay
        {
            public TreningiClass Trening { get; set; }
            public string Opis { get; set; }

            public override string ToString()
            {
                return Opis;
            }
        }

    }
}
