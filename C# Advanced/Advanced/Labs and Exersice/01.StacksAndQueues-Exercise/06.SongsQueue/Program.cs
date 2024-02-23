namespace _06.SongsQueue
{
    internal class Program
    {
        /*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play
         */
        static void Main(string[] args)
        {
            string[] firstSongs = Console.ReadLine()
                .Split(", ")
                .ToArray();
            var queue = new Queue<string>(firstSongs);
            string comm = Console.ReadLine();
            while (queue.Any())
            {
                string[] arr = comm
                    .Split(" ", 2)
                    .ToArray();
                string command = arr[0];
                if (command == "Add")
                {
                    string song = arr[1];
                    if (queue.Contains(song))
                    {
                        Console.WriteLine(song + " is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                comm = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}