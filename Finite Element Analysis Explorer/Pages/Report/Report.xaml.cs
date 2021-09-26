// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.ApplicationModel.Core;
    using Windows.UI;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Report : Page
    {
        /// <summary>
        /// Gets or sets the current construction page.
        /// </summary>
        internal static Report Current { get; set; }

        private bool isPageLoaded = false;

        private bool detailsIsOpen = true;

        /// <summary>
        /// Gets or sets a value indicating whether the details are open.
        /// </summary>
        public bool DetailsIsOpen
        {
            get { return detailsIsOpen; }
            set { detailsIsOpen = value; }
        }

        public Report()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            isPageLoaded = true;

            _ = frameDetails.Navigate(typeof(PanelReport));
            _ = frameDisplay.Navigate(typeof(ReportDisplay));
            App.CurrentPageState = PageState.Results;
            SetTitle("Finite Element Analysis Explorer - Report - " + FileManager.FileTitle);
        }

        /// <summary>
        /// Refreshes the page.
        /// </summary>
        public void Refresh()
        {
            if (isPageLoaded)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                _ = rootFrame.Navigate(typeof(Construction));
            }
        }

        /// <summary>
        /// Sets the page title.
        /// </summary>
        /// <param name="newTitle">The title to set.</param>
        public void SetTitle(string newTitle)
        {
            TextBlock_Title.Text = newTitle;
        }

        /// <summary>
        /// Customizes the title bar.
        /// </summary>
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

        /// <summary>
        /// Show the external help.
        /// </summary>
        public async void ShowHelpAsync()
        {
            Uri uriHelpGeneral = new Uri(@"http://www.intacomputers.com/Software/FEA/FiniteElementAnalysisExplorer/Help/Default.aspx");
            bool success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = false });
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            isPageLoaded = false;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            frameDisplay.Width = ActualWidth;
            frameDisplay.Height = ActualHeight - Constants.HeightTitleBar;

            if (detailsIsOpen)
            {
                frameDetails.Width = Constants.WidthDetailsNormal;
            }
            else
            {
                frameDetails.Width = Constants.WidthDetailsSlim;
            }

            frameDetails.Height = ActualHeight - Constants.HeightTitleBar;
        }

        public void ShowReport()
        {
            if (isPageLoaded)
            {
                App.CurrentPageState = PageState.Results;
                frameDetails.Width = 300;
                _ = frameDetails.Navigate(typeof(PanelReport));
                _ = frameDisplay.Navigate(typeof(ReportDisplay));
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
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
