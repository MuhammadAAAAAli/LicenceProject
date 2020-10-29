using System.Collections.Generic;

namespace UseCases.Interfaces
{
    public interface IAlghorithm
    {
        int GetComputersChoice(IReadOnlyList<char> state);
        void CheckIfIHaveAnyChance(char[] state);
        void SetIfPlayerTurn(bool isPlayerTurn);
    }
}