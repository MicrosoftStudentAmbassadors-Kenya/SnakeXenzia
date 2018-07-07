using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeXenzia.Classes
{
   public  static class GridAndOperations
    {
        public static char?[][] grid = new char?[20][];
        public static int width = 50;
        public static int height = 20;

        public static void DrawFrame()
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

        public static void InitFrame()
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
    }
}
