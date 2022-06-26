Console.Write("Введите число: ");
int userNumber = Convert.ToInt32(Console.ReadLine());
int divider1 = 7,
    divider2 = 23;
if (userNumber%divider1 ==0 && userNumber%divider2 == 0)
{
    Console.WriteLine($"{userNumber} -> да"); //14 -> нет ,46 -> нет, 161 -> да
}
else
{
    Console.WriteLine($"{userNumber} -> нет");
}