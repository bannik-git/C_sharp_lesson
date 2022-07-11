int[] GetArray(int size)
{
	int[] array = new int[size];
	for (int i =0; i < size; i++)
	{
		array[i] = new Random().Next(1, 250);
	}
return array;
}

void PrintArray(int[] array) 
{ 
	for(int i = 0; i < array.Length; i++)
 	{ 
		Console.Write(array[i] + " "); 
	}	 
} 

Console.Write("Введите длинну массива: ");
int size = Convert.ToInt32(Console.ReadLine());
int[] array = GetArray(size); 
int [] arrayNew;

if(array.Length % 2 == 0)
{ 
	arrayNew = new int[array.Length / 2]; 
} 
else 
{ 
	arrayNew = new int[array.Length / 2 + 1]; 
} 
for(int i = 0; i < arrayNew.Length; i++) 
{ 
	if(i != array.Length -1 - i) 
	{ 
		arrayNew[i] = array[i] * array[array.Length - 1 - i];
 	} 
	else 
	{
 		arrayNew[i] = array[i]; 
	} 
} 

PrintArray(array); 
Console.WriteLine(); 
PrintArray(arrayNew); 
