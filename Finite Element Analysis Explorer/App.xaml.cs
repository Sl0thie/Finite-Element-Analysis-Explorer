namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// App Application manages the application creation and suspension.
    /// </summary>
    public sealed partial class App : Application
    {
        /// <summary>
        /// Gets or sets the current construction mode.
        /// </summary>
        internal static ConstructionMode CurrentConstructionMode { get => currentConstructionMode; set => currentConstructionMode = value; }

        /// <summary>
        /// Gets or sets the current solver state.
        /// </summary>
        internal static SolveState CurrentSolverState { get => currentSolverState; set => currentSolverState = value; }

        /// <summary>
        /// Gets or sets the current page state.
        /// </summary>
        internal static PageState CurrentPageState { get => currentPageState; set => currentPageState = value; }

        private static ConstructionMode currentConstructionMode = ConstructionMode.Add;
        private static SolveState currentSolverState = SolveState.Unknown;
        private static PageState currentPageState = PageState.Unknown;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;

            // Load the options from the data store.
            Options.LoadOptions();
        }

        /// <summary>
        /// Starts up the application.
        /// </summary>
        /// <param name="e">Unused.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                // this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(Startup), e.Arguments);
                }

                // Ensure the current window is active
                Window.Current.Activate();
            }

            WService.ReportSessionStart();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails.
        /// </summary>
        /// <param name="sender">The Frame which failed navigation.</param>
        /// <param name="e">Details about the navigation failure.</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            // throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();

            try
            {
                Options.SaveOptions();
                FileManager.SaveSectionsAsync();
                FileManager.SaveLastFile();
                WService.ReportSession();
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            deferral.Complete();
        }
    }
}