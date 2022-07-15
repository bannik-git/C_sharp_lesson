/* 
Программа для ведения досье работников. Есть 3 массива: фио, должность и зарплата. 
В программе должна быть возможность добавить досье, вывести все досье в формате фио-должность-зп
(Иванов Иван Иванович – кассир – 25 000), удалить досье по номеру (номера начинаются с 1), 
поиск досье по фамилии. Дополнительно: вывод всех досье с зп меньше или больше указанной, 
вывод всех досье с указанной должностью. Можно придумать еще свои команды.
*/

// Метод выводящий в консоль массив состоящий из строк
void PrintStringArray (string[] array)
{
    for (int count = 0; count < array.Length; count++)
        Console.WriteLine(array[count]);
    Console.WriteLine();
}

// Запрос последовательности чисел
string GetUserAnswer (string text)
{
    Console.Write(text);
    string userNumber = Console.ReadLine() ?? "";
    return userNumber;
}

// печать массива
void PrintDossier (string[,] arrayName, string[] arrayJobTitle, int[] arraySalary)
{
    Console.WriteLine();
    for (int i = 0; i < arrayName.GetLength(1); i++)
        {
          Console.WriteLine($"{i + 1}. {arrayName[0, i]} {arrayName[1, i]} {arrayName[2, i]}" // 0 - Фамилии, 1 - Имя, 2 - Отчество
          + $" - {arrayJobTitle[i]} - {arraySalary[i]}");
        }
    Console.WriteLine();
}

// методы добавляющие данные работника
string[,] AddFullName (string[,] array, string employeerFullName)
{
    string[,] newArrayFullName = new string[array.GetLength(0), array.GetLength(1) + 1];
    string[] fullName = employeerFullName.Split(' ');
    for (int i = 0; i < newArrayFullName.GetLength(0); i++)
    {
        for (int j = 0; j < newArrayFullName.GetLength(1); j++)
        {
            if ( j < array.GetLength(1))
                newArrayFullName[i, j] = array[i, j];
            else 
                newArrayFullName[i, j] = fullName[i];
        }
    }
    return newArrayFullName;

}

string[] AddJobTitle(string[] array, string jobTitle)
{
    string[] newArrayJobTitle = new string[array.Length +1];
    for (int i = 0; i < newArrayJobTitle.Length; i++)
    {
        if (i < array.Length) newArrayJobTitle[i] = array[i];
        else newArrayJobTitle[i] = jobTitle;
    }
    return newArrayJobTitle;
}

int[] AddSelary(int[] array, string salary)
{
    int[] newArraySalary = new int[array.Length +1];
    for (int i = 0; i < newArraySalary.Length; i++)
    {
        if (i < array.Length) newArraySalary[i] = array[i];
        else newArraySalary[i] = Convert.ToInt32(salary);
    }
    return newArraySalary;
}

// методы удаляющие данные работника
string[,] DeleteEmployee (string[,] array, int index)
{
    string[,] newArrayFullName = new string[array.GetLength(0), array.GetLength(1) - 1];
    for (int i = 0; i < newArrayFullName.GetLength(0); i++)
    {
        for (int j = 0; j < newArrayFullName.GetLength(1); j++)
        {
            if ( j != index) newArrayFullName[i, j] = array[i, j];
        }
    }
    return newArrayFullName;

}

string[] DeleteJobTitle(string[] array, int index)
{
    string[] newArrayJobTitle = new string[array.Length - 1];
    for (int i = 0; i < newArrayJobTitle.Length; i++)
    {
        if (i != index) newArrayJobTitle[i] = array[i];
    }
    return newArrayJobTitle;
}

int[] DeleteSelary(int[] array, int index)
{
    int[] newArraySalary = new int[array.Length - 1];
    for (int i = 0; i < newArraySalary.Length; i++)
    {
        if (i != index) newArraySalary[i] = array[i];
    }
    return newArraySalary;
}

// методы вывода конкретного работника
int SearchEmployee (string[,] array, string surnameEmployee)
{
    int indexSurnameEmployee = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        if (array[0, i] == surnameEmployee)
            indexSurnameEmployee = i;
    }
    return indexSurnameEmployee;
}

