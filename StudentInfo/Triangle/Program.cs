int num = int.Parse(Console.ReadLine());
for (int i = 1; i < num+1; i++)
{
    for (int j = 0; j < i; j++)
    {
        Console.Write(i);
        Console.Write(" ");
    }
    Console.WriteLine();
}
