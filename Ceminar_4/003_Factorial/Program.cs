Console.Write("Введите число: ");
int userNumber = Convert.ToInt32(Console.ReadLine());
int factorial = 1;

if (userNumber >= 0)
{
    for (int count = 1; userNumber >= count; count++)
    {
        factorial *= count;
    }
    Console.WriteLine(factorial);
}
else 
{
    Console.WriteLine("Необходимо ввести положительное число");
}
