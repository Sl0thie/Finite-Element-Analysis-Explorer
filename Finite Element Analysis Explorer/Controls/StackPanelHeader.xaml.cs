using System;
using System.Collections.Generic;
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
            get { return titleIcon; }
            set
            {

                titleIcon = value;
                fontIcon_TitleIcon.Glyph = titleIcon;

            }
        }

        private string title;
        internal string Title
        {
            get { return title; }
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

        private void fontIcon_IconOpen_Tapped(object sender, TappedRoutedEventArgs e)
        {
            fontIcon_IconOpen.Visibility = Visibility.Collapsed;
            fontIcon_IconClosed.Visibility = Visibility.Visible;
            pairedStankPanel.Visibility = Visibility.Visible;
        }

        private void fontIcon_IconClosed_Tapped(object sender, TappedRoutedEventArgs e)
        {
            fontIcon_IconOpen.Visibility = Visibility.Visible;
            fontIcon_IconClosed.Visibility = Visibility.Collapsed;
            pairedStankPanel.Visibility = Visibility.Collapsed;
        }
    }
}
