using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;
using UseCases.Interfaces;

//using JetBrains.Annotations;

namespace UI
{
    //   [UsedImplicitly]
    public class ConsoleUi : IOutput
    {
        private bool _backgroundIsColored;

        public void PrintState(char[] state)
        {
            var oneStringOutput = StringBuilderCreater(state);
            foreach (var c in oneStringOutput.ToString())
            {
                ColorsFor_Xor0_ForTheActualGame(c);
            }
        }

        public int NextMoveChoice()
        {
            var newKeyFromConsole = Console.ReadKey();
            Console.Clear();
            return newKeyFromConsole.KeyChar - 48;
        }

        public void PrintLastPossibleMoves(char[] state, string winner, string moves, bool didPlayerStarts)
        {
            PrintChessCase(state, moves, winner);
            const string message = "Will win for sure !!!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t\t{0} {1} {2} won with style.\n\n", winner, message,
                (didPlayerStarts && winner.Equals("X")) || (didPlayerStarts == false && winner.Equals("0"))
                    ? "You"
                    : "Computer");
            Console.ResetColor();
        }

        public void PrintInitialMessageGoGoGo(char[] state)
        {
            PrintState(state);
            const string message = "Go go go .... X first !";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t\t       {0}\n\n", message);
            Console.ResetColor();
        }

        public void LoosingMessage(char[] state)
        {
            PrintState(state);
            const string message = "You both lost suckers !!";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t\t       {0}\n\n", message);
            Console.ResetColor();
        }

        public void WinningMessage(char[] state, string winner)
        {
            PrintState(state);
            const string message = "won the game !!! Yey !";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t\t       {0} {1}\n\n", winner, message);
            Console.ResetColor();
        }

        public void TryAgainMessage(char[] state)
        {
            PrintState(state);
            const string message = "     Try again :(";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t\t       {0} \n\n", message);
            Console.ResetColor();
        }

