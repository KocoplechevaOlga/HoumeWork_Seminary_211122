// Задайте двумерный массив. Напишите программу, 
//которая упорядочит по убыванию элементы каждой строки двумерного массива.

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

int[,] RangeMatrixByRow(int [,] matrix)
{
    //int [,] rangeMatrix = new int [matrix.GetLength(0),matrix.GetLength(1)];
    int [,] rangeMatrix = matrix;
    for (int i = 0; i < rangeMatrix.GetLength(0); i++)
    {
       for (int j = 0; j < rangeMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < rangeMatrix.GetLength(1)-1; k++)
            {
                if (rangeMatrix[i, k] < rangeMatrix[i,(k+1)]) 
                {
                    int t = rangeMatrix[i,k];
                    rangeMatrix[i,k] = rangeMatrix[i,k+1];
                    rangeMatrix[i,k+1] = t;
                }
            }
        }
    }
    return rangeMatrix;
}

Console.WriteLine("Введите количество строк:");
int matrixRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов:");
int matrixColums = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите минимальное ограничение массива:");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите максимальное ограничение массива:");
int b = Convert.ToInt32(Console.ReadLine())+1;
int [,] myMatrix = FillMatrixRnd(matrixRows, matrixColums, a, b);
PrintMatrix(myMatrix);
Console.WriteLine(" ");

int [,] newMatrix = RangeMatrixByRow(myMatrix);
PrintMatrix(newMatrix);
