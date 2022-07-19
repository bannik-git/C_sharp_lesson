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

// int[,] FillArray (int[,] array, int row , int column, int count = 1, int i = 0)
// {
//     int index = 0;
//     if (row == 0 || column == 0)
//         return array;
//     for (i = 0; i < row * column; i++)
//     {
//         if (i == 0)
//         {   
//             for (int j = 0; j < column; j++)
//             {
//                 array[i, j] = count++;
//             }
//         }
//         else if (i < row - 1)
//         {
//             array[i, column - 1] = count++; 
//         }
//         else if (i == row -1)
//         {
//             for (int n = 0; n < column - 1; n++)
//             {
//                 array[i, column -1 - n] = count++;
//             }
//         }
//         else if (i < row * 2 - 1) // i = 4  row = 3 * 2 = 6
//                 array[row - 1 - index++, 0] = count++;
//         else
//             array = FillArray(array, row -2, column -2, count, i);

//     }
//     return array;
// }
int[,] FillInSquareArray (int[,] array, 
                  int row, 
                  int column, 
                  int count = 1, 
                  int startRowIndex = 0, 
                  int startColumnIndex = 0)
{
    // Console.WriteLine($"row = {row}, column = {column}, startRowIndex = {startRowIndex}, startColumnIndex = {startColumnIndex}");
    if (row < 0 || column < 0)
        return array;
    else if (row == 0 || column == 0) 
    {
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
                for (int j = 0; j < column; j++)
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
