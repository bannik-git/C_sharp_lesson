int GetNumber (string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int SumDigitOfNumber (int number)
{
    if (number / 10 == 0)
        return number;
    return SumDigitOfNumber(number/10) + number % 10;
}

// 1234 = 123 = 12 = 1
int number = GetNumber("Введите число: ");
Console.WriteLine(SumDigitOfNumber(number));