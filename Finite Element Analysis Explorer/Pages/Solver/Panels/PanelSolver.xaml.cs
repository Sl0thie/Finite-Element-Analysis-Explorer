using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class PanelSolver : Page
    {
        internal static PanelSolver Current;

        public PanelSolver()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            comboBox_Solver.SelectedIndex = Options.CurrentSolver;
            checkBox_AutoStart.IsChecked = Options.AutoStartSolver;
            checkBox_AutoFinish.IsChecked = Options.AutoFinishSolver;
        }

        public void SolverHasStarted()
        {
            comboBox_Solver.IsEnabled = false;
            button_StartSolver.Visibility = Visibility.Collapsed;
        }

        public void ShowResultsButton()
        {
            button_Construction.Visibility = Visibility.Collapsed;
            button_Results.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Solver.Current.StartSolver();
        }

        private void comboBox_Solver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Options.CurrentSolver = comboBox_Solver.SelectedIndex;
        }

        private void checkBox_AutoStart_Checked(object sender, RoutedEventArgs e)
        {
            Options.AutoStartSolver = true;
        }

        private void checkBox_AutoStart_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.AutoStartSolver = false;
        }

        private void checkBox_AutoFinish_Checked(object sender, RoutedEventArgs e)
        {
            Options.AutoFinishSolver = true;
        }

        private void checkBox_AutoFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.AutoFinishSolver = false;
        }

        #region Common Menus

        #region Help Menu

        private async void button_Help_Click(object sender, RoutedEventArgs e)
        {
            var uriHelpGeneral = new Uri(@"http://www.bing.com");
            var success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = true });
        }

        #endregion

        #region Settings Menu

        private void menuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsGeneral();
        }

        private void menuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsSolver();
        }

        private void menuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsColors();
        }

        #endregion

        #region File Menu

        private void menuFlyout_New_Click(object sender, RoutedEventArgs e)
        {
            //New File.
            FileManager.NewFile();
        }

        private async void menuFlyout_Open_Click(object sender, RoutedEventArgs e)
        {
            //Open file.
            if (await FileManager.PickFileToLoad())
            {
                //Debug.WriteLine("File Picked, Now loading");
                await FileManager.LoadFile();
            }
        }

        private async void menuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            //Save File.
            await FileManager.SaveFile();
        }

        private async void menuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //Save file as.
            if (await FileManager.PickFileToSave())
            {
                await FileManager.SaveFile();
            }
        }

        private void menuFlyout_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }


        #endregion

        #region Changes per Page

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            //flyOut_NewSection.ShowAt(button_Save);
        }

        private void button_Solve_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSolver();
        }

        private void button_Construction_Click(object sender, RoutedEventArgs e)
        {
            FileManager.LoadLastFileAsync();
        }

        private void button_Results_Click(object sender, RoutedEventArgs e)
        {
            Solver.Current.ShowResults();
        }

        private void button_Sections_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSections();
        }

        private void button_Reports_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #endregion

    }
}
