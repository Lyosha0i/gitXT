using System;
using System.Collections.Generic;
using System.Text;

namespace Task2._2
{
    class Obstacle:GameObject
    {
        private char[] tree = {'O','Y'};
        private char laser = 'I';
        //private int x=16, y;
        public char this[int i]
        {
            get 
            {
                if (i == 0 || i == 1)
                    return tree[i];
                else return laser;
            }
        }
        //public int X
        //{
        //    get
        //    {
        //        return x;
        //    }
        //    set
        //    {
        //        if (x >= 16 && x <= 35)
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
        public Obstacle(Point point):base(point)
        {

        }
        //private static void Obstacles(ref Obstacle[] obstacles)
        //{
        //    for (byte i = 0; i < obstacles.Length; i += 2)
        //    {
        //        Random r = new Random();
        //        int next1 = r.Next(16, 21);
        //        obstacles[i] = new Obstacle
        //        {
        //            X = next1,
        //            Y = i
        //        };
        //        int next2 = r.Next(31, 36);
        //        obstacles[i + 1] = new Obstacle
        //        {
        //            X = next2,
        //            Y = i
        //        };
        //        int next3 = r.Next(0, 3);
        //        GameStrings.game[i][next1] = obstacles[i][next3];
        //        next3 = r.Next(0, 3);
        //        GameStrings.game[i][next2] = obstacles[i][next3];
        //    }
        //}
    }
}
