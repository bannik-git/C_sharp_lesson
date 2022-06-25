Console.Write("Введите число больше 0: ");
int userNumber = Convert.ToInt32(Console.ReadLine()),
    count = - userNumber;

while (count <= userNumber)
{
    Console.Write(count++ + ", ");
}
