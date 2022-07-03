using System.Threading;

int[] GetRandomArray ()
{
    Console.Clear();
    Console.WriteLine("Инициировано создание массива состоящего из случайных значений.");
    Console.Write(" Шаг 1. Введите нужную длину массива: ");
    int arraySize = Convert.ToInt32(Console.ReadLine());
    Console.Write(" Шаг 2. Введите начало диапазона случайных чисел: ");
    int fromNumber = Convert.ToInt32(Console.ReadLine());
    Console.Write(" Шаг 3. Введите конец диапазона случайных чисел: ");
    int upToNumber = Convert.ToInt32(Console.ReadLine());
    int[] randomArray = new int [arraySize];
    for (int count = 0; count < arraySize; count++)
    {
        randomArray[count] = new Random().Next(fromNumber, upToNumber);
    }
    return randomArray;
}

int[] GetUserArray ()
{   
    Console.Clear();
    Console.WriteLine("Инициировано создание пользовательского массива.");
    Console.Write(" Шаг 1. Введите нужную длину массива: ");
    int arraySize = Convert.ToInt32(Console.ReadLine());
    Console.Write(" Шаг 2. Заполнение массив.");
    Console.WriteLine();
    int[] userArray = new int [Convert.ToInt32(arraySize)];
    for (int count = 0; count < arraySize; count++)
    {
        Console.Write($"    Введите число №{count + 1}: ");
        userArray[count] = Convert.ToInt32(Console.ReadLine());
    }
    return userArray;
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
    Console.WriteLine("Подождите информация обрабатывается");
    int bootStripeDelay = 50;
    Console.Write("[");
    for (int count = 0; count < 40; count++)
    {
        Console.Write("#");
        Thread.Sleep(bootStripeDelay);
    }
    Console.Write("]");
    Console.WriteLine();
    Console.Write(" Ваш массив - " + result);
}

Console.WriteLine("Какой массив вы хотите создать?");
Console.WriteLine(" Массив из случайных значений в заданном диапазоне - цифра 1");
Console.WriteLine(" Массив значния которого задаются пользователем -цифра 2");
Console.Write("Введите цифру: ");
int userAnswer = Convert.ToInt16(Console.ReadLine());

if (userAnswer == 1)
{
    PrintArray(GetRandomArray());
}
else if (userAnswer == 2)
{
    PrintArray(GetUserArray());
}
else
{
    Console.WriteLine("Введено не допустимое значение");
}