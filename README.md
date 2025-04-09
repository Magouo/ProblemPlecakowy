# Konsolowa oraz okienkowa aplikacja rozwiązująca problem plecakowy  

---

## Wstęp  

Projekt został stworzony na platformie **.NET** (wersja 8.0) i implementuje rozwiązanie klasycznego **problemu plecakowego** (ang. *Knapsack Problem*), który jest jednym z problemów optymalizacyjnych. W ramach projektu przygotowano:  
- **Aplikację konsolową** do interaktywnego rozwiązywania problemu.  
- **Aplikację okienkową** (GUI) z graficznym interfejsem użytkownika.  
- **Testy jednostkowe** weryfikujące poprawność działania algorytmu.  

---

## Opis problemu  

**Problem plecakowy** polega na wyborze przedmiotów o największej wartości, które można zmieścić w plecaku o ograniczonej pojemności. Każdy przedmiot ma określoną wagę i wartość. Celem jest maksymalizacja wartości przedmiotów w plecaku, przy jednoczesnym zachowaniu ograniczenia wagowego.  

---

## Pliki programu oraz ich przeznaczenie  

### Aplikacja konsolowa  

#### **Program.cs**  
Zawiera cały kod aplikacji konsolowej.  
W pliku znajdują się:  

- **Klasa `Przedmiot`**:  
  - Reprezentuje pojedynczy przedmiot.  
  - Zawiera właściwości:  
    - `Wartosc` - wartość przedmiotu.  
    - `Waga` - waga przedmiotu.  
  - Metoda `ToString()` umożliwia czytelne wyświetlenie informacji o przedmiocie.  

- **Klasa `Wynik`**:  
  - Reprezentuje rozwiązanie problemu.  
  - Zawiera właściwości:  
    - `WybranePrzedmioty` - lista przedmiotów wybranych do plecaka.  
    - `SumaWartosci` - łączna wartość wybranych przedmiotów.  
    - `SumaWagi` - łączna waga wybranych przedmiotów.  
  - Metoda `ToString()` umożliwia czytelne wyświetlenie wyników.  

- **Klasa `Problem`**:  
  - Reprezentuje instancję problemu plecakowego.  
  - Zawiera:  
    - Listę przedmiotów generowanych losowo na podstawie podanego ziarna (*seed*).  
    - Metodę `Rozwiaz(int pojemnosc)`, która implementuje algorytm zachłanny rozwiązujący problem.  
  - Algorytm sortuje przedmioty według współczynnika opłacalności (wartość/waga) i wybiera je, dopóki pojemność plecaka na to pozwala.  

- **Kod główny**:  
  - Umożliwia użytkownikowi:  
    - Podanie liczby przedmiotów, pojemności plecaka oraz ziarna dla generatora losowego.  
    - Wyświetlenie wygenerowanych przedmiotów.  
    - Rozwiązanie problemu i wyświetlenie wyników.  

---

### Testy jednostkowe  

#### **TestyProblemPlecakowy.cs**  
Plik zawierający testy jednostkowe weryfikujące poprawność działania algorytmu.  
Testy obejmują następujące scenariusze:  

- **Test_GdyBrakPrzedmiotow_ZwroconyPustyWynik**  
  - Sprawdza, czy w przypadku braku przedmiotów zwracany jest pusty wynik.  

- **Test_GdyZadenPrzedmiotNieMiesciSie_WynikJestPusty**  
  - Weryfikuje, czy w przypadku, gdy żaden przedmiot nie mieści się w plecaku, zwracany jest pusty wynik.  

- **Test_GdyPrzynajmniejJedenPrzedmiotMiesciSie_ZwroconyJestCoNajmniejJeden**  
  - Sprawdza, czy w przypadku, gdy przynajmniej jeden przedmiot mieści się w plecaku, zwracany jest wynik z co najmniej jednym przedmiotem.  

- **Test_PoprawneRozwiazanieDlaZnanejInstancji**  
  - Weryfikuje poprawność rozwiązania dla konkretnej instancji problemu.  

- **Test_WybieraNajbardziejOplacalnePrzedmioty**  
  - Sprawdza, czy algorytm wybiera przedmioty o najwyższym współczynniku opłacalności.  

---

### Aplikacja okienkowa  

#### **Form1.cs**  
Plik zawierający logikę graficznego interfejsu użytkownika (GUI).  
Umożliwia użytkownikowi:  
- Wprowadzenie danych (ziarno, liczba przedmiotów, pojemność plecaka).  
- Rozwiązanie problemu po kliknięciu przycisku.  
- Wyświetlenie wygenerowanych przedmiotów oraz wyników w polach tekstowych.  
- Zawiera walidację danych wejściowych (np. sprawdzenie, czy wartości są większe od zera).  

---

## Działanie programu  

### Aplikacja konsolowa  

1. Użytkownik uruchamia aplikację i podaje:  
   - Ziarno dla generatora losowego.  
   - Liczbę przedmiotów.  
   - Pojemność plecaka.  
2. Program generuje losowe przedmioty i wyświetla je w konsoli.  
3. Algorytm zachłanny rozwiązuje problem, wybierając przedmioty o najwyższym współczynniku opłacalności.  
4. Wynik (lista wybranych przedmiotów, ich łączna wartość i waga) zostaje wyświetlony w konsoli.  

### Aplikacja okienkowa  

1. Użytkownik uruchamia aplikację i wprowadza dane w polach tekstowych:  
   - Ziarno dla generatora losowego.  
   - Liczba przedmiotów.  
   - Pojemność plecaka.  
2. Po kliknięciu przycisku "Rozwiąż", program generuje losowe przedmioty i rozwiązuje problem.  
3. Wynik (lista wybranych przedmiotów, ich łączna wartość i waga) oraz wygenerowane przedmioty zostają wyświetlone w interfejsie graficznym.  

---

## Wykorzystane technologie  

- **.NET (wersja 6.0)**  
- **C#**  
- **MSTest** (do testów jednostkowych)  
- **Windows Forms** (do aplikacji okienkowej)  
