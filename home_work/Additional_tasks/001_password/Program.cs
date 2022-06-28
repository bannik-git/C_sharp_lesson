string secretMessage = "Пельмени надо варить 2 минуты после всплытия",
    password = "password";

int count = 0,
    maxAttemp = 3;

Console.WriteLine($"У вас будет {maxAttemp} попытки чтобы ввести пароль.");

while (count < maxAttemp)
{
    Console.Write($"Попытка №{count + 1}: ");
    string userPassword = Console.ReadLine() ?? "";

    if (userPassword == password)
    {
        Console.WriteLine($"Секретное сообщение: {secretMessage}");
        break; // выход из цикла, завершение программы.
    }    
   else
   {
        Console.WriteLine("Неверный пароль");
        count++;
   }
}

if (count == maxAttemp)
{
    Console.WriteLine("Вы исчерпали все попытки.");
}
