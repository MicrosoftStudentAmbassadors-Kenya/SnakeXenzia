using System;
using static SnakeXenzia.Classes.GridAndOperations;
using static SnakeXenzia.Classes.SnakeAndOperations;
using static SnakeXenzia.Classes.TargetAndOperations;
using static SnakeXenzia.Classes.Levels;

namespace SnakeXenzia
{
    static class Program
    {
        private static bool _isOver;
        private static int _score;

        public static void Main()
        {
            Console.Title = "Snake Xenzia";
            GetLevel();
            InitFrame();
            DrawFrame();
            InitWorm();
            DrawWorm();
            SetTargetPosition();
            Score();
            while (!_isOver)
            {
                DrawWormHead();
                //if (TargetIsTaken())
                //{
                //    _score += 10;
                //    Score();
                //    IncreaseWormLength();
                //    SetTargetPosition();
                //}
                
                //Pause(Level);
                ControlWorm();
                DrawWormBodyOnHeadPosition();
                MoveWormHead();
                if (IsGameOver())
                    _isOver = true;
                DeleteWormTail();
            }
            Console.SetCursorPosition(0,20);
            Console.WriteLine("Game Over");
            Console.WriteLine($"Your Score : {_score}");
            ContinueGameOrExit();

        }

        private static void ContinueGameOrExit()
        {
            Console.Clear();
            Console.WriteLine("Press Enter Key to Continue playing or Q to quit");
            ConsoleKeyInfo k = Console.ReadKey();
            switch (k.Key)
            {
                case ConsoleKey.Enter:
                    Main();
                    break;
                case ConsoleKey.Q:
                    Console.Clear();
                    Console.WriteLine("Thanks for playing");
                    break;
                default:
                    ContinueGameOrExit();
                    break;
            }
        }

        private static void Pause(int lev)
        {
            System.Threading.Thread.Sleep(lev);
        }

        private static void Score()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(52,0);
            Console.Write($"Score : {_score} ");

        }
        private static bool IsGameOver()
        {
            var value = grid[WormY][WormX] != ' ';
            return value;
        }
    }
}
