using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeXenzia.Classes
{
   public static class TargetAndOperations
    {
        public static int targetX;
        public static int targetY;

        public static bool TargetIsTaken()
        {
            return SnakeAndOperations._wormX == targetX && SnakeAndOperations._wormY == targetY;
        }

        public static void SetTargetPosition()
        {
            var rand = new Random();
            int x = 0;
            int y = 0;
            if (GridAndOperations.grid[y][x] != null)
            {
                x = rand.Next(1, GridAndOperations.width - 1);
                y = rand.Next(1, GridAndOperations.height - 1);
            }

            targetX = x;
            targetY = y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(targetX, targetY);
            Console.Write("X");
        }
    }
}
