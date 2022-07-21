using System.Text;

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

void PrintField(string[,] field, int indexStringUser, string instruction)
{
    Console.Clear();
    Console.WriteLine(instruction + "\n");
    // ограниченный вывод поля
    int i = 0,
        j = field.GetLength(0) - 1;
    if (indexStringUser == j)
    {
        for(i = indexStringUser - 2; i < j + 1; i++)
        { 
            Console.WriteLine(field[i, 0]);
        }
    }
    else if (indexStringUser != j && indexStringUser > 0)
        for (i = indexStringUser - 1; i < indexStringUser + 2; i++)
        {
            Console.WriteLine(field[i, 0]);
        }
    else
    {
        for(i = indexStringUser; i < indexStringUser + 2; i++)
            Console.WriteLine(field[i, 0]);
    }
    // Вывод всего поля сразу
    // for (int i = 0; i < field.GetLength(0); i++)
    // {
    //     for (int j = 0; j < field.GetLength(1); j++)
    //     {
    //         Console.Write(field[i, j]);
    //     }
    //     Console.WriteLine();
    // }
}

void GetPlaceOfAppearance (string[,] field, char userSymbol, int[] userCoorinates)
{
    Random random = new Random();
    StringBuilder buffString = new StringBuilder();
    int i = 0,
        j = 0;
    while (true)
    {
        i = random.Next(0, field.GetLength(0));
        j = random.Next(0, field[0,0].Length);
        if(field[i, 0][j] != '*')
        {
            buffString.Append(field[i, 0]);
            buffString[j] = userSymbol;
            field[i, 0] = Convert.ToString(buffString) ?? string.Empty;
            userCoorinates[0] = i;
            userCoorinates[2] = j;
            return;
        }
    }
}

void Moving(string[,] field, int[] userCoordinates, char userSymbol, ConsoleKey key)
{
    StringBuilder buffString = new StringBuilder(field[userCoordinates[0], 0]); // userCoordinates[0] - номер строки с местом пользователя
// Клавиши:
// DownArrow  | 40 | Клавиша СТРЕЛКА ВНИЗ.
// UpArrow 	  | 38 | Клавиша СТРЕЛКА ВВЕРХ.
// LeftArrow  | 37 | Клавиша СТРЕЛКА ВЛЕВО.
// RightArrow | 39 | Клавиша СТРЕЛКА ВПРАВО.
    switch (key)
    {
        case ConsoleKey.UpArrow:
        {
            if (field[userCoordinates[0] - 1, 0][userCoordinates[2]] != '*')
            {
            buffString.Replace(userSymbol, ' ');
            field[userCoordinates[0], 0] = buffString.ToString();
            buffString.Clear()
                      .Append(field[userCoordinates[0] - 1 , 0]);
            buffString[userCoordinates[2]] = userSymbol;
            field[userCoordinates[0] - 1, 0] = buffString.ToString();
            userCoordinates[0] -= 1; 
            }
            break;
        }
        case ConsoleKey.DownArrow:
        {
            if (field[userCoordinates[0] + 1, 0][userCoordinates[2]] != '*')
            {
            buffString.Replace(userSymbol, ' ');
            field[userCoordinates[0], 0] = buffString.ToString();
            buffString.Clear()
                      .Append(field[userCoordinates[0] + 1 , 0]);
            buffString[userCoordinates[2]] = userSymbol;
            field[userCoordinates[0] + 1, 0] = buffString.ToString();
            userCoordinates[0] += 1; 
            }
            break;
        }
        case ConsoleKey.LeftArrow:
        {
            if (field[userCoordinates[0], 0][userCoordinates[2] - 1] != '*')
            {
                buffString.Replace(userSymbol, ' ');
                buffString[userCoordinates[2] - 1] = userSymbol;
                field[userCoordinates[0], 0] = buffString.ToString();
                userCoordinates[2] -= 1; 
            }
            break;
        }
        case ConsoleKey.RightArrow:
        {
            if (field[userCoordinates[0], 0][userCoordinates[2] + 1] != '*')
            {
                buffString.Replace(userSymbol, ' ');
                buffString[userCoordinates[2] + 1] = userSymbol;
                field[userCoordinates[0], 0] = buffString.ToString();
                userCoordinates[2] += 1; 
            }
            break;
        }
    }
    // return field;
}

void RestorationOfThePlayingField (string[,] field)
{
    StringBuilder buffString = new StringBuilder();
    for(int i = 0; i < field.GetLength(0); i++)
    {
        buffString.Append(field[i, 0])
                  .Replace('@', ' ');
        field[i, 0] = buffString.ToString();
        buffString.Clear();
    }
}

string[,] field = {  //33 на 16
{"****************  ***************"},
{"*                               *"},
{"*  *************  ************  *"},
{"*      ****               ****  *"},
{"*************************  ******"},
{"****      *********        ***  *"},
{"**     *****   *  ***  *******  *"},
{"*                               *"},
{"****   **   *********************"},
{"*      **        *********    ***"},
{"****  *********   ******     ****"},
{"***************   ******   ******"},
{"*         *****              ****"},
{"******   ***************   ******"},
{"******                          *"},
{"******************************  *"}
};
char user = '@';
string instruction = "Для передвижения используйте стрелочки, для выхода Esc";
int[] userCoordinates = new int[3];
GetPlaceOfAppearance(field, user, userCoordinates);
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
    PrintField(field, userCoordinates[0], instruction);
    directionOfTravel = Console.ReadKey();
    switch (directionOfTravel.Key)
    {
        case ConsoleKey.Escape:
        {
            string answer = GetAnswer("Хотите выйти введите - д, Если хотите попробовать еще раз просто нажмите Enter: ").ToLower();
            if (answer == "д" || answer == "l")
            {
                Console.CursorVisible = true;
                return;
            }
            else 
            {
                RestorationOfThePlayingField (field);
                GetPlaceOfAppearance(field, user, userCoordinates);
            }
            break;
        }
        default:
        {
            if (userCoordinates[0] != 0 && userCoordinates[0] != field.GetLength(0) - 1)
            {
                // field = 
                Moving(field, userCoordinates, user, directionOfTravel.Key);
                break;
            }
            else
            {
                Console.WriteLine("\nПоздравляю, Вы нашли выход из лабиринта!\n");
                goto case ConsoleKey.Escape;
            }
        }
    }
}