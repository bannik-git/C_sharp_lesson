bool answer = true;
while (answer)
{
Console.Write("Введите трехзначное число: ");
int userNumber = Convert.ToInt32(Console.ReadLine()); // 456
int lastNumber = userNumber % 10;


    if (userNumber > 99 & userNumber < 1000) // userNumber: [100:999]
    {
        Console.Write(lastNumber);
        answer = false;
    }
    else
    {
    Console.WriteLine("Вы ввели не трехзначное число.");
  
    }
}