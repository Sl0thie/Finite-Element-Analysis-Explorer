﻿namespace Finite_Element_Analysis_Explorer
{
    using Windows.ApplicationModel.Core;
    using Windows.UI;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// FileLoading page.
    /// </summary>
    public sealed partial class FileLoading : Page
    {
        /// <summary>
        /// Gets or sets the current file loading page.
        /// </summary>
        internal static FileLoading Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLoading"/> class.
        /// </summary>
        public FileLoading()
        {
            InitializeComponent();
            CustomizeTitleBar();
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
            App.CurrentPageState = PageState.FileLoading;
            Current = this;

            // IsLoaded = true;
            _ = frameFileLoadingDisplay.Navigate(typeof(FileLoadingDisplay));
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            // App.CurrentPageState = PageState.Unknown;
            Window.Current.SizeChanged -= Current_SizeChanged_UpdateTitleBar;

            // IsLoaded = false;
        }
    }
}
