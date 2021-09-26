namespace Finite_Element_Analysis_Explorer
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// PanelResultsMember Page.
    /// </summary>
    public sealed partial class PanelResultsMember : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelResultsMember"/> class.
        /// </summary>
        public PanelResultsMember()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Model.Members.CurrentMember is object)
            {
                TextBlock_Title.Text = "Member " + Model.Members.CurrentMember.Index;
                constraintsDisplay_Currrent.DisplayOnly = true;

                TextBlock_SelectedProfile.Text = Model.Members.CurrentMember.Section.SectionProfile;
                TextBlock_SelectedMaterial.Text = Model.Members.CurrentMember.Section.Material;

                doubleValue_NormalStress.DisplayOnly = true;
                doubleValue_NormalStress.UnitType = UnitType.Pressure;
                doubleValue_NormalStress.SetTheValue(Model.Members.CurrentMember.NormalStress);

                doubleValue_DisplacementX.DisplayOnly = true;
                doubleValue_DisplacementX.UnitType = UnitType.Length;
                doubleValue_DisplacementX.Axis = 1;
                doubleValue_DisplacementX.SetValue(Model.Members.CurrentMember.NodeNear.Displacement.X, Model.Members.CurrentMember.NodeFar.Displacement.X);

                doubleValue_DisplacementY.DisplayOnly = true;
                doubleValue_DisplacementY.UnitType = UnitType.Length;
                doubleValue_DisplacementY.Axis = 2;
                doubleValue_DisplacementY.SetValue(Model.Members.CurrentMember.NodeNear.Displacement.Y, Model.Members.CurrentMember.NodeFar.Displacement.Y);

                doubleValue_DisplacementM.DisplayOnly = true;
                doubleValue_DisplacementM.UnitType = UnitType.Angle;
                doubleValue_DisplacementM.Axis = 3;
                doubleValue_DisplacementM.SetValue(Model.Members.CurrentMember.NodeNear.Displacement.M, Model.Members.CurrentMember.NodeFar.Displacement.M);

                doubleValue_LocationX.DisplayOnly = true;
                doubleValue_LocationX.UnitType = UnitType.Length;
                doubleValue_LocationX.Axis = 1;
                doubleValue_LocationX.SetValue(Model.Members.CurrentMember.NodeNear.PositionDisplaced.X, Model.Members.CurrentMember.NodeFar.PositionDisplaced.X);

                doubleValue_LocationY.DisplayOnly = true;
                doubleValue_LocationY.UnitType = UnitType.Length;
                doubleValue_LocationY.Axis = 2;
                doubleValue_LocationY.SetValue(Model.Members.CurrentMember.NodeNear.PositionDisplaced.Y, Model.Members.CurrentMember.NodeFar.PositionDisplaced.Y);

                doubleValue_LocationM.DisplayOnly = true;
                doubleValue_LocationM.UnitType = UnitType.Angle;
                doubleValue_LocationM.Axis = 3;
                doubleValue_LocationM.SetValue(Model.Members.CurrentMember.NodeNear.PositionDisplaced.M, Model.Members.CurrentMember.NodeFar.PositionDisplaced.M);

                doubleValue_ReactionsX.DisplayOnly = true;
                doubleValue_ReactionsX.UnitType = UnitType.Force;
                doubleValue_ReactionsX.Axis = 1;
                doubleValue_ReactionsX.SetValue(Model.Members.CurrentMember.NodeNear.LoadReaction.X, Model.Members.CurrentMember.NodeFar.LoadReaction.X);

                doubleValue_ReactionsY.DisplayOnly = true;
                doubleValue_ReactionsY.UnitType = UnitType.Force;
                doubleValue_ReactionsY.Axis = 2;
                doubleValue_ReactionsY.SetValue(Model.Members.CurrentMember.NodeNear.LoadReaction.Y, Model.Members.CurrentMember.NodeFar.LoadReaction.Y);

                doubleValue_ReactionsM.DisplayOnly = true;
                doubleValue_ReactionsM.UnitType = UnitType.Moment;
                doubleValue_ReactionsM.Axis = 3;
                doubleValue_ReactionsM.SetValue(Model.Members.CurrentMember.NodeNear.LoadReaction.M, Model.Members.CurrentMember.NodeFar.LoadReaction.M);

                doubleValue_InternalLoadsX.DisplayOnly = true;
                doubleValue_InternalLoadsX.UnitType = UnitType.Force;
                doubleValue_InternalLoadsX.Axis = 1;
                doubleValue_InternalLoadsX.SetValue(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.X, Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.X);

                doubleValue_InternalLoadsY.DisplayOnly = true;
                doubleValue_InternalLoadsY.UnitType = UnitType.Force;
                doubleValue_InternalLoadsY.Axis = 2;
                doubleValue_InternalLoadsY.SetValue(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y, Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y);

                doubleValue_InternalLoadsM.DisplayOnly = true;
                doubleValue_InternalLoadsM.UnitType = UnitType.Moment;
                doubleValue_InternalLoadsM.Axis = 3;
                doubleValue_InternalLoadsM.SetValue(-Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M, Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M);

                doubleValue_Length.DisplayOnly = true;
                doubleValue_Length.UnitType = UnitType.Length;
                doubleValue_Length.DisplayOnly = true;
                doubleValue_Length.Title = "Length";
                doubleValue_Length.SetTheValue(Model.Members.CurrentMember.LengthDisplaced);

                doubleValue_LengthXAxis.DisplayOnly = true;
                doubleValue_LengthXAxis.UnitType = UnitType.Length;
                doubleValue_LengthXAxis.DisplayOnly = true;
                doubleValue_LengthXAxis.Title = "Length (X axis)";
                doubleValue_LengthXAxis.SetTheValue(Model.Members.CurrentMember.LengthDisplacedXAxis);

                doubleValue_LengthYAxis.DisplayOnly = true;
                doubleValue_LengthYAxis.UnitType = UnitType.Length;
                doubleValue_LengthYAxis.DisplayOnly = true;
                doubleValue_LengthYAxis.Title = "Length (Y axis)";
                doubleValue_LengthYAxis.SetTheValue(Model.Members.CurrentMember.LengthDisplacedYAxis);

                doubleValue_LengthDifference.DisplayOnly = true;
                doubleValue_LengthDifference.UnitType = UnitType.Length;
                doubleValue_LengthDifference.DisplayOnly = true;
                doubleValue_LengthDifference.Title = "Difference";
                doubleValue_LengthDifference.SetTheValue(Model.Members.CurrentMember.LengthDifference);

                doubleValue_LengthDifferenceXAxis.DisplayOnly = true;
                doubleValue_LengthDifferenceXAxis.UnitType = UnitType.Length;
                doubleValue_LengthDifferenceXAxis.DisplayOnly = true;
                doubleValue_LengthDifferenceXAxis.Title = "Difference (X axis)";
                doubleValue_LengthDifferenceXAxis.SetTheValue(Model.Members.CurrentMember.LengthDifferenceXAxis);

                doubleValue_LengthDifferenceYAxis.DisplayOnly = true;
                doubleValue_LengthDifferenceYAxis.UnitType = UnitType.Length;
                doubleValue_LengthDifferenceYAxis.DisplayOnly = true;
                doubleValue_LengthDifferenceYAxis.Title = "Difference (Y axis)";
                doubleValue_LengthDifferenceYAxis.SetTheValue(Model.Members.CurrentMember.LengthDifferenceYAxis);

                doubleValue_LengthRatio.DisplayOnly = true;
                doubleValue_LengthRatio.UnitType = UnitType.Unitless;
                doubleValue_LengthRatio.DisplayOnly = true;
                doubleValue_LengthRatio.Title = "Length Ratio";
                doubleValue_LengthRatio.SetTheValue(Model.Members.CurrentMember.LengthRatio);

                doubleValue_Angle.DisplayOnly = true;
                doubleValue_Angle.UnitType = UnitType.Angle;
                doubleValue_Angle.Title = "Angle";
                doubleValue_Angle.SetTheValue(Model.Members.CurrentMember.SegmentNear.AngleDisplaced);

                SingleValue_E.DisplayOnly = true;
                SingleValue_E.Title = "Modulus of Elasticity (E)";
                SingleValue_E.UnitType = UnitType.Pressure;
                SingleValue_E.SetTheValue(Model.Members.CurrentMember.Section.E);

                SingleValue_I.DisplayOnly = true;
                SingleValue_I.Title = "Moment of Inertia (I)";
                SingleValue_I.UnitType = UnitType.MomentOfInertia;
                SingleValue_I.SetTheValue(Model.Members.CurrentMember.Section.I);

                SingleValue_Area.DisplayOnly = true;
                SingleValue_Area.Title = "Cross Sectional Area";
                SingleValue_Area.UnitType = UnitType.Area;
                SingleValue_Area.SetTheValue(Model.Members.CurrentMember.Section.Area);

                SingleValue_CostPerMeter.DisplayOnly = true;
                SingleValue_CostPerMeter.Title = "Material";
                SingleValue_CostPerMeter.UnitType = UnitType.Money;
                SingleValue_CostPerMeter.SetTheValue(Model.Members.CurrentMember.Section.CostPerLength);

                SingleValue_CostNearNode.DisplayOnly = true;
                SingleValue_CostNearNode.Title = "Near Node";
                SingleValue_CostNearNode.UnitType = UnitType.Money;
                SingleValue_CostNearNode.SetTheValue(0);

                SingleValue_CostFarNode.DisplayOnly = true;
                SingleValue_CostFarNode.Title = "Far Node";
                SingleValue_CostFarNode.UnitType = UnitType.Money;
                SingleValue_CostFarNode.SetTheValue(0);

                SingleValue_CostElevation.DisplayOnly = true;
                SingleValue_CostElevation.Title = "Elevation";
                SingleValue_CostElevation.UnitType = UnitType.Money;
                SingleValue_CostElevation.SetTheValue(0);

                SingleValue_CostTransport.DisplayOnly = true;
                SingleValue_CostTransport.Title = "Transport";
                SingleValue_CostTransport.UnitType = UnitType.Money;
                SingleValue_CostTransport.SetTheValue(0);

                SingleValue_CostTotal.DisplayOnly = true;
                SingleValue_CostTotal.Title = "Total Cost";
                SingleValue_CostTotal.UnitType = UnitType.Money;
                SingleValue_CostTotal.SetTheValue(0);

                doubleValue_LoadsX.UnitType = UnitType.Force;
                doubleValue_LoadsX.DisplayOnly = false;
                doubleValue_LoadsX.Axis = 1;
                doubleValue_LoadsX.SetValue(Model.Members.CurrentMember.NodeNear.Load.X, Model.Members.CurrentMember.NodeFar.Load.X);

                doubleValue_LoadsY.UnitType = UnitType.Force;
                doubleValue_LoadsY.DisplayOnly = false;
                doubleValue_LoadsY.Axis = 2;
                doubleValue_LoadsY.SetValue(Model.Members.CurrentMember.NodeNear.Load.Y, Model.Members.CurrentMember.NodeFar.Load.Y);

                doubleValue_LoadsM.UnitType = UnitType.Moment;
                doubleValue_LoadsM.DisplayOnly = false;
                doubleValue_LoadsM.Axis = 3;
                doubleValue_LoadsM.SetValue(-Model.Members.CurrentMember.NodeNear.Load.M, Model.Members.CurrentMember.NodeFar.Load.M);

                doubleValue_Linear.UnitType = UnitType.ForcePerLength;
                doubleValue_Linear.DisplayOnly = false;
                doubleValue_Linear.Axis = 4;
                doubleValue_Linear.SetValue(Model.Members.CurrentMember.LDLNear, Model.Members.CurrentMember.LDLFar);

                doubleValue_SuperpositionLocalX.DisplayOnly = true;
                doubleValue_SuperpositionLocalY.DisplayOnly = true;
                doubleValue_SuperpositionLocalM.DisplayOnly = true;
                doubleValue_SuperpositionLocalX.Axis = 1;
                doubleValue_SuperpositionLocalY.Axis = 2;
                doubleValue_SuperpositionLocalM.Axis = 3;
                doubleValue_SuperpositionLocalX.UnitType = UnitType.Force;
                doubleValue_SuperpositionLocalY.UnitType = UnitType.Force;
                doubleValue_SuperpositionLocalM.UnitType = UnitType.Moment;
                doubleValue_SuperpositionLocalX.SetValue(Model.Members.CurrentMember.NodeNear.SuperPosition.X, Model.Members.CurrentMember.NodeFar.SuperPosition.X);
                doubleValue_SuperpositionLocalY.SetValue(Model.Members.CurrentMember.NodeNear.SuperPosition.Y, Model.Members.CurrentMember.NodeFar.SuperPosition.Y);
                doubleValue_SuperpositionLocalM.SetValue(Model.Members.CurrentMember.NodeNear.SuperPosition.M, Model.Members.CurrentMember.NodeFar.SuperPosition.M);

                doubleValue_NormalStress.DisplayOnly = true;
                doubleValue_NormalStress.UnitType = UnitType.Pressure;
                doubleValue_NormalStress.SetTheValue(Model.Members.CurrentMember.NormalStress);
            }
            else
            {
                Results.Current.ShowModel();
            }
        }

        #region Common Menus

        #region Help Menu

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Results.Current.ShowHelpAsync();
        }

        #endregion

        #region Settings Menu

        private void MenuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsGeneral();
        }

        private void MenuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsSolver();
        }

        private void MenuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsColors();
        }

        #endregion

        #region File Menu

        private void MenuFlyout_New_Click(object sender, RoutedEventArgs e)
        {
            // New File.
            FileManager.NewFile();
        }

        private async void MenuFlyout_Open_Click(object sender, RoutedEventArgs e)
        {
            // Open file.
            if (await FileManager.PickFileToLoad())
            {
                await FileManager.LoadFile();
            }
        }

        private async void MenuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            // Save File.
            await FileManager.SaveFile();
        }

        private async void MenuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Save file as.
            if (await FileManager.PickFileToSave())
            {
                await FileManager.SaveFile();
            }
        }

        private void MenuFlyout_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        #endregion

        #region Changes per Page

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            // flyOut_NewSection.ShowAt(Button_Save);
        }

        private void Button_Solve_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSolver();
        }

        private void Button_Construction_Click(object sender, RoutedEventArgs e)
        {
            FileManager.LoadLastFileAsync();
        }

        private void Button_Results_Click(object sender, RoutedEventArgs e)
        {
            Solver.Current.ShowResults();
        }

        private void Button_Sections_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSections();
        }

        private void Button_Reports_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Report));
        }

        #endregion

        #endregion
    }
}
