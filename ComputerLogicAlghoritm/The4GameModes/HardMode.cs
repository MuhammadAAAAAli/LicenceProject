using System;
using System.Collections.Generic;
using System.Linq;
using ComputerLogicAlghoritm.HelperClasses;
using UseCases.Exception;

namespace ComputerLogicAlghoritm.The4GameModes
{
    public class HardMode : MediumMode
    {
        private static char _oldValue = '\0';
        private static char _oldValue2 = '\0';

        public HardMode(bool playerStarts)
            : base(playerStarts)
        {
        }

        public override int GetComputersChoice(IReadOnlyList<char> state)
        {
            State = DeepCopyArray(state);
            var iminentMove = CheckIfComputerCanCloseTheGameEvenIfInChess();
            return iminentMove != -1 ? iminentMove : GetHardDificultyChoice();
        }

        protected int GetHardDificultyChoice()
        {
            var finalChoice = -1;
            var iminentMove = MessUpPlayersMoves();
            if (iminentMove != -1)
                return iminentMove;

            if (IsFirstMove(iminentMove))
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                return ThisIsFirstMove()
                    ? EmptyCellsOnTheBoard.GetArray(State)[random.Next(0, EmptyCellsOnTheBoard.GetArray(State).Count)]
                    : 0;
            }

            var outsideEmptyCells = EmptyCellsOnTheBoard.GetSortedList(State);
            var emptyCells = EmptyCellsOnTheBoard.GetSortedList(State);
            var possibleGoodMoves = new Dictionary<int, int>();

            if (AI_CheckIfComputerCanDoChessWithOneMove(emptyCells, outsideEmptyCells, ref finalChoice)) return finalChoice;
            if (AI_CheckIfPlayerCanDoChessNextMoveAndBlockHim(emptyCells, outsideEmptyCells, ref finalChoice)) return finalChoice;

            AI_CheckIfComputerCanDoASmartMoveAndCloseNextOne(emptyCells, outsideEmptyCells, possibleGoodMoves);
            if (FoundOptionsForNextMove(finalChoice, possibleGoodMoves))
                return GetLeastProbableMoveAsTheChoosenOne(possibleGoodMoves);

            var random1 = new Random(Guid.NewGuid().GetHashCode());
            return DidNotFoundAnyChoices(finalChoice)
                ? EmptyCellsOnTheBoard.GetArray(State)[random1.Next(0, EmptyCellsOnTheBoard.GetArray(State).Count)]
                : finalChoice;
        }

        private void AI_CheckIfComputerCanDoASmartMoveAndCloseNextOne(SortedList<int, bool> emptyCells, SortedList<int, bool> outsideEmptyCells,
            Dictionary<int, int> possibleGoodMoves)
        {
            foreach (var x in emptyCells)
            {
                TheNewState(outsideEmptyCells, x, ComputerXor0);
                foreach (var y in emptyCells)
                    CheckIfCompCanCloseNextMove(outsideEmptyCells, possibleGoodMoves, x, y);
                BackToInitialState(outsideEmptyCells, x);
            }
        }

        private bool AI_CheckIfPlayerCanDoChessNextMoveAndBlockHim(SortedList<int, bool> emptyCells, SortedList<int, bool> outsideEmptyCells,
            ref int finalChoice)
        {
            foreach (var x in emptyCells)
            {
                TheNewState(outsideEmptyCells, x, PlayerXorY);
                CheckIfGameCanBeClosedNextRound(ref finalChoice, x);
                if (CheckIfPlayerCanDoChessNextMove(finalChoice))
                    return true;
                BackToInitialState(outsideEmptyCells, x);
            }
            return false;
        }

        private bool AI_CheckIfComputerCanDoChessWithOneMove(SortedList<int, bool> emptyCells, SortedList<int, bool> outsideEmptyCells,
            ref int finalChoice)
        {
            foreach (var x in emptyCells)
            {
                TheNewState(outsideEmptyCells, x, ComputerXor0);
                CheckIfGameCanBeClosedNextRound(ref finalChoice, x);
                if (ComputerCanDoChessNextMove(finalChoice))
                    return true;
                BackToInitialState(outsideEmptyCells, x);
            }
            return false;
        }

        private static bool CheckIfPlayerCanDoChessNextMove(int finalChoice)
        {
            return finalChoice != -1;
        }

        private static bool ComputerCanDoChessNextMove(int finalChoice)
        {
            return finalChoice != -1;
        }

        private static bool ThisIsFirstMove()
        {
            return EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(State) < 2;
        }

        private static bool DidNotFoundAnyChoices(int finalChoice)
        {
            return finalChoice == -1;
        }

        protected static void BackToInitialState(SortedList<int, bool> outsideEmptyCells, KeyValuePair<int, bool> x)
        {
            State[x.Key - 1] = _oldValue;
            outsideEmptyCells[x.Key] = true;
            _oldValue = '\0';
        }

        private static bool FoundOptionsForNextMove(int finalChoice, Dictionary<int, int> possibleGoodMoves)
        {
            return possibleGoodMoves.Keys.Count > 0 && finalChoice == -1;
        }

        private void CheckIfCompCanCloseNextMove(SortedList<int, bool> outsideEmptyCells,
            IDictionary<int, int> possibleGoodMoves, KeyValuePair<int, bool> x, KeyValuePair<int, bool> y)
        {
            if (!NextMoveCellWillBeAvailable(outsideEmptyCells, y)) return;
            try
            {
                TheNewState_2(y, ComputerXor0);
                MessUpPlayersMoves();
            }
            catch (ChessException e)
            {
                if (e.Message.Length == 2)
                {
                    if (possibleGoodMoves.ContainsKey(x.Key))
                    {
                        possibleGoodMoves[x.Key]++;
                    }
                    else
                    {
                        possibleGoodMoves.Add(x.Key, 1);
                    }
                }
            }
            BackToInitialState_2(y);
        }

        protected static void BackToInitialState_2(KeyValuePair<int, bool> y)
        {
            State[y.Key - 1] = _oldValue2;
            _oldValue2 = '\0';
        }

        protected void TheNewState_2(KeyValuePair<int, bool> y, char xor0)
        {
            _oldValue2 = State[y.Key - 1];
            State[y.Key - 1] = xor0;
        }

        protected static bool NextMoveCellWillBeAvailable(SortedList<int, bool> outsideEmptyCells,
            KeyValuePair<int, bool> y)
        {
            return outsideEmptyCells[y.Key];
        }

        private static int GetLeastProbableMoveAsTheChoosenOne(Dictionary<int, int> possibleGoodMoves)
        {
            var minNumberOfPosibilitiesNextRound = possibleGoodMoves.OrderBy(pair => pair.Value).First();
            return possibleGoodMoves
                .Where(x => x.Value == minNumberOfPosibilitiesNextRound.Value)
                .OrderBy(emp => Guid.NewGuid())
                .First().Key;
        }

        private static bool IsFirstMove(int iminentMove)
        {
            return !(iminentMove == -1 && EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(State) >= 2);
        }

        protected static void TheNewState(SortedList<int, bool> outsideEmptyCells, KeyValuePair<int, bool> x, char xor0)
        {
            outsideEmptyCells[x.Key] = false;
            _oldValue = State[x.Key - 1];
            State[x.Key - 1] = xor0;
        }

        private void CheckIfGameCanBeClosedNextRound(ref int finalChoice, KeyValuePair<int, bool> x)
        {
            try
            {
                MessUpPlayersMoves();
            }
            catch (ChessException)
            {
                finalChoice = x.Key;
            }
        }
    }
}