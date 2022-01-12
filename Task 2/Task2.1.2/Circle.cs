using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Circle:Figure
    {
        protected int x, y,r;
        //protected int r;
        public int X {
            get{return x;}
            set{ if (x >= 0) x =value;}
        }
        public int Y
        {
            get { return y; }
            set { if (y >= 0) y = value; }
        }
        public int Radius
        {
            get { return r; }
            set { if (r >= 0) r = value; }
        }
        public Circle(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        override public double Perimeter
        {
            get { return 2*Math.PI*Radius; }
        }
        override public double Area
        {
            get { return Math.PI*Radius*Radius; }
        }
        public override string ToString()
        {
            return base.ToString().Remove(0,12)+": (" + x + ";" + y + "), radius=" + r;
        }
    }
}
