namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelReport Page.
    /// </summary>
    public sealed partial class PanelReport : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelReport"/> class.
        /// </summary>
        public PanelReport()
        {
            InitializeComponent();
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
