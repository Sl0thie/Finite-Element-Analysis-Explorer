using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class StackPanelHeader : UserControl
    {
        private StackPanel pairedStankPanel;

        internal StackPanel PairedStackPanel
        {
            get { return pairedStankPanel; }
            set { pairedStankPanel = value; }
        }

        private string titleIcon;

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

        public StackPanelHeader()
        {
            this.InitializeComponent();
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