void PrintEmployee (string[,] arrayFullName, string[] arrayJobTitle, int[] arraySalary, int index)
{
    Console.WriteLine();
    Console.WriteLine($"{index + 1}. {arrayFullName[0, index]} {arrayFullName[1, index]} {arrayFullName[2, index]}"
          + $" - {arrayJobTitle[index]} - {arraySalary[index]}");
    Console.WriteLine();
}

// методы вывода по зарабоной плате
// поиск совпадения условия
bool SearchMatchСondition (int[] array, int wage, string moreLess = "less")
{
    bool result = false;
    if (moreLess == "more")
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (wage < array[i])
            result = true;
        }
    }
    else
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (wage > array[i])
            result = true;
        }
    }
    return result;
}
// меньше
void PrintLessPaidWorkers (string[,] arrayFullName, string[] arrayJobTitle, int[] arraySalary, int salary)
{   
    Console.WriteLine();
    for (int i = 0; i < arraySalary.Length; i++)
    {
        if (arraySalary[i] < salary)
        {
            Console.WriteLine($"{i + 1}. {arrayFullName[0, i]} {arrayFullName[1, i]} {arrayFullName[2, i]}"
                + $" - {arrayJobTitle[i]} - {arraySalary[i]}");
        }
    }
    Console.WriteLine();
}
// больше
void PrintWorkersWithHigherWages (string[,] arrayFullName, string[] arrayJobTitle, int[] arraySalary, int salary)
{   
    Console.WriteLine();
    for (int i = 0; i < arraySalary.Length; i++)
    {
        if (arraySalary[i] > salary)
        {
            Console.WriteLine($"{i + 1}. {arrayFullName[0, i]} {arrayFullName[1, i]} {arrayFullName[2, i]}"
                + $" - {arrayJobTitle[i]} - {arraySalary[i]}");
        }
    }
    Console.WriteLine();
}

// метод вывода по профессии
bool SearchPost (string[] array, string post)
{
    bool postEmployee = false;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == post)
        {
            postEmployee = true;
            break;
        }
    }
    return postEmployee;

}

void SealOfWorkersByProfession (string[,] arrayFullName, string[] arrayJobTitle, int[] arraySalary, string post)
{   
    Console.WriteLine();
    for (int i = 0; i < arrayJobTitle.Length; i++)
    {
        if (arrayJobTitle[i] == post)
        {
            Console.WriteLine($"{i + 1}. {arrayFullName[0, i]} {arrayFullName[1, i]} {arrayFullName[2, i]}"
                + $" - {arrayJobTitle[i]} - {arraySalary[i]}");
        }
    }
    Console.WriteLine();
}

// Методы форматирования записи
string[,] RecordFullName(string[,] arrayFullName, int employeeNumber, string newFullName)
{
    string[] buffArrayNewFullName = newFullName.Split(' ');
    for(int i = 0; i < arrayFullName.GetLength(0); i++)
        arrayFullName[i, employeeNumber] = buffArrayNewFullName[i];
    return arrayFullName;
}

string[] RecordJobTitle (string[] arrayJobTitle, int employeeNumber, string newJobTitle)
{
    arrayJobTitle[employeeNumber] = newJobTitle;
    return arrayJobTitle;
}

int[] RecordSalary (int[] arraySalary, int employeeNumber, int newSalary)
{
    arraySalary[employeeNumber] = newSalary;
    return arraySalary;
}

void RecordEmployee(ref string[,] arrayFullName, ref string[] arrayJobTitle, ref int[] arraySalary,
                    string[] arrayNewEmployee, int employeeNumber)
{
    string newFullName = $"{arrayNewEmployee[0]} {arrayNewEmployee[1]} {arrayNewEmployee[2]}"; // ФИО - 3 слова
    arrayFullName = RecordFullName(arrayFullName, employeeNumber, newFullName);
    arrayJobTitle = RecordJobTitle(arrayJobTitle, employeeNumber, arrayNewEmployee[3]);
    arraySalary = RecordSalary(arraySalary, employeeNumber, Convert.ToInt32(arrayNewEmployee[4]));
}

// Статистика
int MonthlyPayroll (int[] salary)
{
    int result = 0;
    for (int i = 0; i <salary.Length; i++)
    {
        result += salary[i];
    }
    return result;
}

