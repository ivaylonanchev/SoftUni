namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if(MinCharactersRule(password)!=true &&
                LettersAndDigitsRule(password)!=true &&
                MinDigitsRule(password) != true) Console.WriteLine("Password is valid");

            if (MinCharactersRule(password) == true) Console.WriteLine("Password must be between 6 and 10 characters");
            if (LettersAndDigitsRule(password) == true) Console.WriteLine("Password must consist only of letters and digits");
            if (MinDigitsRule(password) == true) Console.WriteLine("Password must have at least 2 digits");
        }
        static bool MinCharactersRule(string password)
        {
            if (password.Length <= 10 && password.Length >= 6) return false;
            else return true;
        }
        static bool LettersAndDigitsRule(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i])) return true;
            }
            return false;
        }
        static bool MinDigitsRule(string password)
        {
            int a = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if ((char.IsDigit(password[i]))) a++;
            }
            if (a >= 2) return false;
            else return true;
        }
    }
}