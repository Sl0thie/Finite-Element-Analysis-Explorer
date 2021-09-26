// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

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
