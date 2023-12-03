int player = 0;
int total = 0;

int target;
int min;
int max;

Console.WriteLine("Input your target number");
var targetString = Console.ReadLine();

while (!int.TryParse(targetString, out target) || target <= 3)
{
    Console.WriteLine($"Please input a number greater than two.");

    targetString = Console.ReadLine();
}

Console.WriteLine("Input your minimum choice");
var minString = Console.ReadLine();

while (!int.TryParse(minString, out min) || min >= target - 1 || min <= 0)
{
    Console.WriteLine($"Please input a number greater than zero and at least two below the target.");

    minString = Console.ReadLine();
}

Console.WriteLine("Input your maximum choice");
var maxString = Console.ReadLine();

while (!int.TryParse(maxString, out max) || max <= min || max >= target)
{
    Console.WriteLine($"Please input a number more than the minimum and less than the target.");

    maxString = Console.ReadLine();
}

Console.WriteLine($"Choose a number from {min} to {max} your goal is to get to the number {target} if you go over {target} you loose!");

while (total < target)
{
    player++;

    if (player == 4)
    {
        player = 1;
    }

    Console.WriteLine("Player " + player + "s turn");

    if (player == 3)
    {
        if (target - max < total)
        {
            total = target;
        }
        else
        {
            var rnd = new Random();

            total += rnd.Next(min, max);
        }
    }
    else
    {
        var inputString = Console.ReadLine();
        int input;

        while (!int.TryParse(inputString, out input) || input < min || input > max)
        {
            Console.WriteLine($"Please input a nuber between {min} and {max}.");

            inputString = Console.ReadLine();
        }

        total += input;
    }

    Console.WriteLine("The total is now " + total);
}

if (total == target)
{
    Console.WriteLine("player " + player + " wins");
}
else if (total > target)
{
    Console.WriteLine("no one wins you went bust");
}