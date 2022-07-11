int GetLength (string question)
{
    Console.Write(question);
    return Convert.ToInt32(Console.ReadLine());
}

int sideA = GetLength("Введите длину сторону А: ");
int sideB = GetLength("Введите длину сторону B: "); 
int sideC = GetLength("Введите длину сторону C: ");

if(
    sideA < sideB + sideC 
    && sideB < sideA + sideC 
    && sideC < sideB + sideA) 
{ 
    Console.WriteLine("ДА Существует!!!"); 
} 
else 
{ 
    Console.WriteLine("Не существует"); 
} 
