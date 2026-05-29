using System;
using INF04_Konsola_Uczniowie.Models;
using INF04_Konsola_Uczniowie.Services;

var service = new UczenService();
bool running = true;

while (running)
{
    Console.WriteLine("\n=== DZIENNIK UCZNIA ===");
    Console.WriteLine("1. Dodaj ucznia");
    Console.WriteLine("2. Dodaj ocenę uczniowi");
    Console.WriteLine("3. Wyświetl wszystkich uczniów");
    Console.WriteLine("4. Wyświetl średnią ucznia");
    Console.WriteLine("5. Wyświetl najlepszego ucznia");
    Console.WriteLine("0. Zakończ program");
    Console.Write("Wybierz opcję: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            DodajUcznia();
            break;
        case "2":
            DodajOcene();
            break;
        case "3":
            WyswietlWszystkichUczniow();
            break;
        case "4":
            WyswietlSredniaUcznia();
            break;
        case "5":
            WyswietlNajlepszego();
            break;
        case "0":
            running = false;
            Console.WriteLine("Do widzenia!");
            break;
        default:
            Console.WriteLine("Błędny numer opcji.");
            break;
    }
}

void DodajUcznia()
{
    Console.Write("Podaj imię: ");
    string? imie = Console.ReadLine();
    Console.Write("Podaj nazwisko: ");
    string? nazwisko = Console.ReadLine();
    Console.Write("Podaj klasę: ");
    string? klasa = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) || string.IsNullOrWhiteSpace(klasa))
    {
        Console.WriteLine("Błąd: Wszystkie pola są wymagane.");
        return;
    }

    var uczen = service.Add(imie, nazwisko, klasa);
    Console.WriteLine($"Dodano ucznia: {uczen}");
}

void DodajOcene()
{
    if (!service.HasStudents())
    {
        Console.WriteLine("Błąd: Brak uczniów w bazie.");
        return;
    }

    WyswietlWszystkichUczniowZIndeksami();

    Console.Write("Wybierz numer ucznia: ");
    if (!int.TryParse(Console.ReadLine(), out int index))
    {
        Console.WriteLine("Błąd: Błędny numer ucznia.");
        return;
    }

    Console.Write("Podaj ocenę (1-6): ");
    if (!int.TryParse(Console.ReadLine(), out int grade))
    {
        Console.WriteLine("Błąd: Błędny format oceny.");
        return;
    }

    if (service.AddGrade(index, grade, out string? error))
    {
        Console.WriteLine("Ocena dodana pomyślnie.");
    }
    else
    {
        Console.WriteLine($"Błąd: {error}");
    }
}

void WyswietlWszystkichUczniow()
{
    if (!service.HasStudents())
    {
        Console.WriteLine("Brak uczniów w bazie.");
        return;
    }

    Console.WriteLine("\n=== WSZYSCY UCZNIOWIE ===");
    int index = 0;
    foreach (var u in service.GetAll())
    {
        Console.WriteLine($"{index}: {u}");
        index++;
    }
}

void WyswietlWszystkichUczniowZIndeksami()
{
    Console.WriteLine("\n=== LISTA UCZNIÓW ===");
    int index = 0;
    foreach (var u in service.GetAll())
    {
        Console.WriteLine($"{index}: {u}");
        index++;
    }
}

void WyswietlSredniaUcznia()
{
    if (!service.HasStudents())
    {
        Console.WriteLine("Błąd: Brak uczniów w bazie.");
        return;
    }

    WyswietlWszystkichUczniowZIndeksami();

    Console.Write("Wybierz numer ucznia: ");
    if (!int.TryParse(Console.ReadLine(), out int index))
    {
        Console.WriteLine("Błąd: Błędny numer ucznia.");
        return;
    }

    var uczen = service.GetByIndex(index);
    if (uczen is null)
    {
        Console.WriteLine("Błąd: Błędny numer ucznia.");
        return;
    }

    if (uczen.LiczbaOcen == 0)
    {
        Console.WriteLine($"{uczen.Imie} {uczen.Nazwisko} nie ma przypisanych ocen.");
    }
    else
    {
        Console.WriteLine($"Średnia {uczen.Imie} {uczen.Nazwisko}: {uczen.Srednia}");
    }
}

void WyswietlNajlepszego()
{
    if (!service.HasStudents())
    {
        Console.WriteLine("Błąd: Brak uczniów w bazie.");
        return;
    }

    var best = service.GetBestStudent();
    if (best is null)
    {
        Console.WriteLine("Brak uczniów z ocenami.");
    }
    else
    {
        Console.WriteLine($"\n=== NAJLEPSZY UCZEŃ ===");
        Console.WriteLine(best);
    }
}
