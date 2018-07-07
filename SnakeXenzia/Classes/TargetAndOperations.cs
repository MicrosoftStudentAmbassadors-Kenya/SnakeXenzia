using System;

namespace SnakeXenzia.Classes
{
   public static class TargetAndOperations
    {
        private static int _targetX;
        private static int _targetY;

        public static bool TargetIsTaken()
        {
            return SnakeAndOperations.WormX == _targetX && SnakeAndOperations.WormY == _targetY;
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

            _targetX = x;
            _targetY = y;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_targetX, _targetY);
            Console.Write("X");
        }
    }
}
