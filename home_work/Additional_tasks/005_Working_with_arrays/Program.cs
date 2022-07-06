using System.Threading;

int GetUserAnswer (string text)
{
    Console.Write(text);
    int userNumber = Convert.ToInt32(Console.ReadLine());
    return userNumber;
}

int[] GetRandomArray (int sizeArray, int startRandomNumber,  int endRandomNumber)
{
    int[] randomArray = new int [sizeArray];
    for (int count = 0; count < sizeArray; count++)
    {
        randomArray[count] = new Random().Next(startRandomNumber, endRandomNumber + 1);
    }
    return randomArray;
}

int[] GetUserArray (int sizeArray)
{   
    int[] userArray = new int [Convert.ToInt32(sizeArray)];
    for (int count = 0; count < sizeArray; count++)
    {
        userArray[count] = GetUserAnswer($"    Введите число №{count + 1}: ");
    }
    return userArray;
}

void PrintIntArray (int[] array, int userResponseArray, int bootStripeDelay)
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

void PrintStringArray (string[] array)
{
    for (int count = 0; count < array.Length; count++)
    {
        Console.WriteLine(array[count]);
    }
}

int[] AddToArray (int[] array, int number)
{
    int[] buffArray = new int [array.Length + 1];
    for (int index = 0; index < array.Length; index++)
    {
        buffArray[index] = array[index];
    }
    buffArray[array.Length] = number;
    return buffArray;
}

bool TryRemoveFromArray (ref int[] array, int userIndex)
{
    if (userIndex > array.Length - 1)
    {
        return false;
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
        array = buffArray;
        return true;
    }
}

int[] Shuffle (int[] array)
{
    int[] indexArray = new int [array.Length];
    for (int count = 0; count < array.Length; count++)
    {
        indexArray[count] = count;
    }

    int[] buffArray = new int [array.Length];
    int randomIndex = 0;
    for (int index = 0; index < array.Length; index++)
    {
        randomIndex = new Random().Next(0, indexArray.Length);
        buffArray[index] = array[indexArray[randomIndex]];
        TryRemoveFromArray(ref indexArray, randomIndex);
    }
    return buffArray;
}

int[] array = { 1, 2, 3, 4, 5, 6, 7, 8 };
int[] userArray = new int [10];
int userAnswer = -1;

Console.Clear();

int userResponseArray = GetUserAnswer("Хотите создать новый массив(1) или использовать программный массив(2): ");

if (userResponseArray == 1)
{
    string[] arraySelection = {"Какой массив вы хотите создать?",
                    " Массив из случайных значений в заданном диапазоне - цифра 1",
                    " Массив значния которого задаются пользователем -цифра 2"};
    PrintStringArray(arraySelection);
    userAnswer = GetUserAnswer("Введите цифру: ");
    Console.Clear();
    if (userAnswer == 1)
    {
        Console.WriteLine("Инициировано создание массива состоящего из случайных значений.");
        int arraySize = GetUserAnswer(" Шаг 1. Введите нужную длину массива: ");
        int fromNumber = GetUserAnswer(" Шаг 2. Введите начало диапазона случайных чисел: ");
        int upToNumber = GetUserAnswer(" Шаг 3. Введите конец диапазона случайных чисел: ");
        userArray = GetRandomArray(arraySize, fromNumber, upToNumber);
    }
    else if (userAnswer == 2)
    {
        Console.WriteLine("Инициировано создание пользовательского массива.");
        int arraySize = GetUserAnswer(" Шаг 1. Введите нужную длину массива: ");
        Console.Write(" Шаг 2. Заполнение массив.");
        Console.WriteLine();
        userArray = GetUserArray(arraySize);
    }
    else
    {
        Console.WriteLine("Введено не допустимое значение");
        return;
    }
    PrintIntArray(userArray, userResponseArray, 50);
}
else if (userResponseArray == 2)
{
    userArray = array;
    PrintIntArray(userArray, userResponseArray, 10);
}
userResponseArray = 1;
while(true)
{
    Thread.Sleep(500); // Задержка вывода 1 секунда.
    string[] addingOrRemovingAnArrayElement = {String.Empty,
                    "Если хотите добавить в массив элемент введите цифру 1.",
                    "Если хотите удалить элемент массива введите цифру 2.",
                    "Eсли хотите перемешать элементы массива введите цифру 3",
                    "Для выхода введите Exit",
                    String.Empty};
    PrintStringArray(addingOrRemovingAnArrayElement);
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
            int userNumber = GetUserAnswer("Введите число которое хотите добавить в массив: ");
            userArray = AddToArray(userArray, userNumber);
            PrintIntArray(userArray, userResponseArray, 1);
        }
        else if (userAnswer == 2)
        {
            int userIndex = GetUserAnswer("Введите индекс числа которое хотите удалить из массива: ");
            bool performingOperation = TryRemoveFromArray(ref userArray, userIndex);
            if (performingOperation)
            {
                PrintIntArray(userArray, userResponseArray, 2);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Значение индекса больше размера массива");
            }
        }
        else if (userAnswer == 3)
        {
            PrintIntArray(Shuffle(userArray), userResponseArray, 2); 
        }
    }
}


