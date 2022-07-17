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

int SizeArray (int[,] array)
{
    int max = array[0 ,0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (max < array[i, j])
                max = array[i,j];
        }
    }
    return max + 1;
}

int GetQuantity (int[,] array, int number)
{
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (number == array[i,j])
                count++;
        }
    }
    return count;
}

int[] FillingArrayNumberOfMatches (int[] array, int [,] twoDimensionalArray)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = GetQuantity(twoDimensionalArray, i);
    }
    return array;
}

void PrintArray (int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != 0)
            Console.WriteLine($"{i} встречается {array[i]} раз");

    }
}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];
array = FillArray(array);
PrintTwoDimensionalArray(array);

int[] arrayWithAnswers = new int[SizeArray(array)];
arrayWithAnswers = FillingArrayNumberOfMatches(arrayWithAnswers, array);

PrintArray(arrayWithAnswers);

