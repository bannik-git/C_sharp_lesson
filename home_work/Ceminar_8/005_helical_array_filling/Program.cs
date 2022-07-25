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

int[,] FillInSquareArray (int[,] array, 
                  int row, 
                  int column, 
                  int count = 1, 
                  int startRowIndex = 0, 
                  int startColumnIndex = 0)
{
    if (row < 0 || column < 0)
        return array;
    else if (row == 0 || column == 0) 
    {
        if (row == 0 && column != 0)
            for (int k = 0; k <= column; k++)
                array[startRowIndex, startColumnIndex + k] = count++; 
        else if (column == 0 && row != 0)
            for (int t = 0; t <= row; t++)
                array[startRowIndex + t, startColumnIndex] = count++;
        else
            array[startRowIndex, startColumnIndex] = count;
        return array;
    }
    else
    {
        for (int i = 0; i < 4; i++) // всегда 4 стороны
        {

            if (i == 0)
                for (int j = 0; j < column; j++) // Заполняем только 3 элемента
                    array[startRowIndex, j + startColumnIndex] = count++;
            else if (i == 1)
                for (int j = 0; j < row; j++)
                    array[j + startRowIndex, column + startColumnIndex] = count++;
            else if (i == 2)
                for (int j = 0; j < column; j++)
                    array[row + startRowIndex, column - j + startColumnIndex] = count++;
            else if (i == 3)
                for (int j = 0; j < row; j++)
                    array[row - j + startRowIndex, startColumnIndex] = count++;

        }
        array = FillInSquareArray(array, row -2, column -2, count, ++startRowIndex, ++startColumnIndex);
    }   
    return array;
}

// index   0   1   2  3 
//   0   { 1,  2,  3, 4}
//   1   {12, 13, 14, 5}
//   2   {11, 16, 15, 6}
//   3   {10,  9,  8, 7}
//   

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];
array = FillInSquareArray(array, row - 1, column - 1);
PrintTwoDimensionalArray(array);
