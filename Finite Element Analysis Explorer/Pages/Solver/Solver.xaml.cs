using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class Solver : Page
    {
        internal static Solver Current;
        private bool isPageLoaded = false;
        private ISolver currentSolver;
        private bool detailsIsOpen = true;

        public bool DetailsIsOpen
        {
            get { return detailsIsOpen; }
            set { detailsIsOpen = value; }
        }

        public Solver()
        {
            this.InitializeComponent();
            CustomizeTitleBar();
        }

        public void ShowConstruction()
        {
            if (isPageLoaded)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Construction));
            }
        }

        public void StartSolver()
        {
            PanelSolver.Current.SolverHasStarted();

            switch (Options.CurrentSolver)
            {
                case 0:
                    currentSolver = new SolverDoubleLUP(this);
                    break;

                case 1:
                    // CurrentSolver = new SolverDoubleLUP2(this);
                    break;

                case 2:
                    // CurrentSolver = new SolverDoubleLUP3(this);
                    break;

                case 3:
                    // CurrentSolver = new SolverDoubleLUP4(this);
                    break;

                default:
                    currentSolver = new SolverDoubleLUP(this);
                    break;
            }
        }

        public void ShowResults()
        {
            if (isPageLoaded)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Results));
            }
        }

        public void OpenSplit()
        {
            // SplitViewMain.IsPaneOpen = true;
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

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.CurrentPageState = PageState.Solver;
            Current = this;
            isPageLoaded = true;
            frameDetails.Navigate(typeof(PanelSolver));
            frameDisplay.Navigate(typeof(SolverDisplay));

            try
            {
                if (Options.AutoStartSolver)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                    Solver.Current.StartSolver();
                }
            }
            catch(Exception ex)
            {
                WService.ReportException(ex);
            }
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
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }
    }
}
