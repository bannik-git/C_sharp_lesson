int GetNumber (string text)
{
    Console.Write(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int Exponentiation(int number, int degree)
{
    int result = number;
    for (int count = 1; count < degree; count++)
    {
        result *= number;
        // Console.WriteLine(number);
    }
    return result;
}

int userNumber = GetNumber("Ведите число: ");
int degree = GetNumber("Введите степень: ");

int result = Exponentiation(userNumber, degree);

Console.WriteLine(result);
