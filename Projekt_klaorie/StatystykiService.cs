using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace Projekt_klaorie
{
    public class StatystykiService : IStatystyki
    {
        public List<StatystykiData> PobierzStatystykiWykres(int idOsoby, DateTime dataOd, DateTime dataDo)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();

                var posilki = connection.Query<StatystykiData>(
                    "SELECT Posilki.Data, SUM(Potrawy.Kalorie) AS Kalorie, Posilki.ID_potrawy FROM Posilki " +
                    "JOIN Potrawy ON Posilki.ID_potrawy = Potrawy.ID_potrawy " +
                    "WHERE Posilki.ID_osoby = @ID_osoby AND Posilki.Data BETWEEN @DataOd AND @DataDo " +
                    "GROUP BY Posilki.Data",
                    new { ID_osoby = idOsoby, DataOd = dataOd, DataDo = dataDo }).ToList();

                var treningi = connection.Query<StatystykiData>(
                    "SELECT Treningi.Data, SUM(Sporty.Kalorie) AS Kalorie, Treningi.ID_sportu FROM Treningi " +
                    "JOIN Sporty ON Treningi.ID_sportu = Sporty.ID_sportu " +
                    "WHERE Treningi.ID_osoby = @ID_osoby AND Treningi.Data BETWEEN @DataOd AND @DataDo " +
                    "GROUP BY Treningi.Data",
                    new { ID_osoby = idOsoby, DataOd = dataOd, DataDo = dataDo }).ToList();

                return new List<StatystykiData> { new StatystykiData { Posilki = posilki, Treningi = treningi } };
            }
        }

        public List<StatystykiData> PobierzStatystykiTabela(int idOsoby, DateTime dataOd, DateTime dataDo)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();

                var posilki = connection.Query<StatystykiData>(
                    "SELECT Posilki.Data, SUM(Potrawy.Kalorie) AS Kalorie, Posilki.ID_potrawy FROM Posilki " +
                    "JOIN Potrawy ON Posilki.ID_potrawy = Potrawy.ID_potrawy " +
                    "WHERE Posilki.ID_osoby = @ID_osoby AND Posilki.Data BETWEEN @DataOd AND @DataDo " +
                    "GROUP BY Posilki.ID_posilku " +
                    "ORDER BY Posilki.Data",
                    new { ID_osoby = idOsoby, DataOd = dataOd, DataDo = dataDo }).ToList();

                var treningi = connection.Query<StatystykiData>(
                    "SELECT Treningi.Data, SUM(Sporty.Kalorie) AS Kalorie, Treningi.ID_sportu FROM Treningi " +
                    "JOIN Sporty ON Treningi.ID_sportu = Sporty.ID_sportu " +
                    "WHERE Treningi.ID_osoby = @ID_osoby AND Treningi.Data BETWEEN @DataOd AND @DataDo " +
                    "GROUP BY Treningi.ID_treningu " +
                    "ORDER BY Treningi.Data",
                    new { ID_osoby = idOsoby, DataOd = dataOd, DataDo = dataDo }).ToList();

                return new List<StatystykiData> { new StatystykiData { Posilki = posilki, Treningi = treningi } };
            }
        }
    }
}