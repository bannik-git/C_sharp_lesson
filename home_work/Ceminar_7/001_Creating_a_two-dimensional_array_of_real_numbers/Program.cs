int GetNumber (string userString)
{
    Console.Write(userString);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArray (double[,] array)
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

double[,] FillArray (int row, int column)
{
    double[,] array = new double[row, column];
    int max = 10,
        min = -3;
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = Math.Round(random.NextDouble() * (max - min) + min, 4);
        }
    }
    return array;
}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

double[,] array = FillArray(row, column);
PrintArray(array);
