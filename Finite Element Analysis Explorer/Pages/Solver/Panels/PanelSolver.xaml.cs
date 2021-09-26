namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelSolver page.
    /// </summary>
    public sealed partial class PanelSolver : Page
    {
        /// <summary>
        /// Gets or sets the current solver panel page.
        /// </summary>
        internal static PanelSolver Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSolver"/> class.
        /// </summary>
        public PanelSolver()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            ComboBox_Solver.SelectedIndex = Options.Solvers.CurrentSolver;
            CheckBox_AutoStart.IsChecked = Options.Solvers.AutoStartSolver;
            CheckBox_AutoFinish.IsChecked = Options.Solvers.AutoFinishSolver;
            CheckBox_GenerateReport.IsChecked = Options.Solvers.GenerateReport;
        }

        /// <summary>
        /// Processes the solver has started.
        /// </summary>
        public void SolverHasStarted()
        {
            ComboBox_Solver.IsEnabled = false;
            Button_StartSolver.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Shows the results button.
        /// </summary>
        public void ShowResultsButton()
        {
            Button_Construction.Visibility = Visibility.Collapsed;
            Button_Results.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Solver.Current.StartSolver();
        }

        private void ComboBox_Solver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Options.Solvers.CurrentSolver = ComboBox_Solver.SelectedIndex;
        }

        private void CheckBox_AutoStart_Checked(object sender, RoutedEventArgs e)
        {
            Options.Solvers.AutoStartSolver = true;
        }

        private void CheckBox_AutoStart_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.Solvers.AutoStartSolver = false;
        }

        private void CheckBox_AutoFinish_Checked(object sender, RoutedEventArgs e)
        {
            Options.Solvers.AutoFinishSolver = true;
        }

        private void CheckBox_AutoFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.Solvers.AutoFinishSolver = false;
        }

        private void CheckBox_GenerateReport_Checked(object sender, RoutedEventArgs e)
        {
            Options.Solvers.GenerateReport = true;
        }

        private void CheckBox_GenerateReport_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.Solvers.GenerateReport = false;
        }

        #region Common Menus

        #region Help Menu

        private async void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Uri uriHelpGeneral = new Uri(@"http://www.bing.com");
            bool success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = true });
        }

        #endregion

        #region Settings Menu

        private void MenuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsGeneral();
        }

        private void MenuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsSolver();
        }

        private void MenuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsColors();
        }

        #endregion

        #region File Menu

        private void MenuFlyout_New_Click(object sender, RoutedEventArgs e)
        {
            // New File.
            FileManager.NewFile();
        }

        private async void MenuFlyout_Open_Click(object sender, RoutedEventArgs e)
        {
            // file.
            if (await FileManager.PickFileToLoad())
            {
                _ = await FileManager.LoadFile();
            }
        }

        private async void MenuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            // Save File.
            _ = await FileManager.SaveFile();
        }

        private async void MenuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Save file as.
            if (await FileManager.PickFileToSave())
            {
                _ = await FileManager.SaveFile();
            }
        }

        private void MenuFlyout_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        #endregion

        #region Changes per Page

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Solve_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSolver();
        }

        private void Button_Construction_Click(object sender, RoutedEventArgs e)
        {
            FileManager.LoadLastFileAsync();
        }

        private void Button_Results_Click(object sender, RoutedEventArgs e)
        {
            Solver.Current.ShowResults();
        }

        private void Button_Sections_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSections();
        }

        private void Button_Reports_Click(object sender, RoutedEventArgs e)
        {
        }

        #endregion

        #endregion

    }
}
