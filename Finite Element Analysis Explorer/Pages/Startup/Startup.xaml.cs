using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class Startup : Page
    {
        internal static Startup Current;

        public Startup()
        {
            this.InitializeComponent();
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

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftFrameColumn.Width == new GridLength(32))
            {
                LeftFrameColumn.Width = new GridLength(320);
                frameContentDetails.Navigate(typeof(Details));
            }
            else
            {
                LeftFrameColumn.Width = new GridLength(32);
                frameContentDetails.Navigate(typeof(Slim));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            frameContentDetails.Navigate(typeof(Slim));
            frameContentDisplay.Navigate(typeof(StartupDisplay));
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Current_SizeChanged_UpdateTitleBar;
        }
    }
}
