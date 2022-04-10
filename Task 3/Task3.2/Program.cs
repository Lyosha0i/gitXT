using System;
using System.Collections.Generic;

namespace Task3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<byte> da = new DynamicArray<byte>();
            for (byte i = 0; i < 8; i++)
                da.Add(i);
            da.Add(16);
            List<byte> test=new List<byte>(){1,1,1,1,1,1,1,1,1,1,1,1};
            da.AddRange(test);
            List<byte> test2 = new List<byte>();
            for (int i = 0; i < 11; i++) test2.Add(2);
            da.AddRange(test2);
            List<byte> test3 = new List<byte>();
            for (int i = 0; i < 32; i++) test3.Add(3);
            da.AddRange(test3);
            da.Insert(32,32);
            foreach (var i in da) Console.WriteLine(i);
            DynamicArray<byte> da2 = da;
        }
    }
}
