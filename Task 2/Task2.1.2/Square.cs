using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Square:Figure
    {
        protected int x1, x2, y1, y2;
        protected Line a1,a2,b1,b2;
        public int X1
        {
            get { return x1; }
            set { if(x1>=0)x1 = value; }
        }
        public int X2
        {
            get { return x2; }
            set { if (x2 >= 0) x2 = value; }
        }
        public int Y1
        {
            get { return y1; }
            set { if (y1 >= 0) y1 = value; }
        }
        public int Y2
        {
            get { return y2; }
            set { if (y2 >= 0) y2 = value; }
        }
        public Square(int x1,int y1,int x2,int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            Line a1 = new Line(x1,y1,x2,y1);
            Line a2 = new Line(x1, y2, x2, y2);
            Line b1 = new Line(x1, y1, x1, y2);
            Line b2 = new Line(x2, y1, x2, y2);
        }
        public override double Perimeter
        { get {return a1.Perimeter*4;} }
        public override double Area
        { get { return a1.Perimeter*a1.Perimeter; } }
        public override string ToString()
        {
            return base.ToString().Remove(0,12)+": (" + x1 + ";" + y1 + "), (" + x2 + ";" + y1 + ")"+", (" + x1 + ";" + y2 + "), (" + x2 + ";" + y2 + ")";
        }
    }
}
