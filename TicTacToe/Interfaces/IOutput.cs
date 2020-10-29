using DataStructures;

namespace UseCases.Interfaces
{
    public interface IOutput
    {
        void PrintState(char[] state);
        int NextMoveChoice();
        void PrintLastPossibleMoves(char[] state, string winner, string moves, bool didPlayerStarted);
        void PrintInitialMessageGoGoGo(char[] state);
        void LoosingMessage(char[] state);
        void WinningMessage(char[] state, string winner);
        void TryAgainMessage(char[] state);
        InitialInfo GetGameModeAndFirstStart();
    }
}