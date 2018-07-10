using system;

namespace SnakeXenzia
{
    class Snake
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
            Console.SetCursorPosition(0,20);
            Console.WriteLine("Game Over");
        }

    }
}