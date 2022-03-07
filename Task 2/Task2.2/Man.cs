using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Man:GameObject
    {
        private char left = 'M', right = 'm';
        public bool IsLeft = false, IsProtected = false;
        private byte x = 0, y = 28;
        public Man(Point point) : base(point)
        {

        }
        public  char Left
        {
            get
            {
                return left;
            }
        }
        public  char Right
        {
            get
            {
                return right;
            }
        }
        //public  byte X
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
        //public  byte Y
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
        private  byte lives = 3;
        public  byte Lives
        {
            get
            {
                return lives;
            }
            set
            {
                if (lives > 0)//Not (lives>=0)!
                    lives = value;
            }
        }
    }
}
