﻿using System;
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
    /// <summary>
    /// NumericInput UserControl provides a numerical input that is base around engineer's notation.
    /// </summary>
    public sealed partial class NumericInput : UserControl
    {
        /// <summary>
        /// Handles the value changed event.
        /// </summary>
        public event EventHandler ValueChanged;

        private readonly int roundingFactor = 6;
        private decimal theValue = 0;
        private string numberString = string.Empty;
        private string exponentString = string.Empty;

        private string blockSign = string.Empty;
        private string blockHundred = string.Empty;
        private string blockTen = string.Empty;
        private string blockOne = string.Empty;
        private string blockDecimal = string.Empty;
        private string blockTenth = string.Empty;
        private string blockHundredth = string.Empty;
        private string blockThousandth = string.Empty;
        private string blockE = string.Empty;
        private string blockESign = string.Empty;
        private string blockETen = string.Empty;
        private string blockEOne = string.Empty;

        private decimal newValue;

        public decimal NewValue
        {
            get
            {
                return newValue;
            }

            set
            {
                newValue = value;
            }
        }

        private bool displayOnly = false;

        public bool DisplayOnly
        {
            get
            {
                return displayOnly;
            }

            set
            {
                displayOnly = value;
            }
        }

        private bool isInteger;

        public bool IsInteger
        {
            get
            {
                return isInteger;
            }

            set
            {
                isInteger = value;
            }
        }

        public NumericInput()
        {
            this.InitializeComponent();

            textBlock_Sign.Text = string.Empty;
            textBlock_Hundred.Text = string.Empty;
            textBlock_Ten.Text = string.Empty;
            textBlock_One.Text = string.Empty;
            textBlock_Decimal.Text = string.Empty;
            textBlock_Tenth.Text = string.Empty;
            textBlock_Hundredth.Text = string.Empty;
            textBlock_Thousandth.Text = string.Empty;
            textBlock_E.Text = string.Empty;
            textBlock_ESign.Text = string.Empty;
            textBlock_ETen.Text = string.Empty;
            textBlock_EOne.Text = string.Empty;
        }

        public void SetNull()
        {
            textBlock_Sign.Text = string.Empty;
            textBlock_Hundred.Text = string.Empty;
            textBlock_Ten.Text = string.Empty;
            textBlock_One.Text = string.Empty;
            textBlock_Decimal.Text = string.Empty;
            textBlock_Tenth.Text = string.Empty;
            textBlock_Hundredth.Text = string.Empty;
            textBlock_Thousandth.Text = string.Empty;
            textBlock_E.Text = string.Empty;
            textBlock_ESign.Text = string.Empty;
            textBlock_ETen.Text = string.Empty;
            textBlock_EOne.Text = string.Empty;
        }

        internal void SetValue(decimal newValue)
        {
            theValue = newValue;
            this.newValue = newValue;

            // Clear previous
            textBlock_Sign.Text = string.Empty;
            textBlock_Hundred.Text = string.Empty;
            textBlock_Ten.Text = string.Empty;
            textBlock_One.Text = string.Empty;
            textBlock_Decimal.Text = string.Empty;
            textBlock_Tenth.Text = string.Empty;
            textBlock_Hundredth.Text = string.Empty;
            textBlock_Thousandth.Text = string.Empty;
            textBlock_E.Text = string.Empty;
            textBlock_ESign.Text = string.Empty;
            textBlock_ETen.Text = string.Empty;
            textBlock_EOne.Text = string.Empty;

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

            // Handle negative numbers.
            if (theValue < 0)
            {
                blockSign = "-";
                theValue = Math.Abs(theValue);
            }
            else
            {
                blockSign = string.Empty;
            }

            ConvertToEngineeringNotation(theValue);

            blockHundred = numberString.Substring(0, 1);
            blockTen = numberString.Substring(1, 1);
            blockOne = numberString.Substring(2, 1);
            blockDecimal = numberString.Substring(3, 1);
            blockTenth = numberString.Substring(4, 1);
            blockHundredth = numberString.Substring(5, 1);
            blockThousandth = numberString.Substring(6, 1);

            if (!string.IsNullOrEmpty(exponentString))
            {
                blockE = exponentString.Substring(0, 1);
                blockESign = exponentString.Substring(1, 1);
                blockETen = exponentString.Substring(2, 1);
                blockEOne = exponentString.Substring(3, 1);
            }

            if (isInteger)
            {
                if (blockSign == "-")
                {
                    theValue = (int)theValue;
                    ProcessNegativeInteger();
                    return;
                }
                else
                {
                    theValue = (int)theValue;
                    ProcessPositiveInteger();
                    return;
                }
            }
            else
            {
                if (blockSign == "-")
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
            textBlock_Sign.Text = string.Empty;
            textBlock_Hundred.Text = blockHundred;
            textBlock_Ten.Text = blockTen;
            textBlock_One.Text = blockOne;
            textBlock_Decimal.Text = blockDecimal;
            textBlock_Tenth.Text = blockTenth;
            textBlock_Hundredth.Text = blockHundredth;
            textBlock_Thousandth.Text = blockThousandth;

            if (!string.IsNullOrEmpty(exponentString))
            {
                textBlock_E.Text = blockE;
                textBlock_ESign.Text = blockESign;
                textBlock_ETen.Text = blockETen;
                textBlock_EOne.Text = blockEOne;
            }

            if (blockHundred == "0")
            {
                textBlock_Hundred.Text = string.Empty;
                if (blockTen == "0")
                {
                    textBlock_Ten.Text = string.Empty;
                }
            }

            if (blockThousandth == "0")
            {
                textBlock_Thousandth.Text = string.Empty;
                if (blockHundredth == "0")
                {
                    textBlock_Hundredth.Text = string.Empty;
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
            textBlock_Hundred.Text = blockHundred;
            textBlock_Ten.Text = blockTen;
            textBlock_One.Text = blockOne;
            textBlock_Decimal.Text = blockDecimal;
            textBlock_Tenth.Text = blockTenth;
            textBlock_Hundredth.Text = blockHundredth;
            textBlock_Thousandth.Text = blockThousandth;

            if (!string.IsNullOrEmpty(exponentString))
            {
                textBlock_E.Text = blockE;
                textBlock_ESign.Text = blockESign;
                textBlock_ETen.Text = blockETen;
                textBlock_EOne.Text = blockEOne;
            }

            if (blockHundred == "0")
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = "-";
                if (blockTen == "0")
                {
                    textBlock_Sign.Text = string.Empty;
                    textBlock_Hundred.Text = string.Empty;
                    textBlock_Ten.Text = "-";
                }
            }

            if (blockThousandth == "0")
            {
                textBlock_Thousandth.Text = string.Empty;
                if (blockHundredth == "0")
                {
                    textBlock_Hundredth.Text = string.Empty;
                }
            }
        }

        private void ProcessPositiveInteger()
        {
            if (theValue > 999999)
            {
                // Needs exp.
            }
            else if (theValue > 99999)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = theValue.ToString().Substring(0, 1);
                textBlock_Ten.Text = theValue.ToString().Substring(1, 1);
                textBlock_One.Text = theValue.ToString().Substring(2, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(4, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(5, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 9999)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = theValue.ToString().Substring(0, 1);
                textBlock_One.Text = theValue.ToString().Substring(1, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(4, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 999)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = theValue.ToString().Substring(0, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(3, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 99)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = string.Empty;
                textBlock_Decimal.Text = string.Empty;
                textBlock_Tenth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(2, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 9)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = string.Empty;
                textBlock_Decimal.Text = string.Empty;
                textBlock_Tenth.Text = string.Empty;
                textBlock_Hundredth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(1, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = string.Empty;
                textBlock_Decimal.Text = string.Empty;
                textBlock_Tenth.Text = string.Empty;
                textBlock_Hundredth.Text = string.Empty;
                textBlock_Thousandth.Text = theValue.ToString().Substring(0, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
        }

        private void ProcessNegativeInteger()
        {
            if (theValue > 999999)
            {
                // Needs exp.
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
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 9999)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = "-";
                textBlock_Ten.Text = theValue.ToString().Substring(0, 1);
                textBlock_One.Text = theValue.ToString().Substring(1, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(3, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(4, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 999)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = "-";
                textBlock_One.Text = theValue.ToString().Substring(0, 1);
                textBlock_Decimal.Text = ",";
                textBlock_Tenth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(2, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(3, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 99)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = string.Empty;
                textBlock_Decimal.Text = "-";
                textBlock_Tenth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Hundredth.Text = theValue.ToString().Substring(1, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(2, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else if (theValue > 9)
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = string.Empty;
                textBlock_Decimal.Text = string.Empty;
                textBlock_Tenth.Text = "-";
                textBlock_Hundredth.Text = theValue.ToString().Substring(0, 1);
                textBlock_Thousandth.Text = theValue.ToString().Substring(1, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
            }
            else
            {
                textBlock_Sign.Text = string.Empty;
                textBlock_Hundred.Text = string.Empty;
                textBlock_Ten.Text = string.Empty;
                textBlock_One.Text = string.Empty;
                textBlock_Decimal.Text = string.Empty;
                textBlock_Tenth.Text = string.Empty;
                textBlock_Hundredth.Text = "-";
                textBlock_Thousandth.Text = theValue.ToString().Substring(0, 1);
                textBlock_E.Text = string.Empty;
                textBlock_ESign.Text = string.Empty;
                textBlock_ETen.Text = string.Empty;
                textBlock_EOne.Text = string.Empty;
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
                        numberString = Math.Round(d, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = string.Empty;
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = "e+03";
                        }
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
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = string.Empty;
                        }
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
                exponentString = string.Empty;
            }
        }


        #region Pop-up Events

        private void TextBlock_One_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Ten_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Hundred_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Sign_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Decimal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tenth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Hundredth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Thousandth_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void TextBlock_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        private void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_One);
                TextBox_Input.SetTheValue(theValue);
            }
        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TextBox_Input_ValueChanged(object sender, EventArgs e)
        {
            newValue = TextBox_Input.NewValue;
            flyOut_Shared.Hide();
            ValueChanged?.Invoke(this, new EventArgs());
        }
    }
}