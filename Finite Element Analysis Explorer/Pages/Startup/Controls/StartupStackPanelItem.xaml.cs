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
    public sealed partial class StartupStackPanelItem : UserControl
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; TextBlockDescription.Text = description; }
        }

        public StartupStackPanelItem(string _description)
        {
            this.InitializeComponent();
            description = _description;
            TextBlockDescription.Text = description;
        }
    }
}
