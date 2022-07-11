int GetSizeArray (string question)
{
    Console.Write(question);
    return Convert.ToInt32(Console.ReadLine());
}

int[] GetArray (int size)
{
	int[] array = new int[size];
	for (int i = 0; i < size; i++)
	{
		array[i] = new Random().Next(100, 1000);
	}
	return array;
}

void PrintArray (int[] userArray)
{
	string result = "[";
	for (int i = 0; i < userArray.Length; i++)
	{
		if (i == userArray.Length -1)
		{
			result += userArray[i] + "]";
		}
		else
		{
			result += userArray[i] +", ";
		}
	}
	Console.WriteLine();
	Console.WriteLine(result);
    Console.WriteLine();
}

int size = GetSizeArray("Введите длинну массива: ");
int[] userArray = GetArray(size);
PrintArray(userArray);

int sumOfOddNumbers = 0;
for (int index = 1; index < userArray.Length; index += 2) // отсчет с нечетного индекса + 2 каждый второй индекс нечетный
{
	sumOfOddNumbers +=userArray[index];
}
Console.WriteLine($"Сумма элементов числе стоящих на нечетных позициях равна {sumOfOddNumbers}");
