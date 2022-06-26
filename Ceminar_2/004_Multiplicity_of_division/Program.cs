Console.Write("Введите число 1: ");
int userNumber1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число 2: ");
int userNumber2 = Convert.ToInt32(Console.ReadLine());

// int randomNumber = new Random().Next(100, 1000);
// int randomNumber = new Random().Next(100, 1000);

if (userNumber1 % userNumber2 == 0)
{
    Console.WriteLine("Кратно");
}
else
{
    Console.WriteLine($"Не кратно, остаток {userNumber1 % userNumber2}");
}