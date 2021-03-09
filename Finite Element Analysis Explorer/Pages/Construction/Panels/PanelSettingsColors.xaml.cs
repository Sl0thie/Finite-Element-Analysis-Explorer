using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PanelSettingsColors : Page
    {
        public PanelSettingsColors()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Members.CurrentMember = null;
            Model.Sections.CurrentSection = null;
        }

        private void button_ColorBackground_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "ColorBackground";
            flyOut_SelectColor.ShowAt(button_Save);
        }

        private void button_ColorForce_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineForce";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_ColorReaction_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineReaction";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineGridNormal_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineGridNormal";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineGridMinor_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineGridMinor";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineGridMajor_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineGridMajor";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_ColorSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineSelectedElement";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineShearForceSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineShearForceSelected";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }


        private void button_LineShearForceFont_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineShearForceFont";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineMomentForceFont_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineMomentForceFont";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineMomentForceSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineMomentForceSelected";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineDistributedForceSelected_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineDistributedForceSelected";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineShearForce_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineShearForce";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineMomentForce_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineMomentForce";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineDistributedForce_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineDistributedForce";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineNodeFree_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineNodeFree";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineNodeFixed_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineNodeFixed";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineNodePin_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineNodePin";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineNodeRollerX_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineNodeRollerX";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineNodeRollerY_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineNodeRollerY";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }

        private void button_LineNodeOther_Click(object sender, RoutedEventArgs e)
        {
            Options.ColorToEdit = "LineNodeOther";
            flyOut_SelectColorAndLine.ShowAt(button_Save);
        }


        #region Common Menus

        #region Help Menu

        private void button_Help_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowHelpAsync();
        }

        #endregion

        #region Settings Menu

        private void menuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
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

        private void menuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
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

        private void menuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
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
