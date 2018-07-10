using System;
using System.Collections.Generic;

namespace SnakeXenzia.Classes
{
   public static class SnakeAndOperations
    {
        private static List<Positon> worm = new List<Positon>();
        public static int WormX = 25;
        public static int WormY = 9;
        private static int _wormLength = 5;

        private enum Direction
        {
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }

        private static Direction _current = Direction.Right;

        public static void MoveWormHead()
        {
            GridAndOperations.grid[WormY][WormX] = 'o';
            switch (_current)
            {
                case Direction.Up:
                    WormY--;
                    break;
                case Direction.Down:
                    WormY++;
                    break;
                case Direction.Left:
                    WormX--;
                    break;
                case Direction.Right:
                    WormX++;
                    break;
            }

            worm.Add(new Positon { X = WormX, Y = WormY });
        }

        public static void DrawWormBodyOnHeadPosition()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(WormX, WormY);
            Console.Write('o');
        }

        public static void DrawWormHead()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(WormX, WormY);
            Console.Write('@');

        }

        public static void DrawWorm()
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var wormPart in worm)
            {
                Console.SetCursorPosition(wormPart.X, wormPart.Y);
                count++;
                if (count < 5)
                    Console.Write('o');
                else
                {
                    Console.Write('o');
                }
            }
        }

        public static void InitWorm()
        {
            worm.Add(new Positon { X = 21, Y = 9 });
            worm.Add(new Positon { X = 22, Y = 9 });
            worm.Add(new Positon { X = 23, Y = 9 });
            worm.Add(new Positon { X = 24, Y = 9 });
            worm.Add(new Positon { X = 25, Y = 9 });

            foreach (var p in worm) GridAndOperations.grid[p.Y][p.X] = 'o';
        }

        public static void IncreaseWormLength()
        {
            _wormLength++;
        }

        public static void ControlWorm()
        {
            ConsoleKeyInfo s;
            if (Console.KeyAvailable)
            {
                s = Console.ReadKey();
                switch (s.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_current !=Direction.Down)
                        {
                            _current = Direction.Up;
                            //PlayMoveSound();
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (_current != Direction.Up)
                        {
                            _current = Direction.Down;
                            //PlayMoveSound();
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (_current != Direction.Right)
                        {
                            _current = Direction.Left;
                            //PlayMoveSound();
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (_current != Direction.Left)
                        {
                            _current = Direction.Right;
                            //PlayMoveSound();
                        }
                        break;
                }
            }
        }

        public static void DeleteWormTail()
        {
            Console.SetCursorPosition(worm[0].X, worm[0].Y);
            Console.Write(' ');
            if (worm.Count != _wormLength)
            {
                GridAndOperations.grid[worm[0].Y][worm[0].X] = ' ';
                worm.RemoveAt(0);
            }
        }
    }
}
