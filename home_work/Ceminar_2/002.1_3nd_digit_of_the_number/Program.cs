// Альтернативное решение в папке 002.2

// предельное значение int32 (-2 147 483 648 : 2 147 483 648)
Console.Write("Введите число от -2 147 483 647 до 2 147 483 647: ");
int userNumber = Convert.ToInt32(Console.ReadLine());

if (-99 <= userNumber && userNumber <= 99) //[-99:99]
{
    Console.WriteLine("Третьей цифры нет");
}
else if (-999 <= userNumber && userNumber <= 999) 
 // трехзначное число, в данном исполнении соотуствует [-999:-100] [100:999] 
 {
    Console.WriteLine(Math.Abs(userNumber % 10)); 
    // Math.Abs() - модуль числа, для ухода от проверки числа на отрицательность.
}
else if (-9999 <= userNumber && userNumber <= 9999) 
// четырехзначное число. [-9999:-1000] и [1000:9999]
// иначе сработают предыдущие пункты.
{
    Console.WriteLine(Math.Abs(userNumber % 100 / 10)); 
}
else if (-99999 <= userNumber && userNumber <= 99999) 
// пятизначное число. [-99999:-10000] и [10000:99999] 
// иначе сработают предыдущие пункты.
{
    Console.WriteLine(Math.Abs(userNumber % 1000 / 100)); 
}
else if (-999999 <= userNumber && userNumber <= 999999) 
// шестизначное число. [-999999:-100000] и [100000:999999] 
// иначе сработают предыдущие пункты.
{
    Console.WriteLine(Math.Abs(userNumber % 10000 / 1000)); 
}
else if (-9999999 <= userNumber && userNumber <= 9999999) 
// семизначное число. 
{
    Console.WriteLine(Math.Abs(userNumber % 100000 / 10000)); 
}
else if (-99999999 <= userNumber && userNumber <= 99999999) 
// восьмизначное число.
{
    Console.WriteLine(Math.Abs(userNumber % 1000000 / 100000)); 
}
else if (-999999999 <= userNumber && userNumber <= 999999999) 
// девятизначное число.
{
    Console.WriteLine(Math.Abs(userNumber % 10000000 / 1000000)); 
}
else if (-2147483647 <= userNumber && userNumber <= 2147483647) 
// предельное значение int32
{
    Console.WriteLine(Math.Abs(userNumber % 100000000 / 10000000)); 
}
