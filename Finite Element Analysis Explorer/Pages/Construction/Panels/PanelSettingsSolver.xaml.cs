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
    public sealed partial class PanelSettingsSolver : Page
    {
        public PanelSettingsSolver()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Members.CurrentMember = null;
            Model.Sections.CurrentSection = null;

            checkBox_AutoStart.IsChecked = Options.AutoStartSolver;
            checkBox_AutoFinish.IsChecked = Options.AutoFinishSolver;
            comboBox_Solver.SelectedIndex = Options.CurrentSolver;
        }

        private void checkBox_AutoStart_Checked(object sender, RoutedEventArgs e)
        {
            Options.AutoStartSolver = true;
        }

        private void checkBox_AutoStart_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.AutoStartSolver = false;
        }

        private void checkBox_AutoFinish_Checked(object sender, RoutedEventArgs e)
        {
            Options.AutoFinishSolver = true;
        }

        private void checkBox_AutoFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            Options.AutoFinishSolver = false;
        }

        private void comboBox_Solver_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Options.CurrentSolver = comboBox_Solver.SelectedIndex;
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
            Construction.Current.ShowSettingsGeneral();
        }

        private void menuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsSolver();
        }

        private void menuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsColors();
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
