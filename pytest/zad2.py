def szyfr_cezara(tekst, przesuniecie):
    wynik = ""

    for znak in tekst:
        if 'a' <= znak <= 'z':
            wynik += chr((ord(znak) - ord('a') + przesuniecie) % 26 + ord('a'))
        elif 'A' <= znak <= 'Z':
            wynik += chr((ord(znak) - ord('A') + przesuniecie) % 26 + ord('A'))
        else:
            wynik += znak

    return wynik


if __name__ == "__main__":
    tekst = input("Podaj tekst: ")
    przesuniecie = int(input("Podaj przesunięcie: "))
    print(szyfr_cezara(tekst, przesuniecie))