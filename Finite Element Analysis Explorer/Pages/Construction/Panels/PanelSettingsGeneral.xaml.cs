namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PanelSettingsGeneral : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSettingsGeneral"/> class.
        /// </summary>
        public PanelSettingsGeneral()
        {
            InitializeComponent();
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
                await FileManager.LoadFile();
            }
        }

        private async void MenuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            // Save File.
            await FileManager.SaveFile();
        }

        private async void MenuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Save file as.
            if (await FileManager.PickFileToSave())
            {
                await FileManager.SaveFile();
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Members.CurrentMember = null;
            Model.Sections.CurrentSection = null;

            SingleValue_ZoomTrim.Title = "Scale Trim";
            SingleValue_ZoomTrim.UnitType = UnitType.Unitless;
            //SingleValue_ZoomTrim.SetTheValue((decimal)Camera.ZoomTrim);
            SingleValue_ZoomTrim.SetTheValue((decimal)Options.Display.CameraZoomTrim);

            SingleValue_SelectGridSize.Title = "Touch Grid Size";
            SingleValue_SelectGridSize.UnitType = UnitType.Unitless;
            SingleValue_SelectGridSize.SetTheValue((decimal)Options.SelectGridSize);
        }

        private void SingleValue_ZoomTrim_ValueChanged(object sender, EventArgs e)
        {
            //Camera.ZoomTrim = (float)SingleValue_ZoomTrim.NewValue;
            //SingleValue_ZoomTrim.SetTheValue((decimal)Camera.ZoomTrim);

            Options.Display.CameraZoomTrim = (float)SingleValue_ZoomTrim.NewValue;
            SingleValue_ZoomTrim.SetTheValue((decimal)Options.Display.CameraZoomTrim);
        }

        private void SingleValue_SelectGridSize_ValueChanged(object sender, EventArgs e)
        {
            Options.SelectGridSize = (float)SingleValue_SelectGridSize.NewValue;
            SingleValue_SelectGridSize.SetTheValue((decimal)Options.SelectGridSize);
        }
    }
}