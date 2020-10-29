using System;
using System.Collections.Generic;
using ComputerLogicAlghoritm.HelperClasses;
using UseCases.Exception;

namespace ComputerLogicAlghoritm.The4GameModes
{
    public class MediumMode : SetUp
    {
        private static int _firstGoodMoveSameCell = -1;
        private static int _secondGoodMoveSameCell = -1;
        private static int _firstGoodMoveDifferentCells = -1;
        private static int _secondGoodMoveDifferentCells = -1;
        private static char _eliminateChessConfusion1 = 'f';
        private static char _eliminateChessConfusion2 = 's';

        public MediumMode(bool playerStarts)
            : base(playerStarts)
        {
        }

        public override int GetComputersChoice(IReadOnlyList<char> state)
        {
            State = DeepCopyArray(state);
            var iminentMove = CheckIfComputerCanCloseTheGameEvenIfInChess();
            return iminentMove != -1 ? iminentMove : MessUpPlayersMoves();
        }

        protected int CheckIfComputerCanCloseTheGameEvenIfInChess()
        {
            var iminentMove = -1;
            for (var i = 0; i < 9; i++)
            {
                iminentMove = CheckFor2CellsFormationIminentMove(i, ComputerXor0);
                if (iminentMove != -1)
                    return iminentMove;
            }
            return iminentMove;
        }

        private static int CheckFor2CellsFormationIminentMove(int i, char xorY)
        {
            var result = Checks.CheckIfColumnCloseToWinning(i, State, xorY);
            if (result != -1)
                return result;
            result = Checks.CheckIfLineCloseToWinning(i, State, xorY);
            if (result != -1)
                return result;
            result = Checks.CheckIfMinorDiagonalCloseToWinning(i, State, xorY);
            if (result != -1)
                return result;
            result = Checks.CheckIfMajorDiagonalCloseToWinning(i, State, xorY);
            return result;
        }

        protected int MessUpPlayersMoves()
        {
            TakeEliminateConfusionCharToInitialState();
            _secondGoodMoveDifferentCells = -1;
            _firstGoodMoveDifferentCells = -1;
            for (var i = 0; i < 9; i++)
            {
                var computerMoveChoice = CheckIf2CellFormationForBothPlayers_InOnCell(i);
                RememberPotentialMoves(computerMoveChoice);
            }
            return SoDoesPlayerHas_0or1or2_GoodMoves();
        }

        private static void TakeEliminateConfusionCharToInitialState()
        {
            _eliminateChessConfusion1 = 'f';
            _eliminateChessConfusion2 = 's';
        }

        private static void RememberPotentialMoves(int computerMoveChoice)
        {
            if (!FoundAGoodMove(computerMoveChoice)) return;
            if (_firstGoodMoveDifferentCells == -1)
                _firstGoodMoveDifferentCells = computerMoveChoice;
            else if (_secondGoodMoveDifferentCells == -1)
                _secondGoodMoveDifferentCells = computerMoveChoice;
        }

        private static bool FoundAGoodMove(int computerMoveChoice)
        {
            return computerMoveChoice != -1;
        }

        private int SoDoesPlayerHas_0or1or2_GoodMoves()
        {
            int computerMoveChoice;
            if (Found1GoodMove_StartingFromDifferntCells())
                computerMoveChoice = _firstGoodMoveDifferentCells;
            else if (Found2GoodMoves_StartingFromDifferentCells())
            {
                if (_firstGoodMoveDifferentCells == _secondGoodMoveDifferentCells)
                    computerMoveChoice = _firstGoodMoveDifferentCells;
                else if (IsChessWithBothPlayersCells())
                    computerMoveChoice = RecalculateJustComputerMove();
                else
                    throw new ChessException(_firstGoodMoveDifferentCells + _secondGoodMoveDifferentCells.ToString());
            }
            else if (GetType().Name.Equals("MediumMode"))
                computerMoveChoice = NoGoodMoveIsARandomMove();
            else
                computerMoveChoice = -1;
            return computerMoveChoice;
        }

        private int RecalculateJustComputerMove()
        {
            var foundIt = -1;
            for (var i = 0; i < 9; i++)
            {
                if (CheckIf2InARowForEachPlayer(i, ComputerXor0) != -1)
                    foundIt = CheckIf2InARowForEachPlayer(i, ComputerXor0);
            }
            return foundIt;
        }

