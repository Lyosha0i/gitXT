using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Sort(int[] a)
        {
            int min,index,i,j;
            for (i = 0; i <=a.Length-1; i++)
            {
                index = i;
                min = a[i];
                for (j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        index = j;
                    }
                }
                a[index] = a[i];
                a[i] = min;
            }
        }
        //public static void Font()
        //{
        //    //Console.WriteLine("Параметры надписи:\n");
        //}
        static void Main(string[] args)
        {
            int[] a = new int[10];
            Random r = new Random();
            for (int i = 0; i <= a.Length-1; i++) a[i] = r.Next(10);
            for (int i = 0; i <= a.Length-1; i++) Console.Write("{0} ", a[i]);
            Sort(a);
            Console.WriteLine();
            for (int i = 0; i <= a.Length-1; i++) Console.Write("{0} ", a[i]);
            Console.WriteLine("\n{0} {1}",a[0],a[a.Length-1]);
        }
    }
}
