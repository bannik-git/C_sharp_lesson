Console.Write("Введите число: ");
int userNumber = Convert.ToInt32(Console.ReadLine()),
    count = 0;

while (userNumber > 0)
{
    userNumber /= 10;
    count++;
}
Console.WriteLine(count);
