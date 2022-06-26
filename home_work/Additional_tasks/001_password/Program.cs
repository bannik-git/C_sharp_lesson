string secret_message = "Пельмени надо варить 2 минуты после всплытия",
    password = "password";

int count = 0,
    max_attemp = 3;

Console.WriteLine($"У вас будет {max_attemp} попытки чтобы ввести пароль.");

while (count < max_attemp)
{
    Console.Write($"Попытка №{count + 1}: ");
    string userPassword = Console.ReadLine();

    if (userPassword == password)
    {
        Console.WriteLine($"Секретное сообщение: {secret_message}");
        break; // выход из цикла, завершение программы.
    }    
   else
   {
        Console.WriteLine("Неверный пароль");
        count++;
   }
}

if (count == max_attemp)
{
    Console.WriteLine("Вы исчерпали все попытки.");
}
