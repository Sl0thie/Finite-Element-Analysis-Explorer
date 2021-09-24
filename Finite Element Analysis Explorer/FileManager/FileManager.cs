namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Numerics;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Graphics.Canvas.Geometry;
    using Windows.Storage;
    using Windows.Storage.AccessCache;
    using Windows.Storage.Pickers;
    using Windows.Storage.Provider;
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
                    var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                    string mruToken = mru.Add(workingFile, workingFile.Path);
                    var listToken = StorageApplicationPermissions.FutureAccessList.Add(workingFile);

                    workingFileDisplayName = workingFile.DisplayName;
                    workingFilePath = workingFile.Path;
                    workingFileMruToken = mruToken;
                    workingFileListToken = listToken;

                    LocalSettings.Values["WorkingFileDisplayName"] = workingFileDisplayName;
                    LocalSettings.Values["WorkingFilePath"] = workingFilePath;
                    LocalSettings.Values["WorkingFileMruToken"] = workingFileMruToken;
                    LocalSettings.Values["WorkingFileListToken"] = workingFileListToken;

                    await SaveFile();
                    await LoadFile();
                    return;
                }
            }

            // Picking new file failed.
            if (Options.FirstRun)
            {
                var dialog = new MessageDialog("You must specify a file to save the drawing data too for the application to work with. No file chosen, exiting application.");
                await dialog.ShowAsync();
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
                       rootFrame.Navigate(typeof(FileLoading));
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

            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = workingFileDisplayName;

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

        /// <summary>
        /// Loads the last file.
        /// </summary>
        internal static async void LoadLastFileAsync()
        {
            try
            {
                if (Options.FirstRun)
                {
                    var uriHelpGeneral = new Uri(@"http://intacomputers.com/Software/FEA/FiniteElementAnalysisExplorer/Help/QuickStart.aspx");
                    var success = await Windows.System.Launcher.LaunchUriAsync(uriHelpGeneral, new Windows.System.LauncherOptions() { DisplayApplicationPicker = false });
                    // Options.FirstRun = false;
                    NewFile();
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(Construction));
                }
                else
                {
                    workingFileMruToken = (string)LocalSettings.Values["WorkingFileMruToken"];
                    var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                    workingFile = await mru.GetFileAsync(workingFileMruToken);
                    await LoadFile();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR LoadLastFileAsync " + ex.Message + " " + ex.Data.ToString() + " " + ex.StackTrace);
                NewFile();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Construction));
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
                    foreach (var node in Model.Nodes)
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
                    foreach (var member in Model.Members)
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
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(workingFile);
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
                    foreach (var node in Model.Nodes)
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
                    foreach (var member in Model.Members)
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
                    FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(workingFile);
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
                await SaveFile();
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
        internal static int LoadMaterialsAsync()
        {
            try
            {
                MaterialsList.LoadList();
                SectionProfilesList.LoadList();
            }
            catch
            {
            }

            return Model.Materials.Count;
        }

        /// <summary>
        /// Save the materials to disk.
        /// </summary>
        internal static async void SaveMaterialsAsync()
        {
            materialsFile = await LocalFolder.GetFileAsync("Materials.Data");

            IList<string> lines = new List<string>();
            foreach (var material in Model.Materials)
            {
                string line = material.Value.Name.ToString() + "|";
                line += material.Value.Description.ToString() + "|";
                line += material.Value.Cost.ToString() + "|";
                line += material.Value.Density.ToString() + "|";
                line += material.Value.UltimateStrengthTension.ToString() + "|";
                line += material.Value.UltimateStrengthCompression.ToString() + "|";
                line += material.Value.UltimateStrengthShear.ToString() + "|";
                line += material.Value.YieldStrengthTension.ToString() + "|";
                line += material.Value.YieldStrengthShear.ToString() + "|";
                line += material.Value.ModulusOfElasticity.ToString() + "|";
                line += material.Value.ModulusOfRigidity.ToString() + "|";
                line += material.Value.CoefficientOfThermalExpansion.ToString() + "|";
                line += material.Value.Ductility.ToString() + "|";

                line += material.Value.Atomic_Number.ToString() + "|";
                line += material.Value.Symbol.ToString() + "|";
                line += material.Value.Atomic_Mass.ToString() + "|";
                line += material.Value.Allotrope_Names.ToString() + "|";
                line += material.Value.Alternate_Names.ToString() + "|";
                line += material.Value.CAS_Number.ToString() + "|";
                line += material.Value.Icon_Color.ToString() + "|";
                line += material.Value.Block.ToString() + "|";
                line += material.Value.Group.ToString() + "|";
                line += material.Value.Period.ToString() + "|";
                line += material.Value.Series.ToString() + "|";
                line += material.Value.Atomic_Weight.ToString() + "|";
                line += material.Value.Brinell_Hardness.ToString() + "|";
                line += material.Value.Bulk_Modulus.ToString() + "|";
                line += material.Value.Liquid_Density.ToString() + "|";
                line += material.Value.Mohs_Hardness.ToString() + "|";
                line += material.Value.Molar_Volume.ToString() + "|";
                line += material.Value.Poission_Ratio.ToString() + "|";
                line += material.Value.ModulusOfRigidity.ToString() + "|";
                line += material.Value.Sound_Speed.ToString() + "|";
                line += material.Value.Thermal_Conductivity.ToString() + "|";
                line += material.Value.Thermal_Expansion.ToString() + "|";
                line += material.Value.Vickers_Hardness.ToString() + "|";
                line += material.Value.ModulusOfElasticity.ToString() + "|";
                line += material.Value.Absolute_Boiling_Point.ToString() + "|";
                line += material.Value.Absolute_Melting_Point.ToString() + "|";
                line += material.Value.Adiabatic_Index.ToString() + "|";
                line += material.Value.Boiling_Point.ToString() + "|";
                line += material.Value.Critical_Pressure.ToString() + "|";
                line += material.Value.Critical_Temperature.ToString() + "|";
                line += material.Value.Curie_Point.ToString() + "|";
                line += material.Value.Fusion_Heat.ToString() + "|";
                line += material.Value.Melting_Point.ToString() + "|";
                line += material.Value.Neel_Point.ToString() + "|";
                line += material.Value.Phase.ToString() + "|";
                line += material.Value.Specific_Heat.ToString() + "|";
                line += material.Value.Superconducting_Point.ToString() + "|";
                line += material.Value.Vaporization_Heat.ToString() + "|";
                line += material.Value.Color.ToString() + "|";
                line += material.Value.Electrical_Conductivity.ToString() + "|";
                line += material.Value.Electrical_Type.ToString() + "|";
                line += material.Value.Magnetic_Type.ToString() + "|";
                line += material.Value.Mass_Magnetic_Susceptibility.ToString() + "|";
                line += material.Value.Molar_Magnetic_Susceptibility.ToString() + "|";
                line += material.Value.Resistivity.ToString() + "|";
                line += material.Value.Volume_Magnetic_Susceptibility.ToString() + "|";
                line += material.Value.Allotropic_Multiplicities.ToString() + "|";
                line += material.Value.Electron_Affinity.ToString() + "|";
                line += material.Value.Gas_Atomic_Multiplicities.ToString() + "|";
                line += material.Value.Valence.ToString() + "|";
                line += material.Value.Crystal_Structure.ToString() + "|";
                line += material.Value.Lattice_Angles.ToString() + "|";
                line += material.Value.Lattice_Constants.ToString() + "|";
                line += material.Value.Space_Group_Number.ToString() + "|";
                line += material.Value.Space_Group_Name.ToString() + "|";
                line += material.Value.Atomic_Radius.ToString() + "|";
                line += material.Value.Covalent_Radius.ToString() + "|";
                line += material.Value.Electron_Configuration.ToString() + "|";
                line += material.Value.Electron_Configuration_String.ToString() + "|";
                line += material.Value.Electron_Shell_Configuration.ToString() + "|";
                line += material.Value.Ionization_Energies.ToString() + "|";
                line += material.Value.Quantum_Numbers.ToString() + "|";
                line += material.Value.Van_Der_Waals_Radius.ToString() + "|";
                line += material.Value.Decay_Mode.ToString() + "|";
                line += material.Value.HalfLife.ToString() + "|";
                line += material.Value.Isotope_Abundances.ToString() + "|";
                line += material.Value.Lifetime.ToString() + "|";
                line += material.Value.Neutron_Cross_Section.ToString() + "|";
                line += material.Value.Neutron_Mass_Absorption.ToString() + "|";
                line += material.Value.Radioactive.ToString() + "|";
                line += material.Value.Stable_Isotopes.ToString() + "|";
                line += material.Value.Crust_Abundance.ToString() + "|";
                line += material.Value.Human_Abundance.ToString() + "|";
                line += material.Value.Meteorite_Abundance.ToString() + "|";
                line += material.Value.Ocean_Abundance.ToString() + "|";
                line += material.Value.Solar_Abundance.ToString() + "|";
                line += material.Value.Universe_Abundance.ToString() + "|";
                line += material.Value.Radius_Empirical.ToString() + "|";
                line += material.Value.Radius_Calculated.ToString() + "|";
                line += material.Value.Radius_Van_Der_Waals.ToString() + "|";
                line += material.Value.Radius_Covalent_Single_Bond.ToString() + "|";
                line += material.Value.Radius_Covalent_Triple_Bond.ToString() + "|";
                line += material.Value.Radius_Metallic.ToString() + "||||||||||||";

                lines.Add(line);
            }

            await FileIO.WriteLinesAsync(materialsFile, lines);
            CachedFileManager.DeferUpdates(materialsFile);
            FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(materialsFile);
        }

        #region Sections

        /// <summary>
        /// Loads the sections from disk.
        /// </summary>
        /// <returns>True if successful.</returns>
        internal static async Task<int> LoadSectionsAsync()
        {
            try
            {
                if (await LocalFolder.TryGetItemAsync("Sections.Data") == null)
                {
                    StorageFile tempFile = await LocalFolder.CreateFileAsync("Sections.Data", CreationCollisionOption.ReplaceExisting);
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
                }

                sectionsFile = await LocalFolder.GetFileAsync("Sections.Data");
                IList<string> lines = new List<string>();
                lines = await FileIO.ReadLinesAsync(sectionsFile);
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

                    Model.Sections.AddNewSection(
                        tmpSection.Name,
                        tmpSection.E,
                        tmpSection.I,
                        tmpSection.Area,
                        tmpSection.Density,
                        tmpSection.CostPerLength,
                        tmpSection.Alpha,
                        tmpSection.Red,
                        tmpSection.Green,
                        tmpSection.Blue,
                        tmpSection.Line,
                        tmpSection.LineWeight,
                        tmpSection.NearCapStyle,
                        tmpSection.FarCapStyle,
                        tmpSection.CostHorizontalTransport,
                        tmpSection.CostVerticalTransport,
                        tmpSection.CostNodeFixed,
                        tmpSection.CostNodeFree,
                        tmpSection.CostNodePinned,
                        tmpSection.CostNodeRoller,
                        tmpSection.CostNodeTrack,
                        tmpSection.SectionProfile,
                        tmpSection.SectionProfileProperty1,
                        tmpSection.SectionProfileProperty2,
                        tmpSection.SectionProfileProperty3,
                        tmpSection.SectionProfileProperty4,
                        tmpSection.SectionProfileProperty5,
                        tmpSection.SectionProfileProperty6,
                        tmpSection.SectionProfileProperty7,
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
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load sections. " + ex.Message);
                WService.ReportException(ex);
            }

            Section tempSection = Model.Sections.LoadLastCurrentSectionSection();
            Model.Sections.CurrentSection = new Section(
                                                        tempSection.Name,
                                                        tempSection.E,
                                                        tempSection.I,
                                                        tempSection.Area,
                                                        tempSection.Density,
                                                        tempSection.CostPerLength,
                                                        tempSection.Alpha,
                                                        tempSection.Red,
                                                        tempSection.Green,
                                                        tempSection.Blue,
                                                        tempSection.Line,
                                                        tempSection.LineWeight,
                                                        tempSection.NearCapStyle,
                                                        tempSection.FarCapStyle,
                                                        tempSection.CostHorizontalTransport,
                                                        tempSection.CostVerticalTransport,
                                                        tempSection.CostNodeFixed,
                                                        tempSection.CostNodeFree,
                                                        tempSection.CostNodePinned,
                                                        tempSection.CostNodeRoller,
                                                        tempSection.CostNodeTrack,
                                                        tempSection.SectionProfile,
                                                        tempSection.SectionProfileProperty1,
                                                        tempSection.SectionProfileProperty2,
                                                        tempSection.SectionProfileProperty3,
                                                        tempSection.SectionProfileProperty4,
                                                        tempSection.SectionProfileProperty5,
                                                        tempSection.SectionProfileProperty6,
                                                        tempSection.SectionProfileProperty7,
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

        /// <summary>
        /// Save the sections to disk.
        /// </summary>
        internal static async void SaveSectionsAsync()
        {
            sectionsFile = await LocalFolder.GetFileAsync("Sections.Data");

            IList<string> lines = new List<string>();
            foreach (var section in Model.Sections)
            {
                string line = section.Value.Name.ToString() + "|";
                line += section.Value.E.ToString() + "|";
                line += section.Value.I.ToString() + "|";
                line += section.Value.Area.ToString() + "|";
                line += section.Value.Density.ToString() + "|";
                line += section.Value.CostPerLength.ToString() + "|";
                line += section.Value.Alpha.ToString() + "|";
                line += section.Value.Red.ToString() + "|";
                line += section.Value.Green.ToString() + "|";
                line += section.Value.Blue.ToString() + "|";
                line += Convert.ToInt32(section.Value.Line).ToString() + "|";
                line += section.Value.LineWeight.ToString() + "|";
                line += Convert.ToInt32(section.Value.NearCapStyle).ToString() + "|";
                line += Convert.ToInt32(section.Value.FarCapStyle).ToString() + "|";

                line += section.Value.CostHorizontalTransport.ToString() + "|";
                line += section.Value.CostVerticalTransport.ToString() + "|";
                line += section.Value.CostNodeFixed.ToString() + "|";
                line += section.Value.CostNodeFree.ToString() + "|";
                line += section.Value.CostNodePinned.ToString() + "|";
                line += section.Value.CostNodeRoller.ToString() + "|";
                line += section.Value.CostNodeTrack.ToString() + "|";

                line += section.Value.SectionProfile.ToString() + "|";
                line += section.Value.SectionProfileProperty1.ToString() + "|";
                line += section.Value.SectionProfileProperty2.ToString() + "|";
                line += section.Value.SectionProfileProperty3.ToString() + "|";
                line += section.Value.SectionProfileProperty4.ToString() + "|";
                line += section.Value.SectionProfileProperty5.ToString() + "|";
                line += section.Value.SectionProfileProperty6.ToString() + "|";
                line += section.Value.SectionProfileProperty7.ToString() + "|";
                line += section.Value.Material.ToString() + "|";

                line += section.Value.MaintenancePerLength.ToString() + "|";
                line += section.Value.MaintenanceNodeFree.ToString() + "|";
                line += section.Value.MaintenanceFixed.ToString() + "|";
                line += section.Value.MaintenancePinned.ToString() + "|";
                line += section.Value.MaintenanceRoller.ToString() + "|";
                line += section.Value.MaintenanceTrack.ToString() + "|";
                line += section.Value.FactorVerticalTransport.ToString() + "|";
                line += section.Value.FactorHorizontalTransport.ToString() + "|";

                lines.Add(line);
            }

            await FileIO.WriteLinesAsync(sectionsFile, lines);
            CachedFileManager.DeferUpdates(sectionsFile);
            FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(sectionsFile);
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
                var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                string mruToken = mru.Add(workingFile, workingFile.Path);
                var listToken = StorageApplicationPermissions.FutureAccessList.Add(workingFile);

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

                var mru = StorageApplicationPermissions.MostRecentlyUsedList;
                string mruToken = mru.Add(workingFile, workingFile.Path);
                var listToken = StorageApplicationPermissions.FutureAccessList.Add(workingFile);

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
