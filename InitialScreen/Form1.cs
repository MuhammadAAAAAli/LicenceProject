using System;
using System.Windows.Forms;

namespace InitialScreen
{
    public partial class Form1 : Form
    {
        public static event EventHandler ChoiceInitialScreen;
        public Form1()
        {
            InitializeComponent();
        }

        private void consoleBtn_Click(object sender, EventArgs e)
        {
            OnChoiceInitialScreen(true);
            Hide();
        }

        private void guiBtn_Click(object sender, EventArgs e)
        {
            OnChoiceInitialScreen(false);
            Hide();
        }

        private static void OnChoiceInitialScreen(bool choice)
        {
            var handler = ChoiceInitialScreen;
            if (handler != null) handler(choice, EventArgs.Empty);
        }
    }
}