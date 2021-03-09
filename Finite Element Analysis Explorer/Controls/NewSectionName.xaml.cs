using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class NewSectionName : UserControl
    {
        public NewSectionName()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textBox_NewSectionName.Focus(FocusState.Keyboard);
        }

        private void textBox_NewSectionName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                bool FoundSection = false;
                foreach (var Item in Model.Sections)
                {
                    if (Item.Key == textBox_NewSectionName.Text)
                    {
                        Model.Sections.CurrentSection = Item.Value;
                        FoundSection = true;
                        break;
                    }
                }

                if (!FoundSection)
                {
                    //Debug.WriteLine("Creating new Section " + textBox_NewSectionName.Text);
                    Model.Sections.AddNewSection(textBox_NewSectionName.Text, 200000000000m, 0.000022m, 0.1m, 2450m, 100m, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Solid Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                    foreach (var Item in Model.Sections)
                    {
                        if (Item.Key == textBox_NewSectionName.Text)
                        {
                            Model.Sections.CurrentSection = Item.Value;
                            FoundSection = true;
                            break;
                        }
                    }
                }

                PanelSections.Current.HideNewSectionName();
            }
        }
    }
}
