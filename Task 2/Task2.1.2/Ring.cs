using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Ring:Circle
    {
        private new int r = 2;
        private int r2=1;
        private Circle circle2;
        public new int Radius
        {
            get { return r; }
            set { if (r-r2 >0) r = value; }
        }
        public int Radius2
        {
            get { return r2; }
            set { if (r2>0&&r-r2 >0) r2 = value; }
        }
        public Ring(int x, int y, int r, int r2):base(x,y,r)
        {
            //Circle circle1 = new Circle(x, y, r);
            Circle circle2 = new Circle(x, y, r2);
        }
        public new double Perimeter { get { return base.Perimeter+circle2.Perimeter; } }
        public new double Area { get{ return Math.PI*(r*r-r2*r2); } }
        public override string ToString()
        {
            return base.ToString().Remove(7,base.ToString().Length-7)+ x + ";" + y + "), outer radius=" + r + ", inner radius=" + r2;
        }
    }
}
