namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> username = Console.ReadLine()
                .Split(", ")
                .ToList();
            foreach (string user in username)
            {
                int n = 0;
                if (user.Length >= 3 && user.Length <= 16)
                {
                    for (int i = 0; i < user.Length; i++)
                    {
                        if (!char.IsLetterOrDigit(user[i]) && user[i] != '-' && user[i] != '_')
                        {
                            n++;
                            break;
                        }
                    }
                    if (n == 0)
                    {
                        Console.WriteLine(user);
                    }
                }
                
            }
        }
    }
}