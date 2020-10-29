using UseCases.Interfaces;

namespace UseCases
{
    public class ProgramState
    {
        protected IAlghorithm Alghoritm;
        protected IFactory Factory;
        protected int Tryes = 0;
        protected IOutput Ui;

        protected ProgramState(IOutput ui, IFactory factory)
        {
            AtributesGetBasicInitialization(ui, factory);
        }

        public bool WeHaveAWinner { get; protected set; }
        protected bool WeHaveALooser { get; set; }
        public char[] state { get; private set; }
        public bool PrintX { get; protected set; }
        public bool DoesPlayerStart { get; set; }
        protected bool TwoPlayerMode { get; set; }
        protected bool IsComputerTurn { get; set; }

        public IOutput GetUi()
        {
            return Ui;
        }

        private void Test()
        {
            var x = 5;
        }

        private void AtributesGetBasicInitialization(IOutput ui, IFactory factory)
        {
            Ui = ui;
            state = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            TwoPlayerMode = false;
            WeHaveAWinner = false;
            WeHaveALooser = false;
            PrintX = true;
            if (factory != null)
                Factory = factory;
        }
    }
}