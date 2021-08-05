namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Microsoft.Graphics.Canvas.Geometry;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// LineSelector UserControl is used to customize lines.
    /// </summary>
    public sealed partial class LineSelector : UserControl
    {
        private bool isControlLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="LineSelector"/> class.
        /// </summary>
        public LineSelector()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            singleValue_ColorAlpha.Title = "Alpha";
            singleValue_ColorRed.Title = "Red";
            singleValue_ColorGreen.Title = "Green";
            singleValue_ColorBlue.Title = "Blue";

            singleValue_ColorAlpha.UnitType = UnitType.UnitlessInteger;
            singleValue_ColorRed.UnitType = UnitType.UnitlessInteger;
            singleValue_ColorGreen.UnitType = UnitType.UnitlessInteger;
            singleValue_ColorBlue.UnitType = UnitType.UnitlessInteger;

            singleValue_DashOffset.Title = "Dash Offset";
            singleValue_DashOffset.UnitType = UnitType.Unitless;

            singleValue_LineWeight.Title = "Line Weight";
            singleValue_LineWeight.UnitType = UnitType.Unitless;

            singleValue_MiterLimit.Title = "Miter Limit";
            singleValue_MiterLimit.UnitType = UnitType.Unitless;

            switch (Options.ColorToEdit)
            {
                case "ColorBackground":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorBackground.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorBackground.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorBackground.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorBackground.B);
                    slider_A.Value = Options.ColorBackground.A;
                    slider_R.Value = Options.ColorBackground.R;
                    slider_G.Value = Options.ColorBackground.G;
                    slider_B.Value = Options.ColorBackground.B;

                    break;

                case "LineGridNormal":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorGridNormal.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorGridNormal.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorGridNormal.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorGridNormal.B);
                    slider_A.Value = Options.ColorGridNormal.A;
                    slider_R.Value = Options.ColorGridNormal.R;
                    slider_G.Value = Options.ColorGridNormal.G;
                    slider_B.Value = Options.ColorGridNormal.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineGridNormal.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineGridNormal.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineGridNormalWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineGridNormal.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineGridNormal.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineGridNormal.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineGridNormal.LineJoin;
                    break;

                case "LineGridMinor":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorGridMinor.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorGridMinor.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorGridMinor.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorGridMinor.B);
                    slider_A.Value = Options.ColorGridMinor.A;
                    slider_R.Value = Options.ColorGridMinor.R;
                    slider_G.Value = Options.ColorGridMinor.G;
                    slider_B.Value = Options.ColorGridMinor.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineGridMinor.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMinor.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineGridMinorWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineGridMinor.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineGridMinor.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineGridMinor.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineGridMinor.LineJoin;
                    break;

                case "LineGridMajor":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorGridMajor.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorGridMajor.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorGridMajor.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorGridMajor.B);
                    slider_A.Value = Options.ColorGridMajor.A;
                    slider_R.Value = Options.ColorGridMajor.R;
                    slider_G.Value = Options.ColorGridMajor.G;
                    slider_B.Value = Options.ColorGridMajor.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineGridMajor.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMajor.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineGridMajorWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineGridMajor.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineGridMajor.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineGridMajor.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineGridMajor.LineJoin;
                    break;

                case "LineForce":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorForce.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorForce.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorForce.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorForce.B);
                    slider_A.Value = Options.ColorForce.A;
                    slider_R.Value = Options.ColorForce.R;
                    slider_G.Value = Options.ColorForce.G;
                    slider_B.Value = Options.ColorForce.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineForce.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineForce.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineForceWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineForce.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineForce.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineForce.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineForce.LineJoin;
                    break;

                case "LineReaction":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorReaction.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorReaction.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorReaction.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorReaction.B);
                    slider_A.Value = Options.ColorReaction.A;
                    slider_R.Value = Options.ColorReaction.R;
                    slider_G.Value = Options.ColorReaction.G;
                    slider_B.Value = Options.ColorReaction.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineReaction.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineReaction.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineReactionWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineReaction.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineReaction.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineReaction.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineReaction.LineJoin;
                    break;

                case "LineSelectedElement":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorSelectedElement.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorSelectedElement.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorSelectedElement.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorSelectedElement.B);
                    slider_A.Value = Options.ColorSelectedElement.A;
                    slider_R.Value = Options.ColorSelectedElement.R;
                    slider_G.Value = Options.ColorSelectedElement.G;
                    slider_B.Value = Options.ColorSelectedElement.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineSelectedElement.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineSelectedElement.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineSelectedElementWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineSelectedElement.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineSelectedElement.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineSelectedElement.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineSelectedElement.LineJoin;
                    break;

                case "LineShearForceSelected":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorShearForceSelected.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorShearForceSelected.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorShearForceSelected.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorShearForceSelected.B);
                    slider_A.Value = Options.ColorShearForceSelected.A;
                    slider_R.Value = Options.ColorShearForceSelected.R;
                    slider_G.Value = Options.ColorShearForceSelected.G;
                    slider_B.Value = Options.ColorShearForceSelected.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineShearForceSelected.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForceSelected.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceSelectedWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineShearForceSelected.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineShearForceSelected.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineShearForceSelected.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineShearForceSelected.LineJoin;
                    break;

                case "LineShearForceFont":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorShearForceFont.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorShearForceFont.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorShearForceFont.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorShearForceFont.B);
                    slider_A.Value = Options.ColorShearForceFont.A;
                    slider_R.Value = Options.ColorShearForceFont.R;
                    slider_G.Value = Options.ColorShearForceFont.G;
                    slider_B.Value = Options.ColorShearForceFont.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineShearForceFont.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForceFont.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceFontWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineShearForceFont.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineShearForceFont.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineShearForceFont.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineShearForceFont.LineJoin;
                    break;

                case "LineMomentForceSelected":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorMomentForceSelected.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorMomentForceSelected.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorMomentForceSelected.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorMomentForceSelected.B);
                    slider_A.Value = Options.ColorMomentForceSelected.A;
                    slider_R.Value = Options.ColorMomentForceSelected.R;
                    slider_G.Value = Options.ColorMomentForceSelected.G;
                    slider_B.Value = Options.ColorMomentForceSelected.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForceSelected.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForceSelected.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceSelectedWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineMomentForceSelected.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineMomentForceSelected.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineMomentForceSelected.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineMomentForceSelected.LineJoin;
                    break;

                case "LineMomentForceFont":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorMomentForceFont.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorMomentForceFont.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorMomentForceFont.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorMomentForceFont.B);
                    slider_A.Value = Options.ColorMomentForceFont.A;
                    slider_R.Value = Options.ColorMomentForceFont.R;
                    slider_G.Value = Options.ColorMomentForceFont.G;
                    slider_B.Value = Options.ColorMomentForceFont.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForceFont.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForceFont.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceFontWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineMomentForceFont.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineMomentForceFont.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineMomentForceFont.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineMomentForceFont.LineJoin;
                    break;

                case "LineMomentForce":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorMomentForce.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorMomentForce.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorMomentForce.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorMomentForce.B);
                    slider_A.Value = Options.ColorMomentForce.A;
                    slider_R.Value = Options.ColorMomentForce.R;
                    slider_G.Value = Options.ColorMomentForce.G;
                    slider_B.Value = Options.ColorMomentForce.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForce.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForce.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineMomentForce.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineMomentForce.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineMomentForce.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineMomentForce.LineJoin;
                    break;

                case "LineShearForce":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorShearForce.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorShearForce.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorShearForce.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorShearForce.B);
                    slider_A.Value = Options.ColorShearForce.A;
                    slider_R.Value = Options.ColorShearForce.R;
                    slider_G.Value = Options.ColorShearForce.G;
                    slider_B.Value = Options.ColorShearForce.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineShearForce.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForce.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineShearForce.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineShearForce.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineShearForce.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineShearForce.LineJoin;
                    break;

                case "LineDistributedForceSelected":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorDistributedForceSelected.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorDistributedForceSelected.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorDistributedForceSelected.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorDistributedForceSelected.B);
                    slider_A.Value = Options.ColorDistributedForceSelected.A;
                    slider_R.Value = Options.ColorDistributedForceSelected.R;
                    slider_G.Value = Options.ColorDistributedForceSelected.G;
                    slider_B.Value = Options.ColorDistributedForceSelected.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForceSelected.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForceSelected.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceSelectedWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.LineJoin;
                    break;

                case "LineDistributedForce":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorDistributedForce.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorDistributedForce.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorDistributedForce.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorDistributedForce.B);
                    slider_A.Value = Options.ColorDistributedForce.A;
                    slider_R.Value = Options.ColorDistributedForce.R;
                    slider_G.Value = Options.ColorDistributedForce.G;
                    slider_B.Value = Options.ColorDistributedForce.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForce.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForce.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineDistributedForce.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineDistributedForce.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineDistributedForce.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineDistributedForce.LineJoin;
                    break;

                case "LineNodeFree":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorNodeFree.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorNodeFree.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorNodeFree.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorNodeFree.B);
                    slider_A.Value = Options.ColorNodeFree.A;
                    slider_R.Value = Options.ColorNodeFree.R;
                    slider_G.Value = Options.ColorNodeFree.G;
                    slider_B.Value = Options.ColorNodeFree.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFree.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFree.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFreeWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineNodeFree.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeFree.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeFree.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeFree.LineJoin;
                    break;

                case "LineNodeFixed":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorNodeFixed.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorNodeFixed.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorNodeFixed.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorNodeFixed.B);
                    slider_A.Value = Options.ColorNodeFixed.A;
                    slider_R.Value = Options.ColorNodeFixed.R;
                    slider_G.Value = Options.ColorNodeFixed.G;
                    slider_B.Value = Options.ColorNodeFixed.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFixed.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFixed.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFixedWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineNodeFixed.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeFixed.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeFixed.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeFixed.LineJoin;
                    break;

                case "LineNodePin":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorNodePin.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorNodePin.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorNodePin.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorNodePin.B);
                    slider_A.Value = Options.ColorNodePin.A;
                    slider_R.Value = Options.ColorNodePin.R;
                    slider_G.Value = Options.ColorNodePin.G;
                    slider_B.Value = Options.ColorNodePin.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineNodePin.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodePin.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineNodePinWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineNodePin.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodePin.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodePin.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodePin.LineJoin;
                    break;

                case "LineNodeRollerX":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorNodeRollerX.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorNodeRollerX.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorNodeRollerX.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorNodeRollerX.B);
                    slider_A.Value = Options.ColorNodeRollerX.A;
                    slider_R.Value = Options.ColorNodeRollerX.R;
                    slider_G.Value = Options.ColorNodeRollerX.G;
                    slider_B.Value = Options.ColorNodeRollerX.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerX.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerX.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerXWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineNodeRollerX.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeRollerX.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeRollerX.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeRollerX.LineJoin;
                    break;

                case "LineNodeRollerY":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorNodeRollerY.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorNodeRollerY.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorNodeRollerY.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorNodeRollerY.B);
                    slider_A.Value = Options.ColorNodeRollerY.A;
                    slider_R.Value = Options.ColorNodeRollerY.R;
                    slider_G.Value = Options.ColorNodeRollerY.G;
                    slider_B.Value = Options.ColorNodeRollerY.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerY.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerY.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerYWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineNodeRollerY.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeRollerY.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeRollerY.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeRollerY.LineJoin;
                    break;

                case "LineNodeOther":
                    singleValue_ColorAlpha.SetTheValue(Options.ColorNodeOther.A);
                    singleValue_ColorRed.SetTheValue(Options.ColorNodeOther.R);
                    singleValue_ColorGreen.SetTheValue(Options.ColorNodeOther.G);
                    singleValue_ColorBlue.SetTheValue(Options.ColorNodeOther.B);
                    slider_A.Value = Options.ColorNodeOther.A;
                    slider_R.Value = Options.ColorNodeOther.R;
                    slider_G.Value = Options.ColorNodeOther.G;
                    slider_B.Value = Options.ColorNodeOther.B;

                    singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeOther.DashOffset);
                    singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeOther.MiterLimit);
                    singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeOtherWeight);

                    comboBox_LineStyle.SelectedIndex = (int)Options.LineNodeOther.DashStyle;
                    comboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeOther.StartCap;
                    comboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeOther.EndCap;
                    comboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeOther.LineJoin;
                    break;
            }

            rectangle_Color.Fill = new SolidColorBrush(Color.FromArgb((byte)singleValue_ColorAlpha.NewValue, (byte)singleValue_ColorRed.NewValue, (byte)singleValue_ColorGreen.NewValue, (byte)singleValue_ColorBlue.NewValue));

            isControlLoaded = true;
        }

        private void UpdateColor()
        {
            if (isControlLoaded)
            {
                Color tmpColor = Color.FromArgb((byte)singleValue_ColorAlpha.NewValue, (byte)singleValue_ColorRed.NewValue, (byte)singleValue_ColorGreen.NewValue, (byte)singleValue_ColorBlue.NewValue);
                switch (Options.ColorToEdit)
                {
                    case "ColorBackground":
                        Options.ColorBackground = tmpColor;
                        break;

                    case "LineGridNormal":
                        Options.ColorGridNormal = tmpColor;
                        Options.LineGridNormal.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineGridNormal.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineGridNormal.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineGridNormal.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineGridNormal.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineGridNormal.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineGridNormalWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineGridNormal.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineGridNormal.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineGridNormalWeight);
                        break;

                    case "LineGridMinor":
                        Options.ColorGridMinor = tmpColor;
                        Options.LineGridMinor.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineGridMinor.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineGridMinor.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineGridMinor.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineGridMinor.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineGridMinor.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineGridMinorWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineGridMinor.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMinor.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineGridMinorWeight);
                        break;

                    case "LineGridMajor":
                        Options.ColorGridMajor = tmpColor;
                        Options.LineGridMajor.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineGridMajor.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineGridMajor.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineGridMajor.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineGridMajor.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineGridMajor.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineGridMajorWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineGridMajor.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMajor.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineGridMajorWeight);
                        break;

                    case "LineForce":
                        Options.ColorForce = tmpColor;
                        Options.LineForce.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineForce.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineForce.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineForce.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineForce.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineForce.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineForceWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineForce.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineForce.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineForceWeight);
                        break;

                    case "LineReaction":
                        Options.ColorReaction = tmpColor;
                        Options.LineReaction.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineReaction.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineReaction.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineReaction.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineReaction.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineReaction.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineReactionWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineReaction.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineReaction.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineReactionWeight);
                        break;

                    case "LineSelectedElement":
                        Options.ColorSelectedElement = tmpColor;
                        Options.LineSelectedElement.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineSelectedElement.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineSelectedElement.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineSelectedElement.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineSelectedElement.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineSelectedElement.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineSelectedElementWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineSelectedElement.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineSelectedElement.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineSelectedElementWeight);
                        break;

                    case "LineShearForceSelected":
                        Options.ColorShearForceSelected = tmpColor;
                        Options.LineShearForceSelected.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineShearForceSelected.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineShearForceSelected.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineShearForceSelected.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineShearForceSelected.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineShearForceSelected.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineShearForceSelectedWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineShearForceSelected.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForceSelected.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceSelectedWeight);
                        break;

                    case "LineMomentForceSelected":
                        Options.ColorMomentForceSelected = tmpColor;
                        Options.LineMomentForceSelected.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineMomentForceSelected.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineMomentForceSelected.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineMomentForceSelected.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineMomentForceSelected.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineMomentForceSelected.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineMomentForceSelectedWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForceSelected.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForceSelected.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceSelectedWeight);
                        break;

                    case "LineDistributedForceSelected":
                        Options.ColorDistributedForceSelected = tmpColor;
                        Options.LineDistributedForceSelected.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineDistributedForceSelected.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineDistributedForceSelected.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineDistributedForceSelected.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineDistributedForceSelected.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineDistributedForceSelected.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineDistributedForceSelectedWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForceSelected.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForceSelected.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceSelectedWeight);
                        break;

                    case "LineShearForce":
                        Options.ColorShearForce = tmpColor;
                        Options.LineShearForce.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineShearForce.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineShearForce.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineShearForce.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineShearForce.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineShearForce.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineShearForceWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineShearForce.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForce.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceWeight);
                        break;

                    case "LineMomentForce":
                        Options.ColorMomentForce = tmpColor;
                        Options.LineMomentForce.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineMomentForce.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineMomentForce.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineMomentForce.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineMomentForce.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineMomentForce.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineMomentForceWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForce.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForce.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceWeight);
                        break;

                    case "LineDistributedForce":
                        Options.ColorDistributedForce = tmpColor;
                        Options.LineDistributedForce.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineDistributedForce.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineDistributedForce.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineDistributedForce.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineDistributedForce.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineDistributedForce.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineDistributedForceWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForce.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForce.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceWeight);
                        break;

                    case "LineNodeFree":
                        Options.ColorNodeFree = tmpColor;
                        Options.LineNodeFree.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineNodeFree.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineNodeFree.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeFree.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeFree.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineNodeFree.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeFreeWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFree.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFree.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFreeWeight);
                        break;

                    case "LineNodeFixed":
                        Options.ColorNodeFixed = tmpColor;
                        Options.LineNodeFixed.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineNodeFixed.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineNodeFixed.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeFixed.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeFixed.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineNodeFixed.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeFixedWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFixed.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFixed.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFixedWeight);
                        break;

                    case "LineNodePin":
                        Options.ColorNodePin = tmpColor;
                        Options.LineNodePin.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineNodePin.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineNodePin.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodePin.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodePin.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineNodePin.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodePinWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineNodePin.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodePin.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineNodePinWeight);
                        break;

                    case "LineNodeRollerX":
                        Options.ColorNodeRollerX = tmpColor;
                        Options.LineNodeRollerX.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineNodeRollerX.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineNodeRollerX.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeRollerX.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeRollerX.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineNodeRollerX.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeRollerXWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerX.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerX.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerXWeight);
                        break;

                    case "LineNodeRollerY":
                        Options.ColorNodeRollerY = tmpColor;
                        Options.LineNodeRollerY.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineNodeRollerY.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineNodeRollerY.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeRollerY.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeRollerY.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineNodeRollerY.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeRollerYWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerY.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerY.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerYWeight);
                        break;

                    case "LineNodeOther":
                        Options.ColorNodeOther = tmpColor;
                        Options.LineNodeOther.DashOffset = (float)singleValue_DashOffset.NewValue;
                        Options.LineNodeOther.DashStyle = (CanvasDashStyle)comboBox_LineStyle.SelectedIndex;
                        Options.LineNodeOther.EndCap = (CanvasCapStyle)comboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeOther.LineJoin = (CanvasLineJoin)comboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeOther.MiterLimit = (float)singleValue_MiterLimit.NewValue;
                        Options.LineNodeOther.StartCap = (CanvasCapStyle)comboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeOtherWeight = (float)singleValue_LineWeight.NewValue;
                        singleValue_DashOffset.SetTheValue((decimal)Options.LineNodeOther.DashOffset);
                        singleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeOther.MiterLimit);
                        singleValue_LineWeight.SetTheValue((decimal)Options.LineNodeOtherWeight);
                        break;
                }

                rectangle_Color.Fill = new SolidColorBrush(tmpColor);
                singleValue_ColorAlpha.SetTheValue(tmpColor.A);
                singleValue_ColorRed.SetTheValue(tmpColor.R);
                singleValue_ColorGreen.SetTheValue(tmpColor.G);
                singleValue_ColorBlue.SetTheValue(tmpColor.B);
                Model.UpdateColors();
            }
        }

        private void SingleValue_ColorAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorAlpha.NewValue < 0)
            {
                singleValue_ColorAlpha.NewValue = 0;
            }

            if (singleValue_ColorAlpha.NewValue > 255)
            {
                singleValue_ColorAlpha.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorRed_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorRed.NewValue < 0)
            {
                singleValue_ColorRed.NewValue = 0;
            }

            if (singleValue_ColorRed.NewValue > 255)
            {
                singleValue_ColorRed.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorGreen_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorGreen.NewValue < 0)
            {
                singleValue_ColorGreen.NewValue = 0;
            }

            if (singleValue_ColorGreen.NewValue > 255)
            {
                singleValue_ColorGreen.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorBlue_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_ColorBlue.NewValue < 0)
            {
                singleValue_ColorBlue.NewValue = 0;
            }

            if (singleValue_ColorBlue.NewValue > 255)
            {
                singleValue_ColorBlue.NewValue = 255;
            }

            UpdateColor();
        }

        private void Slider_A_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorAlpha.SetTheValue((byte)slider_A.Value);
            UpdateColor();
        }

        private void Slider_R_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorRed.SetTheValue((byte)slider_R.Value);
            UpdateColor();
        }

        private void Slider_G_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorGreen.SetTheValue((byte)slider_G.Value);
            UpdateColor();
        }

        private void Slider_B_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            singleValue_ColorBlue.SetTheValue((byte)slider_B.Value);
            UpdateColor();
        }

        private void ComboBox_LineStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void ComboBox_NearCapStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void ComboBox_FarCapStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void ComboBox_LineJoinStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateColor();
        }

        private void SingleValue_LineWeight_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_LineWeight.NewValue < 0)
            {
                singleValue_LineWeight.NewValue = 1;
            }

            if (singleValue_LineWeight.NewValue > 255)
            {
                singleValue_LineWeight.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_MiterLimit_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_MiterLimit.NewValue < 0)
            {
                singleValue_MiterLimit.NewValue = 1;
            }

            if (singleValue_MiterLimit.NewValue > 255)
            {
                singleValue_MiterLimit.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_DashOffset_ValueChanged(object sender, EventArgs e)
        {
            if (singleValue_DashOffset.NewValue < 0)
            {
                singleValue_DashOffset.NewValue = 1;
            }

            if (singleValue_DashOffset.NewValue > 255)
            {
                singleValue_DashOffset.NewValue = 255;
            }

            UpdateColor();
        }
    }
}