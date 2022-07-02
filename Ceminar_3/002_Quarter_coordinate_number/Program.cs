while (true)
{
    Console.Clear();
    int numberQuarter = IntutInt("Введите № четверти ");

    if (numberQuarter > 0 && numberQuarter < 4)
    {
        if (numberQuarter == 1)
        {
            Console.WriteLine($"X и Y - от 0 до {int.MaxValue}");
        }
        else if (numberQuarter == 2)
        {
            Console.WriteLine($"X - от {int.MinValue} до 0, Y - от 0 до {int.MaxValue}");
        }
        else if (numberQuarter == 3)
        {
            Console.WriteLine($"X и Y - от {int.MinValue} до 0");
        }
        else if (numberQuarter == 4)
        {
            Console.WriteLine($"X - от 0 до {int.MaxValue}, Y - от {int.MinValue} до 0");
        }
    }
    else
    {
        Console.WriteLine("В координатах всего 4 четверти!");
    }
    break;
}

int IntutInt(string output)
{
    Console.Write(output);
    return Convert.ToInt32(Console.ReadLine());
}
