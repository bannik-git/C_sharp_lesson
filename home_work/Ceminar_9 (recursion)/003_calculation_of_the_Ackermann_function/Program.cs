int GetNumber (string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int AckermannFunction (int m, int n)
{
    if (m == 0)
        return n + 1;
    else if (m > 0 && n == 0)
        return AckermannFunction(m - 1, 1);
    else
        return AckermannFunction(m - 1, AckermannFunction(m, n-1)); 
}

int number1 = GetNumber("Введите число №1: "),
    number2 = GetNumber("Введите число №2: ");

Console.Write(AckermannFunction(number1, number2));
