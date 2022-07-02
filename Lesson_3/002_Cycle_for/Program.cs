string Method4 (int count, string text)
{
    string result = string.Empty; // пустая строка
    // Синтаксис цикла: 
    // for(инициализация счетчика; условие; увеличение/уменьшение счетчика){тело цикла}
    for (int i = 0; i < count; i++) // пример фикла for
    {
        result += text;
    }
    return result;
}
string res = Method4(10, "любой текст ");
Console.WriteLine(res);