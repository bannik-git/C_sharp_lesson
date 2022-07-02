// Вид 1 Метод который ничего не принимает и не возвращают
void Method1() 
{
    Console.WriteLine("Любой текст");
}

// вызов метода 
Method1();

// Вид 2 что-то принимает, но ничего не возвращает
void Method2(string msg)
{
    Console.WriteLine(msg);
}

void Method21(string msg, int count)
{
    int i = 0;
    while (i < count)
    {
    Console.WriteLine(msg);
    i++; // ++ инкримент, -- деккримент
    }
}

// вызов метода
Method2("Текст сообщения");

// вызов с наименование аргумента
Method2(msg: "Текст Сообщения");
// вызов метода21
Method21("Текст", 4); // или 
Method21(count: 4, msg: "Новый текст"); // если именуем аргументы то не важно в каком они порядке.

// Вид 3 ничего непринимает, но что-то возвращает.

int Method3()
{
    return DateTime.Now.Year;
}

// вызов
int year = Method3();
Console.WriteLine(year);

// Вид 4 что-то принимает и что-то возвращает
string Method4 (int count, string text)
{
    int i = 0;
    string result = string.Empty; // пустая строка
    
    while (i < count)
    {
        result += text;
        i++;
    }
    return result;
}

// вызов
string res = Method4(10, "любой текст ");
Console.WriteLine(res);
