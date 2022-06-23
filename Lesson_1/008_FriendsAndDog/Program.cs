int FirstFriendsSpeed = 2,
    SecondFriendsSpeed = 3,
    DogSpeed = 5,
    count = 0;

double distance = 10000, time = 0;

int DirectionDog = 1; // 1 - от первого ко второму, 2 - от второго к первому

while (distance > 2)
{   
        
    if (DirectionDog == 1)
    {
        time = distance / (SecondFriendsSpeed + DogSpeed);
        DirectionDog = 2;
    }
    else
    {
        time = distance / (FirstFriendsSpeed + DogSpeed);
        DirectionDog = 1;
    }

    distance = distance - (FirstFriendsSpeed + SecondFriendsSpeed) * time;
    count++;
}

Console.WriteLine(count);



