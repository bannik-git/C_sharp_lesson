int GetCoordinate (string coordinate)
{
    Console.Write(coordinate);
    return Convert.ToInt32(Console.ReadLine());
}
int NumberSquare (int number)
{
    int square = number * number;
    return square;
}
Console.WriteLine("Первая координата:");
int x1 = GetCoordinate("Введите координуту Х: "),
    y1 = GetCoordinate("Введите координуту Y: "),
    z1 = GetCoordinate("Введите координуту Z: ");

Console.WriteLine();
Console.WriteLine("Вторая координата:");
int x2 = GetCoordinate("Введите координуту Х: "),
    y2 = GetCoordinate("Введите координуту Y: "),
    z2 = GetCoordinate("Введите координуту Z: ");

int distanceX = x1 - x2,
    distanceY = y1 - y2,
    distanceZ = z1 - z2;

double result = Math.Sqrt(NumberSquare(distanceX) + NumberSquare(distanceY) + NumberSquare(distanceZ));
Console.WriteLine($"Расстояние между точками А ({x1}, {y1}, {z1})"
                + $"и B ({x2}, {y2}, {z2}) равно {Math.Round(result, 2)}");