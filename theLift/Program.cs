int peopleWaiting = int.Parse(Console.ReadLine()); 

int[] lift = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int maxPeoplePerWagno = 4;

for (int i = 0; i < lift.Length; i++)
{
    int current = lift[i];
    for (int j = current; j < maxPeoplePerWagno; j++)
    {
        lift[i]++;
        peopleWaiting--;

        if (peopleWaiting==0)
        {
            if (lift.Sum() < lift.Length * maxPeoplePerWagno)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            
            Console.WriteLine(string.Join(' ', lift));
            return;
        }
    }
}
Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
Console.WriteLine(string.Join(' ',lift));