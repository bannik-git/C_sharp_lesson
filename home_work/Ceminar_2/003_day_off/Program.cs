Console.Write("Введите цифру дня недели (1-7): ");
int userDay = Convert.ToInt32(Console.ReadLine());

int saturday = 6,
    sunday = 7;

if (userDay == saturday || userDay == sunday)
{
    Console.WriteLine("Выходной день.");
}
else if (userDay > 7 || userDay <= 0)
{
    Console.WriteLine("В следующий раз используйте только цифры от 1 до 7!");
}
else
{
    Console.WriteLine("Не выходной день.");
}


