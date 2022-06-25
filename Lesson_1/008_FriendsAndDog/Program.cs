int firstFriendsSpeed = 2,
    secondFriendsSpeed = 3,
    dogSpeed = 5,
    count = 0;

double distance = 10000, time = 0;

int directionDog = 1; // 1 - от первого ко второму, 2 - от второго к первому

while (distance > 2)
{   
        
    if (directionDog == 1)
    {
        time = distance / (secondFriendsSpeed + dogSpeed);
        directionDog = 2;
    }
    else
    {
        time = distance / (firstFriendsSpeed + dogSpeed);
        DirectionDog = 1;
    }

    distance = distance - (firstFriendsSpeed + secondFriendsSpeed) * time;
    count++;
}

Console.WriteLine("Собака пробежала между друзьями " + count + " раз");
