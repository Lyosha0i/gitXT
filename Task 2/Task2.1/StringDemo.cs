using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1
{
    class StringDemo
    {
        private char[] charArray;
        public char[] CharArray{
            get { return charArray; }
}
        public StringDemo(char[] c)
        {
            this.charArray = c;
        }
        public static bool Compare(StringDemo a, StringDemo b)
        {

            if (a.charArray.Length != b.charArray.Length)
                return false;
            for (int i = 0; i < a.charArray.Length; i++)
                if (a.charArray[i] != b.charArray[i])
                    return false;

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

                n+=i.charArray.Length;

            {
                n += i.c.Length;
            }

            char[] c = new char[n];
            StringDemo a = new StringDemo(c);
            int j=0;
            foreach (var i in arr)
                while (j < n)
                {
                    for (int k = 0; k < i.charArray.Length; k++)
                    {
                        a.charArray[j] = i.charArray[k];
                        j++;
                        //Console.WriteLine(i.c);
                    }
                    break;
                }
            return a;
        }
        public static int Search(StringDemo s, char cc)
        {
            for (int i = 0; i < s.charArray.Length; i++)
            {

                if (s.charArray[i] == cc)
                    return i + 1;

                if (s.c[i] == cc) 
                {
                    return i + 1;
                }

            }
            return -1;
        }
        public static int Search(StringDemo s, char cc, int start=1)
        {
            for (int i = start-1; i < s.charArray.Length; i++)
            {

                if (s.charArray[i] == cc)
                    return i + 1;
            }
            return -1;
        }
        public static char[] StrDToCharArr(StringDemo s){
            return s.charArray;

                if (s.c[i] == cc) 
                {
                    return i + 1;
                }
            }
            return -1;
        }
        public static char[] StrDToCharArr(StringDemo s)
        {
            return s.c;

        }
        public StringDemo Replace(char c1,char c2) {
            for (int i = 0; i < this.charArray.Length; i++)
                if(this.charArray[i]==c1)
                    this.charArray[i]=c2;
            return this;
        }
        public static int Count(StringDemo s, char cc)
        {
            int a=0;
            for (int i = 0; i < s.charArray.Length; i++)
                if (s.charArray[i] == cc)
                    a++;
            return a;
        }
    }
}
