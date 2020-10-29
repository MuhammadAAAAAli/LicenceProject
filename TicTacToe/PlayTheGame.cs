using UseCases.Exception;
using UseCases.Interfaces;

namespace UseCases
{
    public class PlayTheGame : AddXorY
    {
        public PlayTheGame(IOutput ui, IFactory factory) : base(ui, factory)
        {
        }

        public void CheckWhatToDoNext()
        {
            var checks = new CheckIfAnybodyWon(state);
            WeHaveAWinner = checks.DoWeHaveAWinner();
            if (NowbodyWon())
            {
                Ui.LoosingMessage(state);
                WeHaveALooser = true;
            }
            else if (WeHaveAWinner)
                Ui.WinningMessage(state, PrintX == false ? "X" : "0");
            else
                Ui.PrintState(state);
        }

        private bool NowbodyWon()
        {
            return Tryes == 9 && WeHaveAWinner == false;
        }

        public void Play()
        {
            try
            {
                while (!WeHaveAWinner && !WeHaveALooser)
                {
                    if (!TwoPlayerMode)
                    {
                        if (IsComputerTurn)
                        {
                            Alghoritm.SetIfPlayerTurn(!IsComputerTurn);
                            AddChoice(Alghoritm.GetComputersChoice(state));
                        }
                        else
                        {
                            Alghoritm.SetIfPlayerTurn(!IsComputerTurn);
                            if (!Alghoritm.GetType().ToString().Equals("ComputerLogicAlghoritm.The4GameModes.EasyMode"))
                                Alghoritm.CheckIfIHaveAnyChance(state);
                            AskUserWhatHeWantsToChoose();
                        }
                    }
                    else
                    {
                        AskUserWhatHeWantsToChoose();
                    }
                    CheckWhatToDoNext();
                }
            }
            catch (ChessException e)
            {
                Ui.PrintLastPossibleMoves(state, PrintX == false ? "X" : "0", e.Message, DoesPlayerStart);
            }
        }

        private void AskUserWhatHeWantsToChoose()
        {
            var goodChoice = false;
            do
            {
                var newPlayedCell = Ui.NextMoveChoice();
                if (newPlayedCell >= 1 && newPlayedCell <= 9 && IsCellNotPlayedYet(newPlayedCell))
                {
                    AddChoice(newPlayedCell);
                    goodChoice = true;
                }
                else
                    Ui.TryAgainMessage(state);
            } while (!goodChoice);
        }

        private bool IsCellNotPlayedYet(int newKeyAsInt)
        {
            return !(state[newKeyAsInt - 1].Equals('X') || state[newKeyAsInt - 1].Equals('0'));
        }
    }
}