Console.Write("Введите имя пользователя: ");
string UserName = Console.ReadLine();

if (UserName.ToLower() == "маша")
{
    Console.WriteLine("Ура, это Маша");
}
else 
{
    Console.Write("Привет, ");
    Console.WriteLine(UserName);
}