using System;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string str = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звёздные Войны";
            char[] div = { ' ', ',', ':' };
            string[] result = str.Split(div);
            int sum = 0;
            for (int i = 0; i < result.Length; i++)if(result[i]!=""&&char.IsLower(result[i][0]))sum++;
            Console.WriteLine(sum);
        }
    }
}
