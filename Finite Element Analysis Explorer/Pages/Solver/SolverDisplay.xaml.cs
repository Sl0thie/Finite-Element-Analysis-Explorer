using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class SolverDisplay : Page
    {
        internal static SolverDisplay Current;
        //private bool IsLoaded = false;

        public SolverDisplay()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;
            //IsLoaded = true;

            AddMessage(-1, -1, "Solver State", 0);



            //Task.Run(() => ProcessAsync());
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            //IsLoaded = false;
        }

        public void ClearMessages()
        {
            StackConsole.Children.Clear();
            progressBar_Track.Value = 0;
        }


        public void AddMessage(long total, long step, string message, int messageType)
        {

            SolverMessage NextMessage = new SolverMessage();
            NextMessage.TotalTime = total;
            NextMessage.StepTime = step;
            NextMessage.Message = message;
            NextMessage.MessageType = messageType;
            StackConsole.Children.Add(NextMessage);

            if (messageType == 0)
            {
                progressBar_Track.Value = progressBar_Track.Value + 1;
            }

            scrollViewer_Console.UpdateLayout();
            scrollViewer_Console.ChangeView(0.0f, double.MaxValue, 1.0f);


        }
    }
}
