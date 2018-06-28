using System;
using System.Collections.Generic;

namespace SnakeXenzia
{
    public class Pos
    {
        public int x{get;set;}
        public int y{get;set;}
    }
    class Program
    {
        static char [][] grid=new char[20][];
        static int width=50;
        static int height=20;
        static List<Pos> worm=new List<Pos>();
        static int worm_x=25;
        static int worm_y=9; 
        static void Main(string[] args)
        {
            InitFrame();
            DrawFrame();
            InitWorm();
            DrawWorm();
        }

        private static void DrawWorm()
        {
            
        }

        private static void InitWorm()
        {
            worm.Add(new Pos{x=21, y=9});
            worm.Add(new Pos{x=22, y=9});
            worm.Add(new Pos{x=23, y=9});
            worm.Add(new Pos{x=24, y=9});
            worm.Add(new Pos{x=25, y=9});

            foreach(var p in worm)
             grid[p.y][p.x]='o';
        }

        private static void DrawFrame()
        {
            Console.BackgroundColor=ConsoleColor.Black;
            Console.ForegroundColor=ConsoleColor.Green;
            Console.Clear();

            for(int y=0;y<height;y++)
             for(int x=0;x<width;x++)
             {
                 Console.SetCursorPosition(x,y);
                 Console.Write(grid[y][x].ToString());
             }
        }

        private static void InitFrame()
        {
           Console.CursorVisible=false;
           for(int i=0;i<height;i++)
             grid[i]=new char[width];

           grid[0][0]='0';
           grid[0][width-1]='0';
           grid[height-1][0]='0';
           grid[height-1][width-1]='0';

           for(int i=1;i<height-1;i++)
           {
               grid[i][0]='|';
               grid[i][width-1]='|';
           }
           for(int i=1;i<width-1;i++)
           {
               grid[0][i]='=';
               grid[height-1][i]='=';
           } 
           for(int i=1;i<height-1;i++)
            for(int c=1;c<width-1;c++)
             grid[i][c]=' ';
        }
    }
}
