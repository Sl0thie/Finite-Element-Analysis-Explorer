﻿namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// StartupDisplay page.
    /// </summary>
    public sealed partial class StartupDisplay : Page
    {
        /// <summary>
        /// Gets or sets the current startup display page.
        /// </summary>
        internal static StartupDisplay Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartupDisplay"/> class.
        /// </summary>
        public StartupDisplay()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;

            // IsLoaded = true;
            _ = Task.Run(() => ProcessAsync());
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private async Task ProcessAsync()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    AddItem("Loading Materials.");
                });

            int numberOfMaterials = FileManager.LoadMaterialsAsync().Result;

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    AddItem(numberOfMaterials.ToString() + " Materials loaded.");
                });

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    AddItem("Loading Sections.");
                });

            int numberOfSections = await FileManager.LoadSectionsAsync();

            Debug.WriteLine($"No of sections = {numberOfSections}");

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    AddItem(numberOfSections.ToString() + " Sections loaded.");
                });

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                {
                    FileManager.LoadLastFileAsync();
                });

            try
            {
            }
            catch (Exception ex)
            {
                Debug.WriteLine("StartupDisplay Error: " + ex.Message);
                WService.ReportException(ex);
            }
        }

        /// <summary>
        /// Adds a message to the page.
        /// </summary>
        /// <param name="message">The message to add to the page.</param>
        public async void AddItem(string message)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                    {
                        StartupStackPanelItem tempItem = new StartupStackPanelItem(message);
                        Current.StackPanelStartup.Children.Add(tempItem);
                    });
        }
    }
}