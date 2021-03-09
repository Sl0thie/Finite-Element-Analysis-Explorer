using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

    public sealed partial class PanelSections : Page
    {
        internal static PanelSections Current;

        public PanelSections()
        {
            this.InitializeComponent();
        }

        public void HideNewSectionName()
        {
            Construction.Current.ShowSection();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            listView_Sections.ItemsSource = Model.Sections.Values;

        }

        private void ListView_Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Section selectedSection = (Section)listView_Sections.SelectedItem;
            if (!object.ReferenceEquals(null, selectedSection))
            {
                Model.Sections.CurrentSection = Model.Sections[selectedSection.Name];
                Construction.Current.ShowSection();
            }
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
            flyOut_NewSection.ShowAt(button_Save);
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
