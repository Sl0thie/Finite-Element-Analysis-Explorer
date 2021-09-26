namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Generic;

    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelReport Page.
    /// </summary>
    public sealed partial class PanelReport : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelReport"/> class.
        /// </summary>
        public PanelReport()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private async void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            savePicker.FileTypeChoices.Add("Web page", new List<string>() { ".html" });
            savePicker.SuggestedFileName = "Report";
            StorageFile nextFile = null;
            nextFile = await savePicker.PickSaveFileAsync();
            if (nextFile is null)
            {
                // No file picked, do nothing.
            }
            else
            {
                StorageFolder reportsFolder = await FileManager.LocalFolder.GetFolderAsync("Reports");
                StorageFile tempFile = await reportsFolder.GetFileAsync("ReportBasic.html");
                await tempFile.MoveAndReplaceAsync(nextFile);
            }
        }

        private void Button_Report_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            _ = rootFrame.Navigate(typeof(Results));
        }
    }
}