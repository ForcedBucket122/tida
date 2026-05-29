using System;
using System.Collections.Generic;
using System.Linq;
using INF04_Konsola_Uczniowie.Models;

namespace INF04_Konsola_Uczniowie.Services
{
    public class UczenService
    {
        private readonly List<Uczen> _uczniowie = new();

        public IEnumerable<Uczen> GetAll() => _uczniowie.AsReadOnly();

        public bool HasStudents() => _uczniowie.Count > 0;

        public Uczen Add(string imie, string nazwisko, string klasa)
        {
            var u = new Uczen
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Klasa = klasa
            };
            _uczniowie.Add(u);
            return u;
        }

        public bool AddGrade(int index, int grade, out string? error)
        {
            error = null;
            if (index < 0 || index >= _uczniowie.Count)
            {
                error = "Błędny numer ucznia.";
                return false;
            }

            if (grade < 1 || grade > 6)
            {
                error = "Ocena poza zakresem 1–6.";
                return false;
            }

            _uczniowie[index].Oceny.Add(grade);
            return true;
        }

        public Uczen? GetByIndex(int index)
        {
            if (index < 0 || index >= _uczniowie.Count) return null;
            return _uczniowie[index];
        }

        public Uczen? GetBestStudent()
        {
            return _uczniowie
                .Where(u => u.Oceny.Count > 0)
                .OrderByDescending(u => u.Srednia)
                .ThenBy(u => u.Nazwisko)
                .FirstOrDefault();
        }

        public IEnumerable<Uczen> GetTopNByAverage(int n)
        {
            return _uczniowie
                .OrderByDescending(u => u.Srednia)
                .Take(n);
        }

        public IEnumerable<Uczen> FilterByMinAverage(double minAverage)
        {
            return _uczniowie.Where(u => u.Srednia >= minAverage);
        }
    }
}
