namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// ConstructionSlim page.
    /// </summary>
    public sealed partial class ConstructionSlim : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSlim"/> class.
        /// </summary>
        public ConstructionSlim()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        #region File Menu

        private void MenuFlyout_New_Click(object sender, RoutedEventArgs e)
        {
            // New File.
            FileManager.NewFile();
        }

        private async void MenuFlyout_Open_Click(object sender, RoutedEventArgs e)
        {
            // Open file.
            if (await FileManager.PickFileToLoad())
            {
                _ = await FileManager.LoadFile();
            }
        }

        private async void MenuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            // Save File.
            _ = await FileManager.SaveFile();
        }

        private async void MenuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Save file as.
            if (await FileManager.PickFileToSave())
            {
                _ = await FileManager.SaveFile();
            }
        }

        private void MenuFlyout_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        #endregion
    }
}