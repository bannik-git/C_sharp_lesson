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

int[,] FillArray (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array [i, j] = new Random().Next(0, 10);
        }
    }
    return array;
}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];

// index  0  1  2
//   0 - {1, 2, 3}
//   1 - {4, 5, 6},
//   2 - {7, 8, 9}

array = FillArray(array);
PrintArray(array);

int buff = 0;
int indexFirstString = 0;

for (int i = 0; i < array.GetLength(1); i++)
{
    buff = array[indexFirstString, i];
    array[indexFirstString, i] = array[array.GetLength(0) - 1 , i];
    array[array.GetLength(0) - 1 , i] = buff;
}

Console.WriteLine();
PrintArray(array);
