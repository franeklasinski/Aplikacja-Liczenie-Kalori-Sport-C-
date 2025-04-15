using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_klaorie
{
    public class StatystykiData
    {
        public DateTime Data { get; set; }
        public int Kalorie { get; set; }
        public int ID_osoby { get; set; }
        public int ID_potrawy { get; set; }
        public int ID_sportu { get; set; }
        public List<StatystykiData> Posilki { get; set; }
        public List<StatystykiData> Treningi { get; set; }
    }
    public interface IStatystyki
    {
        List<StatystykiData> PobierzStatystykiWykres(int idOsoby, DateTime dataOd, DateTime dataDo);

    }



}
