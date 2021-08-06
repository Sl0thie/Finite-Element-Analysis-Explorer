using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Help Page provides a means to display help.
    /// </summary>
    public sealed partial class Help : Page
    {
        private static Help current;

        /// <summary>
        /// Initializes a new instance of the <see cref="Help"/> class.
        /// </summary>
        public Help()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets current. The Clayton's singleton.
        /// </summary>
        public static Help Current { get => current; set => current = value; }

        /// <summary>
        /// Show the help page.
        /// </summary>
        /// <param name="pageURI">The URL of the help page.</param>
        public void ShowHelpPage(string pageURI)
        {
            WebView_Help.Navigate(new Uri(pageURI));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            WebView_Help.Navigate(new Uri("ms-appx-web:///Assets/Help/General/General.html"));
        }

        private void WebView_Help_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
        }
    }
}
