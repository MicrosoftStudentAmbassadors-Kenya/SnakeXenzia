using System;
using System.Collections.Generic;
using system;
using SnakeXenzia.Classes;

namespace SnakeXenzia
{
    class Snake
    {
        private static char?[][] grid = new char?[20][];
        private static int width = 50;
        private static int height = 20;

        private static List<Pos> worm = new List<Pos>();
        public static int WormX = 25;
        public static int WormY = 9;
        private static int _wormLength = 5;

        public static void Main()
        {
            Console.Title = "Snake Xenzia";
            InitFrame();
            DrawFrame();
            InitWorm();
            DrawWorm();
            SetTargetPosition();
            while (!_isOver)
            {
                DrawWormHead();
                if (TargetIsTaken())
                {
                    _score += 10;
                    Score();
                    IncreaseWormLength();
                    SetTargetPosition();
                }

                Pause(Level);
                ControlWorm();
                DrawWormBodyOnHeadPosition();
                MoveWormHead();
                if (IsGameOver())
                    _isOver = true;
                DeleteWormTail();
            }

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Game Over");
        }

        private static void InitWorm()
        {
            worm.Add(new Pos { X = 21, Y = 9 });
            worm.Add(new Pos { X = 22, Y = 9 });
            worm.Add(new Pos { X = 23, Y = 9 });
            worm.Add(new Pos { X = 24, Y = 9 });
            worm.Add(new Pos { X = 25, Y = 9 });

            foreach (var p in worm) GridAndOperations.grid[p.Y][p.X] = 'o';
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
    }
}