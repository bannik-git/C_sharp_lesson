int NaturalNumber(int number)
{
    if (number ==1)
        return 1;
    else
        Console.Write(NaturalNumber(number -1) + ", ");
    return number;
}

Console.Write("Введите N: ");
int number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(NaturalNumber(number));
