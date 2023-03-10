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

def bisekcja(fun, low, high, eps = None, iter = None):
    fLow = fun(low) * 1.0
    fHigh = fun(high) * 1.0
    repetition = 0

    if (fun(low) == 0): 
        return low
    elif (fun(high) == 0): 
        return high
    
    if (fLow * fHigh > 0):
        return "Error"
    else:
        while(eps != None and abs(low-high) > eps):

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

        return "Pierwiastek: " + str(mid) + "\n" + "Wartosc funkcji: " + str(fun(mid))
    
print(bisekcja(wielomian, -10.0, 10.0, 1e-14, None) + "\n")
print(bisekcja(wykladnicza, -10.0, 10.0, 1e-14, None) + "\n") 
print(bisekcja(trygonometryczna, 1.0, 10.0, 1e-14, None) + "\n") 