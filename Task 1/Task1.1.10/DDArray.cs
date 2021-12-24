using System;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum=0;
            int[,] a = new int[n,n];
            Random r = new Random();
            for (int i = 0; i < a.GetLength(0); i++) for (int j = 0; j < a.GetLength(1); j++) a[i, j] = r.Next(10);
            for (int i = 0; i < a.GetLength(0); i++) {
                for (int j = 0; j < a.GetLength(1); j++) Console.Write("{0} ",a[i,j]);
                Console.WriteLine();
                }
            for (int i = 0; i < a.GetLength(0); i++) for (int j = 0; j < a.GetLength(1); j++) if ((i + j) % 2 == 0) sum += a[i, j];
                    Console.WriteLine(sum);
        }
    }
}
