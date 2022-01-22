using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Obstacle
    {
        private char[] tree = {'O','Y'};
        private char laser = 'I';
        private int x=16, y;
        public char this[int i]
        {
            get 
            {
                if (i == 0 || i == 1)
                    return tree[i];
                else return laser;
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
