int GetNumber (string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int Exponentiation (int number, int degree)
{
    if (degree == 0)
        return 1;
    return Exponentiation(number, degree -1) * number;
}

int number = GetNumber("Введите число: "),
    degree = GetNumber("Введите степень: ");

Console.WriteLine($"{number} ^ {degree} = {Exponentiation(number, degree)}");
