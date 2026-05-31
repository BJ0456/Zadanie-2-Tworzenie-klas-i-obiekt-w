import os
import time
import random

class Car:
    def __init__(self, def_nazwa):
        self.Nazwa = def_nazwa
        self.Dystans = 0

class Track:
    def __init__(self, def_nazwa, def_dlugosc):
        self.Nazwa = def_nazwa
        self.Dlugosc = def_dlugosc

class Race:
    def __init__(self, def_tor, def_auto1, def_auto2):
        self.Tor = def_tor
        self.Auto1 = def_auto1
        self.Auto2 = def_auto2
        self.Stoper = LapTimer()

class LapTimer:
    def __init__(self):
        self.Czas = 0

# START Sekcja wyboru 2 aut do wyścigu 
os.system('cls' if os.name == 'nt' else 'clear')
listaaut = ["Ferrari F40", "Mclaren F1", "Mazda 787B", "Lamborghini Diablo SV", "Porsche 911"]
print("Dostepne auta:")

for i in range(len(listaaut)):
    print(str(i + 1) + " - " + listaaut[i])
    
print()
numer1 = int(input("Wybierz pierwsze auto (1-5): "))
nazwawybor1 = listaaut[numer1 - 1]
auto1 = Car(nazwawybor1)
listaaut.pop(numer1 - 1)
os.system('cls' if os.name == 'nt' else 'clear')

print("Wybrane auto nr1: " + auto1.Nazwa)
print()
print("Dostepne auta:")
for i in range(len(listaaut)):
    print(str(i + 1) + " - " + listaaut[i])
    
print()
numer2 = int(input("Wybierz drugie auto (1-4): "))
nazwawybor2 = listaaut[numer2 - 1]
auto2 = Car(nazwawybor2)
listaaut.pop(numer2 - 1)
os.system('cls' if os.name == 'nt' else 'clear')
# END Sekcja wyboru 2 aut do wyścigu

# START Sekcja wyboru toru
os.system('cls' if os.name == 'nt' else 'clear')
print("Wybrane auta: " + auto1.Nazwa + " oraz " + auto2.Nazwa)
print()
print("Dostępne Tory")
print("1. Nordschleife (20832m)")
print("2. Spa-Francorchamps (7004m)")
print("3. Monza (5793m)")
print()

numertoru = int(input("Wybierz tor (1-3): "))
wybranytor = None

if numertoru == 1:
    wybranytor = Track("Nordschleife", 20832)
elif numertoru == 2:
    wybranytor = Track("Spa-Francorchamps", 7004)
elif numertoru == 3:
    wybranytor = Track("Monza", 5793)
else:
    wybranytor = Track("Nordschleife", 20832)
# END Sekcja wyboru toru

# START Sekcja wyboru liczby okrazen
os.system('cls' if os.name == 'nt' else 'clear')
print()
liczbaokrazen = int(input("Podaj liczbe okrazen (1-...): "))
# END Sekcja wyboru liczby okrazen

# START Sekcja podsumowanie przed wyscigiem   
glownywyscig = Race(wybranytor, auto1, auto2)
os.system('cls' if os.name == 'nt' else 'clear')
print("Wybrany tor: " + wybranytor.Nazwa + " " + str(wybranytor.Dlugosc) + "m")
print("Wybrane auta: " + auto1.Nazwa + " oraz " + auto2.Nazwa)

calkowitydystans = glownywyscig.Tor.Dlugosc * liczbaokrazen
print("Ilosc okrazen: " + str(liczbaokrazen))
print("Całkowity dystans wyscigu: " + str(calkowitydystans) + "m")
# END Sekcja podsumowanie przed wyscigiem

# START Sekcja wyscig
print("\nNaciśnij ENTER, aby rozpocząć wyścig!")
input() 

while glownywyscig.Auto1.Dystans < calkowitydystans and glownywyscig.Auto2.Dystans < calkowitydystans:
    glownywyscig.Stoper.Czas += 1

    ruchauto1 = random.randint(50, 550) 
    ruchauto2 = random.randint(50, 550)

    glownywyscig.Auto1.Dystans += ruchauto1
    glownywyscig.Auto2.Dystans += ruchauto2

    os.system('cls' if os.name == 'nt' else 'clear')
    print("=== WYŚCIG ===")
    print("Czas wyścigu: " + str(glownywyscig.Stoper.Czas) + "s\n")

    okrazauto1 = int(glownywyscig.Auto1.Dystans / wybranytor.Dlugosc) + 1
    okrazauto2 = int(glownywyscig.Auto2.Dystans / wybranytor.Dlugosc) + 1
    
    dystansauto1 = glownywyscig.Auto1.Dystans % wybranytor.Dlugosc
    dystansauto2 = glownywyscig.Auto2.Dystans % wybranytor.Dlugosc

    print(glownywyscig.Auto1.Nazwa)
    print("Okrążenie: " + str(okrazauto1) + "/" + str(liczbaokrazen) + " | Dystans: " + str(dystansauto1) + "m / " + str(wybranytor.Dlugosc) + "m\n")

    print(glownywyscig.Auto2.Nazwa)
    print("Okrążenie: " + str(okrazauto2) + "/" + str(liczbaokrazen) + " | Dystans: " + str(dystansauto2) + "m / " + str(wybranytor.Dlugosc) + "m")

    time.sleep(1) 
# END Sekcja wyscig

# START Sekcja wyniki
print("\n=== KONIEC WYŚCIGU ===")

if glownywyscig.Auto1.Dystans >= calkowitydystans:
    print("Zwycięzca: " + glownywyscig.Auto1.Nazwa)
else:
    print("Zwycięzca: " + glownywyscig.Auto2.Nazwa)

print("Czas całkowity: " + str(glownywyscig.Stoper.Czas) + "s")
# END Sekcja wyniki
