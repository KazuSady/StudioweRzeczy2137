import numpy as np
import matplotlib.pyplot as plt

# Definicje funkcji
def liniowa(x):
    return x - 1

def absx(x):
    return abs(x)

def wielomian(x):
    return pow(x,3) - 4 * x * x + x - 2

def trygonometryczna(x):
    return np.sin(x)

def zl1(x):
    return np.cos(x) * (x - 1)

def zl2(x):
    return abs(np.sin(x)) + 4 * x

def zl3(x):
    return abs(4 * np.cos(x) - 3)
#------------------------------------------------------
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
print("Wybierz funkcję:\n1 - x-1\n2 - |x|\n3 - x^3-4x^2+x-2\n4 - sin(x)\n5 - cos(x)*(x-1)\n6 - |sin(x)|+4x\n7 - |4cos(x)-3|")
choice = input()
print("Podaj dolną granicę:")
a = float(input())
print("Podaj górną granicę:")
b = float(input())
print("Podaj liczbę węzłów:")
n = int(input())

wezly = czebyszew(a, b, n)

# Tworzy 1000 x dla oryginalnej funkcji
x = np.linspace(a, b, 1000)

match choice:
    case '1':
        wart_wezly = liniowa(wezly)
        y_original = liniowa(x)
    case '2':
        wart_wezly = absx(wezly)
        y_original = absx(x)
    case '3':
        wart_wezly = wielomian(wezly)
        y_original = wielomian(x)
        # wsp = [1, -4, 1, -2]
        # y_original=Horner(3, wsp, x)
    case '4':
         wart_wezly = trygonometryczna(wezly)
         y_original = trygonometryczna(x)
    case '5':
         wart_wezly = zl1(wezly)
         y_original = zl1(x)
    case '6':
         wart_wezly = zl2(wezly)
         y_original = zl2(x)
    case '7':
         wart_wezly = zl3(wezly)
         y_original = zl3(x)

y_interpolated = lagrange(x, wezly, wart_wezly)
# Rysowanie wykresu
fig, ax = plt.subplots()
ax.plot(x, y_original, label='f(x)')
ax.plot(x, y_interpolated, label='interpolated')
ax.plot(wezly, wart_wezly, 'o', label='interpolation nodes')
ax.legend()
plt.show()
#------------------------------------------------------
