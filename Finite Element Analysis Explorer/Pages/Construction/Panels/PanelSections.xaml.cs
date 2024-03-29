﻿namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelSections page.
    /// </summary>
    public sealed partial class PanelSections : Page
    {
        /// <summary>
        /// Gets or sets the current panel sections page.
        /// </summary>
        internal static PanelSections Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSections"/> class.
        /// </summary>
        public PanelSections()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hide new section name.
        /// </summary>
        public void HideNewSectionName()
        {
            Construction.Current.ShowSection();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            ListView_Sections.ItemsSource = Model.Sections.Values;
        }

        private void ListView_Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Section selectedSection = (Section)ListView_Sections.SelectedItem;
            if (selectedSection is object)
            {
                Model.Sections.CurrentSection = Model.Sections[selectedSection.Name];
                Construction.Current.ShowSection();
            }
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
            flyOut_NewSection.ShowAt(Button_Save);
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