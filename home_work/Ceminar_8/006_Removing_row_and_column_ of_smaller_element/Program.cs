int GetNumber (string userString)
{
    Console.Write(userString);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintTwoDimensionalArray (int[,] array)
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

int[,] FillArray (int[,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array [i, j] = random.Next(0, 10); // NextDouble() [0.0; 1.0] * (max - min) + min;
        }
    }
    return array;
}

int[,] DeleteRowAndColumnOfSmallerElement (int[,] array)
{
    int minNumber = array[0, 0],
        minRowIndex = 0,
        minColumnIndex = 0;

    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            if (minNumber > array[i, j])
            {
                minNumber = array[i, j];
                minRowIndex = i;
                minColumnIndex = j;
            }

    int[,] resultArray = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    int newRowIndex = 0,
        newColumnIndex = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        if (minRowIndex != i)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                if (minColumnIndex != j)
                {
                    resultArray[newRowIndex, newColumnIndex] = array[i, j];
                    newColumnIndex++;
                }
            newRowIndex++;
            newColumnIndex = 0;
        }
    return resultArray;
}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];
array = FillArray(array);
PrintTwoDimensionalArray(array);

// Удаляет строку и столбце первого найденного минимального элемента
array = DeleteRowAndColumnOfSmallerElement(array);
PrintTwoDimensionalArray(array);
