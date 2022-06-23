int SumBetweenMaxAndMin(int[] UserNumbers, int StartIndex, int EndIndex)
{
    int result = 0;
    while(StartIndex < EndIndex)
    {
        result = result + UserNumbers[StartIndex];
        StartIndex++;
    }
    return result;
}


int[] Numbers = new int[] {2, 4, 5, 7, 12, 14, 6, 3, 1};

int Size = Numbers.Length,
    index = 0;

int MaxNumber = Numbers[index],
    MinNumber = Numbers[index],
    MaxNumberIndex = index,
    MinNumberIndex = index;

while(index < Size)
{
    if (MaxNumber < Numbers[index])
    {
        MaxNumber = Numbers[index];
        MaxNumberIndex = index;
    }
    else if (MinNumber > Numbers[index])
    {
        MinNumber = Numbers[index];
        MinNumberIndex = index;
    }

    index++;
}   

if (MinNumberIndex < MaxNumberIndex) 
{
    Console.WriteLine(SumBetweenMaxAndMin(Numbers, MinNumberIndex + 1, MaxNumberIndex));
}
else
{
    Console.WriteLine(SumBetweenMaxAndMin(Numbers, MaxNumberIndex + 1, MinNumberIndex));
}