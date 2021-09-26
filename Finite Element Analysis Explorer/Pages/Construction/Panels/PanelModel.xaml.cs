namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelModel Page.
    /// </summary>
    public sealed partial class PanelModel : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelModel"/> class.
        /// </summary>
        public PanelModel()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Single_TotalMembers.Title = "Members";
            Single_TotalMembers.UnitType = UnitType.UnitlessInteger;
            Single_TotalMembers.DisplayOnly = true;
            Single_TotalMembers.SetTheValue(Model.Members.Count);

            Single_TotalNodes.Title = "Nodes";
            Single_TotalNodes.UnitType = UnitType.UnitlessInteger;
            Single_TotalNodes.DisplayOnly = true;
            Single_TotalNodes.SetTheValue(Model.Nodes.NoOfPrimaryNodes);

            Single_TotalDOF.Title = "Degrees of Freedom";
            Single_TotalDOF.UnitType = UnitType.UnitlessInteger;
            Single_TotalDOF.DisplayOnly = true;
            Single_TotalDOF.SetTheValue(Model.Nodes.Count * 3);

            Single_NoOfSegments.Title = "Default Segments";
            Single_NoOfSegments.UnitType = UnitType.UnitlessInteger;
            Single_NoOfSegments.DisplayOnly = false;
            Single_NoOfSegments.SetTheValue(Options.DefaultNumberOfSegments);

            LogSlider_ForcesFactor.IsChecked = Options.Display.ShowForce;
            LogSlider_LinearFactor.IsChecked = Options.Display.ShowLinear;
            LogSlider_MomentFactor.IsChecked = Options.Display.ShowMoment;
            LogSlider_ReactionsFactor.IsChecked = Options.Display.ShowReactions;
            LogSlider_ShearFactor.IsChecked = Options.Display.ShowShear;

            LogSlider_DisplacementFactor.Title = "Displacement Factor";
            LogSlider_ForcesFactor.Title = "Force Factor";
            LogSlider_LinearFactor.Title = "Linear Factor";
            LogSlider_MomentFactor.Title = "Moment Factor";
            LogSlider_ReactionsFactor.Title = "Reaction Factor";
            LogSlider_ShearFactor.Title = "Shear Factor";

            LogSlider_DisplacementFactor.SetNewValue(Options.Display.DisplacementFactor);
            LogSlider_ForcesFactor.SetNewValue(Options.Display.ForcesFactor);
            LogSlider_LinearFactor.SetNewValue(Options.Display.LinearFactor);
            LogSlider_MomentFactor.SetNewValue(Options.Display.MomentFactor);
            LogSlider_ReactionsFactor.SetNewValue(Options.Display.ReactionsFactor);
            LogSlider_ShearFactor.SetNewValue(Options.Display.ShearFactor);

            CheckBox_ResetExisting.IsChecked = Options.ResetExistingMembers;
        }

        private void Single_NoOfSegments_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("No of Segments ValueChanged");
            Options.DefaultNumberOfSegments = (int)Single_NoOfSegments.NewValue;
            Single_NoOfSegments.SetTheValue(Options.DefaultNumberOfSegments);
            if (CheckBox_ResetExisting.IsChecked == true)
            {
                foreach (System.Collections.Generic.KeyValuePair<int, Member> item in Model.Members)
                {
                    item.Value.TotalSegments = Options.DefaultNumberOfSegments;
                }
            }
        }

        private void CheckBox_ResetExisting_Checked(object sender, RoutedEventArgs e)
        {
            Options.ResetExistingMembers = true;
        }

        private void CheckBox_ResetExisting_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ResetExistingMembers = false;
        }

        #region Common Menus

        #region Help Menu

        private void Button_Help_ClickAsync(object sender, RoutedEventArgs e)
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

        private void LogSlider_MomentFactor_Checked(object sender, EventArgs e)
        {
            Options.Display.ShowMoment = true;
        }

        private void LogSlider_MomentFactor_Unchecked(object sender, EventArgs e)
        {
            Options.Display.ShowMoment = false;
        }

        private void LogSlider_ShearFactor_Checked(object sender, EventArgs e)
        {
            Options.Display.ShowShear = true;
        }

        private void LogSlider_ShearFactor_Unchecked(object sender, EventArgs e)
        {
            Options.Display.ShowShear = false;
        }

        private void LogSlider_LinearFactor_Checked(object sender, EventArgs e)
        {
            Options.Display.ShowLinear = true;
        }

        private void LogSlider_LinearFactor_Unchecked(object sender, EventArgs e)
        {
            Options.Display.ShowLinear = false;
        }

        private void LogSlider_ForcesFactor_Checked(object sender, EventArgs e)
        {
            Options.Display.ShowForce = true;
        }

        private void LogSlider_ForcesFactor_Unchecked(object sender, EventArgs e)
        {
            Options.Display.ShowForce = false;
        }

        private void LogSlider_ReactionsFactor_Checked(object sender, EventArgs e)
        {
            Options.Display.ShowReactions = true;
        }

        private void LogSlider_ReactionsFactor_Unchecked(object sender, EventArgs e)
        {
            Options.Display.ShowReactions = false;
        }

        private void LogSlider_MomentFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.Display.MomentFactor = LogSlider_MomentFactor.TheValue;
        }

        private void LogSlider_ShearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.Display.ShearFactor = LogSlider_ShearFactor.TheValue;
        }

        private void LogSlider_LinearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.Display.LinearFactor = LogSlider_LinearFactor.TheValue;
        }

        private void LogSlider_ReactionsFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.Display.ReactionsFactor = LogSlider_ReactionsFactor.TheValue;
        }

        private void LogSlider_ForcesFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.Display.ForcesFactor = LogSlider_ForcesFactor.TheValue;
        }

        private void LogSlider_DisplacementFactor_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("LogSlider_DisplacementFactor_ValueChanged");
            Options.Display.DisplacementFactor = LogSlider_DisplacementFactor.TheValue;
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowHelpAsync();
        }
    }
}
