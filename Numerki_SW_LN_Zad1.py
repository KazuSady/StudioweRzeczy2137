import math

def wielomian(x):
    # f(x) = 2x3 - 6x2 + 2x - 1
    return x*(x*(x-3) + 2)-6

def wykladnicza(x):
    # f(x) = ( (1/3)^x - 3)
    return pow((1/3),x) - 3

def trygonometryczna(x):
    # f(x) = sin(x)
    return float(math.sin(x))

def zlozenie(x):
    # f(x) = 2x - 4 + arctan(x)
    return 2*x - 4 + (math.atan(x))

def bisekcja(fun, low, high, eps = None, iter = None):
    # fLow - dolna część przedziału
    fLow = fun(low) * 1.0   
    # fHigh - górna część przedziału
    fHigh = fun(high) * 1.0
    repetition = 0

    # Sprawdza, czy rozwiązanie funkcji nie występuje na którymś z końców przedziału
    if (fun(low) == 0): 
        return low
    elif (fun(high) == 0): 
        return high
    
    # Sprawdza, czy początek i koniec przedziału posiada różne znaki
    if (fLow * fHigh > 0):
        return "Error"
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

        return "Pierwiastek: " + str(mid) + "\n" + "Liczba iteracji: " + str(repetition)

# Podany epsilon 
# print(bisekcja(wielomian, -10.0, 10.0, 1e-14, None) + "\n")
# print(bisekcja(wykladnicza, -10.0, 10.0, 1e-14, None) + "\n") 
# print(bisekcja(trygonometryczna, 1.0, 10.0, 1e-14, None) + "\n") 
# print(bisekcja(zlozenie, 0.0, 4.0, 1e-14, None) + "\n") 

# # Podana liczba iteracji
# print(bisekcja(wielomian, -10.0, 10.0, None, 20) + "\n")
# print(bisekcja(wykladnicza, -10.0, 10.0, None, 20) + "\n") 
# print(bisekcja(trygonometryczna, 1.0, 10.0, None, 20) + "\n") 
# print(bisekcja(zlozenie, 0.0, 4.0, None, 20) + "\n") 

# print("Wybierz funkcję, której rozwiązanie chcesz znaleźć:\n1 - wielomian\n2 - wykładnicza\n3 - trygonometryczna\n4 - złożona")
# fun = input()
# print("Wpisz dolną granicę funkcji: ")
# low = float(input())
# print("Wpisz górną granicę funkcji: ")
# high = float(input())
# print("Określ kryterium zatrzymania algorytmu:\n1 - warunek dokładności\n2 - liczba iteracji")
# kryterium = input()
# if kryterium == "1":
#     print("Podaj wartość epsilon(np. 1e-8): ")
#     eps = float(input())
#     iter = None
# elif kryterium == "2":
#     print("Podaj liczbę iteracji: ")
#     iter = int(input())
#     eps = None
# else:
#     print("Nie wybrano odpowiedniego kryterium")
# match fun:
#     case '1':
#         print(bisekcja(wielomian, low, high, eps, iter))
#     case '2':
#          print(bisekcja(wykladnicza, low, high, eps, iter))
#     case '3':
#         print(bisekcja(trygonometryczna, low, high, eps, iter))
#     case '4':
#          print(bisekcja(zlozenie, low, high, eps, iter))


