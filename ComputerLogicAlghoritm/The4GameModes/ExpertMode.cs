using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ComputerLogicAlghoritm.HelperClasses;
using UseCases;

namespace ComputerLogicAlghoritm.The4GameModes
{
    public class ExpertMode : HardMode
    {
        public ExpertMode(bool playerStarts)
            : base(playerStarts)
        {
        }

        public override int GetComputersChoice(IReadOnlyList<char> state)
        {
            State = DeepCopyArray(state);

            var iminentMove = CheckIfComputerCanCloseTheGameEvenIfInChess();
            if (ThereIsAIminentMoveAndComputerWillWin(iminentMove))
                return iminentMove;

            var outsideEmptyCells = EmptyCellsOnTheBoard.GetSortedList(State);
            var emptyCells = EmptyCellsOnTheBoard.GetSortedList(State);

            if (PlayerHasTwoOreModeCellsDown(emptyCells)) return GetHardDificultyChoice();

            if (emptyCells.Count == 9)
                return 5;

            if (PlayerFirstChoiceWasACorner())
                return 5;

            if (PlayerFirstChoiceWasTheCenter())
                return CreateListWithCornerCells().OrderBy(xx => Guid.NewGuid()).First();

            return GetAllPossibleMovesToBlockPlayerStrategy(outsideEmptyCells, emptyCells)
                        .OrderBy(emp => Guid.NewGuid())
                        .First();


        }

        private static bool ThereIsAIminentMoveAndComputerWillWin(int iminentMove)
        {
            return iminentMove != -1;
        }

        private static bool PlayerFirstChoiceWasTheCenter()
        {
            return State[4].Equals('X');
        }

        private static IEnumerable<int> CreateListWithCornerCells()
        {
            var x = new List<int> { 1, 3, 7, 9 };
            return x;
        }

        private static bool PlayerHasTwoOreModeCellsDown(ICollection emptyCells)
        {
            return emptyCells.Count <= 7;
        }

        private static bool PlayerFirstChoiceWasACorner()
        {
            return State[0].Equals('X') || State[2].Equals('X') || State[6].Equals('X') || State[8].Equals('X');
        }

        private IEnumerable<int> GetAllPossibleMovesToBlockPlayerStrategy(SortedList<int, bool> outsideEmptyCells,
            SortedList<int, bool> emptyCells)
        {
            var posibleGoodMoves = new List<int>();
            foreach (var x in emptyCells)
            {
                TheNewState(outsideEmptyCells, x, PlayerXorY);
                foreach (var y in emptyCells.Where(y => NextMoveCellWillBeAvailable(outsideEmptyCells, y)))
                {
                    TheNewState_2(y, PlayerXorY);
                    var checks = new CheckIfAnybodyWon(State);
                    if (checks.DoWeHaveAWinner())
                    {
                        posibleGoodMoves.Add(x.Key);
                    }
                    BackToInitialState_2(y);
                }
                BackToInitialState(outsideEmptyCells, x);
            }
            return posibleGoodMoves.Distinct();
        }
    }
}