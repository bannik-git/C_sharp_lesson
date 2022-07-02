while (true)
{
    Console.Clear();
    int x = IntutInt ("Введите X: ");
    int y = IntutInt ("Введите Y: ");

    if (x == 0 || y ==0)
    {
        Console.WriteLine("X и Y не должны быть равны 0");
        Console.ReadKey();
        continue;
    }
    if (x > 0 && y > 0)
    {
        Console.WriteLine("1 четверть");
    }
    else if (x > 0 && y < 0)
    {
        Console.WriteLine("2 четверть");
    }
    else if (x < 0 && y < 0)
    {
        Console.WriteLine("3 четверть");
    }
    else if (x < 0 && y > 0)
    {
        Console.WriteLine("4 четверть");
    }
    break;
}

int IntutInt(string output)
{
    Console.Write(output);
    return Convert.ToInt32(Console.ReadLine());
}
