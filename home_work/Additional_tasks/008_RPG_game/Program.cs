using System.IO;
using System.Timers;

string GetAnswer (string text)
{
    Console.Write(text);
    return Console.ReadLine() ?? string.Empty;
}

void PrintArray (string[] array)
{
    for (int i = 0; i < array.Length; i++)
            Console.WriteLine(array[i]);
}

void PrintField(string[,] field, int[] userCoordinates, string instruction, char userSymbol)
{
    Console.Clear();
    for (int i = 0; i < field.GetLength(0); i++)
    {
        for (int j = 0; j < field.GetLength(1); j++)
        {
            Console.Write(field[i, j]);
        }
        Console.WriteLine();
    }
    Console.WriteLine(instruction + "\n");
    Console.SetCursorPosition(userCoordinates[2], userCoordinates[0]);
    Console.Write('@');
}

void MapFormation (string[,] field, string path)
{
    StreamReader map = new StreamReader(path);
    for (int i = 0; i < field.GetLength(0); i++)
        field[i, 0] = map.ReadLine() ?? String.Empty;
}

void GetPlaceOfAppearance (string[,] field, int[] userCoorinates)
{
    Random random = new Random();
    int i = 0,
        j = 0;
    while (true)
    {
        i = random.Next(0, field.GetLength(0));
        j = random.Next(0, field[0,0].Length);
        if(field[i, 0][j] != '*')
        {
            userCoorinates[0] = i;
            userCoorinates[2] = j;
            return;
        }
    }
}

void Moving(string[,] field, int[] userCoordinates, ConsoleKey key)
{
    switch(key)
    {
        case ConsoleKey.UpArrow:
        {
            if (field[userCoordinates[0] - 1, 0][userCoordinates[2]] != '*')
                userCoordinates[0]--;
            break;
        }
        case ConsoleKey.DownArrow:
        {
            if (field[userCoordinates[0] + 1, 0][userCoordinates[2]] != '*')
                userCoordinates[0]++;   
            break;
        }
        case ConsoleKey.LeftArrow:
        {
            if (field[userCoordinates[0], 0][userCoordinates[2] - 1] != '*')
                userCoordinates[2]--;
            break;
        }
        case ConsoleKey.RightArrow:
        {
            if (field[userCoordinates[0], 0][userCoordinates[2] + 1] != '*')
                userCoordinates[2]++;
            break;
        }
    }   
}

int NumberOfFiles = new DirectoryInfo(@$"{Directory.GetCurrentDirectory()}\Maps\").GetFiles().Length;
int level = Convert.ToInt16(GetAnswer($"Доступно уровней - {NumberOfFiles} \nВведите № уровня: "));
string path = @$"{Directory.GetCurrentDirectory()}\Maps\{level}_level.txt";
int count = File.ReadAllLines(path).Length;
string[,] field = new string[count, 1]; 
MapFormation(field, path);
char user = '@';
string instruction = "Для передвижения используйте стрелочки, для выхода Esc";
int[] userCoordinates = new int[3];

GetPlaceOfAppearance(field, userCoordinates);
ConsoleKeyInfo directionOfTravel;
Console.CursorVisible = false;

string[] hello = {"Вас приветствует игра по поиску выхода из лабиринта",
                  "Условия просты, нужно найти выход используя для передвижения стрелочки вверх, вниз, влево и вправо.", 
                  "Ваше местоположения обозначено знаком - @, * обозначены стены лабиринта",
                  "Для начала нажмите Enter"
                 };
PrintArray(hello);
Console.ReadKey();

while (true)
{
    
    PrintField(field, userCoordinates, instruction, user);
    directionOfTravel = Console.ReadKey();
    switch (directionOfTravel.Key)
    {

        case ConsoleKey.Escape:
        {
            Console.SetCursorPosition(0, field.GetLength(0) + 4);
            string answer = GetAnswer("Хотите выйти введите - д, Если хотите попробовать еще раз просто нажмите Enter: ").ToLower();
            if (answer == "д" || answer == "l")
            {
                Console.CursorVisible = true;
                Console.Clear();
                return;
            }
            else 
                GetPlaceOfAppearance(field, userCoordinates);
            break;
        }
        default:
        {
            if (userCoordinates[0] != 0 && userCoordinates[0] != field.GetLength(0) - 1)
            {

                Moving(field, userCoordinates, directionOfTravel.Key);
                break;
            }
            else
            {
                Console.SetCursorPosition(0, field.GetLength(0) + 2);
                Console.WriteLine("Поздравляю, Вы нашли выход из лабиринта!\n");
                goto case ConsoleKey.Escape;
            }
        }
    }
}
