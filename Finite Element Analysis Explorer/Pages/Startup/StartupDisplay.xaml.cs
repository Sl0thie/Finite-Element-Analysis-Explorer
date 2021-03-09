using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class StartupDisplay : Page
    {
        internal static StartupDisplay Current;
        //private bool IsLoaded = false;

        public StartupDisplay()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("StartupDisplay Loaded");
            Current = this;
            //IsLoaded = true;

            Task.Run(() => ProcessAsync());
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("StartupDisplay Unloaded");
            //IsLoaded = false;
        }

        private async Task ProcessAsync()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    AddItem("Loading Materials.");
                }
                );

            int numberOfMaterials = FileManager.LoadMaterialsAsync();

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    AddItem(numberOfMaterials.ToString() + " Materials loaded.");
                }
                );

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    AddItem("Loading Sections.");
                }
                );

            int numberOfSections = await FileManager.LoadSectionsAsync();

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    AddItem(numberOfSections.ToString() + " Sections loaded.");
                }
                );

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
                    if (Options.LoadLastFileOnStartup)
                    {
                        FileManager.LoadLastFileAsync();
                    }
                    else
                    {
                        Frame rootFrame2 = Window.Current.Content as Frame;
                        rootFrame2.Navigate(typeof(Construction));
                    }
                }
                );

            try
            {

            }
            catch (Exception ex) { Debug.WriteLine("StartupDisplay Error: " + ex.Message); }
        }

        public async void AddItem(string message)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                    () =>
                    {
                        StartupStackPanelItem tempItem = new StartupStackPanelItem(message);
                        StartupDisplay.Current.StackPanelStartup.Children.Add(tempItem);
                    }
                    );
        }
    }
}
