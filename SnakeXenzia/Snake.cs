using System;
using System.Collections.Generic;
using SnakeXenzia.Classes;

namespace SnakeXenzia
{
    static class Snake
    {
        private static char?[][] grid = new char?[20][];
        private static int width = 50;
        private static int height = 20;

        private static List<Positon> positions = new List<Positon>();
        private static int snakeX = 25;
        private static int snakeY = 9;
        private static int _snakeLength = 5;
        private static int _targetX;
        private static int _targetY;

        private static bool _isOver;
        private enum Direction
        {
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4
        }

        private static Direction _current = Direction.Right;

        public static void Main()
        {
            Console.Title = "Snake Xenzia";
            InitFrame();
            DrawFrame();
            Initsnake();
            Drawsnake();
            SetTargetPosition();
            while (!_isOver)
            {
                DrawsnakeHead();
                if (TargetIsTaken())
                {
                    IncreasesnakeLength();
                    SetTargetPosition();
                }

                Pause();
                Controlsnake();
                DrawsnakeBodyOnHeadPosition();
                MovesnakeHead();
                if (IsGameOver())
                    _isOver = true;
                ControlSnake();
            }

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Game Over");
        }

        private static void Initsnake()
        {
            positions.Add(new Positon { X = 21, Y = 9 });
            positions.Add(new Positon { X = 22, Y = 9 });
            positions.Add(new Positon { X = 23, Y = 9 });
            positions.Add(new Positon { X = 24, Y = 9 });
            positions.Add(new Positon { X = 25, Y = 9 });

            foreach (var p in positions)
                grid[p.Y][p.X] = 'o';
        }

        private static void InitFrame()
        {
            // Console.CursorVisible=false;
            for (int i = 0; i < height; i++) grid[i] = new char?[width];

            grid[0][0] = '0';
            grid[0][width - 1] = '0';
            grid[height - 1][0] = '0';
            grid[height - 1][width - 1] = '0';

            for (int i = 1; i < height - 1; i++)
            {
                grid[i][0] = '|';
                grid[i][width - 1] = '|';
            }
            for (int i = 1; i < width - 1; i++)
            {
                grid[0][i] = '=';
                grid[height - 1][i] = '=';
            }
            for (int i = 1; i < height - 1; i++)
            for (int c = 1; c < width - 1; c++)
                grid[i][c] = ' ';
        }

        private static void DrawFrame()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.Clear();

            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(grid[y][x].ToString());
            }
        }

        private static void Drawsnake()
        {
            int count = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var snakePart in positions)
            {
                Console.SetCursorPosition(snakePart.X, snakePart.Y);
                count++;
                if (count < 5)
                    Console.Write('o');
                else
                {
                    Console.Write('o');
                }
            }
        }

        private static void SetTargetPosition()
        {
            var rand = new Random();
            int x = 0;
            int y = 0;
            if (grid[y][x] != null)
            {
                x = rand.Next(1, width - 1);
                y = rand.Next(1, height - 1);
            }

            _targetX = x;
            _targetY = y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_targetX, _targetY);
            Console.Write("X");
        }

        private static void DrawsnakeHead()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(snakeX, snakeY);
            Console.Write('@');

        }

        private static bool TargetIsTaken()
        {
            return snakeX == _targetX && snakeY == _targetY;
        }

        private static void IncreasesnakeLength()
        {
            _snakeLength++;
        }
        private static void Pause()
        {
            System.Threading.Thread.Sleep(100);
        }

        private static void Controlsnake()
        {
            ConsoleKeyInfo s;
            if (Console.KeyAvailable)
            {
                s = Console.ReadKey();
                switch (s.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_current != Direction.Down)
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

        private static void DrawsnakeBodyOnHeadPosition()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(snakeX, snakeY);
            Console.Write('o');
        }

        private static void MovesnakeHead()
        {
            grid[snakeY][snakeX] = 'o';
            switch (_current)
            {
                case Direction.Up:
                    snakeY--;
                    break;
                case Direction.Down:
                    snakeY++;
                    break;
                case Direction.Left:
                    snakeX--;
                    break;
                case Direction.Right:
                    snakeX++;
                    break;
            }

            positions.Add(new Positon { X = snakeX, Y = snakeY });
        }
        private static bool IsGameOver()
        {
            var value = grid[snakeY][snakeX] != ' ';
            return value;
        }

        private static void ControlSnake()
        {
            Console.SetCursorPosition(positions[0].X, positions[0].Y);
            Console.Write(' ');
            if (positions.Count != _snakeLength)
            {
                grid[positions[0].Y][positions[0].X] = ' ';
                positions.RemoveAt(0);
            }
        }

    }

}