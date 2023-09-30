namespace _7.WaterOverflow
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int litters = 0;
            for (int i = 0; i <n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if(a<=255 && (litters + a) <=255)
                {
                    litters += a;
                }
                else if (a>255 || a+litters>255) Console.WriteLine("Insufficient capacity!");
            }
            Console.WriteLine(litters);
        }
    }
}