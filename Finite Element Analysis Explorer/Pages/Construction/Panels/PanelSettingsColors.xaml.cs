namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PanelSettingsColors : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSettingsColors"/> class.
        /// </summary>
        public PanelSettingsColors()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Members.CurrentMember = null;
            Model.Sections.CurrentSection = null;
        }

        private void Button_ColorBackground_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "ColorBackground";
            flyOut_SelectColor.ShowAt(Button_Save);
        }

        private void Button_ColorForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineForce";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_ColorReaction_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineReaction";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineGridNormal_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineGridNormal";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineGridMinor_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineGridMinor";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineGridMajor_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineGridMajor";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_ColorSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineSelectedElement";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineShearForceSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineShearForceSelected";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineShearForceFont_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineShearForceFont";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineMomentForceFont_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineMomentForceFont";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineMomentForceSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineMomentForceSelected";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineDistributedForceSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineDistributedForceSelected";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineShearForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineShearForce";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineMomentForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineMomentForce";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineDistributedForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineDistributedForce";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineNodeFree_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineNodeFree";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineNodeFixed_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineNodeFixed";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineNodePin_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineNodePin";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineNodeRollerX_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineNodeRollerX";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineNodeRollerY_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineNodeRollerY";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
        }

        private void Button_LineNodeOther_Click(object sender, RoutedEventArgs e)
        {
            Options.Colors.ColorToEdit = "LineNodeOther";
            flyOut_SelectColorAndLine.ShowAt(Button_Save);
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
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    Construction.Current.ShowSettingsGeneral();
                    break;
                case PageState.FileLoading:
                    break;
                case PageState.Results:
                    Results.Current.ShowSettingsGeneral();
                    break;
                case PageState.Sections:
                    Construction.Current.ShowSettingsGeneral();
                    break;
                case PageState.Solver:
                    break;
                case PageState.Unknown:
                    break;
            }
        }

        private void MenuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    Construction.Current.ShowSettingsSolver();
                    break;
                case PageState.FileLoading:
                    break;
                case PageState.Results:
                    Results.Current.ShowSettingsSolver();
                    break;
                case PageState.Sections:
                    Construction.Current.ShowSettingsSolver();
                    break;
                case PageState.Solver:
                    break;
                case PageState.Unknown:
                    break;
            }
        }

        private void MenuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    Construction.Current.ShowSettingsColors();
                    break;
                case PageState.FileLoading:
                    break;
                case PageState.Results:
                    Results.Current.ShowSettingsColors();
                    break;
                case PageState.Sections:
                    Construction.Current.ShowSettingsColors();
                    break;
                case PageState.Solver:
                    break;
                case PageState.Unknown:
                    break;
            }
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

    }
}
