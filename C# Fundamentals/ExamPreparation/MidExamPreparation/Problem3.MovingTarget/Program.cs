namespace Problem3.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string com = Console.ReadLine();
            while (com != "End")
            {
                string[] arr = com.Split(' ');
                string firstCommand = arr[0];
                string a = arr[1];
                int secondCommand = int.Parse(a);
                string b = arr[2];
                int thirdCommand = int.Parse(b);

                if (firstCommand == "Shoot")
                {
                    Shoot(targets, secondCommand, thirdCommand);
                }
                else if (firstCommand == "Add")
                {
                    Add(targets, secondCommand, thirdCommand);
                }
                else if (firstCommand == "Strike")
                {
                    Strike(targets, secondCommand, thirdCommand);
                }

                com = Console.ReadLine();
            }
            for (int i = 0; i < targets.Count-1; i++)
            {
                Console.Write(targets[i] + "|");
            }
            Console.Write(targets[targets.Count-1]);
        }
        static void Shoot(List<int> targets, int index, int power)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets[index] -= power;
            }
            if (targets[index] <= 0) targets.RemoveAt(index);
        }
        static void Add(List<int> targets, int index, int value)
        {
            if (index >= 0 && index < targets.Count)
            {
                targets.Insert(index, value);
            }
            else Console.WriteLine("Invalid placement!");
        }
        static void Strike(List<int> targets, int index, int radius)
        {
            if (index >= 0 && index < targets.Count)
            {
                List<int> result = new List<int>();
                foreach (int target in targets)
                {
                    {
                        result.Add(target);
                    }
                }
                int n = 1;
                int m = 1;
                bool p = false;
                for (int i = 0; i < radius; i++)
                {
                    if (n <= 0 || m >= targets.Count || index == 0)
                    {
                        Console.WriteLine("Strike missed!");
                        targets.Clear();
                        foreach (int res in result)
                        {
                            targets.Add(res);
                        }
                        p = true;
                        break;
                    }
                    targets.RemoveAt(index + m);
                    targets.RemoveAt(index - n);

                    n--;

                }
                if (p == false)
                {
                    targets.RemoveAt(index - radius);
                }
            }
        }
    }
}