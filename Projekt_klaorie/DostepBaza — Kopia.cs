using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace Projekt_klaorie
{
    internal class DostepBaza
    {
        #region Potrawy
        public static void UsunPotrawe(PotrawaClass potrawa)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var result = connection.Execute("DELETE FROM Potrawy WHERE ID_potrawy = @ID", new { ID = potrawa.ID_potrawy });
                Console.WriteLine($"Liczba usuniętych rekordów: {result}");
            }
        }

        public static PotrawaClass WybierzPotrawe(int id)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var potrawa = connection.QuerySingleOrDefault<PotrawaClass>("SELECT * FROM Potrawy WHERE ID_potrawy = @ID", new { ID = id });
                return potrawa;
            }
        }

        public static List<PotrawaClass> WczytajPotrawy()
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var output = connection.Query<PotrawaClass>("SELECT * FROM Potrawy");
                return output.ToList();
            }
        }

        public static void DodajPotrawe(PotrawaClass potrawa)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                connection.Execute("INSERT INTO Potrawy (Nazwa, Kalorie) VALUES (@Nazwa, @Kalorie)", potrawa);
            }
        }
        #endregion

        #region Osoby

        public static void DodajOsobe(OsobaClass osoba)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                connection.Execute("INSERT INTO Osoba (Imie, Nazwisko, Waga, Wzrost, Wiek, Plec, Cel) VALUES (@Imie, @Nazwisko, @waga, @wzrost, @wiek, @plec, @cel)", osoba);
            }
        }

        public static List<OsobaClass> WczytajOsoby()
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var output = connection.Query<OsobaClass>("SELECT * FROM Osoba");
                return output.ToList();
            }
        }

        public static void UsunOsobe(OsobaClass osoba)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var result = connection.Execute("DELETE FROM Osoba WHERE ID_osoby = @ID", new { ID = osoba.ID_osoby });
                Console.WriteLine($"Liczba usuniętych rekordów: {result}");
            }
        }
        #endregion

        #region Sporty

        public static void DodajSport(SportClass sport)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                connection.Execute("INSERT INTO Sporty (Nazwa, Kalorie) VALUES (@Nazwa, @Kalorie)", sport);
            }
        }

        public static SportClass WybierzSport(int idSportu)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                return connection.QuerySingleOrDefault<SportClass>("SELECT * FROM Sporty WHERE ID_sportu = @ID_sportu", new { ID_sportu = idSportu });
            }
        }

        public static List<SportClass> WczytajSporty()
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var output = connection.Query<SportClass>("SELECT * FROM Sporty");
                return output.ToList();
            }
        }

        public static void UsunSport(SportClass sport)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var result = connection.Execute("DELETE FROM Sporty WHERE ID_sportu = @ID", new { ID = sport.ID_sportu });
                Console.WriteLine($"Liczba usuniętych rekordów: {result}");
            }
        }


        #endregion

        #region Posilki
        public static List<PosilkiClass> WczytajPosilki(int idOsoby)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var output = connection.Query<PosilkiClass>("SELECT * FROM Posilki WHERE ID_osoby = @ID", new { ID = idOsoby });
                return output.ToList();
            }
        }
        public static void DodajPosilek(PosilkiClass posilek)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                connection.Execute("INSERT INTO Posilki (ID_osoby, ID_potrawy, Data) VALUES (@ID_osoby, @ID_potrawy, @Data)", posilek);
            }
        }
        public static void UsunPosilek(PosilkiClass posilek)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var result = connection.Execute("DELETE FROM Posilki WHERE ID_posilku = @ID", new { ID = posilek.ID_posilku });
                Console.WriteLine($"Liczba usuniętych rekordów: {result}");
            }
        }

        #endregion

        public static List<TreningiClass> WczytajTreningi(int idOsoby)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                return connection.Query<TreningiClass>("SELECT * FROM Treningi WHERE ID_osoby = @ID_osoby", new { ID_osoby = idOsoby }).ToList();
            }
        }

        public static void DodajTrening(TreningiClass trening)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                connection.Execute("INSERT INTO Treningi (ID_osoby, ID_sportu, Data) VALUES (@ID_osoby, @ID_sportu, @Data)", trening);
            }
        }

        public static void UsunTrening(TreningiClass trening)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                var result = connection.Execute("DELETE FROM Treningi WHERE ID_treningu = @ID", new { ID = trening.ID_treningu });
                Console.WriteLine($"Liczba usuniętych rekordów: {result}");
            }
        }

        public static List<T> WczytajDane<T>(string query)
        {
            using (IDbConnection connection = new SQLiteConnection("Data Source=kalorie.db"))
            {
                connection.Open();
                return connection.Query<T>(query).ToList();
            }
        }

    }
}

