// Способы задания массива
// способ 1
// int[] numbers1 = new int [8]; 
// способ 2
// int[] numbers2 = new int [4]{0, 5, 6, 7}; 
// способ 3
// int[] numbers3 = new []{0, 5, 6, 7}; 
// способ 4, только для массива инифиализированного сразу
// int[] numbers4 = {0, 5, 6, 7};

void PrintArray (int[] array) // метод для печати массива
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}

int[] randomArray = new int [8];

for (int index = 0; index < randomArray.Length; index++)
{
    randomArray[index] = new Random().Next(0, 2);
}
PrintArray(randomArray);
