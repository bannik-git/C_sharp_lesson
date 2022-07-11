int GetSizeArray (string question)
{
    Console.Write(question);
    return Convert.ToInt32(Console.ReadLine());
}

double[] GetArray (int size)
{
	double[] array = new double[size];
	int wholePart = 0,
	    fractionalPart = 0;
	for (int i = 0; i < size; i++)
	{
		wholePart = new Random().Next(-100, 100);
		fractionalPart = new Random().Next(0, int.MaxValue);
		array[i] = Convert.ToDouble(wholePart + "," + fractionalPart);
        // Можно:
        // array[i] = Convert.ToDouble(wholePart)/Convert.ToDouble(fractionalPart);
        // или
        // array[i] = wholePart + new Random().NextDouble();
	}
	return array;
}

void PrintArray (double[] userArray)
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
double[] userArray = GetArray(size);
PrintArray(userArray);
double maxNumber = userArray[0],
	minNumber = userArray[0];

for (int index = 0; index < userArray.Length; index++)
{
	if (userArray[index] > maxNumber)
	{
		maxNumber = userArray[index];
	}
	else if (userArray[index] < minNumber)
	{
		minNumber = userArray[index];
	}
}
Console.WriteLine($"{maxNumber} - {minNumber} = {maxNumber-minNumber}");
