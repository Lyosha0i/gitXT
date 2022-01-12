using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Triangle:Figure
    {
        private int x1, x2, x3, y1, y2, y3;
        private Line a,b,c;
        public int X1
        {
            get { return x1; }
            set { if (x1 >= 0) x1 = value; }
        }
        public int X2
        {
            get { return x2; }
            set { if (x2 >= 0) x2 = value; }
        }
        public int X3
        {
            get { return x3; }
            set { if (x3 >= 0) x3 = value; }
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
        public int Y3
        {
            get { return y3; }
            set { if (y3 >= 0) y3 = value; }
        }
        public Triangle(int x1,int y1,int x2,int y2,int x3,int y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            Line a = new Line(x1, y1, x2, y2);
            Line b = new Line(x2, y2, x3, y3);
            Line c = new Line(x3, y3, x1, y1);
        }
        public override double Perimeter
        { get {return a.Perimeter+b.Perimeter+c.Perimeter;} }
        public override double Area { get {return Math.Sqrt(this.Perimeter*0.5*(this.Perimeter * 0.5 - a.Perimeter)*(this.Perimeter * 0.5 - b.Perimeter)*(this.Perimeter * 0.5 - c.Perimeter));} }
        public override string ToString()
        {
            return base.ToString().Remove(0,12)+ ": (" + x1 + ";" + y1 + "), (" + x2 + ";" + y2 + "), (" + x3 + ";" + y3 + ")";
        }
    }
}
