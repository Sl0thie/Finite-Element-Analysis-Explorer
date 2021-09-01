namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelResultsModel Page.
    /// </summary>
    public sealed partial class PanelResultsModel : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelResultsModel"/> class.
        /// </summary>
        public PanelResultsModel()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SingleValue_XForce.SetTheValue(Model.ForceX);
            SingleValue_YForce.SetTheValue(Model.ForceY);
            SingleValue_MForce.SetTheValue(Model.ForceM);

            SingleValue_XReaction.SetTheValue(Model.ReactionX);
            SingleValue_YReaction.SetTheValue(Model.ReactionY);
            SingleValue_MReaction.SetTheValue(Model.ReactionM);

            SingleValue_XTotal.SetTheValue(Model.ForceX + Model.ReactionX);
            SingleValue_YTotal.SetTheValue(Model.ForceY + Model.ReactionY);
            SingleValue_MTotal.SetTheValue(Model.ForceM + Model.ReactionM);

            LogSlider_ForcesFactor.IsChecked = Options.ShowForce;
            LogSlider_LinearFactor.IsChecked = Options.ShowLinear;
            LogSlider_MomentFactor.IsChecked = Options.ShowMoment;
            LogSlider_ReactionsFactor.IsChecked = Options.ShowReactions;
            LogSlider_ShearFactor.IsChecked = Options.ShowShear;

            LogSlider_DisplacementFactor.Title = "Displacement Factor";
            LogSlider_ForcesFactor.Title = "Force Factor";
            LogSlider_LinearFactor.Title = "Linear Factor";
            LogSlider_MomentFactor.Title = "Moment Factor";
            LogSlider_ReactionsFactor.Title = "Reaction Factor";
            LogSlider_ShearFactor.Title = "Shear Factor";

            LogSlider_DisplacementFactor.SetNewValue(Options.DisplacementFactor);
            LogSlider_ForcesFactor.SetNewValue(Options.ForcesFactor);
            LogSlider_LinearFactor.SetNewValue(Options.LinearFactor);
            LogSlider_MomentFactor.SetNewValue(Options.MomentFactor);
            LogSlider_ReactionsFactor.SetNewValue(Options.ReactionsFactor);
            LogSlider_ShearFactor.SetNewValue(Options.ShearFactor);

            single_TotalMembers.Title = "Total Members";
            single_TotalMembers.DisplayOnly = true;
            single_TotalMembers.UnitType = UnitType.UnitlessInteger;
            single_TotalMembers.SetTheValue(Model.Members.Count);

            single_TotalNodes.Title = "Total Nodes";
            single_TotalNodes.DisplayOnly = true;
            single_TotalNodes.UnitType = UnitType.UnitlessInteger;
            single_TotalNodes.SetTheValue(Model.Nodes.NoOfPrimaryNodes);

            SingleValue_XForce.Title = "X axis Forces";
            SingleValue_XReaction.Title = "X axis Reactions";
            SingleValue_XTotal.Title = "X axis Total";

            SingleValue_YForce.Title = "Y axis Forces";
            SingleValue_YReaction.Title = "Y axis Reactions";
            SingleValue_YTotal.Title = "Y axis Total";

            SingleValue_MForce.Title = "M axis Forces";
            SingleValue_MReaction.Title = "M axis Reactions";
            SingleValue_MTotal.Title = "M axis Total";

            SingleValue_XForce.UnitType = UnitType.Force;
            SingleValue_XReaction.UnitType = UnitType.Force;
            SingleValue_XTotal.UnitType = UnitType.Force;

            SingleValue_YForce.UnitType = UnitType.Force;
            SingleValue_YReaction.UnitType = UnitType.Force;
            SingleValue_YTotal.UnitType = UnitType.Force;

            SingleValue_MForce.UnitType = UnitType.Moment;
            SingleValue_MReaction.UnitType = UnitType.Moment;
            SingleValue_MTotal.UnitType = UnitType.Moment;

            decimal sum = Model.ForceX + Model.ReactionX;
            if (sum < 0.000000001m)
            {
                sum = 0;
            }

            SingleValue_XForce.SetTheValue(Model.ForceX);
            SingleValue_XReaction.SetTheValue(Model.ReactionX);
            SingleValue_XTotal.SetTheValue(sum);

            sum = Model.ForceY + Model.ReactionY;
            if (sum < 0.000000001m)
            {
                sum = 0;
            }

            SingleValue_YForce.SetTheValue(Model.ForceY);
            SingleValue_YReaction.SetTheValue(Model.ReactionY);
            SingleValue_YTotal.SetTheValue(sum);

            sum = Model.ForceM + Model.ReactionM;
            if (sum < 0.000000001m)
            {
                sum = 0;
            }

            SingleValue_MForce.SetTheValue(Model.ForceM);
            SingleValue_MReaction.SetTheValue(Model.ReactionM);
            SingleValue_MTotal.SetTheValue(sum);

            SingleValue_MaterialCost.UnitType = UnitType.Money;
            SingleValue_MaterialCost.Title = "Material Cost";
            SingleValue_MaterialCost.DisplayOnly = true;
            SingleValue_MaterialCost.SetTheValue(Model.MaterialCost);

            SingleValue_NodeCost.UnitType = UnitType.Money;
            SingleValue_NodeCost.Title = "Node Cost";
            SingleValue_NodeCost.DisplayOnly = true;
            SingleValue_NodeCost.SetTheValue(Model.NodeCost);

            SingleValue_TransportCost.UnitType = UnitType.Money;
            SingleValue_TransportCost.Title = "Transport Cost";
            SingleValue_TransportCost.DisplayOnly = true;
            SingleValue_TransportCost.SetTheValue(Model.TransportCost);

            SingleValue_ElevationCost.UnitType = UnitType.Money;
            SingleValue_ElevationCost.Title = "Elevation Cost";
            SingleValue_ElevationCost.DisplayOnly = true;
            SingleValue_ElevationCost.SetTheValue(Model.ElevationCost);

            SingleValue_TotalCost.UnitType = UnitType.Money;
            SingleValue_TotalCost.Title = "Total Cost";
            SingleValue_TotalCost.DisplayOnly = true;
            SingleValue_TotalCost.SetTheValue(Model.TotalCost);

            comboBox_MemberDisplay.SelectedIndex = Options.MemberDisplay;
        }

        private void CheckBox_ShowMoment_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowMoment = true;
        }

        private void CheckBox_ShowMoment_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowMoment = false;
        }

        private void CheckBox_ShowShear_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowShear = true;
        }

        private void CheckBox_ShowShear_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowShear = false;
        }

        private void CheckBox_ShowLinear_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowLinear = true;
        }

        private void CheckBox_ShowLinear_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowLinear = false;
        }

        private void CheckBox_ShowForces_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowForce = true;
        }

        private void CheckBox_ShowForces_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowForce = false;
        }

        private void CheckBox_ShowReactions_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowReactions = true;
        }

        private void CheckBox_ShowReactions_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowReactions = false;
        }

        private void LogSlider_DisplacementFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.DisplacementFactor = LogSlider_DisplacementFactor.TheValue;
        }

        private void ComboBox_MemberDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Options.MemberDisplay = comboBox_MemberDisplay.SelectedIndex;
            foreach (var item in Model.Members)
            {
                foreach (var nextSegment in item.Value.Segments)
                {
                    nextSegment.Value.UpdateColor();
                }
            }
        }

        #region Common Menus

        #region Help Menu

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowHelpAsync();
        }

        #endregion

        #region Settings Menu

        private void MenuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowSettingsGeneral();
        }

        private void MenuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowSettingsSolver();
        }

        private void MenuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowSettingsColors();
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
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Report));
        }

        #endregion

        #endregion

        private void LogSlider_MomentFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowMoment = true;
        }

        private void LogSlider_MomentFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowMoment = false;
        }

        private void LogSlider_ShearFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowShear = true;
        }

        private void LogSlider_ShearFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowShear = false;
        }

        private void LogSlider_LinearFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowLinear = true;
        }

        private void LogSlider_LinearFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowLinear = false;
        }

        private void LogSlider_ForcesFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowForce = true;
        }

        private void LogSlider_ForcesFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowForce = false;
        }

        private void LogSlider_ReactionsFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowReactions = true;
        }

        private void LogSlider_ReactionsFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowReactions = false;
        }

        private void LogSlider_MomentFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.MomentFactor = LogSlider_MomentFactor.TheValue;
        }

        private void LogSlider_ShearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ShearFactor = LogSlider_ShearFactor.TheValue;
        }

        private void LogSlider_LinearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.LinearFactor = LogSlider_LinearFactor.TheValue;
        }

        private void LogSlider_ReactionsFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ReactionsFactor = LogSlider_ReactionsFactor.TheValue;
        }

        private void LogSlider_ForcesFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ForcesFactor = LogSlider_ForcesFactor.TheValue;
        }
    }
}
