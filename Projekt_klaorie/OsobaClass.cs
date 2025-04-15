using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_klaorie
{
    internal abstract class Osoba
    {
        public int ID_osoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int wiek { get; set; }
        public string plec { get; set; }
        public float waga { get; set; }
        public int wzrost { get; set; }
        public abstract double ObliczBMI();
    }

    internal class OsobaClass : Osoba
    {
        public int cel { get; set; }
        public override double ObliczBMI()
        {
            return waga / (wzrost * wzrost);
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko} - {wiek} lat - {waga} kg {wzrost} cm";
        }
    }
}
