// Задайте две матрицы. Напишите программу, которая 
//будет находить произведение двух матриц.
//Например, даны 2 матрицы:
//                          2 4 | 3 4
//                          3 2 | 3 3
//Результирующая матрица будет:
//                          18 20
//                          15 18

int[,] FillMatrixRnd(int rows, int colums, int min, int max)
{
    int[,] matrix = new int[rows, colums];
    Random rnd  = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = rnd.Next(min, max);
            }
    } 
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i,j], 5} |");
            else Console.Write($"{matrix[i,j], 5}");
        }
        Console.WriteLine("|");
    }
}
int [,] ResultForMultMatrix (int [,] matrixA, int [,]matrixB)
{
    int [,] result = new int [matrixA.GetLength(0), matrixB.GetLength(1)];

    for(int i = 0; i < matrixA.GetLength(0); i++)
    {
        for(int k = 0; k < matrixB.GetLength(1); k++)
        {
            int s = 0;
            for(int j = 0; j < matrixB.GetLength(0); j++)
            {
                s += matrixA[i,j] * matrixB[j,k];
            }
            result[i,k] = s;

        }
    }
    return result;
}

Console.WriteLine("Введите количество строк для первой матрицы:");
int firstMatrixRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов для первой матрицы:");
int firstMatrixColums = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите минимальное ограничение массива для первой матрицы:");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите максимальное ограничение массива для первой матрицы:");
int b = Convert.ToInt32(Console.ReadLine());
int [,] firstMatrix = FillMatrixRnd(firstMatrixRows, firstMatrixColums, a, b);

Console.WriteLine("Введите количество строк для второй матрицы:");
int secondMatrixRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов для второй матрицы:");
int secondMatrixColums = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите минимальное ограничение массива для второй матрицы:");
int c = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите максимальное ограничение массива для второй матрицы:");
int d = Convert.ToInt32(Console.ReadLine());
int [,] secondMatrix = FillMatrixRnd(secondMatrixRows, secondMatrixColums, c, d);

PrintMatrix(firstMatrix);
Console.WriteLine(" ");
PrintMatrix(secondMatrix);
Console.WriteLine(" ");

if (firstMatrix.GetLength(0) == secondMatrix.GetLength(1))
{
int [,] multMatr = ResultForMultMatrix(firstMatrix, secondMatrix);
PrintMatrix(multMatr);
}
else
{
Console.WriteLine("Невозможно найти произведение заданных матриц!");
}
