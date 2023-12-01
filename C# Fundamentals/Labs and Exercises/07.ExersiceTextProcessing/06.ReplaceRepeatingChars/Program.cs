namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                list.Add(input[i].ToString());
            }
            for (int i = 0;i < list.Count-1; i++)
            {
                if (list[i] == list[i+1])
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
            foreach (string s in list)
            {
                Console.Write(s);
            }
        }
    }
}