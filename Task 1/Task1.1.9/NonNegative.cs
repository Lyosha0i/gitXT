using System;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum=0;
            int[] a = new int[n];
            Random r = new Random();
            for (int i = 0; i < a.Length; i++){
                a[i]=r.Next(-10,10);
                if (a[i] > 0) sum += a[i];
                }
            for (int i = 0; i < a.Length; i++) Console.Write("{0} ",a[i]);
            Console.WriteLine("\n{0}",sum);
        }
    }
}
