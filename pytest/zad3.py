def czy_poprawny_pesel(pesel):
    if len(pesel) != 11:
        return False

    if not pesel.isdigit():
        return False

    wagi = [1, 3, 7, 9, 1, 3, 7, 9, 1, 3]
    suma = 0

    for i in range(10):
        suma += int(pesel[i]) * wagi[i]

    cyfra_kontrolna = (10 - (suma % 10)) % 10

    return cyfra_kontrolna == int(pesel[10])


if __name__ == "__main__":
    pesel = input("Podaj PESEL: ")
    if czy_poprawny_pesel(pesel):
        print("PESEL poprawny")
    else:
        print("PESEL niepoprawny")