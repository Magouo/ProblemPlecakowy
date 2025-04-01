using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemPlecakowy;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class TestyProblemPlecakowy
    {
        [TestMethod]
        public void Test_GdyBrakPrzedmiotow_ZwroconyPustyWynik() 
        {
            Problem problem = new Problem(0, 123);
            int pojemnosc = 10;

            Wynik wynik = problem.Rozwiaz(pojemnosc);

            Assert.AreEqual(0, wynik.WybranePrzedmioty.Count, "Plecak powinien być pusty.");
            Assert.AreEqual(0, wynik.SumaWartosci, "Suma wartości powinna wynosić 0.");
            Assert.AreEqual(0, wynik.SumaWagi, "Suma wag powinna wynosić 0.");
        } 

        [TestMethod]
        public void Test_GdyZadenPrzedmiotNieMiesciSie_WynikJestPusty() 
        {
            Problem problem = new Problem(3, 99);
            problem.Przedmioty = new List<Przedmiot>
            {
                new Przedmiot(5, 20),
                new Przedmiot(8, 25),
                new Przedmiot(10, 30)
            };
            int pojemnosc = 10;

            Wynik wynik = problem.Rozwiaz(pojemnosc);

            Assert.AreEqual(0, wynik.WybranePrzedmioty.Count, "Żaden przedmiot nie powinien zostać wybrany.");
            Assert.AreEqual(0, wynik.SumaWartosci, "Suma wartości powinna wynosić 0.");
            Assert.AreEqual(0, wynik.SumaWagi, "Suma wag powinna wynosić 0.");
        }

        [TestMethod]
        public void Test_GdyPrzynajmniejJedenPrzedmiotMiesciSie_ZwroconyJestCoNajmniejJeden()
        {
            Problem problem = new Problem(3, 50);
            problem.Przedmioty = new List<Przedmiot>
            {
                new Przedmiot(10, 2),
                new Przedmiot(5, 8),
                new Przedmiot(7, 3)
            };
            int pojemnosc = 5;

            Wynik wynik = problem.Rozwiaz(pojemnosc);

            Assert.IsTrue(wynik.WybranePrzedmioty.Count > 0, "Przynajmniej jeden przedmiot powinien zostać wybrany.");
        }

        [TestMethod]
        public void Test_PoprawneRozwiazanieDlaZnanejInstancji() 
        {
            Problem problem = new Problem(5, 5);
            int pojemnosc = 5;
            Wynik wynik = problem.Rozwiaz(pojemnosc);

            Assert.AreEqual(10, wynik.SumaWartosci, "Oczekiwana wartość to 10.");
            Assert.AreEqual(5, wynik.SumaWagi, "Oczekiwana waga to 2.");

            Assert.AreEqual(2, wynik.WybranePrzedmioty.Count, "Oczekiwana liczba przedmiotów to 2.");
            Assert.IsTrue(wynik.WybranePrzedmioty.Any(p => p.Wartosc == 6 && p.Waga == 2));
            Assert.AreEqual(6, wynik.WybranePrzedmioty[0].Wartosc, "Oczekiwana wartość to 6.");
            Assert.AreEqual(2, wynik.WybranePrzedmioty[0].Waga, "Oczekiwana waga to 2.");
            Assert.IsTrue(wynik.WybranePrzedmioty.Any(p => p.Wartosc == 4 && p.Waga == 3));
            Assert.AreEqual(4, wynik.WybranePrzedmioty[1].Wartosc, "Oczekiwana wartość to 4."); 
            Assert.AreEqual(3, wynik.WybranePrzedmioty[1].Waga, "Oczekiwana waga to 3.");
        }

        [TestMethod]
        public void Test_WybieraNajbardziejOplacalnePrzedmioty()
        {
            Problem problem = new Problem(4, 77);
            problem.Przedmioty = new List<Przedmiot>
            {
                new Przedmiot(10, 2), // Współczynnik 5.0
                new Przedmiot(7, 3),  // Współczynnik 2.33
                new Przedmiot(5, 4),  // Współczynnik 1.25
                new Przedmiot(6, 2)   // Współczynnik 3.0
            };
            int pojemnosc = 4;

            Wynik wynik = problem.Rozwiaz(pojemnosc);

            Assert.AreEqual(16, wynik.SumaWartosci, "Oczekiwana wartość to 16 (najbardziej opłacalne przedmioty).");
        }
    }
}
