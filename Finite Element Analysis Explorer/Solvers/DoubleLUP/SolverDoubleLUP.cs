namespace Finite_Element_Analysis_Explorer
{
    using System.Threading.Tasks;

    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// SolverDoubleLUP ISolver.
    /// </summary>
    public class SolverDoubleLUP : ISolver
    {
        #region Properties

        #region ISolver Interface

        private Page parent;

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        public Page Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        private bool hasErrors;

        /// <summary>
        /// Gets or sets a value indicating whether there are errors.
        /// </summary>
        public bool HasErrors
        {
            get { return hasErrors; }
            set { hasErrors = value; }
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SolverDoubleLUP"/> class.
        /// </summary>
        /// <param name="parent">The parent page.</param>
        public SolverDoubleLUP(Page parent)
        {
            this.parent = parent;
            App.CurrentSolverState = SolveState.Solving;
            SolverDisplay.Current.ClearMessages();

            _ = Task.Run(() => SolveModel());
        }

        #endregion

        /// <summary>
        /// Solves the model.
        /// </summary>
        public void SolveModel()
        {
            SolverFunctions.ResetDisplayAndShowWelcomeMessage();
            SolverFunctions.ResetPropertiesForSolver();
            SolverFunctions.ShrinkModel();
            SolverFunctions.SaveFile();

            if (!SolverFunctions.AssignCodeNumbersToDegreesOfFreedom())
            {
                return;
            }

            SolverFunctions.CreateSuperpositionValuesFromSegmentsToNodes();

            if (!SolverFunctions.AssembleStiffnessMatrix())
            {
                return;
            }

            SolverFunctions.AssembleKMatrices();
            SolverFunctions.GetQkFromSubNodes();
            SolverFunctions.GetQuFromSubNodes();
            SolverFunctions.GetDkFromSubNodes();
            SolverFunctions.GetDuFromSubNodes();
            SolverFunctions.SolveForDu();
            SolverFunctions.SetDuToSubNodes();
            SolverFunctions.SolveForQu();
            SolverFunctions.SetQuToSubNodes();
            SolverFunctions.UpdateMemberAndSegmentsFromMatrix();
            SolverFunctions.CreateLengthRatioColors();
            SolverFunctions.CreateAxialRatioColors();
            SolverFunctions.CreateNormalStressColors();
            Camera.UpdateAllGraphics();
            SolverFunctions.CalculateEqulibriumValues();
            SolverFunctions.CalculateMaterials();
            SolverFunctions.CalculateLabour();
            SolverFunctions.CalculateCost();
            SolverFunctions.CreateReportAsync();
            SolverFunctions.DisplayEndMessages();
        }
    }
}