Console.WriteLine("Программа работает исправно");

string commandHelp = "Help",
       setNameCommand = "SetName",
       setPasswordCommand = "SetPassword",
       writeNameCommand = "WriteName",
       commandExit = "Exit",
       help = "Список команд:",
       descriptionSetNameCommand = $" {setNameCommand} - установить имя",
       descriptionSetPasswordCommand = $" {setPasswordCommand} - установить пароль",
       descriptionWriteNameCommand = $" {writeNameCommand} - вывод установленного имени после ввода пароля",
       descriptionCommandExit = $" {commandExit} - выход из программы",
       userName = "",
       userPassword = "";

    Console.WriteLine("Чтобы узнать список команд введите Help");
while (true)
{   
    Console.Write("Введите команду: ");
    string userCommand = Console.ReadLine() ?? "";
        userCommand = userCommand.ToLower();
    if (userCommand == commandHelp.ToLower())
    {
        Console.WriteLine(help);
        Console.WriteLine(descriptionSetNameCommand);
        Console.WriteLine(descriptionSetPasswordCommand);
        Console.WriteLine(descriptionWriteNameCommand);
        Console.WriteLine(descriptionCommandExit);
    } 
    else if (userCommand == setNameCommand.ToLower())
    {
        Console.Write("Введите Ваше имя: ");
        userName = Console.ReadLine() ?? "";
    }
    else if (userCommand == setPasswordCommand.ToLower())
    {
        if (userName != "")
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
        else
        {
            Console.WriteLine($"Сначала нужно ввести имя. Для этого воспользуйтесь командой {setNameCommand}.");
        }
    }
    else if (userCommand == writeNameCommand.ToLower())
    {
        Console.Write("Чтоб получить доступ к имени пользователя введите пароль: ");
        string passwordResponse = Console.ReadLine() ?? "";
        if (userPassword == passwordResponse && userName == "")
        {
            Console.WriteLine("Имя пользователя не установлено." +
            $"Для того чтоб установить имя пользователю введите команду {setNameCommand}");
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
    else if (userCommand == commandExit.ToLower())
    {
        break;
    }
    else
    {
        Console.WriteLine("Такой команды нет." +
        $"Для получения списка команд введите {commandHelp}");
    }
}
