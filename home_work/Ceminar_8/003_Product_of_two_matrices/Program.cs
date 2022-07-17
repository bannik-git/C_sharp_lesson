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

int[,] MatrixMultiplication (int[,] array1, int[,] array2)
{
    int row = 0,
        columns = 0,
        result = 0;
    if ((array1.GetLength(0) < array2.GetLength(0) || array1.GetLength(0) == array2.GetLength(0))
     && (array1.GetLength(0) == array2.GetLength(1)))
        row = columns = array1.GetLength(0);
    else if (array1.GetLength(0) > array2.GetLength(0) && array1.GetLength(0) == array2.GetLength(1)) 
        row = columns = array2.GetLength(1);
    else
    {
        Console.WriteLine("Матрицы не совместимы");
    }
    
    int[,] resultArray = new int[row, columns];

    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
                for (int m = 0; m < array1.GetLength(1); m++)
                {
                    result += array1[i, m] * array2[m, j]; 
                }
            resultArray[i, j] = result;
            result = 0;
        }
    }
    return resultArray;
}


Console.WriteLine("Создание 1 массива: ");
int row1 = GetNumber(" Введите количество строк массива: "),
    column1 = GetNumber(" Введите количество столбцов массива: ");
int[,] array1 = new int [row1, column1];
array1 = FillArray(array1);
PrintTwoDimensionalArray(array1);

Console.WriteLine("Создание 2 массива: ");
int row2 = GetNumber(" Введите количество строк массива: "),
    column2 = GetNumber(" Введите количество столбцов массива: ");

int[,] array2 = new int [row2, column2];
array2 = FillArray(array2);
PrintTwoDimensionalArray(array2);

int[,] resultArray = MatrixMultiplication(array1, array2);
Console.WriteLine("Ответ:");
PrintTwoDimensionalArray(resultArray);

