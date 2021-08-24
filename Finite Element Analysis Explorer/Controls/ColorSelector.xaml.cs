namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// ColorSelector UserControl.
    /// Provides a UI for users to pick colors.
    /// TODO Check the shadow cast as it seems over-sized.
    /// </summary>
    public sealed partial class ColorSelector : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSelector"/> class.
        /// </summary>
        public ColorSelector()
        {
            this.InitializeComponent();
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

            switch (Options.ColorToEdit)
            {
                case "ColorBackground":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorBackground.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorBackground.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorBackground.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorBackground.B);
                    slider_A.Value = Options.ColorBackground.A;
                    slider_R.Value = Options.ColorBackground.R;
                    slider_G.Value = Options.ColorBackground.G;
                    slider_B.Value = Options.ColorBackground.B;
                    break;

                case "ColorForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorForce.B);
                    slider_A.Value = Options.ColorForce.A;
                    slider_R.Value = Options.ColorForce.R;
                    slider_G.Value = Options.ColorForce.G;
                    slider_B.Value = Options.ColorForce.B;
                    break;

                case "ColorReaction":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorReaction.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorReaction.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorReaction.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorReaction.B);
                    slider_A.Value = Options.ColorReaction.A;
                    slider_R.Value = Options.ColorReaction.R;
                    slider_G.Value = Options.ColorReaction.G;
                    slider_B.Value = Options.ColorReaction.B;
                    break;
            }
        }

        /// <summary>
        /// Updates the control when changes are made.
        /// </summary>
        private void UpdateColor()
        {
            Color tmpColor = Color.FromArgb((byte)SingleValue_ColorAlpha.NewValue, (byte)SingleValue_ColorRed.NewValue, (byte)SingleValue_ColorGreen.NewValue, (byte)SingleValue_ColorBlue.NewValue);

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
            SingleValue_ColorAlpha.SetTheValue(tmpColor.A);
            SingleValue_ColorRed.SetTheValue(tmpColor.R);
            SingleValue_ColorGreen.SetTheValue(tmpColor.G);
            SingleValue_ColorBlue.SetTheValue(tmpColor.B);

            Model.UpdateColors();
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
    }
}
