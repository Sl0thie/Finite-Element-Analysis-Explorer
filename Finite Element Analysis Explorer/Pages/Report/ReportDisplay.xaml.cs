// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReportDisplay : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDisplay"/> class.
        /// </summary>
        public ReportDisplay()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Web.Navigate(new Uri("ms-appdata:///local/Reports/ReportBasic.html"));
        }
    }
}
