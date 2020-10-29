using System.Collections.Generic;
using UseCases.Interfaces;

namespace ComputerLogicAlghoritm
{
    public abstract class SetUp : IAlghorithm
    {
        protected bool IsPlyerTurnNow;

        protected SetUp(bool playerStarts)
        {
            WhoHasXAnd0(playerStarts);
        }

        protected char ComputerXor0 { get; private set; }
        protected char PlayerXorY { get; private set; }
        protected static char[] State { get; set; }

        public void SetIfPlayerTurn(bool isPlayerTurn)
        {
            IsPlyerTurnNow = isPlayerTurn;
        }

        public abstract void CheckIfIHaveAnyChance(char[] state);
        public abstract int GetComputersChoice(IReadOnlyList<char> state);

        private void WhoHasXAnd0(bool playerStarts)
        {
            if (playerStarts)
            {
                ComputerXor0 = '0';
                PlayerXorY = 'X';
            }
            else
            {
                ComputerXor0 = 'X';
                PlayerXorY = '0';
            }
        }

        protected static char[] DeepCopyArray(IReadOnlyList<char> originalState)
        {
            char[] copyState = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            for (var i = 0; i < 9; i++)
            {
                copyState[i] = originalState[i];
            }
            return copyState;
        }
    }
}