using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class FileLoadingDisplay : Page
    {
        internal static FileLoadingDisplay Current;

        // private bool IsLoaded = false;
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
