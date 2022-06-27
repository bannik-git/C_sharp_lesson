Console.Write("Введите число: ");
int userNumber1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите число: ");
int userNumber2 = Convert.ToInt32(Console.ReadLine());

// Вариант 3

if ((userNumber1 == userNumber2 * userNumber2) || (userNumber2 == userNumber1 * userNumber1))
{
    Console.WriteLine($"{userNumber1}, {userNumber2} -> да");
}
else
{
    Console.WriteLine($"{userNumber1}, {userNumber2} -> нет");
}




// Вариант 2

// if (userNumber1 > userNumber2 && userNumber1 == userNumber2*userNumber2)
// {
//     Console.WriteLine($"{userNumber1}, {userNumber2} -> да");
// }
// else if (userNumber1 < userNumber2 && userNumber2 == userNumber1*userNumber1)
// {
//     Console.WriteLine($"{userNumber1}, {userNumber2} -> да");
// }
// else
// {
//     Console.WriteLine($"{userNumber1}, {userNumber2} -> нет");
// }


// Вариант 1

//     // if (userNumber1 == userNumber2*userNumber2)
//     // {
//         Console.WriteLine($"{userNumber1}, {userNumber2} -> да");
//     }
//     else
//     {
//         Console.WriteLine($"{userNumber1}, {userNumber2} -> нет");
//     }
// }
// else
// {
//     if (userNumber2 == userNumber1*userNumber1)
//     {
//         Console.WriteLine($"{userNumber1}, {userNumber2} -> да");
//     }
//     else
//     {
//         Console.WriteLine($"{userNumber1}, {userNumber2} -> нет");
//     }
// }

