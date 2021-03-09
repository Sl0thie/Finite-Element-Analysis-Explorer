using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class ColorSelector : UserControl
    {
        public ColorSelector()
        {
            this.InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            singleValue_ColorAlpha.Title = "Alpha";
            singleValue_ColorRed.Title = "Red";
            singleValue_ColorGreen.Title = "Green";
            singleValue_ColorBlue.Title = "Blue";

            singleValue_ColorAlpha.UnitType = UnitType.UnitlessInteger;
            singleValue_ColorRed.UnitType = UnitType.UnitlessInteger;
            singleValue_ColorGreen.UnitType = UnitType.UnitlessInteger;
            singleValue_ColorBlue.UnitType = UnitType.UnitlessInteger;

            switch (Options.ColorToEdit)
            {
                case "ColorBackground":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorBackground.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorBackground.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorBackground.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorBackground.B);
                    slider_A.Value = Options.ColorBackground.A;
                    slider_R.Value = Options.ColorBackground.R;
                    slider_G.Value = Options.ColorBackground.G;
                    slider_B.Value = Options.ColorBackground.B;
                    break;

                case "ColorForce":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorForce.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorForce.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorForce.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorForce.B);
                    slider_A.Value = Options.ColorForce.A;
                    slider_R.Value = Options.ColorForce.R;
                    slider_G.Value = Options.ColorForce.G;
                    slider_B.Value = Options.ColorForce.B;
                    break;

                case "ColorReaction":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorReaction.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorReaction.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorReaction.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorReaction.B);
                    slider_A.Value = Options.ColorReaction.A;
                    slider_R.Value = Options.ColorReaction.R;
                    slider_G.Value = Options.ColorReaction.G;
                    slider_B.Value = Options.ColorReaction.B;
                    break;
            }
        }

        private void UpdateColor()
        {
            Color tmpColor = Color.FromArgb((byte)singleValue_ColorAlpha.NewValue, (byte)singleValue_ColorRed.NewValue, (byte)singleValue_ColorGreen.NewValue, (byte)singleValue_ColorBlue.NewValue);

            switch (Options.ColorToEdit)
            {
                case "ColorBackground":
                    Options.ColorBackground = tmpColor;
                    break;
                case "ColorForce":
                    Options.ColorForce = tmpColor;
                    break;
                case "ColorReaction":
                    Options.ColorReaction = tmpColor;
                    break;
            }

            rectangle_Color.Fill = new SolidColorBrush(tmpColor);
            singleValue_ColorAlpha.SetTheValue(tmpColor.A);
            singleValue_ColorRed.SetTheValue(tmpColor.R);
            singleValue_ColorGreen.SetTheValue(tmpColor.G);
            singleValue_ColorBlue.SetTheValue(tmpColor.B);

            Model.UpdateColors();
        }

        private void singleValue_ColorAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorAlpha.NewValue < 0) { singleValue_ColorAlpha.NewValue = 0; }
            if (singleValue_ColorAlpha.NewValue > 255) { singleValue_ColorAlpha.NewValue = 255; }
            UpdateColor();
        }

        private void singleValue_ColorRed_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorRed.NewValue < 0) { singleValue_ColorRed.NewValue = 0; }
            if (singleValue_ColorRed.NewValue > 255) { singleValue_ColorRed.NewValue = 255; }
            UpdateColor();
        }

        private void singleValue_ColorGreen_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorGreen.NewValue < 0) { singleValue_ColorGreen.NewValue = 0; }
            if (singleValue_ColorGreen.NewValue > 255) { singleValue_ColorGreen.NewValue = 255; }
            UpdateColor();
        }

        private void singleValue_ColorBlue_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorBlue.NewValue < 0) { singleValue_ColorBlue.NewValue = 0; }
            if (singleValue_ColorBlue.NewValue > 255) { singleValue_ColorBlue.NewValue = 255; }
            UpdateColor();
        }

        private void slider_A_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorAlpha.SetTheValue((byte)slider_A.Value);
            UpdateColor();
        }

        private void slider_R_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorRed.SetTheValue((byte)slider_R.Value);
            UpdateColor();
        }

        private void slider_G_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorGreen.SetTheValue((byte)slider_G.Value);
            UpdateColor();
        }

        private void slider_B_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorBlue.SetTheValue((byte)slider_B.Value);
            UpdateColor();
        }
    }
}
