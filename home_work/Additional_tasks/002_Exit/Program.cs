string exit = "exit";
int count = 1;
Console.WriteLine("Программа работает исправно");
while (true)
{
    Console.Write("Если хотите завершить программу введите exit: ");
    string userCommand = Console.ReadLine() ?? "";

    if (userCommand.ToLower() == exit)
    {
        Console.WriteLine("Программа закрыта");
        break;
    } 
    else
    {
        Console.WriteLine($"{count++} цикл");
    }
}
