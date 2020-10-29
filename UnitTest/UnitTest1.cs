using ComputerLogicAlghoritm.HelperClasses;
using ComputerLogicAlghoritm.The4GameModes;
using DummyUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UseCases;
using UseCases.Exception;
using UseCases.Interfaces;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IAlghorithm _alghoritmEasy;
        private readonly IAlghorithm _alghoritmExpert;
        private readonly IAlghorithm _alghoritmHard;
        private readonly IAlghorithm _alghoritmMedium;
        private readonly PlayTheGame _game = new PlayTheGame(new Dummy(), null);

        public UnitTest1()
        {
            _alghoritmEasy = new EasyMode(true);
            _alghoritmMedium = new MediumMode(true);
            _alghoritmHard = new HardMode(true);
            _alghoritmExpert = new ExpertMode(true);
        }

        // ======================================================================


        [TestMethod]
        public void BasicFirstTest()
        {
            var correctVersion = new string(new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'});
            Assert.IsTrue(correctVersion.Equals(new string(_game.state)));
        }

        [TestMethod]
        public void XInFirstBox()
        {
            _game.AddChoice(1);
            var correctVersion = new string(new[] {'X', '2', '3', '4', '5', '6', '7', '8', '9'});
            Assert.IsTrue(correctVersion.Equals(new string(_game.state)));
        }

        [TestMethod]
        public void XInFirst0InSecond()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            var correctVersion = new string(new[] {'X', '0', '3', '4', '5', '6', '7', '8', '9'});
            Assert.IsTrue(correctVersion.Equals(new string(_game.state)));
        }

        [TestMethod]
        public void DummyGame()
        {
            for (var i = 0; i < 9; i++)
                _game.AddChoice(i + 1);
            var correctVersion = new string(new[] {'X', '0', 'X', '0', 'X', '0', 'X', '0', 'X'});
            Assert.IsTrue(correctVersion.Equals(new string(_game.state)));
        }

        // ======================================================================


        [TestMethod]
        public void XWinnerFirstRow()
        {
            _game.AddChoice(1);
            _game.AddChoice(9);
            _game.AddChoice(2);
            _game.AddChoice(8);
            _game.AddChoice(3);
            _game.CheckWhatToDoNext();
            Assert.IsTrue(_game.WeHaveAWinner);
        }

        [TestMethod]
        public void ZeroWinnerSecondRow()
        {
            _game.AddChoice(1);
            _game.AddChoice(4);
            _game.AddChoice(2);
            _game.AddChoice(5);
            _game.AddChoice(7);
            _game.AddChoice(6);
            _game.CheckWhatToDoNext();
            Assert.IsTrue(_game.WeHaveAWinner);
        }

        [TestMethod]
        public void ThreeInARowButDifferentRow()
        {
            _game.AddChoice(2);
            _game.AddChoice(9);
            _game.AddChoice(3);
            _game.AddChoice(8);
            _game.AddChoice(4);
            Assert.IsFalse(_game.WeHaveAWinner);
        }

        [TestMethod]
        public void DiagonalyWon()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(5);
            _game.AddChoice(8);
            _game.AddChoice(9);
            _game.CheckWhatToDoNext();
            Assert.IsTrue(_game.WeHaveAWinner);
        }

        [TestMethod]
        public void OtherDiagonalyWon()
        {
            _game.AddChoice(3);
            _game.AddChoice(2);
            _game.AddChoice(5);
            _game.AddChoice(8);
            _game.AddChoice(7);
            _game.CheckWhatToDoNext();
            Assert.IsTrue(_game.WeHaveAWinner);
        }

        [TestMethod]
        public void LineWon()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(4);
            _game.AddChoice(3);
            _game.AddChoice(7);
            _game.CheckWhatToDoNext();
            Assert.IsTrue(_game.WeHaveAWinner);
        }

        [TestMethod]
        public void LastLineWins()
        {
            _game.AddChoice(9);
            _game.AddChoice(1);
            _game.AddChoice(8);
            _game.AddChoice(2);
            _game.AddChoice(7);
            _game.CheckWhatToDoNext();
            Assert.IsTrue(_game.WeHaveAWinner);
        }

        // =====================================================================


        [TestMethod]
        public void CheckCompOneRandomChoice()
        {
            _game.AddChoice(9);
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            Assert.AreEqual(2, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }

        [TestMethod]
        public void CheckCompThreeRandomChoice()
        {
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            Assert.AreEqual(4, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }

        // ======================================================================


        [TestMethod]
        public void CheckIfAlgBlocksFirstColomn()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(4);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('0'));
        }

        [TestMethod]
        public void CheckIfAlgBlocksSecondColomn()
        {
            _game.AddChoice(2);
            _game.AddChoice(1);
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[7].Equals('0'));
        }

        [TestMethod]
        public void CheckIfAlgBlocksThirdColomn()
        {
            _game.AddChoice(3);
            _game.AddChoice(1);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[8].Equals('0'));
        }

        [TestMethod]
        public void CheckIfAlgBlocksFirstLine()
        {
            _game.AddChoice(1);
            _game.AddChoice(4);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[2].Equals('0'));
        }

        [TestMethod]
        public void CheckIfAlgBlocksSecondLine()
        {
            _game.AddChoice(6);
            _game.AddChoice(1);
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[3].Equals('0'));
        }

        [TestMethod]
        public void CheckIfAlgBlocksThirdLine()
        {
            _game.AddChoice(7);
            _game.AddChoice(1);
            _game.AddChoice(9);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[7].Equals('0'));
        }

        [TestMethod]
        public void CheckIfAlgBlocksMajorDiagonal()
        {
            _game.AddChoice(1);
            _game.AddChoice(7);
            _game.AddChoice(9);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[4].Equals('0'));
        }

        // ======================================================================

        [TestMethod]
        public void ChessOnComputerMeMajorDiagonalAnd3RdColomn()
        {
            char[] x = {};
            try
            {
                _game.AddChoice(1);
                _game.AddChoice(7);
                _game.AddChoice(6);
                _game.AddChoice(8);
                _game.AddChoice(9);
                _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            }
            catch (ChessException e)
            {
                x = e.Message.ToCharArray();
            }
            Assert.AreEqual(5, x[0] - 48);
            Assert.AreEqual(3, x[1] - 48);
        }

        [TestMethod]
        public void ChessOnComputerMinorDiagonalAndSecondLine()
        {
            char[] x = {};
            try
            {
                _game.AddChoice(7);
                _game.AddChoice(8);
                _game.AddChoice(4);
                _game.AddChoice(1);
                _game.AddChoice(5);
                _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            }
            catch (ChessException e)
            {
                x = e.Message.ToCharArray();
            }
            Assert.AreEqual(3, x[0] - 48);
            Assert.AreEqual(6, x[1] - 48);
        }

        [TestMethod]
        public void TwoPlayersCellsMakeAChess()
        {
            _game.DoesPlayerStart = true;
            _game.AddChoice(1);
            _game.AddChoice(3);
            _game.AddChoice(4);
            _game.AddChoice(6);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[8].Equals('0'));
            Assert.IsTrue(_game.DoesPlayerStart);
        }

        [TestMethod]
        public void CheckIfXTurn()
        {
            _game.DoesPlayerStart = true;
            _game.AddChoice(1);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.DoesPlayerStart);
        }

        [TestMethod]
        public void CheckIf0Turn()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsFalse(_game.PrintX);
        }

        [TestMethod]
        public void SpecialCaseTest()
        {
            _game.AddChoice(2);
            _game.AddChoice(4);
            _game.AddChoice(3);
            _game.AddChoice(7);
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('0'));
        }

        [TestMethod]
        public void BadChoiceAtTheBegining_1()
        {
            _game.AddChoice(7);
            _game.AddChoice(9);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsFalse(_game.state[7].Equals('0'));
        }

        [TestMethod]
        public void BadChoiceAtTheBegining_2()
        {
            _game.AddChoice(4);
            _game.AddChoice(7);
            _game.AddChoice(9);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsFalse(_game.state[7].Equals('0'));
        }

        [TestMethod]
        public void SameCellBothPlayersWin()
        {
            _game.AddChoice(1);
            _game.AddChoice(3);
            _game.AddChoice(5);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[8].Equals('X'));
        }

        [TestMethod]
        public void ImposibbleSituation()
        {
            _game.AddChoice(2);
            _game.AddChoice(5);
            _game.AddChoice(3);
            _game.AddChoice(6);
            _game.AddChoice(4);
            _game.AddChoice(8);
            _game.AddChoice(7);
            _game.AddChoice(9);
            _alghoritmMedium.SetIfPlayerTurn(true);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('X'));
        }

        [TestMethod]
        public void NearlyImposibleTest()
        {
            _game.AddChoice(2);
            _game.AddChoice(4);
            _game.AddChoice(3);
            _game.AddChoice(6);
            _game.AddChoice(5);
            _game.AddChoice(7);
            _game.AddChoice(9);
            _game.AddChoice(8);
            _alghoritmMedium.SetIfPlayerTurn(true);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('X'));
        }

        [TestMethod]
        public void CheckIfIGetException()
        {
            _game.AddChoice(1);
            _game.AddChoice(3);
            _game.AddChoice(4);
            _game.AddChoice(6);
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[8].Equals('0'));
        }

        [TestMethod]
        public void CheckNoGoodMoveFunction()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(4);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
        }

        [TestMethod]
        public void NumberOfOcupiedCells()
        {
            _game.AddChoice(1);
            Assert.AreEqual(1, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
            _game.AddChoice(2);
            Assert.AreEqual(2, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }

        [TestMethod]
        public void IfHardDoesRandomCellFirstRound_1()
        {
            _game.AddChoice(1);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.AreEqual(2, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }

        [TestMethod]
        public void IfHardDoesRandomCellFirstRound_2()
        {
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.AreEqual(1, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }

        [TestMethod]
        public void CheckHardBlocksPlayerSecondRound()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(4);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('0'));
        }

        [TestMethod]
        public void CheckChessForHard()
        {
            char[] x = {};
            try
            {
                _game.AddChoice(1);
                _game.AddChoice(7);
                _game.AddChoice(6);
                _game.AddChoice(8);
                _game.AddChoice(9);
                _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            }
            catch (ChessException e)
            {
                x = e.Message.ToCharArray();
            }
            Assert.AreEqual(5, x[0] - 48);
            Assert.AreEqual(3, x[1] - 48);
        }

        [TestMethod]
        public void CheckHardLogic_1Step()
        {
            _game.AddChoice(1);
            _game.AddChoice(2);
            _game.AddChoice(8);
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('X'));
        }

        [TestMethod]
        public void CheckHardLogic_2Steps()
        {
            _game.AddChoice(1);
            _game.AddChoice(7);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[3].Equals('X'));
        }

        [TestMethod]
        [ExpectedException(typeof (ChessException))]
        public void CheckHardSureWin()
        {
            _game.AddChoice(1);
            _game.AddChoice(4);
            _game.AddChoice(6);
            _game.AddChoice(8);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[2].Equals('X'));
            _alghoritmHard.CheckIfIHaveAnyChance(_game.state);
        }

        [TestMethod]
        public void CheckIfComputerWantsChessFirst()
        {
            var alghoritmHard2 = new HardMode(false);
            _game.AddChoice(4);
            _game.AddChoice(2);
            _game.AddChoice(8);
            _game.AddChoice(6);
            _game.AddChoice(alghoritmHard2.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('X'));
        }

        [TestMethod]
        public void CheckExpertMode5First()
        {
            _game.AddChoice(1);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[4].Equals('0'));
        }

        [TestMethod]
        public void CheckExpertBlocksAtFirstMove()
        {
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('0') || _game.state[2].Equals('0') || _game.state[4].Equals('0') ||
                          _game.state[7].Equals('0'));
        }

        [TestMethod]
        public void CheckExpertAlgWorksWithHard()
        {
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
        }

        // =========================================================


        [TestMethod]
        public void CheckNewStyleAlgBug()
        {
            try
            {
                _game.AddChoice(6);
                _game.AddChoice(9);
                _game.AddChoice(1);
                _game.AddChoice(8);
                _game.AddChoice(7);
                _game.AddChoice(4);
                _game.AddChoice(3);
                _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            }
            catch (ChessException e)
            {
                Assert.IsTrue(e.Message.Equals("25"));
            }
        }

        [TestMethod]
        public void CheckIfPlayerChooses5FirstCompChoosesCorner()
        {
            _game.AddChoice(5);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('0') || _game.state[2].Equals('0') || _game.state[6].Equals('0') ||
                          _game.state[8].Equals('0'));
        }

        [TestMethod]
        public void CheckIfComputerClosesMeWhenIDoChess_medium()
        {
            _game.AddChoice(5);
            _game.AddChoice(7);
            _game.AddChoice(3);
            _game.AddChoice(9);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('0') && _game.state[7].Equals('0') && _game.state[8].Equals('0'));
        }

        [TestMethod]
        public void CheckIfComputerClosesMeWhenIDoChess_medium2()
        {
            _game.AddChoice(5);
            _game.AddChoice(1);
            _game.AddChoice(9);
            _game.AddChoice(7);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmMedium.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('0') && _game.state[3].Equals('0') && _game.state[6].Equals('0'));
        }

        [TestMethod]
        public void CheckIfComputerClosesMeWhenIDoChess_hard()
        {
            _game.AddChoice(5);
            _game.AddChoice(7);
            _game.AddChoice(3);
            _game.AddChoice(9);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('0') && _game.state[7].Equals('0') && _game.state[8].Equals('0'));
        }

        [TestMethod]
        public void CheckIfComputerClosesMeWhenIDoChess_hard2()
        {
            _game.AddChoice(5);
            _game.AddChoice(1);
            _game.AddChoice(9);
            _game.AddChoice(7);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmHard.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('0') && _game.state[3].Equals('0') && _game.state[6].Equals('0'));
        }

        [TestMethod]
        public void CheckIfComputerClosesMeWhenIDoChess_expert()
        {
            _game.AddChoice(5);
            _game.AddChoice(7);
            _game.AddChoice(3);
            _game.AddChoice(9);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[6].Equals('0') && _game.state[7].Equals('0') && _game.state[8].Equals('0'));
        }

        [TestMethod]
        public void CheckIfComputerClosesMeWhenIDoChess_expert2()
        {
            _game.AddChoice(5);
            _game.AddChoice(1);
            _game.AddChoice(9);
            _game.AddChoice(7);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmExpert.GetComputersChoice(_game.state));
            Assert.IsTrue(_game.state[0].Equals('0') && _game.state[3].Equals('0') && _game.state[6].Equals('0'));
        }

        //   [Ignore]
        [TestMethod]
        public void CheckIfComputerMakesAMoveWhenIDoChess_easy()
        {
            _game.AddChoice(5);
            _game.AddChoice(7);
            _game.AddChoice(3);
            _game.AddChoice(9);
            _game.AddChoice(2);
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            Assert.AreEqual(6, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }

        //    [Ignore]
        [TestMethod]
        public void CheckIfComputerMakesAMoveWhenIDoChess_easy2()
        {
            _game.AddChoice(5);
            _game.AddChoice(1);
            _game.AddChoice(9);
            _game.AddChoice(7);
            _game.AddChoice(6);
            _game.AddChoice(_alghoritmEasy.GetComputersChoice(_game.state));
            Assert.AreEqual(6, EmptyCellsOnTheBoard.GetnumberOfOcupiedOnes(_game.state));
        }
    }
}