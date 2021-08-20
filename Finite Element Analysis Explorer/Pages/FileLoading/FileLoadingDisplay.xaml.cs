using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// FileLoadingDisplay page.
    /// </summary>
    public sealed partial class FileLoadingDisplay : Page
    {
        /// <summary>
        /// Gets or sets the current file loading display page.
        /// </summary>
        internal static FileLoadingDisplay Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLoadingDisplay"/> class.
        /// </summary>
        public FileLoadingDisplay()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;

            // IsLoaded = true;
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            // IsLoaded = false;
        }

        /// <summary>
        /// Adds a message to the page.
        /// </summary>
        /// <param name="total">The total loading time.</param>
        /// <param name="step">The time for this step.</param>
        /// <param name="message">The message.</param>
        public void AddMessage(long total, long step, string message)
        {
            SolverMessage nextMessage = new SolverMessage
            {
                TotalTime = total,
                StepTime = step,
                Message = message,
            };
            StackConsole.Children.Add(nextMessage);
        }
    }
}