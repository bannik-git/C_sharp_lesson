int[] array = {6, 8, 3, 2, 1, 4, 5, 7}; //[6, 8, 3, 2, 1, 4, 5, 7];


void PrintArray(int[] array)
{
    int count = array.Length;
    for (int i = 0; i < count; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

for (int i = 0; i < array.Length -1; i++)
{
    int minIndex = i;
    for (int j = i + 1; j < array.Length; j++)
    {
        if (array[minIndex] > array[j])
        {
            minIndex = j;
        }
    }
    int numberBuff = array[i];
    array[i] = array[minIndex];
    array[minIndex] = numberBuff;
    PrintArray(array);

}

