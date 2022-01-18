using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void PrintLayer(int[,,] a,int layer) {
            for (int i = 0; i < a.GetLength(0); i++)
            { 
                for (int j = 0; j < a.GetLength(1); j++)Console.Write("{0} ", a[i, j, layer]);
            Console.WriteLine();
}
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[,,] a = new int[3,3,3];
            Random r = new Random();
            for (int i = 0; i < a.GetLength(0); i++)for(int j = 0; j < a.GetLength(1); j++)for(int k = 0; k < a.GetLength(2); k++) a[i,j,k] = r.Next(-10,10);
            for (int i = 0; i < 3; i++) PrintLayer(a,i);
            for (int i = 0; i < a.GetLength(0); i++) for (int j = 0; j < a.GetLength(1); j++) for (int k = 0; k < a.GetLength(2); k++) if (a[i, j, k] > 0) a[i, j, k] = 0;
            for (int i = 0; i < 3; i++) PrintLayer(a, i);
        }
    }
}
