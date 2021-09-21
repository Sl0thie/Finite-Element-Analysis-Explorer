namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Microsoft.Graphics.Canvas.Geometry;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// LineSelectorBox UserControl used to select line types.
    /// </summary>
    public sealed partial class LineSelectorBox : UserControl
    {
        private bool isControlLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineSelectorBox"/> class.
        /// </summary>
        public LineSelectorBox()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SingleValue_ColorAlpha.Title = "Alpha";
            SingleValue_ColorRed.Title = "Red";
            SingleValue_ColorGreen.Title = "Green";
            SingleValue_ColorBlue.Title = "Blue";

            SingleValue_ColorAlpha.UnitType = UnitType.UnitlessInteger;
            SingleValue_ColorRed.UnitType = UnitType.UnitlessInteger;
            SingleValue_ColorGreen.UnitType = UnitType.UnitlessInteger;
            SingleValue_ColorBlue.UnitType = UnitType.UnitlessInteger;

            SingleValue_DashOffset.Title = "Dash Offset";
            SingleValue_DashOffset.UnitType = UnitType.Unitless;

            SingleValue_LineWeight.Title = "Line Weight";
            SingleValue_LineWeight.UnitType = UnitType.Unitless;

            SingleValue_MiterLimit.Title = "Miter Limit";
            SingleValue_MiterLimit.UnitType = UnitType.Unitless;

            SingleValue_ColorAlpha.SetTheValue(Model.Sections.CurrentSection.Alpha);
            SingleValue_ColorRed.SetTheValue(Model.Sections.CurrentSection.Red);
            SingleValue_ColorGreen.SetTheValue(Model.Sections.CurrentSection.Green);
            SingleValue_ColorBlue.SetTheValue(Model.Sections.CurrentSection.Blue);

            slider_A.Value = Model.Sections.CurrentSection.Alpha;
            slider_R.Value = Model.Sections.CurrentSection.Red;
            slider_G.Value = Model.Sections.CurrentSection.Green;
            slider_B.Value = Model.Sections.CurrentSection.Blue;

            SingleValue_DashOffset.SetTheValue((decimal)Model.Sections.CurrentSection.DashOffset);
            SingleValue_MiterLimit.SetTheValue((decimal)Model.Sections.CurrentSection.MiterLimit);
            SingleValue_LineWeight.SetTheValue((decimal)Model.Sections.CurrentSection.LineWeight);

            comboBox_LineStyle.SelectedIndex = (int)Model.Sections.CurrentSection.Line;
            comboBox_NearCapStyle.SelectedIndex = (int)Model.Sections.CurrentSection.NearCapStyle;
            comboBox_FarCapStyle.SelectedIndex = (int)Model.Sections.CurrentSection.FarCapStyle;
            comboBox_LineJoinStyle.SelectedIndex = (int)Model.Sections.CurrentSection.LineJoin;

            rectangle_Color.Fill = new SolidColorBrush(Color.FromArgb((byte)SingleValue_ColorAlpha.NewValue, (byte)SingleValue_ColorRed.NewValue, (byte)SingleValue_ColorGreen.NewValue, (byte)SingleValue_ColorBlue.NewValue));

            isControlLoaded = true;
        }

        private void UpdateColor()
        {
            if (isControlLoaded)
            {
                Color tmpColor = Color.FromArgb((byte)SingleValue_ColorAlpha.NewValue, (byte)SingleValue_ColorRed.NewValue, (byte)SingleValue_ColorGreen.NewValue, (byte)SingleValue_ColorBlue.NewValue);

                Model.Sections.CurrentSection.Alpha = tmpColor.A;
                Model.Sections.CurrentSection.Red = tmpColor.R;
                Model.Sections.CurrentSection.Green = tmpColor.G;
                Model.Sections.CurrentSection.Blue = tmpColor.B;

                Model.Sections.CurrentSection.DashOffset = (float)SingleValue_DashOffset.NewValue;
                Model.Sections.CurrentSection.Line = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                Model.Sections.CurrentSection.NearCapStyle = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                Model.Sections.CurrentSection.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                Model.Sections.CurrentSection.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                Model.Sections.CurrentSection.FarCapStyle = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                Model.Sections.CurrentSection.LineWeight = (float)SingleValue_LineWeight.NewValue;

                SingleValue_DashOffset.SetTheValue((decimal)Model.Sections.CurrentSection.DashOffset);
                SingleValue_MiterLimit.SetTheValue((decimal)Model.Sections.CurrentSection.MiterLimit);
                SingleValue_LineWeight.SetTheValue((decimal)Model.Sections.CurrentSection.LineWeight);
                rectangle_Color.Fill = new SolidColorBrush(tmpColor);
                SingleValue_ColorAlpha.SetTheValue(tmpColor.A);
                SingleValue_ColorRed.SetTheValue(tmpColor.R);
                SingleValue_ColorGreen.SetTheValue(tmpColor.G);
                SingleValue_ColorBlue.SetTheValue(tmpColor.B);
                
                Options.Colors.Save();
            }
        }

        private void SingleValue_ColorAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorAlpha.NewValue < 0)
            {
                SingleValue_ColorAlpha.NewValue = 0;
            }

            if (SingleValue_ColorAlpha.NewValue > 255)
            {
                SingleValue_ColorAlpha.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorRed_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorRed.NewValue < 0)
            {
                SingleValue_ColorRed.NewValue = 0;
            }

            if (SingleValue_ColorRed.NewValue > 255)
            {
                SingleValue_ColorRed.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorGreen_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorGreen.NewValue < 0)
            {
                SingleValue_ColorGreen.NewValue = 0;
            }

            if (SingleValue_ColorGreen.NewValue > 255)
            {
                SingleValue_ColorGreen.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorBlue_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorBlue.NewValue < 0)
            {
                SingleValue_ColorBlue.NewValue = 0;
            }

            if (SingleValue_ColorBlue.NewValue > 255)
            {
                SingleValue_ColorBlue.NewValue = 255;
            }

            UpdateColor();
        }

        private void Slider_A_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorAlpha.SetTheValue((byte)slider_A.Value);
            UpdateColor();
        }

        private void Slider_R_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorRed.SetTheValue((byte)slider_R.Value);
            UpdateColor();
        }

        private void Slider_G_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorGreen.SetTheValue((byte)slider_G.Value);
            UpdateColor();
        }

        private void Slider_B_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorBlue.SetTheValue((byte)slider_B.Value);
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
            if (SingleValue_LineWeight.NewValue < 0)
            {
                SingleValue_LineWeight.NewValue = 1;
            }

            if (SingleValue_LineWeight.NewValue > 255)
            {
                SingleValue_LineWeight.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_MiterLimit_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_MiterLimit.NewValue < 0)
            {
                SingleValue_MiterLimit.NewValue = 1;
            }

            if (SingleValue_MiterLimit.NewValue > 255)
            {
                SingleValue_MiterLimit.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_DashOffset_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_DashOffset.NewValue < 0)
            {
                SingleValue_DashOffset.NewValue = 1;
            }

            if (SingleValue_DashOffset.NewValue > 255)
            {
                SingleValue_DashOffset.NewValue = 255;
            }

            UpdateColor();
        }
    }
}