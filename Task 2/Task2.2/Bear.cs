using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Bear
    {
        private char left = 'B', right = 'b';
        public bool IsLeft,IsKilled=false;
        private int x, y;
        public char Left
            {
            get
            {
                return left;
            }
        }
        public char Right
        {
            get
            {
                return right;
            }
        }
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
    }
}
