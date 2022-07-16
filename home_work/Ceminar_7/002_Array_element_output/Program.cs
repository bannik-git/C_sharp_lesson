string GetNumber (string userString)
{
    Console.Write(userString);
    return Console.ReadLine() ?? String.Empty;
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

int row = Convert.ToInt32(GetNumber("Введите количество строк массива: ")),
    column = Convert.ToInt32(GetNumber("Введите количество столбцов массива: "));

int[,] array = FillArray(row, column);
PrintArray(array);

string indexElements = GetNumber("Введите индексы нужного элемента: ");

int rowIndex = (int)Char.GetNumericValue(indexElements[0]),
    columnIndex = (int)Char.GetNumericValue(indexElements[1]);

if (array.GetLength(0) > rowIndex && array.GetLength(1) > columnIndex)
    Console.WriteLine(array[rowIndex, columnIndex]);
else
    Console.WriteLine("Такого числа нет");
