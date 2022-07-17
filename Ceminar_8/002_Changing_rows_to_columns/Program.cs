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

int[,] ArrayRotation (int[,] array)
{
    //                              columns             row
    int[,] newArray = new int[array.GetLength(1), array.GetLength(0)];
    for (int i = 0; i < newArray.GetLength(0); i++) // i - строки
    {
        for (int j = 0; j < newArray.GetLength(1); j++) // j - столбцы
        {
            newArray [i, j] = array[j, i];
        }
    }
    return newArray;

}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];

// index  0  1  2  3 -column  index  0  1  2 - row
//   0 - {1, 2, 3, 4}           0 - {1, 4, 7}
//   1 - {4, 5, 6, 7},          1 - {2, 5, 8},
//   2 - {7, 8, 9, 10}          2 - {3, 6, 9}
//   row                        3 - {4, 7, 10}
//                            Column

array = FillArray(array);
PrintArray(array);

int[,] newArray = ArrayRotation(array);
PrintArray(newArray);
