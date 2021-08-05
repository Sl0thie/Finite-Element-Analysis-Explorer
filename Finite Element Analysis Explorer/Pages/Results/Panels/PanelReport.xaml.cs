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
