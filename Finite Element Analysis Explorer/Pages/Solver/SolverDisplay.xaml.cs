namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// SolverDisplay Page contains the solver stage display.
    /// </summary>
    public sealed partial class SolverDisplay : Page
    {
        /// <summary>
        /// Gets or sets Clayton's singleton.
        /// </summary>
        internal static SolverDisplay Current { get => current; set => current = value; }

        private static SolverDisplay current;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolverDisplay"/> class.
        /// </summary>
        public SolverDisplay()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            AddMessage(-1, -1, "Solver State", 0);
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Clears the messages from the display.
        /// </summary>
        public void ClearMessages()
        {
            StackConsole.Children.Clear();
            progressBar_Track.Value = 0;
        }

        /// <summary>
        /// Adds a message to the display.
        /// </summary>
        /// <param name="total">The total time the solver has taken.</param>
        /// <param name="step">The time this step has taken.</param>
        /// <param name="message">The message to display.</param>
        /// <param name="messageType">The message type. The color to display.</param>
        public void AddMessage(long total, long step, string message, int messageType)
        {
            SolverMessage nextMessage = new SolverMessage
            {
                TotalTime = total,
                StepTime = step,
                Message = message,
                MessageType = messageType,
            };

            StackConsole.Children.Add(nextMessage);

            if (messageType == 0)
            {
                progressBar_Track.Value++;
            }

            scrollViewer_Console.UpdateLayout();
            scrollViewer_Console.ChangeView(0.0f, double.MaxValue, 1.0f);
        }
    }
}