using UseCases.Interfaces;

namespace UseCases
{
    public class SetInitialRequirements : ProgramState
    {
        protected SetInitialRequirements(IOutput ui, IFactory factory)
            : base(ui, factory)
        {
            var x = Ui.GetGameModeAndFirstStart();
            if (x != null)
            {
                if (x.GameMode == 0)
                    TwoPlayerMode = true;
                else
                {
                    TwoPlayerMode = false;
                    DoesPlayerStart = x.PlayerStarts;
                    IsComputerTurn = !x.PlayerStarts;
                    Alghoritm = Factory.GetGameMode(x.GameMode, x.PlayerStarts);
                }
            }
            Ui.PrintInitialMessageGoGoGo(state);
        }
    }
}