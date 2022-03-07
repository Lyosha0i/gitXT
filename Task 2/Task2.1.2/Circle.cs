using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Circle:Figure
    {
        protected int r=1;
        protected Point center;
        public Point Center
        {
            get { return center; }
            set { if (value.X >= 0 && value.Y >= 0) center = value; }
        }
        //public int X {
        //    get{return x;}
        //    set{ if (x >= 0) x =value;}
        //}
        //public int Y
        //{
        //    get { return y; }
        //    set { if (y >= 0) y = value; }
        //}
        public int Radius
        {
            get { return r; }
            set { if (value >= 0) r = value; }
        }
        public Circle(Point center,int r)
        {
            this.center = center;
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
            return base.ToString().Remove(0,12)+": (" + center.X + ";" + center.Y + "), radius=" + r;
        }
    }
}
