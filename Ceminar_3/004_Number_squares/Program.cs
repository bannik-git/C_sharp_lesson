﻿Console.Write("Введите число: ");
int userNumber = Convert.ToInt32(Console.ReadLine()),
count = 1;
string result = "";

while (count <= userNumber)
{
    result += count * count;
    if (count != userNumber)
    {
    result += ", "; // result = result + count * count + ", ";
    }
    count++;
}

Console.WriteLine(result);