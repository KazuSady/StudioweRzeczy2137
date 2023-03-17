import math
import numpy as np
import matplotlib.pyplot as plt

def wielomian(x):
    # f(x) = 2x^3 - 6x^2 + 2x - 1
    return 2*pow(x,3)-6*x*x+2*x-1

def rysuj_funkcje(fun, low, high, root_x1, root_x2):
    x = np.linspace(low, high, 100)
    y = fun(x)
    plt.plot(x, y)
    plt.grid()

    root_y = fun(root_x1)


    ax = plt.gca()
    ax.spines['top'].set_color('none')
    ax.spines['bottom'].set_position('zero')
    ax.spines['left'].set_position('zero')
    ax.spines['right'].set_color('none')
    ax.set_xlabel('x', size=14, labelpad=-24, x=1.03)
    ax.set_ylabel('y', size=14, labelpad=-21, y=1.02, rotation=0)

    plt.axvline(x=root_x1, color='r', linestyle='--')
    plt.text(root_x1, root_y, f'({root_x1:.4f}, {root_y:.4f})', horizontalalignment='right' if root_x1 < (low + high) / 2 else 'left')

    plt.axvline(x=root_x2, color='g', linestyle=':')
    plt.text(root_x2, root_y, f'({root_x2:.4f}, {root_y:.4f})', horizontalalignment='right' if root_x2 < (low + high) / 2 else 'left')

    plt.show()
    

def wykladnicza(x):
    # f(x) = ( (1/3)^x - 3)
    return pow((1/3),x) - 3

def trygonometryczna(x):
    # f(x) = sin(x)
    return np.vectorize(math.sin)(x)

def zlozenie(x):
    # f(x) = 2x - 4 + arctan(x)
    return 2*x - 4 + np.vectorize(math.atan)(x)

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
        return "Pierwiastek: " + str(low) + "\nLiczba iteracji: 1" , low
    elif (fun(high) == 0): 
        return "Pierwiastek: " +  str(high) + "\nLiczba iteracji: 1", high
    
    # Sprawdza, czy początek i koniec przedziału posiada różne znaki
    if (fLow * fHigh > 0):
        return "Wykryto ten sam znak wartości funkcji na granicach przedziału"
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
        return "Pierwiastek: " + str(mid) + "\nLiczba iteracji: " + str(repetition), mid

def styczna(fun, Dfun, low, high, eps, iter):
    repetition = 0
    tmp = low
    x = high
    while((iter != None and repetition != iter) or (eps != None and abs(tmp-x) > eps)):
        x = tmp 
        tmp = x - fun(x)/Dfun(x)
        repetition += 1
    return "Pierwiastek: " + str(tmp) + "\nLiczba iteracji: " + str(repetition),tmp



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
        print(bisekcja(wielomian, low, high, eps, iter)[0])
        print(styczna(wielomian, Dwielomian, low, high, eps, iter)[0])
        x1 = styczna(wielomian, Dwielomian, low, high, eps, iter)[1]
        x2 = bisekcja(wielomian, low, high, eps, iter)[1]
        rysuj_funkcje(wielomian,low,high,x1,x2)
    case '2':
        print(bisekcja(wykladnicza, low, high, eps, iter)[0])
        print(styczna(wykladnicza, Dwykladnicza, low, high, eps, iter)[0])
        x1 = styczna(wykladnicza, Dwykladnicza, low, high, eps, iter)[1]
        x2 = bisekcja(wykladnicza, low, high, eps, iter)[1]
        rysuj_funkcje(wykladnicza, low,high,x1,x2)
    case '3':
        print(bisekcja(trygonometryczna, low, high, eps, iter)[0])
        print(styczna(trygonometryczna, Dtrygonometryczna, low, high, eps, iter)[0])
        x1 = styczna(trygonometryczna, Dtrygonometryczna, low, high, eps, iter)[1]
        x2 = bisekcja(trygonometryczna, low, high, eps, iter)[1]
        rysuj_funkcje(trygonometryczna, low,high,x1,x2)
    case '4':
        print(bisekcja(zlozenie, low, high, eps, iter)[0])
        print(styczna(zlozenie, Dzlozenie, low, high, eps, iter)[0])
        x1 = styczna(zlozenie, Dzlozenie, low, high, eps, iter)[1]
        x2 = bisekcja(zlozenie, low, high, eps, iter)[1]
        rysuj_funkcje(zlozenie,low,high,x1,x2)
