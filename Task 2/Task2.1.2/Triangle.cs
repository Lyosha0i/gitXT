using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Triangle:Figure
    {
        private Point point1,point2,point3;
        private Line a,b,c;
        public Point Point1
        {
            get { return point1; }
            set { if (value.X >= 0 && value.Y >= 0) point1= value; }
        }
        public Point Point2
        {
            get { return point2; }
            set { if (value.X >= 0 && value.Y >= 0) point2 = value; }
        }
        public Point Point3
        {
            get { return point3; }
            set { if (value.X >= 0 && value.Y >= 0) point3= value; }
        }
        //public int X1
        //{
        //    get { return x1; }
        //    set { if (x1 >= 0) x1 = value; }
        //}
        //public int X2
        //{
        //    get { return x2; }
        //    set { if (x2 >= 0) x2 = value; }
        //}
        //public int X3
        //{
        //    get { return x3; }
        //    set { if (x3 >= 0) x3 = value; }
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
        //public int Y3
        //{
        //    get { return y3; }
        //    set { if (y3 >= 0) y3 = value; }
        //}
        public Triangle(Point point1, Point point2, Point point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
            Line a = new Line(point1,point2);
            Line b = new Line(point2, point3);
            Line c = new Line(point3, point1);
        }
        public override double Perimeter
        { get {return a.Perimeter+b.Perimeter+c.Perimeter;} }
        public override double Area 
        {
            get 
            {return Math.Sqrt(this.Perimeter*0.5*(this.Perimeter * 0.5 - a.Perimeter)*
                (this.Perimeter * 0.5 - b.Perimeter)*(this.Perimeter * 0.5 - c.Perimeter));} }
        public override string ToString()
        {
            return base.ToString().Remove(0,12)+ ": (" + point1.X + ";" + point1.Y + "), (" + point2.X + ";" + point2.Y + "), (" + point3.X + ";" + point3.Y + ")";
        }
    }
}
