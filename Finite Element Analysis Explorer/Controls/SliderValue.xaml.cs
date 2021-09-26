namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Input;

    /// <summary>
    /// SliderValue UserControl provides a sider input.
    /// </summary>
    public sealed partial class SliderValue : UserControl
    {
        /// <summary>
        /// Event that is raised when the value changes.
        /// </summary>
        public event EventHandler ValueChanged;

        private string title;

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                TextBlock_Title.Text = title;
            }
        }

        private string displayValue;

        /// <summary>
        /// Gets or sets the display value.
        /// </summary>
        public string DisplayValue
        {
            get
            {
                return displayValue;
            }

            set
            {
                displayValue = value;
                TextBlock_Value.Text = displayValue;
            }
        }

        private double minValue;

        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        public double MinValue
        {
            get
            {
                return minValue;
            }

            set
            {
                minValue = value;
                Slider_Primary.Minimum = value;
            }
        }

        private double maxValue;

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        public double MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                maxValue = value;
                Slider_Primary.Maximum = value;
            }
        }

        private double newValue;

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        public double NewValue
        {
            get
            {
                return newValue;
            }

            set
            {
                newValue = value;
                Slider_Primary.Value = newValue;
            }
        }

        private double oldValue;

        /// <summary>
        /// Gets or sets the old value.
        /// </summary>
        public double OldValue
        {
            get
            {
                return oldValue;
            }

            set
            {
                oldValue = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SliderValue"/> class.
        /// </summary>
        public SliderValue()
        {
            InitializeComponent();
        }

        private void Slider_Primary_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            newValue = Slider_Primary.Value;
            if (newValue == oldValue)
            {
            }
            else
            {
                oldValue = newValue;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        private void TextBlock_Minus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Slider_Primary.Value > Slider_Primary.Minimum)
            {
                Slider_Primary.Value--;
            }
        }

        private void TextBlock_Plus_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Slider_Primary.Value < Slider_Primary.Maximum)
            {
                Slider_Primary.Value++;
            }
        }
    }
}
