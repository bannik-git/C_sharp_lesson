Console.Write("Введите номер дня недели (1-7): ");
int a = Convert.ToInt32(Console.ReadLine());

string [] days = new string  []{"Понедельник", "Вторник", "Среда", "Четверг", "Пянтица", "Суббота", "Воскресенье"};

Console.WriteLine(days[a-1]);
