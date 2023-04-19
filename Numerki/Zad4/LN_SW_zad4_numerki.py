import numpy as np
import matplotlib.pyplot as plt

# Horner
def Horner(stopien, a, x):
    wynik = a[stopien]
    for i in range(stopien - 1, -1, -1):
        wynik = wynik * x + a[i]
    return wynik

#------------------------------------------------------
# Węzły Czebyszewa
def czebyszew(a, b, n):
    k = np.arange(1, n+1)
    nodes = 0.5*(a+b)+0.5*(b-a)*np.cos((2*k+1)*np.pi/(2*n+1))
    return nodes

#------------------------------------------------------
# Interpolacja Lagrange'a
def lagrange(x, wezly, wart_wezly):
    n = wezly.size
    L = np.ones((n, x.size))
    for i in range(n):
        for j in range(n):
            if i != j:
                xj = wezly[j]
                L[i] *= (x - xj)/(wezly[i]- xj)
        L[i] *= wart_wezly[i]
    y = np.sum(L, axis=0)
    return y

#------------------------------------------------------
# Menu
print("Wybierz metodę:\n1 - Kwadratura Newtona-Cotesa\n2 - kwadratura Gaussa(wielomiany Hermite'a)")
choice = input()
print("Podaj dolną granicę:")
a = float(input())
print("Podaj górną granicę:")
b = float(input())

match choice:
    case '1':
        print('dupa')
    case '2':
        print('dupa')
#------------------------------------------------------   
      
