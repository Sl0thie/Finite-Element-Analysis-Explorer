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
    public sealed partial class PanelHelp : Page
    {
        public PanelHelp()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Model.Members.CurrentMember = null;
            Model.Sections.CurrentSection = null;
        }

        #region Common Menus

        #region Help Menu

        private async void button_Help_Click(object sender, RoutedEventArgs e)
        {
            var uriHelpGeneral = new Uri(@"http://www.bing.com");
            var success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = true });
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

        private void button_Return_Click(object sender, RoutedEventArgs e)
        {
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    Construction.Current.ShowDrawing();
                    break;

                case PageState.Results:
                    Results.Current.ShowDrawing();
                    break;

            }
        }

        private void button_HelpGeneral_Click(object sender, RoutedEventArgs e)
        {
            Help.Current.ShowHelpPage("ms-appx-web:///Assets/Help/General/General.html");
        }

        private void button_HelpQuickstart_Click(object sender, RoutedEventArgs e)
        {
            Help.Current.ShowHelpPage("ms-appx-web:///Assets/Help/QuickStart/QuickStart.html");
        }

        private void button_HelpCredits_Click(object sender, RoutedEventArgs e)
        {
            Help.Current.ShowHelpPage("ms-appx-web:///Assets/Help/Credits/Credits.html");
        }

        private void button_HelpProperties_Click(object sender, RoutedEventArgs e)
        {
            Help.Current.ShowHelpPage("ms-appx-web:///Assets/Help/Properties/Properties.html");
        }
    }
}
