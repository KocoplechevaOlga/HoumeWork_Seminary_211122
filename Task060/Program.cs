// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
//Напишите программу, которая будет построчно выводить массив, 
//добавляя индексы каждого элемента. Например, задан массив размером 2 x 2 x 2.
// Результат:
//      66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
//      34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)
//   

int[,,] FillThreeDMassivRnd(int rows, int colums, int depth)
{
    int[,,] massiv = new int[rows, colums, depth];
    Random rnd  = new Random();
    for (int i = 0; i < massiv.GetLength(0); i++)
    {
        for (int j = 0; j < massiv.GetLength(1); j++)
            {
                for (int k = 0; k < massiv.GetLength(2); k++)
                {
                    massiv[i,j,k] = rnd.Next(10, 100);
                    int n = massiv[i, j, k];
                    bool f = FindDig(massiv, n, i, j, k);
                    while(f == true)
                    {
                        massiv[i,j,k] = rnd.Next(10, 100);
                        n = massiv[i, j, k];
                        f = FindDig(massiv, n, i, j, k);
                    }
                }
            }
    }
    return massiv;
}

void PrintThreeDMassiv(int[,,] massivThreeD)
{
    for (int i = 0; i < massivThreeD.GetLength(0); i++)
    {
        for (int j = 0; j < massivThreeD.GetLength(1); j++)
        {
            for (int k = 0; k < massivThreeD.GetLength(2); k++)
            {
                Console.Write($"{massivThreeD[i, j, k]} ({i}, {j}, {k}) ");
            }
        }
            Console.WriteLine("");
    }
}
bool FindDig(int [,,] mas, int x, int a, int b, int c)
{
    bool f = false;
    for (int l = 0; l <= a; l++)
    {
        for (int m = 0; m <= b; m++)
        {
            for (int n = 0; n <= (c-1); n++)
            {
            if (mas[l, m, n] == x) 
            {
                f = true;
            }
            }
        }
    }    
    return f;
}

Console.WriteLine("Введите количество строк:");
int massivRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов:");
int massivColums = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите значение глубины:");
int massivDepth = Convert.ToInt32(Console.ReadLine());
int count = massivRows*massivRows*massivDepth;
if (count < 90)
{
    int [,,] my3DMassiv = FillThreeDMassivRnd(massivRows, massivColums, massivDepth);
    PrintThreeDMassiv(my3DMassiv);
}

else Console.WriteLine("Заланные параметры противоречат условию, сократите количество строк, столбцов или глубину");