using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Eloquent
    {
        public static void All()
        {
            var stacktrace = new StackTrace();
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();

            Console.WriteLine($"Вызывающий класс: {method.ReflectedType.Name}");
        }
    }
}
