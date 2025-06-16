List<int> targets = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

string command = string.Empty;

while ((command=Console.ReadLine())!="End")
{
    string[] tokens = command.Split();

    string action = tokens[0];
    int index = int.Parse(tokens[1]);

    switch (action)
    {
        case "Shoot":
            int power = int.Parse(tokens[2]);
            Shoot(index,power,targets);
            break;

        case "Add":
            int value = int.Parse(tokens[2]);
            Add(index,value,targets);
            break;

        case "Strike":
            int radius = int.Parse(tokens[2]);
            strike(index, radius, targets);
            break;
    }
}

static void Shoot(int index, int power, List<int> targets)
{
    if (index<0||index>targets.Count-1)
    {
        return;
    }

    targets[index] -= power;

    if (targets[index]<=0)
    {
        targets.RemoveAt(index);
    }
}

static void Add(int index, int value, List<int> targets)
{
    if (index < 0 || index > targets.Count - 1)
    {
        Console.WriteLine("Invalid placement!");
        return;
    }

    targets.Insert(index,value);
}

static void strike(int index, int radius, List<int> targets)
{
    if (index - radius < 0 || index + radius > targets.Count - 1)
    {
        Console.WriteLine("Strike missed!");

        return;
    }
    targets.RemoveRange(index-radius,radius*2+1);
}

Console.WriteLine(string.Join("|",targets));