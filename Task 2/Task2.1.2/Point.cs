using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._1._2
{
    class Point
    {
        private int x, y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
