// y = k1 * x + b1, 
// y = k2 * x + b2; 
// k1 * x + b1 = k2 * x + b2 -> k1*x - k2*x = b2 - b1 -> x(k1-k2) = (b2-b1) -> 
// x = (b2-b1) / (k1-k2)

double GetNumber (string str)
{
    Console.Write(str);
    return Convert.ToDouble(Console.ReadLine());
}
	
double k1 = GetNumber("Введите k1: "),
       k2 = GetNumber("Введите k2: "),
       b1 = GetNumber("Введите b1: "),
       b2 = GetNumber("Введите b2: "),
       coordinatX = 0, // (b2 - b1) / (k1 - k2),
       coordinatY = 0; // k1 * coordinatX + b1;

if (k1 - k2 == 0)
{
    if (b1 - b2 == 0)
    {
        Console.WriteLine("Прямые совпадают(накладываются друг на друга)");
    }
    else
    {
        Console.WriteLine("Прямые паралельны");
    }
}
else 
{
    coordinatX = (b2 - b1) / (k1 - k2);
    coordinatY = k1 * coordinatX + b1;
    Console.WriteLine($"Координаты точки пересечения двух прямых ({coordinatX}, {coordinatY})");
}

