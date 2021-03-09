using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class Help : Page
    {
        public static Help Current;


        public Help()
        {
            this.InitializeComponent();
        }

        public void ShowHelpPage(string PageURI)
        {
            webView_Help.Navigate(new Uri(PageURI));
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            webView_Help.Navigate(new Uri("ms-appx-web:///Assets/Help/General/General.html"));
        }

        private void webView_Help_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            // Debug.WriteLine("NavigationStarting " + args.Uri.ToString());
        }
    }
}
