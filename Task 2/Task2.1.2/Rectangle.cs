using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Rectangle:Square
    {
        public Rectangle(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        { }
            public override double Perimeter
        { get { return (a1.Perimeter + b1.Perimeter) * 2; } }
        public override double Area
        { get { return a1.Perimeter * b1.Perimeter; } }
    }
    }
