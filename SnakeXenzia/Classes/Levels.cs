using System;
using System.Collections.Generic;
using System.Text;
using static SnakeXenzia.Program;

namespace SnakeXenzia.Classes
{
    public static class Levels
    {
        public static int Level;

        public static void  GetLevel()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose Your level");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Hard");
            Console.WriteLine("3. Hard");
            Console.WriteLine("4. Expert");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Level = 150;
                    break;
                case "2":
                    Level = 90;
                    break;
                case "3":
                    Level = 60;
                    break;
                case "4":
                    Level = 35;
                    break;
                default:
                    Console.WriteLine("Select a valid level");
                    Main();
                    break;
            }
        }
    }
}
