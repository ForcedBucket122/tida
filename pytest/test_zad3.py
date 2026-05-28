from zad3 import czy_poprawny_pesel


def test_poprawny():
    assert czy_poprawny_pesel("44051401458") == True


def test_zla_dlugosc():
    assert czy_poprawny_pesel("12345") == False


def test_litery():
    assert czy_poprawny_pesel("4405140145A") == False


def test_bledna_kontrolna():
    assert czy_poprawny_pesel("44051401459") == False