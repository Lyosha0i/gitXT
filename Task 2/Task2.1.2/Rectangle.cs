using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Rectangle:Square
    {
        public Rectangle(Point point1,Point point2) : base(point1,point2)
        { }
            public override double Perimeter
        { get { return (a1.Perimeter + b1.Perimeter) * 2; } }
        public override double Area
        { get { return a1.Perimeter * b1.Perimeter; } }
    }
    }
