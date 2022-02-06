using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1
{
    class StringDemo
    {
        private char[] c;
        public char[] C{
            get { return c; }
}
        public StringDemo(char[] c)
        {
            this.c = c;
        }
        public static bool Compare(StringDemo a, StringDemo b)
        {
            if (a == null || b == null || a.c.Length != b.c.Length)
            {
                return false;
            }
            for (int i = 0; i < a.c.Length; i++)
            {
                if (a.c[i] != b.c[i])
                {   
                    return false;
                }
            }
            return true;
        }
        public static StringDemo Concat(params StringDemo[] arr)
        {
            int n=0;
            foreach (var i in arr)
            {
                n += i.c.Length;
            }
            char[] c = new char[n];
            StringDemo a = new StringDemo(c);
            int j=0;
            foreach (var i in arr) while (j < n)
                {
                    for (int k = 0; k < i.c.Length; k++)
                    {
                        a.c[j] = i.c[k];
                        j++;
                        //Console.WriteLine(i.c);
                    }
                    break;
                }
            return a;
        }
        public static int Search(StringDemo s, char cc)
        {
            for (int i = 0; i < s.c.Length; i++)
            {
                if (s.c[i] == cc) return i + 1;
            }
            return -1;
        }
        public static int Search(StringDemo s, char cc, int start=1)
        {
            for (int i = start-1; i < s.c.Length; i++)
            {
                if (s.c[i] == cc) return i + 1;
            }
            return -1;
        }
        public static char[] StrDToCharArr(StringDemo s){
            return s.c;
        }
        public StringDemo Replace(char c1,char c2) {
            for (int i = 0; i < this.c.Length; i++)if(this.c[i]==c1)this.c[i]=c2;
            return this;
        }
        public static int Count(StringDemo s, char cc)
        {
            int a=0;
            for (int i = 0; i < s.c.Length; i++) if (s.c[i] == cc) a++;
            return a;
        }
    }
}
