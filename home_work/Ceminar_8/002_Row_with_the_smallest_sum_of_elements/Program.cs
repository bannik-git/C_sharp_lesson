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

int[] SumElementsRowArray (int[,] array)
{
    int[] sumElementsRowArray = new int[array.GetLength(0)];
    int sum = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        sumElementsRowArray[i] = sum;
        sum = 0;
    }
    return sumElementsRowArray;
}

int GetIndexMaximumElement (int[] array)
{

    int minIndex = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i]< array[minIndex])
            minIndex = i;
    }
    return minIndex;
}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];
array = FillArray(array);
PrintTwoDimensionalArray(array);

int[] sumOfElementsAcrossRows = SumElementsRowArray(array);
int minIndex = GetIndexMaximumElement(sumOfElementsAcrossRows);
Console.WriteLine($"Номер строки с наименьшей суммой элементов = {minIndex + 1}");
