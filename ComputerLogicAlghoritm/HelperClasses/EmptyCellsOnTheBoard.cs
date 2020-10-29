using System.Collections.Generic;

namespace ComputerLogicAlghoritm.HelperClasses
{
    public class EmptyCellsOnTheBoard
    {
        public static List<int> GetArray(char[] state)
        {
            var freeCells = new List<int>();
            for (var i = 0; i < 9; i++)
            {
                if (!(state[i].Equals('X') || state[i].Equals('0')))
                {
                    freeCells.Add(i + 1);
                }
            }
            return freeCells;
        }

        public static int GetnumberOfOcupiedOnes(char[] state)
        {
            return 9 - GetArray(state).Count;
        }

        public static SortedList<int, bool> GetSortedList(char[] state)
        {
            var freeCells = new SortedList<int, bool>();
            for (var i = 0; i < 9; i++)
            {
                if (!(state[i].Equals('X') || state[i].Equals('0')))
                {
                    freeCells.Add(i + 1, true);
                }
            }
            return freeCells;
        }
    }
}