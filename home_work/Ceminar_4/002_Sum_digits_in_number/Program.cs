Console.Write($"Введите число от 1 до {int.MaxValue}: ");
string number = Console.ReadLine() ?? "";
int userNumber = Convert.ToInt32(number),
    result = 0;

for (int count = 0; count < number.Length; count++)
{
    result += userNumber % 10;
    userNumber /= 10;
}

Console.WriteLine(result);