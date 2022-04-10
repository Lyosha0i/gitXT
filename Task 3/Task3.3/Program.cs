using System;
using static Task3._3.SuperArray;

namespace Task3._3
{
    delegate int Operation(int[] ints);
    class Program
    {
        //delegate int Operation(int[] ints);
        static void Main(string[] args)
        {
            //Console.WriteLine("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz".CharCount('z'));
            int[] days = new int[366];
            for (int i = 0; i < 366; i++) for (int j = 1; j <= 12; j++) for (int k = 1; k <= DateTime.DaysInMonth(2004, j); k++)
                    {
                        days[i] = k;
                        if (i % 2 == 0) days[i] = 32;
                        i++;
                    }
            Console.WriteLine(days.Mode());
            Operation Sum = SuperArray.IntsSum;//Delegates
            int result = Sum(days);
            Console.WriteLine(result);
            Operation Mode = SuperArray.Mode;
            result = Mode(days);
            Console.WriteLine(result);//         Delegates
        }
    }
}
