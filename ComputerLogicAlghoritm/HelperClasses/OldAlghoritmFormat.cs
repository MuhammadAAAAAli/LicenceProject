//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections;
//using TicTacToe;
//using ComputerLogicAlghoritm;


//namespace TicTacToe
//{
//    public class OldAlghoritmFormat
//    {
//        public bool isPlyerTurnNow;
//        private int _dificultyLevel;

//        private char computerXor0 = '\0';
//        private char playerXorY = '\0';
//        private static char[] _state { get; set; }

//        static int firstGoodMove_SameCell = -1;
//        static int secondGoodMove_SameCell = -1;

//        static int firstGoodMove_DifferentCells = -1;
//        static int secondGoodMove_DifferentCells = -1;
//        static char eliminateChessConfusion1 = 'f';
//        static char eliminateChessConfusion2 = 's';


//        public OldAlghoritmFormat(int dificultyLevel)
//        {
//            _dificultyLevel = dificultyLevel;
//        }

//        public void setIfPlayerTurn(bool isPlayerTurn)
//        {
//            isPlyerTurnNow = isPlayerTurn;
//        }

//        public void SetDificulty_and_WhoHasXAnd0(int dificultyLevel, bool playerStarts)
//        {
//            if (playerStarts)
//            {
//                computerXor0 = '0';
//                playerXorY = 'X';
//            }
//            else
//            {
//                computerXor0 = 'X';
//                playerXorY = '0';
//            }
//            _dificultyLevel = dificultyLevel;
//        }


//        public int GetComputersChoice(char[] state)
//        {
//            _state = DeepCopyArray(state);
//            ReinitializeEliminateAmbiguityVariables();
//            int computerMoveChoice = 0;
//            switch (_dificultyLevel)
//            {
//                case (int)DificultyLevelEnum.Easy:
//                    computerMoveChoice = ComputerChoosesRandomCell(); break;
//                case (int)DificultyLevelEnum.Medium:
//                    computerMoveChoice = MessUpPlayersMoves(); break;
//                case (int)DificultyLevelEnum.Hard:
//                    computerMoveChoice = GetHardDificultyChoice(); break;
//                case (int)DificultyLevelEnum.Expert:
//                    computerMoveChoice = GetExpertDificultyChoice(); break;
//            }
//            return computerMoveChoice;
//        }

//        private int GetExpertDificultyChoice()
//        {
//            SortedList<int, bool> outsideEmptyCells = EmptyCellsOnTheBoard.GetSortedList(_state);
//            SortedList<int, bool> emptyCells = EmptyCellsOnTheBoard.GetSortedList(_state);
//            if (PlayerHasOnlyOneCellDown(emptyCells))
//            {
//                if (PlayerFirstChoiceWasACorner())
//                    return 5;
//                else
//                    return GetAllPossibleMovesToBlockPlayerStrategy(outsideEmptyCells, emptyCells).OrderBy(emp => Guid.NewGuid()).First();
//            }
//            else
//                return GetHardDificultyChoice();
//        }

//        private bool PlayerHasOnlyOneCellDown(SortedList<int, bool> emptyCells)
//        {
//            return emptyCells.Count == 8;
//        }

//        private bool PlayerFirstChoiceWasACorner()
//        {
//            return _state[0].Equals('X') || _state[2].Equals('X') || _state[6].Equals('X') || _state[8].Equals('X');
//        }

//        private List<int> GetAllPossibleMovesToBlockPlayerStrategy(SortedList<int, bool> outsideEmptyCells, SortedList<int, bool> emptyCells)
//        {
//            List<int> posibleGoodMoves = new List<int>();
//            char oldValue = '\0';
//            char oldValue2 = '\0';
//            foreach (var x in emptyCells)
//            {
//                TheNewState(outsideEmptyCells, ref oldValue, x, playerXorY);
//                foreach (var y in emptyCells)
//                {
//                    if (NextMoveCellWillBeAvailable(outsideEmptyCells, y))
//                    {
//                        TheNewState_2(ref oldValue2, y, playerXorY);
//                        CheckIfAnybodyWon checks = new CheckIfAnybodyWon(_state);
//                        if (checks.DoWeHaveAWinner())
//                        {
//                            posibleGoodMoves.Add(x.Key);
//                        }
//                        BackToInitialState_2(oldValue2, y);
//                    }
//                }
//                BackToInitialState(outsideEmptyCells, oldValue, x);
//            }
//            return posibleGoodMoves;
//        }


