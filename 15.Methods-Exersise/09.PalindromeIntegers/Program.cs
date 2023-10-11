namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            while (a != "END")
            {
                PalindromeCheck(a);
                a= Console.ReadLine();
            }
        }
        static void PalindromeCheck(string a)
        {
            char[] arr = a.ToCharArray();
            Array.Reverse(arr);
            string b = new string(arr);
            if(a==b) Console.WriteLine("true");
            else Console.WriteLine("false");
        }
    }
}