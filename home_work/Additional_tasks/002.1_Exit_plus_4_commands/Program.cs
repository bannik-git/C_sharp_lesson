Console.WriteLine("Программа работает исправно");

string command1 = "Help",
       command2 = "SetName",
       command3 = "SetPassword",
       command4 = "WriteName",
       command5 = "Exit",
       help = "Список команд:",
       descriptionCommand2 = $" {command2} - установить имя",
       descriptionCommand3 = $" {command3} - установить пароль",
       descriptionCommand4 = $" {command4} - вывод установленного имени после ввода пароля",
       descriptionCommand5 = $" {command5} - выход из программы",
       userName = "",
       userPassword = "";

    Console.WriteLine("Чтобы узнать список команд введите Help");
while (true)
{   
    Console.Write("Введите команду: ");
    string userCommand = Console.ReadLine() ?? "";

    if (userCommand.ToLower() == command1.ToLower())
    {
        Console.WriteLine(help);
        Console.WriteLine(descriptionCommand2);
        Console.WriteLine(descriptionCommand3);
        Console.WriteLine(descriptionCommand4);
        Console.WriteLine(descriptionCommand5);
    } 
    else if (userCommand.ToLower() == command2.ToLower())
    {
        Console.Write("Введите Ваше имя: ");
        userName = Console.ReadLine() ?? "";
    }
    else if (userCommand.ToLower() == command3.ToLower())
    {
        if (userPassword == "")
        {
            Console.Write("Введите новый пароль: ");
            userPassword = Console.ReadLine() ?? "";
        }
        else
        {
            Console.Write("Введите старый пароль: ");
            string oldUserPassword = Console.ReadLine() ?? "";
            if (userPassword == oldUserPassword)
            {
                Console.Write("Введите новый пароль: ");
                userPassword = Console.ReadLine() ?? "";
            }
            else
            {
                Console.WriteLine("Неверный пароль");
            }
        }
    }
    else if (userCommand.ToLower() == command4.ToLower())
    {
        Console.Write("Чтоб получить доступ к имени пользователя введите пароль: ");
        string passwordResponse = Console.ReadLine() ?? "";
        if (userPassword == passwordResponse && userName == "")
        {
            Console.WriteLine("Имя пользователя не установлено." +
            $"Для того чтоб установить имя пользователю введите команду {command2}");
        } 
        else if (userPassword == passwordResponse)
        {
            Console.WriteLine($"Имя пользователя: {userName}");
        }
        else
        {
            Console.WriteLine("Неверный пароль");
        }
    }
    else if (userCommand.ToLower() == command5.ToLower())
    {
        break;
    }
    else
    {
        Console.WriteLine("Такой команды нет." +
        $"Для получения списка команд введите {command1}");
    }
}
