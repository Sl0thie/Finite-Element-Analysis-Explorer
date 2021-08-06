namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// SolverMessage UserControl used to display messages from the solver.
    /// </summary>
    public sealed partial class SolverMessage : UserControl
    {
        /// <summary>
        /// Gets or sets the total time the solver has taken up to this point.
        /// </summary>
        public long TotalTime
        {
            get
            {
                return totalTime;
            }

            set
            {
                totalTime = value;
                TextBlock_TotalTime.Text = MakeString(totalTime);
            }
        }

        /// <summary>
        /// Gets or sets the time it has taken to perform this step.
        /// </summary>
        public long StepTime
        {
            get
            {
                return stepTime;
            }

            set
            {
                stepTime = value;
                TextBlock_StepTime.Text = MakeString(stepTime);
            }
        }

        /// <summary>
        /// Gets or sets the message to display.
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
                TextBlock_Message.Text = message;
            }
        }

        /// <summary>
        /// Gets or sets the icon to use for the message.
        /// </summary>
        public int Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        /// <summary>
        /// Gets or sets the message type to use for the message.
        /// </summary>
        public int MessageType
        {
            get
            {
                return messageType;
            }

            set
            {
                messageType = value;
                switch (messageType)
                {
                    case 0:
                        TextBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 192, 192, 192));
                        break;

                    case 1:
                        TextBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 128, 128, 128));
                        break;

                    case 2:
                        TextBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 32, 32));
                        break;

                    case 3:
                        TextBlock_Message.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 32));
                        break;
                }
            }
        }

        private long totalTime;
        private long stepTime;
        private string message;
        private int icon;
        private int messageType;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolverMessage"/> class.
        /// </summary>
        public SolverMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Makes a time string.
        /// </summary>
        /// <param name="totalMilliseconds">The length of the time string in milliseconds.</param>
        /// <returns>A human readable string of time.</returns>
        private string MakeString(long totalMilliseconds)
        {
            if (totalMilliseconds >= 0)
            {
                long milliseconds = totalMilliseconds;
                long totalMinutes = 0;
                long totalSeconds = 0;

                do
                {
                    if (milliseconds > 60000)
                    {
                        totalMinutes++;
                        milliseconds -= 60000;
                    }
                }
                while (milliseconds >= 60000);

                string tempString = totalMinutes + ":";
                do
                {
                    if (milliseconds >= 1000)
                    {
                        totalSeconds++;
                        milliseconds -= 1000;
                    }
                }
                while (milliseconds >= 1000);

                if (totalSeconds < 10)
                {
                    tempString = tempString + "0" + totalSeconds + ":";
                }
                else
                {
                    tempString = tempString + totalSeconds + ":";
                }

                if (milliseconds.ToString().Length == 0)
                {
                    tempString += "000";
                }
                else if (milliseconds.ToString().Length == 1)
                {
                    tempString = tempString + "00" + milliseconds;
                }
                else if (milliseconds.ToString().Length == 2)
                {
                    tempString = tempString + "0" + milliseconds;
                }
                else
                {
                    tempString += milliseconds;
                }

                return tempString;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}