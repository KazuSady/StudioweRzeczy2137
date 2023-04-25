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
# Simpson part 1
def Simpson1(a, b, funkcja):
    h = (b - a) / 2
    result = h/3 * (e**(- a*a)* funkcja(a) + 4 * e**(-((a+b)/2)*((a+b)/2)) * funkcja((a+b)/2) + funkcja(b) * e**(- b*b))
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
    delta = 1
    result = 0
    iter = 1
    a=-10
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
# Współczynniki dla kwadratury Gaussa
def wspolczynnik(n):
    s = (n,2)
    tabwspol = np.zeros(s)
    match n:
        case 2:
            tabwspol[0][0] = -0.707107
            tabwspol[0][1] = 0.886227
            tabwspol[1][0] = 0.707107
            tabwspol[1][1] = 0.886227
        case 3:
            tabwspol[0][0] = -1.224745
            tabwspol[0][1] = 0.295409
            tabwspol[1][0] = 0.000000
            tabwspol[1][1] = 1.181636
            tabwspol[2][0] = 1.224745
            tabwspol[2][1] = 0.295409
        case 4:
            tabwspol[0][0] = -1.650680
            tabwspol[0][1] = 0.081313
            tabwspol[1][0] = -0.534648
            tabwspol[1][1] = 0.804914
            tabwspol[2][0] = 0.534648
            tabwspol[2][1] = 0.804914
            tabwspol[3][0] = 1.650680
            tabwspol[3][1] = 0.081313
        case 5:
            tabwspol[0][0] = -2.020183
            tabwspol[0][1] = 0.019953
            tabwspol[1][0] = -0.958572
            tabwspol[1][1] = 0.393619
            tabwspol[2][0] = 0.000000
            tabwspol[2][1] = 0.945309
            tabwspol[3][0] = 0.958572
            tabwspol[3][1] = 0.393619
            tabwspol[4][0] = 2.020183
            tabwspol[4][1] = 0.019953
    return tabwspol
#------------------------------------------------------
# Gauss-Hermite
def hermite(wezly, funkcja):
    result = 0
    tmp = 0
    wspol = wspolczynnik(wezly)
    for i in range(wezly):
        if wspol[i][1] != 0:
            tmp = wspol[i][1] * funkcja(wspol[i][0])
            result += tmp
    return result
#------------------------------------------------------
# Menu
print("Wybierz funkcję:\n1 - |x-5|\n2 - 2^x\n3 - 4log(x+3)")
choice = input()
print("Podaj ilość węzłów dla kwadratury Gaussa: 2/3/4/5")
wezly = int(input())
print("Podaj dokładność:")
eps = float(input())

match choice:
    case '1':
        przyb_cal = newton_cotes(f1, eps)
        gausherm = hermite(wezly, f1)
    case '2':
       przyb_cal = newton_cotes(f2, eps) 
       gausherm = hermite(wezly, f2)
    case '3':
        przyb_cal = newton_cotes(f3, eps)
        gausherm = hermite(wezly, f3)
print(przyb_cal, gausherm)
 
#------------------------------------------------------   
      