//        private char[] DeepCopyArray(char[] originalState)
//        {
//            char[] copyState = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
//            for (int i = 0; i < 9; i++)
//            {
//                copyState[i] = originalState[i];
//            }
//            return copyState;
//        }

//        public void CheckIfIHaveAnyChance(char[] state)
//        {
//            _state = DeepCopyArray(state);
//            MessUpPlayersMoves();
//        }

//        private int GetHardDificultyChoice()
//        {
//            int finalChoice = -1;
//            int iminentMove = MessUpPlayersMoves();
//            if (iminentMove != -1)
//                return iminentMove;
//            else if (IsNotFirstMove(iminentMove))
//            {
//                SortedList<int, bool> outsideEmptyCells = EmptyCellsOnTheBoard.GetSortedList(_state);
//                SortedList<int, bool> emptyCells = EmptyCellsOnTheBoard.GetSortedList(_state);
//                Dictionary<int, int> possibleGoodMoves = new Dictionary<int, int>();
//                char oldValue = '\0';
//                char oldValue2 = '\0';

//                foreach (var x in emptyCells)
//                {
//                    TheNewState(outsideEmptyCells, ref oldValue, x, computerXor0);
//                    CheckIfGameCanBeClosedNextRound(ref finalChoice, outsideEmptyCells, ref oldValue, x);
//                    if (finalChoice != -1)
//                        return finalChoice;
//                    BackToInitialState(outsideEmptyCells, oldValue, x);

//                }

//                foreach (var x in emptyCells)
//                {
//                    TheNewState(outsideEmptyCells, ref oldValue, x, playerXorY);
//                    CheckIfGameCanBeClosedNextRound(ref finalChoice, outsideEmptyCells, ref oldValue, x);
//                    if (finalChoice != -1)
//                        return finalChoice;
//                    BackToInitialState(outsideEmptyCells, oldValue, x);
//                }

//                foreach (var x in emptyCells)
//                {
//                    TheNewState(outsideEmptyCells, ref oldValue, x, computerXor0);
//                    foreach (var y in emptyCells)
//                        CheckIfCompCanCloseNextMove(outsideEmptyCells, possibleGoodMoves, ref oldValue2, x, y);
//                    BackToInitialState(outsideEmptyCells, oldValue, x);
//                }
//                if (FoundOptionsForNextMove(finalChoice, possibleGoodMoves))
//                    return GetBestMoveForThisMove(possibleGoodMoves);
//                else if (DidNotFoundAnyChoices(finalChoice))
//                    return ComputerChoosesRandomCell();
//                else
//                    return finalChoice;
//            }
//            else if (ThisIsFirstMove())
//                return ComputerChoosesRandomCell();
//            return 0;
//        }

//        private void TheNewState(SortedList<int, bool> outsideEmptyCells, ref char oldValue, KeyValuePair<int, bool> x, char Xor0)
//        {
//            outsideEmptyCells[x.Key] = false;
//            oldValue = _state[x.Key - 1];
//            _state[x.Key - 1] = Xor0;
//        }

//        private static bool ThisIsFirstMove()
//        {
//            return EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_state) < 2;
//        }

//        private static bool DidNotFoundAnyChoices(int finalChoice)
//        {
//            return finalChoice == -1;
//        }

//        private static int GetBestMoveForThisMove(Dictionary<int, int> possibleGoodMoves)
//        {
//            var maxValue = possibleGoodMoves.OrderBy(pair => pair.Value).First();
//            return possibleGoodMoves
//                .Where(x => x.Value == maxValue.Value)
//                .OrderBy(emp => Guid.NewGuid())
//                .First().Key;
//        }

//        private bool FoundOptionsForNextMove(int finalChoice, Dictionary<int, int> possibleGoodMoves)
//        {
//            return possibleGoodMoves.Keys.Count > 0 && finalChoice == -1;
//        }

//        private void BackToInitialState(SortedList<int, bool> outsideEmptyCells, char oldValue, KeyValuePair<int, bool> x)
//        {
//            _state[x.Key - 1] = oldValue;
//            outsideEmptyCells[x.Key] = true;
//        }

