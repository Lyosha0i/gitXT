using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Shield:GameObject
    {
        private char c = 'D';
        public bool IsCollected = false,IsDamaged=false;
        private int x, y;
        public char C
        {
            get
            {
                return c;
            }
        }
        public Shield(Point point) : base(point)
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
        //        if (y==14)
        //            y = value;
        //    }
        //}
    }
}
