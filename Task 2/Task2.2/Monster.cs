using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Monster:GameObject
    {
        char left, right;
        public char Left { get;}
        public char Right { get;}
        public Monster(Point point) : base(point)
        {

        }
    }
}
