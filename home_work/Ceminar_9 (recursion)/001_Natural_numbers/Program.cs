int GetNumber (string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int PrintNumber (int number1, int number2)
{
    int max = number1,
        min = number2;    
    if (min > max)
    {
        max = number2;
        min = number1;
    }
    if (min != max)
    {
        Console.Write(PrintNumber(max - 1, min) + ", ");
        return max;
    }
    return min;
}

int number1 = GetNumber("Введите число №1: "),
    number2 = GetNumber("Введите число №2: ");

Console.Write(PrintNumber(number1, number2));
