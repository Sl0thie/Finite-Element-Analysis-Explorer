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
using Microsoft.Graphics.Canvas.Geometry;
using System.Diagnostics;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class LineSelectorBox : UserControl
    {
        private bool IsControlLoaded = false;
        public LineSelectorBox()
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

            singleValue_DashOffset.Title = "Dash Offset";
            singleValue_DashOffset.UnitType = UnitType.Unitless;

            singleValue_LineWeight.Title = "Line Weight";
            singleValue_LineWeight.UnitType = UnitType.Unitless;

            singleValue_MiterLimit.Title = "Miter Limit";
            singleValue_MiterLimit.UnitType = UnitType.Unitless;

            singleValue_ColorAlpha.SetTheValue(Model.Sections.CurrentSection.Alpha);
            singleValue_ColorRed.SetTheValue(Model.Sections.CurrentSection.Red);
            singleValue_ColorGreen.SetTheValue(Model.Sections.CurrentSection.Green);
            singleValue_ColorBlue.SetTheValue(Model.Sections.CurrentSection.Blue);

            slider_A.Value = Model.Sections.CurrentSection.Alpha;
            slider_R.Value = Model.Sections.CurrentSection.Red;
            slider_G.Value = Model.Sections.CurrentSection.Green;
            slider_B.Value = Model.Sections.CurrentSection.Blue;

            singleValue_DashOffset.SetTheValue((decimal)Model.Sections.CurrentSection.DashOffset);
            singleValue_MiterLimit.SetTheValue((decimal)Model.Sections.CurrentSection.MiterLimit);
            singleValue_LineWeight.SetTheValue((decimal)Model.Sections.CurrentSection.LineWeight);

            comboBox_LineStyle.SelectedIndex = (int)Model.Sections.CurrentSection.Line;
            comboBox_NearCapStyle.SelectedIndex = (int)Model.Sections.CurrentSection.NearCapStyle;
            comboBox_FarCapStyle.SelectedIndex = (int)Model.Sections.CurrentSection.FarCapStyle;
            comboBox_LineJoinStyle.SelectedIndex = (int)Model.Sections.CurrentSection.LineJoin;

            rectangle_Color.Fill = new SolidColorBrush(Color.FromArgb((byte)singleValue_ColorAlpha.NewValue, (byte)singleValue_ColorRed.NewValue, (byte)singleValue_ColorGreen.NewValue, (byte)singleValue_ColorBlue.NewValue));



            IsControlLoaded = true;
            //singleValue_LineWeight.SetValue();
        }

        private void UpdateColor()
        {
            if (IsControlLoaded)
            {
                Color tmpColor = Color.FromArgb((byte)singleValue_ColorAlpha.NewValue, (byte)singleValue_ColorRed.NewValue, (byte)singleValue_ColorGreen.NewValue, (byte)singleValue_ColorBlue.NewValue);

                Model.Sections.CurrentSection.Alpha = tmpColor.A;
                Model.Sections.CurrentSection.Red = tmpColor.R;
                Model.Sections.CurrentSection.Green = tmpColor.G;
                Model.Sections.CurrentSection.Blue = tmpColor.B;

                //Model.Sections.CurrentSection.DashCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                Model.Sections.CurrentSection.DashOffset = (float)singleValue_DashOffset.NewValue;
                Model.Sections.CurrentSection.Line = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                Model.Sections.CurrentSection.NearCapStyle = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                Model.Sections.CurrentSection.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                Model.Sections.CurrentSection.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                Model.Sections.CurrentSection.FarCapStyle = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                Model.Sections.CurrentSection.LineWeight = (float)singleValue_LineWeight.NewValue;

                singleValue_DashOffset.SetTheValue((decimal)Model.Sections.CurrentSection.DashOffset);
                singleValue_MiterLimit.SetTheValue((decimal)Model.Sections.CurrentSection.MiterLimit);
                singleValue_LineWeight.SetTheValue((decimal)Model.Sections.CurrentSection.LineWeight);
                rectangle_Color.Fill = new SolidColorBrush(tmpColor);
                singleValue_ColorAlpha.SetTheValue(tmpColor.A);
                singleValue_ColorRed.SetTheValue(tmpColor.R);
                singleValue_ColorGreen.SetTheValue(tmpColor.G);
                singleValue_ColorBlue.SetTheValue(tmpColor.B);
                Model.UpdateColors();
            }
        }

        private void SingleValue_ColorAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorAlpha.NewValue < 0) { singleValue_ColorAlpha.NewValue = 0; }
            if (singleValue_ColorAlpha.NewValue > 255) { singleValue_ColorAlpha.NewValue = 255; }
            UpdateColor();
        }

        private void SingleValue_ColorRed_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorRed.NewValue < 0) { singleValue_ColorRed.NewValue = 0; }
            if (singleValue_ColorRed.NewValue > 255) { singleValue_ColorRed.NewValue = 255; }
            UpdateColor();
        }

        private void SingleValue_ColorGreen_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorGreen.NewValue < 0) { singleValue_ColorGreen.NewValue = 0; }
            if (singleValue_ColorGreen.NewValue > 255) { singleValue_ColorGreen.NewValue = 255; }
            UpdateColor();
        }

        private void SingleValue_ColorBlue_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorBlue.NewValue < 0) { singleValue_ColorBlue.NewValue = 0; }
            if (singleValue_ColorBlue.NewValue > 255) { singleValue_ColorBlue.NewValue = 255; }
            UpdateColor();
        }

        private void Slider_A_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorAlpha.SetTheValue((byte)slider_A.Value);
            UpdateColor();
        }

        private void Slider_R_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorRed.SetTheValue((byte)slider_R.Value);
            UpdateColor();
        }

        private void Slider_G_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorGreen.SetTheValue((byte)slider_G.Value);
            UpdateColor();
        }

        private void Slider_B_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorBlue.SetTheValue((byte)slider_B.Value);
            UpdateColor();
        }

        private void ComboBox_LineStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void ComboBox_NearCapStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void ComboBox_FarCapStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void ComboBox_LineJoinStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void SingleValue_LineWeight_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_LineWeight.NewValue < 0) { singleValue_LineWeight.NewValue = 1; }
            if (singleValue_LineWeight.NewValue > 255) { singleValue_LineWeight.NewValue = 255; }
            UpdateColor();
        }

        private void SingleValue_MiterLimit_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_MiterLimit.NewValue < 0) { singleValue_MiterLimit.NewValue = 1; }
            if (singleValue_MiterLimit.NewValue > 255) { singleValue_MiterLimit.NewValue = 255; }
            UpdateColor();
        }

        private void SingleValue_DashOffset_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_DashOffset.NewValue < 0) { singleValue_DashOffset.NewValue = 1; }
            if (singleValue_DashOffset.NewValue > 255) { singleValue_DashOffset.NewValue = 255; }
            UpdateColor();
        }
    }
}
