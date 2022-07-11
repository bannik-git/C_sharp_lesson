void PrintArray (int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
    Console.WriteLine();
}

int GetSizeArray (string question)
{
    Console.Write(question);
    return Convert.ToInt32(Console.ReadLine());
}

int[] GetArray(int size)
{
	int[] array = new int[size];
	for (int i =0; i < size; i++)
	{
		array[i] = new Random().Next(-8,9);
	}
return array;
}

int[] CopyArray (int[] array)
{
    int[] newArray = new int [array.Length];
    for (int i = 0; i < newArray.Length; i++)
    {
        newArray[i] = array[i];
    }
    return newArray;
}

int size = GetSizeArray("Введите длинну массива: ");
int[] array = GetArray(size),
      copyArray = CopyArray(array);

PrintArray (array);
array [0] = 100;
PrintArray (array);
PrintArray (copyArray);
    

