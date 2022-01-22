using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    static class Man
    {
        private static char left = 'M', right = 'm';
        public static bool IsLeft = false, IsProtected = false;
        private static byte x = 0, y = 28;
        public static char Left
        {
            get
            {
                return left;
            }
        }
        public static char Right
        {
            get
            {
                return right;
            }
        }
        public static byte X
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
        public static byte Y
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
        private static byte lives = 3;
        public static byte Lives
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
