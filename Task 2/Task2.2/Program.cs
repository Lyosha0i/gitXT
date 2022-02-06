using System;
using System.Diagnostics;
using System.Timers;
using System.Text;

namespace Task2._2
{
    class Program
    {
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)//The game should have a timer, but it hasn't.
        {
            
        }
        private static int Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
		private static void MinusLive(Man man)
		{
            if (man.IsProtected)
                man.IsProtected = false;
            else
            {
                man.Lives--;
                man.point.X = 0;
                man.point.Y = 28;
            }
		}
        private static void Obstacles(ref Obstacle[] obstacles)
        {
            for (byte i = 0; i < obstacles.Length; i+=2)
            {
                Random r = new Random();
                int next1 = r.Next(16,21);
                obstacles[i] = new Obstacle(new Point(next1, i));
                int next2 = r.Next(31, 36);
                obstacles[i + 1] = new Obstacle(new Point(next2, i));
                int next3 = r.Next(0,3);
                GameStrings.game[i][next1] = obstacles[i][next3];
                next3 = r.Next(0, 3);
                GameStrings.game[i][next2] = obstacles[i][next3];
            }
        }
        private static void Bears(ref Bear[] bears, Obstacle[] obstacles)
        {
            for (byte i = 0; i < bears.Length; i += 3)
            {
                Random r = new Random();
                int next1 = r.Next(0, obstacles[(int)(i / 3 * 2)].point.X);
                bears[i] = new Bear(new Point(next1, (int)(i/3*2)));
                int next2 = r.Next(obstacles[(int)(i / 3 * 2)].point.X + 1, obstacles[(int)(i / 3 * 2) + 1].point.X);
                bears[i + 1] = new Bear(new Point(next2, (int)(i / 3 * 2)));
                int next3 = r.Next(obstacles[(int)(i / 3 * 2) + 1].point.X + 1, 40);
                bears[i + 2] = new Bear(new Point(next3, (int)(i / 3 * 2)));
                int next4 = r.Next(0, 2);
                if (next4 == 0)
                {
                    GameStrings.game[(int)(i / 3 * 2)][next1] = bears[i].Left;
                    bears[i].IsLeft = true;
                }
                else
                {
                    GameStrings.game[(int)(i / 3 * 2)][next1] = bears[i].Right;
                    bears[i].IsLeft = false;
                }
                next4 = r.Next(0, 2);
                if (next4 == 0)
                {
                    GameStrings.game[(int)(i / 3 * 2)][next2] = bears[i + 1].Left;
                    bears[i + 1].IsLeft = true;
                }
                else
                {
                    GameStrings.game[(int)(i / 3 * 2)][next2] = bears[i + 1].Right;
                    bears[i + 1].IsLeft = false;
                }
                next4 = r.Next(0, 2);
                if (next4 == 0)
                {
                    GameStrings.game[(int)(i / 3 * 2)][next3] = bears[i + 2].Left;
                    bears[i + 2].IsLeft = true;
                }
                else
                {
                    GameStrings.game[(int)(i / 3 * 2)][next3] = bears[i + 2].Right;
                    bears[i + 2].IsLeft = false;
                }
            }
        }
        private static void Lives(ref Life[] lives, Obstacle[] obstacles)
        {
            lives[0] = new Life(new Point(obstacles[0].point.X, 0));
            GameStrings.game[0][lives[0].point.X] = lives[0].C;
            lives[1] = new Life(new Point(obstacles[14].point.X+1, 14));
            GameStrings.game[14][lives[1].point.X] = lives[1].C;
        }
        private static void Shields(ref Shield[] shields)
        {
            for (byte i = 0; i < shields.Length; i++)
            {
                Random r = new Random();
                int next = r.Next(0,4);
                shields[i] = new Shield(new Point(14 + i % 2 * 15 + 25 * (Factorial(i) - 1) - next, 14));
                GameStrings.game[14][shields[i].point.X] = shields[i].C;
            }
        }
        private static void Notes(ref Note[] notes, Obstacle[] obstacles)//Notes to collect.
        {
            for (byte i = 0; i < notes.Length; i += 3)
            {
                Random r = new Random();
                int next1 = r.Next(0, obstacles[(int)(i / 3 * 2)].point.X);
                notes[i] = new Note(new Point(next1, (int)(i / 3) * 2));
                int next2 = r.Next(obstacles[(int)(i / 3 * 2)].point.X + 1, obstacles[(int)(i / 3 * 2) + 1].point.X);
                notes[i + 1] = new Note(new Point(next2, (int)(i / 3) * 2));
                int next3 = r.Next(obstacles[(int)(i / 3 * 2) + 1].point.X + 1, 40);
                notes[i + 2] = new Note(new Point(next3, (int)(i / 3) * 2));
                GameStrings.game[(int)(i / 3 * 2)][next1] = notes[i].C;
                GameStrings.game[(int)(i / 3 * 2)][next2] = notes[i].C;
                GameStrings.game[(int)(i / 3 * 2)][next3] = notes[i].C;
            }
        }
        private static void manUpdate(ref Bear[] bears, ref int killed, ref Man man, Obstacle[] obstacles, ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.LeftArrow && man.point.X > 0 && man.point.X != obstacles[man.point.Y].point.X - 1 && man.point.X != obstacles[man.point.Y + 1].point.X - 1)
            {
                man.point.X--;
                man.IsLeft = true;
            }
            if (input.Key == ConsoleKey.RightArrow && man.point.X < 40 && man.point.X != obstacles[man.point.Y].point.X + 1 && man.point.X != obstacles[man.point.Y + 1].point.X + 1)
            {
                man.point.X++;
                man.IsLeft = false;
            }
            if (input.Key == ConsoleKey.UpArrow && man.point.Y > 0 && man.point.Y != obstacles[man.point.Y - 2].point.Y - 2 && man.point.X != obstacles[man.point.Y - 1].point.Y - 2)
                man.point.Y -= 2;
            if (input.Key == ConsoleKey.DownArrow && man.point.Y < 28 && man.point.Y != obstacles[man.point.Y + 2].point.Y + 2 && man.point.X != obstacles[man.point.Y + 3].point.Y + 2)
                man.point.Y += 2;
            //AB(CD+EF)
            if (input.Key == ConsoleKey.Spacebar && man.point.X < obstacles[man.point.Y].point.X && (!man.IsLeft && man.point.X < bears[(int)(man.point.Y / 3 * 2)].point.X || man.IsLeft && man.point.X > bears[(int)(man.point.Y / 3 * 2)].point.X))//Kill a bear.
                bears[(int)(man.point.Y / 3 * 2)].IsKilled = true;
            //ABC(DE+FG)
            else if (input.Key == ConsoleKey.Spacebar && man.point.X > obstacles[man.point.Y].point.X && man.point.X < obstacles[man.point.Y + 1].point.X && (!man.IsLeft && man.point.X < bears[(int)(man.point.Y / 3 * 2) + 1].point.X || man.IsLeft&& man.point.X > bears[(int)(man.point.Y / 3 * 2) + 1].point.X))//Kill a bear.
            {
                bears[(int)(man.point.Y / 3 * 2) + 1].IsKilled = true;
                killed++;
            }
            //AB(CD+EF)
            else if (input.Key == ConsoleKey.Spacebar && man.point.X > obstacles[man.point.Y + 1].point.X && (!man.IsLeft&& man.point.X < bears[(int)(man.point.Y / 3 * 2) + 2].point.X || man.IsLeft&& man.point.X > bears[(int)(man.point.Y / 3 * 2) + 2].point.X))//Kill a bear.
            {
                bears[(int)(man.point.Y / 3 * 2) + 2].IsKilled = true;
                killed++;
            }
        }
        private static void BearsUpdate(ref Bear[] bears, ref Man man, Obstacle[] obstacles)
        {
            for (byte i = 0; i < bears.Length; i += 3)
            {
                if (!bears[i].IsKilled)
                    if (bears[i].IsLeft&& bears[i].point.X > 0)
                        bears[i].point.X--;
                    else if (!bears[i].IsLeft&& bears[i].point.X < obstacles[(int)(i / 3 * 2)].point.X - 1)
                        bears[i].point.X++;
                if (bears[i].point.X == man.point.X && bears[i].point.Y == man.point.Y)
                    MinusLive(man);
                if (bears[i].point.Y == man.point.Y && bears[i].point.X > man.point.X && bears[i].IsLeft && bears[i].point.X > 0)
                    bears[i].point.X--;
                else if (bears[i].point.Y == man.point.Y && bears[i].point.X < man.point.X && !bears[i].IsLeft && bears[i].point.X < obstacles[(int)(i / 3 * 2)].point.X - 1)
                    bears[i].point.X++;
                if (bears[i].point.X == man.point.X && bears[i].point.Y == man.point.Y)
                    MinusLive(man);
                if (bears[i].IsLeft&& bears[i].point.X == 0 || !bears[i].IsLeft && bears[i].point.X == obstacles[(int)(i / 3 * 2)].point.X - 1)
                    bears[i].IsLeft = !bears[i].IsLeft;//
                if (!bears[i + 1].IsKilled)
                    if (bears[i + 1].IsLeft&& bears[i + 1].point.X > obstacles[(int)(i / 3 * 2)].point.X + 1)
                        bears[i].point.X--;
                    else if (!bears[i + 1].IsLeft&& bears[i + 1].point.X < obstacles[(int)(i / 3 * 2) + 1].point.X - 1)
                        bears[i + 1].point.X++;
                if (bears[i + 1].point.X == man.point.X && bears[i + 1].point.Y == man.point.Y)
                    MinusLive(man);
                if (bears[i + 1].point.Y == man.point.Y && bears[i + 1].point.X > man.point.X && bears[i + 1].IsLeft&& bears[i + 1].point.X > obstacles[(int)(i / 3 * 2)].point.X + 1)
                    bears[i + 1].point.X--;
                else if (bears[i + 1].point.Y == man.point.Y && bears[i + 1].point.X < man.point.X && !bears[i + 1].IsLeft&& bears[i + 1].point.X < obstacles[(int)(i / 3 * 2) + 1].point.X - 1)
                    bears[i + 1].point.X++;
                if (bears[i + 1].point.X == man.point.X && bears[i + 1].point.Y == man.point.Y)
                    MinusLive(man);
                if (bears[i + 1].IsLeft&& bears[i + 1].point.X == obstacles[(int)(i / 3 * 2)].point.X + 1 || !bears[i + 1].IsLeft&& bears[i + 1].point.X == obstacles[(int)(i / 3 * 2) + 1].point.X - 1)
                    bears[i + 1].IsLeft = !bears[i + 1].IsLeft;//
                if (!bears[i + 2].IsKilled)
                    if (bears[i + 2].IsLeft&& bears[i + 2].point.X > obstacles[(int)(i / 3 * 2) + 1].point.X + 1)
                        bears[i + 2].point.X--;
                    else if (!bears[i + 2].IsLeft&& bears[i + 2].point.X < 40)
                        bears[i + 2].point.X++;
                if (bears[i + 2].point.X == man.point.X && bears[i + 2].point.Y == man.point.Y)
                    MinusLive(man);
                if (bears[i + 2].point.Y == man.point.Y && bears[i + 2].point.X > man.point.X && bears[i + 2].IsLeft&& bears[i + 2].point.X > obstacles[(int)(i / 3 * 2) + 1].point.X + 1)
                    bears[i + 2].point.X--;
                else if (bears[i + 2].point.Y == man.point.Y && bears[i + 2].point.X < man.point.X && !bears[i + 2].IsLeft&& bears[i + 2].point.X < 40)
                    bears[i].point.X++;
                if (bears[i + 2].point.X == man.point.X && bears[i + 2].point.Y == man.point.Y)
                    MinusLive(man);
                if (bears[i + 2].IsLeft == true && bears[i + 2].point.X == obstacles[(int)(i / 3 * 2)].point.X + 1 || !bears[i + 2].IsLeft&& bears[i + 2].point.X == 39)
                    bears[i].IsLeft = !bears[i].IsLeft;
            }
        }
        private static void LivesUpdate(ref Life[]lives,ref Man man)
		{
		if(man.point.Y==lives[0].point.Y&&man.point.X==lives[0].point.X&&!lives[0].IsCollected)
            {
                man.Lives++;
                lives[0].IsCollected = true;
            }
            if (man.point.Y == lives[1].point.Y && man.point.X == lives[1].point.X &&!lives[1].IsCollected)
            {
                man.Lives++;
                lives[1].IsCollected = true;
            }
        }
        private static void ShieldsUpdate(ref Shield[]shields, ref Man man,Bear[]bears)
        {
            for (byte i = 0; i < shields.Length; i++)
            {
                if (man.point.Y == shields[i].point.Y && man.point.X == shields[i].point.X && !shields[i].IsCollected)
                {
                    man.IsProtected=true;
                    shields[i].IsCollected = true;
                }
            }
        }
        private static void NotesUpdate(ref Note[]notes,ref Man man,ref int n)
        {
            for (byte i = 0; i < notes.Length; i++)
            {
                if (man.point.Y == notes[i].point.Y && man.point.X == notes[i].point.X && !notes[i].IsCollected)
                {
                    n++;
                    notes[i].IsCollected = true;
                }
            }
        }    


        static void Main(string[] args)
        {
		int killed=0,notesPP=0;
            ConsoleKeyInfo input;
			Console.WriteLine("Press any key");
            input = Console.ReadKey();
            Console.Clear();
            DateTime now = DateTime.Now;
            Man man = new Man(new Point(0,0));
			Obstacle[] obstacles = new Obstacle[30];
            Bear[] bears = new Bear[45];
            Life[] lives= new Life[6];
			Shield[] shields= new Shield[3];
            Note[] notes = new Note[45];//Notes to collect.
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                        if (j % 2 == 1)
                        {
                            if(GameStrings.game[j]==null)GameStrings.game[j] = new StringBuilder("ПППППППППППППППППППППППППППППППППППППППП");
                            if (GameStrings.game[j] != null) Console.WriteLine(GameStrings.game[j]);
                        }
                    else
                    {
                            if (GameStrings.game[j] == null) GameStrings.game[j] = new StringBuilder("                                        ");
                        if (GameStrings.game[j] != null) Console.WriteLine(GameStrings.game[j]);
                        }
                if (i == 0)
                {
                    Obstacles(ref obstacles);
                    Bears(ref bears,obstacles);
                    Lives(ref lives,obstacles);
                    Shields(ref shields);
                    Notes(ref notes,obstacles);
					GameStrings.game[28][0]=man.Right;
                }
				manUpdate(ref bears,ref killed,ref man,obstacles,input);
				BearsUpdate(ref bears,ref man,obstacles);
				LivesUpdate(ref lives,ref man);
				ShieldsUpdate(ref shields,ref man,bears);
				NotesUpdate(ref notes,ref man,ref notesPP);
                Console.WriteLine(now+DateTime.Now.Millisecond.ToString());
                if (now<DateTime.Now) Console.WriteLine(DateTime.Now-now);
                Console.WriteLine("L {0} ♫ {1} B {2}",man.Lives,notesPP,killed);
                for (double j = 0; j < 1000; j += 0.00001);//The crutch instead of the timer.
                Console.Clear();
            }
        }
    }
}
