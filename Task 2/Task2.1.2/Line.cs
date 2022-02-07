using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Line:Figure
    {
        private Point startPoint;
        private Point endPoint;

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
        public override double Perimeter
        { get {return Math.Sqrt((x2-x1)+(y2-y1));} }
        public override double Area
        { get { return this.Perimeter; } }
        public override string ToString()
        {
            return base.ToString().Remove(0,12)+": ("+x1+";"+y1+"), (" + x2 + ";" + y2+")";
        }
        public Line(int x1,int y1,int x2,int y2)
        {
            this.x1=x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }
}
