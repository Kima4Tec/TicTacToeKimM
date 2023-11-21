using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeKimM
{
    internal class Data
    {
        public static void DrawX(int x, int y)
        {
            Pos(x, y + 0, @"xxx         xxx", ConsoleColor.White);
            Pos(x, y + 1, @"  xxx     xxx  ", ConsoleColor.White);
            Pos(x, y + 2, @"    xxx xxx    ", ConsoleColor.White);
            Pos(x, y + 3, @"      xxx      ", ConsoleColor.White);
            Pos(x, y + 4, @"    xxx xxx    ", ConsoleColor.White);
            Pos(x, y + 5, @"  xxx     xxx  ", ConsoleColor.White);
            Pos(x, y + 6, @"xxx         xxx", ConsoleColor.White);
        }

        public static void DrawO(int x, int y)
        {
            Pos(x, y + 0, @"    OOOOOOO    ", ConsoleColor.White);
            Pos(x, y + 1, @"  OOO     OOO  ", ConsoleColor.White);
            Pos(x, y + 2, @"OOO         OOO", ConsoleColor.White);
            Pos(x, y + 3, @"OOO         OOO", ConsoleColor.White);
            Pos(x, y + 4, @"OOO         OOO", ConsoleColor.White);
            Pos(x, y + 5, @"  OOO     OOO  ", ConsoleColor.White);
            Pos(x, y + 6, @"    OOOOOOO    ", ConsoleColor.White);
        }

        //The innerBoard in lines
        public static void GameLines()
        {
            //1. horizontal line
            for (int i = 0; i < 53; i++)
            {
                Pos(7 + i, 9, "─");
            }
            //2. horizontal line
            for (int i = 0; i < 53; i++)
            {
                Pos(7 + i, 17, "─");
            }
            //left vertical line
            for (int i = 0; i < 23; i++)
            {
                Pos(24, 2 + i, "│");
            }
            //right vertical line
            for (int i = 0; i < 23; i++)
            {
                Pos(42, 2 + i, "│");
            }

        }

                public static void Banner(int x, int y)
        {
            Pos(x, y + 0, @"*********************************", ConsoleColor.Red);
            Pos(x, y + 1, @"*", ConsoleColor.Red);
            Pos(x + 32, y + 1, @"*", ConsoleColor.Red);
            Pos(x, y + 2, @"*********************************", ConsoleColor.Red);
        }
        public static void BannerText(int x, int y)
        {
            Pos(x, y, @"            TICTACTOE            ", ConsoleColor.White);
        }

        public static void NumLockKeys(int x, int y)
        {
            Pos(x, y + 0, @"┌─────┬─────┬─────┐", ConsoleColor.White);
            Pos(x, y + 1, @"│  7  │  8  │  9  │", ConsoleColor.White);
            Pos(x, y + 2, @"├─────┼─────┼─────┤", ConsoleColor.White);
            Pos(x, y + 3, @"│  4  │  5  │  6  │", ConsoleColor.White);
            Pos(x, y + 4, @"├─────┼─────┼─────┤", ConsoleColor.White);
            Pos(x, y + 5, @"│  1  │  2  │  3  │", ConsoleColor.White);
            Pos(x, y + 6, @"└─────┴─────┴─────┘", ConsoleColor.White);

        }


        public static void Pos(int x, int y, object tekst, ConsoleColor color = ConsoleColor.DarkMagenta) //positioning text
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(tekst);
            Console.ResetColor();
        }
    }
}
