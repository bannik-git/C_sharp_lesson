int GetNumber (string userString)
{
    Console.Write(userString);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] FillArray (int[,] array)
{
    int m = 1,
        n = array.GetLength(0);
    for (int i  = 0; i < array.GetLength(0); i++)
    {   
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j < n - 1 - i || j > n - 1 + i)
                array[i, j] = 0;
            else if (j == n - 1 - i || j == n - 1 + i)
                array[i, j] = 1;
            else
            {
                if (j == n - 1 - i + m * 2)
                {
                    array[i, j] = array[i - 1, j - 1] + array[i -1 , j + 1];
                    m++;
                }
                else
                    array[i, j] = 0;                
            }
        }
        m = 1;
    }
    return array;
}

void PrintArray (int[,] array)
{
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == 0)
                Console.Write("\t");
            else
                Console.Write($"{array[i, j]}\t");
        }       
    Console.WriteLine();
    }
}

Console.Clear();
int numberString = GetNumber("Введите нормер строки треугольника: ");
int[,] pascalTriangle = new int[numberString, numberString * 2 -1];

pascalTriangle = FillArray(pascalTriangle);
PrintArray(pascalTriangle);


