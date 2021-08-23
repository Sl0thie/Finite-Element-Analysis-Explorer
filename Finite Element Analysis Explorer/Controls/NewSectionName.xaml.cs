﻿using Microsoft.Graphics.Canvas.Geometry;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// NewSectionName UserControl.
    /// </summary>
    public sealed partial class NewSectionName : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewSectionName"/> class.
        /// </summary>
        public NewSectionName()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textBox_NewSectionName.Focus(FocusState.Keyboard);
        }

        private void TextBox_NewSectionName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                bool foundSection = false;
                foreach (var item in Model.Sections)
                {
                    if (item.Key == textBox_NewSectionName.Text)
                    {
                        Model.Sections.CurrentSection = item.Value;
                        foundSection = true;
                        break;
                    }
                }

                if (!foundSection)
                {
                    Model.Sections.AddNewSection(textBox_NewSectionName.Text, 200000000000m, 0.000022m, 0.1m, 2450m, 100m, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Solid Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                    foreach (var item in Model.Sections)
                    {
                        if (item.Key == textBox_NewSectionName.Text)
                        {
                            Model.Sections.CurrentSection = item.Value;
                            foundSection = true;
                            break;
                        }
                    }
                }

                PanelSections.Current.HideNewSectionName();
            }
        }
    }
}