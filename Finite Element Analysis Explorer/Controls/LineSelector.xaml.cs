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

            switch (Options.Colors.ColorToEdit)
            {
                case "ColorBackground":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.Background.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.Background.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.Background.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.Background.B);
                    Slider_A.Value = Options.Colors.Background.A;
                    Slider_R.Value = Options.Colors.Background.R;
                    Slider_G.Value = Options.Colors.Background.G;
                    Slider_B.Value = Options.Colors.Background.B;

                    break;

                case "LineGridNormal":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.GridNormal.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.GridNormal.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.GridNormal.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.GridNormal.B);
                    Slider_A.Value = Options.Colors.GridNormal.A;
                    Slider_R.Value = Options.Colors.GridNormal.R;
                    Slider_G.Value = Options.Colors.GridNormal.G;
                    Slider_B.Value = Options.Colors.GridNormal.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.GridNormal.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.GridNormal.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.GridNormalWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.GridNormal.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.GridNormal.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.GridNormal.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.GridNormal.LineJoin;
                    break;

                case "LineGridMinor":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.GridMinor.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.GridMinor.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.GridMinor.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.GridMinor.B);
                    Slider_A.Value = Options.Colors.GridMinor.A;
                    Slider_R.Value = Options.Colors.GridMinor.R;
                    Slider_G.Value = Options.Colors.GridMinor.G;
                    Slider_B.Value = Options.Colors.GridMinor.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.GridMinor.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.GridMinor.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.GridMinorWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.GridMinor.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.GridMinor.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.GridMinor.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.GridMinor.LineJoin;
                    break;

                case "LineGridMajor":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.GridMajor.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.GridMajor.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.GridMajor.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.GridMajor.B);
                    Slider_A.Value = Options.Colors.GridMajor.A;
                    Slider_R.Value = Options.Colors.GridMajor.R;
                    Slider_G.Value = Options.Colors.GridMajor.G;
                    Slider_B.Value = Options.Colors.GridMajor.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.GridMajor.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.GridMajor.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.GridMajorWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.GridMajor.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.GridMajor.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.GridMajor.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.GridMajor.LineJoin;
                    break;

                case "LineForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.Force.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.Force.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.Force.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.Force.B);
                    Slider_A.Value = Options.Colors.Force.A;
                    Slider_R.Value = Options.Colors.Force.R;
                    Slider_G.Value = Options.Colors.Force.G;
                    Slider_B.Value = Options.Colors.Force.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.Force.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.Force.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.Force.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.Force.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.Force.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.Force.LineJoin;
                    break;

                case "LineReaction":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.Reaction.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.Reaction.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.Reaction.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.Reaction.B);
                    Slider_A.Value = Options.Colors.Reaction.A;
                    Slider_R.Value = Options.Colors.Reaction.R;
                    Slider_G.Value = Options.Colors.Reaction.G;
                    Slider_B.Value = Options.Colors.Reaction.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.Reaction.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.Reaction.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ReactionWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.Reaction.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.Reaction.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.Reaction.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.Reaction.LineJoin;
                    break;

                case "LineSelectedElement":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.SelectedElement.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.SelectedElement.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.SelectedElement.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.SelectedElement.B);
                    Slider_A.Value = Options.Colors.SelectedElement.A;
                    Slider_R.Value = Options.Colors.SelectedElement.R;
                    Slider_G.Value = Options.Colors.SelectedElement.G;
                    Slider_B.Value = Options.Colors.SelectedElement.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.SelectedElement.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.SelectedElement.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.SelectedElementWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.SelectedElement.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.SelectedElement.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.SelectedElement.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.SelectedElement.LineJoin;
                    break;

                case "LineShearForceSelected":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.ShearForceSelected.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.ShearForceSelected.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.ShearForceSelected.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.ShearForceSelected.B);
                    Slider_A.Value = Options.Colors.ShearForceSelected.A;
                    Slider_R.Value = Options.Colors.ShearForceSelected.R;
                    Slider_G.Value = Options.Colors.ShearForceSelected.G;
                    Slider_B.Value = Options.Colors.ShearForceSelected.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.ShearForceSelected.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.ShearForceSelected.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ShearForceSelectedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.ShearForceSelected.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.ShearForceSelected.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.ShearForceSelected.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.ShearForceSelected.LineJoin;
                    break;

                case "LineShearForceFont":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.ShearForceFont.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.ShearForceFont.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.ShearForceFont.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.ShearForceFont.B);
                    Slider_A.Value = Options.Colors.ShearForceFont.A;
                    Slider_R.Value = Options.Colors.ShearForceFont.R;
                    Slider_G.Value = Options.Colors.ShearForceFont.G;
                    Slider_B.Value = Options.Colors.ShearForceFont.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.ShearForceFont.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.ShearForceFont.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ShearForceFontWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.ShearForceFont.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.ShearForceFont.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.ShearForceFont.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.ShearForceFont.LineJoin;
                    break;

                case "LineMomentForceSelected":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.MomentForceSelected.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.MomentForceSelected.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.MomentForceSelected.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.MomentForceSelected.B);
                    Slider_A.Value = Options.Colors.MomentForceSelected.A;
                    Slider_R.Value = Options.Colors.MomentForceSelected.R;
                    Slider_G.Value = Options.Colors.MomentForceSelected.G;
                    Slider_B.Value = Options.Colors.MomentForceSelected.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.MomentForceSelected.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.MomentForceSelected.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.MomentForceSelectedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.MomentForceSelected.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.MomentForceSelected.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.MomentForceSelected.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.MomentForceSelected.LineJoin;
                    break;

                case "LineMomentForceFont":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.MomentForceFont.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.MomentForceFont.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.MomentForceFont.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.MomentForceFont.B);
                    Slider_A.Value = Options.Colors.MomentForceFont.A;
                    Slider_R.Value = Options.Colors.MomentForceFont.R;
                    Slider_G.Value = Options.Colors.MomentForceFont.G;
                    Slider_B.Value = Options.Colors.MomentForceFont.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.MomentForceFont.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.MomentForceFont.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.MomentForceFontWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.MomentForceFont.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.MomentForceFont.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.MomentForceFont.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.MomentForceFont.LineJoin;
                    break;

                case "LineMomentForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.MomentForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.MomentForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.MomentForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.MomentForce.B);
                    Slider_A.Value = Options.Colors.MomentForce.A;
                    Slider_R.Value = Options.Colors.MomentForce.R;
                    Slider_G.Value = Options.Colors.MomentForce.G;
                    Slider_B.Value = Options.Colors.MomentForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.MomentForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.MomentForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.MomentForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.MomentForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.MomentForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.MomentForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.MomentForce.LineJoin;
                    break;

                case "LineShearForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.ShearForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.ShearForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.ShearForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.ShearForce.B);
                    Slider_A.Value = Options.Colors.ShearForce.A;
                    Slider_R.Value = Options.Colors.ShearForce.R;
                    Slider_G.Value = Options.Colors.ShearForce.G;
                    Slider_B.Value = Options.Colors.ShearForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.ShearForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.ShearForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ShearForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.ShearForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.ShearForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.ShearForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.ShearForce.LineJoin;
                    break;

                case "LineDistributedForceSelected":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.DistributedForceSelected.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.DistributedForceSelected.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.DistributedForceSelected.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.DistributedForceSelected.B);
                    Slider_A.Value = Options.Colors.DistributedForceSelected.A;
                    Slider_R.Value = Options.Colors.DistributedForceSelected.R;
                    Slider_G.Value = Options.Colors.DistributedForceSelected.G;
                    Slider_B.Value = Options.Colors.DistributedForceSelected.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.DistributedForceSelected.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.DistributedForceSelected.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.DistributedForceSelectedWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.DistributedForceSelected.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.DistributedForceSelected.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.DistributedForceSelected.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.DistributedForceSelected.LineJoin;
                    break;

                case "LineDistributedForce":
                    SingleValue_ColorAlpha.SetTheValue(Options.Colors.DistributedForce.A);
                    SingleValue_ColorRed.SetTheValue(Options.Colors.DistributedForce.R);
                    SingleValue_ColorGreen.SetTheValue(Options.Colors.DistributedForce.G);
                    SingleValue_ColorBlue.SetTheValue(Options.Colors.DistributedForce.B);
                    Slider_A.Value = Options.Colors.DistributedForce.A;
                    Slider_R.Value = Options.Colors.DistributedForce.R;
                    Slider_G.Value = Options.Colors.DistributedForce.G;
                    Slider_B.Value = Options.Colors.DistributedForce.B;

                    SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.DistributedForce.DashOffset);
                    SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.DistributedForce.MiterLimit);
                    SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.DistributedForceWeight);

                    ComboBox_LineStyle.SelectedIndex = (int)Options.Lines.DistributedForce.DashStyle;
                    ComboBox_NearCapStyle.SelectedIndex = (int)Options.Lines.DistributedForce.StartCap;
                    ComboBox_FarCapStyle.SelectedIndex = (int)Options.Lines.DistributedForce.EndCap;
                    ComboBox_LineJoinStyle.SelectedIndex = (int)Options.Lines.DistributedForce.LineJoin;
                    break;

                case "LineNodeFree":

                    break;

                case "LineNodeFixed":

                    break;

                case "LineNodePin":

                    break;

                case "LineNodeRollerX":

                    break;

                case "LineNodeRollerY":

                    break;

                case "LineNodeOther":

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
                switch (Options.Colors.ColorToEdit)
                {
                    case "ColorBackground":
                        Options.Colors.Background = tmpColor;
                        break;

                    case "LineGridNormal":
                        Options.Colors.GridNormal = tmpColor;
                        Options.Lines.GridNormal.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.GridNormal.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.GridNormal.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.GridNormal.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.GridNormal.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.GridNormal.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.GridNormalWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.GridNormal.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.GridNormal.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.GridNormalWeight);
                        break;

                    case "LineGridMinor":
                        Options.Colors.GridMinor = tmpColor;
                        Options.Lines.GridMinor.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.GridMinor.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.GridMinor.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.GridMinor.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.GridMinor.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.GridMinor.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.GridMinorWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.GridMinor.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.GridMinor.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.GridMinorWeight);
                        break;

                    case "LineGridMajor":
                        Options.Colors.GridMajor = tmpColor;
                        Options.Lines.GridMajor.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.GridMajor.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.GridMajor.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.GridMajor.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.GridMajor.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.GridMajor.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.GridMajorWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.GridMajor.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.GridMajor.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.GridMajorWeight);
                        break;

                    case "LineForce":
                        Options.Colors.Force = tmpColor;
                        Options.Lines.Force.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.Force.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.Force.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.Force.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.Force.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.Force.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.ForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.Force.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.Force.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ForceWeight);
                        break;

                    case "LineReaction":
                        Options.Colors.Reaction = tmpColor;
                        Options.Lines.Reaction.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.Reaction.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.Reaction.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.Reaction.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.Reaction.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.Reaction.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.ReactionWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.Reaction.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.Reaction.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ReactionWeight);
                        break;

                    case "LineSelectedElement":
                        Options.Colors.SelectedElement = tmpColor;
                        Options.Lines.SelectedElement.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.SelectedElement.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.SelectedElement.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.SelectedElement.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.SelectedElement.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.SelectedElement.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.SelectedElementWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.SelectedElement.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.SelectedElement.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.SelectedElementWeight);
                        break;

                    case "LineShearForceSelected":
                        Options.Colors.ShearForceSelected = tmpColor;
                        Options.Lines.ShearForceSelected.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.ShearForceSelected.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.ShearForceSelected.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.ShearForceSelected.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.ShearForceSelected.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.ShearForceSelected.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.ShearForceSelectedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.ShearForceSelected.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.ShearForceSelected.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ShearForceSelectedWeight);
                        break;

                    case "LineMomentForceSelected":
                        Options.Colors.MomentForceSelected = tmpColor;
                        Options.Lines.MomentForceSelected.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.MomentForceSelected.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.MomentForceSelected.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.MomentForceSelected.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.MomentForceSelected.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.MomentForceSelected.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.MomentForceSelectedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.MomentForceSelected.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.MomentForceSelected.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.MomentForceSelectedWeight);
                        break;

                    case "LineDistributedForceSelected":
                        Options.Colors.DistributedForceSelected = tmpColor;
                        Options.Lines.DistributedForceSelected.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.DistributedForceSelected.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.DistributedForceSelected.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.DistributedForceSelected.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.DistributedForceSelected.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.DistributedForceSelected.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.DistributedForceSelectedWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.DistributedForceSelected.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.DistributedForceSelected.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.DistributedForceSelectedWeight);
                        break;

                    case "LineShearForce":
                        Options.Colors.ShearForce = tmpColor;
                        Options.Lines.ShearForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.ShearForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.ShearForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.ShearForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.ShearForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.ShearForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.ShearForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.ShearForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.ShearForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.ShearForceWeight);
                        break;

                    case "LineMomentForce":
                        Options.Colors.MomentForce = tmpColor;
                        Options.Lines.MomentForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.MomentForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.MomentForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.MomentForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.MomentForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.MomentForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.MomentForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.MomentForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.MomentForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.MomentForceWeight);
                        break;

                    case "LineDistributedForce":
                        Options.Colors.DistributedForce = tmpColor;
                        Options.Lines.DistributedForce.DashOffset = (float)SingleValue_DashOffset.NewValue;
                        Options.Lines.DistributedForce.DashStyle = (CanvasDashStyle)ComboBox_LineStyle.SelectedIndex;
                        Options.Lines.DistributedForce.EndCap = (CanvasCapStyle)ComboBox_FarCapStyle.SelectedIndex;
                        Options.Lines.DistributedForce.LineJoin = (CanvasLineJoin)ComboBox_LineJoinStyle.SelectedIndex;
                        Options.Lines.DistributedForce.MiterLimit = (float)SingleValue_MiterLimit.NewValue;
                        Options.Lines.DistributedForce.StartCap = (CanvasCapStyle)ComboBox_NearCapStyle.SelectedIndex;
                        Options.Lines.DistributedForceWeight = (float)SingleValue_LineWeight.NewValue;
                        SingleValue_DashOffset.SetTheValue((decimal)Options.Lines.DistributedForce.DashOffset);
                        SingleValue_MiterLimit.SetTheValue((decimal)Options.Lines.DistributedForce.MiterLimit);
                        SingleValue_LineWeight.SetTheValue((decimal)Options.Lines.DistributedForceWeight);
                        break;

                    case "LineNodeFree":

                        break;

                    case "LineNodeFixed":

                        break;

                    case "LineNodePin":

                        break;

                    case "LineNodeRollerX":

                        break;

                    case "LineNodeRollerY":

                        break;

                    case "LineNodeOther":

                        break;
                }

                Rectangle_Color.Fill = new SolidColorBrush(tmpColor);
                SingleValue_ColorAlpha.SetTheValue(tmpColor.A);
                SingleValue_ColorRed.SetTheValue(tmpColor.R);
                SingleValue_ColorGreen.SetTheValue(tmpColor.G);
                SingleValue_ColorBlue.SetTheValue(tmpColor.B);
                
                Options.Colors.Save();
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