using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{

    public sealed partial class PanelModel : Page
    {
        public PanelModel()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            single_TotalMembers.Title = "Members";
            single_TotalMembers.UnitType = UnitType.UnitlessInteger;
            single_TotalMembers.DisplayOnly = true;
            single_TotalMembers.SetTheValue(Model.Members.Count);

            single_TotalNodes.Title = "Nodes";
            single_TotalNodes.UnitType = UnitType.UnitlessInteger;
            single_TotalNodes.DisplayOnly = true;
            single_TotalNodes.SetTheValue(Model.Nodes.Count);

            single_TotalDOF.Title = "Degrees of Freedom";
            single_TotalDOF.UnitType = UnitType.UnitlessInteger;
            single_TotalDOF.DisplayOnly = true;
            single_TotalDOF.SetTheValue(Model.Nodes.Count * 3);

            single_NoOfSegments.Title = "Default Segments";
            single_NoOfSegments.UnitType = UnitType.UnitlessInteger;
            single_NoOfSegments.DisplayOnly = false;
            single_NoOfSegments.SetTheValue(Options.DefaultNumberOfSegments);

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

            checkBox_ResetExisting.IsChecked = Options.ResetExistingMembers;
        }

        private void Single_NoOfSegments_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("No of Segments ValueChanged");
            Options.DefaultNumberOfSegments = (int)single_NoOfSegments.NewValue;
            single_NoOfSegments.SetTheValue(Options.DefaultNumberOfSegments);
            if (checkBox_ResetExisting.IsChecked == true)
            {
                foreach (var Item in Model.Members)
                {
                    Item.Value.TotalSegments = Options.DefaultNumberOfSegments;
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

            //dummy comment.

          
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
            //New File.
            FileManager.NewFile();
        }

        private async void MenuFlyout_Open_Click(object sender, RoutedEventArgs e)
        {
            //Open file.
            if (await FileManager.PickFileToLoad())
            {
                //Debug.WriteLine("File Picked, Now loading");
                await FileManager.LoadFile();
            }
        }

        private async void MenuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            //Save File.
            await FileManager.SaveFile();
        }

        private async void MenuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            //Save file as.
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
            //flyOut_NewSection.ShowAt(button_Save);
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
            Options.MomentFactor = logSlider_MomentFactor.TheValue;
        }

        private void LogSlider_ShearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ShearFactor = logSlider_ShearFactor.TheValue;
        }

        private void LogSlider_LinearFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.LinearFactor = logSlider_LinearFactor.TheValue;
        }

        private void LogSlider_ReactionsFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ReactionsFactor = logSlider_ReactionsFactor.TheValue;
        }

        private void LogSlider_ForcesFactor_ValueChanged(object sender, EventArgs e)
        {
            Options.ForcesFactor = logSlider_ForcesFactor.TheValue;
        }

        private void LogSlider_DisplacementFactor_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("logSlider_DisplacementFactor_ValueChanged");
            Options.DisplacementFactor = logSlider_DisplacementFactor.TheValue;
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowHelpAsync();
        }
    }
}
