Console.Write("Введите цифру дня недели (1-7): ");
int userDay = Convert.ToInt32(Console.ReadLine());

int saturday = 6,
    sunday = 7;

if (userDay == saturday || userDay == sunday)
{
    Console.WriteLine("Выходной день.");
}
else if (userDay > 7)
{
    Console.WriteLine("В неделе только 7 дней!");
}
else
{
    Console.WriteLine("Не выходной день.");
}


