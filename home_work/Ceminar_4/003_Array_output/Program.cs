int[] GetRandomArray (int arraySize, int fromNumber, int upToNumber)
{
    int[] randomArray = new int [arraySize];
    for (int count = 0; count < arraySize; count++)
    {
        randomArray[count] = new Random().Next(fromNumber, upToNumber);
    }
    return randomArray;
}

void PrintArray (int[] array)
{
    string result = String.Empty; // Пустая строка
    for (int count = 0; count < array.Length; count++)
    {
        if (count == 0)
        {
            result += $"[{array[count]}, ";
        }
        else if (count == array.Length - 1)
        {
            result += $"{array[count]}]";
        }
        else
        {
            result += $"{array[count]}, ";
        }
    }
    Console.Write(result);
}

PrintArray(GetRandomArray(8, 1, 10)); //8 - размер массива, 1 и 10 - диапазон чисел рамндомайзера. [1:10)
