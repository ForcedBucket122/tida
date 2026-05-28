from zad2 import szyfr_cezara


def test_male_litery():
    assert szyfr_cezara("abc", 1) == "bcd"


def test_duze_litery():
    assert szyfr_cezara("XYZ", 2) == "ZAB"


def test_mieszany_tekst():
    assert szyfr_cezara("Ala ma kota!", 3) == "Dod pd nrwd!"


def test_brzegowy_pusty():
    assert szyfr_cezara("", 5) == ""


def test_brzegowy_zero():
    assert szyfr_cezara("Test 123!", 0) == "Test 123!"