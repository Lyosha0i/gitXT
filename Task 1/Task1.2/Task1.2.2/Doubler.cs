using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "программу, которая удваивает в первой введённой строке все символы, принадлежащие второй введённой строке.";
            string s2 = "описание";
            string s = "";
            int i,j;
            for (i = 0; i < s1.Length; i++){
                for (j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        s += s1[i];
                        break;
                    }
                }
                s += s1[i];
                    }
            Console.WriteLine(s);
            Console.ReadKey(true);
        }
    }
}
