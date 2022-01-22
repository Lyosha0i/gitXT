using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Note
    {
        private char c = '♫';
        public bool IsCollected = false;
        private int x, y;
        //public char C { get; }
        //}
        public char C
        {
            get
            {
                return c;
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
                if (x >= 16 && x <= 35)
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
