namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using Windows.Storage;
    using Windows.Storage.AccessCache;
    using Windows.Storage.Pickers;
    using Windows.UI.Core;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// FileManager class.
    /// </summary>
    internal static class FileManager
    {
        private static string fileTitle;

        // Files
        private static StorageFile workingFile;
        private static StorageFile materialsFile;
        private static StorageFile sectionsFile;
        private static StorageFile nextFile;

        // File properties.
        private static string workingFilePath = string.Empty;
        private static string workingFileDisplayName = string.Empty;
        private static string workingFileMruToken = string.Empty;
        private static string workingFileListToken = string.Empty;

        // Loading stats.
        private static int statsLoadingTotalItems = 0;

        #region Properties

        /// <summary>
        /// Gets or sets the local settings application data container.
        /// </summary>
        internal static ApplicationDataContainer LocalSettings { get; set; } = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Gets or sets the local folder.
        /// </summary>
        internal static StorageFolder LocalFolder { get; set; } = ApplicationData.Current.LocalFolder;

        /// <summary>
        /// Gets the file title.
        /// </summary>
        public static string FileTitle
        {
            get { return fileTitle; }
        }

        #endregion

        /// <summary>
        /// Creates a new file.
        /// </summary>
        public static async void NewFile()
        {
            if (await PickFileToSave())
            {
                Model.Reset();
                if (nextFile is object)
                {
                    Options.FirstRun = false;
                    Camera.Zoom = 0.5f;
                    Camera.CenterOn(new Vector2(0, 0));

                    // New File was picked.
                    workingFile = nextFile;
                    StorageItemMostRecentlyUsedList mru = StorageApplicationPermissions.MostRecentlyUsedList;
                    string mruToken = mru.Add(workingFile, workingFile.Path);
                    string listToken = StorageApplicationPermissions.FutureAccessList.Add(workingFile);

                    workingFileDisplayName = workingFile.DisplayName;
                    workingFilePath = workingFile.Path;
                    workingFileMruToken = mruToken;
                    workingFileListToken = listToken;

                    LocalSettings.Values["WorkingFileDisplayName"] = workingFileDisplayName;
                    LocalSettings.Values["WorkingFilePath"] = workingFilePath;
                    LocalSettings.Values["WorkingFileMruToken"] = workingFileMruToken;
                    LocalSettings.Values["WorkingFileListToken"] = workingFileListToken;

                    _ = await SaveFile();
                    _ = await LoadFile();
                    return;
                }
            }

            // Picking new file failed.
            if (Options.FirstRun)
            {
                MessageDialog dialog = new MessageDialog("You must specify a file to save the drawing data too for the application to work with. No file chosen, exiting application.");
                _ = await dialog.ShowAsync();
                Application.Current.Exit();
            }
        }

        /// <summary>
        /// Load the file.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal static async Task<bool> LoadFile()
        {
            // Reset the Model first.
            Model.Reset();

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                   {
                       fileTitle = "Untitled";
                       Frame rootFrame = Window.Current.Content as Frame;
                       _ = rootFrame.Navigate(typeof(FileLoading));
                   });

            if (workingFile is object)
            {
                try
                {
                    if (StorageApplicationPermissions.MostRecentlyUsedList.ContainsItem(workingFileMruToken))
                    {
                    }
                    else
                    {
                    }

                    if (StorageApplicationPermissions.FutureAccessList.ContainsItem(workingFileListToken))
                    {
                        // Debug.WriteLine("Found FAL Token");
                    }
                    else
                    {
                        // Debug.WriteLine("FAL Token Not Found");
                    }

                    if (StorageApplicationPermissions.FutureAccessList.CheckAccess(workingFile))
                    {
                        // Debug.WriteLine("Have File Access");
                    }
                    else
                    {
                        // Debug.WriteLine("No File Access");
                    }

                    workingFileDisplayName = workingFile.DisplayName;
                    workingFilePath = workingFile.Path;
                    fileTitle = workingFile.DisplayName;
                    LocalSettings.Values["WorkingFileDisplayName"] = workingFileDisplayName;
                    LocalSettings.Values["WorkingFilePath"] = workingFilePath;

                    IList<string> lines = new List<string>();
                    lines = await FileIO.ReadLinesAsync(workingFile);

                    if (workingFile.FileType == ".struct")
                    {
                        foreach (string line in lines)
                        {
                            string[] words = line.Split('|');
                            switch (words[0])
                            {
                                case "I":
                                    try
                                    {
                                        // Stats for Loading
                                        statsLoadingTotalItems = Convert.ToInt32(words[1]);
                                        try
                                        {
                                            if (FileLoadingDisplay.Current is object)
                                            {
                                                FileLoadingDisplay.Current.AddMessage(-1, -1, "Total Elements " + statsLoadingTotalItems);
                                            }
                                        }
                                        catch
                                        {
                                        }

                                        // Load Camera Settings
                                        Camera.SetupFromFile(Convert.ToSingle(words[13]), new Vector2(Convert.ToSingle(words[14]), Convert.ToSingle(words[15])));
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("INFO Line Failed to load. " + ex.Message);
                                    }

                                    break;

                                case "N":
                                    try
                                    {
                                        Node tempnode = Model.Nodes.GetOrAdd(
                                            new Tuple<decimal, decimal>(Convert.ToDecimal(words[2]), Convert.ToDecimal(words[3])),
                                            new Node(
                                                Convert.ToInt32(words[1]),
                                                new Point(Convert.ToDecimal(words[2]), Convert.ToDecimal(words[3]), 0),
                                                new Codes(-1, -1, -1),
                                                new Constraints((ConstraintType)Convert.ToInt32(words[4])),
                                                new NodalLoad(Convert.ToDecimal(words[5]), Convert.ToDecimal(words[6]), Convert.ToDecimal(words[7])),
                                                true));
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("SECTION Line Failed to load. " + ex.Message);
                                    }

                                    break;

                                case "M":

                                    try
                                    {
                                        Member addMember = new Member(
                                            Convert.ToInt32(words[1]),
                                            Model.Nodes.GetFromIndex(Convert.ToInt32(words[2])),
                                            Model.Nodes.GetFromIndex(Convert.ToInt32(words[3])),
                                            Model.Sections[Convert.ToString(words[4])],
                                            Convert.ToInt32(words[5]),
                                            Convert.ToDecimal(words[6]),
                                            Convert.ToDecimal(words[7]));
                                    }
                                    catch
                                    {
                                        Debug.WriteLine("ERROR: addMember failed.");
                                    }

                                    try
                                    {
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("MEMBER Line Failed to load. " + ex.Message);
                                    }

                                    break;
                                default:
                                    Debug.WriteLine("WARNING: Unknown word.");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        foreach (string line in lines)
                        {
                            string[] words = line.Split(',');
                            switch (words[0])
                            {
                                case "I":
                                    try
                                    {
                                        // Stats for Loading
                                        statsLoadingTotalItems = Convert.ToInt32(words[1]);
                                        try
                                        {
                                            if (FileLoadingDisplay.Current is object)
                                            {
                                                FileLoadingDisplay.Current.AddMessage(-1, -1, "Total Elements " + statsLoadingTotalItems);
                                            }
                                        }
                                        catch
                                        {
                                        }

                                        // Load Camera Settings
                                        Camera.SetupFromFile(Convert.ToSingle(words[13]), new Vector2(Convert.ToSingle(words[14]), Convert.ToSingle(words[15])));
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("INFO Line Failed to load. " + ex.Message);
                                    }

                                    break;

                                case "N":
                                    try
                                    {
                                        Node tempnode = Model.Nodes.GetOrAdd(
                                            new Tuple<decimal, decimal>(Convert.ToDecimal(words[2]), Convert.ToDecimal(words[3])),
                                            new Node(
                                                Convert.ToInt32(words[1]),
                                                new Point(Convert.ToDecimal(words[2]), Convert.ToDecimal(words[3]), 0),
                                                new Codes(-1, -1, -1),
                                                new Constraints((ConstraintType)Convert.ToInt32(words[4])),
                                                new NodalLoad(Convert.ToDecimal(words[5]), Convert.ToDecimal(words[6]), Convert.ToDecimal(words[7])),
                                                true));
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("SECTION Line Failed to load. " + ex.Message);
                                    }

                                    break;

                                case "M":

                                    try
                                    {
                                        Member addMember = new Member(
                                            Convert.ToInt32(words[1]),
                                            Model.Nodes.GetFromIndex(Convert.ToInt32(words[2])),
                                            Model.Nodes.GetFromIndex(Convert.ToInt32(words[3])),
                                            Model.Sections[Convert.ToString(words[4])],
                                            Convert.ToInt32(words[5]),
                                            Convert.ToDecimal(words[6]),
                                            Convert.ToDecimal(words[7]));
                                    }
                                    catch
                                    {
                                        Debug.WriteLine("ERROR: addMember failed.");
                                    }

                                    try
                                    {
                                    }
                                    catch (Exception ex)
                                    {
                                        Debug.WriteLine("MEMBER Line Failed to load. " + ex.Message);
                                    }

                                    break;
                                default:
                                    Debug.WriteLine("WARNING: Unknown word.");
                                    break;
                            }
                        }
                    }

                    // Update the number of primary nodes.
                    Model.Nodes.UpdateNoOfPrimaryNodes();
                }
                catch
                {
                    NewFile();
                }
            }
            else
            {
                return false;
            }

            Windows.UI.ViewManagement.ApplicationView appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = workingFileDisplayName;

            await Task.Delay(100);

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                () =>
                   {
                       Frame rootFrame = Window.Current.Content as Frame;
                       _ = rootFrame.Navigate(typeof(Construction));
                   });

            return true;
        }

        /// <summary>
        /// Loads the last file.
        /// </summary>
        internal static async void LoadLastFileAsync()
        {
            try
            {
                if (Options.FirstRun)
                {
                    Uri uriHelpGeneral = new Uri(@"http://intacomputers.com/Software/FEA/FiniteElementAnalysisExplorer/Help/QuickStart.aspx");
                    bool success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = false });
                    NewFile();
                    Frame rootFrame = Window.Current.Content as Frame;
                    _ = rootFrame.Navigate(typeof(Construction));
                }
                else
                {
                    workingFileMruToken = (string)LocalSettings.Values["WorkingFileMruToken"];
                    StorageItemMostRecentlyUsedList mru = StorageApplicationPermissions.MostRecentlyUsedList;
                    workingFile = await mru.GetFileAsync(workingFileMruToken);
                    _ = await LoadFile();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR LoadLastFileAsync " + ex.Message + " " + ex.Data.ToString() + " " + ex.StackTrace);
                NewFile();
                Frame rootFrame = Window.Current.Content as Frame;
                _ = rootFrame.Navigate(typeof(Construction));
            }
        }

        /// <summary>
        /// Save a file to disk.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal static async Task<bool> SaveFile()
        {
            if (workingFile != null)
            {
                if (workingFile.FileType == ".struct")
                {
                    IList<string> lines = new List<string>();

                    string info = "I|";

                    info = info + (Model.Members.Count + Model.Nodes.Count()).ToString() + "|";
                    info = info + Model.Members.Count.ToString() + "|";
                    info = info + Model.Nodes.Count.ToString() + "|";
                    info += "0|0|0|0|0|0|0|0|0|";

                    info = info + Camera.Zoom + "|";
                    info = info + Camera.Position.X + "|";
                    info = info + Camera.Position.Y + "|";
                    lines.Add(info);

                    long count = 0;
                    foreach (KeyValuePair<Tuple<decimal, decimal>, Node> node in Model.Nodes)
                    {
                        if (node.Value.IsPrimary)
                        {
                            string line = "N|" + node.Value.Index.ToString() + "|";
                            line = line + node.Value.Position.X.ToString() + "|";
                            line = line + node.Value.Position.Y.ToString() + "|";
                            line = line + ((int)node.Value.Constraints.ConstraintType).ToString() + "|";
                            line = line + node.Value.Load.X.ToString() + "|";
                            line = line + node.Value.Load.Y.ToString() + "|";
                            line += node.Value.Load.M.ToString();
                            lines.Add(line);
                            count++;
                        }
                    }

                    count = 0;
                    foreach (KeyValuePair<int, Member> member in Model.Members)
                    {
                        string line = "M|" + member.Value.Index + "|";
                        line = line + member.Value.NodeNear.Index.ToString() + "|";
                        line = line + member.Value.NodeFar.Index.ToString() + "|";
                        line = line + member.Value.Section.Name.ToString() + "|";
                        line = line + member.Value.TotalSegments.ToString() + "|";
                        line = line + member.Value.LDLNear.ToString() + "|";
                        line += member.Value.LDLFar.ToString();
                        lines.Add(line);
                        count++;
                    }

                    await FileIO.WriteLinesAsync(workingFile, lines);
                    CachedFileManager.DeferUpdates(workingFile);
                    _ = await CachedFileManager.CompleteUpdatesAsync(workingFile);
                }
                else
                {
                    IList<string> lines = new List<string>();

                    string info = "I,";

                    info = info + (Model.Members.Count + Model.Nodes.Count()).ToString() + ",";
                    info = info + Model.Members.Count.ToString() + ",";
                    info = info + Model.Nodes.Count.ToString() + ",";
                    info += "0,0,0,0,0,0,0,0,0,";

                    info = info + Camera.Zoom + ",";
                    info = info + Camera.Position.X + ",";
                    info = info + Camera.Position.Y + ",";
                    lines.Add(info);

                    long count = 0;
                    foreach (KeyValuePair<Tuple<decimal, decimal>, Node> node in Model.Nodes)
                    {
                        if (node.Value.IsPrimary)
                        {
                            string line = "N," + node.Value.Index.ToString() + ",";
                            line = line + node.Value.Position.X.ToString() + ",";
                            line = line + node.Value.Position.Y.ToString() + ",";
                            line = line + ((int)node.Value.Constraints.ConstraintType).ToString() + ",";
                            line = line + node.Value.Load.X.ToString() + ",";
                            line = line + node.Value.Load.Y.ToString() + ",";
                            line += node.Value.Load.M.ToString();
                            lines.Add(line);
                            count++;
                        }
                    }

                    count = 0;
                    foreach (KeyValuePair<int, Member> member in Model.Members)
                    {
                        string line = "M," + member.Value.Index + ",";
                        line = line + member.Value.NodeNear.Index.ToString() + ",";
                        line = line + member.Value.NodeFar.Index.ToString() + ",";
                        line = line + member.Value.Section.Name.ToString() + ",";
                        line = line + member.Value.TotalSegments.ToString() + ",";
                        line = line + member.Value.LDLNear.ToString() + ",";
                        line += member.Value.LDLFar.ToString();
                        lines.Add(line);
                        count++;
                    }

                    await FileIO.WriteLinesAsync(workingFile, lines);
                    CachedFileManager.DeferUpdates(workingFile);
                    _ = await CachedFileManager.CompleteUpdatesAsync(workingFile);
                }
            }
            else
            {
                Debug.WriteLine("File is Not Saved : " + workingFilePath);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Save the last file.
        /// </summary>
        internal static async void SaveLastFile()
        {
            if (workingFile is object)
            {
                _ = await SaveFile();
            }
        }

        /// <summary>
        /// Load the Materials from file. File Item Format:
        /// int = index.
        /// string = Name.
        /// string = Description.
        /// decimal = Cost.
        /// decimal = density.
        /// decimal = Ultimate Strength Tension.
        /// decimal = Ultimate Strength Compression.
        /// decimal = Ultimate Strength Shear.
        /// decimal = Yield Strength Tension.
        /// decimal = Yield Strength Shear.
        /// decimal = Modulus of Elasticity.
        /// decimal = Modulus of Rigidity.
        /// decimal = Coefficient of Thermal Expansion.
        /// decimal = Ductility.
        /// </summary>
        /// <returns>The count of materials.</returns>
        internal static async Task<int> LoadMaterialsAsync()
        {
            StorageFile materialsDataFile = null;

            try
            {
                materialsDataFile = await LocalFolder.GetFileAsync("Materials.json");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("File Not Found: " + ex.Message);
            }

            if (materialsDataFile == null)
            {
                // Copy the file from the install folder to the local folder
                var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Data");
                var file = await folder.GetFileAsync("Materials.json");
                if (file != null)
                {
                    materialsDataFile = await file.CopyAsync(LocalFolder, "Materials.json", NameCollisionOption.FailIfExists);
                }
            }

            string json = await Windows.Storage.FileIO.ReadTextAsync(materialsDataFile);
            Debug.WriteLine(json);
            Model.Materials.LoadMaterials(JsonConvert.DeserializeObject<Dictionary<string, Material>>(json));

            SectionProfilesList.LoadList();

            return Model.Materials.Count;
        }

        /// <summary>
        /// Save the materials to disk.
        /// TODO re-implement material save.
        /// </summary>
        internal static async void SaveMaterialsAsync()
        {
            string json = JsonConvert.SerializeObject(Model.Materials, Formatting.Indented);
            materialsFile = await LocalFolder.GetFileAsync("Materials.json");

            await FileIO.WriteTextAsync(materialsFile, json);

            CachedFileManager.DeferUpdates(materialsFile);
            _ = await CachedFileManager.CompleteUpdatesAsync(materialsFile);
        }

        #region Sections

        /// <summary>
        /// Loads the sections from disk.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal static async Task<int> LoadSectionsAsync()
        {
            Debug.WriteLine($"InstalledLocation Path {Windows.ApplicationModel.Package.Current.InstalledLocation.Path}");
            Debug.WriteLine($"LocalFolder Path {LocalFolder.Path}");

            StorageFile sectionsDataFile = null;

            try
            {
                sectionsDataFile = await LocalFolder.GetFileAsync("Sections.json");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("File Not Found: " + ex.Message);
            }

            try
            {
                if (sectionsDataFile == null)
                {
                    // Copy the file from the install folder to the local folder
                    var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Data");
                    var file = await folder.GetFileAsync("Sections.json");
                    if (file != null)
                    {
                        sectionsDataFile = await file.CopyAsync(LocalFolder, "Sections.json", NameCollisionOption.FailIfExists);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("File Not Copied: " + ex.Message);
            }

            try
            {
                string json = await Windows.Storage.FileIO.ReadTextAsync(sectionsDataFile);
                Debug.WriteLine("Section JSON: " + json);
                Model.Sections.LoadSections(JsonConvert.DeserializeObject<Dictionary<string, Section>>(json));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Json Not Found: " + ex.Message);
            }

            return Model.Sections.Count;
        }

        /// <summary>
        /// Save the sections to disk.
        /// </summary>
        internal static async void SaveSectionsAsync()
        {
            Debug.WriteLine("SaveSectionsAsync");

            try
            {
                string json = JsonConvert.SerializeObject(Model.Sections, Formatting.Indented);

                Debug.WriteLine("SaveSectionsAsync JSON " + json);

                sectionsFile = await LocalFolder.GetFileAsync("Sections.json");
                await FileIO.WriteTextAsync(sectionsFile, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SaveSectionsAsync: " + ex.Message);
            }
        }

        #endregion

        /// <summary>
        /// Pick the file to load.
        /// </summary>
        /// <returns>True if successful.</returns>
        public static async Task<bool> PickFileToLoad()
        {
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            openPicker.FileTypeFilter.Add(".struct");
            openPicker.FileTypeFilter.Add(".csv");
            nextFile = null;
            nextFile = await openPicker.PickSingleFileAsync();

            if (nextFile is null)
            {
                // Open File Picker Failed.
                return false;
            }
            else
            {
                // New File was picked.
                workingFile = nextFile;
                StorageItemMostRecentlyUsedList mru = StorageApplicationPermissions.MostRecentlyUsedList;
                string mruToken = mru.Add(workingFile, workingFile.Path);
                string listToken = StorageApplicationPermissions.FutureAccessList.Add(workingFile);

                workingFileDisplayName = workingFile.DisplayName;
                workingFilePath = workingFile.Path;
                workingFileMruToken = mruToken;
                workingFileListToken = listToken;

                LocalSettings.Values["WorkingFileDisplayName"] = workingFileDisplayName;
                LocalSettings.Values["WorkingFilePath"] = workingFilePath;
                LocalSettings.Values["WorkingFileMruToken"] = workingFileMruToken;
                LocalSettings.Values["WorkingFileListToken"] = workingFileListToken;

                return true;
            }
        }

        /// <summary>
        /// Pick the file to save to.
        /// </summary>
        /// <returns>True if successful.</returns>
        public static async Task<bool> PickFileToSave()
        {
            FileSavePicker savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            savePicker.FileTypeChoices.Add("Structure Files", new List<string>() { ".struct" });
            savePicker.SuggestedFileName = workingFileDisplayName;
            nextFile = null;
            nextFile = await savePicker.PickSaveFileAsync();
            if (nextFile is null)
            {
                // File Picker Failed.
                return false;
            }
            else
            {
                // Picked ok.
                workingFile = nextFile;

                StorageItemMostRecentlyUsedList mru = StorageApplicationPermissions.MostRecentlyUsedList;
                string mruToken = mru.Add(workingFile, workingFile.Path);
                string listToken = StorageApplicationPermissions.FutureAccessList.Add(workingFile);

                workingFileDisplayName = workingFile.DisplayName;
                workingFilePath = workingFile.Path;
                workingFileMruToken = mruToken;
                workingFileListToken = listToken;

                LocalSettings.Values["WorkingFileDisplayName"] = workingFileDisplayName;
                LocalSettings.Values["WorkingFilePath"] = workingFilePath;
                LocalSettings.Values["WorkingFileMruToken"] = workingFileMruToken;
                LocalSettings.Values["WorkingFileListToken"] = workingFileListToken;

                return true;
            }
        }
    }
}