//        private void CheckIfCompCanCloseNextMove(SortedList<int, bool> outsideEmptyCells, Dictionary<int, int> possibleGoodMoves, ref char oldValue2, KeyValuePair<int, bool> x, KeyValuePair<int, bool> y)
//        {
//            if (NextMoveCellWillBeAvailable(outsideEmptyCells, y))
//            {
//                try
//                {
//                    TheNewState_2(ref oldValue2, y, computerXor0);
//                    MessUpPlayersMoves();
//                }
//                catch (ChessException e)
//                {
//                    if (e.Message.Length == 2)
//                    {
//                        if (possibleGoodMoves.ContainsKey(x.Key))
//                        {
//                            possibleGoodMoves[x.Key]++;
//                        }
//                        else
//                        {
//                            possibleGoodMoves.Add(x.Key, 1);
//                        }
//                    }
//                }
//                BackToInitialState_2(oldValue2, y);
//            }
//        }

//        private static void BackToInitialState_2(char oldValue2, KeyValuePair<int, bool> y)
//        {
//            _state[y.Key - 1] = oldValue2;
//        }

//        private void TheNewState_2(ref char oldValue2, KeyValuePair<int, bool> y, char Xor0)
//        {
//            oldValue2 = _state[y.Key - 1];
//            _state[y.Key - 1] = Xor0;
//        }

//        private static bool NextMoveCellWillBeAvailable(SortedList<int, bool> outsideEmptyCells, KeyValuePair<int, bool> y)
//        {
//            return outsideEmptyCells[y.Key] == true;
//        }

//        private void CheckIfGameCanBeClosedNextRound(ref int finalChoice, SortedList<int, bool> outsideEmptyCells, ref char oldValue, KeyValuePair<int, bool> x)
//        {
//            try
//            {

//                MessUpPlayersMoves();
//            }
//            catch (ChessException e)
//            {
//                finalChoice = x.Key;
//            }
//        }

//        private static bool IsNotFirstMove(int iminentMove)
//        {
//            return iminentMove == -1 && EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_state) >= 2;
//        }
//        private int MessUpPlayersMoves()
//        {
//            int computerMoveChoice = 0;
//            secondGoodMove_DifferentCells = -1;
//            firstGoodMove_DifferentCells = -1;
//            for (int i = 0; i < 9; i++)
//            {
//                try
//                {
//                    computerMoveChoice = CheckIf2CellFormationForBothPlayers_InOnCell(i);
//                }
//                catch (ChessException e)
//                {
//                    throw e;
//                }
//                rememberPotentialMoves(computerMoveChoice);
//            }
//            return SoDoIHave_0or1or2_GoodMoves();
//        }
//        private int SoDoIHave_0or1or2_GoodMoves()
//        {
//            int computerMoveChoice = 0;
//            if (Found1GoodMove_StartingFromDifferntCells())
//                computerMoveChoice = firstGoodMove_DifferentCells;
//            else if (Found2GoodMoves_StartingFromDifferentCells())
//            {
//                if (firstGoodMove_DifferentCells == secondGoodMove_DifferentCells)
//                    computerMoveChoice = firstGoodMove_DifferentCells;
//                else if (IsChessWithBothPlayersCells())
//                    computerMoveChoice = RecalculateJustComputerMove();
//                else
//                    throw new ChessException(firstGoodMove_DifferentCells.ToString() + secondGoodMove_DifferentCells.ToString());
//            }
//            else
//                if (_dificultyLevel == 2)
//                    computerMoveChoice = NoGoodMoveIsARandomMove();
//                else
//                    computerMoveChoice = -1;
//            return computerMoveChoice;
//        }

//        private int NoGoodMoveIsARandomMove()
//        {
//            int computerMoveChoice = 0;
//            do
//            {
//                computerMoveChoice = ComputerChoosesRandomCell();
//            } while (IsComputerRandomChoiceBad(computerMoveChoice) && EmptyCellsOnTheBoard.GetArray(_state).Count > 5);
//            return computerMoveChoice;
//        }

//        private void rememberPotentialMoves(int computerMoveChoice)
//        {
//            if (FoundAGoodMove(computerMoveChoice))
//                if (firstGoodMove_DifferentCells == -1)
//                    firstGoodMove_DifferentCells = computerMoveChoice;
//                else if (secondGoodMove_DifferentCells == -1)
//                    secondGoodMove_DifferentCells = computerMoveChoice;
//        }

//        private int RecalculateJustComputerMove()
//        {
//            int foundIt = -1; ;
//            for (int i = 0; i < 9; i++)
//            {
//                if (CheckIf2InARowForEachPlayer(i, computerXor0) != -1)
//                    foundIt = CheckIf2InARowForEachPlayer(i, computerXor0);
//            }
//            return foundIt;
//        }

//        private bool IsChessWithBothPlayersCells()
//        {
//            return !eliminateChessConfusion1.Equals(eliminateChessConfusion2);
//        }

