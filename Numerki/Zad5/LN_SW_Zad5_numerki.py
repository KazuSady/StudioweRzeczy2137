import numpy as np
import matplotlib.pyplot as plt

X = []
Y = []
nodes = []
Ynodes = []
c = []
Yvalues = []
Xvalues = []
Xczebyszew = []
Yczebyszew = []
coefficients = []
sum = 0.0
bsum = 0.0
ile = 0
epsilon = 0.0

# Definicje funkcji
def liniowa(x):
    return x - 1

def absx(x):
    return abs(x)

# x^3 - 4x^2 +1 - 2
def wielomian(x):
    wsp = [1, -4, 1, -2]
    return Horner(3, wsp, x)

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
# Punkty/węzły - generowanie punktów w przedziale [a,b] z krokiem 0.01
def Punkty(a, b, funk):
    i = a
    while i <= b:
        X.append(i)
        Y.append(Wartosci(i, funk))
        i += 0.01
#------------------------------------------------------
# Obliczanie wartości punktów
def Wartosci(x, funk):
    wynik = 0
    if(funk==1):
        wynik=liniowa(x)
    elif (funk==2):
        wynik=absx(x)
    elif (funk==3):
        wynik=wielomian(x)
    elif (funk==4):
        wynik=trygonometryczna(x)
    elif (funk==5):
        wynik=zl1(x)
    elif (funk==6):
        wynik=zl2(x)
    else:
        wynik=zl3(x)
    return wynik
#------------------------------------------------------ 
# Obliczenie wartości węzłów dla interpolacji wielomianowej
def cnodes(stopien, a, b, wybor):
    for i in range(stopien + 1):
        c.append((1/2.0) * ((b - a) * np.cos(((2*i + 1) * np.pi) / (2 * stopien + 2)) + (b + a)))
        Ynodes.append(Wartosci(c[i], wybor))
    
    for i in range(1, stopien + 2):
        nodes.append(-np.cos((2*i + 1) * np.pi / (2.0 * (stopien + 1))))
#------------------------------------------------------ 
# Współczynniki wielomianów
def Coefficients(stopien):
    for i in range(stopien + 1):
        suma1 = 0
        suma2 = 0
        for k in range(stopien + 1):
            suma1 += Ynodes[k] * Polynomials(Xvalues[k], i)
            suma2 += Polynomials(Xvalues[k], i) * Polynomials(Xvalues[k], i)
        coefficients.append(suma1 / suma2)
#------------------------------------------------------         
# Wielomiany
def Polynomials(x, stopien):
    if stopien == 0:
        return 1.0
    elif stopien == 1:
        return x
    else:
        tkm1 = x
        tkm2 = 1.0
        tk = 0.0
        for i in range(2, stopien + 1):
            tk = (2.0 * x * tkm1) - tkm2
            tkm2 = tkm1
            tkm1 = tk
        return tk
#------------------------------------------------------ 

# Menu
print("Wybierz funkcję:\n1 - x-1\n2 - |x|\n3 - x^3-4x^2+x-2\n4 - sin(x)\n5 - cos(x)*(x-1)\n6 - |sin(x)|+4x\n7 - |4cos(x)-3|")
choice = int(input())
print("Podaj dolną granicę:")
a = float(input())
print("Podaj górną granicę:")
b = float(input())
print("Wybierz tryb pracy: \n1. Program dobiera stopień wielomianu\n2. Podaję stopień wielomianu: ")
tryb = input()
match tryb:
    case '1':
        print("Wprowadź oczekiwany błąd aproksymacji:")
        eps = float(input())
        n = 1
        while True:
            Y.clear()
            X.clear()
            c.clear()
            Ynodes.clear()
            Xvalues.clear()
            coefficients.clear()
            Yvalues.clear()
            n += 1
            Punkty(a, b, choice)
            cnodes( n, a, b, choice)
            for i in range(n+1):
                Xvalues.append((2*c[i]-(b+a))/(b-a))
                Yvalues.append(Wartosci(Xvalues[i], choice))
            Coefficients(n)
            bsum = 0.0
            ile = 0
            epsilon = 0.0
        
            for i in np.arange(a, b+0.2, 0.2):
                for j in range(n+1):
                    sum += coefficients[j] * Polynomials((2.0*(i-a))/(b-a)-1, j)
                bsum += abs(Wartosci(i, choice) - sum)
                ile += 1
                sum = 0.0
            epsilon = bsum / ile
            bsum = 0.0
            if epsilon <= eps:
                break
        sum = 0.0
        for i in np.arange(a, b+0.01, 0.01):
            Xczebyszew.append(i)
            for j in range(n+1):
                sum += coefficients[j] * Polynomials((2.0*(i-a))/(b-a)-1, j)
            Yczebyszew.append(sum)
            sum = 0.0
        print("Stopień wielomianu aproksymującego, dla którego osiągnięto zadaną dokładność to:", n)
    case '2':
        print("Podaj stopień wielomianu aproksymującego:")
        n = int(input())
        Punkty(a, b, choice)
        cnodes( n, a, b, choice)
        for i in range(n + 1):
            Xvalues.append((2*c[i]-(b+a))/(b-a))
            Yvalues.append(Wartosci(Xvalues[i], choice))
        Coefficients(n)
        for i in np.arange(a, b+0.01, 0.01):
            Xczebyszew.append(i)
            for j in range(n+1):
                sum += coefficients[j] * Polynomials((2.0*(i-a))/(b-a)-1, j)
            Yczebyszew.append(sum)
            sum = 0.0
        for i in np.arange(a, b+0.2, 0.2):
            for j in range(n+1):
                sum += coefficients[j] * Polynomials((2.0*(i-a))/(b-a)-1, j)
            bsum += abs(Wartosci(i, choice) - sum)
            ile += 1
            sum = 0.0
        epsilon = bsum / ile
        print("Błąd aproksymacji:", epsilon)


plt.plot(X, Y, label='Funkcja')
plt.plot(Xczebyszew, Yczebyszew, label='Aproksymacja')
plt.legend()
plt.xlabel('x')
plt.ylabel('f(x)')
plt.title('Aproksymacja wielomianami Czebyszewa')
plt.show()