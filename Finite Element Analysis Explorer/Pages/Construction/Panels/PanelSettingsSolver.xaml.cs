﻿namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelSettingsSolver Page.
    /// </summary>
    public sealed partial class PanelSettingsSolver : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSettingsSolver"/> class.
        /// </summary>
        public PanelSettingsSolver()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Members.CurrentMember = null;
            Model.Sections.CurrentSection = null;

            checkBox_AutoStart.IsChecked = Options.Solvers.AutoStartSolver;
            checkBox_AutoFinish.IsChecked = Options.Solvers.AutoFinishSolver;
            comboBox_Solver.SelectedIndex = Options.Solvers.CurrentSolver;
            checkBox_GenerateReport.IsChecked = Options.Solvers.GenerateReport;
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

        private void ComboBox_Solver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Options.Solvers.CurrentSolver = comboBox_Solver.SelectedIndex;
        }

        #region Common Menus

        #region Help Menu

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowHelpAsync();
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
            // Open file.
            if (await FileManager.PickFileToLoad())
            {
                // Debug.WriteLine("File Picked, Now loading");
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
            // flyOut_NewSection.ShowAt(Button_Save);
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