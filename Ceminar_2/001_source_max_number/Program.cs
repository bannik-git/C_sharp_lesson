int randomNumber = new Random().Next(10, 100);

int firstDigit = randomNumber / 10;
int secondDigit = randomNumber % 10;

int max = firstDigit;

if (secondDigit > max)
{
    max = secondDigit;
}

Console.WriteLine($"Число = {randomNumber}, макс цифра = {max}");

