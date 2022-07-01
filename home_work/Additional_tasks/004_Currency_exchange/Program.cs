string rub = "rub", //рубль
    usd = "usd", //Доллар
    eur = "eur", //Евро
    gbr = "gbr", //Фунт Стерлингов
    jpy = "jpy", //Иена
    cny = "cny", //Юань
    userСurrency = "",
    volumeText = "",
    listOfCurrencies = $"(Рубли - {rub}, Доллары - {usd}, Евро - {eur}, Фунты - {gbr}, Ены - {jpy}, Юань - {cny}): ";

    
double volumeRub = 22300, 
    volumeUsd = 2400, 
    volumeEur = 658, 
    volumeGbr = 347, 
    volumeJpy = 900,
    volumeCny = 467,
    volume = 0,
    havingBalance = 1;

// курс на 28.06.2022г сайт https://www.banki.ru/products/currency/cb/
double exchangeRateUsdToRub = 53.3641, // 1 доллар = 53.3641
    exchangeRateEurToRub = 56.0535,
    exchangeRateGbrToRub = 65.5738,
    exchangeRateJpyToRub = 0.396464,
    exchangeRateCnyToRub = 8.04837;

string commandHelp = "Help", 
    commandSwap = "Swap", // Обмен 
    commandTopUp = "TopUp", // пополнение 
    commandWithdraw = "Withdraw", //снять деньги
    commandBalace = "Balance", // баланс
    commandExit = "Exit", // выход
    help = "Список команд: ",
    descriptionCommandSwap = $"{commandSwap} - обмен валют",
    descriptionCommandTopUp = $"{commandTopUp} - пополнение валютного счета",
    descriptionCommandWithdwar = $"{commandWithdraw} - вывод средств",
    descriptionCommandBalace = $"{commandBalace} - вывести текущий баланса",
    descriptionCommandExit = $"{commandExit} - выход";

double getCurrencyToWhichTransfer (string userCurrencyToWhichTransfer, double volume, double rate)
{
    if (userCurrencyToWhichTransfer == rub)
    {
        volumeRub += volume * rate;
        return volumeRub;
    }
    else if (userCurrencyToWhichTransfer == usd)
    {
        volumeUsd += volume * rate / exchangeRateUsdToRub;
        return volumeUsd;
    }
    else if (userCurrencyToWhichTransfer == eur)
    {
        volumeEur += volume * rate / exchangeRateEurToRub;
        return volumeEur;
    }
    else if (userCurrencyToWhichTransfer == gbr)
    {
        volumeGbr += volume * rate / exchangeRateGbrToRub;
        return volumeGbr;
    }
    else if (userCurrencyToWhichTransfer == jpy)
    {
        volumeJpy += volume * rate / exchangeRateJpyToRub;
        return volumeJpy;
    }
    else if (userCurrencyToWhichTransfer == cny)
    {
        volumeCny += volume * rate / exchangeRateCnyToRub;
        return volumeCny;
    }
    else
    {
        return -1;
    }

}
double reducingBalanceTransferredCurrency (string userCurrencyForTransfer, double volumeCurrencyForTransfer)
{
    if (userCurrencyForTransfer == rub && volumeRub >= volumeCurrencyForTransfer)
    {
        volumeRub -= volumeCurrencyForTransfer;
        return volumeRub;
    }
    else if (userCurrencyForTransfer == usd && volumeUsd >= volumeCurrencyForTransfer)
    {
        volumeUsd -= volumeCurrencyForTransfer;
        return volumeUsd;
    }
    else if (userCurrencyForTransfer == eur && volumeEur >= volumeCurrencyForTransfer)
    {
        volumeEur -= volumeCurrencyForTransfer;
        return volumeEur;
    }
    else if (userCurrencyForTransfer == gbr && volumeGbr >= volumeCurrencyForTransfer)
    {
        volumeGbr -= volumeCurrencyForTransfer;
        return volumeGbr;
    }
    else if (userCurrencyForTransfer == jpy && volumeJpy >= volumeCurrencyForTransfer)
    {
        volumeJpy -= volumeCurrencyForTransfer;
        return volumeJpy;
    }
    else if (userCurrencyForTransfer == cny && volumeCny >= volumeCurrencyForTransfer)
    {
        volumeCny -= volumeCurrencyForTransfer;
        return volumeCny;
    }
    else
    {
        Console.WriteLine("Ваш баланс не достаточен для данной операции");
        havingBalance = 0;
        return havingBalance;
    }
}
double getVolumeCurrentyForTransfer (string userCurrencyForTransfer)
{
    double rate = 1; // Для случаев валютой выбран руб.
    if (userCurrencyForTransfer == usd)
    {
        rate = exchangeRateUsdToRub;
    }
    else if (userCurrencyForTransfer == eur)
    {
        rate = exchangeRateEurToRub;
    }
    else if (userCurrencyForTransfer == gbr)
    {
        rate = exchangeRateGbrToRub;
    }
    else if (userCurrencyForTransfer == jpy)
    {
        rate = exchangeRateJpyToRub;
    }
    else if (userCurrencyForTransfer == cny)
    {
        rate = exchangeRateCnyToRub;
    }
    return rate;
}
string getUserSum()
{
    Console.Write("Введите сумму: ");
    volumeText = Console.ReadLine() ?? "";
    volumeText = volumeText.Replace(".", ",");
    return volumeText;
}