int AverageMonthlySalary (int[] salary)
{
    int result = 0;
    for (int i = 0; i <salary.Length; i++)
    {
        result += salary[i];
    }
    return result/salary.Length;
}

int indexMaxSalary (int[] salary)
{
    int indexMax = 0 ;
    for (int i = 1; i < salary.Length; i++)
    {
        if (salary[indexMax] < salary[i])
            indexMax = i;
    } 
    return indexMax;
}

int indexMinSalary (int[] salary)
{
    int indexMin = 0 ;
    for (int i = 1; i < salary.Length; i++)
    {
        if (salary[indexMin] > salary[i])
            indexMin = i;
    } 
    return indexMin;
}

void Statistics(string[,] arrayFullName, string[] arrayJobTitle, int[] arraySalary)
{
    int payrollFund = MonthlyPayroll(arraySalary),
        averageWage = AverageMonthlySalary(arraySalary),
        numberOfEmployees = arraySalary.Length,
        indexMax = indexMaxSalary(arraySalary),
        indexMin = indexMinSalary(arraySalary);
        

    string employee = "сотрудник",
           strNumberOfEmployees = Convert.ToString(numberOfEmployees);
    char lastNumber = strNumberOfEmployees[strNumberOfEmployees.Length - 1];

    if (Char.GetNumericValue(lastNumber) > 1 && Char.GetNumericValue(lastNumber) < 5 && (numberOfEmployees < 5 || numberOfEmployees > 21))
        employee = "сотрудника";
    else 
        employee = "сотрудников";
    Console.WriteLine();
    Console.WriteLine($"В компании трудится {numberOfEmployees} {employee}.\n"
                    + $"Cредмесячная заработная плата составляет {averageWage} руб.\n"
                    + $"Месячный фонд оплаты труда составляет {payrollFund} руб.\n\n"
                    + $"Сотрудник получающий минимальную заработную плату: "
                    + $" {indexMin + 1}. {arrayFullName[0, indexMin]} {arrayFullName[1, indexMin]} {arrayFullName[2, indexMin]}"
                    + $" - {arrayJobTitle[indexMin]} - {arraySalary[indexMin]}\n\n"
                    + $"Сотрудник получающий максимальную заработную плату: "
                    + $" {indexMax + 1}. {arrayFullName[0, indexMax]} {arrayFullName[1, indexMax]} {arrayFullName[2, indexMax]}"
                    + $" - {arrayJobTitle[indexMax]} - {arraySalary[indexMax]}");
    Console.WriteLine();
}


// string[,] employeeFullName = new string[3,0];
string[,] employeeFullName = 
{
    {"Иванов", "Сидоров", "Петров"},
    {"Иван", "Семен", "Пётор"},
    {"Иванович", "Семенович", "Петрович"},
};

// string[] jobTitle = new string[0]; 
string[] jobTitle = {"кассир", "Адьютант", "Майор"};
// int[] salary = new int[0]; 
int[] salary = {25000, 250000, 140000};

Console.WriteLine("Вас приветствует программа по анализу работающего персонала");

string[] functional = {"Функционал программы:",
                       "   1 - Добавление новых сотрудников",
                       "   2 - Удалить выбранное досье по порядковому номеру", 
                       "   3 - Вывод досье по фамилии работника",
                       "   4 - Вывод досье с уровнем заработной платы меньше указанной",
                       "   5 - Вывод досье с уровнем заработной платы больше указанной",
                       "   6 - Вывод всех досье по указанной должности",
                       "   7 - Форматирование записи сотрудника",
                       "   8 - Вывести статистику по организации",
                       "   9 - Вывод всех досье",
                       "  Для выхода из программы введите Exit"};

