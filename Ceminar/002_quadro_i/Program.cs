Console.Write("Введите число 1 ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число 2 ");
int b = Convert.ToInt32(Console.ReadLine());

if (a*a == b) // (b/a == a)
{
    Console.WriteLine("Да");
}
else
{
    Console.WriteLine("Нет");
}