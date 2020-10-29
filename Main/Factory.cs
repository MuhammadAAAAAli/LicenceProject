using ComputerLogicAlghoritm.HelperClasses;
using ComputerLogicAlghoritm.The4GameModes;
using UseCases.Interfaces;

//using JetBrains.Annotations;

namespace TicTacToeMain
{
    //   [UsedImplicitly]
    public class Factory : IFactory
    {
        public IAlghorithm GetGameMode(int choosedDificultyLevel, bool playerStarts)
        {
            switch (choosedDificultyLevel)
            {
                case (int) DificultyLevelEnum.Easy:
                    return new EasyMode(playerStarts);
                case (int) DificultyLevelEnum.Medium:
                    return new MediumMode(playerStarts);
                case (int) DificultyLevelEnum.Hard:
                    return new HardMode(playerStarts);
                case (int) DificultyLevelEnum.Expert:
                    return new ExpertMode(playerStarts);
                default:
                    return null;
            }
        }
    }
}