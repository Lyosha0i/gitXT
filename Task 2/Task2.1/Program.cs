using System;
using System.Text;

namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=0;
            char[] c=new char[8];
            ConsoleKeyInfo input;
            Console.WriteLine("Enter a string");
            //input = Console.ReadKey(true); //input.Key.ToString()
            //while (true)
            //{
                //Console.ReadKey();
                do
                {
                    input = Console.ReadKey();
                    if(input.Key != ConsoleKey.Enter) c[i] = input.KeyChar;
                i++;
            }
                while (input.Key != ConsoleKey.Enter);
                //break;
            //}
            StringDemo test = new StringDemo(c);
            //StringBuilder a = new StringBuilder("asdConsole.WriteLine(test.c.ToString());");
            //string b = "asdConsole.WriteLine(test.c.ToString());";
            //Console.WriteLine(test.c.Length);
            Console.WriteLine("Result: ");
            for (i = 0; i < test.C.Length; i++)Console.Write(test.C[i]);
            StringDemo s = new StringDemo(c);
            char[] c2 = { '7', '7', '7', '1', '6', '2', '1', '6' };
            char[] c3 = { '1', '6', '7', '7', '7', '2', '1', '6' };
            StringDemo s2 = new StringDemo(c);
            Console.WriteLine();
            Console.WriteLine(s.C);
            Console.WriteLine();
            c = new char[]{ '1', '6', '7', '7', '7', '2', '1', '6' };
            s2 =new StringDemo(c2);
            StringDemo s3 = new StringDemo(c3);
            Console.WriteLine(StringDemo.Compare(s,s2));
            Console.WriteLine(StringDemo.Compare(s, s3));
            Console.WriteLine(StringDemo.Concat(s,s2,s3).C);
            Console.WriteLine(StringDemo.Search(s,'2'));
            Console.WriteLine(StringDemo.Search(s, '7',4));
            Console.WriteLine(StringDemo.Search(s, '1', 8));
            c = StringDemo.StrDToCharArr(s);
            Console.WriteLine(c);
            s = s.Replace('7', '0');
            Console.WriteLine(s.C);
            Console.WriteLine(StringDemo.Count(s,'0'));
            Console.WriteLine("♫");
        }
    }
}
