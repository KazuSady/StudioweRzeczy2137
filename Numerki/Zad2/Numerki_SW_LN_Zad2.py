def GaussSeidel(aMatrix, bMatrix,xSolution, iter, eps):
    n = len(aMatrix)
    repetition = 0                  
    while True:
        for i in range(0, n):  
            temp = 0       
            d = bMatrix[i] 
            print(d)                 
            for j in range(0, n):     
                if(i != j):
                    d-=aMatrix[i][j] * xSolution[j]
                    print(d)
            xSolution[i] = d / aMatrix[i][j]  
            # if eps != None and abs(xSolution[i]-temp) < eps:
            #     return x, repetition
            # temp = xSolution[i]
            repetition += 1 
            if iter != None and repetition == iter:
                break    
        return x, repetition
        


print('Wprowadz nazwe pliku z ukladem rownan do rozwiazania')
fileName = input()
print('Wybierz metode stopu\n1 - Ilosc iteracji\n2 - Dokladnosc')
stopMethod = input()
match stopMethod:
    case '1':
        print('Wprowadz liczbe iteracji')
        iters = input()
    case '2':
        print('Wprowadz dokladnosc, np. 1e-8')
        epsilon = input()

with open(fileName, 'r') as f:
    lines = f.readlines()
    data = []
    n = -1
    last_column = []
    for line in lines:
        chars = [float(x) for x in line.split()]
        data.append(chars[:-1])
        last_column.append(chars[-1])
        n += 1
# Creating the solutions array 
x = []
for i in range(0, n + 1):
    x.append(0)

match stopMethod:
    case '1':
        print(GaussSeidel(data, last_column, x, int(iters), None))
    case '2':
        print(GaussSeidel(data, last_column, x, None, float(epsilon)))
        