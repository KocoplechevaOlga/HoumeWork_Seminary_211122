// Задайте прямоугольный двумерный массив. 
//Напишите программу, которая будет находить строку с наименьшей суммой элементов.

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
int [] ArrayFromSumInRows (int [,] matrix)
{
    int [] array = new int [matrix.GetLength(0)];
    int k = 0;
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i,j];
        }
        array[k] = sum;
        k+=1;
    }
    return array;
}
void PrintArray(int[] arr)
{
     int j = 0;
     Console.Write("|");
     for (j = 0; j < (arr.Length); j++)
     {
         Console.Write($"{arr[j], 8} | ");
     }
 }

int FindIMinFromArr (int [] arr)
{
    int min = 0;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] < arr[min]) min = i;
    }
    int rn = min+1;
    return rn;
}

Console.WriteLine("Введите количество строк:");
int matrixRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов не равное количеству строк:");
int matrixColums = Convert.ToInt32(Console.ReadLine());
while (matrixRows == matrixColums)
{
Console.WriteLine("Вы задаете не прямоугольный массив. Измените количество строк или столбцов");
Console.WriteLine("Введите количество строк:");
matrixRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов не равное количеству строк:");
matrixColums = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Введите минимальное ограничение массива:");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите максимальное ограничение массива:");
int b = Convert.ToInt32(Console.ReadLine())+1;
int [,] myMatrix = FillMatrixRnd(matrixRows, matrixColums, a, b);
PrintMatrix(myMatrix);
Console.WriteLine(" ");

int [] arrayFromRows = ArrayFromSumInRows(myMatrix);
Console.WriteLine("Суммы по строкам:");
PrintArray(arrayFromRows);
int m = FindIMinFromArr(arrayFromRows);
Console.WriteLine(" ");
Console.WriteLine($"Наименьшая сумма элементов находится в строке {m}");

