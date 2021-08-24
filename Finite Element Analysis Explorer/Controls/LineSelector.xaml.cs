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
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SingleValue_ColorAlpha.Title = "Alpha";
            SingleValue_ColorRed.Title = "Red";
            SingleValue_ColorGreen.Title = "Green";
            SingleValue_ColorBlue.Title = "Blue";

            SingleValue_ColorAlpha.UnitType = UnitType.UnitlessInteger;
            SingleValue_ColorRed.UnitType = UnitType.UnitlessInteger;
            SingleValue_ColorGreen.UnitType = UnitType.UnitlessInteger;
            SingleValue_ColorBlue.UnitType = UnitType.UnitlessInteger;

            SingleValue_DashOffset.Title = "Dash Offset";
            SingleValue_DashOffset.UnitType = UnitType.Unitless;

            SingleValue_LineWeight.Title = "Line Weight";
            SingleValue_LineWeight.UnitType = UnitType.Unitless;

            SingleValue_MiterLimit.Title = "Miter Limit";
            SingleValue_MiterLimit.UnitType = UnitType.Unitless;

            switch (Options.ColorToEdit)
            {
                case "ColorBackground":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorBackground.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorBackground.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorBackground.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorBackground.B);
                    Slider_A.Value = Options.ColorBackground.A;
                    Slider_R.Value = Options.ColorBackground.R;
                    Slider_G.Value = Options.ColorBackground.G;
                    Slider_B.Value = Options.ColorBackground.B;

                    break;

                case "LineGridNormal":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorGridNormal.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorGridNormal.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorGridNormal.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorGridNormal.B);
                    Slider_A.Value = Options.ColorGridNormal.A;
                    Slider_R.Value = Options.ColorGridNormal.R;
                    Slider_G.Value = Options.ColorGridNormal.G;
                    Slider_B.Value = Options.ColorGridNormal.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineGridNormal.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineGridNormal.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineGridNormalWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineGridNormal.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineGridNormal.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineGridNormal.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineGridNormal.LineJoin;
                    break;

                case "LineGridMinor":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorGridMinor.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorGridMinor.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorGridMinor.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorGridMinor.B);
                    Slider_A.Value = Options.ColorGridMinor.A;
                    Slider_R.Value = Options.ColorGridMinor.R;
                    Slider_G.Value = Options.ColorGridMinor.G;
                    Slider_B.Value = Options.ColorGridMinor.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineGridMinor.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMinor.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineGridMinorWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineGridMinor.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineGridMinor.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineGridMinor.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineGridMinor.LineJoin;
                    break;

                case "LineGridMajor":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorGridMajor.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorGridMajor.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorGridMajor.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorGridMajor.B);
                    Slider_A.Value = Options.ColorGridMajor.A;
                    Slider_R.Value = Options.ColorGridMajor.R;
                    Slider_G.Value = Options.ColorGridMajor.G;
                    Slider_B.Value = Options.ColorGridMajor.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineGridMajor.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMajor.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineGridMajorWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineGridMajor.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineGridMajor.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineGridMajor.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineGridMajor.LineJoin;
                    break;

                case "LineForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorForce.B);
                    Slider_A.Value = Options.ColorForce.A;
                    Slider_R.Value = Options.ColorForce.R;
                    Slider_G.Value = Options.ColorForce.G;
                    Slider_B.Value = Options.ColorForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineForce.LineJoin;
                    break;

                case "LineReaction":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorReaction.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorReaction.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorReaction.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorReaction.B);
                    Slider_A.Value = Options.ColorReaction.A;
                    Slider_R.Value = Options.ColorReaction.R;
                    Slider_G.Value = Options.ColorReaction.G;
                    Slider_B.Value = Options.ColorReaction.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineReaction.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineReaction.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineReactionWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineReaction.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineReaction.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineReaction.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineReaction.LineJoin;
                    break;

                case "LineSelectedElement":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorSelectedElement.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorSelectedElement.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorSelectedElement.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorSelectedElement.B);
                    Slider_A.Value = Options.ColorSelectedElement.A;
                    Slider_R.Value = Options.ColorSelectedElement.R;
                    Slider_G.Value = Options.ColorSelectedElement.G;
                    Slider_B.Value = Options.ColorSelectedElement.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineSelectedElement.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineSelectedElement.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineSelectedElementWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineSelectedElement.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineSelectedElement.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineSelectedElement.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineSelectedElement.LineJoin;
                    break;

                case "LineShearForceSelected":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorShearForceSelected.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorShearForceSelected.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorShearForceSelected.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorShearForceSelected.B);
                    Slider_A.Value = Options.ColorShearForceSelected.A;
                    Slider_R.Value = Options.ColorShearForceSelected.R;
                    Slider_G.Value = Options.ColorShearForceSelected.G;
                    Slider_B.Value = Options.ColorShearForceSelected.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineShearForceSelected.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForceSelected.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceSelectedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineShearForceSelected.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineShearForceSelected.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineShearForceSelected.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineShearForceSelected.LineJoin;
                    break;

                case "LineShearForceFont":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorShearForceFont.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorShearForceFont.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorShearForceFont.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorShearForceFont.B);
                    Slider_A.Value = Options.ColorShearForceFont.A;
                    Slider_R.Value = Options.ColorShearForceFont.R;
                    Slider_G.Value = Options.ColorShearForceFont.G;
                    Slider_B.Value = Options.ColorShearForceFont.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineShearForceFont.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForceFont.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceFontWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineShearForceFont.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineShearForceFont.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineShearForceFont.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineShearForceFont.LineJoin;
                    break;

                case "LineMomentForceSelected":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorMomentForceSelected.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorMomentForceSelected.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorMomentForceSelected.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorMomentForceSelected.B);
                    Slider_A.Value = Options.ColorMomentForceSelected.A;
                    Slider_R.Value = Options.ColorMomentForceSelected.R;
                    Slider_G.Value = Options.ColorMomentForceSelected.G;
                    Slider_B.Value = Options.ColorMomentForceSelected.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForceSelected.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForceSelected.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceSelectedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineMomentForceSelected.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineMomentForceSelected.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineMomentForceSelected.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineMomentForceSelected.LineJoin;
                    break;

                case "LineMomentForceFont":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorMomentForceFont.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorMomentForceFont.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorMomentForceFont.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorMomentForceFont.B);
                    Slider_A.Value = Options.ColorMomentForceFont.A;
                    Slider_R.Value = Options.ColorMomentForceFont.R;
                    Slider_G.Value = Options.ColorMomentForceFont.G;
                    Slider_B.Value = Options.ColorMomentForceFont.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForceFont.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForceFont.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceFontWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineMomentForceFont.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineMomentForceFont.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineMomentForceFont.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineMomentForceFont.LineJoin;
                    break;

                case "LineMomentForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorMomentForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorMomentForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorMomentForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorMomentForce.B);
                    Slider_A.Value = Options.ColorMomentForce.A;
                    Slider_R.Value = Options.ColorMomentForce.R;
                    Slider_G.Value = Options.ColorMomentForce.G;
                    Slider_B.Value = Options.ColorMomentForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineMomentForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineMomentForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineMomentForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineMomentForce.LineJoin;
                    break;

                case "LineShearForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorShearForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorShearForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorShearForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorShearForce.B);
                    Slider_A.Value = Options.ColorShearForce.A;
                    Slider_R.Value = Options.ColorShearForce.R;
                    Slider_G.Value = Options.ColorShearForce.G;
                    Slider_B.Value = Options.ColorShearForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineShearForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineShearForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineShearForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineShearForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineShearForce.LineJoin;
                    break;

                case "LineDistributedForceSelected":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorDistributedForceSelected.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorDistributedForceSelected.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorDistributedForceSelected.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorDistributedForceSelected.B);
                    Slider_A.Value = Options.ColorDistributedForceSelected.A;
                    Slider_R.Value = Options.ColorDistributedForceSelected.R;
                    Slider_G.Value = Options.ColorDistributedForceSelected.G;
                    Slider_B.Value = Options.ColorDistributedForceSelected.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForceSelected.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForceSelected.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceSelectedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineDistributedForceSelected.LineJoin;
                    break;

                case "LineDistributedForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorDistributedForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorDistributedForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorDistributedForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorDistributedForce.B);
                    Slider_A.Value = Options.ColorDistributedForce.A;
                    Slider_R.Value = Options.ColorDistributedForce.R;
                    Slider_G.Value = Options.ColorDistributedForce.G;
                    Slider_B.Value = Options.ColorDistributedForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineDistributedForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineDistributedForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineDistributedForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineDistributedForce.LineJoin;
                    break;

                case "LineNodeFree":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorNodeFree.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorNodeFree.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorNodeFree.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorNodeFree.B);
                    Slider_A.Value = Options.ColorNodeFree.A;
                    Slider_R.Value = Options.ColorNodeFree.R;
                    Slider_G.Value = Options.ColorNodeFree.G;
                    Slider_B.Value = Options.ColorNodeFree.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFree.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFree.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFreeWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineNodeFree.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeFree.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeFree.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeFree.LineJoin;
                    break;

                case "LineNodeFixed":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorNodeFixed.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorNodeFixed.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorNodeFixed.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorNodeFixed.B);
                    Slider_A.Value = Options.ColorNodeFixed.A;
                    Slider_R.Value = Options.ColorNodeFixed.R;
                    Slider_G.Value = Options.ColorNodeFixed.G;
                    Slider_B.Value = Options.ColorNodeFixed.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFixed.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFixed.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFixedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineNodeFixed.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeFixed.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeFixed.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeFixed.LineJoin;
                    break;

                case "LineNodePin":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorNodePin.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorNodePin.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorNodePin.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorNodePin.B);
                    Slider_A.Value = Options.ColorNodePin.A;
                    Slider_R.Value = Options.ColorNodePin.R;
                    Slider_G.Value = Options.ColorNodePin.G;
                    Slider_B.Value = Options.ColorNodePin.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodePin.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodePin.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodePinWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineNodePin.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodePin.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodePin.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodePin.LineJoin;
                    break;

                case "LineNodeRollerX":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorNodeRollerX.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorNodeRollerX.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorNodeRollerX.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorNodeRollerX.B);
                    Slider_A.Value = Options.ColorNodeRollerX.A;
                    Slider_R.Value = Options.ColorNodeRollerX.R;
                    Slider_G.Value = Options.ColorNodeRollerX.G;
                    Slider_B.Value = Options.ColorNodeRollerX.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerX.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerX.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerXWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineNodeRollerX.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeRollerX.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeRollerX.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeRollerX.LineJoin;
                    break;

                case "LineNodeRollerY":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorNodeRollerY.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorNodeRollerY.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorNodeRollerY.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorNodeRollerY.B);
                    Slider_A.Value = Options.ColorNodeRollerY.A;
                    Slider_R.Value = Options.ColorNodeRollerY.R;
                    Slider_G.Value = Options.ColorNodeRollerY.G;
                    Slider_B.Value = Options.ColorNodeRollerY.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerY.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerY.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerYWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineNodeRollerY.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeRollerY.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeRollerY.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeRollerY.LineJoin;
                    break;

                case "LineNodeOther":
                    SingleValue_ColorAlpha.SetTheValue(Options.ColorNodeOther.A);
                    SingleValue_ColorRed.SetTheValue(Options.ColorNodeOther.R);
                    SingleValue_ColorGreen.SetTheValue(Options.ColorNodeOther.G);
                    SingleValue_ColorBlue.SetTheValue(Options.ColorNodeOther.B);
                    Slider_A.Value = Options.ColorNodeOther.A;
                    Slider_R.Value = Options.ColorNodeOther.R;
                    Slider_G.Value = Options.ColorNodeOther.G;
                    Slider_B.Value = Options.ColorNodeOther.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeOther.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeOther.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeOtherWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.LineNodeOther.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.LineNodeOther.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.LineNodeOther.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.LineNodeOther.LineJoin;
                    break;
            }

            Rectangle_Color.Fill = new SolidColorBrush(Color.FromArgb((byte)SingleValue_ColorAlpha.NewValue, (byte)SingleValue_ColorRed.NewValue, (byte)SingleValue_ColorGreen.NewValue, (byte)SingleValue_ColorBlue.NewValue));

            isControlLoaded = true;
        }

        private void UpdateColor()
        {
            if (isControlLoaded)
            {
                Color tmpColor = Color.FromArgb((byte)SingleValue_ColorAlpha.NewValue, (byte)SingleValue_ColorRed.NewValue, (byte)SingleValue_ColorGreen.NewValue, (byte)SingleValue_ColorBlue.NewValue);
                switch (Options.ColorToEdit)
                {
                    case "ColorBackground":
                        Options.ColorBackground = tmpColor;
                        break;

                    case "LineGridNormal":
                        Options.ColorGridNormal = tmpColor;
                        Options.LineGridNormal.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineGridNormal.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineGridNormal.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineGridNormal.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineGridNormal.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineGridNormal.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineGridNormalWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineGridNormal.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineGridNormal.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineGridNormalWeight);
                        break;

                    case "LineGridMinor":
                        Options.ColorGridMinor = tmpColor;
                        Options.LineGridMinor.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineGridMinor.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineGridMinor.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineGridMinor.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineGridMinor.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineGridMinor.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineGridMinorWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineGridMinor.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMinor.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineGridMinorWeight);
                        break;

                    case "LineGridMajor":
                        Options.ColorGridMajor = tmpColor;
                        Options.LineGridMajor.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineGridMajor.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineGridMajor.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineGridMajor.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineGridMajor.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineGridMajor.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineGridMajorWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineGridMajor.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineGridMajor.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineGridMajorWeight);
                        break;

                    case "LineForce":
                        Options.ColorForce = tmpColor;
                        Options.LineForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineForceWeight);
                        break;

                    case "LineReaction":
                        Options.ColorReaction = tmpColor;
                        Options.LineReaction.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineReaction.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineReaction.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineReaction.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineReaction.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineReaction.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineReactionWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineReaction.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineReaction.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineReactionWeight);
                        break;

                    case "LineSelectedElement":
                        Options.ColorSelectedElement = tmpColor;
                        Options.LineSelectedElement.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineSelectedElement.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineSelectedElement.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineSelectedElement.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineSelectedElement.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineSelectedElement.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineSelectedElementWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineSelectedElement.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineSelectedElement.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineSelectedElementWeight);
                        break;

                    case "LineShearForceSelected":
                        Options.ColorShearForceSelected = tmpColor;
                        Options.LineShearForceSelected.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineShearForceSelected.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineShearForceSelected.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineShearForceSelected.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineShearForceSelected.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineShearForceSelected.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineShearForceSelectedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineShearForceSelected.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForceSelected.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceSelectedWeight);
                        break;

                    case "LineMomentForceSelected":
                        Options.ColorMomentForceSelected = tmpColor;
                        Options.LineMomentForceSelected.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineMomentForceSelected.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineMomentForceSelected.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineMomentForceSelected.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineMomentForceSelected.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineMomentForceSelected.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineMomentForceSelectedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForceSelected.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForceSelected.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceSelectedWeight);
                        break;

                    case "LineDistributedForceSelected":
                        Options.ColorDistributedForceSelected = tmpColor;
                        Options.LineDistributedForceSelected.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineDistributedForceSelected.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineDistributedForceSelected.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineDistributedForceSelected.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineDistributedForceSelected.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineDistributedForceSelected.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineDistributedForceSelectedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForceSelected.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForceSelected.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceSelectedWeight);
                        break;

                    case "LineShearForce":
                        Options.ColorShearForce = tmpColor;
                        Options.LineShearForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineShearForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineShearForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineShearForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineShearForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineShearForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineShearForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineShearForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineShearForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineShearForceWeight);
                        break;

                    case "LineMomentForce":
                        Options.ColorMomentForce = tmpColor;
                        Options.LineMomentForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineMomentForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineMomentForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineMomentForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineMomentForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineMomentForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineMomentForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineMomentForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineMomentForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineMomentForceWeight);
                        break;

                    case "LineDistributedForce":
                        Options.ColorDistributedForce = tmpColor;
                        Options.LineDistributedForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineDistributedForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineDistributedForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineDistributedForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineDistributedForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineDistributedForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineDistributedForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineDistributedForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineDistributedForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineDistributedForceWeight);
                        break;

                    case "LineNodeFree":
                        Options.ColorNodeFree = tmpColor;
                        Options.LineNodeFree.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineNodeFree.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineNodeFree.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeFree.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeFree.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineNodeFree.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeFreeWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFree.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFree.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFreeWeight);
                        break;

                    case "LineNodeFixed":
                        Options.ColorNodeFixed = tmpColor;
                        Options.LineNodeFixed.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineNodeFixed.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineNodeFixed.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeFixed.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeFixed.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineNodeFixed.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeFixedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeFixed.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeFixed.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeFixedWeight);
                        break;

                    case "LineNodePin":
                        Options.ColorNodePin = tmpColor;
                        Options.LineNodePin.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineNodePin.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineNodePin.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodePin.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodePin.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineNodePin.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodePinWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodePin.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodePin.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodePinWeight);
                        break;

                    case "LineNodeRollerX":
                        Options.ColorNodeRollerX = tmpColor;
                        Options.LineNodeRollerX.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineNodeRollerX.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineNodeRollerX.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeRollerX.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeRollerX.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineNodeRollerX.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeRollerXWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerX.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerX.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerXWeight);
                        break;

                    case "LineNodeRollerY":
                        Options.ColorNodeRollerY = tmpColor;
                        Options.LineNodeRollerY.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineNodeRollerY.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineNodeRollerY.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeRollerY.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeRollerY.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineNodeRollerY.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeRollerYWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeRollerY.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeRollerY.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeRollerYWeight);
                        break;

                    case "LineNodeOther":
                        Options.ColorNodeOther = tmpColor;
                        Options.LineNodeOther.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.LineNodeOther.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.LineNodeOther.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.LineNodeOther.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.LineNodeOther.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.LineNodeOther.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.LineNodeOtherWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.LineNodeOther.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.LineNodeOther.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.LineNodeOtherWeight);
                        break;
                }

                Rectangle_Color.Fill = new SolidColorBrush(tmpColor);
                SingleValue_ColorAlpha.SetTheValue(tmpColor.A);
                SingleValue_ColorRed.SetTheValue(tmpColor.R);
                SingleValue_ColorGreen.SetTheValue(tmpColor.G);
                SingleValue_ColorBlue.SetTheValue(tmpColor.B);
                Model.UpdateColors();
            }
        }

        private void SingleValue_ColorAlpha_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorAlpha.NewValue < 0)
            {
                SingleValue_ColorAlpha.NewValue = 0;
            }

            if (SingleValue_ColorAlpha.NewValue > 255)
            {
                SingleValue_ColorAlpha.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorRed_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorRed.NewValue < 0)
            {
                SingleValue_ColorRed.NewValue = 0;
            }

            if (SingleValue_ColorRed.NewValue > 255)
            {
                SingleValue_ColorRed.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorGreen_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorGreen.NewValue < 0)
            {
                SingleValue_ColorGreen.NewValue = 0;
            }

            if (SingleValue_ColorGreen.NewValue > 255)
            {
                SingleValue_ColorGreen.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_ColorBlue_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_ColorBlue.NewValue < 0)
            {
                SingleValue_ColorBlue.NewValue = 0;
            }

            if (SingleValue_ColorBlue.NewValue > 255)
            {
                SingleValue_ColorBlue.NewValue = 255;
            }

            UpdateColor();
        }

        private void Slider_A_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorAlpha.SetTheValue((byte)Slider_A.Value);
            UpdateColor();
        }

        private void Slider_R_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorRed.SetTheValue((byte)Slider_R.Value);
            UpdateColor();
        }

        private void Slider_G_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorGreen.SetTheValue((byte)Slider_G.Value);
            UpdateColor();
        }

        private void Slider_B_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            SingleValue_ColorBlue.SetTheValue((byte)Slider_B.Value);
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
            if (SingleValue_LineWeight.NewValue < 0)
            {
                SingleValue_LineWeight.NewValue = 1;
            }

            if (SingleValue_LineWeight.NewValue > 255)
            {
                SingleValue_LineWeight.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_MiterLimit_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_MiterLimit.NewValue < 0)
            {
                SingleValue_MiterLimit.NewValue = 1;
            }

            if (SingleValue_MiterLimit.NewValue > 255)
            {
                SingleValue_MiterLimit.NewValue = 255;
            }

            UpdateColor();
        }

        private void SingleValue_DashOffset_ValueChanged(object sender, EventArgs e)
        {
            if (SingleValue_DashOffset.NewValue < 0)
            {
                SingleValue_DashOffset.NewValue = 1;
            }

            if (SingleValue_DashOffset.NewValue > 255)
            {
                SingleValue_DashOffset.NewValue = 255;
            }

            UpdateColor();
        }
    }
}