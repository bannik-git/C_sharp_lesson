Console.Write("Введите число: ");

string userNumber_string = Console.ReadLine();
int userNumber = Convert.ToInt32(userNumber_string);
int size = userNumber_string.Length; // находим длину строки, понимаем скольки значное число

if (userNumber < 0)
{
    size = size - 1; // в случае если число отрицательное убираем влияние знака "-"
}

if (size <= 2) // если size <= 2 число может быть максимум двухзначное.
{
    Console.WriteLine("Третьей цифры нет");
} 
else
{
    int count = 0,
        number_for_remainder = 1, // число для нахождения остатка 
        divider = 1; // число на которое будет делится остаток

    while (count < size - 2) // size - 2 для начала сразу с 3х значных чисел.
    {
        if (count == 0)
        {
            number_for_remainder *= 10;
        }
        else
        {
            number_for_remainder *= 10;
            divider *= 10;
        }
        count++;
    }
    Console.WriteLine(Math.Abs(userNumber % number_for_remainder / divider));
}