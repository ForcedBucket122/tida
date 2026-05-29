using System;
using System.Collections.Generic;
using System.Linq;

namespace INF04_Konsola_Uczniowie.Models
{
    public class Uczen
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Imie { get; set; } = string.Empty;
        public string Nazwisko { get; set; } = string.Empty;
        public string Klasa { get; set; } = string.Empty;

        // Lista ocen (1..6)
        public List<int> Oceny { get; } = new();

        public int LiczbaOcen => Oceny.Count;

        // Średnia zaokrąglona do 2 miejsc; 0 gdy brak ocen
        public double Srednia => Oceny.Count == 0 ? 0.0 : Math.Round(Oceny.Average(), 2);

        public override string ToString()
            => $"{Imie} {Nazwisko}, klasa: {Klasa}, ocen: {LiczbaOcen}, śr.: {Srednia}";
    }
}
