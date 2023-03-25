import numpy as np

def is_diagonally_dominant(matrix):
    n = len(matrix)
    # Loop over rows and check if each row is diagonally dominant
    for i in range(n):
        row_sum = sum(abs(matrix[i][j]) for j in range(n) if j != i)
        if abs(matrix[i][i]) <= row_sum:
            return False
    return True

def make_diagonally_dominant(matrix):
    
    n = len(matrix)
    
    # Loop over rows and rearrange elements to make diagonal dominant
    for i in range(n):
        max_val = abs(matrix[i][i])
        max_idx = i
        
        # Find index of maximum absolute value in row
        for j in range(n):
            if j != i and abs(matrix[i][j]) > max_val:
                max_val = abs(matrix[i][j])
                max_idx = j
        
        # Swap elements to make maximum value on diagonal
        if max_idx != i:
            matrix[i][i], matrix[i][max_idx] = matrix[i][max_idx], matrix[i][i]
    return matrix

def GaussSeidel(A, b, X, iter, eps):
    n = len(b)     
    if is_diagonally_dominant(A)!=True: 
        A=make_diagonally_dominant(A)
    for rep in range(iter):
        x_new = np.zeros(n)
        for j in range(n):
            s1 = np.dot(A[j, :j], x_new[:j])
            s2 = np.dot(A[j, j + 1:], X[j + 1:])
            x_new[j] = (b[j] - s1 - s2) / A[j, j]
        if eps!=None and np.allclose(X, x_new, rtol=eps):
            return x_new,rep
        X = x_new
    return X,rep

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
        x=GaussSeidel(A, b, x0, iters, None)
        print(str(np.round(x[0],2))+' rep:'+str(x[1]))
    case '2':
        x=GaussSeidel(A, b, x0, 1000, epsilon)
        print(str(np.round(x[0],2))+' rep:'+str(x[1]))
       





