using System.Formats.Asn1;

namespace Problem5.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int shotTargets = 0;
            string indice = Console.ReadLine();
            while (indice != "End")
            {
                int index = int.Parse(indice);
                if (index < targets.Count)
                {
                    if (targets[index] != -1)
                    {
                        ReduceAndIncrease(targets, index);
                        shotTargets++;
                    }
                }
                indice = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> " + string.Join(" ",targets));

        }
        static void ReduceAndIncrease (List<int> targets, int index)
        {
            int num = targets[index];
            for (int i = 0; i < targets.Count; i++)
            {
                if (targets[i] != -1)
                {
                    if (targets[i] <= num) targets[i] += num;
                    else targets[i] -= num;
                }
            }
            targets[index] = -1;
        }
    }
}