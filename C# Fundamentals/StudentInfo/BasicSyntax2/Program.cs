using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BasicSyntax2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            
            int allsum = 0;
            for (int i = 0; i < num.Length ; i++)
            {
                int sum = 1;
                int currentnum = int.Parse(num[i].ToString());
                for (int j = 1; j <= currentnum; j++)
                {
                    sum *= j;
                }
                allsum += sum;
            }
            if(allsum == int.Parse(num))
            {
                Console.WriteLine("yes");
            }
            else Console.WriteLine("no");

        }
    }

}