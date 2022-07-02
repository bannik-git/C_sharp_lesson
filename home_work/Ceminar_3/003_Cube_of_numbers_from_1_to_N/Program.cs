Console.Write($"Введите число от 1 до {int.MaxValue}: ");
int userNumber = Convert.ToInt32(Console.ReadLine()),
count = 1;
string result = "";

while (count <= userNumber)
{
    result += count * count * count; // result += Math.Pow(count, 3);
    if (count != userNumber)
    {
    result += ", "; // result = result + count * count + ", ";
    }
    count++;
}

Console.WriteLine(result);