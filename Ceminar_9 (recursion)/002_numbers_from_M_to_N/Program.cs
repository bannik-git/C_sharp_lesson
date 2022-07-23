int GetNumber (string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int NaturalNumber(int a, int b)
{
    int max = b,
        min = a;
    if (min > max)
    {
        max = a;
        min = b;
    }
    if (min == max)
        return min;
    else
        Console.Write(NaturalNumber(max -1, min) + ", ");
    return max;
}

int a = GetNumber("Введите число M: "),
    b = GetNumber("Введите число N: ");

Console.WriteLine(NaturalNumber(a, b));
