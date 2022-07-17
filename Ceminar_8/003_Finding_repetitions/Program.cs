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
int[,] FillArray2 (int[,] array)
{
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array [i, j] = -2; // NextDouble() [0.0; 1.0] * (max - min) + min;
        }
    }
    return array;
}

int GetReplays (int[,] array, int number)
{   
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if(number == array[i, j])
                    count++;
            }
        }
    return count;
}


int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: ");

int[,] array = new int [row, column];

array = FillArray(array);
PrintArray(array);

int[,] result = GetString(array);
// PrintArray(result);

// 1, 2, 3 
// 4, 6, 1 
// 2, 1, 6

bool TrueORFalse (int[,] buff, int number)
{
    bool result = true;
    for (int i = 0; i < buff.GetLength(0); i++)
    {
        if (number == buff[i, 0])
            result = false;
    }
    return result;
}
int[,] GetString (int[,] array)
{   
    int count = 0,
        index = 0;
    int [,] buff = new int[array.Length, 2];
    buff = FillArray2(buff);
    for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                count = GetReplays(array, array[i, j]);
                if (TrueORFalse(buff, array[i, j]))
                {
                    buff[index, 0] =array[i, j]; 
                    buff[index, 1] = count;
                    index++;
                }
            }
        }
    return buff;
}
void PrintNewArray (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if(array[i, 1] != -2)
        {
            Console.Write($"{array[i, 0]} встречается {array[i, 1]} раз");
            Console.WriteLine();

        }
    }
    Console.WriteLine();
}

PrintNewArray(result);
