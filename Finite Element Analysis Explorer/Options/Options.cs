namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Options static class manages the options for the application.
    /// </summary>
    internal static class Options
    {
        private static bool lockNumericalInput = false;
        private static decimal lastNumericalInput = 0;
        private static int defaultNumberOfSegments = 10;
        private static string lastCurrentSectionName = "Default";
        private static bool resetExistingMembers = true;

        /// <summary>
        /// Gets the Color options.
        /// </summary>
        internal static OptionsColors Colors { get; } = new OptionsColors();

        /// <summary>
        /// Gets the Unit options.
        /// </summary>
        internal static OptionsUnits Units { get; } = new OptionsUnits();

        /// <summary>
        /// Gets the line options.
        /// </summary>
        internal static OptionsLines Lines { get; } = new OptionsLines();

        /// <summary>
        /// Gets the display options.
        /// </summary>
        internal static OptionsDisplay Display { get; } = new OptionsDisplay();

        /// <summary>
        /// Gets the solver options.
        /// </summary>
        internal static OptionsSolvers Solvers { get; } = new OptionsSolvers();

        /// <summary>
        /// Gets or sets a value indicating whether the application has run before.
        /// </summary>
        internal static bool FirstRun { get; set; } = true;

        /// <summary>
        /// Gets or sets the Id. A GUID generated randomly to identify the application install.
        /// </summary>
        internal static string Id { get; set; }

        /// <summary>
        /// Gets or sets the selected grid size.
        /// </summary>
        internal static float SelectGridSize { get; set; } = 1f;

        /// <summary>
        /// Gets or sets a value indicating whether the numerical input is locked.
        /// </summary>
        public static bool LockNumericalInput
        {
            get { return lockNumericalInput; }
            set { lockNumericalInput = value; }
        }

        /// <summary>
        /// Gets or sets the last numerical input.
        /// </summary>
        public static decimal LastNumericalInput
        {
            get { return lastNumericalInput; }
            set { lastNumericalInput = value; }
        }

        /// <summary>
        /// Gets or sets the default number of segments for a member.
        /// </summary>
        internal static int DefaultNumberOfSegments
        {
            get
            {
                return defaultNumberOfSegments;
            }

            set
            {
                defaultNumberOfSegments = value;
            }
        }

        /// <summary>
        /// Gets the last current section name.
        /// </summary>
        internal static string LastCurrentSectionName
        {
            get
            {
                return lastCurrentSectionName;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to reset existing members.
        /// </summary>
        public static bool ResetExistingMembers
        {
            get { return resetExistingMembers; }
            set { resetExistingMembers = value; }
        }

        /// <summary>
        /// Loads the options from the Application Data Container named LocalSettings.
        /// </summary>
        internal static void LoadOptions()
        {
            if (FileManager.LocalSettings.Values["FirstRun"] is object)
            {
                FirstRun = (bool)FileManager.LocalSettings.Values["FirstRun"];
            }
            else
            {
                FileManager.LocalSettings.Values["FirstRun"] = true;
                FirstRun = true;
            }

            if (FirstRun)
            {
                Id = Guid.NewGuid().ToString();
                FileManager.LocalSettings.Values["Id"] = Id;

                FileManager.LocalSettings.Values["LockNumericalInput"] = false;
                lockNumericalInput = false;

                FileManager.LocalSettings.Values["defaultNumberOfSegments"] = defaultNumberOfSegments;
                defaultNumberOfSegments = 10;

                FileManager.LocalSettings.Values["ResetExistingMembers"] = true;
                resetExistingMembers = true;

                FileManager.LocalSettings.Values["lastCurrentSection"] = "Default";
                lastCurrentSectionName = "Default";

                FileManager.LocalSettings.Values["SelectGridSize"] = 1f;
                SelectGridSize = 1f;
            }

            if (FileManager.LocalSettings.Values["Id"] is object)
            {
                Id = (string)FileManager.LocalSettings.Values["Id"];
            }

            try
            {
                lockNumericalInput = (bool)FileManager.LocalSettings.Values["LockNumericalInput"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["LockNumericalInput"] = false;
                lockNumericalInput = false;
                WService.ReportException(ex);
            }

            try
            {
                defaultNumberOfSegments = (int)FileManager.LocalSettings.Values["defaultNumberOfSegments"];
                if (defaultNumberOfSegments < 1)
                {
                    defaultNumberOfSegments = 1;
                }
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["defaultNumberOfSegments"] = defaultNumberOfSegments;
                defaultNumberOfSegments = 10;
                WService.ReportException(ex);
            }

            try
            {
                resetExistingMembers = (bool)FileManager.LocalSettings.Values["ResetExistingMembers"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ResetExistingMembers"] = true;
                resetExistingMembers = true;
                WService.ReportException(ex);
            }

            try
            {
                lastCurrentSectionName = (string)FileManager.LocalSettings.Values["lastCurrentSection"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["lastCurrentSection"] = "Default";
                lastCurrentSectionName = "Default";
                WService.ReportException(ex);
            }

            if (lastCurrentSectionName is null)
            {
                lastCurrentSectionName = "Default";
            }

            if (string.IsNullOrEmpty(lastCurrentSectionName.Trim()))
            {
                lastCurrentSectionName = "Default";
            }

            try
            {
                SelectGridSize = Convert.ToSingle(FileManager.LocalSettings.Values["SelectGridSize"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading SelectGridSize");
                FileManager.LocalSettings.Values["SelectGridSize"] = 1f;
                SelectGridSize = 1f;
            }
        }

        /// <summary>
        /// Saves the options to the Application Data Container named LocalSettings.
        /// </summary>
        internal static void SaveOptions()
        {
            FileManager.LocalSettings.Values["FirstRun"] = FirstRun;
            FileManager.LocalSettings.Values["Id"] = Id;
            FileManager.LocalSettings.Values["SelectGridSize"] = (float)SelectGridSize;
            FileManager.LocalSettings.Values["LockNumericalInput"] = lockNumericalInput;
            FileManager.LocalSettings.Values["defaultNumberOfSegments"] = defaultNumberOfSegments;
            FileManager.LocalSettings.Values["lastCurrentSection"] = lastCurrentSectionName;
            FileManager.LocalSettings.Values["ResetExistingMembers"] = resetExistingMembers;
        }
    }
}