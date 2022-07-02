// Определить является ли пятизначное число палиндромом

Console.Write("Введите пятизначное число: ");
int fiveDigitNumber = Convert.ToInt16(Console.ReadLine()),
    firstDigit = fiveDigitNumber / 10000,
    secondDigit = fiveDigitNumber % 10000 / 1000,
    penultimateDigit = fiveDigitNumber % 100 / 10,
    lastDigit = fiveDigitNumber % 10;
    
if (fiveDigitNumber >= 10000 && fiveDigitNumber <100000)
{
    if (firstDigit == lastDigit && secondDigit == penultimateDigit)
    {
        Console.WriteLine("Число является палиндромом");
    }
    else
    {
        Console.WriteLine("Число не является палиндромом");
    }
}
else
{
    Console.WriteLine("Вы ввели неверное число");
}
// Решение с использованием строк 
// Console.Write("Введите пятизначное число: ");
// string number = Console.ReadLine() ?? ""; // ухожу от ошибки Null
// if (number.Length == 5)
// {
//     if (number[0] == number[4] && number[1] == number[3])
//     {
//         Console.WriteLine("Число является палиндромом");
//     }
//     else
//     {
//         Console.WriteLine("Число не является палиндромом");
//     }
// }
// else 
// {
//     Console.WriteLine("Вы ввели неверное число");
// }
