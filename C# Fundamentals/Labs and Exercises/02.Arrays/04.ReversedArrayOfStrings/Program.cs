namespace _04.ReversedArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string[] arr = a.Split(' ');
            string[] reversed = new string[arr.Length];
            int b = 0;
            for (int i = arr.Length-1; i >= 0; i--)
            {
                reversed[b] =arr[i];
                b++;
            }
            for (int i = 0; i < reversed.Length; i++)
            {
                Console.Write(reversed[i]+" ");
            }
        }
    }
}