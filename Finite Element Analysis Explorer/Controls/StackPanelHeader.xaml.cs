namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    /// <summary>
    /// StackPanelHeader UserControl provides a header UI for the side panel that collapses the pair stack panel when clicked.
    /// </summary>
    public sealed partial class StackPanelHeader : UserControl
    {
        private StackPanel pairedStankPanel;

        /// <summary>
        /// Gets or sets the paired stack panel.
        /// </summary>
        internal StackPanel PairedStackPanel
        {
            get { return pairedStankPanel; }
            set { pairedStankPanel = value; }
        }

        private string titleIcon;

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public string TitleIcon
        {
            get
            {
                return titleIcon;
            }

            set
            {
                titleIcon = value;
                FontIcon_TitleIcon.Glyph = titleIcon;
            }
        }

        private string title;

        /// <summary>
        /// Gets or sets the title to display on the control.
        /// </summary>
        internal string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                TextBlock_Title.Text = title;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackPanelHeader"/> class.
        /// </summary>
        public StackPanelHeader()
        {
            InitializeComponent();
        }

        private void FontIcon_IconOpen_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FontIcon_IconOpen.Visibility = Visibility.Collapsed;
            FontIcon_IconClosed.Visibility = Visibility.Visible;
            pairedStankPanel.Visibility = Visibility.Visible;
        }

        private void FontIcon_IconClosed_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FontIcon_IconOpen.Visibility = Visibility.Visible;
            FontIcon_IconClosed.Visibility = Visibility.Collapsed;
            pairedStankPanel.Visibility = Visibility.Collapsed;
        }
    }
}
