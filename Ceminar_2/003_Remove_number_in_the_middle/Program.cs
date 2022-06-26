// Console.Write("Введите трех значное число: ");
// int userNumber = Convert.ToInt32(Console.ReadLine());

int randomNumber = new Random().Next(100, 1000);

Console.WriteLine(randomNumber);

int number1 = randomNumber / 100;
int number3 = randomNumber % 10;

// Если нужно число:
// int result = number1*10 + number3;
// Console.WriteLine(result);

Console.WriteLine($"{number1}{number3}");


