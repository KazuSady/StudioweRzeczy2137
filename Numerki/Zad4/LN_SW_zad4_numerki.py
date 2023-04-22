import numpy as np

e = 2.7182818284585634

# Funkcje
def f1(x):
    return abs(x-5)
def f2(x):
    return pow(2,x)
def f3(x):
    return 4 * np.log(x + 3)
#------------------------------------------------------
# Horner
def Horner(stopien, a, x):
    wynik = a[stopien]
    for i in range(stopien - 1, -1, -1):
        wynik = wynik * x + a[i]
    return wynik

#------------------------------------------------------
# Simpson part 1
def Simpson1(a, b, funkcja):
    h = (b - a) / 2
    result = h/3 * (e**(- a)* funkcja(a) + 4 * e**(-(a+b)/2) * funkcja((a+b)/2) + funkcja(b) * e**(- b))
    return result

#------------------------------------------------------
# Simpson part 2
def Simpson2(a, b, funkcja, eps):
    result = Simpson1(a, b, funkcja)
    n = 2
    while True:
        tmp = 0
        h = (b - a) / (2 * n)
        start = a
        koniec = a +2 * h
        for i in range(n):
            i = Simpson1(start, koniec, funkcja)
            tmp += i
            start = koniec
            koniec += 2 * h 
        if abs(tmp - result) < eps:
            result = tmp
            break
        else:
            result = tmp
            n += 1
    return result
#------------------------------------------------------
# Newton-Cotes
def newton_cotes(funkcja, eps):
    a = 0
    delta = 1
    result = 0
    iter = 1
    while True:
        resS = Simpson2(a, a + delta, funkcja, eps)
        result += resS
        a += delta
        iter += 1
        if abs(resS) <= abs(eps):
            break
    print(a, iter)
    return result
#------------------------------------------------------
# Menu
print("Wybierz funkcję:\n1 - |x-5|\n2 - cos(2x)\n3 - 4log(x+3)")
choice = input()
print("Podaj dokładność:")
eps = float(input())

match choice:
    case '1':
        przyb_cal = newton_cotes(f1, eps)
    case '2':
       przyb_cal = newton_cotes(f2, eps) 
    case '3':
        przyb_cal = newton_cotes(f3, eps)
print(przyb_cal)
 
#------------------------------------------------------   
      
