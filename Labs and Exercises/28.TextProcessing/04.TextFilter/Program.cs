namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();
            string text = Console.ReadLine();
            for (int i = 0; i < list.Count; i++)
            {
                string star = "";
                for (int j = 0; list[i].Length > j; j++)
                {
                    star += "*";
                }
                while (text.Contains(list[i]))
                {
                    
                    text = text.Replace(list[i], star);
                }
            }
            Console.WriteLine(text);
        }
    }
}