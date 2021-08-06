using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// TextInput UserControl provides a simple text input.
    /// </summary>
    public sealed partial class TextInput : UserControl
    {
        /// <summary>
        /// Event that is raised when the value changes.
        /// </summary>
        public event EventHandler ValueChanged;

        private int roundingFactor = 6;
        private string numberString = string.Empty;
        private string exponentString = string.Empty;
        private string oldString = string.Empty;
        private decimal newValue;

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        public decimal NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextInput"/> class.
        /// </summary>
        public TextInput()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Sets the value to display.
        /// </summary>
        /// <param name="newValueToDisplay">The value to display.</param>
        public void SetTheValue(decimal newValueToDisplay)
        {
            if (!Options.LockNumericalInput)
            {
                // Previous Value is locked so don't bother processing.
                newValue = newValueToDisplay;
                ShowValue(newValueToDisplay);
            }
        }

        private void ShowValue(decimal valueToShow)
        {
            newValue = valueToShow;
            TextBox_TextInput.Text = valueToShow.ToString();

            TextBlock_Sign.Visibility = Visibility.Visible;
            TextBlock_Hundred.Visibility = Visibility.Visible;
            TextBlock_Ten.Visibility = Visibility.Visible;
            TextBlock_One.Visibility = Visibility.Visible;
            TextBlock_DecimalPoint.Visibility = Visibility.Visible;
            TextBlock_Tenth.Visibility = Visibility.Visible;
            TextBlock_Hundredth.Visibility = Visibility.Visible;
            TextBlock_Thousandth.Visibility = Visibility.Visible;

            TextBlock_E.Visibility = Visibility.Visible;
            TextBlock_ExponentSign.Visibility = Visibility.Visible;
            TextBlock_ExpTen.Visibility = Visibility.Visible;
            TextBlock_ExpOne.Visibility = Visibility.Visible;

            TextBlock_Sign.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_Hundred.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_Ten.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_One.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_DecimalPoint.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_Tenth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_Hundredth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_Thousandth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));

            TextBlock_E.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_ExponentSign.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_ExpTen.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            TextBlock_ExpOne.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));

            if (valueToShow < 0)
            {
                TextBlock_Sign.Text = "-";
                valueToShow = Math.Abs(valueToShow);
            }
            else
            {
                // TextBlock_Sign.Visibility = Visibility.Collapsed;
            }

            ConvertToEngineeringNotation(valueToShow);

            TextBlock_Hundred.Text = numberString.Substring(0, 1);
            TextBlock_Ten.Text = numberString.Substring(1, 1);
            TextBlock_One.Text = numberString.Substring(2, 1);
            TextBlock_DecimalPoint.Text = numberString.Substring(3, 1);
            TextBlock_Tenth.Text = numberString.Substring(4, 1);
            TextBlock_Hundredth.Text = numberString.Substring(5, 1);
            TextBlock_Thousandth.Text = numberString.Substring(6, 1);

            TextBlock_ExponentSign.Text = exponentString.Substring(1, 1);
            TextBlock_ExpTen.Text = exponentString.Substring(2, 1);
            TextBlock_ExpOne.Text = exponentString.Substring(3, 1);

            if (TextBlock_Hundred.Text == "0")
            {
                TextBlock_Hundred.Visibility = Visibility.Collapsed;
                if (TextBlock_Ten.Text == "0")
                {
                    TextBlock_Ten.Visibility = Visibility.Collapsed;
                }
            }

            if (TextBlock_Thousandth.Text == "0")
            {
                TextBlock_Thousandth.Visibility = Visibility.Collapsed;
                if (TextBlock_Hundredth.Text == "0")
                {
                    TextBlock_Hundredth.Visibility = Visibility.Collapsed;
                }
            }

            if (TextBlock_ExpTen.Text == "0")
            {
                if (TextBlock_ExpOne.Text == "0")
                {
                    // TextBlock_E.Visibility = Visibility.Collapsed;
                    // TextBlock_ExponentSign.Visibility = Visibility.Collapsed;
                    // TextBlock_ExpTen.Visibility = Visibility.Collapsed;
                    // TextBlock_ExpOne.Visibility = Visibility.Collapsed;
                }
                else
                {
                    if (TextBlock_ExponentSign.Text == "+")
                    {
                        // TextBlock_ExponentSign.Visibility = Visibility.Collapsed;
                    }

                    TextBlock_ExpTen.Visibility = Visibility.Collapsed;
                }
            }

            if (TextBlock_Sign.Text == "-")
            {
                TextBox_TextInput.Text = TextBlock_Sign.Text + valueToShow.ToString();
            }
            else
            {
                TextBox_TextInput.Text = valueToShow.ToString();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Debug.WriteLine("Here 4376");
            if (Options.LockNumericalInput)
            {
                fontIcon_Lock.Glyph = "🔒";
                ShowValue(Options.LastNumericalInput);
            }
            else
            {
                fontIcon_Lock.Glyph = "🔓";
            }

            TextBox_TextInput.Focus(FocusState.Keyboard);
        }

        private void ConvertToEngineeringNotation(decimal d)
        {
            double exponent = Math.Log10(Math.Abs((double)d));
            if (Math.Abs(d) >= 1)
            {
                switch ((int)Math.Floor(exponent))
                {
                    case 0:
                    case 1:
                    case 2:
                        numberString = Math.Round(d, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+00";
                        break;
                    case 3:
                    case 4:
                    case 5:
                        numberString = Math.Round(d / 1e3m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+03";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        numberString = Math.Round(d / 1e6m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+06";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        numberString = Math.Round(d / 1e9m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+09";
                        break;
                    case 12:
                    case 13:
                    case 14:
                        numberString = Math.Round(d / 1e12m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+12";
                        break;
                    case 15:
                    case 16:
                    case 17:
                        numberString = Math.Round(d / 1e15m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+15";
                        break;
                    case 18:
                    case 19:
                    case 20:
                        numberString = Math.Round(d / 1e18m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+18";
                        break;
                    case 21:
                    case 22:
                    case 23:
                        numberString = Math.Round(d / 1e21m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+21";
                        break;
                    default:
                        numberString = Math.Round(d / 1e24m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+24";
                        break;
                }
            }
            else if (Math.Abs(d) > 0)
            {
                switch ((int)Math.Floor(exponent))
                {
                    case -1:
                    case -2:
                    case -3:
                        numberString = Math.Round(d * 1e3m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-03";
                        break;
                    case -4:
                    case -5:
                    case -6:
                        numberString = Math.Round(d * 1e6m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-06";
                        break;
                    case -7:
                    case -8:
                    case -9:
                        numberString = Math.Round(d * 1e9m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-09";
                        break;
                    case -10:
                    case -11:
                    case -12:
                        numberString = Math.Round(d * 1e12m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-12";
                        break;
                    case -13:
                    case -14:
                    case -15:
                        numberString = Math.Round(d * 1e15m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-15";
                        break;
                    case -16:
                    case -17:
                    case -18:
                        numberString = Math.Round(d * 1e18m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-18";
                        break;
                    case -19:
                    case -20:
                    case -21:
                        numberString = Math.Round(d * 1e21m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-21";
                        break;
                    default:
                        numberString = Math.Round(d * 1e24m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-24";
                        break;
                }
            }
            else
            {
                numberString = "000.000";
                exponentString = "e+00";
            }
        }

        private void ParseDisplay()
        {
            try
            {
                string combinedNumber = TextBlock_Sign.Text +
                TextBlock_Hundred.Text +
                TextBlock_Ten.Text +
                TextBlock_One.Text +
                TextBlock_DecimalPoint.Text +
                TextBlock_Tenth.Text +
                TextBlock_Hundredth.Text +
                TextBlock_Thousandth.Text + "e" +
                TextBlock_ExponentSign.Text +
                TextBlock_ExpTen.Text +
                TextBlock_ExpOne.Text;

                newValue = decimal.Parse(combinedNumber, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                ShowValue(newValue);
            }
            catch
            {
                ShowValue(0);
            }
        }

        private void AdjustValue(decimal amount)
        {
            double currentExponent = double.Parse(TextBlock_ExponentSign.Text + TextBlock_ExpTen.Text + TextBlock_ExpOne.Text);

            if (currentExponent == 0)
            {
                newValue += amount;
            }
            else
            {
                if (newValue < 0)
                {
                    newValue -= amount * (decimal)Math.Pow(10, currentExponent);
                }
                else
                {
                    newValue += amount * (decimal)Math.Pow(10, currentExponent);
                }
            }

            ShowValue(newValue);

            // ParseDisplay();
        }

        #region Enter Button

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            Options.LastNumericalInput = newValue;
            ValueChanged?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Keyboard Keys

        private void TextBox_TextInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {
        }

        private void TextBox_TextInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                if (e.Key.ToString() == "Enter")
                {
                    newValue = decimal.Parse(TextBox_TextInput.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent | NumberStyles.AllowLeadingSign);
                    ShowValue(newValue);
                    oldString = TextBox_TextInput.Text;
                    Options.LastNumericalInput = newValue;
                    ValueChanged?.Invoke(this, new EventArgs());
                }
            }
            catch
            {
                TextBox_TextInput.Text = oldString;
            }
        }

        #endregion

        #region Lock

        private void Button_Lock_Click(object sender, RoutedEventArgs e)
        {
            if (fontIcon_Lock.Glyph == "🔓")
            {
                fontIcon_Lock.Glyph = "🔒";
                Options.LockNumericalInput = true;
            }
            else
            {
                fontIcon_Lock.Glyph = "🔓";
                Options.LockNumericalInput = false;
            }
        }

        #endregion

        #region Sign

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            // if (TextBlock_Sign.Text == "+")
            // {
            //    TextBlock_Sign.Text = "-";
            // }
            // else
            // {
            //    TextBlock_Sign.Text = "+";
            // }
            TextBlock_Sign.Text = "+";
            ParseDisplay();
        }

        private void Button_SignDown_Click(object sender, RoutedEventArgs e)
        {
            // if (TextBlock_Sign.Text == "+")
            // {
            //    TextBlock_Sign.Text = "-";
            // }
            // else
            // {
            //    TextBlock_Sign.Text = "+";
            // }
            TextBlock_Sign.Text = "-";
            ParseDisplay();
        }

        #endregion

        #region Hundred

        private void Button_HundredUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(100);

            // switch (TextBlock_Hundred.Text)
            // {
            //    case "0":
            //        TextBlock_Hundred.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_Hundred.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_Hundred.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_Hundred.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_Hundred.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_Hundred.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_Hundred.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_Hundred.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_Hundred.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_Hundred.Text = "0";
            //        break;
            // }
            // ParseDisplay();
        }

        private void Button_HundredDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-100);

            // switch (TextBlock_Hundred.Text)
            // {
            //    case "0":
            //        TextBlock_Hundred.Text = "9";
            //        break;
            //    case "1":
            //        TextBlock_Hundred.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_Hundred.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_Hundred.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_Hundred.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_Hundred.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_Hundred.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_Hundred.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_Hundred.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_Hundred.Text = "8";
            //        break;
            // }
            // ParseDisplay();
        }

        #endregion

        #region Ten

        private void Button_TenUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(10);

            // switch (TextBlock_Ten.Text)
            // {
            //    case "0":
            //        TextBlock_Ten.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_Ten.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_Ten.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_Ten.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_Ten.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_Ten.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_Ten.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_Ten.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_Ten.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_Ten.Text = "0";
            //        break;
            // }
            // ParseDisplay();
        }

        private void Button_TenDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-10);

            // switch (TextBlock_Ten.Text)
            // {
            //    case "0":
            //        TextBlock_Ten.Text = "9";
            //        break;
            //    case "1":
            //        TextBlock_Ten.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_Ten.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_Ten.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_Ten.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_Ten.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_Ten.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_Ten.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_Ten.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_Ten.Text = "8";
            //        break;
            // }
            // ParseDisplay();
        }

        #endregion

        #region One

        private void Button_OneUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(1);

            // switch (TextBlock_One.Text)
            // {
            //    case "0":
            //        TextBlock_One.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_One.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_One.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_One.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_One.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_One.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_One.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_One.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_One.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_One.Text = "0";
            //        break;
            // }
            // ParseDisplay();
        }

        private void Button_OneDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-1);

            // switch (TextBlock_One.Text)
            // {
            //    case "0":
            //        TextBlock_One.Text = "9";
            //        break;
            //    case "1":
            //        TextBlock_One.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_One.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_One.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_One.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_One.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_One.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_One.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_One.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_One.Text = "8";
            //        break;
            // }
            // ParseDisplay();
        }

        #endregion

        #region Tenth

        private void Button_TenthUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(0.1m);

            // switch (TextBlock_Tenth.Text)
            // {
            //    case "0":
            //        TextBlock_Tenth.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_Tenth.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_Tenth.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_Tenth.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_Tenth.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_Tenth.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_Tenth.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_Tenth.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_Tenth.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_Tenth.Text = "0";
            //        break;
            // }
            // ParseDisplay();
        }

        private void Button_TenthDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-0.1m);

            // switch (TextBlock_Tenth.Text)
            // {
            //    case "0":
            //        TextBlock_Tenth.Text = "9";
            //        break;
            //    case "1":
            //        TextBlock_Tenth.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_Tenth.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_Tenth.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_Tenth.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_Tenth.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_Tenth.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_Tenth.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_Tenth.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_Tenth.Text = "8";
            //        break;
            // }
            // ParseDisplay();
        }

        #endregion

        #region Hundredth

        private void Button_HundredthUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(0.01m);

            // switch (TextBlock_Hundredth.Text)
            // {
            //    case "0":
            //        TextBlock_Hundredth.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_Hundredth.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_Hundredth.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_Hundredth.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_Hundredth.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_Hundredth.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_Hundredth.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_Hundredth.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_Hundredth.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_Hundredth.Text = "0";
            //        break;
            // }
            // ParseDisplay();
        }

        private void Button_HundredthDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-0.01m);

            // switch (TextBlock_Hundredth.Text)
            // {
            //    case "0":
            //        TextBlock_Hundredth.Text = "9";
            //        break;
            //    case "1":
            //        TextBlock_Hundredth.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_Hundredth.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_Hundredth.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_Hundredth.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_Hundredth.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_Hundredth.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_Hundredth.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_Hundredth.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_Hundredth.Text = "8";
            //        break;
            // }
            // ParseDisplay();
        }

        #endregion

        #region Thousandth

        private void Button_ThousandthUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(0.001m);

            // switch (TextBlock_Thousandth.Text)
            // {
            //    case "0":
            //        TextBlock_Thousandth.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_Thousandth.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_Thousandth.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_Thousandth.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_Thousandth.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_Thousandth.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_Thousandth.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_Thousandth.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_Thousandth.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_Thousandth.Text = "0";
            //        break;
            // }
            // ParseDisplay();
        }

        private void Button_ThousandthDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-0.001m);

            // switch (TextBlock_Thousandth.Text)
            // {
            //    case "0":
            //        TextBlock_Thousandth.Text = "9";
            //        break;
            //    case "1":
            //        TextBlock_Thousandth.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_Thousandth.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_Thousandth.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_Thousandth.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_Thousandth.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_Thousandth.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_Thousandth.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_Thousandth.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_Thousandth.Text = "8";
            //        break;
            // }
            // ParseDisplay();
        }

        #endregion

        #region Exponent Sign

        private void Button_ExponentSignUp_Click(object sender, RoutedEventArgs e)
        {
            // if (TextBlock_ExponentSign.Text == "+")
            // {
            //    TextBlock_ExponentSign.Text = "-";
            // }
            // else
            // {
            //    TextBlock_ExponentSign.Text = "+";
            // }
            TextBlock_ExponentSign.Text = "+";
            ParseDisplay();
        }

        private void Button_SignExponentSignDown_Click(object sender, RoutedEventArgs e)
        {
            // if (TextBlock_ExponentSign.Text == "+")
            // {
            //    TextBlock_ExponentSign.Text = "-";
            // }
            // else
            // {
            //    TextBlock_ExponentSign.Text = "+";
            // }
            TextBlock_ExponentSign.Text = "-";
            ParseDisplay();
        }

        #endregion

        #region ExpTen

        private void Button_ExpTenUp_Click(object sender, RoutedEventArgs e)
        {
            // switch (TextBlock_ExpTen.Text)
            // {
            //    case "0":
            //        TextBlock_ExpTen.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_ExpTen.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_ExpTen.Text = "0";
            //        break;
            // }
            // ParseDisplay();
            newValue *= 10000000000;
            ShowValue(newValue);
        }

        private void Button_ExpTenDown_Click(object sender, RoutedEventArgs e)
        {
            // switch (TextBlock_ExpTen.Text)
            // {
            //    case "0":
            //        TextBlock_ExpTen.Text = "2";
            //        break;
            //    case "1":
            //        TextBlock_ExpTen.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_ExpTen.Text = "1";
            //        break;
            // }
            // ParseDisplay();
            newValue /= 10000000000;
            ShowValue(newValue);
        }

        #endregion

        #region ExpOne

        private void Button_ExpOneUp_Click(object sender, RoutedEventArgs e)
        {
            // switch (TextBlock_ExpOne.Text)
            // {
            //    case "0":
            //        TextBlock_ExpOne.Text = "1";
            //        break;
            //    case "1":
            //        TextBlock_ExpOne.Text = "2";
            //        break;
            //    case "2":
            //        TextBlock_ExpOne.Text = "3";
            //        break;
            //    case "3":
            //        TextBlock_ExpOne.Text = "4";
            //        break;
            //    case "4":
            //        TextBlock_ExpOne.Text = "5";
            //        break;
            //    case "5":
            //        TextBlock_ExpOne.Text = "6";
            //        break;
            //    case "6":
            //        TextBlock_ExpOne.Text = "7";
            //        break;
            //    case "7":
            //        TextBlock_ExpOne.Text = "8";
            //        break;
            //    case "8":
            //        TextBlock_ExpOne.Text = "9";
            //        break;
            //    case "9":
            //        TextBlock_ExpOne.Text = "0";
            //        switch (TextBlock_ExpTen.Text)
            //        {
            //            case "0":
            //                TextBlock_ExpTen.Text = "1";
            //                break;

            // case "1":
            //                TextBlock_ExpTen.Text = "2";
            //                break;

            // case "2":
            //                ShowValue(0);
            //                break;

            // default:
            //                ShowValue(0);
            //                break;
            //        }
            //        break;
            // }
            newValue *= 10;
            ShowValue(newValue);

            // ParseDisplay();
        }

        private void Button_ExpOneDown_Click(object sender, RoutedEventArgs e)
        {
            // switch (TextBlock_ExpOne.Text)
            // {
            //    case "0":
            //        TextBlock_ExpOne.Text = "9";
            //        switch (TextBlock_ExpTen.Text)
            //        {
            //            case "0":
            //                TextBlock_ExpTen.Text = "0";
            //                break;

            // case "1":
            //                TextBlock_ExpTen.Text = "0";
            //                break;

            // case "2":
            //                TextBlock_ExpTen.Text = "1";
            //                break;

            // default:
            //                ShowValue(0);
            //                break;
            //        }
            //        break;
            //    case "1":
            //        TextBlock_ExpOne.Text = "0";
            //        break;
            //    case "2":
            //        TextBlock_ExpOne.Text = "1";
            //        break;
            //    case "3":
            //        TextBlock_ExpOne.Text = "2";
            //        break;
            //    case "4":
            //        TextBlock_ExpOne.Text = "3";
            //        break;
            //    case "5":
            //        TextBlock_ExpOne.Text = "4";
            //        break;
            //    case "6":
            //        TextBlock_ExpOne.Text = "5";
            //        break;
            //    case "7":
            //        TextBlock_ExpOne.Text = "6";
            //        break;
            //    case "8":
            //        TextBlock_ExpOne.Text = "7";
            //        break;
            //    case "9":
            //        TextBlock_ExpOne.Text = "8";
            //        break;
            // }
            newValue /= 10;
            ShowValue(newValue);

            // ParseDisplay();
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowValue(0);
        }
    }
}