        public InitialInfo GetGameModeAndFirstStart()
        {
            string playerStarts = null;
            var gameMode = -1;

            while (playerStarts == null)
            {
                Console.Clear();
                var oneStringOutput = new StringBuilder();

                oneStringOutput.Append(IsGameModeChoosed(gameMode)
                    ? "\n\t\t\t\tTic Tac Toe\n\n\n\n\t\t0. Two players mode\n\n\n\t\tSingle player mode ... Choose difficulty level : \n\t\t1. Easy\n\t\t2. Medium\n\t\t3. Hard\n\t\t4. Expert\n\n\n\n\n"
                    : "\n\t\t\t\tTic Tac Toe\n\n\n\n\t\t0. Two players mode\n\n\n\t\tSingle player mode ... Choose difficulty level : \n\t\t1. Easy\n\t\t2. Medium\n\t\t3. Hard\n\t\t4. Expert\n\n\n\n\n\n");

                foreach (var c in oneStringOutput.ToString())
                    ColorsinitialScreen(c, gameMode);
                if (IsGameModeChoosed(gameMode))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\t\t" + "Do you want to start first ? Y/N");
                    Console.ResetColor();
                }
                Console.WriteLine("\n\n\n\n\t\t\t      \u00a9  Alin Boncioaga");

                WaitingKeybordInput(ref playerStarts, ref gameMode);
            }
            return new InitialInfo(gameMode, playerStarts.Equals("y"));
        }

        private static void ColorsFor_Xor0_ForTheActualGame(char toBeChecked)
        {
            if (toBeChecked.Equals('X'))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(toBeChecked);
                Console.ResetColor();
            }
            else if (toBeChecked.Equals('0'))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(toBeChecked);
                Console.ResetColor();
            }
            else if (toBeChecked >= 97 && toBeChecked <= 105)
                Console.Write(" ");
            else
                Console.Write(toBeChecked);
        }

        private static void PrintChessCase(IReadOnlyList<char> state, string cells, string winner)
        {
            if (state == null) throw new ArgumentNullException("state");
            var oneStringOutput = StringBuilderCreater(state);
            foreach (var c in oneStringOutput.ToString())
            {
                ColorsForChess(c, cells, winner);
            }
        }

        private static StringBuilder StringBuilderCreater(IReadOnlyList<char> state)
        {
            Console.Clear();
            var oneStringOutput = new StringBuilder();
            oneStringOutput.Append("\n\n\n");
            oneStringOutput.Append("\n\t\t\t===================");
            oneStringOutput.Append("\n\t\t\t|aaaaa|bbbbb|ccccc|");
            oneStringOutput.Append("\n\t\t\t|aa" + state[0] + "aa|bb" + state[1] + "bb|cc" + state[2] + "cc|");
            oneStringOutput.Append("\n\t\t\t|aaaaa|bbbbb|ccccc|");
            oneStringOutput.Append("\n\t\t\t===================");
            oneStringOutput.Append("\n\t\t\t|ddddd|eeeee|fffff|");
            oneStringOutput.Append("\n\t\t\t|dd" + state[3] + "dd|ee" + state[4] + "ee|ff" + state[5] + "ff|");
            oneStringOutput.Append("\n\t\t\t|ddddd|eeeee|fffff|");
            oneStringOutput.Append("\n\t\t\t===================");
            oneStringOutput.Append("\n\t\t\t|ggggg|hhhhh|iiiii|");
            oneStringOutput.Append("\n\t\t\t|gg" + state[6] + "gg|hh" + state[7] + "hh|ii" + state[8] + "ii|");
            oneStringOutput.Append("\n\t\t\t|ggggg|hhhhh|iiiii|");
            oneStringOutput.Append("\n\t\t\t===================");
            oneStringOutput.Append("\n\n\n\n");
            return oneStringOutput;
        }

        private static void ColorsForChess(char toBeChecked, string cells, string winner)
        {
            var cellsOfInterest = cells.ToCharArray();
            if (toBeChecked.Equals('X'))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(toBeChecked);
                Console.ResetColor();
            }
            else if (toBeChecked.Equals('0'))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(toBeChecked);
                Console.ResetColor();
            }
            else if (IsSureWin(toBeChecked, cellsOfInterest[0], cellsOfInterest[1]))
            {
                if (winner.Equals("X"))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else if (winner.Equals("0"))
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
            else if ((toBeChecked >= 97 && toBeChecked <= 105) || (toBeChecked >= 49 && toBeChecked <= 57))
                Console.Write(" ");
            else
                Console.Write(toBeChecked);
        }

        private static bool IsSureWin(char toBeChecked, char cell1, char cell2)
        {
            return CheckCellsForChessSitution(toBeChecked, cell1) || CheckCellsForChessSitution(toBeChecked, cell2);
        }

        private static bool CheckCellsForChessSitution(char toBeChecked, char cell)
        {
            if (toBeChecked.Equals(cell))
                return true;
            switch (cell)
            {
                case '1':
                {
                    if (toBeChecked.Equals('a'))
                        return true;
                    break;
                }
                case '2':
                {
                    if (toBeChecked.Equals('b'))
                        return true;
                    break;
                }
                case '3':
                {
                    if (toBeChecked.Equals('c'))
                        return true;
                    break;
                }
                case '4':
                {
                    if (toBeChecked.Equals('d'))
                        return true;
                    break;
                }
                case '5':
                {
                    if (toBeChecked.Equals('e'))
                        return true;
                    break;
                }
                case '6':
                {
                    if (toBeChecked.Equals('f'))
                        return true;
                    break;
                }
                case '7':
                {
                    if (toBeChecked.Equals('g'))
                        return true;
                    break;
                }
                case '8':
                {
                    if (toBeChecked.Equals('h'))
                        return true;
                    break;
                }
                case '9':
                {
                    if (toBeChecked.Equals('i'))
                        return true;
                    break;
                }
            }
            return false;
        }

        private void ColorsinitialScreen(char toBeChecked, int gameMode)
        {
            if (toBeChecked.Equals('0') || toBeChecked.Equals('1') || toBeChecked.Equals('2') || toBeChecked.Equals('3') ||
                toBeChecked.Equals('4'))
            {
                if (gameMode != -1 && toBeChecked.ToString().Equals(gameMode.ToString()))
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    _backgroundIsColored = true;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(toBeChecked);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(toBeChecked);
                    Console.ResetColor();
                }
            }
            else
            {
                if (_backgroundIsColored && toBeChecked.ToString().Equals("\n"))
                    Console.ResetColor();
                Console.Write(toBeChecked);
            }
        }

        private static void WaitingKeybordInput(ref string isPlayerStarting, ref int gameMode)
        {
            if (IsGameModeChoosed(gameMode))
            {
                isPlayerStarting = gameMode == 0 ? "y" : GetWhoStarts(isPlayerStarting);
            }
            else
                gameMode = GetGameMode();
        }

        private static int GetGameMode()
        {
            var newKeyFromConsole = Console.ReadKey();
            Console.Clear();
            return newKeyFromConsole.KeyChar - 48;
        }

        private static string GetWhoStarts(string playerStarts)
        {
            var c = Choose_Y_or_N();
            if (c.ToString().ToLower().Equals("y") || c.ToString().ToLower().Equals("n"))
            {
                playerStarts = c.ToString().ToLower();
            }
            return playerStarts;
        }

        private static bool IsGameModeChoosed(int gameMode)
        {
            return (gameMode == 0 || gameMode == 1 || gameMode == 2 || gameMode == 3 || gameMode == 4);
        }

        private static char Choose_Y_or_N()
        {
            var newKeyFromConsole = Console.ReadKey();
            var c = newKeyFromConsole.KeyChar;
            Console.Clear();
            return c;
        }
    }
}