int GetNumber (string userString)
{
    Console.Write(userString);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArray (int[,] array)
{
    for (int m = 0; m < array.GetLength(0); m++)
    {
        for (int n = 0; n < array.GetLength(1); n++)
        {
            Console.Write(array[m, n] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] FillArray (int row, int column)
{
    int[,] array = new int[row, column];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(-10, 11);
        }
    }
    return array;
}
void PrintArifmeticMeanColumns (int[,] array)
{   
    int result = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            result += array[j, i];
        }
        Console.WriteLine($"Среднее арифметическое столбца {i + 1} = {(result * 1.0) / array.GetLength(0)}");
        result = 0;
    }
}


int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = FillArray(row, column);
PrintArray(array);
Console.WriteLine();
PrintArifmeticMeanColumns(array);


