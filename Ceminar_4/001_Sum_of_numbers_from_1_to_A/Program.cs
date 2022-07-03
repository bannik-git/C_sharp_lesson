Console.Write("Введите число А: ");
int userNumber = Convert.ToInt32(Console.ReadLine()),
    sum = 0;

for (int i = 1; i <= userNumber; i++)
{
    sum+= i;
}
Console.WriteLine(sum);