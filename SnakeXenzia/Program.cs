using System;
using System.Collections.Generic;

namespace SnakeXenzia
{
    class Program
    {
        private static char? [][] grid=new char?[20][];
        private static int width=50;
        private static int height=20;
        private static List<Pos> worm=new List<Pos>();
        private static int _wormX = 25;
        private static int _wormY = 9;
        private static bool isOver = false;
        
        private enum Direction
        {
            Up=1,
            Down=2,
            Left=3,
            Right=4
        }

        private static Direction current = Direction.Right;
        private static int wormLength = 5;
        private static int targetX;
        private static int targetY;
        static void Main()
        {
            InitFrame();
            DrawFrame();
            InitWorm();
            DrawWorm();
            SetTargetPosition();
            while (!isOver)
            {
                DrawWormHead();
                Pause();
                ControlWorm();
                DrawWormBodyOnHeadPosition();
                MoveWormHead();
                if (IsGameOver())
                    isOver = true;
                DeleteWormTail();
            }
            Console.SetCursorPosition(0,20);
            Console.WriteLine("Game Over");
        }

        private static void SetTargetPosition()
        {
            var rand=new Random();
            int x = 0;
            int y = 0;
            if (grid[y][x] != null)
            {
                x = rand.Next(1, width - 1);
                y = rand.Next(1, height);
            }

            targetX = x;
            targetY = y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(targetX,targetY);
            Console.Write("X");
        }



        private static void ControlWorm()
        {
            ConsoleKeyInfo s;
            if (Console.KeyAvailable)
            {
                s = Console.ReadKey();
                switch (s.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (current != Direction.Down)
                        {
                            current = Direction.Up;
                           //PlayMoveSound();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (current != Direction.Up)
                        {
                            current = Direction.Down;
                            //PlayMoveSound();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (current != Direction.Right)
                        {
                            current = Direction.Left;
                            //PlayMoveSound();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (current != Direction.Left)
                        {
                            current = Direction.Right;
                            //PlayMoveSound();
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private static void DeleteWormTail()
        {
            Console.SetCursorPosition(worm[0].X, worm[0].Y);
            Console.Write(' ');
            if (worm.Count != wormLength)
            {
                grid[worm[0].Y][worm[0].X] = ' ';
                worm.RemoveAt(0);
            }
        }
    

        private static bool IsGameOver()
        {
            var value = grid[_wormY][_wormX] != ' ';
            return value;
        }

        private static void Pause()
        {
            System.Threading.Thread.Sleep(100);
        }

        private static void MoveWormHead()
        {
            grid[_wormY][_wormX] = 'o';
            switch (current)
            {
                case Direction.Up:
                    _wormY--;
                    break;
                case Direction.Down:
                    _wormY++;
                    break;
                case Direction.Left:
                    _wormX--;
                    break;
                case Direction.Right:
                    _wormX++;
                    break;
            }
            worm.Add(new Pos{X =_wormX, Y=_wormY});
        }

        private static void DrawWormBodyOnHeadPosition()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_wormX, _wormY);
            Console.Write('o');
        }

        private static void DrawWormHead()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_wormX, _wormY);
            Console.Write('@');

        }

        private static void DrawWorm()
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var wormPart in worm)
            {
                Console.SetCursorPosition(wormPart.X, wormPart.Y);
                count++;
                if(count<5)
                    Console.Write('o');
                else
                {
                    Console.Write('o');
                }
            }
        }

        private static void InitWorm()
        {
            worm.Add(new Pos{X=21, Y=9});
            worm.Add(new Pos{X=22, Y=9});
            worm.Add(new Pos{X=23, Y=9});
            worm.Add(new Pos{X=24, Y=9});
            worm.Add(new Pos{X=25, Y=9});

            foreach(var p in worm)
             grid[p.Y][p.X]='o';
        }

        private static void DrawFrame()
        {
            Console.BackgroundColor=ConsoleColor.Black;
            Console.ForegroundColor=ConsoleColor.Green;
            //Console.Clear();

            for(int y=0;y<height;y++)
             for(int x=0;x<width;x++)
             {
                 Console.SetCursorPosition(x,y);
                 Console.Write(grid[y][x].ToString());
             }
        }

        private static void InitFrame()
        {
          // Console.CursorVisible=false;
           for(int i=0;i<height;i++)
             grid[i]=new char?[width];

           grid[0][0]='0';
           grid[0][width-1]='0';
           grid[height-1][0]='0';
           grid[height-1][width-1]='0';

           for(int i=1;i<height-1;i++)
           {
               grid[i][0]='|';
               grid[i][width-1]='|';
           }
           for(int i=1;i<width-1;i++)
           {
               grid[0][i]='=';
               grid[height-1][i]='=';
           } 
           for(int i=1;i<height-1;i++)
            for(int c=1;c<width-1;c++)
             grid[i][c]=' ';
        }
    }
}
