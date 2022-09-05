using System.IO;

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

void PrintField(string[,] field, 
                int[] userCoordinates, char userSymbol, 
                int[,] enemyCoordinates, char enemySymbol,
                string instruction)
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
    Console.SetCursorPosition(userCoordinates[1], userCoordinates[0]);
    Console.Write(userSymbol);

    for (int i = 0; i < enemyCoordinates.GetLength(0); i++)
    {
        Console.SetCursorPosition(enemyCoordinates[i, 1], enemyCoordinates[i, 0]);
        Console.Write(enemySymbol); 
    }
    
}

void MapFormation (string[,] field, string path)
{
    StreamReader map = new StreamReader(path);
    for (int i = 0; i < field.GetLength(0); i++)
        field[i, 0] = map.ReadLine() ?? String.Empty;
}

void GetPlaceOfAppearance (string[,] field, int[] userCoorinates, int[] Coorinates = null)
{
    Random random = new Random();
    int i = 0,
        j = 0;
    while (true)
    {
        i = random.Next(0, field.GetLength(0));
        j = random.Next(0, field[0,0].Length);
        if (Coorinates != null)
        {
            if(field[i, 0][j] != '*' && i != userCoorinates[0] && j != userCoorinates[1])
            {
                Coorinates[0] = i;
                Coorinates[1] = j;
                return;
            }
        }
        else if (field[i, 0][j] != '*')
        {
            userCoorinates[0] = i;
            userCoorinates[1] = j;
            return;
        }
        
    }
}

void GetPlaceOfAppearanceEnemy (string[,] field, int[] userCoorinates, int[,] enemyCoorinates)
{
    Random random = new Random();
    int i = 0,
        j = 0;

    for (int k = 0; k < enemyCoorinates.GetLength(0); k++)      
    {
        bool check = true;
        while(check)
        {
            i = random.Next(0, field.GetLength(0));
            j = random.Next(0, field[0,0].Length);
            if(field[i, 0][j] != '*' && i != userCoorinates[0] && j != userCoorinates[1])
            {
                enemyCoorinates[k, 0] = i;
                enemyCoorinates[k, 1] = j;
                break;
            }
        }
    }
}


void Moving(string[,] field, int[] userCoordinates, ConsoleKey key)
{
    switch(key)
    {
        case ConsoleKey.UpArrow:
        {
            if (field[userCoordinates[0] - 1, 0][userCoordinates[1]] != '*')
                userCoordinates[0]--;
            break;
        }
        case ConsoleKey.DownArrow:
        {
            if (field[userCoordinates[0] + 1, 0][userCoordinates[1]] != '*')
                userCoordinates[0]++;   
            break;
        }
        case ConsoleKey.LeftArrow:
        {
            if (field[userCoordinates[0], 0][userCoordinates[1] - 1] != '*')
                userCoordinates[1]--;
            break;
        }
        case ConsoleKey.RightArrow:
        {
            if (field[userCoordinates[0], 0][userCoordinates[1] + 1] != '*')
                userCoordinates[1]++;
            break;
        }
    }   
}

void MovingEnemy(string[,] field, int[,] enemyCoordinates, 
                Random direction, int directionEnemy, 
                int stepEnemy, ref int stepCount)
{
    for (int i = 0; i < enemyCoordinates.GetLength(0); i++)
    {
        if (stepEnemy == stepCount)
        {
            directionEnemy = direction.Next(1,5);
            stepCount = 0;
        }
        bool step = true;
        while (step)
        { 
            switch(directionEnemy) 
            {
                case 1:
                {
                    if (field[enemyCoordinates[i, 0] - 1, 0][enemyCoordinates[i, 1]] != '*')
                        enemyCoordinates[i, 0]--; 
                    step = false;
                    break;
                }
                case 2:
                {
                    if (field[enemyCoordinates[i, 0] + 1, 0][enemyCoordinates[i, 1]] != '*')
                        enemyCoordinates[i, 0]++;  
                    step = false;
                    break;
                }
                case 3:
                {
                    if (field[enemyCoordinates[i, 0], 0][enemyCoordinates[i, 1] - 1] != '*')
                        enemyCoordinates[i, 1]--;
                    step = false;
                    break;
                }
                case 4:
                {
                    if (field[enemyCoordinates[i, 0], 0][enemyCoordinates[i, 1] + 1] != '*')
                        enemyCoordinates[i, 1]++;
                    step = false;
                    break;
                }
            } 
        }
    }  
}

