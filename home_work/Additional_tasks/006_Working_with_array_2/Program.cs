// Метод выводящий в консоль массив состоящий из строк
void PrintStringArray (string[] array)
{
    for (int count = 0; count < array.Length; count++)
    {
        Console.WriteLine(array[count]);
    }
    Console.WriteLine();
}

// Запрос последовательности чисел
string GetUserAnswer (string text)
{
    Console.Write(text);
    string userNumber = Console.ReadLine() ?? "";
    return userNumber;
}

// печать массива
void Numbers (int[] array)
{
    string result = String.Empty; // Пустая строка
    for (int count = 0; count < array.Length; count++)
    {
        if (count == 0 && count == array.Length - 1)
        {
            result += $"[{array[count]}]";
        }
        else if (count == 0)
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
    Console.WriteLine();
    Console.WriteLine(" Ваш массив - " + result);
}

// Вспомогательная метод преобразующая строку в массив
int[] GetArray (int[] array, string userString, int startIndex)
{
    string result = String.Empty;
    for (int index = 0; index < userString.Length; index++)
    {   
        if (userString[index] != ' ')
        {
            result += userString[index];
        }
        if (userString[index] == ' ')
        {
            array[startIndex] = Convert.ToInt32(result);
            result = string.Empty;
            startIndex++;
        }
        if (index == userString.Length - 1 && result != String.Empty)
        {
            array[startIndex] = Convert.ToInt32(result);
        }
    }
    return array;
}

// Вспомогательный метод на основе строки расчитывающий длину массива
int GetNumberOfSpace (string stringWithNumbers)
{
    int space = 0;
    for (int count = 0; count < stringWithNumbers.Length; count++)
    {
        if (stringWithNumbers[count] == ' ' && count != stringWithNumbers.Length - 1)
        {
            space += 1;
        }
    }
    return space;
}

//Метод получения готового массива из строки пользователя
int[] SetNumbers (string userString)
{   
    int[] array = new int [GetNumberOfSpace(userString) + 1];
    array = GetArray(array, userString, 0);
    return array;
}

// Метод добавляющий новые элементы в массив
int[] AddNumbers (int[] array, string StringWithNumbersToAdd)
{
    int space = GetNumberOfSpace(StringWithNumbersToAdd) + 1;
    int[] buffArray = new int [array.Length + space];
    for (int count = 0; count <= array.Length; count++)
    {   
        if (count < array.Length)
        {
            buffArray[count] = array[count];
        }
        else
        {
            buffArray = GetArray(buffArray, StringWithNumbersToAdd, count);
        }
    }
    return buffArray;
}

// Метод удаляющий числа из массива если они совпали с цифрами введенными пользователем
int[] RemoveNumbers (int[] array, string stringWithNumbersToDelete)
{
    int space = GetNumberOfSpace(stringWithNumbersToDelete) + 1,
        countDeleteElements = 0; //????
    int[] buffArray = new int[array.Length],
          stringArray = new int [space];
    stringArray = GetArray(stringArray, stringWithNumbersToDelete, 0);
    for (int index = 0; index <buffArray.Length; index++)
    {
        buffArray[index] = -1; // Вводится значение элемента который будет маркером
        for (int count = 0; count <stringArray.Length; count++)
        {
            if (array[index] == stringArray[count])
            {
                buffArray[index] = array[index]; // все элементы которые не равны -1 будут удалены
                countDeleteElements++;
                break;
            }
        }
    }
    int[] resultArray = new int[array.Length - countDeleteElements];
    int buffIndex = 0;
    for (int index = 0; index < array.Length; index++)
    {
        if (buffArray[index] == -1)
        {
            resultArray[buffIndex] = array[index];
            buffIndex++;
        }
    }
    return resultArray;
}

// Метод суммирующий цифры элементов массива
int Sum (int[] array)
{
    int result = 0;
    for (int index = 0; index < array.Length; index++)
    {
        if (array[index] < 10) // однозначное число;
        {
            result += array[index];
        }
        else
        {
            while(array[index] > 0)
            {
                result += array[index] % 10;
                array[index] /= 10;
            }
        }
    }
    return result;
}

// Вспомогательный метод удаляющая элементы из массива
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

// Метод перемешивающий элементы массива
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

Console.Clear();
string[] greetings = {"Вас приветствует программа для работы с массивами чисел.",
                     "Для начала работы нужно создать числовую последовательность."};
PrintStringArray(greetings);

string userNumbers = GetUserAnswer("Введите числа через пробел: ");
int[] userArray = SetNumbers(userNumbers);
int sumDigitOfNumbers = 0;

Console.WriteLine("Поздравляем, новый массив успешно создан.");
Numbers(userArray);


// Описание функционала программы
string[] functional = {"Функционал программы:",
                       "  Создать новый массив - цифра 1",
                       "  Добавить новые элементы в созданный массив - цифра 2",
                       "  Удалить элементы из созданного массива - цифра 3",
                       "  Найти сумму всех чисел элементов массива - цифра 4",
                       "  Перемешать элементы массива - цифра 5",
                       "  Для выхода из программы введите Exit"};

Console.WriteLine();
PrintStringArray(functional);
while(true)
{
    
    string userAnswer = GetUserAnswer("Введите цифру или команду, для вывода описания функционала введите Help: ").ToLower();
    if (userAnswer == "help")
    {
        PrintStringArray(functional);
    }
    else if (userAnswer == "exit")
    {
        break;
    }
    else
    {
        int numberUserAnswer = Convert.ToInt16(userAnswer);
        if (numberUserAnswer == 1)
        {
            userNumbers = GetUserAnswer("Введите числа через пробел: ");
            userArray = SetNumbers(userNumbers);
        }
        else if (numberUserAnswer == 2)
        {
            userNumbers = GetUserAnswer("Введите через пробел числа которые вы хотите добавить: ");
            userArray = AddNumbers(userArray, userNumbers);
        }
        else if (numberUserAnswer == 3)
        {
            userNumbers = GetUserAnswer("Введите через пробел числа которые вы хотите удалить: ");
            userArray = RemoveNumbers(userArray, userNumbers);
        }
        else if (numberUserAnswer == 4)
        {
            sumDigitOfNumbers = Sum(userArray);
            Console.WriteLine(sumDigitOfNumbers);
        }
        else if (numberUserAnswer == 5)
        {
            userArray = Shuffle(userArray);
        }
        else if (userAnswer == "help")
        {
            PrintStringArray(functional);
        }
        else if (userAnswer == "exit")
        {
            break;
        }
        else
        {
            Console.WriteLine("Введена не верная команда");
        }
        if (numberUserAnswer != 4)
        {
            Numbers(userArray);
        }
    }
}



