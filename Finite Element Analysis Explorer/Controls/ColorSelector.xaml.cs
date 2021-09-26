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

            switch (Options.Colors.ColorToEdit)
            {
                case "ColorBackground":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.Background.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.Background.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.Background.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.Background.B);
                    slider_A.Value = Options.Colors.Background.A;
                    slider_R.Value = Options.Colors.Background.R;
                    slider_G.Value = Options.Colors.Background.G;
                    slider_B.Value = Options.Colors.Background.B;
                    break;

                case "ColorForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.Force.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.Force.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.Force.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.Force.B);
                    slider_A.Value = Options.Colors.Force.A;
                    slider_R.Value = Options.Colors.Force.R;
                    slider_G.Value = Options.Colors.Force.G;
                    slider_B.Value = Options.Colors.Force.B;
                    break;

                case "ColorReaction":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.Reaction.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.Reaction.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.Reaction.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.Reaction.B);
                    slider_A.Value = Options.Colors.Reaction.A;
                    slider_R.Value = Options.Colors.Reaction.R;
                    slider_G.Value = Options.Colors.Reaction.G;
                    slider_B.Value = Options.Colors.Reaction.B;
                    break;
            }
        }

        /// <summary>
        /// Updates the control when changes are made.
        /// </summary>
        private void UpdateColor()
        {
            Color tmpColor = Color.FromArgb((byte)SingleValue_ColorAlpha.NewValue, (byte)SingleValue_ColorRed.NewValue, (byte)SingleValue_ColorGreen.NewValue, (byte)SingleValue_ColorBlue.NewValue);

            switch (Options.Colors.ColorToEdit)
            {
                case "ColorBackground":
                    Options.Colors.Background = tmpColor;
                    break;
                case "ColorForce":
                    Options.Colors.Force = tmpColor;
                    break;
                case "ColorReaction":
                    Options.Colors.Reaction = tmpColor;
                    break;
            }

            rectangle_Color.Fill = new SolidColorBrush(tmpColor);
            SingleValue_ColorAlpha.SetTheValue(tmpColor.A);
            SingleValue_ColorRed.SetTheValue(tmpColor.R);
            SingleValue_ColorGreen.SetTheValue(tmpColor.G);
            SingleValue_ColorBlue.SetTheValue(tmpColor.B);
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
