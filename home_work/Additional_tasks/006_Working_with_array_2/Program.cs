﻿// Метод выводящий в консоль массив состоящий из строк
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
void Numbers (double[] array)
{
    string result = "["; 
    for (int count = 0; count < array.Length; count++)
    {
        if (count == array.Length - 1)
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
double[] GetArray (double[] array, string userString, int startIndex)
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
double[] SetNumbers (string userString)
{   
    double[] array = new double [GetNumberOfSpace(userString) + 1];
    array = GetArray(array, userString, 0);
    return array;
}

// Метод добавляющий новые элементы в массив
double[] AddNumbers (double[] array, string StringWithNumbersToAdd)
{
    int space = GetNumberOfSpace(StringWithNumbersToAdd) + 1;
    double[] buffArray = new double [array.Length + space];
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
double[] RemoveNumbers (double[] array, string stringWithNumbersToDelete)
{
    int space = GetNumberOfSpace(stringWithNumbersToDelete) + 1,
        countDeleteElements = 0; //????
    double[] buffArray = new double[array.Length],
             stringArray = new double [space];
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
    double[] resultArray = new double[array.Length - countDeleteElements];
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
int Sum (double[] array)
{
    int result = 0;
    for (int index = 0; index < array.Length; index++)
    {
        if (array[index] < 10) // однозначное число;
        {
            result += (int) array[index];
        }
        else
        {
            while(array[index] > 0)
            {
                result += (int)array[index] % 10;
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
double[] Shuffle (double[] array)
{
    int[] indexArray = new int [array.Length];
    for (int count = 0; count < array.Length; count++)
    {
        indexArray[count] = count;
    }

    double[] buffArray = new double [array.Length];
    int randomIndex = 0;
    for (int index = 0; index < array.Length; index++)
    {
        randomIndex = new Random().Next(0, indexArray.Length);//Convert.ToDouble(new Random().Next(0, indexArray.Length));
        buffArray[index] = array[indexArray[randomIndex]];
        TryRemoveFromArray(ref indexArray, randomIndex);
    }
    return buffArray;
}

// Метод возведения в степень массива или выбранного элемента
double[] Exponentiation (double[] array, int degree, int index = -1)
{  
    double number = 0;
    if (index == -1)
    {
        if (degree == 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }
        }
        else
        {    
            for (int i = 0; i < array.Length; i++)
            {
                number = array[i];
                for (int count = 1; count < degree; count++)
                {
                    number *= array[i];
                }
                array[i] = number;
            }
        }
    }
    else 
    {
        number = array[index];
        for (int count = 1; count < degree; count++)
                {
                    number *= array[index];
                }
                array[index] = number;
    }
    return array;

}

// Метод извлечения корня из массива или выбранного элемента
double[] RootExtraction (double[] array, double degree, int index = -1)
{
    if (index == -1)
    {
    for (int i = 0; i < array.Length; i++)
        {
            array[i] = Math.Pow(array[i], 1 / degree); 
        }
    }
    else
    {
        array[index] = Math.Pow(array[index], 1 / degree);
    }
    return array;
}

Console.Clear();
string[] greetings = {"Вас приветствует программа для работы с массивами чисел.",
                     "Для начала работы нужно создать числовую последовательность."};
PrintStringArray(greetings);

string userNumbers = GetUserAnswer("Введите числа через пробел: ");
double[] userArray = SetNumbers(userNumbers);
int sumDigitOfNumbers = 0;

Console.WriteLine("Поздравляем, новый массив успешно создан.");
Numbers(userArray);


// Описание функционала программы
string[] functional = {"Функционал программы:",
                       "  1 - cоздать новый массив",
                       "  2 - Добавить новые элементы в созданный массив",
                       "  3 - Удалить элементы из созданного массива",
                       "  4 - Найти сумму всех чисел элементов массива",
                       "  5 - Перемешать элементы массива",
                       "  6 - Возводить в n степень определенный или все элементы массива",
                       "  7 - Извлекать корень n степени из определенного или всех элементов массива",
                       "  8 - Вывод массива",
                       "  Для выхода из программы введите Exit"};

Console.WriteLine();
PrintStringArray(functional);
string str;
double[] arguments;
while(true)
{
    
    string userAnswer = GetUserAnswer("Введите цифру или команду, для вывода описания функционала введите Help: ").ToLower();
    switch (userAnswer)
    {
        case "help": 
            PrintStringArray(functional);
            break;
        case "exit": 
            Console.Clear();
            return;
        default:
            int numberUserAnswer = Convert.ToInt16(userAnswer);
            switch (numberUserAnswer)
            {
                case 1: 
                    userNumbers = GetUserAnswer("Введите числа через пробел: ");
                    userArray = SetNumbers(userNumbers);
                    break;
                case 2:
                    userNumbers = GetUserAnswer("Введите через пробел числа которые вы хотите добавить: ");
                    userArray = AddNumbers(userArray, userNumbers);
                    break;
                case 3:
                    userNumbers = GetUserAnswer("Введите через пробел числа которые вы хотите удалить: ");
                    userArray = RemoveNumbers(userArray, userNumbers);
                    break;
                case 4:
                    sumDigitOfNumbers = Sum(userArray);
                    Console.WriteLine(sumDigitOfNumbers);
                    break;
                case 5:
                    userArray = Shuffle(userArray);
                    break;
                case 6:
                    Console.WriteLine();
                    Console.WriteLine("Если вы хотите возвести в степень какой-то элемент массива"
                    + " укажите его индекс через пробел например (2 3).");
                    Console.Write("Если хотите возвести ввесь массив в n степень просто введите степень: ");
                    str = Console.ReadLine() ?? "";
                    arguments = SetNumbers(str);
                    if (arguments.Length == 1)
                    {
                        userArray = Exponentiation(userArray, (int) arguments[0]);
                    }
                    else
                    {
                        userArray = Exponentiation(userArray, (int) arguments[0], (int) arguments[1]);
                    }
                    break;
                case 7:
                    Console.WriteLine();
                    Console.WriteLine("Если вы хотите извлечь корень n степени из какого-то элемента массива"
                    + " укажите степень корня и индекс элемента через пробел например (2 3).");
                    Console.Write("Если хотите извлечь корень n степени из всех элементов массива просто введите степень корня: ");
                    str = Console.ReadLine() ?? "";
                    arguments = SetNumbers(str);
                    if (arguments.Length == 1)
                    {
                        userArray = RootExtraction(userArray, (int) arguments[0]);
                    }
                    else
                    {
                        userArray = RootExtraction(userArray, (int) arguments[0], (int) arguments[1]);
                    }
                    break;
                case 8:
                    Numbers(userArray);
                    break;
                default:
                    Console.WriteLine("Введена не верная команда");
                    break;
            }
            if ( numberUserAnswer != 4 && numberUserAnswer != 8)
            {
                Numbers(userArray);
            }
            break;
    }
}