//        private void ReinitializeEliminateAmbiguityVariables()
//        {
//            eliminateChessConfusion1 = 'f';
//            eliminateChessConfusion2 = 's';
//        }

//        private bool Found2GoodMoves_StartingFromDifferentCells()
//        {
//            return firstGoodMove_DifferentCells != -1 && secondGoodMove_DifferentCells != -1;
//        }

//        private bool Found1GoodMove_StartingFromDifferntCells()
//        {
//            return firstGoodMove_DifferentCells != -1 && secondGoodMove_DifferentCells == -1;
//        }

//        private bool IsComputerRandomChoiceBad(int computerMoveChoice)
//        {
//            if (computerMoveChoice == 2 || computerMoveChoice == 4 || computerMoveChoice == 6 || computerMoveChoice == 8)
//                if (_state[computerMoveChoice - 2].Equals('0') && _state[computerMoveChoice].Equals('X'))
//                    return true;
//                else if (_state[computerMoveChoice - 2].Equals('X') && _state[computerMoveChoice].Equals('0'))
//                    return true;
//            return false;
//        }

//        private static bool FoundAGoodMove(int computerMoveChoice)
//        {
//            return computerMoveChoice != -1;
//        }

//        private static int ComputerChoosesRandomCell()
//        {
//            Random random = new Random(Guid.NewGuid().GetHashCode());
//            return EmptyCellsOnTheBoard.GetArray(_state)[random.Next(0, EmptyCellsOnTheBoard.GetArray(_state).Count)];
//        }

//        private int CheckIf2CellFormationForBothPlayers_InOnCell(int i)
//        {
//            try
//            {
//                secondGoodMove_SameCell = -1;
//                firstGoodMove_SameCell = -1;
//                int x = CheckIf2InARowForEachPlayer(i, isPlyerTurnNow == true ? playerXorY : computerXor0);

//                if (x == -1)
//                    return CheckIf2InARowForEachPlayer(i, isPlyerTurnNow == true ? computerXor0 : playerXorY);
//                return x;
//            }
//            catch (ChessException e)
//            {
//                throw e;
//            }
//        }


//        private int CheckIf2InARowForEachPlayer(int i, char XorY)
//        {
//            CheckFor2CellsFormation(i, XorY);

//            if (Found1GoodMove())
//            {
//                if (eliminateChessConfusion1.Equals('f'))
//                    eliminateChessConfusion1 = XorY;
//                else if (eliminateChessConfusion2.Equals('s'))
//                    eliminateChessConfusion2 = XorY;
//                return firstGoodMove_SameCell;
//            }
//            else if (Found2GoodMoves())
//                if (GoodMovesAreTheSame())
//                    return firstGoodMove_SameCell;
//                else
//                    throw new ChessException(firstGoodMove_SameCell.ToString() + secondGoodMove_SameCell.ToString());

//            return -1;
//        }
//        private void CheckFor2CellsFormation(int i, char XorY)
//        {
//            int result = Checks.CheckIfColumnCloseToWinning(i, _state, XorY);
//            if (result != -1)
//                firstGoodMove_SameCell = result;
//            result = Checks.CheckIfLineCloseToWinning(i, _state, XorY);
//            if (result != -1 && firstGoodMove_SameCell != -1)
//                secondGoodMove_SameCell = result;
//            else if (result != -1 && firstGoodMove_SameCell == -1)
//                firstGoodMove_SameCell = result;
//            result = Checks.CheckIfMinorDiagonalCloseToWinning(i, _state, XorY);
//            if (result != -1 && firstGoodMove_SameCell != -1)
//                secondGoodMove_SameCell = result;
//            else if (result != -1 && firstGoodMove_SameCell == -1)
//                firstGoodMove_SameCell = result;
//            result = Checks.CheckIfMajorDiagonalCloseToWinning(i, _state, XorY);
//            if (result != -1 && firstGoodMove_SameCell != -1)
//                secondGoodMove_SameCell = result;
//            else if (result != -1 && firstGoodMove_SameCell == -1)
//                firstGoodMove_SameCell = result;
//        }
//        private bool GoodMovesAreTheSame()
//        {
//            return firstGoodMove_SameCell == secondGoodMove_SameCell;
//        }

//        private bool Found2GoodMoves()
//        {
//            return firstGoodMove_SameCell != -1 && secondGoodMove_SameCell != -1;
//        }

//        private bool Found1GoodMove()
//        {
//            return firstGoodMove_SameCell != -1 && secondGoodMove_SameCell == -1;
//        }

//    }
//}

