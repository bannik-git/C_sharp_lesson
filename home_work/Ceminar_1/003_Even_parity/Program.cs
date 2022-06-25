Console.Write("Введите число: ");
int userNumber = Convert.ToInt32(Console.ReadLine());

if (userNumber % 2 ==0)
{
    Console.WriteLine("Число " + userNumber + " четное.");
}
else
{
    Console.WriteLine("Число " + userNumber + " нечетное.");
}