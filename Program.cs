
using System;

namespace TicTacToeKimM
{
    internal class Program
    {
        //Multi dimensionel array 3x3
        static char[,] innerBoard =
    {
        {' ', ' ', ' '},
        {' ', ' ', ' '},
        {' ', ' ', ' '}
    };
        static char player = 'X';
        static string usedNumberFields = "";
        static int computerKeyNumberForO;

        /// <summary>
        /// Output to user calling methods from users choice
        /// </summary>
        static void Main()
        {
            Data.BannerText((Console.WindowWidth - 33) / 2, 3);
            Data.Banner((Console.WindowWidth - 33) / 2, 2);
            Data.Pos((Console.WindowWidth - 64 ) / 2, 6, "Vil du spille TicTacToe mod en anden spiller eller computeren?: ", ConsoleColor.White);
            Data.Pos((Console.WindowWidth - 64) / 2, 8, " [S]piller", ConsoleColor.White);
            Data.Pos((Console.WindowWidth - 64) / 2, 9, " [C]]omputer", ConsoleColor.White);
            Console.CursorVisible = false;
            while (true)
            {
                ConsoleKeyInfo Response = Console.ReadKey(intercept: true);

                if (Response.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    PlayerVsPlayer();
                    break;
                }

                if (Response.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    PlayerVsComp();
                    break;
                }
            }
        }
        /// <summary>
        /// Output introduction and board when choice is player on player
        /// </summary>
        static void PlayerVsPlayer()
        {
            //Drawing the TicTacToe innerBoard
            Data.GameLines();

            //Drawing info numlock keypad
            Data.NumLockKeys(70, 6);

            //Max 9 attempts
            do
            {
                player = 'X';
                Data.Pos(70, 2, $"Spiller {player} ", ConsoleColor.Yellow);
                Data.Pos(70, 4, $"Indtast et tal mellem 1 og 9 for at placere {player}: ", ConsoleColor.White);
                GetKeyPressX();
                if (IsGameEnded())
                {
                    break;
                }
                player = 'O';
                Data.Pos(70, 2, $"Spiller {player} ", ConsoleColor.Yellow);
                Data.Pos(70, 4, $"Indtast et tal mellem 1 og 9 for at placere {player}: ", ConsoleColor.White);

                GetKeyPressO();

            } while (!IsGameEnded());
            {
                IsPlayAgain();
            }
        }


