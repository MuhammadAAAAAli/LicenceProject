using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class PlayGui : Form
    {
        public PlayGui()
        {
            ColorTheChessSituation = null;
            InitializeComponent();
            FormClosed += ChooseLevelGui.ChooseLevelGuiIsClosed;
        }

        public string Winner { get; set; }
        public string ColorTheChessSituation { get; set; }
        public bool GameShouldStop { get; set; }
        public bool PlayerStarts { get; set; }
        public KeyValuePair<bool, int> PlayerHasChoosed { get; set; }
        public static event EventHandler HaveAnotherGo;

        public void HideMyself()
        {
            if (InvokeRequired)
            {
                Invoke(
                    new MethodInvoker(
                        HideMyself));
            }
            else
            {
                Hide();
            }
        }

        public void ShowMessages()
        {
            if (InvokeRequired)
            {
                Invoke(
                    new MethodInvoker(
                        delegate { ShowMessages(); }));
            }
            else
            {
                messagesOnUi.Show();
            }
        }

        public void SetMessagesOnUi(string text)
        {
            if (ColorTheChessSituation != null)
            {
                if (ColorTheChessSituation.Contains("1"))
                {
                    button1.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("2"))
                {
                    button2.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("3"))
                {
                    button3.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("4"))
                {
                    button4.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("5"))
                {
                    button5.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("6"))
                {
                    button6.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("7"))
                {
                    button7.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("8"))
                {
                    button8.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
                if (ColorTheChessSituation.Contains("9"))
                {
                    button9.BackColor = Winner.Equals("0") ? Color.Blue : Color.Red;
                }
            }

            if (InvokeRequired)
            {
                Invoke(
                    new MethodInvoker(
                        delegate { SetMessagesOnUi(text); }));
            }
            else
            {
                messagesOnUi.Text = text;
                messagesOnUi.Left = (ClientSize.Width - messagesOnUi.Width)/2;
                messagesOnUi.Top = ClientSize.Height*80/100;
            }
        }

        public void UpdateUiWithComputerAlgChoice(int buttonToBeChanged)
        {
            if (InvokeRequired)
            {
                Invoke(
                    new MethodInvoker(
                        delegate { UpdateUiWithComputerAlgChoice(buttonToBeChanged); }));
            }
            else
            {
                buttonToBeChanged++;
                if (buttonToBeChanged == 1)
                {
                    button1.Text = PlayerStarts ? "0" : "X";
                    button1.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 2)
                {
                    button2.Text = PlayerStarts ? "0" : "X";
                    button2.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 3)
                {
                    button3.Text = PlayerStarts ? "0" : "X";
                    button3.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 4)
                {
                    button4.Text = PlayerStarts ? "0" : "X";
                    button4.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 5)
                {
                    button5.Text = PlayerStarts ? "0" : "X";
                    button5.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 6)
                {
                    button6.Text = PlayerStarts ? "0" : "X";
                    button6.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 7)
                {
                    button7.Text = PlayerStarts ? "0" : "X";
                    button7.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 8)
                {
                    button8.Text = PlayerStarts ? "0" : "X";
                    button8.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
                else if (buttonToBeChanged == 9)
                {
                    button9.Text = PlayerStarts ? "0" : "X";
                    button9.ForeColor = PlayerStarts ? Color.Blue : Color.Red;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 1);
                button1.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button1.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 2);
                button2.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button2.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 3);
                button3.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button3.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 4);
                button4.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button4.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 5);
                button5.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button5.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 6);
                button6.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button6.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 7);
                button7.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button7.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 8);
                button8.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button8.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Text.Equals("") && !GameShouldStop)
            {
                PlayerHasChoosed = new KeyValuePair<bool, int>(true, 9);
                button9.ForeColor = PlayerStarts ? Color.Red : Color.Blue;
                button9.Text = PlayerStarts ? "X" : "0";
                messagesOnUi.Hide();
            }
        }
    }
}