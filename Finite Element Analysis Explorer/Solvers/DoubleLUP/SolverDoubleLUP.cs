using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Core;
using MathNet.Numerics.LinearAlgebra;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI;

namespace Finite_Element_Analysis_Explorer
{
    public class SolverDoubleLUP : ISolver
    {
        #region Properties

        #region ISolver Interface

        private Page _parent;
        public Page Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private bool _HasErrors;
        public bool HasErrors
        {
            get { return _HasErrors; }
            set { _HasErrors = value; }
        }

        #endregion      

        #endregion

        #region Constructor

        public SolverDoubleLUP(Page parent)
        {
            _parent = parent;
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