        /// <summary>
        /// Output introduction and board when choice is player on player
        /// </summary>
        static void PlayerVsComp()
        {
            //Drawing the TicTacToe innerBoard
            Data.GameLines();

            //Drawing info numlock keypad
            Data.NumLockKeys(70, 6);

            //Max 9 attempts
            do
            {
                player = 'X';
                Data.Pos(70, 2, $"Spiller {player} ", ConsoleColor.Yellow);
                Data.Pos(70, 4, $"Indtast et tal mellem 1 og 9 for at placere {player}: ", ConsoleColor.White);
                GetKeyPressX();
                if (IsGameEnded())
                {
                    break;
                }
                player = 'O';
                Data.Pos(70, 2, $"Spiller {player} ", ConsoleColor.Yellow);
                Data.Pos(70, 4, $"Indtast et tal mellem 1 og 9 for at placere {player}: ", ConsoleColor.White);

                //GetKeyPressO();
                ComputerPlayer();
            } while (!IsGameEnded());
            {
                IsPlayAgain();
            }
        }
        /// <summary>
        /// Output if win or tie calling methods to check bools
        /// </summary>
        /// <returns></returns>
        static bool IsGameEnded()
        {
            if (CheckForWin())
            {
                Data.Pos(70, 15, $"Spiller {player} vinder! Tillykke!", ConsoleColor.Green);
                return true;
            }

            if (CheckForTie())
            {
                Data.Pos(70, 15, "Kampen er uafgjort!", ConsoleColor.Cyan);
                return true;
            }

            return false;
        }
        /// <summary>
        /// Check wheter there is three equals on a line - but not with " "
        /// </summary>
        /// <returns></returns>
        static bool CheckForWin()
        {
            // Check rows, columns, and diagonals
            for (int i = 0; i < 3; i++)
            {
                if ((innerBoard[i, 0] == innerBoard[i, 1] && innerBoard[i, 1] == innerBoard[i, 2] && innerBoard[i, 0] != ' ') ||
                    (innerBoard[0, i] == innerBoard[1, i] && innerBoard[1, i] == innerBoard[2, i] && innerBoard[0, i] != ' '))
                {
                    return true;
                }
            }

            if ((innerBoard[0, 0] == innerBoard[1, 1] && innerBoard[1, 1] == innerBoard[2, 2] && innerBoard[0, 0] != ' ') ||
                (innerBoard[0, 2] == innerBoard[1, 1] && innerBoard[1, 1] == innerBoard[2, 0] && innerBoard[0, 2] != ' '))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Checking if no spaces are left
        /// </summary>
        /// <returns></returns>
        static bool CheckForTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (innerBoard[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Computer player finds a random number for the switch placing the "O", if IsPotentialWin() is false
        /// </summary>
        private static void ComputerPlayer()
        {
            //int computerKeyNumberForO;
            string usedNumberConverted;
            bool containsNumber = true;
            if (!IsPotentialWin())
            {
                do
                {
                    Random rnd = new Random();
                    computerKeyNumberForO = rnd.Next(1, 9);
                    usedNumberConverted = Convert.ToString(computerKeyNumberForO);
                    containsNumber = usedNumberFields.Contains(usedNumberConverted);
                } while (containsNumber);
                usedNumberFields += usedNumberConverted;
            }
            else
            {
                usedNumberFields += computerKeyNumberForO;
            }


            GetKeyForComputerO(computerKeyNumberForO);

        }

        /// <summary>
        /// Checking for if "X" goes again twice in a row, and then placing a "O" on the empty place
        /// </summary>
        /// <returns></returns>
        static bool IsPotentialWin() 
        {
            char CheckX = 'X';
            if ((CheckX.Equals(innerBoard[0, 2]) && innerBoard[0, 2] == innerBoard[1, 1] && innerBoard[2, 0] == ' ' ||
                CheckX.Equals(innerBoard[0, 0]) && innerBoard[0, 0] == innerBoard[1, 0] && innerBoard[2, 0] == ' ' ||
                CheckX.Equals(innerBoard[2, 2]) && innerBoard[2, 1] == innerBoard[2, 2] && innerBoard[2, 0] == ' '))
            {
                computerKeyNumberForO = 9;
                return true;
            }
            if ((CheckX.Equals(innerBoard[0, 0]) && innerBoard[0, 0] == innerBoard[2, 0] && innerBoard[1, 0] == ' ' ||
                (CheckX.Equals(innerBoard[1, 1]) && innerBoard[1, 1] == innerBoard[1, 2] && innerBoard[1, 0] == ' ')))
            {
                computerKeyNumberForO = 8;
                return true;
            }
            if ((CheckX.Equals(innerBoard[1, 1]) && innerBoard[1, 1] == innerBoard[2, 2] && innerBoard[0, 0] == ' ' ||
                CheckX.Equals(innerBoard[0, 1]) && innerBoard[1, 0] == innerBoard[2, 0] && innerBoard[0, 0] == ' ' ||
                CheckX.Equals(innerBoard[1, 0]) && innerBoard[0, 1] == innerBoard[0, 2] && innerBoard[0, 0] == ' '))
            {
                computerKeyNumberForO = 7;
                return true;
            }
            if (CheckX.Equals(innerBoard[1, 1]) && innerBoard[0, 1] == innerBoard[1, 1] && innerBoard[2, 1] == ' ' ||
                CheckX.Equals(innerBoard[2, 2]) && innerBoard[2, 0] == innerBoard[2, 2] && innerBoard[2, 1] == ' ')
            {
                computerKeyNumberForO = 6;
                return true;
            }
            if (CheckX.Equals(innerBoard[0, 0]) && innerBoard[1, 0] == innerBoard[1, 2] && innerBoard[1, 1] == ' ' ||
                CheckX.Equals(innerBoard[1, 0]) && innerBoard[0, 1] == innerBoard[2, 1] && innerBoard[1, 1] == ' ' ||
                CheckX.Equals(innerBoard[2, 0]) && innerBoard[0, 0] == innerBoard[2, 2] && innerBoard[1, 1] == ' ' ||
                CheckX.Equals(innerBoard[0, 1]) && innerBoard[2, 0] == innerBoard[0, 2] && innerBoard[1, 1] == ' ')
            {
                computerKeyNumberForO = 5;
                return true;
            }
            if (CheckX.Equals(innerBoard[1, 1]) && innerBoard[1, 1] == innerBoard[2, 1] && innerBoard[0, 1] == ' ' ||
                CheckX.Equals(innerBoard[0, 0]) && innerBoard[0, 0] == innerBoard[0, 2] && innerBoard[0, 1] == ' ')
            {
                computerKeyNumberForO = 4;
                return true;
            }
            if (CheckX.Equals(innerBoard[1, 1]) && innerBoard[0, 0] == innerBoard[1, 1] && innerBoard[2, 2] == ' ' ||
                CheckX.Equals(innerBoard[2, 1]) && innerBoard[0, 2] == innerBoard[1, 2] && innerBoard[2, 2] == ' ' ||
                CheckX.Equals(innerBoard[1, 2]) && innerBoard[2, 0] == innerBoard[2, 1] && innerBoard[2, 2] == ' ')
            {
                computerKeyNumberForO = 3;
                return true;
            }
            if (CheckX.Equals(innerBoard[1, 1]) && innerBoard[0, 2] == innerBoard[2, 2] && innerBoard[1, 2] == ' ' ||
                CheckX.Equals(innerBoard[0, 2]) && innerBoard[1, 0] == innerBoard[1, 1] && innerBoard[1, 2] == ' ')
            {
                computerKeyNumberForO = 2;
                return true;
            }
            if (CheckX.Equals(innerBoard[1, 1]) && innerBoard[2, 0] == innerBoard[1, 1] && innerBoard[0, 2] == ' ' ||
                CheckX.Equals(innerBoard[0, 1]) && innerBoard[1, 2] == innerBoard[2, 2] && innerBoard[0, 2] == ' ' ||
                CheckX.Equals(innerBoard[1, 2]) && innerBoard[0, 0] == innerBoard[0, 1] && innerBoard[0, 2] == ' ')
            {
                computerKeyNumberForO = 1;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Switch placing a "O" for computer in a certain place 1-9
        /// </summary>
        /// <param name="computerKeyNumberForO"></param>
        static void GetKeyForComputerO(int computerKeyNumberForO)
        {

            switch (computerKeyNumberForO)
            {
                case 1:
                    Data.DrawO(8, 18);
                    innerBoard[0, 2] = player;
                    Data.Pos(73, 11, player, ConsoleColor.Magenta);
                    break;
                case 2:
                    Data.DrawO(26, 18);
                    innerBoard[1, 2] = player;
                    Data.Pos(79, 11, player, ConsoleColor.Magenta);
                    break;
                case 3:
                    Data.DrawO(44, 18);
                    innerBoard[2, 2] = player;
                    Data.Pos(85, 11, player, ConsoleColor.Magenta);
                    break;
                case 4:
                    Data.DrawO(8, 10);
                    innerBoard[0, 1] = player;
                    Data.Pos(73, 9, player);
                    break;
                case 5:
                    Data.DrawO(26, 10);
                    innerBoard[1, 1] = player;
                    Data.Pos(79, 9, player);
                    break;
                case 6:
                    Data.DrawO(44, 10);
                    innerBoard[2, 1] = player;
                    Data.Pos(85, 9, player);
                    break;
                case 7:
                    Data.DrawO(8, 2);
                    innerBoard[0, 0] = player;
                    Data.Pos(73, 7, player);
                    break;
                case 8:
                    Data.DrawO(26, 2);
                    innerBoard[1, 0] = player;
                    Data.Pos(79, 7, player);
                    break;
                case 9:
                    Data.DrawO(44, 2);
                    innerBoard[2, 0] = player;
                    Data.Pos(85, 7, player);
                    break;
            }
        }
        /// <summary>
        /// Switch placing a "X" for player in a certain place 1-9
        /// </summary>
        static void GetKeyPressX()
        {
            int keyPressForX = 0;
            string usedNumberConv;
            bool containsNumber = true;
            do
            {
                // Read the key without waiting for Enter
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                // Check if the key pressed is a number
                if (char.IsDigit(keyInfo.KeyChar))
                {
                    keyPressForX = int.Parse(keyInfo.KeyChar.ToString());
                    usedNumberConv = Convert.ToString(keyPressForX);
                    containsNumber = usedNumberFields.Contains(usedNumberConv);
                    usedNumberFields += usedNumberConv;
                }
            } while (containsNumber);

            switch (keyPressForX)
            {
                case 1:
                    Data.DrawX(8, 18);
                    innerBoard[0, 2] = player;
                    Data.Pos(73, 11, player);
                    break;
                case 2:
                    Data.DrawX(26, 18);
                    innerBoard[1, 2] = player;
                    Data.Pos(79, 11, player);
                    break;
                case 3:
                    Data.DrawX(44, 18);
                    innerBoard[2, 2] = player;
                    Data.Pos(85, 11, player);
                    break;
                case 4:
                    Data.DrawX(8, 10);
                    innerBoard[0, 1] = player;
                    Data.Pos(73, 9, player);
                    break;
                case 5:
                    Data.DrawX(26, 10);
                    innerBoard[1, 1] = player;
                    Data.Pos(79, 9, player);
                    break;
                case 6:
                    Data.DrawX(44, 10);
                    innerBoard[2, 1] = player;
                    Data.Pos(85, 9, player);
                    break;
                case 7:
                    Data.DrawX(8, 2);
                    innerBoard[0, 0] = player;
                    Data.Pos(73, 7, player);
                    break;
                case 8:
                    Data.DrawX(26, 2);
                    innerBoard[1, 0] = player;
                    Data.Pos(79, 7, player);
                    break;
                case 9:
                    Data.DrawX(44, 2);
                    innerBoard[2, 0] = player;
                    Data.Pos(85, 7, player);
                    break;
            }
        }
        /// <summary>
        /// Switch placing a "O" for user in a certain place 1-9
        /// </summary>
        static void GetKeyPressO()
        {

            // Read the key without waiting for Enter
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Check if the key pressed is a number
            if (char.IsDigit(keyInfo.KeyChar))
            {
                int keyPressForO = int.Parse(keyInfo.KeyChar.ToString());

                switch (keyPressForO)
                {
                    case 1:
                        Data.DrawO(8, 18);
                        innerBoard[0, 2] = player;
                        Data.Pos(73, 11, player, ConsoleColor.Magenta);
                        break;
                    case 2:
                        Data.DrawO(26, 18);
                        innerBoard[1, 2] = player;
                        Data.Pos(79, 11, player, ConsoleColor.Magenta);
                        break;
                    case 3:
                        Data.DrawO(44, 18);
                        innerBoard[2, 2] = player;
                        Data.Pos(85, 11, player, ConsoleColor.Magenta);
                        break;
                    case 4:
                        Data.DrawO(8, 10);
                        innerBoard[0, 1] = player;
                        Data.Pos(73, 9, player);
                        break;
                    case 5:
                        Data.DrawO(26, 10);
                        innerBoard[1, 1] = player;
                        Data.Pos(79, 9, player);
                        break;
                    case 6:
                        Data.DrawO(44, 10);
                        innerBoard[2, 1] = player;
                        Data.Pos(85, 9, player);
                        break;
                    case 7:
                        Data.DrawO(8, 2);
                        innerBoard[0, 0] = player;
                        Data.Pos(73, 7, player);
                        break;
                    case 8:
                        Data.DrawO(26, 2);
                        innerBoard[1, 0] = player;
                        Data.Pos(79, 7, player);
                        break;
                    case 9:
                        Data.DrawO(44, 2);
                        innerBoard[2, 0] = player;
                        Data.Pos(85, 7, player);
                        break;
                }
            }
        }

        /// <summary>
        /// Checking if user wants to play again
        /// </summary>
        static void IsPlayAgain()
        {
            Data.Pos(70, 17, "Play again? (Y/N)", ConsoleColor.Green);
            bool validKeyPress = false;
            while (!validKeyPress)
            {
                ConsoleKeyInfo x = Console.ReadKey();

                if (x.Key == ConsoleKey.Y)
                {
                    validKeyPress = true;
                    ClearData();
                    Main();
                }
                if (x.Key == ConsoleKey.N)
                {
                    validKeyPress = true;
                    break;
                }
            }
        }
        /// <summary>
        /// Clearing data preparing for a new game
        /// </summary>
        private static void ClearData()
        {
            IsGameEnded();
            Console.Clear();
            player = 'X';
            usedNumberFields = "";
            //Array.Clear(innerBoard, 0, innerBoard.Length);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    innerBoard[i, j] = ' ';
                }
            }

        }
    }
}
