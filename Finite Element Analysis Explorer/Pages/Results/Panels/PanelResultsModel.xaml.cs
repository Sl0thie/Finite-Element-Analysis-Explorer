using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Finite_Element_Analysis_Explorer
{

    public sealed partial class PanelResultsModel : Page
    {
        public PanelResultsModel()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            singleValue_XForce.SetTheValue(Model.ForceX);
            singleValue_YForce.SetTheValue(Model.ForceY);
            singleValue_MForce.SetTheValue(Model.ForceM);

            singleValue_XReaction.SetTheValue(Model.ReactionX);
            singleValue_YReaction.SetTheValue(Model.ReactionY);
            singleValue_MReaction.SetTheValue(Model.ReactionM);

            singleValue_XTotal.SetTheValue(Model.ForceX + Model.ReactionX);
            singleValue_YTotal.SetTheValue(Model.ForceY + Model.ReactionY);
            singleValue_MTotal.SetTheValue(Model.ForceM + Model.ReactionM);

            logSlider_ForcesFactor.IsChecked = Options.ShowForce;
            logSlider_LinearFactor.IsChecked = Options.ShowLinear;
            logSlider_MomentFactor.IsChecked = Options.ShowMoment;
            logSlider_ReactionsFactor.IsChecked = Options.ShowReactions;
            logSlider_ShearFactor.IsChecked = Options.ShowShear;

            logSlider_DisplacementFactor.Title = "Displacement Factor";
            logSlider_ForcesFactor.Title = "Force Factor";
            logSlider_LinearFactor.Title = "Linear Factor";
            logSlider_MomentFactor.Title = "Moment Factor";
            logSlider_ReactionsFactor.Title = "Reaction Factor";
            logSlider_ShearFactor.Title = "Shear Factor";

            logSlider_DisplacementFactor.SetNewValue(Options.DisplacementFactor);
            logSlider_ForcesFactor.SetNewValue(Options.ForcesFactor);
            logSlider_LinearFactor.SetNewValue(Options.LinearFactor);
            logSlider_MomentFactor.SetNewValue(Options.MomentFactor);
            logSlider_ReactionsFactor.SetNewValue(Options.ReactionsFactor);
            logSlider_ShearFactor.SetNewValue(Options.ShearFactor);

            single_TotalMembers.Title = "Total Members";
            single_TotalMembers.DisplayOnly = true;
            single_TotalMembers.UnitType = UnitType.UnitlessInteger;
            single_TotalMembers.SetTheValue(Model.Members.Count);

            single_TotalNodes.Title = "Total Nodes";
            single_TotalNodes.DisplayOnly = true;
            single_TotalNodes.UnitType = UnitType.UnitlessInteger;
            single_TotalNodes.SetTheValue(Model.Nodes.Count);

            single_TotalSegments.Title = "Total Segments";
            single_TotalSegments.DisplayOnly = true;
            single_TotalSegments.UnitType = UnitType.UnitlessInteger;
            single_TotalSegments.SetTheValue(0);

            singleValue_XForce.Title = "X axis Forces";
            singleValue_XReaction.Title = "X axis Reactions";
            singleValue_XTotal.Title = "X axis Total";

            singleValue_YForce.Title = "Y axis Forces";
            singleValue_YReaction.Title = "Y axis Reactions";
            singleValue_YTotal.Title = "Y axis Total";

            singleValue_MForce.Title = "M axis Forces";
            singleValue_MReaction.Title = "M axis Reactions";
            singleValue_MTotal.Title = "M axis Total";

            singleValue_XForce.UnitType = UnitType.Force;
            singleValue_XReaction.UnitType = UnitType.Force;
            singleValue_XTotal.UnitType = UnitType.Force;

            singleValue_YForce.UnitType = UnitType.Force;
            singleValue_YReaction.UnitType = UnitType.Force;
            singleValue_YTotal.UnitType = UnitType.Force;

            singleValue_MForce.UnitType = UnitType.Moment;
            singleValue_MReaction.UnitType = UnitType.Moment;
            singleValue_MTotal.UnitType = UnitType.Moment;

            singleValue_XForce.SetTheValue(Model.ForceX);
            singleValue_XReaction.SetTheValue(Model.ReactionX);
            singleValue_XTotal.SetTheValue(Model.ForceX + Model.ReactionX);

            singleValue_YForce.SetTheValue(Model.ForceY);
            singleValue_YReaction.SetTheValue(Model.ReactionY);
            singleValue_YTotal.SetTheValue(Model.ForceY + Model.ReactionY);

            singleValue_MForce.SetTheValue(Model.ForceM);
            singleValue_MReaction.SetTheValue(Model.ReactionM);
            singleValue_MTotal.SetTheValue(Model.ForceM + Model.ReactionM);

            singleValue_MaterialCost.UnitType = UnitType.Money;
            singleValue_MaterialCost.Title = "Material Cost";
            singleValue_MaterialCost.DisplayOnly = true;
            singleValue_MaterialCost.SetTheValue(Model.MaterialCost);

            singleValue_NodeCost.UnitType = UnitType.Money;
            singleValue_NodeCost.Title = "Node Cost";
            singleValue_NodeCost.DisplayOnly = true;
            singleValue_NodeCost.SetTheValue(Model.NodeCost);

            singleValue_TransportCost.UnitType = UnitType.Money;
            singleValue_TransportCost.Title = "Transport Cost";
            singleValue_TransportCost.DisplayOnly = true;
            singleValue_TransportCost.SetTheValue(Model.TransportCost);

            singleValue_ElevationCost.UnitType = UnitType.Money;
            singleValue_ElevationCost.Title = "Elevation Cost";
            singleValue_ElevationCost.DisplayOnly = true;
            singleValue_ElevationCost.SetTheValue(Model.ElevationCost);

            singleValue_TotalCost.UnitType = UnitType.Money;
            singleValue_TotalCost.Title = "Total Cost";
            singleValue_TotalCost.DisplayOnly = true;
            singleValue_TotalCost.SetTheValue(Model.TotalCost);

            comboBox_MemberDisplay.SelectedIndex = Options.MemberDisplay;
        }

        private void checkBox_ShowMoment_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowMoment = true;
        }

        private void checkBox_ShowMoment_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowMoment = false;
        }

        private void checkBox_ShowShear_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowShear = true;
        }

        private void checkBox_ShowShear_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowShear = false;
        }

        private void checkBox_ShowLinear_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowLinear = true;
        }

        private void checkBox_ShowLinear_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowLinear = false;
        }

        private void checkBox_ShowForces_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowForce = true;
        }

        private void checkBox_ShowForces_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowForce = false;
        }

        private void checkBox_ShowReactions_Checked(object sender, RoutedEventArgs e)
        {
            Options.ShowReactions = true;
        }

        private void checkBox_ShowReactions_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.ShowReactions = false;
        }

        private void logSlider_DisplacementFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.DisplacementFactor = logSlider_DisplacementFactor.TheValue;
        }

        private void comboBox_MemberDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Options.MemberDisplay = comboBox_MemberDisplay.SelectedIndex;
            foreach (var Item in Model.Members)
            {
                foreach (var nextSegment in Item.Value.Segments)
                {
                    nextSegment.Value.UpdateColor();
                }
            }
        }

        #region Common Menus

        #region Help Menu

        private void button_Help_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowHelpAsync();
        }

        #endregion

        #region Settings Menu

        private void menuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowSettingsGeneral();
        }

        private void menuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowSettingsSolver();
        }

        private void menuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowSettingsColors();
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
            Results.Current.ShowReport();
        }

        #endregion

        #endregion

        private void logSlider_MomentFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowMoment = true;
        }

        private void logSlider_MomentFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowMoment = false;
        }

        private void logSlider_ShearFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowShear = true;
        }

        private void logSlider_ShearFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowShear = false;
        }

        private void logSlider_LinearFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowLinear = true;
        }

        private void logSlider_LinearFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowLinear = false;
        }

        private void logSlider_ForcesFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowForce = true;
        }

        private void logSlider_ForcesFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowForce = false;
        }

        private void logSlider_ReactionsFactor_Checked(object sender, EventArgs e)
        {
            Options.ShowReactions = true;
        }

        private void logSlider_ReactionsFactor_Unchecked(object sender, EventArgs e)
        {
            Options.ShowReactions = false;
        }

        private void logSlider_MomentFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.MomentFactor = logSlider_MomentFactor.TheValue;
        }

        private void logSlider_ShearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ShearFactor = logSlider_ShearFactor.TheValue;
        }

        private void logSlider_LinearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.LinearFactor = logSlider_LinearFactor.TheValue;
        }

        private void logSlider_ReactionsFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ReactionsFactor = logSlider_ReactionsFactor.TheValue;
        }

        private void logSlider_ForcesFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ForcesFactor = logSlider_ForcesFactor.TheValue;
        }
    }
}
