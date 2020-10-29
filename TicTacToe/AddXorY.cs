using UseCases.Interfaces;

namespace UseCases
{
    public class AddXorY : SetInitialRequirements
    {
        protected AddXorY(IOutput ui, IFactory factory)
            : base(ui, factory)
        {
        }

        public void AddChoice(int i)
        {
            IsComputerTurn = !IsComputerTurn;
            Tryes++;
            if (PrintX)
            {
                state[i - 1] = 'X';
                PrintX = false;
            }
            else
            {
                state[i - 1] = '0';
                PrintX = true;
            }
        }
    }
}