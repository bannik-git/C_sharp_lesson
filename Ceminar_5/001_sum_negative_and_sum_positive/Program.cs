void PrintArray(int[] array) 
{ 
	for(int i = 0; i< array.Length; i++) 
	{ 
		Console.Write(array[i] + " "); 
	} 
	Console.WriteLine(); 
} 

void FillArray(int[] array) 
{ 
	for(int i = 0; i< array.Length; i++) 
	{ 
		array[i] = new Random().Next(-9, 10); 
	} 
} 

int[] numbers = new int[12];
int sumPositive = 0; 
int sumNegative = 0; 

FillArray(numbers); 
PrintArray(numbers); 

for(int i = 0; i< numbers.Length; i++) 
{ 
	if(numbers[i] > 0) 
	{ 
		sumPositive += numbers[i]; 
	} 
	else 
	{ 
		sumNegative += numbers[i]; 
	} 
} 

Console.WriteLine($"Сумма положительных равна {sumPositive}, сумма отрицательных равна {sumNegative}"); 
