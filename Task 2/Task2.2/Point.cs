using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
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
                if (x >= 0 && x <= 39)
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
                if (y >= 0 && y <= 28)
                    y = value;
            }
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
