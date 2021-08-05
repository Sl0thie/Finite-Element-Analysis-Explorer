namespace Finite_Element_Analysis_Explorer
{
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Controls;

    public class SolverDoubleLUP : ISolver
    {
        #region Properties

        #region ISolver Interface

        private Page parent;

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
        /// <param name="parent"></param>
        public SolverDoubleLUP(Page parent)
        {
            this.parent = parent;
            App.CurrentSolverState = SolveState.Solving;
            SolverDisplay.Current.ClearMessages();

            Task.Run(() => SolveModel());
        }

        #endregion

        public void SolveModel()
        {
            SolverFunctions.ResetDisplayAndShowWelcomeMessage();
            SolverFunctions.ResetPropertiesForSolver();
            SolverFunctions.ShrinkModel();
            SolverFunctions.SaveFile();
            SolverFunctions.AssignCodeNumbersToDegreesOfFreedom();
            SolverFunctions.CreateSuperpositionValuesFromSegmentsToNodes();
            SolverFunctions.AssembleStiffnessMatrix();
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
            SolverFunctions.DisplayEndMessages();
        }
    }
}