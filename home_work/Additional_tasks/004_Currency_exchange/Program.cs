string rub = "RUB", //рубль
    usd = "USD", //Доллар
    eur = "EUR", //Евро
    gbr = "GBR", //Фунт Стерлингов
    jpy = "JPY", //Иена
    cny = "CNY", //Юань
    userСurrency = "";
    

double volumeRub = 22300, 
    volumeUsd = 2400, 
    volumeEur = 658, 
    volumeGbr = 347, 
    volumeJpy = 900,
    volumeCny = 467,
    volume = 0;

// курс на 28.06.2022г сайт https://www.banki.ru/products/currency/cb/
double exchangeRateUsdToRub = 53.3641, // 1 доллар = 53.3641
    exchangeRateEurToRub = 56.0535,
    exchangeRateGbrToRub = 65.5738,
    exchangeRateJpyToRub = 0.396464,
    exchangeRateCnyToRub = 8.04837;


string command1 = "Help", 
    command2 = "Swap", // Обмен 
    command3 = "TopUp", // пополнение 
    command4 = "Withdraw", //снять деньги
    command5 = "Balance",
    command6 = "Exit",
    help = "Список команд: ",
    descriptionCommand2 = $"{command2} - обмен валют",
    descriptionCommand3 = $"{command3} - пополнение валютного счета",
    descriptionCommand4 = $"{command4} - вывод средств",
    descriptionCommand5 = $"{command5} - вывести текущий баланса",
    descriptionCommand6 = $"{command6} - выход";


Console.WriteLine("Вас приветствует программа по управлению валютами." +
    "Для получения списка команд введите Help");


Console.WriteLine("Введите названия валюты для обмена: ");

