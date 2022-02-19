using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Line : Figure
    {
        private Point startPoint;
        private Point endPoint;
        public Point StartPoint
        {
            get { return startPoint; }
            set { if (value.X >= 0 && value.Y >= 0) startPoint = value; }
        }
        public Point EndPoint
        {
            get { return endPoint; }
            set { if (value.X >= 0 && value.Y >= 0) endPoint = value; }
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
        public override double Perimeter
        { get { return Math.Sqrt((EndPoint.X - StartPoint.X) + (EndPoint.Y - StartPoint.Y)); } }
        public override double Area
        { get { return this.Perimeter; } }
        public override string ToString()
        {
            return base.ToString().Remove(0, 12) + ": (" + StartPoint.X + ";" + StartPoint.Y + "), (" + EndPoint.X + ";" + EndPoint.Y + ")";
        }
        public Line(Point start, Point end)
        {
            startPoint = start;
            endPoint = end;
        }
    }
}