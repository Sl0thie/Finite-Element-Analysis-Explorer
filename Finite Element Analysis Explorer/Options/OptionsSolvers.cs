namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                FileManager.LocalSettings.Values["AutoStartSolver"] = (bool)autoStartSolver;
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
                FileManager.LocalSettings.Values["AutoFinishSolver"] = (bool)autoFinishSolver;
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
                FileManager.LocalSettings.Values["GenerateReport"] = (bool)generateReport;
            }
        }

        /// <summary>
        /// Gets or sets the current solver.
        /// </summary>
        public int CurrentSolver
        {
            get { return currentSolver; }
            set
            {
                currentSolver = value;
                FileManager.LocalSettings.Values["CurrentSolver"] = (int)currentSolver;
            }
        }

        internal OptionsSolvers()
        {
            try
            {
                autoStartSolver = (bool)FileManager.LocalSettings.Values["AutoStartSolver"];
                autoFinishSolver = (bool)FileManager.LocalSettings.Values["AutoFinishSolver"];
                generateReport = (bool)FileManager.LocalSettings.Values["GenerateReport"];
                currentSolver = (int)FileManager.LocalSettings.Values["CurrentSolver"];
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}
