namespace _6.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char a = (char)(n + 96);
            for (int i = 97; i <n+97 ; i++)
            {
            
                for (int j = 97; j < n+97; j++)
                {
                    for (int k = 97; k < n+97; k++)
                    {
                        Console.Write((char)i);
                        Console.Write((char)j);
                        Console.Write((char)k);
                        Console.WriteLine("");
                    }
                    
                }
            }
        }
    }
}