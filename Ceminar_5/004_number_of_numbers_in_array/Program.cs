// Search number of numbers [10:99] in array
int[] GetArray(int size)
{
	int[] array = new int[size];
	for (int i =0; i < size; i++)
	{
		array[i] = new Random().Next(1, 250);
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

int[] userArray = GetArray(123);

PrintArray(userArray);

int count = 0;

for(int i = 0; i < userArray.Length; i++)
{
	if(userArray[i] > 9 && userArray[i] < 100)
	{
		count++;
	}
}
Console.WriteLine(count);