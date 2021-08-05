using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class Solver : Page
    {
        internal static Solver Current;
        private bool IsPageLoaded = false;

        //private bool IsSolving = false;
        private ISolver CurrentSolver;

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
            if (IsPageLoaded)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Construction));
            }
        }

        public void StartSolver()
        {
            //CurrentSolver = new SolverBasic2(this, true);
            PanelSolver.Current.SolverHasStarted();

            switch (Options.CurrentSolver)
            {
                case 0:
                    CurrentSolver = new SolverDoubleLUP(this);
                    break;

                case 1:
                    //CurrentSolver = new SolverDoubleLUP2(this);
                    break;

                case 2:
                    //CurrentSolver = new SolverDoubleLUP3(this);
                    break;

                case 3:
                    //CurrentSolver = new SolverDoubleLUP4(this);
                    break;

                default:
                    CurrentSolver = new SolverDoubleLUP(this);
                    break;
            }

            //CurrentSolver = new SolverDoubleLUP(this, true);
        }

        public void ShowResults()
        {
            if (IsPageLoaded)
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Results));
            }
        }

        public void OpenSplit()
        {
            //SplitViewMain.IsPaneOpen = true;
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
            IsPageLoaded = true;
            frameDetails.Navigate(typeof(PanelSolver));
            frameDisplay.Navigate(typeof(SolverDisplay));

            try
            {
                if (Options.AutoStartSolver)
                {
                    //Debug.WriteLine("Autostarting..");
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                    Solver.Current.StartSolver();
                }
            }
            catch { }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //App.CurrentPageState = PageState.Unknown;
            IsPageLoaded = false;
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
            //if (detailsIsOpen)
            //{
            //    detailsIsOpen = false;
            //    frameDetails.Width = Constants.WidthDetailsSlim;
            //    frameDetails.Navigate(typeof(ConstructionSlim));
            //}
            //else
            //{
            //    detailsIsOpen = true;
            //    frameDetails.Width = Constants.WidthDetailsNormal;
            //    frameDetails.Navigate(typeof(PanelModel));
            //}

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //frameDisplay.Width = this.ActualWidth;
            //frameDisplay.Height = this.ActualHeight - Constants.HeightTitleBar;

            //if (detailsIsOpen)
            //{
            //    frameDetails.Width = Constants.WidthDetailsNormal;
            //}
            //else
            //{
            //    frameDetails.Width = Constants.WidthDetailsSlim;
            //}
            //frameDetails.Height = this.ActualHeight - Constants.HeightTitleBar;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
