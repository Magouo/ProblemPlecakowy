using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemPlecakowy
{
    // Klasa przedmiot
    public class Przedmiot
    {
        public int Wartosc { get; set; }
        public int Waga { get; set; }

        public Przedmiot(int wartosc, int waga)
        {
            Wartosc = wartosc;
            Waga = waga;
        }

        public override string ToString()
        {
            return $"Wartosc: {Wartosc}, Waga: {Waga}";
        }
    }

    // Klasa problem
    public class Problem
    {
        public List<Przedmiot> Przedmioty { get;  set; }
        public int Pojemnosc { get;  set; }

        public Problem(int liczbaPrzedmiotow, int seed)
        {
            Random losowy = new Random(seed);
            Przedmioty = new List<Przedmiot>();

            for (int i = 0; i < liczbaPrzedmiotow; i++)
            {
                int wartosc = losowy.Next(1, 10);
                int waga = losowy.Next(1, 10);
                Przedmioty.Add(new Przedmiot(wartosc, waga));
            }
        }

        public Wynik Rozwiaz(int pojemnosc)
        {
            var posortowanePrzedmioty = Przedmioty.OrderByDescending(p => (double)p.Wartosc / p.Waga).ToList();

            List<Przedmiot> wybranePrzedmioty = new List<Przedmiot>();
            int sumaWartosci = 0;
            int sumaWagi = 0;

            foreach (var przedmiot in posortowanePrzedmioty)
            {
                if (sumaWagi + przedmiot.Waga <= pojemnosc)
                {
                    wybranePrzedmioty.Add(przedmiot);
                    sumaWartosci += przedmiot.Wartosc;
                    sumaWagi += przedmiot.Waga;
                }
            }

            return new Wynik(wybranePrzedmioty, sumaWartosci, sumaWagi);
        }

        public override string ToString()
        {
            return string.Join("\n", Przedmioty);
        }
    }

    // Klasa wynik rozwiązania problemu
    public class Wynik
    {
        public List<Przedmiot> WybranePrzedmioty { get;  set; }
        public int SumaWartosci { get;  set; }
        public int SumaWagi { get;  set; }

        public Wynik(List<Przedmiot> wybranePrzedmioty, int sumaWartosci, int sumaWagi)
        {
            WybranePrzedmioty = wybranePrzedmioty;
            SumaWartosci = sumaWartosci;
            SumaWagi = sumaWagi;
        }

        public override string ToString()
        {
            return $"Suma wartosci: {SumaWartosci}, Suma wagi: {SumaWagi}\nPrzedmioty:\n" + string.Join("\n", WybranePrzedmioty);
        }
    }

    // Klasa główna
    internal class Program
    {
        static void Main(string[] args)
        {
            int seed = 0;

            while (seed <= 0)
            {
                Console.Write("Podaj seed losowania: ");
                seed = int.Parse(Console.ReadLine());
            }

            Console.Write("Podaj liczbe przedmiotow: ");
            int liczbaPrzedmiotow = int.Parse(Console.ReadLine());

            Console.Write("Podaj pojemnosc plecaka: ");
            int pojemnosc = int.Parse(Console.ReadLine());

            Problem problem = new Problem(liczbaPrzedmiotow, seed);
            Console.WriteLine("\nWygenerowane przedmioty:");
            Console.WriteLine(problem);

            Wynik wynik = problem.Rozwiaz(pojemnosc);
            Console.WriteLine("\nRozwiazanie:");
            Console.WriteLine(wynik);
        }
    }
}
