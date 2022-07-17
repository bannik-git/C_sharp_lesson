int GetNumber (string userString)
{
    Console.Write(userString);
    return Convert.ToInt32(Console.ReadLine());
}

void Print3DArray (int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int m = 0; m < array.GetLength(2); m++)
            {
                Console.Write($"{array[i, j, m]}({i},{j},{m}) ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[] GetArrayTwoDigitNumbers (int[] array, int start, int end)
{
    int index = 0;
    for (int i = start; i < end + 1; i++)
    {
        array[index] = i;
        index++;
    }
    return array;
}

bool TryRemoveFromArray (ref int[] array, int userIndex)
{
    if (userIndex > array.Length - 1)
    {
        return false;
    }
    else
    {
        int[] buffArray = new int [array.Length - 1];
        int buffIndex = 0;
        for (int index = 0; index < array.Length; index++)
        {
            if (index != userIndex)
            {
                buffArray[buffIndex] = array[index];
                buffIndex++;
            }
        }
        array = buffArray;
        return true;
    }
}

int[] Shuffle (int[] array)
{
    int[] indexArray = new int [array.Length];
    for (int count = 0; count < array.Length; count++)
    {
        indexArray[count] = count;
    }

    int[] buffArray = new int [array.Length];
    int randomIndex = 0;
    Random random = new Random();
    for (int index = 0; index < array.Length; index++)
    {
        randomIndex = random.Next(0, indexArray.Length);
        buffArray[index] = array[indexArray[randomIndex]];
        TryRemoveFromArray(ref indexArray, randomIndex);
    }
    return buffArray;
}

int[,,] FillArray (int[,,] array)
{
    int[] doubleFigures = new int[99-10+1];
    doubleFigures = Shuffle(GetArrayTwoDigitNumbers(doubleFigures, 10, 99));
    int count = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
                array [i, j, n] = doubleFigures[count];
                count++;     
            }
        }
    }
    return array;
}

int row = GetNumber("Введите количество строк массива: "),
    column = GetNumber("Введите количество столбцов массива: "),
    depth = GetNumber("Введите глубину массива: ");
int[,,] array = new int [row, column, depth];
array = FillArray(array);
Print3DArray(array);




