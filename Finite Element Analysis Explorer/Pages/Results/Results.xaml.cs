namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Windows.ApplicationModel.Core;
    using Windows.UI;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Results page.
    /// </summary>
    public sealed partial class Results : Page
    {
        /// <summary>
        /// Gets or sets the current results page.
        /// </summary>
        internal static Results Current { get; set; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Results"/> class.
        /// </summary>
        public Results()
        {
            InitializeComponent();
            CustomizeTitleBar();
        }

        #region Show

        /// <summary>
        /// Shows the member.
        /// </summary>
        public void ShowMember()
        {
            if (isPageLoaded)
            {
                frameDetails.Navigate(typeof(PanelResultsMember));
            }
        }

        /// <summary>
        /// Shows the model.
        /// </summary>
        public void ShowModel()
        {
            if (isPageLoaded)
            {
                frameDetails.Navigate(typeof(PanelResultsModel));
            }
        }

        /// <summary>
        /// Shows the report.
        /// </summary>
        public void ShowReport()
        {
            frameDetails.Width = 220;
            frameDetails.Navigate(typeof(PanelReport));
            frameDisplay.Navigate(typeof(ResultsReport));
        }

        /// <summary>
        /// Shows the color settings.
        /// </summary>
        public void ShowSettingsColors()
        {
            frameDetails.Navigate(typeof(PanelSettingsColors));
        }

        /// <summary>
        /// Shows the solver settings.
        /// </summary>
        public void ShowSettingsSolver()
        {
            frameDetails.Navigate(typeof(PanelSettingsSolver));
        }

        /// <summary>
        /// Shows the general settings.
        /// </summary>
        public void ShowSettingsGeneral()
        {
            frameDetails.Navigate(typeof(PanelSettingsGeneral));
        }

        /// <summary>
        /// Shows the external help.
        /// </summary>
        public async void ShowHelpAsync()
        {
            var uriHelpGeneral = new Uri(@"http://www.intacomputers.com/Software/FEA/FiniteElementAnalysisExplorer/Help/Default.aspx");
            var success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = false });
        }

        /// <summary>
        /// Shows the drawing.
        /// </summary>
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

        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <param name="newTitle">The title to display.</param>
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
            isPageLoaded = true;
            frameDetails.Navigate(typeof(PanelResultsModel));
            frameDisplay.Navigate(typeof(ResultsDisplay));

            SetTitle("Finite Element Analysis Explorer - Results - " + FileManager.FileTitle);

            isPageLoaded = true;
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

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            isPageLoaded = false;
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