import math

def wielomian(x):
    # f(x) = 2x^3 - 6x^2 + 2x - 1
    return 2*pow(x,3)-6*x*x+2*x-1

def wykladnicza(x):
    # f(x) = ( (1/3)^x - 3)
    return pow((1/3),x) - 3

def trygonometryczna(x):
    # f(x) = sin(x)
    return float(math.sin(x))

def zlozenie(x):
    # f(x) = 2x - 4 + arctan(x)
    return 2*x - 4 + (math.atan(x))

#Pochodne
def Dwielomian(x):
    # f(x) = 6x^2 - 12x +2
    return 6*x*x - 12*x +2

def Dwykladnicza(x):
    # f(x) = -3^(-x)*log(3)
    return -pow(3,-x)*math.log(3)

def Dtrygonometryczna(x):
    # f(x) = cos(x)
    return float(math.cos(x))

def Dzlozenie(x):
    # f(x) = 1/(x*x+1)+2
    return 1/(x*x+1)+2

def bisekcja(fun, low, high, eps, iter):
    # fLow - dolna część przedziału
    fLow = fun(low) * 1.0   
    # fHigh - górna część przedziału
    fHigh = fun(high) * 1.0
    repetition = 0

    # Sprawdza, czy rozwiązanie funkcji nie występuje na którymś z końców przedziału
    if (fun(low) == 0): 
        return "Pierwiastek: " + str(low) + "\nLiczba iteracji: 1"
    elif (fun(high) == 0): 
        return "Pierwiastek: " +  str(high) + "\nLiczba iteracji: 1"
    
    # Sprawdza, czy początek i koniec przedziału posiada różne znaki
    if (fLow * fHigh > 0):
        return "Wykryto ten sam znak"
    else:
        # Wykonuje, dopóki wartość absolutna różnicy nie jest mniejsza od zadanego epsilona
        while(eps != None and abs(low-high) > eps or iter != None):

            if (iter != None and repetition == iter):
                break

            repetition += 1
            mid = (low + high) / 2.0

            if (fun(mid) == 0):
                break
            if (fun(low) * fun(mid) < 0):
                high = mid
            else:
                low = mid

        return "Pierwiastek: " + str(mid) + "\nLiczba iteracji: " + str(repetition)

# GIGA WAŻNE METODA STYCZNYCH DLA TRYGONOMETRYCZNEJ NIE DZIAŁA DK WHY

def styczna(fun, Dfun, low, high, eps, iter):
    repetition = 0
    tmp = low
    x = high
    while((iter != None and repetition != iter) or (eps != None and abs(tmp-x) > eps)):
        x = tmp 
        tmp = x - fun(x)/Dfun(x)
        repetition += 1
    return "Pierwiastek: " + str(tmp) + "\nLiczba iteracji: " + str(repetition)


print("Wybierz funkcję, której rozwiązanie chcesz znaleźć:\n1 - wielomian\n2 - wykładnicza\n3 - trygonometryczna\n4 - złożona")
fun = input()
print("Wpisz dolną granicę funkcji: ")
low = float(input())
print("Wpisz górną granicę funkcji: ")
high = float(input())
print("Określ kryterium zatrzymania algorytmu:\n1 - warunek dokładności\n2 - liczba iteracji")
kryterium = input()
if kryterium == "1":
    print("Podaj wartość epsilon(np. 1e-8): ")
    eps = float(input())
    iter = None
elif kryterium == "2":
    print("Podaj liczbę iteracji: ")
    iter = int(input())
    eps = None
else:
    print("Nie wybrano odpowiedniego kryterium")
match fun:
    case '1':
        print(bisekcja(wielomian, low, high, eps, iter))
        print(styczna(wielomian, Dwielomian, low, high, eps, iter))
    case '2':
         print(bisekcja(wykladnicza, low, high, eps, iter))
         print(styczna(wykladnicza, Dwykladnicza, low, high, eps, iter))
    case '3':
        print(bisekcja(trygonometryczna, low, high, eps, iter))
        print(styczna(trygonometryczna, Dtrygonometryczna, low, high, eps, iter))
    case '4':
         print(bisekcja(zlozenie, low, high, eps, iter))
         print(styczna(zlozenie, Dzlozenie, low, high, eps, iter))


