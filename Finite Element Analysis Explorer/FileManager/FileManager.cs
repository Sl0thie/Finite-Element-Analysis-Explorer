using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.Graphics.Canvas.Geometry;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    internal static class FileManager
    {
        // static FileManager()
        // {
        //    //DefaultFile = localFolder.CreateFileAsync("Untitled.Struct", CreationCollisionOption.ReplaceExisting);

        // //// Create sample file; replace if exists.
        //    //Windows.Storage.StorageFolder storageFolder =
        //    //    Windows.Storage.ApplicationData.Current.LocalFolder;
        //    //Windows.Storage.StorageFile sampleFile =
        //    //    await storageFolder.CreateFileAsync("sample.txt",
        //    //        Windows.Storage.CreationCollisionOption.ReplaceExisting);

        // }
        #region Properties

        internal static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        internal static StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        // Files
        private static StorageFile WorkingFile;
        private static StorageFile MaterialsFile;
        private static StorageFile SectionsFile;
        private static StorageFile NextFile;

        // private static StorageFile DefaultFile;

        private static string WorkingFilePath = string.Empty;
        private static string WorkingFileDisplayName = string.Empty;
        private static string WorkingFileMruToken = string.Empty;
        private static string WorkingFileListToken = string.Empty;

        internal static int StatsLoadingTotalItems = 0;
        internal static int StatsLoadingTotalMembers = 0;
        internal static int StatsLoadingTotalNodes = 0;
        internal static int StatsLoadingTotalSections = 0;

        internal static int StatsLastSolverUsed = 0;
        internal static long StatsTimeCreated = 0;
        internal static long StatsTimeLastOpened = 0;
        internal static long StatsTimeLastClosed = 0;
        internal static long StatsTimeTotalOpened = 0;
        internal static long StatsTotalOpened = 0;
        internal static long StatsTimeTotalSolving = 0;
        internal static long StatsTotalSolving = 0;

        // private static string fileName = "";
        // internal static string FileName
        // {
        //    get { return fileName; }
        // }

        // private static string filePath = "";
        // internal static string FilePath
        // {
        //    get { return filePath; }
        // }
        private static string fileTitle;

        public static string FileTitle
        {
            get { return fileTitle; }

            // set { fileTitle = value; }
        }

        #endregion

        public static async void NewFile()
        {

            if (await PickFileToSave())
            {
                Model.Reset();
                if (NextFile is null)
                {
                    // Open File Picker Failed.
                    return;
                }
                else
                {
                    // Model.Reset();
                    Camera.Zoom = 0.5f;
                    Camera.CenterOn(new Vector2(0, 0));

                    // New File was picked.
                    WorkingFile = NextFile;
                    var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                    string mruToken = mru.Add(WorkingFile, WorkingFile.Path);
                    var listToken = StorageApplicationPermissions.FutureAccessList.Add(WorkingFile);

                    WorkingFileDisplayName = WorkingFile.DisplayName;
                    WorkingFilePath = WorkingFile.Path;
                    WorkingFileMruToken = mruToken;
                    WorkingFileListToken = listToken;

                    localSettings.Values["WorkingFileDisplayName"] = WorkingFileDisplayName;
                    localSettings.Values["WorkingFilePath"] = WorkingFilePath;
                    localSettings.Values["WorkingFileMruToken"] = WorkingFileMruToken;
                    localSettings.Values["WorkingFileListToken"] = WorkingFileListToken;

                    // Debug.WriteLine("Open File Picker : " + WorkingFile.DisplayName + " " + WorkingFile.Path + " " + WorkingFileMruToken);
                    await SaveFile();
                    await LoadFile();
                    return;
                }
            }

            ///Old Version.
            ////Reset the Model first.
            // Model.Reset();
            ////fileName = "";
            ////filePath = "";

            // DefaultFile = await localFolder.CreateFileAsync("Untitled.Struct", CreationCollisionOption.ReplaceExisting);
            // WorkingFile = DefaultFile;

            // Camera.Zoom = 1;
            // Camera.CenterOn(new Vector2(0, 0));

            // await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
            //       () =>
            //       {
            //           fileTitle = "Untitled";
            //           Frame rootFrame = Window.Current.Content as Frame;
            //           rootFrame.Navigate(typeof(Construction));
            //       }
            //       );
        }

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
                       rootFrame.Navigate(typeof(FileLoading));
                   });

            if (WorkingFile is object)
            {
                try
                {
                    if (StorageApplicationPermissions.MostRecentlyUsedList.ContainsItem(WorkingFileMruToken))
                    {
                    }
                    else
                    {
                    }

                    if (StorageApplicationPermissions.FutureAccessList.ContainsItem(WorkingFileListToken))
                    {
                        // Debug.WriteLine("Found FAL Token");
                    }
                    else
                    {
                        // Debug.WriteLine("FAL Token Not Found");
                    }

                    if (StorageApplicationPermissions.FutureAccessList.CheckAccess(WorkingFile))
                    {
                        // Debug.WriteLine("Have File Access");
                    }
                    else
                    {
                        // Debug.WriteLine("No File Access");
                    }

                    WorkingFileDisplayName = WorkingFile.DisplayName;
                    WorkingFilePath = WorkingFile.Path;
                    fileTitle = WorkingFile.DisplayName;
                    localSettings.Values["WorkingFileDisplayName"] = WorkingFileDisplayName;
                    localSettings.Values["WorkingFilePath"] = WorkingFilePath;

                    IList<String> lines = new List<string>();
                    lines = await FileIO.ReadLinesAsync(WorkingFile);

                    Debug.WriteLine("WorkingFileDisplayName " + WorkingFilePath);
                    Debug.WriteLine("WorkingFilePath " + WorkingFilePath);
                    Debug.WriteLine("WorkingFile.FileType " + WorkingFile.FileType);

                    if (WorkingFile.FileType == ".struct")
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
                                        StatsLoadingTotalItems = Convert.ToInt32(words[1]);
                                        try
                                        {
                                            if (FileLoadingDisplay.Current is object)
                                            {
                                                FileLoadingDisplay.Current.AddMessage(-1, -1, "Total Elements " + StatsLoadingTotalItems);
                                            }
                                        }
                                        catch
                                        {
                                        }

                                        StatsLoadingTotalMembers = Convert.ToInt32(words[2]);
                                        StatsLoadingTotalNodes = Convert.ToInt32(words[3]);
                                        StatsLoadingTotalSections = Convert.ToInt32(words[4]);

                                        // Other Stats
                                        StatsLastSolverUsed = Convert.ToInt32(words[5]);
                                        StatsTimeCreated = Convert.ToInt32(words[6]);
                                        StatsTimeLastOpened = Convert.ToInt32(words[7]);
                                        StatsTimeLastClosed = Convert.ToInt32(words[8]);
                                        StatsTimeTotalOpened = Convert.ToInt32(words[9]);
                                        StatsTotalOpened = Convert.ToInt32(words[10]);
                                        StatsTimeTotalSolving = Convert.ToInt32(words[11]);
                                        StatsTotalSolving = Convert.ToInt32(words[12]);

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

                                    // Model.Members.AddNewMemberToIndex(Convert.ToInt32(words[1]),
                                    //       Model.Nodes.GetFromIndex(Convert.ToInt32(words[2])),
                                    //       Model.Nodes.GetFromIndex(Convert.ToInt32(words[3])),
                                    //       Model.Sections[Convert.ToString(words[4])],
                                    //       Convert.ToInt32(words[5]),
                                    //       Convert.ToDecimal(words[6]),
                                    //       Convert.ToDecimal(words[7]));

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
                                        StatsLoadingTotalItems = Convert.ToInt32(words[1]);
                                        try
                                        {
                                            if (FileLoadingDisplay.Current is object)
                                            {
                                                FileLoadingDisplay.Current.AddMessage(-1, -1, "Total Elements " + StatsLoadingTotalItems);
                                            }
                                        }
                                        catch
                                        {
                                        }

                                        StatsLoadingTotalMembers = Convert.ToInt32(words[2]);
                                        StatsLoadingTotalNodes = Convert.ToInt32(words[3]);
                                        StatsLoadingTotalSections = Convert.ToInt32(words[4]);

                                        // Other Stats
                                        StatsLastSolverUsed = Convert.ToInt32(words[5]);
                                        StatsTimeCreated = Convert.ToInt32(words[6]);
                                        StatsTimeLastOpened = Convert.ToInt32(words[7]);
                                        StatsTimeLastClosed = Convert.ToInt32(words[8]);
                                        StatsTimeTotalOpened = Convert.ToInt32(words[9]);
                                        StatsTotalOpened = Convert.ToInt32(words[10]);
                                        StatsTimeTotalSolving = Convert.ToInt32(words[11]);
                                        StatsTotalSolving = Convert.ToInt32(words[12]);

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

            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = WorkingFileDisplayName;

            await Task.Delay(100);

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.High,
                   () =>
                   {
                       Frame rootFrame = Window.Current.Content as Frame;
                       rootFrame.Navigate(typeof(Construction));
                   });

            return true;
        }

        internal static async void LoadLastFileAsync()
        {
            try
            {
                WorkingFileMruToken = (string)localSettings.Values["WorkingFileMruToken"];
                var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                WorkingFile = await mru.GetFileAsync(WorkingFileMruToken);
                await LoadFile();
            }
            catch (Exception ex)
            {
                if (Options.FirstRun)
                {
                    var uriHelpGeneral = new Uri(@"http://intacomputers.com/Software/FiniteElementAnalysisExplorer/Help/QuickStart.aspx");
                    var success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = false });
                    Options.FirstRun = false;
                }

                Debug.WriteLine("ERROR LoadLastFileAsync " + ex.Message + " " + ex.Data.ToString() + " " + ex.StackTrace);
                NewFile();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Construction));
            }
        }

        internal static async Task<bool> SaveFile()
        {

            if (WorkingFile != null)
            {

                if (WorkingFile.FileType == ".struct")
                {
                    IList<String> lines = new List<string>();

                    string Info = "I|";

                    Info = Info + (Model.Members.Count + Model.Nodes.Count()).ToString() + "|";
                    Info = Info + Model.Members.Count.ToString() + "|";
                    Info = Info + Model.Nodes.Count.ToString() + "|";
                    Info += "0|0|0|0|0|0|0|0|0|";

                    Info = Info + Camera.Zoom + "|";
                    Info = Info + Camera.Position.X + "|";
                    Info = Info + Camera.Position.Y + "|";
                    lines.Add(Info);

                    long Count = 0;
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.IsPrimary)
                        {
                            string Line = "N|" + Item.Value.Index.ToString() + "|";
                            Line = Line + Item.Value.Position.X.ToString() + "|";
                            Line = Line + Item.Value.Position.Y.ToString() + "|";
                            Line = Line + ((int)Item.Value.Constraints.ConstraintType).ToString() + "|";
                            Line = Line + Item.Value.Load.X.ToString() + "|";
                            Line = Line + Item.Value.Load.Y.ToString() + "|";
                            Line += Item.Value.Load.M.ToString();
                            lines.Add(Line);
                            Count++;
                        }
                    }

                    Count = 0;
                    foreach (var Item in Model.Members)
                    {
                        string Line = "M|" + Item.Value.Index + "|";
                        Line = Line + Item.Value.NodeNear.Index.ToString() + "|";
                        Line = Line + Item.Value.NodeFar.Index.ToString() + "|";
                        Line = Line + Item.Value.Section.Name.ToString() + "|";
                        Line = Line + Item.Value.TotalSegments.ToString() + "|";
                        Line = Line + Item.Value.LDLNear.ToString() + "|";
                        Line += Item.Value.LDLFar.ToString();
                        lines.Add(Line);
                        Count++;
                    }

                    await FileIO.WriteLinesAsync(WorkingFile, lines);
                    CachedFileManager.DeferUpdates(WorkingFile);
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(WorkingFile);
                }
                else
                {
                    IList<String> lines = new List<string>();

                    string Info = "I,";

                    Info = Info + (Model.Members.Count + Model.Nodes.Count()).ToString() + ",";
                    Info = Info + Model.Members.Count.ToString() + ",";
                    Info = Info + Model.Nodes.Count.ToString() + ",";
                    Info += "0,0,0,0,0,0,0,0,0,";

                    Info = Info + Camera.Zoom + ",";
                    Info = Info + Camera.Position.X + ",";
                    Info = Info + Camera.Position.Y + ",";
                    lines.Add(Info);

                    long Count = 0;
                    foreach (var Item in Model.Nodes)
                    {
                        if (Item.Value.IsPrimary)
                        {
                            string Line = "N," + Item.Value.Index.ToString() + ",";
                            Line = Line + Item.Value.Position.X.ToString() + ",";
                            Line = Line + Item.Value.Position.Y.ToString() + ",";
                            Line = Line + ((int)Item.Value.Constraints.ConstraintType).ToString() + ",";
                            Line = Line + Item.Value.Load.X.ToString() + ",";
                            Line = Line + Item.Value.Load.Y.ToString() + ",";
                            Line += Item.Value.Load.M.ToString();
                            lines.Add(Line);
                            Count++;
                        }
                    }

                    Count = 0;
                    foreach (var Item in Model.Members)
                    {
                        string Line = "M," + Item.Value.Index + ",";
                        Line = Line + Item.Value.NodeNear.Index.ToString() + ",";
                        Line = Line + Item.Value.NodeFar.Index.ToString() + ",";
                        Line = Line + Item.Value.Section.Name.ToString() + ",";
                        Line = Line + Item.Value.TotalSegments.ToString() + ",";
                        Line = Line + Item.Value.LDLNear.ToString() + ",";
                        Line += Item.Value.LDLFar.ToString();
                        lines.Add(Line);
                        Count++;
                    }

                    await FileIO.WriteLinesAsync(WorkingFile, lines);
                    CachedFileManager.DeferUpdates(WorkingFile);
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(WorkingFile);
                }
            }
            else
            {
                Debug.WriteLine("File is Not Saved : " + WorkingFilePath);
                return false;
            }

            // Debug.WriteLine("File : " + WorkingFileDisplayName + " " + WorkingFilePath);
            return true;
        }

        internal static async void SaveLastFile()
        {
            if (WorkingFile is object)
            {
                await SaveFile();
            }
        }

        /// <summary>
        /// Load the Materials from file. File Item Format:
        /// int = index
        /// string = Name
        /// string = Description
        /// decimal = Cost
        ///
        /// decimal = density
        /// decimal = Ultimate Strength Tension
        /// decimal = Ultimate Strength Compression
        /// decimal = Ultimate Strength Shear
        /// decimal = Yield Strength Tension
        /// decimal = Yield Strength Shear
        /// decimal = Modulus of Elasticity
        /// decimal = Modulus of Rigidity
        /// decimal = Coefficient of Thermal Expansion
        /// decimal = Ductility
        ///
        /// </summary>
        /// <returns></returns>
        internal static int LoadMaterialsAsync()
        {
            try
            {
                MaterialsList.LoadList();
                SectionProfilesList.LoadList();

                // MaterialsFile = await localFolder.GetFileAsync("Materials.Data");
                // IList<String> Lines = new List<string>();
                // Lines = await FileIO.ReadLinesAsync(MaterialsFile);
                // foreach (string line in Lines)
                // {
                //    string[] words = line.Split('|');
                //    Material tempMaterial = new Material(Convert.ToString(words[0]), Convert.ToString(words[1]), Convert.ToDecimal(words[2]), Convert.ToDecimal(words[3]), Convert.ToDecimal(words[4]), Convert.ToDecimal(words[5]), Convert.ToDecimal(words[6]), Convert.ToDecimal(words[7]), Convert.ToDecimal(words[8]), Convert.ToDecimal(words[9]), Convert.ToDecimal(words[10]), Convert.ToDecimal(words[11]), Convert.ToInt32(words[12]), Convert.ToInt32(words[13]), Convert.ToString(words[14]), Convert.ToDecimal(words[15]), Convert.ToString(words[16]), Convert.ToString(words[17]), Convert.ToString(words[18]), Convert.ToString(words[19]), Convert.ToString(words[20]), Convert.ToString(words[21]), Convert.ToString(words[22]), Convert.ToString(words[23]), Convert.ToString(words[24]), Convert.ToString(words[25]), Convert.ToString(words[26]), Convert.ToString(words[27]), Convert.ToString(words[28]), Convert.ToString(words[29]), Convert.ToString(words[30]), Convert.ToString(words[31]), Convert.ToString(words[32]), Convert.ToString(words[33]), Convert.ToString(words[34]), Convert.ToString(words[35]), Convert.ToString(words[36]), Convert.ToString(words[37]), Convert.ToString(words[38]), Convert.ToString(words[39]), Convert.ToString(words[40]), Convert.ToString(words[41]), Convert.ToString(words[42]), Convert.ToString(words[43]), Convert.ToString(words[44]), Convert.ToString(words[45]), Convert.ToString(words[46]), Convert.ToString(words[47]), Convert.ToString(words[48]), Convert.ToString(words[49]), Convert.ToString(words[50]), Convert.ToString(words[51]), Convert.ToString(words[52]), Convert.ToString(words[53]), Convert.ToString(words[54]), Convert.ToString(words[55]), Convert.ToString(words[56]), Convert.ToString(words[57]), Convert.ToString(words[58]), Convert.ToString(words[59]), Convert.ToString(words[60]), Convert.ToString(words[61]), Convert.ToString(words[62]), Convert.ToString(words[63]), Convert.ToString(words[64]), Convert.ToString(words[65]), Convert.ToString(words[66]), Convert.ToString(words[67]), Convert.ToString(words[68]), Convert.ToString(words[69]), Convert.ToString(words[70]), Convert.ToString(words[71]), Convert.ToString(words[72]), Convert.ToString(words[73]), Convert.ToString(words[74]), Convert.ToString(words[75]), Convert.ToString(words[76]), Convert.ToString(words[77]), Convert.ToString(words[78]), Convert.ToString(words[79]), Convert.ToString(words[80]), Convert.ToString(words[81]), Convert.ToString(words[82]), Convert.ToString(words[83]), Convert.ToString(words[84]), Convert.ToString(words[85]), Convert.ToString(words[86]), Convert.ToString(words[87]), Convert.ToString(words[88]), Convert.ToString(words[89]), Convert.ToString(words[90]), Convert.ToString(words[91]), Convert.ToString(words[92]), Convert.ToString(words[93]), Convert.ToString(words[94]), Convert.ToString(words[95]), Convert.ToString(words[96]), Convert.ToString(words[97]), Convert.ToString(words[98]), Convert.ToString(words[99]));
                //    Model.Materials.Add(tempMaterial.Name, tempMaterial);
                // }
            }
            catch
            {
                // Material tempMaterial = new Material("Steel (Structural)", "", 1, 8860, 480000000, -1, -1, 260000000, 145000000, 200000000000, 79000000000, 11700000, 23);
                // Model.Materials.Add(tempMaterial.Name, tempMaterial);

                // tempMaterial = new Material("Steel (High - Strength)", "", 1, 8860, 480000000, -1, -1, 350000000, 210000000, 200000000000, 79000000000, 11700000, 21);
                // Model.Materials.Add(tempMaterial.Name, tempMaterial);

                // tempMaterial = new Material("Aluminum (1100 - H14)", "", 1, 2710, 110000000, -1, 75000000, 95000000, 55000000, 70000000000, 26000000000, 23600000, 20);
                // Model.Materials.Add(tempMaterial.Name, tempMaterial);

                // StorageFile tempFile = await localFolder.CreateFileAsync("Materials.Data", CreationCollisionOption.ReplaceExisting);
                // await FileIO.WriteTextAsync(tempFile, "Steel (Structural)||1|8860|480000000|-1|-1|260000000|145000000|200000000000|79000000000|11700000|23");
                // await FileIO.WriteTextAsync(tempFile, "Steel (High-Strength)||1|8860|480000000|-1|-1|350000000|210000000|200000000000|79000000000|11700000|21");
                // await FileIO.WriteTextAsync(tempFile, "Aluminum (1100-H14)||1|2710|110000000|-1|75000000|95000000|55000000|70000000000|26000000000|23600000|20");
                // await Task.Run(() => SaveMaterialsAsync());

                // StorageFile tempFile = await localFolder.CreateFileAsync("Materials.Data", CreationCollisionOption.ReplaceExisting);
                // await Task.Run(() => SaveMaterialsAsync());

                // Debug.WriteLine("ERROR Loading Materials");
            }

            return Model.Materials.Count;
        }

        internal static void SaveMaterialsAsyncsec()
        {

            // XmlSerializer serializer = new XmlSerializer(typeof(Material));
            // StringBuilder stringBuilder = new StringBuilder();
            // XmlWriterSettings settings = new XmlWriterSettings()
            // {
            //    Indent = true,
            //    OmitXmlDeclaration = true,
            // };

            // using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            // {
            //    serializer.Serialize(xmlWriter, Model.Materials);
            // }

            // try
            // {
            //    string localData = ObjectSerializer<Dictionary<string,Material>.ToXml(Model.Materials);

            // if (!string.IsNullOrEmpty(localData))
            //    {
            //        StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Materials.xml", CreationCollisionOption.ReplaceExisting);
            //        await FileIO.WriteTextAsync(localFile, localData);
            //    }
            // }
            // catch (Exception ex)
            // {
            //    Debug.WriteLine("XML Error " + ex.Message);
            // }

            // string jsonContents = JsonConvert.SerializeObject(clocksItem);
            // StorageFile data = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            // using (IRandomAccessStream textStream = await data.OpenAsync(FileAccessMode.ReadWrite))
            // {
            //    using (DataWriter textWriter = new DataWriter(textStream))
            //    {
            //        textWriter.WriteString(jsonContents);
            //        await textWriter.StoreAsync();
            //    }

            // }

            // StorageFile file = await localFolder.CreateFileAsync("Materials.xml", CreationCollisionOption.ReplaceExisting);
            // using (IRandomAccessStream writeStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            // {
            //    System.IO.Stream s = writeStream.AsStreamForWrite();
            //    System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            //    settings.Async = true;
            //    using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(s, settings))
            //    {
            //        //writer.Settings.ConformanceLevel = System.Xml.ConformanceLevel.Auto;

            // foreach (var Item in Model.Materials)
            //        {
            //            writer.WriteStartElement("Material");
            //            writer.WriteElementString("Name", Item.Value.Name);
            //            writer.WriteElementString("Description", Item.Value.Description);
            //            writer.WriteElementString("Cost", Item.Value.Cost.ToString());

            // writer.WriteElementString("Density", Item.Value.Density.ToString());
            //            writer.WriteElementString("UltimateStrengthTension", Item.Value.UltimateStrengthTension.ToString());
            //            writer.WriteElementString("UltimateStrengthCompression", Item.Value.UltimateStrengthCompression.ToString());
            //            writer.WriteElementString("UltimateStrengthShear", Item.Value.UltimateStrengthShear.ToString());
            //            writer.WriteElementString("YieldStrengthTension", Item.Value.YieldStrengthTension.ToString());
            //            writer.WriteElementString("YieldStrengthShear", Item.Value.YieldStrengthShear.ToString());
            //            writer.WriteElementString("ModulusOfElasticity", Item.Value.ModulusOfElasticity.ToString());
            //            writer.WriteElementString("ModulusOfRigidity", Item.Value.ModulusOfRigidity.ToString());
            //            writer.WriteElementString("CoefficientOfThermalExpansion", Item.Value.CoefficientOfThermalExpansion.ToString());
            //            writer.WriteElementString("Ductility", Item.Value.Ductility.ToString());

            // writer.WriteEndElement();
            //        }

            // writer.Flush();
            //        await writer.FlushAsync();
            //    }
            // }
        }

        internal static async void SaveMaterialsAsync()
        {
            MaterialsFile = await localFolder.GetFileAsync("Materials.Data");

            IList<String> lines = new List<string>();
            foreach (var Item in Model.Materials)
            {

                string Line = Item.Value.Name.ToString() + "|";
                Line += Item.Value.Description.ToString() + "|";
                Line += Item.Value.Cost.ToString() + "|";
                Line += Item.Value.Density.ToString() + "|";
                Line += Item.Value.UltimateStrengthTension.ToString() + "|";
                Line += Item.Value.UltimateStrengthCompression.ToString() + "|";
                Line += Item.Value.UltimateStrengthShear.ToString() + "|";
                Line += Item.Value.YieldStrengthTension.ToString() + "|";
                Line += Item.Value.YieldStrengthShear.ToString() + "|";
                Line += Item.Value.ModulusOfElasticity.ToString() + "|";
                Line += Item.Value.ModulusOfRigidity.ToString() + "|";
                Line += Item.Value.CoefficientOfThermalExpansion.ToString() + "|";
                Line += Item.Value.Ductility.ToString() + "|";

                Line += Item.Value.Atomic_Number.ToString() + "|";
                Line += Item.Value.Symbol.ToString() + "|";
                Line += Item.Value.Atomic_Mass.ToString() + "|";
                Line += Item.Value.Allotrope_Names.ToString() + "|";
                Line += Item.Value.Alternate_Names.ToString() + "|";
                Line += Item.Value.CAS_Number.ToString() + "|";
                Line += Item.Value.Icon_Color.ToString() + "|";
                Line += Item.Value.Block.ToString() + "|";
                Line += Item.Value.Group.ToString() + "|";
                Line += Item.Value.Period.ToString() + "|";
                Line += Item.Value.Series.ToString() + "|";
                Line += Item.Value.Atomic_Weight.ToString() + "|";
                Line += Item.Value.Brinell_Hardness.ToString() + "|";
                Line += Item.Value.Bulk_Modulus.ToString() + "|";
                Line += Item.Value.Liquid_Density.ToString() + "|";
                Line += Item.Value.Mohs_Hardness.ToString() + "|";
                Line += Item.Value.Molar_Volume.ToString() + "|";
                Line += Item.Value.Poission_Ratio.ToString() + "|";
                Line += Item.Value.ModulusOfRigidity.ToString() + "|";
                Line += Item.Value.Sound_Speed.ToString() + "|";
                Line += Item.Value.Thermal_Conductivity.ToString() + "|";
                Line += Item.Value.Thermal_Expansion.ToString() + "|";
                Line += Item.Value.Vickers_Hardness.ToString() + "|";
                Line += Item.Value.ModulusOfElasticity.ToString() + "|";
                Line += Item.Value.Absolute_Boiling_Point.ToString() + "|";
                Line += Item.Value.Absolute_Melting_Point.ToString() + "|";
                Line += Item.Value.Adiabatic_Index.ToString() + "|";
                Line += Item.Value.Boiling_Point.ToString() + "|";
                Line += Item.Value.Critical_Pressure.ToString() + "|";
                Line += Item.Value.Critical_Temperature.ToString() + "|";
                Line += Item.Value.Curie_Point.ToString() + "|";
                Line += Item.Value.Fusion_Heat.ToString() + "|";
                Line += Item.Value.Melting_Point.ToString() + "|";
                Line += Item.Value.Neel_Point.ToString() + "|";
                Line += Item.Value.Phase.ToString() + "|";
                Line += Item.Value.Specific_Heat.ToString() + "|";
                Line += Item.Value.Superconducting_Point.ToString() + "|";
                Line += Item.Value.Vaporization_Heat.ToString() + "|";
                Line += Item.Value.Color.ToString() + "|";
                Line += Item.Value.Electrical_Conductivity.ToString() + "|";
                Line += Item.Value.Electrical_Type.ToString() + "|";
                Line += Item.Value.Magnetic_Type.ToString() + "|";
                Line += Item.Value.Mass_Magnetic_Susceptibility.ToString() + "|";
                Line += Item.Value.Molar_Magnetic_Susceptibility.ToString() + "|";
                Line += Item.Value.Resistivity.ToString() + "|";
                Line += Item.Value.Volume_Magnetic_Susceptibility.ToString() + "|";
                Line += Item.Value.Allotropic_Multiplicities.ToString() + "|";
                Line += Item.Value.Electron_Affinity.ToString() + "|";
                Line += Item.Value.Gas_Atomic_Multiplicities.ToString() + "|";
                Line += Item.Value.Valence.ToString() + "|";
                Line += Item.Value.Crystal_Structure.ToString() + "|";
                Line += Item.Value.Lattice_Angles.ToString() + "|";
                Line += Item.Value.Lattice_Constants.ToString() + "|";
                Line += Item.Value.Space_Group_Number.ToString() + "|";
                Line += Item.Value.Space_Group_Name.ToString() + "|";
                Line += Item.Value.Atomic_Radius.ToString() + "|";
                Line += Item.Value.Covalent_Radius.ToString() + "|";
                Line += Item.Value.Electron_Configuration.ToString() + "|";
                Line += Item.Value.Electron_Configuration_String.ToString() + "|";
                Line += Item.Value.Electron_Shell_Configuration.ToString() + "|";
                Line += Item.Value.Ionization_Energies.ToString() + "|";
                Line += Item.Value.Quantum_Numbers.ToString() + "|";
                Line += Item.Value.Van_Der_Waals_Radius.ToString() + "|";
                Line += Item.Value.Decay_Mode.ToString() + "|";
                Line += Item.Value.HalfLife.ToString() + "|";
                Line += Item.Value.Isotope_Abundances.ToString() + "|";
                Line += Item.Value.Lifetime.ToString() + "|";
                Line += Item.Value.Neutron_Cross_Section.ToString() + "|";
                Line += Item.Value.Neutron_Mass_Absorption.ToString() + "|";
                Line += Item.Value.Radioactive.ToString() + "|";
                Line += Item.Value.Stable_Isotopes.ToString() + "|";
                Line += Item.Value.Crust_Abundance.ToString() + "|";
                Line += Item.Value.Human_Abundance.ToString() + "|";
                Line += Item.Value.Meteorite_Abundance.ToString() + "|";
                Line += Item.Value.Ocean_Abundance.ToString() + "|";
                Line += Item.Value.Solar_Abundance.ToString() + "|";
                Line += Item.Value.Universe_Abundance.ToString() + "|";
                Line += Item.Value.Radius_Empirical.ToString() + "|";
                Line += Item.Value.Radius_Calculated.ToString() + "|";
                Line += Item.Value.Radius_Van_Der_Waals.ToString() + "|";
                Line += Item.Value.Radius_Covalent_Single_Bond.ToString() + "|";
                Line += Item.Value.Radius_Covalent_Triple_Bond.ToString() + "|";
                Line += Item.Value.Radius_Metallic.ToString() + "||||||||||||";

                lines.Add(Line);
            }

            await FileIO.WriteLinesAsync(MaterialsFile, lines);
            CachedFileManager.DeferUpdates(MaterialsFile);
            FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(MaterialsFile);
        }

        #region Sections

        internal static async Task<int> LoadSectionsAsync()
        {
            try
            {
                SectionsFile = await localFolder.GetFileAsync("Sections.Data");
                IList<String> lines = new List<string>();
                lines = await FileIO.ReadLinesAsync(SectionsFile);
                foreach (string line in lines)
                {
                    string[] words = line.Split('|');
                    Section tmpSection = new Section(
                        Convert.ToString(words[0]),
                        Convert.ToDecimal(words[1]),
                        Convert.ToDecimal(words[2]),
                        Convert.ToDecimal(words[3]),
                        Convert.ToDecimal(words[4]),
                        Convert.ToDecimal(words[5]),
                        Convert.ToByte(words[6]),
                        Convert.ToByte(words[7]),
                        Convert.ToByte(words[8]),
                        Convert.ToByte(words[9]),
                        (CanvasDashStyle)Convert.ToInt32(words[10]),
                        Convert.ToSingle(words[11]),
                        (CanvasCapStyle)Convert.ToInt32(words[12]),
                        (CanvasCapStyle)Convert.ToInt32(words[13]),
                        Convert.ToDecimal(words[14]),
                        Convert.ToDecimal(words[15]),
                        Convert.ToDecimal(words[16]),
                        Convert.ToDecimal(words[17]),
                        Convert.ToDecimal(words[18]),
                        Convert.ToDecimal(words[19]),
                        Convert.ToDecimal(words[20]),
                        Convert.ToString(words[21]),
                        Convert.ToDecimal(words[22]),
                        Convert.ToDecimal(words[23]),
                        Convert.ToDecimal(words[24]),
                        Convert.ToDecimal(words[25]),
                        Convert.ToDecimal(words[26]),
                        Convert.ToDecimal(words[27]),
                        Convert.ToDecimal(words[28]),
                        Convert.ToString(words[29]),
                        Convert.ToDecimal(words[30]),
                        Convert.ToDecimal(words[31]),
                        Convert.ToDecimal(words[32]),
                        Convert.ToDecimal(words[33]),
                        Convert.ToDecimal(words[34]),
                        Convert.ToDecimal(words[35]),
                        Convert.ToDecimal(words[36]),
                        Convert.ToDecimal(words[37]));

                    Model.Sections.AddNewSection(tmpSection.Name, tmpSection.E, tmpSection.I, tmpSection.Area,
                        tmpSection.Density, tmpSection.CostPerLength, tmpSection.Alpha, tmpSection.Red, tmpSection.Green, tmpSection.Blue,
                        tmpSection.Line, tmpSection.LineWeight, tmpSection.NearCapStyle, tmpSection.FarCapStyle,
                        tmpSection.CostHorizontalTransport, tmpSection.CostVerticalTransport, tmpSection.CostNodeFixed,
                        tmpSection.CostNodeFree, tmpSection.CostNodePinned, tmpSection.CostNodeRoller, tmpSection.CostNodeTrack,
                        tmpSection.SectionProfile, tmpSection.SectionProfileProperty1, tmpSection.SectionProfileProperty2, tmpSection.SectionProfileProperty3, tmpSection.SectionProfileProperty4, tmpSection.SectionProfileProperty5,
                        tmpSection.SectionProfileProperty6, tmpSection.SectionProfileProperty7,
                        tmpSection.Material,
                        tmpSection.MaintenancePerLength,
                        tmpSection.MaintenanceNodeFree,
                        tmpSection.MaintenanceFixed,
                        tmpSection.MaintenancePinned,
                        tmpSection.MaintenanceRoller,
                        tmpSection.MaintenanceTrack,
                        tmpSection.FactorVerticalTransport,
                        tmpSection.FactorHorizontalTransport);
                }

                Model.Sections.CurrentSection = Model.Sections.LoadLastCurrentSectionSection();
            }
            catch
            {
                Debug.WriteLine("Failed to load sections.");

                // Model.Sections.AddNewSection("Default", 200000000000m, 0.000022m, 0.1m, 2450m, 100m, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Solid Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                try
                {
                    Model.Sections.CurrentSection = Model.Sections.LoadLastCurrentSectionSection();
                }
                catch (Exception ex2)
                {
                    Debug.WriteLine("Error Setting Current Section " + ex2.Message);
                }

                StorageFile tempFile = await localFolder.CreateFileAsync("Sections.Data", CreationCollisionOption.ReplaceExisting);

                string tempString = "Default|200000000000|0.0000666666666666666666666667|0.0200|2450|2.0000|255|192|192|192|0|3.2|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.1|0.200|0|0|0|0|0|Default|0|0|0|0|0|0|0|0|\n";
                tempString += "Steel 150 UB 18|200000000000|0.0000085391265302666666666667|0.00239372|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.075|0.155|0.0083|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|\n";
                tempString += "Steel 200 UB 30|200000000000|0.0000267427055096|0.00380472|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.134|0.207|0.0083|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|\n";
                tempString += "Steel 250 UB 37|200000000000|0.0000502116060000000000000000|0.004770|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.146|0.256|0.009|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|\n";
                tempString += "Steel 410 UB 60|200000000000|0.0001961423633750000000000000|0.00778050|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.178|0.4060|0.0105|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|\n";
                tempString += "Steel 610 UB 125|200000000000|0.0008849453840416666666666667|0.01610450|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.229|0.6120|0.0155|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|\n";
                tempString += "Concrete 100x100 25MPa|200000000000|0.0000083333333333333333333333|0.01|2450|2.61|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Square|0.1|0|0|0|0|0|0|Concrete 25MPa|0|0|0|0|0|0|0|0|\n";
                tempString += "Concrete 200x200 25MPa|200000000000|0.0001333333333333333333333333|0.04000000|2450|10.44000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Square|0.2000|0|0|0|0|0|0|Concrete 25MPa|0|0|0|0|0|0|0|0|\n";
                tempString += "Concrete 300x300 25MPa|200000000000|0.000675000000|0.090000|2450|23.490000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Square|0.300|0|0|0|0|0|0|Concrete 25MPa|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 70x35|200000000000|0.0000010004166666666666666667|0.002450|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.035|0.070|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 90x35|200000000000|0.000002126250|0.003150|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.035|0.090|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 70x45|200000000000|0.0000005315625|0.003150|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.070|0.045|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 90x45|200000000000|0.000002733750|0.004050|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.045|0.090|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 100x100|200000000000|0.000022|0.1|2450|100|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0|0|0|0|0|0|0|Default|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 165x65|200000000000|0.00002433234375|0.010725|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.065|0.165|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|\n";
                tempString += "Timber 260x65|200000000000|0.0000952033333333333333333333|0.016900|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.065|0.260|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|\n";

                await FileIO.WriteTextAsync(tempFile, tempString);

                // await FileIO.WriteTextAsync(tempFile, "Default|200000000000|0.0000666666666666666666666667|0.0200|2450|2.0000|255|192|192|192|0|3.2|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.1|0.200|0|0|0|0|0|Default|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Steel 150 UB 18|200000000000|0.0000085391265302666666666667|0.00239372|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.075|0.155|0.0083|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Steel 200 UB 30|200000000000|0.0000267427055096|0.00380472|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.134|0.207|0.0083|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Steel 250 UB 37|200000000000|0.0000502116060000000000000000|0.004770|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.146|0.256|0.009|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Steel 410 UB 60|200000000000|0.0001961423633750000000000000|0.00778050|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.178|0.4060|0.0105|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Steel 610 UB 125|200000000000|0.0008849453840416666666666667|0.01610450|2450|0.00000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|I Beam|0.229|0.6120|0.0155|0|0|0|0|Steel, Structural|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Concrete 100x100 25MPa|200000000000|0.0000083333333333333333333333|0.01|2450|2.61|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Square|0.1|0|0|0|0|0|0|Concrete 25MPa|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Concrete 200x200 25MPa|200000000000|0.0001333333333333333333333333|0.04000000|2450|10.44000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Square|0.2000|0|0|0|0|0|0|Concrete 25MPa|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Concrete 300x300 25MPa|200000000000|0.000675000000|0.090000|2450|23.490000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Square|0.300|0|0|0|0|0|0|Concrete 25MPa|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 70x35|200000000000|0.0000010004166666666666666667|0.002450|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.035|0.070|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 90x35|200000000000|0.000002126250|0.003150|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.035|0.090|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 70x45|200000000000|0.0000005315625|0.003150|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.070|0.045|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 90x45|200000000000|0.000002733750|0.004050|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.045|0.090|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 100x100|200000000000|0.000022|0.1|2450|100|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0|0|0|0|0|0|0|Default|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 165x65|200000000000|0.00002433234375|0.010725|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.065|0.165|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|");
                // await FileIO.WriteTextAsync(tempFile, "Timber 260x65|200000000000|0.0000952033333333333333333333|0.016900|2450|0.000000|255|192|192|192|0|1.5|2|2|0|0|0|0|0|0|0|Solid Rectangle|0.065|0.260|0|0|0|0|0|Timber, Douglas Fur|0|0|0|0|0|0|0|0|");
                Model.Sections.CurrentSection = Model.Sections["Default"];
                await Task.Run(() => SaveSectionsAsync());

                await Task.Run(() => LoadSectionsAsync());
            }

            Section tempSection = Model.Sections.LoadLastCurrentSectionSection();
            Model.Sections.CurrentSection = new Section(tempSection.Name, tempSection.E, tempSection.I, tempSection.Area,
                tempSection.Density, tempSection.CostPerLength, tempSection.Alpha, tempSection.Red, tempSection.Green, tempSection.Blue,
                tempSection.Line, tempSection.LineWeight, tempSection.NearCapStyle, tempSection.FarCapStyle,
                tempSection.CostHorizontalTransport, tempSection.CostVerticalTransport, tempSection.CostNodeFixed,
                tempSection.CostNodeFree, tempSection.CostNodePinned, tempSection.CostNodeRoller, tempSection.CostNodeTrack,
                tempSection.SectionProfile, tempSection.SectionProfileProperty1, tempSection.SectionProfileProperty2, tempSection.SectionProfileProperty3, tempSection.SectionProfileProperty4, tempSection.SectionProfileProperty5,
                tempSection.SectionProfileProperty6, tempSection.SectionProfileProperty7,
                tempSection.Material,
                tempSection.MaintenancePerLength,
                tempSection.MaintenanceNodeFree,
                tempSection.MaintenanceFixed,
                tempSection.MaintenancePinned,
                tempSection.MaintenanceRoller,
                tempSection.MaintenanceTrack,
                tempSection.FactorVerticalTransport,
                tempSection.FactorHorizontalTransport);

            return Model.Sections.Count;
        }

        internal static async void SaveSectionsAsync()
        {
            SectionsFile = await localFolder.GetFileAsync("Sections.Data");

            IList<String> lines = new List<string>();
            foreach (var Item in Model.Sections)
            {
                string Line = Item.Value.Name.ToString() + "|";
                Line += Item.Value.E.ToString() + "|";
                Line += Item.Value.I.ToString() + "|";
                Line += Item.Value.Area.ToString() + "|";
                Line += Item.Value.Density.ToString() + "|";
                Line += Item.Value.CostPerLength.ToString() + "|";
                Line += Item.Value.Alpha.ToString() + "|";
                Line += Item.Value.Red.ToString() + "|";
                Line += Item.Value.Green.ToString() + "|";
                Line += Item.Value.Blue.ToString() + "|";
                Line += Convert.ToInt32(Item.Value.Line).ToString() + "|";
                Line += Item.Value.LineWeight.ToString() + "|";
                Line += Convert.ToInt32(Item.Value.NearCapStyle).ToString() + "|";
                Line += Convert.ToInt32(Item.Value.FarCapStyle).ToString() + "|";

                Line += Item.Value.CostHorizontalTransport.ToString() + "|";
                Line += Item.Value.CostVerticalTransport.ToString() + "|";
                Line += Item.Value.CostNodeFixed.ToString() + "|";
                Line += Item.Value.CostNodeFree.ToString() + "|";
                Line += Item.Value.CostNodePinned.ToString() + "|";
                Line += Item.Value.CostNodeRoller.ToString() + "|";
                Line += Item.Value.CostNodeTrack.ToString() + "|";

                Line += Item.Value.SectionProfile.ToString() + "|";
                Line += Item.Value.SectionProfileProperty1.ToString() + "|";
                Line += Item.Value.SectionProfileProperty2.ToString() + "|";
                Line += Item.Value.SectionProfileProperty3.ToString() + "|";
                Line += Item.Value.SectionProfileProperty4.ToString() + "|";
                Line += Item.Value.SectionProfileProperty5.ToString() + "|";
                Line += Item.Value.SectionProfileProperty6.ToString() + "|";
                Line += Item.Value.SectionProfileProperty7.ToString() + "|";
                Line += Item.Value.Material.ToString() + "|";

                Line += Item.Value.MaintenancePerLength.ToString() + "|";
                Line += Item.Value.MaintenanceNodeFree.ToString() + "|";
                Line += Item.Value.MaintenanceFixed.ToString() + "|";
                Line += Item.Value.MaintenancePinned.ToString() + "|";
                Line += Item.Value.MaintenanceRoller.ToString() + "|";
                Line += Item.Value.MaintenanceTrack.ToString() + "|";
                Line += Item.Value.FactorVerticalTransport.ToString() + "|";
                Line += Item.Value.FactorHorizontalTransport.ToString() + "|";

                lines.Add(Line);
            }

            await FileIO.WriteLinesAsync(SectionsFile, lines);
            CachedFileManager.DeferUpdates(SectionsFile);
            FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(SectionsFile);
        }

        #endregion

        public static async Task<bool> PickFileToLoad()
        {
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            openPicker.FileTypeFilter.Add(".struct");
            openPicker.FileTypeFilter.Add(".csv");
            NextFile = null;
            NextFile = await openPicker.PickSingleFileAsync();

            if (NextFile is null)
            {
                // Open File Picker Failed.
                return false;
            }
            else
            {
                // New File was picked.
                WorkingFile = NextFile;
                var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                string mruToken = mru.Add(WorkingFile, WorkingFile.Path);
                var listToken = StorageApplicationPermissions.FutureAccessList.Add(WorkingFile);

                WorkingFileDisplayName = WorkingFile.DisplayName;
                WorkingFilePath = WorkingFile.Path;
                WorkingFileMruToken = mruToken;
                WorkingFileListToken = listToken;

                localSettings.Values["WorkingFileDisplayName"] = WorkingFileDisplayName;
                localSettings.Values["WorkingFilePath"] = WorkingFilePath;
                localSettings.Values["WorkingFileMruToken"] = WorkingFileMruToken;
                localSettings.Values["WorkingFileListToken"] = WorkingFileListToken;

                // Debug.WriteLine("Open File Picker : " + WorkingFile.DisplayName + " " + WorkingFile.Path + " " + WorkingFileMruToken);
                return true;
            }
        }

        public static async Task<bool> PickFileToSave()
        {

            FileSavePicker savePicker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            };
            savePicker.FileTypeChoices.Add("Structure Files", new List<string>() { ".struct" });
            savePicker.SuggestedFileName = WorkingFileDisplayName;
            NextFile = null;
            NextFile = await savePicker.PickSaveFileAsync();
            if (NextFile is null)
            {
                // File Picker Failed.
                return false;
            }
            else
            {
                // Picked ok.
                WorkingFile = NextFile;

                var mru = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList;
                string mruToken = mru.Add(WorkingFile, WorkingFile.Path);
                var listToken = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(WorkingFile);

                WorkingFileDisplayName = WorkingFile.DisplayName;
                WorkingFilePath = WorkingFile.Path;
                WorkingFileMruToken = mruToken;
                WorkingFileListToken = listToken;

                localSettings.Values["WorkingFileDisplayName"] = WorkingFileDisplayName;
                localSettings.Values["WorkingFilePath"] = WorkingFilePath;
                localSettings.Values["WorkingFileMruToken"] = WorkingFileMruToken;
                localSettings.Values["WorkingFileListToken"] = WorkingFileListToken;

                return true;
            }
        }
    }
}
