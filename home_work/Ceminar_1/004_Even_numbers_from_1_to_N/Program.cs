Console.Write("Введите число больше 1: ");
int userNumber = Convert.ToInt32(Console.ReadLine()),
    count = 1;

if (userNumber < 1)
{
    Console.WriteLine("Вы ввели неверное число");
}
else if (userNumber == 1)
{
    Console.WriteLine("Четных чисел нет");
}
else
{
    while (count <= userNumber)
    {
        if (count%2 == 0)
        {
            if ((userNumber - count) == 1)
            {
                Console.Write(count);
                count+=2;
            }
            else if ((userNumber - count) == 0)
            {
                Console.Write(count);
                count+=2;
            }
            else
            {
                Console.Write(count + ", ");
                count+=2;                
            }
        }
        else
        {
            count++;
        }
    }

}
