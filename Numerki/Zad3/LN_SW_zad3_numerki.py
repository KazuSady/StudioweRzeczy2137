import math

# Definicje funkcji
def liniowa(x):
    return x - 1

def absx(x):
    return abs(x)

def wielomian(x):
    return pow(x,3) - 4 * x * x + x - 2

def trygonometryczna(x):
    return math.sin(x)

def zl1(x):
    return math.cos(x) * (x - 1)

def zl2(x):
    return abs(math.sin(x)) + 4 * x

def zl3(x):
    return abs(4 * math.cos(x) - 3)
#------------------------------------------------------
# Horner
def Horner(stopien, a, x):
    wynik = a[0]
    for i in range(stopien):
        wynik = wynik * x * a[i]
    return wynik

#------------------------------------------------------
# Menu
print("Wybierz funkcję:\n1 - x-1\n2 - |x|\n3 - x^3-4x^2+x-2\n4 - sin(x)\n5 - cos(x)*(x-1)\n6 - |sin(x)|+4x\n7 - |4cos(x)-3|")
choice = input()
print("Podaj x:")
x = int(input())

match choice:
    case '1':
        print('a')
    case '2':
        print('a')
    case '3':
        wsp = [1, -4, 1, -2]
        print(Horner(3, wsp, x))
    case '4':
        print('a')
    case '5':
        print('a')
    case '6':
        print('a')
    case '7':
        print('a')
#------------------------------------------------------
