using System;

namespace ConsoleApp1
{
    class Program
    {
        public static void Settings(ref bool bold, ref bool italic, ref bool underline, ref bool comma)
        {
            Console.WriteLine("Параметры надписи: ");
            if (bold == false && italic == false && underline == false) Console.Write("None");
            else
            {
                if (bold == true)
                {
                    Console.Write("Bold");
                    comma = true;
                };
                if (italic == true)
                {
                    if (comma == true) Console.Write(", ");
                    Console.Write("Italic");
                    comma = true;
                };
                if (underline == true)
                {
                    if (comma == true) Console.Write(", ");
                    Console.Write("Underline");
                    comma = true;
                };
            };
        }
        public static void Property(ref byte property, ref bool bold, ref bool italic, ref bool underline)
        {
            switch (property)
            {
                case 1:
                    {
                        bold = !bold;
                        //Font();
                        break;
                    }
                case 2:
                    {
                        italic = !italic;
                        //Font();
                        break;
                    }
                case 3:
                    {
                        underline = !underline;
                        //Font();
                        break;
                    }
            }
        }
            static void Main(string[] args)
            {
                bool bold = false; bool italic = false; bool underline = false;
                bool comma;
                //Font();
                while (true)
                {
                    comma = false;
                    Settings(ref bold, ref italic, ref underline, ref comma);
                    Console.WriteLine("\nВведите:\n\t1:Bold\n\t2:Italic\n\t3:Underline");
                    byte property = byte.Parse(Console.ReadLine());
                    Property(ref property, ref bold, ref italic, ref underline);
                    //default:
                    //    {
                    //        //Font();
                    //        break;
                    //    }
                }
            }
        }
    }