while (true)
{
    string userAnswer = GetUserAnswer("Введите цифру или команду, для вывода описания функционала введите Help: ").ToLower();
    switch (userAnswer)
    {
        case "help": 
            PrintStringArray(functional);
            break;
        case "exit": 
            Console.Clear();
            return;
        default:
            int numberUserAnswer = Convert.ToByte(userAnswer);
            switch (numberUserAnswer)
            {
                case 1: 
                    string userEmployeeFullName = GetUserAnswer("Введите ФИО работника: ");
                    employeeFullName = AddFullName(employeeFullName, userEmployeeFullName);
                    string userJobTitle = GetUserAnswer("Введите должность: ");
                    jobTitle = AddJobTitle(jobTitle, userJobTitle);
                    string userSalary = GetUserAnswer("Введите заработную плату: ");
                    salary = AddSelary(salary, userSalary);
                    break;
                case 2:
                    int indexEmployee = Convert.ToInt32(GetUserAnswer("Введите порядковый номер работника которого хотите удалить: ")) - 1;
                    if (indexEmployee < employeeFullName.GetLength(1) - 1)
                    {
                        employeeFullName = DeleteEmployee(employeeFullName, indexEmployee);
                        jobTitle = DeleteJobTitle(jobTitle, indexEmployee);
                        salary = DeleteSelary(salary, indexEmployee);
                    }
                    else Console.WriteLine("Введено число превышающее количество работников");
                    break;
                case 3:
                    string surname = GetUserAnswer("Введите фамилию работника: ");
                    int indexSurname = SearchEmployee(employeeFullName, surname);
                    if (Convert.ToBoolean(indexSurname))
                        PrintEmployee(employeeFullName, jobTitle, salary, indexSurname);
                    else
                        Console.WriteLine("Работник не найден");
                    break;
                case 4:
                    int employeeSalaryLess = Convert.ToInt32(GetUserAnswer("Введите сумму: "));
                    if (SearchMatchСondition(salary, employeeSalaryLess))
                        PrintLessPaidWorkers(employeeFullName, jobTitle, salary, employeeSalaryLess);
                    else Console.WriteLine("Работники удовлетворяющие условию отсутсвуют");
                    break;
                case 5:
                    int employeeSalaryMore = Convert.ToInt32(GetUserAnswer("Введите сумму: "));
                    if (SearchMatchСondition(salary, employeeSalaryMore, "more"))
                        PrintWorkersWithHigherWages(employeeFullName, jobTitle, salary, employeeSalaryMore);
                    else Console.WriteLine("Работники удовлетворяющие условию отсутсвуют");
                    break;
                case 6:
                    string post = GetUserAnswer("Введите название должности: ");
                    if (SearchPost(jobTitle, post))
                        SealOfWorkersByProfession(employeeFullName, jobTitle, salary, post);
                    else
                        Console.WriteLine("Должность не найдена");
                    break;
                case 7:
                    PrintDossier(employeeFullName, jobTitle, salary);
                    int employeeNumber = Convert.ToInt32(GetUserAnswer("Введите номер записи которую хотите отформатировать: ")) - 1;
                    string[] instruction ={"  1 - если вы хотите отформатировать ФИО",
                                           "  2 - если вы хотите отформатировать должность",
                                           "  3 - если вы хотите отформатировать заработную плату",
                                           "  4 - если вы хотите отформатировать все данные"};
                    PrintStringArray(instruction);
                    int userNumber = Convert.ToInt32(GetUserAnswer("Введите число: "));
                    switch (userNumber)
                    {
                        case 1:
                            string newFullName = GetUserAnswer("Введите скорректированное ФИО: ");
                            employeeFullName = RecordFullName(employeeFullName, employeeNumber, newFullName);
                            break;
                        case 2:
                            string newJobTitle = GetUserAnswer("Введите скорректированную должность: ");
                            jobTitle = RecordJobTitle(jobTitle, employeeNumber, newJobTitle);
                            break;
                        case 3:
                            int newSalary = Convert.ToInt32(GetUserAnswer("Введите скорректированную заработную плату: "));
                            salary = RecordSalary(salary, employeeNumber, newSalary);
                            break;
                        case 4:
                            string[] newEmployee = GetUserAnswer("Последовательно вводите ФИО, должность и заработную плату разделяя пробелами: ").Split(' ');
                            RecordEmployee(ref employeeFullName, ref jobTitle, ref salary, newEmployee, employeeNumber);
                            break;
                        default:
                            Console.WriteLine("Вы ввели не верное число");
                            break;
                    }
                    break;
                case 8:
                    Statistics(employeeFullName, jobTitle, salary);
                    break;
                case 10:
                    PrintDossier(employeeFullName, jobTitle, salary);
                    break;
                default:
                    Console.WriteLine("Введена не верная команда");
                    break;
            }
            break;
    }
}

