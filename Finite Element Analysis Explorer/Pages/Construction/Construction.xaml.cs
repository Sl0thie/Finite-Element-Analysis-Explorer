namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.ApplicationModel.Core;
    using Windows.UI;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Construction page.
    /// </summary>
    public sealed partial class Construction : Page
    {
        /// <summary>
        /// Gets or sets the current construction page.
        /// </summary>
        internal static Construction Current { get; set; }

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
        /// Initializes a new instance of the <see cref="Construction"/> class.
        /// </summary>
        public Construction()
        {
            InitializeComponent();
            CustomizeTitleBar();
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

        #region Show

        /// <summary>
        /// Show the member page.
        /// </summary>
        public void ShowMember()
        {
            _ = frameDetails.Navigate(typeof(PanelMember));
        }

        /// <summary>
        /// Show the solver page.
        /// </summary>
        public void ShowSolver()
        {
            if (isPageLoaded)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                _ = rootFrame.Navigate(typeof(Solver));
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

        /// <summary>
        /// Shows the model page.
        /// </summary>
        public void ShowModel()
        {
            if (isPageLoaded)
            {
                App.CurrentPageState = PageState.Construction;
                frameDetails.Width = 300;
                _ = frameDetails.Navigate(typeof(PanelModel));
            }
        }

        /// <summary>
        /// Shows the sections page.
        /// </summary>
        public void ShowSections()
        {
            _ = FileManager.SaveFile();
            App.CurrentPageState = PageState.Sections;
            frameDetails.Width = 220;
            _ = frameDetails.Navigate(typeof(PanelSections));
            _ = frameDisplay.Navigate(typeof(DisplaySection));
        }

        /// <summary>
        /// Shows the section page.
        /// </summary>
        public void ShowSection()
        {
            _ = FileManager.SaveFile();
            App.CurrentPageState = PageState.Sections;
            frameDetails.Width = 220;
            _ = frameDetails.Navigate(typeof(PanelSections));
            _ = frameDisplay.Navigate(typeof(DisplaySection));
        }

        /// <summary>
        /// Shows the color settings page.
        /// </summary>
        public void ShowSettingsColors()
        {
            frameDetails.Width = 300;
            _ = frameDetails.Navigate(typeof(PanelSettingsColors));
        }

        /// <summary>
        /// Shows the solver settings page.
        /// </summary>
        public void ShowSettingsSolver()
        {
            frameDetails.Width = 300;
            _ = frameDetails.Navigate(typeof(PanelSettingsSolver));
        }

        /// <summary>
        /// Shows the general settings page.
        /// </summary>
        public void ShowSettingsGeneral()
        {
            frameDetails.Width = 300;
            _ = frameDetails.Navigate(typeof(PanelSettingsGeneral));
        }

        /// <summary>
        /// Shows the drawing page.
        /// </summary>
        public void ShowDrawing()
        {
            if (Model.Members.CurrentMember == null)
            {
                frameDetails.Width = 300;
                _ = frameDetails.Navigate(typeof(PanelModel));
            }
            else
            {
                frameDetails.Width = 300;
                _ = frameDetails.Navigate(typeof(PanelMember));
            }

            _ = frameDisplay.Navigate(typeof(ConstructionDisplay));
        }

        #endregion

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            isPageLoaded = true;
            if (Model.Members.CurrentMember == null)
            {
                Model.Sections.CurrentSection = Model.Sections["Default"];
                _ = frameDetails.Navigate(typeof(PanelModel));
            }
            else
            {
                _ = frameDetails.Navigate(typeof(PanelMember));
            }

            _ = frameDisplay.Navigate(typeof(ConstructionDisplay));
            App.CurrentPageState = PageState.Construction;
            SetTitle("Finite Element Analysis Explorer - Construction - " + FileManager.FileTitle);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            isPageLoaded = false;
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

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (detailsIsOpen)
            {
                detailsIsOpen = false;
                frameDetails.Width = Constants.WidthDetailsSlim;
                _ = frameDetails.Navigate(typeof(ConstructionSlim));
            }
            else
            {
                detailsIsOpen = true;
                frameDetails.Width = Constants.WidthDetailsNormal;
                _ = frameDetails.Navigate(typeof(PanelModel));
            }
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
    }
}