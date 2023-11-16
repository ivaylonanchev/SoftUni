namespace _05.Digits_LethersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string all = Console.ReadLine();

            string digits = "";
            string letters = "";
            string others = "";

            foreach(char c in all)
            {
                if (char.IsDigit(c))
                {
                    digits += c;
                }
                else if(char.IsLetter(c))
                {
                    letters += c;
                }
                else
                {
                    others += c;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}