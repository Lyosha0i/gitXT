using System;

namespace Task3._3._2
{
    class Program
    {
        delegate int Operation(string word);
        static void Main(string[] args)
        {
            string word = "-32";
            Console.WriteLine(word.IsRussian());
            Console.WriteLine(word.IsEnglish());
            Console.WriteLine(word.IsNumber());
            Console.WriteLine(word.IsMix());
        }
    }
}
