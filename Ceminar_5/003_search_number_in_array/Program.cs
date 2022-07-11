int[] GetArray(int size)
{
	int[] array = new int[size];
	for (int i =0; i < size; i++)
	{
		array[i] = new Random().Next(-8,9);
	}
return array;
}

void PrintArray (int[] array)
{
	for (int i = 0; i < array.Length; i++)
	{
		Console.Write(array[i] + " ");
	}
    Console.WriteLine();
}

int[] userArray = GetArray(8);

PrintArray(userArray);
Console.Write("Введите число для поиска: ");
int userNumber = Convert.ToInt32(Console.ReadLine());

for(int i = 0; i < userArray.Length; i++)
{
	if(userArray[i] == userNumber)
	{
		Console.WriteLine("Число найдено");
		return;
	}
}
Console.WriteLine("Нет");
