using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class NumericInput : UserControl
    {
        public event EventHandler ValueChanged;

        private int RoundingFactor = 6;
        private decimal theValue = 0;
        private string numberString = "";
        private string exponentString = "";

        private string block_Sign = "";
        private string block_Hundred = "";
        private string block_Ten = "";
        private string block_One = "";
        private string block_Decimal = "";
        private string block_Tenth = "";
        private string block_Hundredth = "";
        private string block_Thousandth = "";
        private string block_E = "";
        private string block_ESign = "";
        private string block_ETen = "";
        private string block_EOne = "";

        private decimal newValue;
        public decimal NewValue
        {
            get { return newValue; }
            set { newValue = value; }
        }

        private bool displayOnly = false;
        public bool DisplayOnly
        {
            get { return displayOnly; }
            set { displayOnly = value; }
        }

        private bool isInteger;
        public bool IsInteger
        {
            get { return isInteger; }
            set { isInteger = value; }
        }

        public NumericInput()
        {
            this.InitializeComponent();

            textBlock_Sign.Text = "";
            textBlock_Hundred.Text = "";
            textBlock_Ten.Text = "";
            textBlock_One.Text = "";
            textBlock_Decimal.Text = "";
            textBlock_Tenth.Text = "";
            textBlock_Hundredth.Text = "";
            textBlock_Thousandth.Text = "";
            textBlock_E.Text = "";
            textBlock_ESign.Text = "";
            textBlock_ETen.Text = "";
            textBlock_EOne.Text = "";

        }

        public void SetNull()
        {
            textBlock_Sign.Text = "";
            textBlock_Hundred.Text = "";
            textBlock_Ten.Text = "";
            textBlock_One.Text = "";
            textBlock_Decimal.Text = "";
            textBlock_Tenth.Text = "";
            textBlock_Hundredth.Text = "";
            textBlock_Thousandth.Text = "";
            textBlock_E.Text = "";
            textBlock_ESign.Text = "";
            textBlock_ETen.Text = "";
            textBlock_EOne.Text = "";
        }

        internal void SetValue(decimal _newValue)
        {
            theValue = _newValue;
            newValue = _newValue;

            //Clear previous
            textBlock_Sign.Text = "";
            textBlock_Hundred.Text = "";
            textBlock_Ten.Text = "";
            textBlock_One.Text = "";
            textBlock_Decimal.Text = "";
            textBlock_Tenth.Text = "";
            textBlock_Hundredth.Text = "";
            textBlock_Thousandth.Text = "";
            textBlock_E.Text = "";
            textBlock_ESign.Text = "";
            textBlock_ETen.Text = "";
            textBlock_EOne.Text = "";

            textBlock_Sign.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Hundred.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Ten.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_One.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Decimal.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Tenth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Hundredth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));
            textBlock_Thousandth.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 148, 255));

            if (displayOnly)
            {
                if (DMath.Abs(theValue) < 0.000001m) { theValue = 0; }
            }

            //handle negative numbers.
            if (theValue < 0)
            {
                block_Sign = "-";
                theValue = Math.Abs(theValue);
            }
            else
            {
                block_Sign = "";
            }

            ConvertToEngineeringNotation(theValue);

            block_Hundred = numberString.Substring(0, 1);
            block_Ten = numberString.Substring(1, 1);
            block_One = numberString.Substring(2, 1);
            block_Decimal = numberString.Substring(3, 1);
            block_Tenth = numberString.Substring(4, 1);
            block_Hundredth = numberString.Substring(5, 1);
            block_Thousandth = numberString.Substring(6, 1);

            if (!String.IsNullOrEmpty(exponentString))
            {
                block_E = exponentString.Substring(0, 1);
                block_ESign = exponentString.Substring(1, 1);
                block_ETen = exponentString.Substring(2, 1);
                block_EOne = exponentString.Substring(3, 1);
            }



            if (isInteger)
            {
                if (block_Sign == "-")
                {
                    theValue = (int)theValue;
                    ProcessNegativeInteger(); return;
                }
                else
                {
                    theValue = (int)theValue;
                    ProcessPositiveInteger(); return;
                }

            }
            else
            {
                if (block_Sign == "-")
                {
                    ProcessNegativeDecimal();
                }
                else
                {
                    ProcessPositiveDecimal();
                }
            }
        }

        private void ProcessPositiveDecimal()
        {

            textBlock_Sign.Text = "";
            textBlock_Hundred.Text = block_Hundred;
            textBlock_Ten.Text = block_Ten;
            textBlock_One.Text = block_One;
            textBlock_Decimal.Text = block_Decimal;
            textBlock_Tenth.Text = block_Tenth;
            textBlock_Hundredth.Text = block_Hundredth;
            textBlock_Thousandth.Text = block_Thousandth;
            if (!String.IsNullOrEmpty(exponentString))
            {
                textBlock_E.Text = block_E;
                textBlock_ESign.Text = block_ESign;
                textBlock_ETen.Text = block_ETen;
                textBlock_EOne.Text = block_EOne;
            }

            if (block_Hundred == "0")
            {
                textBlock_Hundred.Text = "";
                if (block_Ten == "0")
                {
                    textBlock_Ten.Text = "";
                }
            }

            if (block_Thousandth == "0")
            {
                textBlock_Thousandth.Text = "";
                if (block_Hundredth == "0")
                {
                    textBlock_Hundredth.Text = "";
                }
            }


            if (theValue == 0)
            {
                textBlock_One.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 32, 255));
                textBlock_Decimal.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 32, 255));
                textBlock_Tenth.Foreground = new SolidColorBrush(Color.FromArgb(255, 32, 32, 255));
            }

        }

        private void ProcessNegativeDecimal()
        {

            textBlock_Sign.Text = "-";
            textBlock_Hundred.Text = block_Hundred;
            textBlock_Ten.Text = block_Ten;
            textBlock_One.Text = block_One;
            textBlock_Decimal.Text = block_Decimal;
            textBlock_Tenth.Text = block_Tenth;
            textBlock_Hundredth.Text = block_Hundredth;
            textBlock_Thousandth.Text = block_Thousandth;
            if (!String.IsNullOrEmpty(exponentString))
            {
                textBlock_E.Text = block_E;
                textBlock_ESign.Text = block_ESign;
                textBlock_ETen.Text = block_ETen;
                textBlock_EOne.Text = block_EOne;
            }


            if (block_Hundred == "0")
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "-";
                if (block_Ten == "0")
                {
                    textBlock_Sign.Text = "";
                    textBlock_Hundred.Text = "";
                    textBlock_Ten.Text = "-";
                }
            }

            if (block_Thousandth == "0")
            {
                textBlock_Thousandth.Text = "";
                if (block_Hundredth == "0")
                {
                    textBlock_Hundredth.Text = "";
                }
            }

        }

        private void ProcessPositiveInteger()
        {
            if (theValue > 999999)
            {
                //Needs exp

            }
            else if (theValue > 99999)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = theValue.ToString().Substring(0, 1);
                textBlock_Ten.Text = theValue.ToString().Substring(1, 1);
                textBlock_One.Text = theValue.ToString().Substring(2, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(4, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(5, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 9999)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = theValue.ToString().Substring(0, 1);
                textBlock_One.Text = theValue.ToString().Substring(1, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(4, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 999)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = theValue.ToString().Substring(0, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(3, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 99)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = "";
                textBlock_Decimal.Text = "";
                textBlock_Tenth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(2, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 9)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = "";
                textBlock_Decimal.Text = "";
                textBlock_Tenth.Text = "";
                textBlock_Hundredth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(1, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = "";
                textBlock_Decimal.Text = "";
                textBlock_Tenth.Text = "";
                textBlock_Hundredth.Text = "";
                textBlock_Thousandth.Text = theValue.ToString().Substring(0, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
        }

        private void ProcessNegativeInteger()
        {
            if (theValue > 999999)
            {
                //Needs exp

            }
            else if (theValue > 99999)
            {
                textBlock_Sign.Text = "-";
                textBlock_Hundred.Text = theValue.ToString().Substring(0, 1);
                textBlock_Ten.Text = theValue.ToString().Substring(1, 1);
                textBlock_One.Text = theValue.ToString().Substring(2, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(4, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(5, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 9999)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "-";
                textBlock_Ten.Text = theValue.ToString().Substring(0, 1);
                textBlock_One.Text = theValue.ToString().Substring(1, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(4, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 999)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "-";
                textBlock_One.Text = theValue.ToString().Substring(0, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(3, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 99)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = "";
                textBlock_Decimal.Text = "-";
                textBlock_Tenth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(2, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else if (theValue > 9)
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = "";
                textBlock_Decimal.Text = "";
                textBlock_Tenth.Text = "-";
                textBlock_Hundredth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(1, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
            else
            {
                textBlock_Sign.Text = "";
                textBlock_Hundred.Text = "";
                textBlock_Ten.Text = "";
                textBlock_One.Text = "";
                textBlock_Decimal.Text = "";
                textBlock_Tenth.Text = "";
                textBlock_Hundredth.Text = "-";
                textBlock_Thousandth.Text = theValue.ToString().Substring(0, 1);
                textBlock_E.Text = "";
                textBlock_ESign.Text = "";
                textBlock_ETen.Text = "";
                textBlock_EOne.Text = "";
            }
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
                        exponentString = "";
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = "e+03";
                        }
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
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = "";
                        }
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
                exponentString = "";
            }
        }


        #region Popup Events

        private void textBlock_One_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Ten_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Hundred_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Sign_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Decimal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Tenth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Hundredth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void textBlock_Thousandth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                textBox_Input.SetTheValue(theValue);
            }
        }

        #endregion    

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_Input_ValueChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine("New Input " + textBox_Input.Text);
            newValue = textBox_Input.NewValue;
            flyOut_Shared.Hide();
            ValueChanged?.Invoke(this, new EventArgs());


        }
    }
}
