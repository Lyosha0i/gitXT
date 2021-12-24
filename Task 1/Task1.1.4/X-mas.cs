using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Triangle(int n)
        {
            for (int i = 1; i <= n+1; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    for (int k = n - j; k >= 0; k--)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 1; k <= j; k++)
                    {
                        Console.Write("*");
                    }
                    for (int k = 1; k <= j - 1; k++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n=");
            int n = int.Parse(Console.ReadLine());
            Triangle(n);
            Console.ReadKey(true);
        }
    }
}
