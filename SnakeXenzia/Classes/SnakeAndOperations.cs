using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeXenzia.Classes
{
   public  class SnakeAndOperations
    {
        private static List<Pos> worm = new List<Pos>();
        public static int _wormX = 25;
        public static int _wormY = 9;
        private static int wormLength = 5;

        public enum Direction
        {
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }

        private static Direction current = Direction.Right;

        public static void MoveWormHead()
        {
            GridAndOperations.grid[_wormY][_wormX] = 'o';
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

            worm.Add(new Pos { X = _wormX, Y = _wormY });
        }

        public static void DrawWormBodyOnHeadPosition()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_wormX, _wormY);
            Console.Write('o');
        }

        public static void DrawWormHead()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_wormX, _wormY);
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
            worm.Add(new Pos { X = 21, Y = 9 });
            worm.Add(new Pos { X = 22, Y = 9 });
            worm.Add(new Pos { X = 23, Y = 9 });
            worm.Add(new Pos { X = 24, Y = 9 });
            worm.Add(new Pos { X = 25, Y = 9 });

            foreach (var p in worm) GridAndOperations.grid[p.Y][p.X] = 'o';
        }

        public static void IncreaseWormLength()
        {
            wormLength++;
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
                        if (current !=Direction.Down)
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

        public static void DeleteWormTail()
        {
            Console.SetCursorPosition(worm[0].X, worm[0].Y);
            Console.Write(' ');
            if (worm.Count != wormLength)
            {
                GridAndOperations.grid[worm[0].Y][worm[0].X] = ' ';
                worm.RemoveAt(0);
            }
        }
    }
}
