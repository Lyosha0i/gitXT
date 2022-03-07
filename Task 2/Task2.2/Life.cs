using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Life:GameObject
    {
        private char c ='L';
        public bool IsCollected = false;
        private int x, y;
        public char C
        {
            get
            {
                return c;
            }
        }
        public Life(Point point) : base(point)
        {

        }
        //public char C { get; }
        //public int X
        //{
        //    get
        //    {
        //        return x;
        //    }
        //    set
        //    {
        //        if (x >= 0 && x <= 39)
        //            x = value;
        //    }
        //}
        //public int Y
        //{
        //    get
        //    {
        //        return y;
        //    }
        //    set
        //    {
        //        if (y >= 0 && y <= 28)
        //            y = value;
        //    }
        //}
    }
}
