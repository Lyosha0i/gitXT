using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Square(int a,int b)
        {
            if (a > 0 && b > 0) Console.WriteLine(a*b);
            else Console.WriteLine("Invalid");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a=");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter b=");
            int b = int.Parse(Console.ReadLine());
            Square(a,b);
        }
    }
}
