Console.Write("Введите трехзначное число: ");
int userNumber = Convert.ToInt32(Console.ReadLine());

int number2nd = userNumber % 100 / 10;

Console.WriteLine($"{number2nd} - вторая цифра в числе {userNumber}");