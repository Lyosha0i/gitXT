using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Rectangle:Square
    {
        public Rectangle(int x1, int y1, int x2, int y2):base(x1,y1,x2,y2)
        {
            //Line a1 = new Line(x1, y1, x2, y1);
            //Line a2 = new Line(x1, y2, x2, y2);
            //Line b1 = new Line(x1, y1, x1, y2);
            //Line b2 = new Line(x2, y1, x2, y2);
        }
    }
}
