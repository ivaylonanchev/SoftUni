namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> secondDeck = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            while (firstDeck.Count > 0 && secondDeck.Count > 0)
            {
                if (firstDeck[0] > secondDeck[0])
                {
                    firstDeck.Add(secondDeck[0]);
                    firstDeck.Add(firstDeck[0]);
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
                else if(firstDeck[0] < secondDeck[0])
                {
                    secondDeck.Add(firstDeck[0]);
                    secondDeck.Add(secondDeck[0]);
                    secondDeck.RemoveAt(0);
                    firstDeck.RemoveAt(0);
                }
                else if(firstDeck[0] == secondDeck[0])
                {
                    firstDeck.RemoveAt(0);
                    secondDeck.RemoveAt(0);
                }
            }
            if(firstDeck.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstDeck.Sum()}");
            }
            else Console.WriteLine($"Second player wins! Sum: {secondDeck.Sum()}");
        }
    }
}