using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.Graphics.Canvas.Text;
using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Text;
using System.Diagnostics;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Numerics;
using Windows.UI.Input;
using Windows.Foundation;
using Microsoft.Graphics.Canvas.Geometry;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class ConstructionDisplay : Page
    {
        #region Properties

        #region Operations

        internal static ConstructionDisplay Current;
        private SelectionState CurrentSelectionState = SelectionState.Ready;
        private Vector2 FirstNodePosition;
        private bool IsLoaded = false;

        #endregion

        #region Colors

        private Color ColorBackground = Options.ColorBackground;

        private Color ColorForce = Options.ColorForce;
        private Color ColorReaction = Options.ColorReaction;

        private Color ColorGridNormal = Options.ColorGridNormal;
        private Color ColorGridMajor = Options.ColorGridMajor;
        private Color ColorGridMinor = Options.ColorGridMinor;

        private Color ColorGridMajorFont = Options.ColorGridMajorFont;

        private Color ColorSelectedElement = Options.ColorSelectedElement;
        private Color ColorSelectedNode = Options.ColorSelectedNode;

        private Color ColorShearForceSelected = Options.ColorShearForceSelected;
        private Color ColorMomentForceSelected = Options.ColorMomentForceSelected;
        private Color ColorShearForce = Options.ColorShearForce;
        private Color ColorMomentForce = Options.ColorMomentForce;
        private Color ColorDistributedForce = Options.ColorDistributedForce;
        private Color ColorDistributedForceSelected = Options.ColorDistributedForceSelected;

        private Color ColorNodeFree = Options.ColorNodeFree;
        private Color ColorNodeFixed = Options.ColorNodeFixed;
        private Color ColorNodePin = Options.ColorNodePin;
        private Color ColorNodeRollerX = Options.ColorNodeRollerX;
        private Color ColorNodeRollerY = Options.ColorNodeRollerY;
        private Color ColorNodeOther = Options.ColorNodeFree;
        private Color ColorLabel = Color.FromArgb(255, 205, 205, 205);
        private Color ColorHeaderLabel = Color.FromArgb(255, 255, 255, 255);

        private Brush BrushBackground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        #endregion

        #region Lines

        private CanvasStrokeStyle LineGridNormal = Options.LineGridNormal;
        private CanvasStrokeStyle LineGridMinor = Options.LineGridMinor;
        private CanvasStrokeStyle LineGridMajor = Options.LineGridMajor;
        private CanvasStrokeStyle LineForce = Options.LineForce;
        private CanvasStrokeStyle LineReaction = Options.LineReaction;
        private CanvasStrokeStyle LineSelectedElement = Options.LineSelectedElement;
        private CanvasStrokeStyle LineShearForceSelected = Options.LineShearForceSelected;
        private CanvasStrokeStyle LineMomentForceSelected = Options.LineMomentForceSelected;
        private CanvasStrokeStyle LineShearForce = Options.LineShearForce;
        private CanvasStrokeStyle LineMomentForce = Options.LineMomentForce;
        private CanvasStrokeStyle LineDistributedForce = Options.LineDistributedForce;
        private CanvasStrokeStyle LineDistributedForceSelected = Options.LineDistributedForceSelected;
        private CanvasStrokeStyle LineNodeFree = Options.LineNodeFree;
        private CanvasStrokeStyle LineNodeFixed = Options.LineNodeFixed;
        private CanvasStrokeStyle LineNodePin = Options.LineNodePin;
        private CanvasStrokeStyle LineNodeRollerX = Options.LineNodeRollerX;
        private CanvasStrokeStyle LineNodeRollerY = Options.LineNodeRollerY;
        private CanvasStrokeStyle LineNodeOther = Options.LineNodeOther;


        #endregion

        #region Fonts

        //Font setup is in the create resources method.
        private CanvasTextFormat LabelGridX;
        private CanvasTextFormat LabelGridY;
        private CanvasTextFormat LabelFormat;
        private CanvasTextFormat LabelHeaderFormat;

        #endregion       

        #region CanvasBitmaps

        private CanvasBitmap bitMapNodePinnedTop;
        private CanvasBitmap bitMapNodeRollerTop;
        private CanvasBitmap bitMapNodeFixedTop;
        private CanvasBitmap bitMapNodeTrackTop;

        private CanvasBitmap bitMapNodePinnedBottom;
        private CanvasBitmap bitMapNodeRollerBottom;
        private CanvasBitmap bitMapNodeFixedBottom;
        private CanvasBitmap bitMapNodeTrackBottom;

        private CanvasBitmap bitMapNodePinnedLeft;
        private CanvasBitmap bitMapNodeRollerLeft;
        private CanvasBitmap bitMapNodeFixedLeft;
        private CanvasBitmap bitMapNodeTrackLeft;

        private CanvasBitmap bitMapNodePinnedRight;
        private CanvasBitmap bitMapNodeRollerRight;
        private CanvasBitmap bitMapNodeFixedRight;
        private CanvasBitmap bitMapNodeTrackRight;

        #endregion

        #region Transforms

        private TransformGroup transforms;
        private MatrixTransform previousTransform;
        private CompositeTransform deltaTransform;
        private bool forceManipulationsToEnd;

        #endregion

        private byte OriginalMinorGridAlpha;
        private byte OriginalNormalGridAlpha;
        private byte OriginalMajorGridAlpha;

        private float MinorGridAlphaChange;
        private float NormalGridAlphaChange;
        private float MajorGridAlphaChange;

        private float TotalGridChanges = 40;
        private static float CounterGridChanges = 0;


        #endregion

        #region Constructor

        public ConstructionDisplay()
        {
            this.InitializeComponent();
            forceManipulationsToEnd = false;
            InitManipulationTransforms();

            // Register for the various manipulation events that will occur on the shape
            canvas.ManipulationStarted += new ManipulationStartedEventHandler(Canvas_ManipulationStarted);
            canvas.ManipulationDelta += new ManipulationDeltaEventHandler(Canvas_ManipulationDelta);
            canvas.ManipulationCompleted += new ManipulationCompletedEventHandler(Canvas_ManipulationCompleted);
            canvas.ManipulationInertiaStarting += new ManipulationInertiaStartingEventHandler(Canvas_ManipulationInertiaStarting);

            // The ManipulationMode property dictates what manipulation events the element
            // will listen to.  This will set it to a limited subset of these events.
            canvas.ManipulationMode =
                ManipulationModes.TranslateX |
                ManipulationModes.TranslateY |
                ManipulationModes.Scale |
                ManipulationModes.Rotate |
                ManipulationModes.TranslateInertia |
                ManipulationModes.ScaleInertia |
                ManipulationModes.RotateInertia;
        }

        private void InitManipulationTransforms()
        {
            transforms = new TransformGroup();
            previousTransform = new MatrixTransform() { Matrix = Matrix.Identity };
            deltaTransform = new CompositeTransform();

            transforms.Children.Add(previousTransform);
            transforms.Children.Add(deltaTransform);

            // Set the render transform on the rect
            canvas.RenderTransform = transforms;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;

            UpdateColors();
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (IsLoaded)
            {
                Camera.ViewportSize = new Vector2((int)canvas.ActualWidth, (int)canvas.ActualHeight);
            }

        }

        private void Canvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            LabelGridX = new CanvasTextFormat() { FontSize = 12, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };
            LabelGridY = new CanvasTextFormat() { FontSize = 12, FontWeight = FontWeights.Normal, HorizontalAlignment = CanvasHorizontalAlignment.Right, FontFamily = "Segoe UI" };

            LabelFormat = new CanvasTextFormat() { FontSize = 14, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };
            LabelHeaderFormat = new CanvasTextFormat() { FontSize = 14, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };

            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
            //Dots = new CanvasStrokeStyle() { LineJoin = CanvasLineJoin.Round, DashStyle = CanvasDashStyle.Dot };

        }

        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {

            bitMapNodePinnedTop = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodePinnedTop.png");
            bitMapNodeRollerTop = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeRollerTop.png");
            bitMapNodeFixedTop = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeFixedTop.png");
            bitMapNodeTrackTop = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeTrackTop.png");

            bitMapNodePinnedBottom = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodePinnedBottom.png");
            bitMapNodeRollerBottom = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeRollerBottom.png");
            bitMapNodeFixedBottom = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeFixedBottom.png");
            bitMapNodeTrackBottom = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeTrackBottom.png");

            bitMapNodePinnedLeft = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodePinnedLeft.png");
            bitMapNodeRollerLeft = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeRollerLeft.png");
            bitMapNodeFixedLeft = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeFixedLeft.png");
            bitMapNodeTrackLeft = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeTrackLeft.png");

            bitMapNodePinnedRight = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodePinnedRight.png");
            bitMapNodeRollerRight = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeRollerRight.png");
            bitMapNodeFixedRight = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeFixedRight.png");
            bitMapNodeTrackRight = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\NodeTrackRight.png");



            //ReloadColors();
            //AlphaFade = ColorGridMinor.A;
        }

        #endregion

        #region Draw Loop

        private void Canvas_DrawAnimated(ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {

            #region Transform and other Settings

            args.DrawingSession.Clear(ColorBackground);
            args.DrawingSession.Transform = Camera.TranslationMatrix;
            args.DrawingSession.Antialiasing = Microsoft.Graphics.Canvas.CanvasAntialiasing.Aliased;
            //args.DrawingSession.Antialiasing = Microsoft.Graphics.Canvas.CanvasAntialiasing.Antialiased;

            #endregion
            #region Grid

            float iX = Camera.TopLeftMinor.X;
            float iY = Camera.TopLeftMinor.Y;
            int lineCountX = 0;
            int lineCountY = 0;

            try
            {
                #region Grid Fade

                if (CounterGridChanges < TotalGridChanges)
                {
                    CounterGridChanges += 1;
                    ColorGridMinor = Color.FromArgb(Convert.ToByte(MinorGridAlphaChange * CounterGridChanges), ColorGridMinor.R, ColorGridMinor.G, ColorGridMinor.B);
                    ColorGridNormal = Color.FromArgb(Convert.ToByte(NormalGridAlphaChange * CounterGridChanges), ColorGridNormal.R, ColorGridNormal.G, ColorGridNormal.B);
                    ColorGridMajor = Color.FromArgb(Convert.ToByte(MajorGridAlphaChange * CounterGridChanges), ColorGridMajor.R, ColorGridMajor.G, ColorGridMajor.B);
                }

                #endregion

                #region Minor Grid

                do
                {
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, ColorGridMinor, Camera.LineUnit, LineGridMinor);
                    iX += Camera.GridSizeMinor;
                    lineCountX++;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), ColorGridMinor, Camera.LineUnit, LineGridMinor);
                    iY += Camera.GridSizeMinor;
                    lineCountY++;
                }
                while (iY < Camera.BottomRight.Y);

                #endregion
                #region Major Normal

                iX = Camera.TopLeftNormal.X;
                iY = Camera.TopLeftNormal.Y;
                do
                {
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, ColorBackground, Camera.LineUnit, LineGridNormal);
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, ColorGridNormal, Camera.LineUnit, LineGridNormal);
                    iX += Camera.GridSizeNormal;
                    lineCountX++;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), ColorBackground, Camera.LineUnit, LineGridNormal);
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), ColorGridNormal, Camera.LineUnit, LineGridNormal);
                    iY += Camera.GridSizeNormal;
                    lineCountY++;
                }
                while (iY < Camera.BottomRight.Y);

                #endregion
                #region Major Grid

                iX = Camera.TopLeftMajor.X;
                iY = Camera.TopLeftMajor.Y;
                do
                {
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, ColorBackground, Camera.LineUnit, LineGridMajor);
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, ColorGridMajor, Camera.LineUnit, LineGridMajor);
                    iX += Camera.GridSizeMajor;
                    lineCountX++;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), ColorBackground, Camera.LineUnit, LineGridMajor);
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), ColorGridMajor, Camera.LineUnit, LineGridMajor);
                    iY += Camera.GridSizeMajor;
                    lineCountY++;
                }
                while (iY < Camera.BottomRight.Y);

                #endregion
            }
            catch { }

            #endregion
            #region Draw LDL's

            args.DrawingSession.Antialiasing = Microsoft.Graphics.Canvas.CanvasAntialiasing.Antialiased;

            if (Options.ShowLinear)
            {
                try
                {
                    foreach (var Item in Model.Members.MembersWithLinearLoads)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearLDLLine, ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarLDLLine, ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearLDLLine, nextSegment.Value.FarLDLLine, ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.LineLengthLDLArrow), ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.LineLengthLDLArrow), ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.LineLengthLDLArrow), ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.LineLengthLDLArrow), ColorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, LineDistributedForce);

                        }
                    }
                }
                catch { }
            }

            #endregion
            #region Draw Members

            try
            {
                foreach (var Item in Model.Members)
                {
                    foreach (var nextItem in Item.Value.Segments)
                    {
                        args.DrawingSession.DrawLine(nextItem.Value.NearVector, nextItem.Value.FarVector, nextItem.Value.CurrentColor, Camera.LineUnit * Item.Value.Section.LineWeight, Item.Value.Section.LineStyle);
                    }
                }
            }
            catch { }

            #endregion
            #region Draw Images for Constraints

            try
            {
                foreach (var Item in Model.Nodes.NodesWithConstraints)
                {
                    switch (Item.Value.Constraints.ConstraintType)
                    {
                        case ConstraintType.FixedBottom:
                            args.DrawingSession.DrawImage(bitMapNodeFixedBottom, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y - 33 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.FixedTop:
                            args.DrawingSession.DrawImage(bitMapNodeFixedTop, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.FixedLeft:
                            args.DrawingSession.DrawImage(bitMapNodeFixedLeft, new Rect(Item.Value.Location.X - 33 * Camera.LineUnit, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.FixedRight:
                            args.DrawingSession.DrawImage(bitMapNodeFixedRight, new Rect(Item.Value.Location.X, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;

                        case ConstraintType.PinnedBottom:
                            args.DrawingSession.DrawImage(bitMapNodePinnedBottom, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y - 33 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.PinnedTop:
                            args.DrawingSession.DrawImage(bitMapNodePinnedTop, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.PinnedLeft:
                            args.DrawingSession.DrawImage(bitMapNodePinnedLeft, new Rect(Item.Value.Location.X - 33 * Camera.LineUnit, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.PinnedRight:
                            args.DrawingSession.DrawImage(bitMapNodePinnedRight, new Rect(Item.Value.Location.X, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;

                        case ConstraintType.RollerBottom:
                            args.DrawingSession.DrawImage(bitMapNodeRollerBottom, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y - 33 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.RollerTop:
                            args.DrawingSession.DrawImage(bitMapNodeRollerTop, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.RollerLeft:
                            args.DrawingSession.DrawImage(bitMapNodeRollerLeft, new Rect(Item.Value.Location.X - 33 * Camera.LineUnit, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.RollerRight:
                            args.DrawingSession.DrawImage(bitMapNodeRollerRight, new Rect(Item.Value.Location.X, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;

                        case ConstraintType.TrackBottom:
                            args.DrawingSession.DrawImage(bitMapNodeTrackBottom, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y - 33 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.TrackTop:
                            args.DrawingSession.DrawImage(bitMapNodeTrackTop, new Rect(Item.Value.Location.X - 16 * Camera.LineUnit, Item.Value.Location.Y, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.TrackLeft:
                            args.DrawingSession.DrawImage(bitMapNodeTrackLeft, new Rect(Item.Value.Location.X - 33 * Camera.LineUnit, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                        case ConstraintType.TrackRight:
                            args.DrawingSession.DrawImage(bitMapNodeTrackRight, new Rect(Item.Value.Location.X, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            break;
                    }
                }
            }
            catch { }

            #endregion
            #region Draw Forces

            try
            {
                foreach (var Item in Model.Nodes.NodesWithNodalLoads)
                {
                    args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + Item.Value.ForceLine, ColorForce, Camera.LineUnit * Options.LineForceWeight, LineForce);
                    args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + (Item.Value.ForceUnitLeft * Camera.LineLengthForceArrow), ColorForce, Camera.LineUnit * Options.LineForceWeight, LineForce);
                    args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + (Item.Value.ForceUnitRight * Camera.LineLengthForceArrow), ColorForce, Camera.LineUnit * Options.LineForceWeight, LineForce);
                }
            }
            catch { }

            #endregion
            #region Draw Circles for Constraints

            try
            {
                foreach (var Item in Model.Nodes.NodesWithConstraints)
                {
                    switch (Item.Value.Constraints.ConstraintType)
                    {
                        case ConstraintType.FixedBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeFixed, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.FixedTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeFixed, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.FixedLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeFixed, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.FixedRight:
                            args.DrawingSession.DrawImage(bitMapNodeFixedRight, new Rect(Item.Value.Location.X, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeFixed, Camera.ConstraintWidth);
                            break;

                        case ConstraintType.PinnedBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedRight:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;

                        case ConstraintType.RollerBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeRollerX, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.RollerTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeRollerX, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.RollerLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeRollerY, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.RollerRight:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodeRollerY, Camera.ConstraintWidth);
                            break;

                        case ConstraintType.TrackBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.TrackTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.TrackLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.TrackRight:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, ColorNodePin, Camera.ConstraintWidth);
                            break;
                    }
                }
            }
            catch { }

            #endregion
            #region Draw Selected Member

            try
            {
                if (!object.ReferenceEquals(null, Model.Members.CurrentMember))
                {
                    foreach (var nextItem in Model.Members.CurrentMember.Segments)
                    {
                        args.DrawingSession.DrawLine(nextItem.Value.NearVector, nextItem.Value.FarVector, ColorSelectedElement, Camera.LineUnit * (Model.Members.CurrentMember.Section.LineWeight + 2), nextItem.Value.Section.LineStyle);
                    }
                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.ConstraintRadius, ColorBackground);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.ConstraintRadius, ColorSelectedElement, Camera.ConstraintWidth);
                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.ConstraintRadius, ColorBackground);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.ConstraintRadius, ColorSelectedElement, Camera.ConstraintWidth);
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }

            #endregion        
            #region Draw Selected Node

            try
            {
                switch (CurrentSelectionState)
                {
                    case SelectionState.Ready:
                        //nothing?
                        break;

                    case SelectionState.FirstNode:
                        //create member and continue.
                        args.DrawingSession.FillCircle(FirstNodePosition, 4 * Camera.LineUnit, ColorSelectedNode);
                        break;

                    case SelectionState.SecondNode:
                        //should not get here?
                        break;
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }

            #endregion
            #region Debug Text

            //args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(350, 20));
            //args.DrawingSession.DrawText("CAMERA", 0, 0, Colors.Gray, LabelHeaderFormat);
            //args.DrawingSession.DrawText("Position: " + Camera.Position, 0, 20, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("Zoom: " + Camera.Zoom, 0, 40, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("ViewportWidth: " + Camera.ViewportWidth + " " + Camera.ViewportHeight, 0, 60, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("ViewportCenter: " + Camera.ViewportCenter, 0, 80, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("translationTrim: " + Camera.translationTrim, 0, 100, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("TranslationMatrix: " + Camera.TranslationMatrix, 0, 120, Colors.White, LabelFormat);

            //args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(350, 200));
            //args.DrawingSession.DrawText("GRID", 0, 0, Colors.Gray, LabelHeaderFormat);
            //args.DrawingSession.DrawText("gridSizeNormal: " + Camera.GridSizeNormal, 0, 20, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("TopLeft: " + Camera.TopLeftNormal, 0, 40, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("BottomRight: " + Camera.BottomRight, 0, 60, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("lineCountX: " + lineCountX, 0, 80, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("lineCountY: " + lineCountY, 0, 100, Colors.White, LabelFormat);
            //args.DrawingSession.DrawText("LineUnit: " + Camera.LineUnit, 0, 120, Colors.White, LabelFormat);

            //args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(Camera.ViewportCenter.X - 3, Camera.ViewportCenter.Y - 3));
            //args.DrawingSession.DrawRectangle(0, 0, 5, 5, ColorSelectedElement, 4);

            #endregion
            #region Grid Labels

            try
            {
                args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(10, -20));

                iX = Camera.TopLeftMinor.X;
                iY = Camera.TopLeftMinor.Y;
                do
                {
                    args.DrawingSession.DrawText(
                        Math.Round((iX * Camera.LengthUnitFactor), 3).ToString() + Camera.LengthUnitString, (Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (iX * Camera.ZoomTrimmed),
                        Camera.ViewportSize.Y + 2,
                        ColorGridMajorFont, LabelGridX
                        );

                    iX += Camera.GridSizeMinor;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawText(
                        Math.Round((iY * Camera.LengthUnitFactor), 3).ToString() + Camera.LengthUnitString, Camera.ViewportSize.X - 15,
                        (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y - (iY * Camera.ZoomTrimmed),
                        ColorGridMajorFont, LabelGridY);
                    iY += Camera.GridSizeMinor;
                }
                while (iY < Camera.BottomRight.Y);
            }
            catch { }

            #endregion
        }

        #endregion

        #region Input

        private void Page_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            try
            {
                CounterGridChanges = 0;
                PointerPoint mousePosition = e.GetCurrentPoint(ConstructionDisplay.Current);
                int delta = mousePosition.Properties.MouseWheelDelta;
                switch (delta)
                {
                    case -120:
                        Camera.ScaleDeltaScrollWheel(0.9f, new Vector2((float)mousePosition.Position.X, (float)mousePosition.Position.Y));
                        break;
                    case 120:
                        Camera.ScaleDeltaScrollWheel(1.1f, new Vector2((float)mousePosition.Position.X, (float)mousePosition.Position.Y));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }

        }

        private void Canvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
        }

        private void Canvas_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            try
            {
                // If the reset button has been pressed, mark the manipulation as completed
                if (forceManipulationsToEnd)
                {
                    e.Complete();
                    return;
                }
                previousTransform.Matrix = transforms.Value;

                // Get center point for rotation
                Windows.Foundation.Point center = previousTransform.TransformPoint(new Windows.Foundation.Point(e.Position.X, e.Position.Y));

                deltaTransform.CenterX = center.X;
                deltaTransform.CenterY = center.Y;

                if (e.Delta.Scale != 1)
                {
                    CounterGridChanges = 0;
                    Camera.ScaleDeltaScrollWheel((float)e.Delta.Scale, new Vector2((float)center.X, (float)center.Y));
                }

                if ((e.Delta.Translation.X != 0) | e.Delta.Translation.Y != 0)
                {
                    CounterGridChanges = 0;
                    Camera.MoveCamera(e.Delta.Translation.ToVector2());
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
        }

        private void Canvas_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingRoutedEventArgs e)
        {

        }

        private void Canvas_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {

        }

        private void Canvas_ManipulationStarting(object sender, ManipulationStartingRoutedEventArgs e)
        {

        }

        private void Canvas_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            try
            {
                Vector2 MousePoint = Camera.ScreenToWorld(new Vector2((float)e.GetPosition(canvas).X, (float)e.GetPosition(canvas).Y));
                switch (CurrentSelectionState)
                {
                    case SelectionState.Ready:
                        //Start new member.
                        FirstNodePosition = new Vector2(Camera.Snap(MousePoint.X, Camera.GridSizeMinor), Camera.Snap(MousePoint.Y, Camera.GridSizeMinor));
                        Model.Members.CurrentMember = null;
                        CurrentSelectionState = SelectionState.FirstNode;
                        break;

                    case SelectionState.FirstNode:
                        //Cancel selection?

                        CurrentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Construction.Current.ShowModel();
                        break;

                    case SelectionState.SecondNode:
                        //finish member then cancel.

                        AddMember(FirstNodePosition, new Vector2(Camera.Snap(MousePoint.X, Camera.GridSizeMinor), Camera.Snap(MousePoint.Y, Camera.GridSizeMinor)));
                        CurrentSelectionState = SelectionState.Ready;

                        break;
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
        }

        private void Canvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Vector2 MousePoint = Camera.ScreenToWorld(new Vector2((float)e.GetPosition(canvas).X, (float)e.GetPosition(canvas).Y));

            switch (CurrentSelectionState)
            {
                case SelectionState.Ready:
                    //nothing or select member.
                    int tempInt = Model.Members.FindNearestElement(MousePoint);
                    if (tempInt == -1)
                    {
                        CurrentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Construction.Current.ShowModel();
                    }
                    else
                    {
                        Model.Members.CurrentMember = Model.Members[tempInt];
                        Construction.Current.ShowMember();
                    }
                    break;

                case SelectionState.FirstNode:
                    //create member and continue.

                    AddMember(FirstNodePosition, new Vector2(Camera.Snap(MousePoint.X, Camera.GridSizeMinor), Camera.Snap(MousePoint.Y, Camera.GridSizeMinor)));
                    FirstNodePosition = new Vector2(Camera.Snap(MousePoint.X, Camera.GridSizeMinor), Camera.Snap(MousePoint.Y, Camera.GridSizeMinor));
                    break;

                case SelectionState.SecondNode:
                    //should not get here?
                    break;
            }

            try
            {

            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
        }

        private void Canvas_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //Vector2 MousePoint = Camera.ScreenToWorld(new Vector2((float)e.GetPosition(canvas).X, (float)e.GetPosition(canvas).Y));
            switch (CurrentSelectionState)
            {
                case SelectionState.Ready:
                    //nothing?
                    break;

                case SelectionState.FirstNode:
                    //create member and continue.
                    CurrentSelectionState = SelectionState.Ready;
                    break;

                case SelectionState.SecondNode:
                    //should not get here?
                    CurrentSelectionState = SelectionState.Ready;
                    break;
            }

            try
            {

            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
        }

        #endregion

        private void AddMember(Vector2 _firstNodePosition, Vector2 _secondNodePosition)
        {
            //Check if Nodes are the same location.
            if ((_firstNodePosition.X == _secondNodePosition.X) && (_firstNodePosition.Y == _secondNodePosition.Y))
            {
                //Debug.WriteLine("Nodes are the same.");
                return;
            }

            Node NodeNear = null;
            Node NodeFar = null;


            //Debug.WriteLine("New Member " + _firstNodePosition + " " + _secondNodePosition);



            //Switch nodes to suit quadrant.
            if (_firstNodePosition.X < _secondNodePosition.X)
            {
                NodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                NodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
            }
            else if (_firstNodePosition.X > _secondNodePosition.X)
            {
                NodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                NodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
            }
            else
            {
                if (_firstNodePosition.Y < _secondNodePosition.Y)
                {
                    NodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                    NodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                }
                else
                {
                    NodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)_secondNodePosition.X, (decimal)_secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                    NodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)_firstNodePosition.X, (decimal)_firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                }
            }

            //Add Member to the collection.
            try
            {
                Model.Members.CurrentMember = new Member(Model.Members.NextIndex, NodeNear, NodeFar, Model.Sections.CurrentSection, Options.DefaultNumberOfSegments, 0, 0);


                //Model.Members.CurrentMember = Model.Members.AddNewMember(NodeNear, NodeFar, Model.Sections.CurrentSection, Options.DefaultNumberOfSegments, 0, 0);
                Construction.Current.ShowMember();
            }
            catch (Exception ex) { Debug.WriteLine("Error Adding Member " + ex.Message); }


        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Camera.ViewportSize = new Vector2((int)this.ActualWidth, (int)this.ActualHeight);
        }



        public void UpdateColors()
        {
            ColorBackground = Options.ColorBackground;
            ColorForce = Options.ColorForce;
            ColorReaction = Options.ColorReaction;
            ColorGridNormal = Options.ColorGridNormal;
            ColorGridMajor = Options.ColorGridMajor;
            ColorGridMinor = Options.ColorGridMinor;
            ColorGridMajorFont = Options.ColorGridMajorFont;
            ColorSelectedElement = Options.ColorSelectedElement;
            ColorSelectedNode = Options.ColorSelectedNode;
            ColorShearForceSelected = Options.ColorShearForceSelected;
            ColorMomentForceSelected = Options.ColorMomentForceSelected;
            ColorShearForce = Options.ColorShearForce;
            ColorMomentForce = Options.ColorMomentForce;
            ColorDistributedForce = Options.ColorDistributedForce;
            ColorDistributedForceSelected = Options.ColorDistributedForceSelected;
            ColorNodeFree = Options.ColorNodeFree;
            ColorNodeFixed = Options.ColorNodeFixed;
            ColorNodePin = Options.ColorNodePin;
            ColorNodeRollerX = Options.ColorNodeRollerX;
            ColorNodeRollerY = Options.ColorNodeRollerY;
            ColorNodeOther = Options.ColorNodeFree;



            LineGridNormal = Options.LineGridNormal;
            LineGridMinor = Options.LineGridMinor;
            LineGridMajor = Options.LineGridMajor;
            LineForce = Options.LineForce;
            LineReaction = Options.LineReaction;
            LineSelectedElement = Options.LineSelectedElement;
            LineShearForceSelected = Options.LineShearForceSelected;
            LineMomentForceSelected = Options.LineMomentForceSelected;
            LineShearForce = Options.LineShearForce;
            LineMomentForce = Options.LineMomentForce;
            LineDistributedForce = Options.LineDistributedForce;
            LineDistributedForceSelected = Options.LineDistributedForceSelected;
            LineNodeFree = Options.LineNodeFree;
            LineNodeFixed = Options.LineNodeFixed;
            LineNodePin = Options.LineNodePin;
            LineNodeRollerX = Options.LineNodeRollerX;
            LineNodeRollerY = Options.LineNodeRollerY;
            LineNodeFree = Options.LineNodeFree;

            OriginalMinorGridAlpha = ColorGridMinor.A;
            OriginalNormalGridAlpha = ColorGridNormal.A;
            OriginalMajorGridAlpha = ColorGridMajor.A;

            MinorGridAlphaChange = OriginalMinorGridAlpha / TotalGridChanges;
            NormalGridAlphaChange = OriginalNormalGridAlpha / TotalGridChanges;
            MajorGridAlphaChange = OriginalMajorGridAlpha / TotalGridChanges;
        }



    }
}

