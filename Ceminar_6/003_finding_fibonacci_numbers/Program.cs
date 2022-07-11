int GetNumber (string question)
{
    Console.Write(question);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArray (int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
}

int userNumber = GetNumber("Введите норме числа Фибоначчи: "), // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
    fibonacciNumber1 = 0,
    fibonacciNumber2 = 1;
int[] fibonacciNumbers = new int[userNumber];

if (userNumber == 1)
{
    fibonacciNumbers[0] = fibonacciNumber1;
}
if (userNumber > 1)
{
    fibonacciNumbers[1] = fibonacciNumber2;
}

for (int i = 2; i < userNumber; i++)
{
    fibonacciNumbers[i] =  fibonacciNumber1 + fibonacciNumber2;
    fibonacciNumber1 = fibonacciNumber2;
    fibonacciNumber2 = fibonacciNumbers[i];
    // либо fibonacciNumbers[i] =  fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2]
}
PrintArray (fibonacciNumbers);
		