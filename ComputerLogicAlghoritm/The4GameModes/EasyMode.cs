using System;
using System.Collections.Generic;
using ComputerLogicAlghoritm.HelperClasses;

namespace ComputerLogicAlghoritm.The4GameModes
{
    public class EasyMode : MediumMode
    {
        public EasyMode(bool playerStarts)
            : base(playerStarts)
        {
        }

        public override int GetComputersChoice(IReadOnlyList<char> state)
        {
            State = DeepCopyArray(state);
            var random = new Random(Guid.NewGuid().GetHashCode());
            return
                EmptyCellsOnTheBoard.GetArray(State)[random.Next(0, EmptyCellsOnTheBoard.GetArray(State).Count)];
        }
    }
}