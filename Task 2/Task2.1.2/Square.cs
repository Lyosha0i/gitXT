using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Square:Figure
    {
        protected Point point1,point2;
        protected Line a1,a2,b1,b2;
        public Point Point1
        {
            get { return point1; }
            set { if (value.X >= 0 && value.Y >= 0) point1 = value; }
        }
        public Point Point2
        {
            get { return point2; }
            set { if (value.X >= 0 && value.Y >= 0) point2= value; }
        }
        //public int X1
        //{
        //    get { return x1; }
        //    set { if(x1>=0)x1 = value; }
        //}
        //public int X2
        //{
        //    get { return x2; }
        //    set { if (x2 >= 0) x2 = value; }
        //}
        //public int Y1
        //{
        //    get { return y1; }
        //    set { if (y1 >= 0) y1 = value; }
        //}
        //public int Y2
        //{
        //    get { return y2; }
        //    set { if (y2 >= 0) y2 = value; }
        //}
        public Square(Point point1,Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
            Line a1 = new Line(point1,new Point(point2.X,point1.Y));
            Line a2 = new Line(new Point(point1.X, point2.Y),point2);
            Line b1 = new Line(point1, new Point(point1.X, point2.Y));
            Line b2 = new Line(new Point(point2.X, point1.Y),point2);
        }
        public override double Perimeter
        { get {return a1.Perimeter*4;} }
        public override double Area
        { get { return a1.Perimeter*a1.Perimeter; } }
        public override string ToString()
        {
            return base.ToString().Remove(0,12)+
                ": (" + point1.X + ";" + point1.Y + "), (" + point2.X + ";" + point1.Y + ")"+
                ", (" + point1.X + ";" + point2.Y + "), (" + point2.X + ";" + point2.Y + ")";
        }
    }
}
