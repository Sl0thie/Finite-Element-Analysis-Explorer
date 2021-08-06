using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class PanelReport : Page
    {
        public PanelReport()
        {
            this.InitializeComponent();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowDrawing();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
