using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Task3._3
{
    static class SuperArray
    {
        //delegate int Operation(int[] ints);
        public static void ActionSeries(this int[] ints)
        {
            for (int i = 0; i<ints.Length; i++)
            {
                Console.WriteLine(ints[i]);
            }
        }
        public static int IntsSum(this int[] ints)
        {
            return ints.Sum();
        }
        public static double IntsAverage(this int[] ints)
        {
            return ints.Average();
        }
        public static int Mode(this int[] ints)
        {
            return ints.GroupBy(value => value)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .First();
        }
    }
}
