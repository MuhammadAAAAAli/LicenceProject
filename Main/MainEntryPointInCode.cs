using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using InitialScreen;
using Microsoft.Practices.Unity;
using UI;
using UseCases;
using UseCases.Interfaces;
using UserInterface;

namespace TicTacToeMain
{
    internal class MainEntryPointInCode
    {
        private static bool consoleOrGui;
        public static bool Console { get; private set; }
        private static PlayTheGame game;
        private static readonly UnityContainer MyContainer = new UnityContainer();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32")]
        public static extern IntPtr GetConsoleWindow();

        private static void Main()
        {
            HideConsole();
            var form = new Form1();
            form.FormClosed += ExitTheWholeApplication;
            Form1.ChoiceInitialScreen += GetChoice;
            form.ShowDialog();

            if (consoleOrGui)
                SetUpUnityContainerForConsole();
            else
               SetUpUnityContainerForGui();
            Main2(null, null);
        }
        private static void GetChoice(object sender, EventArgs e)
        {
            consoleOrGui = (bool)sender;
        }

        private static void PopulateEventsForGuiDependecyInversion()
        {
            PlayGui.HaveAnotherGo += Main2;
            ChooseLevelGui.ChooseLevelGuiIsClosedEvent += ExitTheWholeApplication;
        }

        private static void ShowConsole()
        {
            var console = GetConsoleWindow();
            if (IntPtr.Zero != console)
            {
                ShowWindow(console, 1);
            }
        }

        private static void SetUpUnityContainerForGui()
        {
            MyContainer.RegisterType<IOutput, ChooseLevelGui>();
            MyContainer.RegisterType<IFactory, Factory>();
        }
        private static void SetUpUnityContainerForConsole()
        {
            MyContainer.RegisterType<IOutput, ConsoleUi>();
            MyContainer.RegisterType<IFactory, Factory>();
        }

        private static void ExitTheWholeApplication(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        public static void Main2(object sender, EventArgs e)
        {
            if (WeAreWorkingWithConsole())
            {
                PlayTillYouDropOnConsole();
            }
            else if (WeAreWorkingWithGui())
            {
                PlayTillYouDropOnGui();
            }
        }

        private static void PlayTillYouDropOnGui()
        {
            PopulateEventsForGuiDependecyInversion();
            bool playAgain;
           /* do
            {*/
                playAgain = false;
                var keyOk = false;
                HideConsole();

                game = MyContainer.Resolve<PlayTheGame>();
                game.Play();
                CheckIfTheUserWantsToGoAgainOnGui(ref playAgain, ref keyOk);
    
            if ( playAgain )
                Main();
            else
                Environment.Exit(1);
            /*} while (playAgain);*/
        }

        private static void CheckIfTheUserWantsToGoAgainOnGui(ref bool playAgain, ref bool keyOk)
        {
            var result = MessageBox.Show(@"Do you want to play again ?", @"Go again ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                playAgain = true;
                HideOldGameUi();
            }
            else if (result == DialogResult.No)
            {
                Environment.Exit(1);
            }
        }

        private static void HideOldGameUi()
        {
            ((ChooseLevelGui) game.GetUi()).HidePlayGui();
        }

        private static void HideConsole()
        {
            var console = GetConsoleWindow();
            if (IntPtr.Zero != console)
            {
                ShowWindow(console, 0);
            }
        }

        private static bool WeAreWorkingWithGui()
        {
            return MyContainer.Registrations.Any(x => x.MappedToType.Name == "ChooseLevelGui");
        }

        private static bool WeAreWorkingWithConsole()
        {
            return MyContainer.Registrations.Any(x => x.MappedToType.Name == "ConsoleUi");
        }

        private static void PlayTillYouDropOnConsole()
        {
            ShowConsole();
            bool playAgain;
           /* do
            {*/
                System.Console.ResetColor();
                playAgain = false;
                var keyOk = false;
                var game = MyContainer.Resolve<PlayTheGame>();
                game.Play();
                CheckIfTheUserWantsToGoAgainOnConsole(ref playAgain, ref keyOk);
                if (playAgain)
                    Main();
                else
                    Environment.Exit(1);
           /* } while (playAgain);*/
        }

        private static void CheckIfTheUserWantsToGoAgainOnConsole(ref bool playAgain, ref bool keyOk)
        {
            System.Console.WriteLine(@"Do you want to play again ? Y/N");
            System.Console.ForegroundColor = ConsoleColor.Black;
            do
            {
                var newKeyFromConsole = System.Console.ReadKey();
                var c = newKeyFromConsole.KeyChar;
                CheckIfUserPressed_YorN(ref playAgain, ref keyOk, c);
            } while (!keyOk);
        }

        private static void CheckIfUserPressed_YorN(ref bool playAgain, ref bool keyOk, char c)
        {
            if (PressedY(c))
            {
                playAgain = true;
                keyOk = true;
            }
            else if (PressedN(c))
            {
                playAgain = false;
                keyOk = true;
            }
        }

        private static bool PressedN(char c)
        {
            return c.ToString().ToLower().Equals("n");
        }

        private static bool PressedY(char c)
        {
            return c.ToString().ToLower().Equals("y");
        }
    }
}