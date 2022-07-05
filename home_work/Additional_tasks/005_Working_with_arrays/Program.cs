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
        randomArray[count] = new Random().Next(fromNumber, upToNumber + 1);
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

void PrintArray (int[] array, int userResponseArray, int bootStripeDelay)
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
    if (userResponseArray == 1)
    {
        Console.WriteLine("Подождите информация обрабатывается");
        Console.Write("[");
        for (int count = 0; count < 40; count++)
        {
            Console.Write("#");
            Thread.Sleep(bootStripeDelay);
        }
        Console.Write("]");
        Console.WriteLine();
    }
    Console.WriteLine();
    Console.WriteLine(" Ваш массив - " + result);
}

int[] AddToArray (int[] array)
{
    Console.Write("Введите число которое хотите добавить в массив: ");
    int userNumber = Convert.ToInt32(Console.ReadLine());
    int[] buffArray = new int [array.Length + 1];
    for (int index = 0; index < array.Length; index++)
    {
        buffArray[index] = array[index];
    }
    buffArray[array.Length] = userNumber;
    return buffArray;
}

int[] RemoveFromArray (int[] array, ref int selector)
{
    Console.Write("Введите индекс числа которое хотите удалить из массива: ");
    int userIndex = Convert.ToInt32(Console.ReadLine());
    if (userIndex > array.Length - 1)
    {
        Console.WriteLine();
        Console.WriteLine("Значение индекса больше размера массива");
        Selector(ref selector);
        return array;
    }
    else
    {
        int[] buffArray = new int [array.Length - 1];
        int buffIndex = 0;
        for (int index = 0; index < array.Length; index++)
        {
            if (index != userIndex)
            {
                buffArray[buffIndex] = array[index];
                buffIndex++;
            }
        }
        return buffArray;
    }
}

int Selector (ref int selector)
{
    if (selector == 1)
    {
        selector = 2;
        return selector;
    }
    else
    {
        selector = 1;
        return selector;
    }
}

int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
int[] userArray = new int [10];
int userAnswer = -1,
    selector = 1;

Console.Clear();

Console.Write("Хотите создать новый массив(1) или использовать программный массив(2): ");
int userResponseArray = Convert.ToInt16(Console.ReadLine());

if (userResponseArray == 1)
{
    Console.WriteLine("Какой массив вы хотите создать?");
    Console.WriteLine(" Массив из случайных значений в заданном диапазоне - цифра 1");
    Console.WriteLine(" Массив значния которого задаются пользователем -цифра 2");
    Console.Write("Введите цифру: ");
    userAnswer = Convert.ToInt16(Console.ReadLine());

    if (userAnswer == 1)
    {
        userArray = GetRandomArray();
    }
    else if (userAnswer == 2)
    {
        userArray = GetUserArray();
    }
    else
    {
        Console.WriteLine("Введено не допустимое значение");
        return;
    }
    PrintArray(userArray, userResponseArray, 50);
}
else if (userResponseArray == 2)
{
    userArray = array;
    PrintArray(userArray, userResponseArray, 10);
}
userResponseArray = 1;
while(true)
{
    Thread.Sleep(500); // Задержка вывода 1 секунда.
    Console.WriteLine();
    Console.WriteLine("Если хотите добавить в массив элемент введите цифру 1.");
    Console.WriteLine("Если хотите удалить элемент массива введите цифру 2.");
    Console.WriteLine("Для выхода введите Exit");
    Console.WriteLine();
    Console.Write("Введите команду: ");
    string userAddOrRemoveAnswer = Console.ReadLine() ?? "";
    if (userAddOrRemoveAnswer.ToLower() == "exit")
    {
        Console.Clear();
        break;
    }
    else
    {
        userAnswer = Convert.ToInt16(userAddOrRemoveAnswer); 
        if (userAnswer == 1)
        {
            userArray = AddToArray(userArray);
            PrintArray(userArray, userResponseArray, 1);
        }
        else if (userAnswer == 2)
        {
            userArray = RemoveFromArray(userArray, ref selector);
            if (selector == 1)
            {
                PrintArray(userArray, userResponseArray, 2);

            }
            else
            {
            Selector(ref selector);
            }
        }
    }
}