bool Intersection (int[] userCoordinate, int[,] enemyCoordinates)
{
    bool result = false;
    for (int i = 0; i < enemyCoordinates.GetLength(0); i++)
    {
        if (userCoordinate[0] == enemyCoordinates[i, 0] && userCoordinate[1] == enemyCoordinates[i, 1])
            result = true;
    }
    return result;
}

bool Victory(string[,] field)
{
    bool result = true;
    for (int i = 0; i < field.GetLength(0); i++)
    {
        foreach (char item in field[i, 0])
        {
            if ('.' == item)
            {
                result = false;
                break;
            }
        }
    }
    return result;
}

int NumberOfFiles = new DirectoryInfo(@$"{Directory.GetCurrentDirectory()}\Maps\").GetFiles().Length;
int level = Convert.ToInt16(GetAnswer($"Доступно уровней - {NumberOfFiles} \nВведите № уровня: "));
string path = @$"{Directory.GetCurrentDirectory()}\Maps\{level}_level.txt";
int count = File.ReadAllLines(path).Length;
string[,] field = new string[count, 1]; 
MapFormation(field, path);

char user = '@',
    enemy = 'X';

string instruction = "Для передвижения используйте стрелочки, для выхода Esc";
int[] userCoordinates = new int[2];

int[,] enemyCoordinates = new int[3 ,2]; // 3 - Количество врагов


GetPlaceOfAppearance(field, userCoordinates);
GetPlaceOfAppearanceEnemy(field, userCoordinates, enemyCoordinates);

ConsoleKeyInfo directionOfTravel;
Console.CursorVisible = false;

string[] hello = {"Вас приветствует игра по поиску выхода из лабиринта",
                  "Условия просты, нужно найти выход используя для передвижения стрелочки вверх, вниз, влево и вправо.", 
                  "Ваше местоположения обозначено знаком - @, * обозначены стены лабиринта",
                  "Для начала нажмите Enter"
                 };

PrintArray(hello);
Console.ReadKey();
Random direction = new Random();
int directionEnemy = direction.Next(1,5);
Random step = new Random();
int stepEnemy = step.Next(1, 4);
int stepCount = 1;

while (true)
{
    
    PrintField(field, 
               userCoordinates, user,
               enemyCoordinates, enemy,
               instruction);
    Console.WriteLine(stepCount);
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
                MapFormation(field, path);
                GetPlaceOfAppearance(field, userCoordinates);
                GetPlaceOfAppearanceEnemy(field, userCoordinates, enemyCoordinates);
            break;
        }
        default:
        {
            if (Victory(field))
            {
                Console.SetCursorPosition(0, field.GetLength(0) + 2);
                Console.WriteLine("Вы победили!");
                goto case ConsoleKey.Escape;
            }
            if (Intersection(userCoordinates, enemyCoordinates))
            {
                Console.SetCursorPosition(0, field.GetLength(0) + 2);
                Console.WriteLine("Game Over");
                goto case ConsoleKey.Escape;
            } 
            if (userCoordinates[0] != 0 && userCoordinates[0] != field.GetLength(0) - 1)
            {
                field[userCoordinates[0], 0] = field[userCoordinates[0], 0].Remove(userCoordinates[1], 1).Insert(userCoordinates[1], ' '.ToString());
                Moving(field, userCoordinates, directionOfTravel.Key);
                MovingEnemy(field, enemyCoordinates, direction ,directionEnemy, stepEnemy, ref stepCount);
                
                stepCount++;
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
