using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Triangle(int n)
        {
            for (int i = 1; i <= n; i++){
                for (int j = n - i; j >= 1; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                for (int j = 1; j <=i-1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

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
