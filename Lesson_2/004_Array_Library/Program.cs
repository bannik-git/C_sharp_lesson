void FillArray(int[] collection) // void - метод кторый ничего не возвращает
{
    int length = collection.Length;
    int index = 0;
    while (index < length)
    {   
        collection[index] = new Random().Next(1, 10);
        index++;
    }
}

void PrintArray(int[] col) 
{
    int count = col.Length;
    int position = 0;
    while (position < count)
    {
        Console.Write(col[position] + " ");
        position++;
    }
}
int[] array = new int[10];

FillArray(array);
PrintArray(array);
