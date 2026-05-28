from collections import Counter

def analiza_znakow(tekst):
    litery = []

    for znak in tekst:
        if znak.isalpha():
            litery.append(znak.lower())

    wynik = Counter(litery)

    return dict(wynik)


if __name__ == "__main__":
    tekst = input("Podaj tekst: ")
    wynik = analiza_znakow(tekst)
    print(wynik)