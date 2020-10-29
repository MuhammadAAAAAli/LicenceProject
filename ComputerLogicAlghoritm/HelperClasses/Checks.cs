namespace ComputerLogicAlghoritm.HelperClasses
{
    public static class Checks
    {
        public static int CheckIfColumnCloseToWinning(int i, char[] state, char compOrPlayer)
        {
            if (i >= 3) return -1;
            if (state[i].Equals(state[i + 3]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[i + 6].Equals('X') || state[i + 6].Equals('0')))
                    return i + 7;
            }
            else if (state[i + 3].Equals(state[i + 6]) && state[i + 3].Equals(compOrPlayer))
            {
                if (!(state[i + 0].Equals('X') || state[i + 0].Equals('0')))
                    return i + 1;
            }
            else if (state[i].Equals(state[i + 6]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[i + 3].Equals('X') || state[i + 3].Equals('0')))
                    return i + 4;
            }
            return -1;
        }

        public static int CheckIfLineCloseToWinning(int i, char[] state, char compOrPlayer)
        {
            if (i != 0 && i%3 != 0) return -1;
            if (state[i].Equals(state[i + 1]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[i + 2].Equals('X') || state[i + 2].Equals('0')))
                    return i + 3;
            }
            else if (state[i + 1].Equals(state[i + 2]) && state[i + 1].Equals(compOrPlayer))
            {
                if (!(state[i + 0].Equals('X') || state[i + 0].Equals('0')))
                    return i + 1;
            }
            else if (state[i].Equals(state[i + 2]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[i + 1].Equals('X') || state[i + 1].Equals('0')))
                    return i + 2;
            }
            return -1;
        }

        public static int CheckIfMinorDiagonalCloseToWinning(int i, char[] state, char compOrPlayer)
        {
            if (i != 2) return -1;
            if (state[i].Equals(state[i + 2]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[6].Equals('X') || state[6].Equals('0')))
                    return 7;
            }
            else if (state[i + 2].Equals(state[i + 4]) && state[i + 2].Equals(compOrPlayer))
            {
                if (!(state[2].Equals('X') || state[2].Equals('0')))
                    return 3;
            }
            else if (state[i].Equals(state[i + 4]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[4].Equals('X') || state[4].Equals('0')))
                    return 5;
            }
            return -1;
        }

        public static int CheckIfMajorDiagonalCloseToWinning(int i, char[] state, char compOrPlayer)
        {
            if (i != 0) return -1;
            if (state[i].Equals(state[i + 4]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[8].Equals('X') || state[8].Equals('0')))
                    return 9;
            }
            else if (state[i + 4].Equals(state[i + 8]) && state[i + 4].Equals(compOrPlayer))
            {
                if (!(state[0].Equals('X') || state[0].Equals('0')))
                    return 1;
            }
            else if (state[i].Equals(state[i + 8]) && state[i].Equals(compOrPlayer))
            {
                if (!(state[4].Equals('X') || state[4].Equals('0')))
                    return 5;
            }
            return -1;
        }
    }
}