while (true)
{
    Console.Write("Введите команду: ");
    string userCommand = Console.ReadLine() ?? "";
    if (userCommand.ToLower() == command1.ToLower())
    {
        Console.WriteLine(help);
        Console.WriteLine(" " + descriptionCommand2);
        Console.WriteLine(" " + descriptionCommand3);
        Console.WriteLine(" " + descriptionCommand4);
        Console.WriteLine(" " + descriptionCommand5);
        Console.WriteLine(" " + descriptionCommand6);
    } 
    else if (userCommand.ToLower() == command2.ToLower())
    {
        Console.WriteLine("Сначала введите название валюты которую хотите поменять," +
        "потом вводите валюту в которую хотите перевести");
        Console.Write("Введите названия валюты для обмена: ");
        string currencyForExchange1 = Console.ReadLine() ?? "";
        Console.Write("Введите нужную валюту для обмена: ");
        string currencyForExchange2 = Console.ReadLine() ?? "";
        Console.Write("Введите сумму: ");
        string volumeText = Console.ReadLine() ?? "";
        
        if (volumeText != "" || Convert.ToInt32(volumeText) != 0)
        {
           volume = Convert.ToInt32(volumeText);

            // rub -> dollar    
            if (rub.ToLower() == currencyForExchange1.ToLower())
            {
                if (volumeRub >= volume)
                {
                    volumeRub -= volume;
                    
                    if (usd.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeUsd += volume / exchangeRateUsdToRub;
                    }
                    else if (eur.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeEur += volume / exchangeRateEurToRub;
                    }
                    else if (gbr.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeGbr += volume / exchangeRateGbrToRub;
                    }
                    else if (jpy.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeJpy += volume / exchangeRateJpyToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeCny += volume / exchangeRateCnyToRub;
                    }
                }
                else
                {
                    Console.WriteLine("Ваш баланс не достаточен для данной операции");
                }
                
            }
            // usd -> rub
            else if (usd.ToLower() == currencyForExchange1.ToLower())
            {
                if (volumeUsd >= volume)
                {
                    volumeUsd -= volume;
                                    
                    if (rub.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeRub += volume * exchangeRateUsdToRub;
                    }
                    else if (eur.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeEur += volume * exchangeRateUsdToRub / exchangeRateEurToRub;
                    }
                    else if (gbr.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeGbr += volume * exchangeRateUsdToRub / exchangeRateGbrToRub;
                    }
                    else if (jpy.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeJpy += volume * exchangeRateUsdToRub / exchangeRateJpyToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeCny += volume * exchangeRateUsdToRub / exchangeRateCnyToRub;
                    }
                }
                else
                {
                    Console.WriteLine("Ваш баланс не достаточен для данной операции");
                }
            }
            // eur -> rub
            else if (eur.ToLower() == currencyForExchange1.ToLower())
            {
                if (volumeEur >= volume)
                {
                    volumeEur -= volume;
                                
                    if (rub.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeRub += volume * exchangeRateEurToRub;
                    }
                    else if (usd.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeUsd += volume * exchangeRateEurToRub / exchangeRateUsdToRub;
                    }
                    else if (gbr.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeGbr += volume * exchangeRateEurToRub / exchangeRateGbrToRub;
                    }
                    else if (jpy.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeJpy += volume * exchangeRateEurToRub / exchangeRateJpyToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeCny += volume * exchangeRateEurToRub / exchangeRateCnyToRub;
                    }
                }
                else
                {
                    Console.WriteLine("Ваш баланс не достаточен для данной операции");
                }
            }
            // Gbr -> rub
            else if (gbr.ToLower() == currencyForExchange1.ToLower())
            {
                if (volumeGbr >= volume)
                {
                    volumeGbr -= volume;
                
                    if (rub.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeRub += volume * exchangeRateGbrToRub;
                    }
                    else if (usd.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeUsd += volume * exchangeRateGbrToRub / exchangeRateUsdToRub;
                    }
                    else if (eur.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeEur += volume * exchangeRateGbrToRub / exchangeRateEurToRub;
                    }
                    else if (jpy.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeJpy += volume * exchangeRateGbrToRub / exchangeRateJpyToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeCny += volume * exchangeRateGbrToRub / exchangeRateCnyToRub;
                    }
                }
                else
                {
                    Console.WriteLine("Ваш баланс не достаточен для данной операции");
                }
            }
            // jpy -> rub
            else if (jpy.ToLower() == currencyForExchange1.ToLower())
            {
                if (volumeRub >= volume)
                {
                    volumeJpy -= volume;
                
                    if (rub.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeRub += volume * exchangeRateJpyToRub;
                    }
                    else if (usd.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeUsd += volume * exchangeRateJpyToRub / exchangeRateUsdToRub;
                    }
                    else if (eur.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeEur += volume * exchangeRateJpyToRub / exchangeRateEurToRub;
                    }
                    else if (gbr.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeGbr += volume * exchangeRateJpyToRub / exchangeRateGbrToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeCny += volume * exchangeRateJpyToRub / exchangeRateCnyToRub;
                    }
                }
                else
                {
                    Console.WriteLine("Ваш баланс не достаточен для данной операции");
                }
            }
            // cny -> rub
            else if (cny.ToLower() == currencyForExchange1.ToLower())
            {
                if (volumeCny >= volume)
                {
                    volumeCny -= volume;
                                
                    if (rub.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeRub += volume * exchangeRateCnyToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange1.ToLower() && usd.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeUsd += volume * exchangeRateCnyToRub / exchangeRateUsdToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange1.ToLower() && eur.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeEur += volume * exchangeRateCnyToRub / exchangeRateEurToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange1.ToLower() && gbr.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeGbr += volume * exchangeRateCnyToRub / exchangeRateGbrToRub;
                    }
                    else if (cny.ToLower() == currencyForExchange1.ToLower() && jpy.ToLower() == currencyForExchange2.ToLower())
                    {
                        volumeJpy += volume * exchangeRateCnyToRub / exchangeRateJpyToRub;
                    }
                }
                else
                {
                    Console.WriteLine("Ваш баланс не достаточен для данной операции");
                }
            }
            

        }
    }
    else if (userCommand.ToLower() == command3.ToLower())
    {
        Console.Write("Введите валюту объем которой которой Вы хотите пополнить: ");
        userСurrency = Console.ReadLine() ?? "";
                
        if (userСurrency != "" )
        {
            Console.Write("Введите сумму: ");
            volume = Convert.ToInt32(Console.ReadLine());

            if (volume != 0)
            {
                if (userСurrency.ToLower() == rub.ToLower())
                {
                    volumeRub += volume;
                }
                else if (userСurrency.ToLower() == usd.ToLower())
                {
                    volumeUsd += volume;
                }
                else if (userСurrency.ToLower() == eur.ToLower())
                {
                    volumeEur += volume;
                }
                else if (userСurrency.ToLower() == gbr.ToLower())
                {
                    volumeGbr += volume;
                }
                else if (userСurrency.ToLower() == jpy.ToLower())
                {
                    volumeJpy += volume;
                }
                else if (userСurrency.ToLower() == cny.ToLower())
                {
                    volumeCny += volume;
                }
            }
        }
        
    }
    else if (userCommand.ToLower() == command4.ToLower())
    {
        Console.Write("Введите валюту которую Вы хотите снять: ");
        userСurrency = Console.ReadLine() ?? "";
                
        if (userСurrency != "" )
        {
            Console.Write("Введите сумму: ");
            volume = Convert.ToInt32(Console.ReadLine());

            if (volume != 0)
            {
                if (userСurrency.ToLower() == rub.ToLower() && volumeRub >= volume)
                {
                    volumeRub -= volume;
                }
                else if (userСurrency.ToLower() == usd.ToLower() && volumeUsd >= volume)
                {
                    volumeUsd -= volume;
                }
                else if (userСurrency.ToLower() == eur.ToLower() && volumeEur >= volume)
                {
                    volumeEur -= volume;
                }
                else if (userСurrency.ToLower() == gbr.ToLower() && volumeGbr >= volume)
                {
                    volumeGbr -= volume;
                }
                else if (userСurrency.ToLower() == jpy.ToLower() && volumeJpy >= volume)
                {
                    volumeJpy -= volume;
                }
                else if (userСurrency.ToLower() == cny.ToLower() && volumeCny >= volume)
                {
                    volumeCny -= volume;
                }
            }
        }
    }
    else if (userCommand.ToLower() == command5.ToLower())
    {
        Console.WriteLine($" {rub} - {Math.Round(volumeRub, 2)}");
        Console.WriteLine($" {usd} - {Math.Round(volumeUsd, 2)}");
        Console.WriteLine($" {eur} - {Math.Round(volumeEur, 2)}");
        Console.WriteLine($" {gbr} - {Math.Round(volumeGbr, 2)}");
        Console.WriteLine($" {jpy} - {Math.Round(volumeJpy, 2)}");
        Console.WriteLine($" {cny} - {Math.Round(volumeCny, 2)}");
    }
    else if (userCommand.ToLower() == command6.ToLower())
    {
        break;
    }
    else
    {
        Console.WriteLine("Такой команды нет." +
        $"Для получения списка команд введите {command1}");
    }
}
