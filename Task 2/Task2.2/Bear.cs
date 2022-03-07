using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Bear:Monster
    {
        private new char left = 'B', right = 'b';
        public bool IsLeft,IsKilled=false;
        private int x, y;
        public Bear(Point point) : base(point)
        {

        }
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
        //public static void Multiple(ref Bear bear)
        //{
        //    bear = new Bear
        //    {
        //        X = 0,
        //        Y = 0,
        //        IsKilled = false,
        //        IsLeft = false
        //    };
        //}

    }
}
