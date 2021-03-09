using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class TextInput : UserControl
    {
        public event EventHandler ValueChanged;

        private int RoundingFactor = 6;
        //private decimal theValue = 0;
        private string numberString = "";
        private string exponentString = "";
        private string oldString = "";

        private decimal newValue;
        public decimal NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }

        public TextInput()
        {
            this.InitializeComponent();
        }

        public void SetTheValue(decimal newValueToDisplay)
        {
            if (!Options.LockNumericalInput)
            {
                //Previous Value is locked so don't bother processing.
                newValue = newValueToDisplay;
                ShowValue(newValueToDisplay);
            }
        }

        private void ShowValue(decimal valueToShow)
        {
            newValue = valueToShow;
            textBox_TextInput.Text = valueToShow.ToString();

            textBlock_Sign.Visibility = Visibility.Visible;
            textBlock_Hundred.Visibility = Visibility.Visible;
            textBlock_Ten.Visibility = Visibility.Visible;
            textBlock_One.Visibility = Visibility.Visible;
            textBlock_DecimalPoint.Visibility = Visibility.Visible;
            textBlock_Tenth.Visibility = Visibility.Visible;
            textBlock_Hundredth.Visibility = Visibility.Visible;
            textBlock_Thousandth.Visibility = Visibility.Visible;

            textBlock_E.Visibility = Visibility.Visible;
            textBlock_ExponentSign.Visibility = Visibility.Visible;
            textBlock_ExpTen.Visibility = Visibility.Visible;
            textBlock_ExpOne.Visibility = Visibility.Visible;

            textBlock_Sign.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Hundred.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Ten.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_One.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_DecimalPoint.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Tenth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Hundredth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Thousandth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));

            textBlock_E.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_ExponentSign.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_ExpTen.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_ExpOne.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));

            if (valueToShow < 0)
            {
                textBlock_Sign.Text = "-";
                valueToShow = Math.Abs(valueToShow);
            }
            else
            {
                //textBlock_Sign.Visibility = Visibility.Collapsed;
            }

            ConvertToEngineeringNotation(valueToShow);

            textBlock_Hundred.Text = numberString.Substring(0, 1);
            textBlock_Ten.Text = numberString.Substring(1, 1);
            textBlock_One.Text = numberString.Substring(2, 1);
            textBlock_DecimalPoint.Text = numberString.Substring(3, 1);
            textBlock_Tenth.Text = numberString.Substring(4, 1);
            textBlock_Hundredth.Text = numberString.Substring(5, 1);
            textBlock_Thousandth.Text = numberString.Substring(6, 1);

            textBlock_ExponentSign.Text = exponentString.Substring(1, 1);
            textBlock_ExpTen.Text = exponentString.Substring(2, 1);
            textBlock_ExpOne.Text = exponentString.Substring(3, 1);

            if (textBlock_Hundred.Text == "0")
            {
                textBlock_Hundred.Visibility = Visibility.Collapsed;
                if (textBlock_Ten.Text == "0")
                {
                    textBlock_Ten.Visibility = Visibility.Collapsed;
                }
            }

            if (textBlock_Thousandth.Text == "0")
            {
                textBlock_Thousandth.Visibility = Visibility.Collapsed;
                if (textBlock_Hundredth.Text == "0")
                {
                    textBlock_Hundredth.Visibility = Visibility.Collapsed;
                }
            }

            if (textBlock_ExpTen.Text == "0")
            {
                if (textBlock_ExpOne.Text == "0")
                {
                    //textBlock_E.Visibility = Visibility.Collapsed;
                    //textBlock_ExponentSign.Visibility = Visibility.Collapsed;
                    //textBlock_ExpTen.Visibility = Visibility.Collapsed;
                    //textBlock_ExpOne.Visibility = Visibility.Collapsed;
                }
                else
                {
                    if (textBlock_ExponentSign.Text == "+")
                    {
                        //textBlock_ExponentSign.Visibility = Visibility.Collapsed;
                    }
                    textBlock_ExpTen.Visibility = Visibility.Collapsed;
                }
            }

            if (textBlock_Sign.Text == "-")
            {
                textBox_TextInput.Text = textBlock_Sign.Text + valueToShow.ToString();
            }
            else
            {
                textBox_TextInput.Text = valueToShow.ToString();
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("Here 4376");

            if (Options.LockNumericalInput)
            {
                fontIcon_Lock.Glyph = "🔒";
                ShowValue(Options.LastNumericalInput);
            }
            else
            {
                fontIcon_Lock.Glyph = "🔓";
            }

            textBox_TextInput.Focus(FocusState.Keyboard);


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
                        numberString = Math.Round(d, RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+00";
                        break;
                    case 3:
                    case 4:
                    case 5:
                        numberString = Math.Round((d / 1e3m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+03";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        numberString = Math.Round((d / 1e6m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+06";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        numberString = Math.Round((d / 1e9m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+09";
                        break;
                    case 12:
                    case 13:
                    case 14:
                        numberString = Math.Round((d / 1e12m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+12";
                        break;
                    case 15:
                    case 16:
                    case 17:
                        numberString = Math.Round((d / 1e15m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+15";
                        break;
                    case 18:
                    case 19:
                    case 20:
                        numberString = Math.Round((d / 1e18m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+18";
                        break;
                    case 21:
                    case 22:
                    case 23:
                        numberString = Math.Round((d / 1e21m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+21";
                        break;
                    default:
                        numberString = Math.Round((d / 1e24m), RoundingFactor).ToString("000.000") + "";
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
                        numberString = Math.Round((d * 1e3m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-03";
                        break;
                    case -4:
                    case -5:
                    case -6:
                        numberString = Math.Round((d * 1e6m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-06";
                        break;
                    case -7:
                    case -8:
                    case -9:
                        numberString = Math.Round((d * 1e9m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-09";
                        break;
                    case -10:
                    case -11:
                    case -12:
                        numberString = Math.Round((d * 1e12m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-12";
                        break;
                    case -13:
                    case -14:
                    case -15:
                        numberString = Math.Round((d * 1e15m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-15";
                        break;
                    case -16:
                    case -17:
                    case -18:
                        numberString = Math.Round((d * 1e18m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-18";
                        break;
                    case -19:
                    case -20:
                    case -21:
                        numberString = Math.Round((d * 1e21m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-21";
                        break;
                    default:
                        numberString = Math.Round((d * 1e24m), RoundingFactor).ToString("000.000") + "";
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
                string combinedNumber = textBlock_Sign.Text +
                textBlock_Hundred.Text +
                textBlock_Ten.Text +
                textBlock_One.Text +
                textBlock_DecimalPoint.Text +
                textBlock_Tenth.Text +
                textBlock_Hundredth.Text +
                textBlock_Thousandth.Text + "e" +
                textBlock_ExponentSign.Text +
                textBlock_ExpTen.Text +
                textBlock_ExpOne.Text;

                newValue = decimal.Parse(combinedNumber, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign);
                ShowValue(newValue);
            }
            catch
            {
                ShowValue(0);
            }
        }

        private void AdjustValue(decimal Ammount)
        {
            double currentExponent = double.Parse(textBlock_ExponentSign.Text + textBlock_ExpTen.Text + textBlock_ExpOne.Text);

            if (currentExponent == 0)
            {
                newValue = newValue + Ammount;
            }
            else
            {
                if (newValue < 0)
                {
                    newValue = newValue - (Ammount * (decimal)Math.Pow(10, currentExponent));
                }
                else
                {
                    newValue = newValue + (Ammount * (decimal)Math.Pow(10, currentExponent));
                }
                
            }

            ShowValue(newValue);
            //ParseDisplay();
        }

        #region Enter Button

        private void button_Enter_Click(object sender, RoutedEventArgs e)
        {
            Options.LastNumericalInput = newValue;
            ValueChanged?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Keyboard Keys

        private void textBox_TextInput_KeyDown(object sender, KeyRoutedEventArgs e)
        {



        }

        private void textBox_TextInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                if (e.Key.ToString() == "Enter")
                {
                    newValue = decimal.Parse(textBox_TextInput.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent | NumberStyles.AllowLeadingSign);
                    ShowValue(newValue);
                    oldString = textBox_TextInput.Text;
                    Options.LastNumericalInput = newValue;
                    ValueChanged?.Invoke(this, new EventArgs());
                }
            }
            catch
            {
                textBox_TextInput.Text = oldString;
            }
        }

        #endregion

        #region Lock

        private void button_Lock_Click(object sender, RoutedEventArgs e)
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

        private void button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            //if (textBlock_Sign.Text == "+")
            //{
            //    textBlock_Sign.Text = "-";
            //}
            //else
            //{
            //    textBlock_Sign.Text = "+";
            //}
            textBlock_Sign.Text = "+";
            ParseDisplay();
        }

        private void button_SignDown_Click(object sender, RoutedEventArgs e)
        {
            //if (textBlock_Sign.Text == "+")
            //{
            //    textBlock_Sign.Text = "-";
            //}
            //else
            //{
            //    textBlock_Sign.Text = "+";
            //}
            textBlock_Sign.Text = "-";
            ParseDisplay();
        }


        #endregion

        #region Hundred

        private void button_HundredUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(100);

            //switch (textBlock_Hundred.Text)
            //{
            //    case "0":
            //        textBlock_Hundred.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_Hundred.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_Hundred.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_Hundred.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_Hundred.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_Hundred.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_Hundred.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_Hundred.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_Hundred.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_Hundred.Text = "0";
            //        break;
            //}
            //ParseDisplay();
        }

        private void button_HundredDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-100);

            //switch (textBlock_Hundred.Text)
            //{
            //    case "0":
            //        textBlock_Hundred.Text = "9";
            //        break;
            //    case "1":
            //        textBlock_Hundred.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_Hundred.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_Hundred.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_Hundred.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_Hundred.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_Hundred.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_Hundred.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_Hundred.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_Hundred.Text = "8";
            //        break;
            //}
            //ParseDisplay();
        }

        #endregion

        #region Ten

        private void button_TenUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(10);

            //switch (textBlock_Ten.Text)
            //{
            //    case "0":
            //        textBlock_Ten.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_Ten.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_Ten.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_Ten.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_Ten.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_Ten.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_Ten.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_Ten.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_Ten.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_Ten.Text = "0";
            //        break;
            //}
            //ParseDisplay();
        }

        private void button_TenDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-10);

            //switch (textBlock_Ten.Text)
            //{
            //    case "0":
            //        textBlock_Ten.Text = "9";
            //        break;
            //    case "1":
            //        textBlock_Ten.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_Ten.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_Ten.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_Ten.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_Ten.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_Ten.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_Ten.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_Ten.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_Ten.Text = "8";
            //        break;
            //}
            //ParseDisplay();
        }

        #endregion

        #region One

        private void button_OneUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(1);

            //switch (textBlock_One.Text)
            //{
            //    case "0":
            //        textBlock_One.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_One.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_One.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_One.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_One.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_One.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_One.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_One.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_One.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_One.Text = "0";
            //        break;
            //}
            //ParseDisplay();
        }

        private void button_OneDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-1);

            //switch (textBlock_One.Text)
            //{
            //    case "0":
            //        textBlock_One.Text = "9";
            //        break;
            //    case "1":
            //        textBlock_One.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_One.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_One.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_One.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_One.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_One.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_One.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_One.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_One.Text = "8";
            //        break;
            //}
            //ParseDisplay();
        }

        #endregion

        #region Tenth

        private void button_TenthUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(0.1m);

            //switch (textBlock_Tenth.Text)
            //{
            //    case "0":
            //        textBlock_Tenth.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_Tenth.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_Tenth.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_Tenth.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_Tenth.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_Tenth.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_Tenth.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_Tenth.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_Tenth.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_Tenth.Text = "0";
            //        break;
            //}
            //ParseDisplay();
        }

        private void button_TenthDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-0.1m);

            //switch (textBlock_Tenth.Text)
            //{
            //    case "0":
            //        textBlock_Tenth.Text = "9";
            //        break;
            //    case "1":
            //        textBlock_Tenth.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_Tenth.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_Tenth.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_Tenth.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_Tenth.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_Tenth.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_Tenth.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_Tenth.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_Tenth.Text = "8";
            //        break;
            //}
            //ParseDisplay();
        }

        #endregion

        #region Hundredth

        private void button_HundredthUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(0.01m);

            //switch (textBlock_Hundredth.Text)
            //{
            //    case "0":
            //        textBlock_Hundredth.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_Hundredth.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_Hundredth.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_Hundredth.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_Hundredth.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_Hundredth.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_Hundredth.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_Hundredth.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_Hundredth.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_Hundredth.Text = "0";
            //        break;
            //}
            //ParseDisplay();
        }

        private void button_HundredthDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-0.01m);

            //switch (textBlock_Hundredth.Text)
            //{
            //    case "0":
            //        textBlock_Hundredth.Text = "9";
            //        break;
            //    case "1":
            //        textBlock_Hundredth.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_Hundredth.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_Hundredth.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_Hundredth.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_Hundredth.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_Hundredth.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_Hundredth.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_Hundredth.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_Hundredth.Text = "8";
            //        break;
            //}
            //ParseDisplay();
        }

        #endregion

        #region Thousandth

        private void button_ThousandthUp_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(0.001m);

            //switch (textBlock_Thousandth.Text)
            //{
            //    case "0":
            //        textBlock_Thousandth.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_Thousandth.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_Thousandth.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_Thousandth.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_Thousandth.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_Thousandth.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_Thousandth.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_Thousandth.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_Thousandth.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_Thousandth.Text = "0";
            //        break;
            //}
            //ParseDisplay();
        }

        private void button_ThousandthDown_Click(object sender, RoutedEventArgs e)
        {
            AdjustValue(-0.001m);

            //switch (textBlock_Thousandth.Text)
            //{
            //    case "0":
            //        textBlock_Thousandth.Text = "9";
            //        break;
            //    case "1":
            //        textBlock_Thousandth.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_Thousandth.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_Thousandth.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_Thousandth.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_Thousandth.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_Thousandth.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_Thousandth.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_Thousandth.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_Thousandth.Text = "8";
            //        break;
            //}
            //ParseDisplay();
        }

        #endregion

        #region Exponent Sign

        private void button_ExponentSignUp_Click(object sender, RoutedEventArgs e)
        {
            //if (textBlock_ExponentSign.Text == "+")
            //{
            //    textBlock_ExponentSign.Text = "-";
            //}
            //else
            //{
            //    textBlock_ExponentSign.Text = "+";
            //}
            textBlock_ExponentSign.Text = "+";
            ParseDisplay();
        }

        private void button_SignExponentSignDown_Click(object sender, RoutedEventArgs e)
        {
            //if (textBlock_ExponentSign.Text == "+")
            //{
            //    textBlock_ExponentSign.Text = "-";
            //}
            //else
            //{
            //    textBlock_ExponentSign.Text = "+";
            //}
            textBlock_ExponentSign.Text = "-";
            ParseDisplay();
        }

        #endregion

        #region ExpTen

        private void button_ExpTenUp_Click(object sender, RoutedEventArgs e)
        {
            //switch (textBlock_ExpTen.Text)
            //{
            //    case "0":
            //        textBlock_ExpTen.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_ExpTen.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_ExpTen.Text = "0";
            //        break;
            //}
            //ParseDisplay();


            newValue = newValue * 10000000000;
            ShowValue(newValue);
        }

        private void button_ExpTenDown_Click(object sender, RoutedEventArgs e)
        {
            //switch (textBlock_ExpTen.Text)
            //{
            //    case "0":
            //        textBlock_ExpTen.Text = "2";
            //        break;
            //    case "1":
            //        textBlock_ExpTen.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_ExpTen.Text = "1";
            //        break;
            //}
            //ParseDisplay();

            newValue = newValue / 10000000000;
            ShowValue(newValue);
        }

        #endregion

        #region ExpOne

        private void button_ExpOneUp_Click(object sender, RoutedEventArgs e)
        {
            //switch (textBlock_ExpOne.Text)
            //{
            //    case "0":
            //        textBlock_ExpOne.Text = "1";
            //        break;
            //    case "1":
            //        textBlock_ExpOne.Text = "2";
            //        break;
            //    case "2":
            //        textBlock_ExpOne.Text = "3";
            //        break;
            //    case "3":
            //        textBlock_ExpOne.Text = "4";
            //        break;
            //    case "4":
            //        textBlock_ExpOne.Text = "5";
            //        break;
            //    case "5":
            //        textBlock_ExpOne.Text = "6";
            //        break;
            //    case "6":
            //        textBlock_ExpOne.Text = "7";
            //        break;
            //    case "7":
            //        textBlock_ExpOne.Text = "8";
            //        break;
            //    case "8":
            //        textBlock_ExpOne.Text = "9";
            //        break;
            //    case "9":
            //        textBlock_ExpOne.Text = "0";
            //        switch (textBlock_ExpTen.Text)
            //        {
            //            case "0":
            //                textBlock_ExpTen.Text = "1";
            //                break;

            //            case "1":
            //                textBlock_ExpTen.Text = "2";
            //                break;

            //            case "2":
            //                ShowValue(0);
            //                break;

            //            default:
            //                ShowValue(0);
            //                break;
            //        }
            //        break;
            //}
            newValue = newValue * 10;
            ShowValue(newValue);
            //ParseDisplay();
        }

        private void button_ExpOneDown_Click(object sender, RoutedEventArgs e)
        {
            //switch (textBlock_ExpOne.Text)
            //{
            //    case "0":
            //        textBlock_ExpOne.Text = "9";
            //        switch (textBlock_ExpTen.Text)
            //        {
            //            case "0":
            //                textBlock_ExpTen.Text = "0";
            //                break;

            //            case "1":
            //                textBlock_ExpTen.Text = "0";
            //                break;

            //            case "2":
            //                textBlock_ExpTen.Text = "1";
            //                break;

            //            default:
            //                ShowValue(0);
            //                break;
            //        }
            //        break;
            //    case "1":
            //        textBlock_ExpOne.Text = "0";
            //        break;
            //    case "2":
            //        textBlock_ExpOne.Text = "1";
            //        break;
            //    case "3":
            //        textBlock_ExpOne.Text = "2";
            //        break;
            //    case "4":
            //        textBlock_ExpOne.Text = "3";
            //        break;
            //    case "5":
            //        textBlock_ExpOne.Text = "4";
            //        break;
            //    case "6":
            //        textBlock_ExpOne.Text = "5";
            //        break;
            //    case "7":
            //        textBlock_ExpOne.Text = "6";
            //        break;
            //    case "8":
            //        textBlock_ExpOne.Text = "7";
            //        break;
            //    case "9":
            //        textBlock_ExpOne.Text = "8";
            //        break;
            //}

            newValue = newValue / 10;
            ShowValue(newValue);

            //ParseDisplay();
        }


        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowValue(0);
        }
    }
}