Console.WriteLine("Вас приветствует программа по управлению валютами." +
    "Для получения списка команд введите Help");

while (true)
{
    Console.Write("Введите команду: ");
    string userCommand = Console.ReadLine() ?? "";
        userCommand = userCommand.ToLower();
    if (userCommand == commandHelp.ToLower())
    {
        Console.WriteLine(help);
        Console.WriteLine(" " + descriptionCommandSwap);
        Console.WriteLine(" " + descriptionCommandTopUp);
        Console.WriteLine(" " + descriptionCommandWithdwar);
        Console.WriteLine(" " + descriptionCommandBalace);
        Console.WriteLine(" " + descriptionCommandExit);
    } 
    else if (userCommand == commandSwap.ToLower())
    {
        Console.WriteLine("Сначала введите название валюты которую хотите перевести," +
        " далее валюту которую хотите пополнить");
        Console.Write($"Введите валюту которую хотите перевести {listOfCurrencies}");
        string userCurrentyForTransfer = Console.ReadLine() ?? "";
            userCurrentyForTransfer = userCurrentyForTransfer.ToLower();
        Console.Write("Введите валюту которую хотите пополнить: ");
        string userCurrencyForExchange = Console.ReadLine() ?? "";
            userCurrencyForExchange = userCurrencyForExchange.ToLower();
        getUserSum();
        if (userCurrentyForTransfer != userCurrencyForExchange)
        {
            getVolumeCurrentyForTransfer (userCurrentyForTransfer);
            if (volumeText != "" && Convert.ToDouble(volumeText) != 0)
            {
                volume = Convert.ToDouble(volumeText);
                reducingBalanceTransferredCurrency(userCurrentyForTransfer, volume);
                if (havingBalance == 1)
                {
                    getCurrencyToWhichTransfer(userCurrencyForExchange, volume, getVolumeCurrentyForTransfer (userCurrentyForTransfer));
                }
                havingBalance = 1;
            }
        }
    }
    else if (userCommand == commandTopUp.ToLower())
    {
        Console.Write($"Введите валюту объем которой которой Вы хотите пополнить {listOfCurrencies}");
        userСurrency = Console.ReadLine() ?? "";
            userСurrency = userСurrency.ToLower();      
        if (userСurrency != "" )
        {
            getUserSum();
            volume = Convert.ToDouble(volumeText);
            if (volume != 0)
            {
                if (userСurrency == rub)
                {
                    volumeRub += volume;
                }
                else if (userСurrency == usd)
                {
                    volumeUsd += volume;
                }
                else if (userСurrency == eur)
                {
                    volumeEur += volume;
                }
                else if (userСurrency == gbr)
                {
                    volumeGbr += volume;
                }
                else if (userСurrency == jpy)
                {
                    volumeJpy += volume;
                }
                else if (userСurrency == cny)
                {
                    volumeCny += volume;
                }
            }
        }
    }
    else if (userCommand == commandWithdraw.ToLower())
    {
        Console.Write($"Введите валюту которую Вы хотите снять {listOfCurrencies}: ");
        userСurrency = Console.ReadLine() ?? "";
        if (userСurrency != "" )
        {
            getUserSum();
            if (volumeText != "" && Convert.ToDouble(volumeText) != 0)
            {
                volume = Convert.ToDouble(volumeText);
                reducingBalanceTransferredCurrency(userСurrency, volume);
            }
        }
    }
    else if (userCommand == commandBalace.ToLower())
    {
        Console.WriteLine($" {rub.ToUpper()} - {Math.Round(volumeRub, 2)}");
        Console.WriteLine($" {usd.ToUpper()} - {Math.Round(volumeUsd, 2)}");
        Console.WriteLine($" {eur.ToUpper()} - {Math.Round(volumeEur, 2)}");
        Console.WriteLine($" {gbr.ToUpper()} - {Math.Round(volumeGbr, 2)}");
        Console.WriteLine($" {jpy.ToUpper()} - {Math.Round(volumeJpy, 2)}");
        Console.WriteLine($" {cny.ToUpper()} - {Math.Round(volumeCny, 2)}");
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