int GetCoordinate(string coordinate)
{
    Console.Write(coordinate);
    return Convert.ToInt32(Console.ReadLine());
}
int х1 = GetCoordinate("Введите координуту Х первой точки: ");
int y1 = GetCoordinate("Введите координуту Y первой точки: ");
int x2 = GetCoordinate("Введите координуту Х второй точки: ");
int y2 = GetCoordinate("Введите координуту Y второй точки: ");
double result = Math.Sqrt((х1-x2)*(х1 -x2) + (y1-y2)*(y1 -y2));
Console.WriteLine(result);
// Console.Write("Введите координуту Х первой точки: ");
// int х1 = Convert.ToInt32(Console.ReadLine());
// Console.Write("Введите координуту Y первой точки: ");
// int y1 = Convert.ToInt32(Console.ReadLine());
// Console.Write("Введите координуту Х второй точки: ");
// int x2 = Convert.ToInt32(Console.ReadLine());
// Console.Write("Введите координуту Y второй точки: ");
// int y2 = Convert.ToInt32(Console.ReadLine());