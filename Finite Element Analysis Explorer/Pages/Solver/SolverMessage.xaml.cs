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
    public sealed partial class SolverMessage : UserControl
    {
        private long _TotalTime;
        public long TotalTime
        {
            get { return _TotalTime; }
            set
            {
                _TotalTime = value;
                textBlock_TotalTime.Text = MakeString(_TotalTime);
            }
        }

        private long _StepTime;
        public long StepTime
        {
            get { return _StepTime; }
            set
            {
                _StepTime = value;
                textBlock_StepTime.Text = MakeString(_StepTime);
            }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                textBlock_Message.Text = _Message;
            }
        }

        private int _Icon;
        public int Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }


        private int messageType;
        public int MessageType
        {
            get { return messageType; }
            set
            {
                messageType = value;
                switch (messageType)
                {
                    case 0:
                        textBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 192, 192, 192));
                        break;

                    case 1:
                        textBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                        break;

                    case 2:
                        textBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 32, 32));
                        break;

                    case 3:
                        textBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 32));
                        break;
                }
            }
        }

        public SolverMessage()
        {
            InitializeComponent();
        }

        private string MakeString(long TotalMilliseconds)
        {
            if (TotalMilliseconds >= 0)
            {
                long Milliseconds = TotalMilliseconds;
                long TotalMinutes = 0;
                long TotalSeconds = 0;

                do
                {
                    if (Milliseconds > 60000)
                    {
                        TotalMinutes++;
                        Milliseconds -= 60000;
                    }
                } while (Milliseconds >= 60000);
                string tempString = TotalMinutes + ":";
                do
                {
                    if (Milliseconds >= 1000)
                    {
                        TotalSeconds++;
                        Milliseconds -= 1000;
                    }
                } while (Milliseconds >= 1000);

                if (TotalSeconds < 10)
                {
                    tempString = tempString + "0" + TotalSeconds + ":";
                }
                else
                {
                    tempString = tempString + TotalSeconds + ":";
                }

                if (Milliseconds.ToString().Length == 0)
                {
                    tempString += "000";
                }
                else if (Milliseconds.ToString().Length == 1)
                {
                    tempString = tempString + "00" + Milliseconds;
                }
                else if (Milliseconds.ToString().Length == 2)
                {
                    tempString = tempString + "0" + Milliseconds;
                }
                else
                {
                    tempString += Milliseconds;
                }

                return tempString;
            }
            else
            {
                return "";
            }
        }
    }
}
