using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DataStructures;
using UseCases.Interfaces;

namespace UserInterface
{
    public partial class ChooseLevelGui : Form, IOutput
    {
        public readonly PlayGui _playGui = new PlayGui();
        private readonly char[] _previousState = {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private InitialInfo _dtoToBeSend;
        private Thread _newThread;

        public static event EventHandler ChooseLevelGuiIsClosedEvent;

        public ChooseLevelGui()
        {
            InitializeComponent();
            FormClosed += ChooseLevelGuiIsClosed;
        }

        public void PrintState(char[] state)
        {
            var computerOption = ComputerAddedAnOptionInMeantime(state);
            if (computerOption != -1)
            {
                _playGui.UpdateUiWithComputerAlgChoice(computerOption);
            }
            DeepCopyVector(state);
        }

        public int NextMoveChoice()
        {
            do
            {
            } while (!_playGui.PlayerHasChoosed.Key);
            var DtoMoveChoice = _playGui.PlayerHasChoosed.Value;
            _playGui.PlayerHasChoosed = new KeyValuePair<bool, int>(false, -1);
            return DtoMoveChoice;
        }

        public void PrintLastPossibleMoves(char[] state, string winner, string moves, bool didPlayerStarted)
        {
            _playGui.Winner = winner;
            _playGui.ColorTheChessSituation = moves;
            _playGui.GameShouldStop = true;
            const string message = "  will win for sure !!!    ";
            PrintState(state);
            _playGui.SetMessagesOnUi(" \t\t" + winner + message +
                                     ((_playGui.PlayerStarts && winner.Equals("X")) ||
                                      (!_playGui.PlayerStarts && winner.Equals("0"))
                                         ? "You"
                                         : "Computer") +
                                     " won with style."); 
            _playGui.ShowMessages();
        }

        public void PrintInitialMessageGoGoGo(char[] state)
        {
            _playGui.SetMessagesOnUi(_playGui.PlayerStarts ? "Go go go .... X first !" : "Go go go .... !");
            _playGui.ShowMessages();
        }

        public void LoosingMessage(char[] state)
        {
            _playGui.GameShouldStop = true;
            _playGui.SetMessagesOnUi("You both lost suckers !!");
            PrintState(state);
            _playGui.ShowMessages();
        }

        public void WinningMessage(char[] state, string winner)
        {
            _playGui.GameShouldStop = true;
            PrintState(state);
            _playGui.SetMessagesOnUi(winner + " won the game !!! Yey ");
            _playGui.ShowMessages();
        }

        public void TryAgainMessage(char[] state)
        {
            _playGui.SetMessagesOnUi("     Try again :(");
            _playGui.ShowMessages();
        }

        public InitialInfo GetGameModeAndFirstStart()
        {
            ShowDialog();
            return _dtoToBeSend;
        }


        public void HidePlayGui()
        {
            _playGui.HideMyself();
        }

        public static void ChooseLevelGuiIsClosed(object sender, EventArgs e)
        {
            if (ChooseLevelGuiIsClosedEvent != null)
                ChooseLevelGuiIsClosedEvent(null, EventArgs.Empty);
        }

        private void DeepCopyVector(char[] newState)
        {
            for (var i = 0; i < 9; i++)
            {
                _previousState[i] = newState[i];
            }
        }

        private int ComputerAddedAnOptionInMeantime(char[] state)
        {
            for (var i = 0; i < 9; i++)
            {
                if (state[i] != _previousState[i])
                {
                    if (_previousState[i] >= 49 && _previousState[i] <= 57 &&
                        state[i].Equals(_playGui.PlayerStarts ? '0' : 'X'))
                        return i;
                }
            }
            return -1;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (UserChoosedWhoStarts() || singleModeRD.Checked)
            {
                PrepareTheInformationFromUserToBeSent();
                Hide();
                _playGui.PlayerStarts = iStartFirst.Checked;
                StartTheGameInANewBackgroundThread();
            }
        }

        private bool UserChoosedWhoStarts()
        {
            return iStartFirst.Checked || computerStartsFirst.Checked;
        }

        private void StartTheGameInANewBackgroundThread()
        {
            _newThread = new Thread(GameUi) {IsBackground = true};
            Console.WriteLine(@"Thread number " + _newThread.ManagedThreadId + "  !!");
            _newThread.Start();
        }

        private void PrepareTheInformationFromUserToBeSent()
        {
            var choosedLevel = allRadioButtons.Controls.OfType<RadioButton>().First(x => x.Checked);
            var whatDidTheUserChoosed = choosedLevel.Name;
            if (singleModeRD.Checked)
            {
                _dtoToBeSend = new InitialInfo(0, false);
            }
            else if (whatDidTheUserChoosed.Contains("easy"))
            {
                _dtoToBeSend = new InitialInfo(1, iStartFirst.Checked);
            }
            else if (whatDidTheUserChoosed.Contains("medium"))
            {
                _dtoToBeSend = new InitialInfo(2, iStartFirst.Checked);
            }
            else if (whatDidTheUserChoosed.Contains("hard"))
            {
                _dtoToBeSend = new InitialInfo(3, iStartFirst.Checked);
            }
            else if (whatDidTheUserChoosed.Contains("expert"))
            {
                _dtoToBeSend = new InitialInfo(4, iStartFirst.Checked);
            }
        }

        public void GameUi()
        {
            _playGui.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void singleModeRD_CheckedChanged(object sender, EventArgs e)
        {
            allWhoStartsFirstButtons.Hide();
        }

        private void easyModeRB_CheckedChanged(object sender, EventArgs e)
        {
            allWhoStartsFirstButtons.Show();
        }

        private void mediumModeRB_CheckedChanged(object sender, EventArgs e)
        {
            allWhoStartsFirstButtons.Show();
        }

        private void hardModeRB_CheckedChanged(object sender, EventArgs e)
        {
            allWhoStartsFirstButtons.Show();
        }

        private void expertModeRB_CheckedChanged(object sender, EventArgs e)
        {
            allWhoStartsFirstButtons.Show();
        }

        private void ChooseLevelGui_Load(object sender, EventArgs e)
        {
        }
    }
}