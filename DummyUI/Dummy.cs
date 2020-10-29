using DataStructures;
using UseCases.Interfaces;

namespace DummyUI
{
    public class Dummy : IOutput
    {
        public void PrintState(char[] state)
        {
        }

        public int NextMoveChoice()
        {
            return 0;
        }

        public void PrintInitialMessageGoGoGo(char[] state)
        {
        }

        public void LoosingMessage(char[] state)
        {
        }

        public void WinningMessage(char[] state, string winner)
        {
        }

        public void TryAgainMessage(char[] state)
        {
        }

        public InitialInfo GetGameModeAndFirstStart()
        {
            return null;
        }

        public void PrintLastPossibleMoves(char[] state, string winner, string moves, bool didPlayerStarted)
        {
        }
    }
}