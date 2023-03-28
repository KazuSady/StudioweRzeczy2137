import numpy as np

def is_diagonally_dominant(matrix):
    n = len(matrix)
    # Loop over rows and check if each row is diagonally dominant
    for i in range(n):
        row_sum = sum(abs(matrix[i][j]) for j in range(n) if j != i)
        if abs(matrix[i][i]) <= row_sum:
            return False
    return True


def GaussSeidel(A, b, X, iter, eps):
    n = len(b)    
    x_new = np.zeros(n) 
    D=np.zeros_like(A)
    U=np.zeros_like(A)
    L=np.zeros_like(A)
    for i in range(n):
        D[i][i]=A[i][i]
    for i in range(n):
        for j in range(i+1,n):
            U[i][j]=A[i][j]
    for i in range(1,n):
        for j in range(i):
            L[i][j]=A[i][j]
    D=np.linalg.inv(D)
    b=np.dot(D,b)
    U=np.dot(D,U)
    L=np.dot(D,L)
    for rep in range(iter):
        x_new=b-np.dot(L,x_new)-np.dot(U,X)
        if eps!=None and np.allclose(X, x_new, rtol=eps):
            return x_new,rep+1
        X = x_new
    return X, rep+1

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
        if is_diagonally_dominant(A)!=True: 
            print("Macierz nie jest zbieżna")
        else:
            x=GaussSeidel(A, b, x0, iters, None)
            print(str(np.round(x[0],4))+' rep:'+str(x[1]))
    case '2':
        if is_diagonally_dominant(A)!=True: 
            print("Macierz nie jest zbieżna")
        else:
            x=GaussSeidel(A, b, x0, 1000, epsilon)
            print(str(np.round(x[0],4))+' rep:'+str(x[1]))
       





