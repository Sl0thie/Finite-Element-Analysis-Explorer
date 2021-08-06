using System;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class Results : Page
    {
        internal static Results Current;
        private bool IsPageLoaded = false;

        private bool detailsIsOpen = true;

        public bool DetailsIsOpen
        {
            get { return detailsIsOpen; }
            set { detailsIsOpen = value; }
        }

        public Results()
        {
            this.InitializeComponent();
            CustomizeTitleBar();
        }

        #region Show

        public void ShowMember()
        {
            if (IsPageLoaded)
            {
                frameDetails.Navigate(typeof(PanelResultsMember));
            }
        }

        public void ShowModel()
        {
            if (IsPageLoaded)
            {
                frameDetails.Navigate(typeof(PanelResultsModel));
            }
        }

        public void ShowReport()
        {
            frameDetails.Width = 220;
            frameDetails.Navigate(typeof(PanelReport));
            frameDisplay.Navigate(typeof(ResultsReport));
        }

        public void ShowSettingsColors()
        {
            frameDetails.Navigate(typeof(PanelSettingsColors));
        }

        public void ShowSettingsSolver()
        {
            frameDetails.Navigate(typeof(PanelSettingsSolver));
        }

        public void ShowSettingsGeneral()
        {
            frameDetails.Navigate(typeof(PanelSettingsGeneral));
        }

        public async void ShowHelpAsync()
        {
            // frameDetails.Width = 220;
            // frameDetails.Navigate(typeof(PanelHelp));
            // frameDisplay.Navigate(typeof(Help));
            var uriHelpGeneral = new Uri(@"http://dallasadams.net/Software/FEA/FiniteElementAnalysisExplorer/Help/Default.aspx");
            var success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = false });
        }

        public void ShowDrawing()
        {
            if (Model.Members.CurrentMember == null)
            {
                frameDetails.Width = 300;
                frameDetails.Navigate(typeof(PanelResultsModel));
            }
            else
            {
                frameDetails.Width = 300;
                frameDetails.Navigate(typeof(PanelResultsMember));
            }

            frameDisplay.Navigate(typeof(ResultsDisplay));
        }

        #endregion

        public void SetTitle(string newTitle)
        {
            TextBlock_Title.Text = newTitle;
        }

        private void CustomizeTitleBar()
        {

            // customize title area
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(trickyTitleBar);

            // customize buttons' colors
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;

            titleBar.BackgroundColor = Color.FromArgb(255, 64, 64, 64);
            titleBar.ButtonBackgroundColor = Color.FromArgb(255, 64, 64, 64);

            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonForegroundColor = Colors.White;

            // handle windows size changes to restore custom title bar
            Window.Current.SizeChanged += Current_SizeChanged_UpdateTitleBar;
        }

        private void Current_SizeChanged_UpdateTitleBar(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode == false)
            {
                customTitleBar.Visibility = Visibility.Visible;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.CurrentPageState = PageState.Results;
            Current = this;
            IsPageLoaded = true;
            frameDetails.Navigate(typeof(PanelResultsModel));
            frameDisplay.Navigate(typeof(ResultsDisplay));

            SetTitle("Finite Element Analysis Explorer - " + FileManager.FileTitle);

            IsPageLoaded = true;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            frameDisplay.Width = this.ActualWidth;
            frameDisplay.Height = this.ActualHeight - Constants.HeightTitleBar;

            if (detailsIsOpen)
            {
                frameDetails.Width = Constants.WidthDetailsNormal;
            }
            else
            {
                frameDetails.Width = Constants.WidthDetailsSlim;
            }

            frameDetails.Height = this.ActualHeight - Constants.HeightTitleBar;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            // App.CurrentPageState = PageState.Unknown;
            IsPageLoaded = false;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (detailsIsOpen)
            {
                detailsIsOpen = false;
                frameDetails.Width = Constants.WidthDetailsSlim;
                frameDetails.Navigate(typeof(ConstructionSlim));
            }
            else
            {
                detailsIsOpen = true;
                frameDetails.Width = Constants.WidthDetailsNormal;
                frameDetails.Navigate(typeof(PanelModel));
            }
        }

        private void MenuFlyoutNew(object sender, RoutedEventArgs e)
        {
        }

        private void MenuFlyoutOpen(object sender, RoutedEventArgs e)
        {
        }

        private void MenuFlyoutSave(object sender, RoutedEventArgs e)
        {
        }

        private void MenuFlyoutSaveAs(object sender, RoutedEventArgs e)
        {
        }
    }
}
