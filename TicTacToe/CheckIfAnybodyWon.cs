namespace UseCases
{
    public class CheckIfAnybodyWon
    {
        public CheckIfAnybodyWon(char[] state)
        {
            WeHaveAWinner = false;
            State = state;
        }

        private char[] State { get; set; }
        private bool WeHaveAWinner { get; set; }

        public bool DoWeHaveAWinner()
        {
            for (var i = 0; i < 9; i++)
            {
                CheckIfRowWon(i);
                CheckIfMajorDiagonalWon(i);
                CheckIfMinorDiagonalWon(i);
                CheckIfColumnWon(i);
                if (WeHaveAWinner)
                    return true;
            }
            return false;
        }

        private void CheckIfColumnWon(int i)
        {
            if (i >= 3) return;
            if (State[i] == State[i + 3] && State[i + 3] == State[i + 6])
            {
                WeHaveAWinner = true;
            }
        }

        private void CheckIfRowWon(int i)
        {
            if (i != 0 && i%3 != 0) return;
            if (State[i] == State[i + 1] && State[i + 1] == State[i + 2])
            {
                WeHaveAWinner = true;
            }
        }

        private void CheckIfMinorDiagonalWon(int i)
        {
            if (i != 2) return;
            if (State[i] == State[i + 2] && State[i + 2] == State[i + 4])
            {
                WeHaveAWinner = true;
            }
        }

        private void CheckIfMajorDiagonalWon(int i)
        {
            if (i != 0) return;
            if (State[i] == State[i + 4] && State[i + 4] == State[i + 8])
            {
                WeHaveAWinner = true;
            }
        }
    }
}