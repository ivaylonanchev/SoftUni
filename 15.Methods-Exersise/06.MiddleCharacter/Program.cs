namespace _06.MiddleCharacter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] arr = new string[a.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                string b = a[i].ToString();
                arr[i] = b;
            }
            Console.WriteLine(MiddleCharacters(arr));
            static string MiddleCharacters(string[] arr)
            {
                string middleNum = "";
                if (arr.Length % 2 == 0)
                {
                    middleNum += arr[(arr.Length / 2) - 1] + arr[arr.Length / 2];
                }
                else
                {
                    middleNum = arr[arr.Length / 2];
                }
                return middleNum;
            }
        }
    }
}