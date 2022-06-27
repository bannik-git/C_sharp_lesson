int maxNumber = 20,
    count = 0,
    maxAttemp = 3,
    number = new Random().Next(1, maxNumber + 1);

string attemp = "";  

// 1 попытка, [2:4] попытки, [5:n] попыток
if (maxAttemp == 1)
{
    attemp = "попытка";
}
else if (maxAttemp < 4)
{
    attemp = "попытки";
}
else
{
    attemp = "попыток";
}

string greetings = "Вас приветствует игра 'Угадайка', она загадает число от 1 до 20.",
       exercise = $"Ваша задача угадать загаданное число за {maxAttemp} {attemp}. Удачи!",
       yesEn = "y",
       yesRu = "д",
       yesInWrongStoryEn = "н",
       yesInWrongStoryRu = "l";

 Console.WriteLine(greetings);

while (true)
{
    Console.WriteLine(exercise);

    while (count < maxAttemp)
    {
        Console.Write("Введите число: ");
        int userNumber = Convert.ToInt32(Console.ReadLine()); 

        if (userNumber == number)
        {
            Console.Write("Совершенно верно!");
            break;
        }
        else if (userNumber < number)
        {
            Console.WriteLine($"Ваше число меньше загаданного. Попыток осталось: {maxAttemp - ++count}");
        }
        else if (userNumber > number)
        {
            Console.WriteLine($"Ваше число больше загаданного. Попыток осталось: {maxAttemp - ++count}");
        }
    }
    if (count < maxAttemp)
    {
        Console.WriteLine(" Хотите попробовать еще раз введите 'y' или 'д'");
    }
    else
    {
        Console.WriteLine("К сожалению попытки кончались. Если хотите попробовать еще раз введите 'y' или 'д'");
    }
     
    string userAnswer = Console.ReadLine() ?? ""; //для того чтоб VS code не ругался ^_^

    if (userAnswer.ToLower() == yesEn || 
        userAnswer.ToLower() == yesRu ||
        userAnswer.ToLower() == yesInWrongStoryEn ||
        userAnswer.ToLower() == yesInWrongStoryRu)
    {
        count = 0;

    }
    else
    {
        break;
    }
    
    
}