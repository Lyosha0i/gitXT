using System;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string str = "Загрузка символов пропущена. Модуль оптимизирован, включен параметр отладчика Только мой код.";
            char[] div = { ' ', ',', '.' };
            string[] result = str.Split(div);
            int len = result.Length;
            int sum = 0;
            for (int i = 0; i < result.Length; i++) {
                if (result[i].Length == 0) len--;
                sum += result[i].Length;
            };
            Console.WriteLine((double)sum/(double)len);//Not rounded.
        }
    }
}
