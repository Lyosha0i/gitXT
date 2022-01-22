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
		private static void MinusLive()
		{
            if (Man.IsProtected)
                Man.IsProtected = false;
            else
            {
                Man.Lives--;
                Man.X = 0;
                Man.Y = 28;
            }
		}
        private static void Obstacles(ref Obstacle[] obstacles)
        {
            for (byte i = 0; i < obstacles.Length; i+=2)
            {
                Random r = new Random();
                int next1 = r.Next(16,21);
                obstacles[i] = new Obstacle
                {
                    X = next1,
                    Y = i
                };
                int next2 = r.Next(31, 36);
                obstacles[i + 1] = new Obstacle
                {
                    X = next2,
                    Y = i
                };
                int next3 = r.Next(0,3);
                GameStrings.game[i][next1] = obstacles[i][next3];
                next3 = r.Next(0, 3);
                GameStrings.game[i][next2] = obstacles[i][next3];
            }
        }
        private static void Bears(ref Bear[] bears,Obstacle[]obstacles)
        {
            for (byte i = 0; i < bears.Length; i+=3)
            {
                Random r = new Random();
                int next1 = r.Next(0, obstacles[(int)(i/3*2)].X);
                bears[i] = new Bear
                {
                    X = next1,
                    Y = (int)(i / 3 * 2),
                };
                int next2 = r.Next(obstacles[(int)(i/3*2)].X+1,obstacles[(int)(i/3*2)+1].X);
                bears[i + 1] = new Bear
                {
                    X = next2,
                    Y = (int)(i / 3 * 2)
                };
                int next3 = r.Next(obstacles[(int)(i/3*2)+1].X+1, 40);
                bears[i + 2] = new Bear
                {
                    X = next3,
                    Y = (int)(i / 3 * 2)
                };
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
                    bears[i+1].IsLeft = true;
                }
                else
                {
                    GameStrings.game[(int)(i / 3 * 2)][next2] = bears[i + 1].Right;
                    bears[i+1].IsLeft = false;
                }
                next4 = r.Next(0, 2);
                if (next4 == 0)
                {
                    GameStrings.game[(int)(i / 3 * 2)][next3] = bears[i + 2].Left;
                    bears[i+2].IsLeft = true;
                }
                else
                {
                    GameStrings.game[(int)(i / 3 * 2)][next3] = bears[i + 2].Right;
                    bears[i+2].IsLeft = false;
                }
                }
        }
        private static void Lives(ref Life[] lives,Obstacle[] obstacles)
        {
            lives[0] = new Life
                {
                    X = obstacles[0].X,
                    Y = 0
                };
                GameStrings.game[0][lives[0].X] = lives[0].C;
				lives[1] = new Life
                {
                    X = obstacles[14].X+1,
                    Y = 14
                };
                GameStrings.game[14][lives[1].X] = lives[1].C;
                }
		private static void Shields(ref Shield[] shields)
        {
            for (byte i = 0; i < shields.Length; i++)
            {
                Random r = new Random();
                int next = r.Next(0,4);
                shields[i] = new Shield
                {
                    X = 14+i%2*15+25*(Factorial(i)-1)-next,
                    Y = 14
                };
                GameStrings.game[14][shields[i].X] = shields[i].C;
            }
        }
        private static void Notes(ref Note[] notes,Obstacle[]obstacles)//Notes to collect.
        {
            for (byte i = 0; i < notes.Length; i+=3)
            {
                Random r = new Random();
                int next1 = r.Next(0, obstacles[(int)(i/3*2)].X);
                notes[i] = new Note
                {
                    X = next1,
                    Y = (int)(i / 3 * 2)
                };
                int next2 = r.Next(obstacles[(int)(i/3*2)].X+1,obstacles[(int)(i/3*2)+1].X);
                notes[i + 1] = new Note
                {
                    X = next2,
                    Y = (int)(i / 3 * 2)
                };
                int next3 = r.Next(obstacles[(int)(i/3*2)+1].X+1, 40);
                notes[i + 2] = new Note
                {
                    X = next3,
                    Y = (int)(i / 3 * 2)
                };
                GameStrings.game[(int)(i / 3 * 2)][next1] = notes[i].C;
                GameStrings.game[(int)(i / 3 * 2)][next2] = notes[i].C;
                GameStrings.game[(int)(i / 3 * 2)][next3] = notes[i].C;
                }
        }
        private static void ManUpdate(ref Bear[]bears,ref int killed,Obstacle[]obstacles,ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.LeftArrow && Man.X > 0 && Man.X != obstacles[Man.Y].X-1 && Man.X != obstacles[Man.Y + 1].X - 1)
			{
                Man.X--;
				Man.IsLeft=true;
				}
            if (input.Key == ConsoleKey.RightArrow && Man.X < 40 && Man.X != obstacles[Man.Y].X + 1 && Man.X != obstacles[Man.Y + 1].X + 1)
			{
                Man.X++;
				Man.IsLeft=false;
				}
            if (input.Key == ConsoleKey.UpArrow && Man.Y > 0 && Man.Y != obstacles[Man.Y-2].Y-2 && Man.X != obstacles[Man.Y -1].Y-2)
                Man.Y-=2;
            if (input.Key == ConsoleKey.DownArrow && Man.Y < 28 && Man.Y != obstacles[Man.Y + 2].Y + 2 && Man.X != obstacles[Man.Y + 3].Y + 2)
                Man.Y += 2;
            //AB(CD+EF)
            if (input.Key == ConsoleKey.Spacebar && Man.X < obstacles[Man.Y].X && (Man.IsLeft == false && Man.X < bears[(int)(Man.Y / 3 * 2)].X || Man.IsLeft == true && Man.X > bears[(int)(Man.Y / 3 * 2)].X))//Kill a bear.
                bears[(int)(Man.Y / 3 * 2)].IsKilled = true;
            //ABC(DE+FG)
            else if (input.Key == ConsoleKey.Spacebar && Man.X > obstacles[Man.Y].X &&Man.X < obstacles[Man.Y+1].X && (Man.IsLeft == false && Man.X < bears[(int)(Man.Y / 3 * 2)+1].X || Man.IsLeft == true && Man.X > bears[(int)(Man.Y / 3 * 2)+1].X))//Kill a bear.
                {
				bears[(int)(Man.Y / 3 * 2)+1].IsKilled = true;
				killed++;
				}
            //AB(CD+EF)
            else if (input.Key == ConsoleKey.Spacebar && Man.X > obstacles[Man.Y+1].X && (Man.IsLeft == false && Man.X < bears[(int)(Man.Y / 3 * 2)+2].X || Man.IsLeft == true && Man.X > bears[(int)(Man.Y / 3 * 2)+2].X))//Kill a bear.
                {
				bears[(int)(Man.Y / 3 * 2)+2].IsKilled = true;
				killed++;
				}
        }
		private static void BearsUpdate(ref Bear[]bears,Obstacle[]obstacles)
		{
            for (byte i = 0; i < bears.Length; i += 3)    
            {
                if (bears[i].IsKilled==false)
			if(bears[i].IsLeft==true&&bears[i].X>0)
			bears[i].X--;
			else if(bears[i].IsLeft==false&&bears[i].X<obstacles[(int)(i/3*2)].X-1)
			bears[i].X++;
			if(bears[i].X==Man.X&&bears[i].Y==Man.Y)
			MinusLive();
			if(bears[i].Y==Man.Y&&bears[i].X>Man.X&&bears[i].IsLeft==true&&bears[i].X>0)
			bears[i].X--;
			else if(bears[i].Y==Man.Y&&bears[i].X<Man.X&&bears[i].IsLeft==false&&bears[i].X<obstacles[(int)(i/3*2)].X-1)
			bears[i].X++;
			if(bears[i].X==Man.X&&bears[i].Y==Man.Y)
			MinusLive();
                if (bears[i].IsLeft == true && bears[i].X == 0 || bears[i].IsLeft == false && bears[i].X == obstacles[(int)(i / 3 * 2)].X - 1)
                    bears[i].IsLeft = !bears[i].IsLeft;//
			if(bears[i+1].IsKilled==false)
			if(bears[i+1].IsLeft==true&&bears[i+1].X>obstacles[(int)(i/3*2)].X+1)
			bears[i].X--;
			else if(bears[i+1].IsLeft==false&&bears[i+1].X<obstacles[(int)(i/3*2)+1].X-1)
			bears[i+1].X++;
			if(bears[i+1].X==Man.X&&bears[i+1].Y==Man.Y)
			MinusLive();
			if(bears[i+1].Y==Man.Y&&bears[i+1].X>Man.X&&bears[i+1].IsLeft==true&&bears[i+1].X>obstacles[(int)(i/3*2)].X+1)
			bears[i+1].X--;
			else if(bears[i+1].Y==Man.Y&&bears[i+1].X<Man.X&&bears[i+1].IsLeft==false&&bears[i+1].X<obstacles[(int)(i/3*2)+1].X-1)
			bears[i+1].X++;
			if(bears[i+1].X==Man.X&&bears[i+1].Y==Man.Y)
			MinusLive();
                if (bears[i+1].IsLeft == true && bears[i+1].X == obstacles[(int)(i / 3 * 2)].X + 1 || bears[i+1].IsLeft == false && bears[i+1].X == obstacles[(int)(i / 3 * 2)+1].X - 1)
                    bears[i+1].IsLeft = !bears[i+1].IsLeft;//
                if (bears[i+2].IsKilled==false)
			if(bears[i+2].IsLeft==true&&bears[i+2].X>obstacles[(int)(i/3*2)+1].X+1)
			bears[i+2].X--;
			else if(bears[i+2].IsLeft==false&&bears[i+2].X<40)
			bears[i+2].X++;
			if(bears[i+2].X==Man.X&&bears[i+2].Y==Man.Y)
			MinusLive();
			if(bears[i+2].Y==Man.Y&&bears[i+2].X>Man.X&&bears[i+2].IsLeft==true&&bears[i+2].X>obstacles[(int)(i/3*2)+1].X+1)
			bears[i+2].X--;
			else if(bears[i+2].Y==Man.Y&&bears[i+2].X<Man.X&&bears[i+2].IsLeft==false&&bears[i+2].X<40)
			bears[i].X++;
			if(bears[i+2].X==Man.X&&bears[i+2].Y==Man.Y)
			MinusLive();
                if (bears[i+2].IsLeft == true && bears[i+2].X == obstacles[(int)(i / 3 * 2)].X + 1 || bears[i+2].IsLeft == false && bears[i+2].X == 39)
                    bears[i].IsLeft = !bears[i].IsLeft;
            }
		}
		private static void LivesUpdate(ref Life[]lives)
		{
		if(Man.Y==lives[0].Y&&Man.X==lives[0].X&&lives[0].IsCollected==false)
            {
                Man.Lives++;
                lives[0].IsCollected = true;
            }
            if (Man.Y == lives[1].Y && Man.X == lives[1].X && lives[1].IsCollected == false)
            {
                Man.Lives++;
                lives[1].IsCollected = true;
            }
        }
        private static void ShieldsUpdate(ref Shield[]shields, Bear[]bears)
        {
            for (byte i = 0; i < shields.Length; i++)
            {
                if (Man.Y == shields[i].Y && Man.X == shields[i].X && !shields[i].IsCollected)
                {
                    Man.IsProtected=true;
                    shields[i].IsCollected = true;
                }
            }
        }
        private static void NotesUpdate(ref Note[]notes,ref int n)
        {
            for (byte i = 0; i < notes.Length; i++)
            {
                if (Man.Y == notes[i].Y && Man.X == notes[i].X && !notes[i].IsCollected)
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
					GameStrings.game[28][0]=Man.Right;
                }
				ManUpdate(ref bears,ref killed,obstacles,input);
				BearsUpdate(ref bears,obstacles);
				LivesUpdate(ref lives);
				ShieldsUpdate(ref shields,bears);
				NotesUpdate(ref notes,ref notesPP);
                Console.WriteLine(now+DateTime.Now.Millisecond.ToString());
                if (now<DateTime.Now) Console.WriteLine(DateTime.Now-now);
                Console.WriteLine("L {0} ♫ {1} B {2}",Man.Lives,notesPP,killed);
                for (double j = 0; j < 1000; j += 0.00001);//The crutch instead of the timer.
                Console.Clear();
            }
        }
    }
}
