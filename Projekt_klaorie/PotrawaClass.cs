using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_klaorie
{
    internal class PotrawaClass
    {
        private int id_potrawy;
        private string nazwa;
        private int kalorie;
        public int ID_potrawy
        {
            get { return id_potrawy; }
            set { id_potrawy = value; }
        }
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }
        public int Kalorie
        {
            get { return kalorie; }
            set { kalorie = value; }
        }
        public override string ToString()
        {
            return $"{Nazwa} - {Kalorie} kcal";
        }
    }
}
