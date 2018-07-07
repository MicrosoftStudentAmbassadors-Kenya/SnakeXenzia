using System;
using System.Collections.Generic;
using SnakeXenzia.Classes;

namespace SnakeXenzia
{
    class Program
    {
 
        private static bool isOver = false;
        private static int score = 0;


        static void Main()
        {
            Console.Title = "Snake Xenzia";
            GridAndOperations.InitFrame();
            GridAndOperations.DrawFrame();
            SnakeAndOperations.InitWorm();
            SnakeAndOperations.DrawWorm();
            TargetAndOperations.SetTargetPosition();
            Score();
            while (!isOver)
            {
                SnakeAndOperations.DrawWormHead();
                if (TargetAndOperations.TargetIsTaken())
                {
                    score += 10;
                    Score();
                    SnakeAndOperations.IncreaseWormLength();
                    TargetAndOperations.SetTargetPosition();
                }
                
                Pause();
                SnakeAndOperations.ControlWorm();
                SnakeAndOperations.DrawWormBodyOnHeadPosition();
                SnakeAndOperations.MoveWormHead();
                if (IsGameOver())
                    isOver = true;
                SnakeAndOperations.DeleteWormTail();
            }
            Console.SetCursorPosition(0,20);
            Console.WriteLine("Game Over");
            Console.WriteLine($"Your Score : {score}");
            Console.ReadKey();
        }

        private static void Score()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(52,0);
            Console.Write($"Score : {score} ");

        }





    

        private static bool IsGameOver()
        {
            var value = GridAndOperations.grid[SnakeAndOperations._wormY][SnakeAndOperations._wormX] != ' ';
            return value;
        }

        private static void Pause()
        {
            System.Threading.Thread.Sleep(100);
        }
    }
}
