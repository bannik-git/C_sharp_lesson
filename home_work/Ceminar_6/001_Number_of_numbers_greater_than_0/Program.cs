// Запрос последовательности чисел
string GetUserAnswer (string text)
{
    Console.Write(text);
    string userNumber = Console.ReadLine() ?? "";
    return userNumber;
}

// Вспомогательная метод преобразующая строку в массив
int[] GetArray (int[] array, string userString)
{
    string result = String.Empty;
    int startIndex = 0;
    for (int index = 0; index < userString.Length; index++)
    {   
        if (userString[index] != ' ' && userString[index] != ',')
        {
            result += userString[index];
        }
        if ((userString[index] == ' ' || userString[index] == ',') && result != String.Empty)
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
int GetNumberOfCommas (string stringWithNumbers)
{
    int space = 0;

    for (int count = 0; count < stringWithNumbers.Length; count++)
    {
        if (stringWithNumbers[count] == ',' && count != stringWithNumbers.Length - 1)
        {
            space += 1;
        }
    }
    return space;
}

//Метод получения готового массива из строки пользователя
int[] SetNumbers (string userString)
{   
    int[] array = new int [GetNumberOfCommas(userString) + 1];
    array = GetArray(array, userString);
    return array;
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
    Console.WriteLine();
}

string userNumericalSequence = GetUserAnswer("Введите последовательность чисел разделнных запятой: ");
int[] userArray = SetNumbers(userNumericalSequence);
Numbers(userArray);
int count = 0;
for (int i = 0; i < userArray.Length; i++)
{
    if (userArray[i] >= 0)
    {
        count++;
    }
}
Console.WriteLine($"Количество числе больше 0 равно {count}");

