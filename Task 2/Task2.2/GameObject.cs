using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    abstract class GameObject
    {
        public Point point { get; set; }
        public char left { get; set; }
        public char right { get; set; }
        public GameObject(Point point)
        {
            this.point = point;
        }
    }
}
