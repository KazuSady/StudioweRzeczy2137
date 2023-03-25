import numpy as np

def GaussSeidel(A, b, X, iter, eps):
    n = len(b)      
    for rep in range(iter):
        x_new = np.zeros(n)
        for j in range(n):
            s1 = np.dot(A[j, :j], x_new[:j])
            s2 = np.dot(A[j, j + 1:], X[j + 1:])
            x_new[j] = (b[j] - s1 - s2) / A[j, j]
        if eps!=None and np.allclose(X, x_new, rtol=eps):
            return x_new
        X = x_new
    return X

print('Wprowadz nazwe pliku z ukladem rownan do rozwiazania')
fileName = input()
print('Wybierz metode stopu\n1 - Ilosc iteracji\n2 - Dokladnosc')
stopMethod = input()
match stopMethod:
    case '1':
        print('Wprowadz liczbe iteracji')
        iters = int(input())
    case '2':
        print('Wprowadz dokladnosc, np. 1e-8')
        epsilon = float(input())

 # Read input file
A = []
b = []
with open(fileName, "r") as f:
    for line in f:
        row = [float(x) for x in line.split()]
        A.append(row[:-1])
        b.append(row[-1])

x0 = np.zeros(len(b))
A=np.array(A)
b=np.array(b)


match stopMethod:
    case '1':
        print(np.round(GaussSeidel(A, b, x0, int(iters), None),2))
    case '2':
        print(np.round(GaussSeidel(A, b, x0,100, float(epsilon)),2))





