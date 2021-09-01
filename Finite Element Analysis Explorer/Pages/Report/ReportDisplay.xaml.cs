// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Finite_Element_Analysis_Explorer
{
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

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportDisplay : Page
    {
        public ReportDisplay()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("ReportDisplay.Page_Loaded");
            //Web.Navigate(new Uri("ReportBasic.html"));

            //Web.Navigate(new Uri("ms-appdata:///local/ReportBasic.html"));

            Web.Navigate(new Uri("ms-appdata:///local/Reports/ReportBasic.html"));
        }
    }
}
