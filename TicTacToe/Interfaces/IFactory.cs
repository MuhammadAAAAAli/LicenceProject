namespace UseCases.Interfaces
{
    public interface IFactory
    {
        IAlghorithm GetGameMode(int choosedDificultyLevel, bool playerStarts);
    }
}