        private static int CheckIf2InARowForEachPlayer(int i, char xorY)
        {
            CheckFor2CellsFormation(i, xorY);

            if (Found1GoodMove())
            {
                if (_eliminateChessConfusion1.Equals('f'))
                    _eliminateChessConfusion1 = xorY;
                else if (_eliminateChessConfusion2.Equals('s'))
                    _eliminateChessConfusion2 = xorY;
                return _firstGoodMoveSameCell;
            }
            if (!Found2GoodMoves()) return -1;
            if (GoodMovesAreTheSame())
                return _firstGoodMoveSameCell;
            throw new ChessException(_firstGoodMoveSameCell + _secondGoodMoveSameCell.ToString());
        }

        private static bool Found2GoodMoves()
        {
            return _firstGoodMoveSameCell != -1 && _secondGoodMoveSameCell != -1;
        }

        private static bool GoodMovesAreTheSame()
        {
            return _firstGoodMoveSameCell == _secondGoodMoveSameCell;
        }

        private static bool Found1GoodMove()
        {
            return _firstGoodMoveSameCell != -1 && _secondGoodMoveSameCell == -1;
        }

        private static void CheckFor2CellsFormation(int i, char xorY)
        {
            var result = Checks.CheckIfColumnCloseToWinning(i, State, xorY);
            if (result != -1)
                _firstGoodMoveSameCell = result;
            result = Checks.CheckIfLineCloseToWinning(i, State, xorY);
            if (result != -1 && _firstGoodMoveSameCell != -1)
                _secondGoodMoveSameCell = result;
            else if (result != -1 && _firstGoodMoveSameCell == -1)
                _firstGoodMoveSameCell = result;
            result = Checks.CheckIfMinorDiagonalCloseToWinning(i, State, xorY);
            if (result != -1 && _firstGoodMoveSameCell != -1)
                _secondGoodMoveSameCell = result;
            else if (result != -1 && _firstGoodMoveSameCell == -1)
                _firstGoodMoveSameCell = result;
            result = Checks.CheckIfMajorDiagonalCloseToWinning(i, State, xorY);
            if (result != -1 && _firstGoodMoveSameCell != -1)
                _secondGoodMoveSameCell = result;
            else if (result != -1 && _firstGoodMoveSameCell == -1)
                _firstGoodMoveSameCell = result;
        }

        private static bool Found1GoodMove_StartingFromDifferntCells()
        {
            return _firstGoodMoveDifferentCells != -1 && _secondGoodMoveDifferentCells == -1;
        }

        private static bool Found2GoodMoves_StartingFromDifferentCells()
        {
            return _firstGoodMoveDifferentCells != -1 && _secondGoodMoveDifferentCells != -1;
        }

        private static bool IsChessWithBothPlayersCells()
        {
            return !_eliminateChessConfusion1.Equals(_eliminateChessConfusion2);
        }

        private static int NoGoodMoveIsARandomMove()
        {
            int computerMoveChoice;
            do
            {
                var random = new Random(Guid.NewGuid().GetHashCode());
                computerMoveChoice =
                    EmptyCellsOnTheBoard.GetArray(State)[random.Next(0, EmptyCellsOnTheBoard.GetArray(State).Count)];
            } while (IsComputerRandomChoiceBad(computerMoveChoice) && EmptyCellsOnTheBoard.GetArray(State).Count > 5);
            return computerMoveChoice;
        }

        private static bool IsComputerRandomChoiceBad(int computerMoveChoice)
        {
            if (computerMoveChoice != 2 && computerMoveChoice != 4 && computerMoveChoice != 6 && computerMoveChoice != 8)
                return false;
            if (State[computerMoveChoice - 2].Equals('0') && State[computerMoveChoice].Equals('X'))
                return true;
            if (State[computerMoveChoice - 2].Equals('X') && State[computerMoveChoice].Equals('0'))
                return true;
            return false;
        }

        private int CheckIf2CellFormationForBothPlayers_InOnCell(int i)
        {
            _secondGoodMoveSameCell = -1;
            _firstGoodMoveSameCell = -1;
            var x = CheckIf2InARowForEachPlayer(i, IsPlyerTurnNow ? PlayerXorY : ComputerXor0);

            return x == -1 ? CheckIf2InARowForEachPlayer(i, IsPlyerTurnNow ? ComputerXor0 : PlayerXorY) : x;
        }

        public override void CheckIfIHaveAnyChance(char[] state)
        {
            State = DeepCopyArray(state);
            MessUpPlayersMoves();
        }
    }
}