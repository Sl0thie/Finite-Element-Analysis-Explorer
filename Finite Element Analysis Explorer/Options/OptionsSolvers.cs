namespace Finite_Element_Analysis_Explorer
{
    using System;

    /// <summary>
    /// OptionsSolvers class manages solver options.
    /// </summary>
    internal class OptionsSolvers
    {
        private bool autoStartSolver = true;
        private bool autoFinishSolver = true;
        private bool generateReport = true;
        private int currentSolver = 0;

        /// <summary>
        /// Gets or sets a value indicating whether to automatically start the solver.
        /// </summary>
        internal bool AutoStartSolver
        {
            get
            {
                return autoStartSolver;
            }

            set
            {
                autoStartSolver = value;
                FileManager.LocalSettings.Values["AutoStartSolver"] = autoStartSolver;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically finish the solver.
        /// </summary>
        internal bool AutoFinishSolver
        {
            get
            {
                return autoFinishSolver;
            }

            set
            {
                autoFinishSolver = value;
                FileManager.LocalSettings.Values["AutoFinishSolver"] = autoFinishSolver;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to generate a report on success.
        /// </summary>
        internal bool GenerateReport
        {
            get
            {
                return generateReport;
            }

            set
            {
                generateReport = value;
                FileManager.LocalSettings.Values["GenerateReport"] = generateReport;
            }
        }

        /// <summary>
        /// Gets or sets the current solver.
        /// </summary>
        public int CurrentSolver
        {
            get
            {
                return currentSolver;
            }

            set
            {
                currentSolver = value;
                FileManager.LocalSettings.Values["CurrentSolver"] = currentSolver;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsSolvers"/> class.
        /// </summary>
        internal OptionsSolvers()
        {
            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("AutoStartSolver"))
                {
                    autoStartSolver = (bool)FileManager.LocalSettings.Values["AutoStartSolver"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("AutoFinishSolver"))
                {
                    autoFinishSolver = (bool)FileManager.LocalSettings.Values["AutoFinishSolver"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("GenerateReport"))
                {
                    generateReport = (bool)FileManager.LocalSettings.Values["GenerateReport"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("CurrentSolver"))
                {
                    currentSolver = (int)FileManager.LocalSettings.Values["CurrentSolver"];
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}
