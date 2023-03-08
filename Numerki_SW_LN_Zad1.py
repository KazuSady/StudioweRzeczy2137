import math

def wielomian(x):
    # f(x) = (x^3) - x + 1 
    return x**2 - 2*x + 1

def wykladnicza(x):
    # f(x) = ( (1/3)^x - 3)
    return pow((1/3),x) - 3

def trygonometryczna(x):
    # f(x) = sin(x)
    return math.cos(x)

def bisekcja(fun, low, high, eps = None, iter = None):
    fLow = fun(low) * 1.0
    fHigh = fun(high) * 1.0
    repetition = 0

    if (fLow * fHigh > 0):
        return "Error"
    else:

        while(1):
            repetition += 1
            mid = (low + high) / 2
            
            if ((eps != None) and (abs(low - mid) < eps)):
                break
            if ((iter != None) and (repetition >= iter)):
                break

            fMid = fun(mid) * 1.0
            if ( (eps != None) and (abs(fMid < eps))):
                break

            if (fLow * fMid < 0):
                high = mid
            else:
                low = mid
                fLow = fMid
        return "Pierwiastek: " + str(mid) + "\n" + "Wartosc funkcji: " + str(fun(mid))
    
