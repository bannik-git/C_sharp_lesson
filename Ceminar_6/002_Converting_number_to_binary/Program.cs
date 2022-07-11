int GetNumber (string question)
{
    Console.Write(question);
    return Convert.ToInt32(Console.ReadLine());
}

string GetNumberBinary (int number)
{
    string result = String.Empty;
    while (number >= 1) // 45/2 = 22 ост 1, 22/2 11 ост 0, 11/2=5 ост 1, 5/2=2 ост 1, 2/2=1 ост 0  
    {
        result = number%2 + " " + result;
        number /= 2;
    }
    return result;
}

int userNumber = GetNumber("Введите число: ");
Console.WriteLine($"{userNumber} = {GetNumberBinary(userNumber)}");
