Console.Write("Введите число №1: ");
int number1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число №2: ");
int number2 = Convert.ToInt32(Console.ReadLine());

if (number1 > number2)
{
    Console.WriteLine("max = " + number1);
}
else if (number1 == number2)
{
    Console.WriteLine("max = " + number1);
}
else
{
    Console.WriteLine("max = " + number2);
}