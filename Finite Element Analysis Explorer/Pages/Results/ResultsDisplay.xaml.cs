namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using System.Threading.Tasks;
    using Microsoft.Graphics.Canvas;
    using Microsoft.Graphics.Canvas.Geometry;
    using Microsoft.Graphics.Canvas.Text;
    using Microsoft.Graphics.Canvas.UI.Xaml;
    using Windows.Foundation;
    using Windows.UI;
    using Windows.UI.Input;
    using Windows.UI.Text;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;

    /// <summary>
    /// ResultsDisplay Page displays the results from the solver.
    /// </summary>
    public sealed partial class ResultsDisplay : Page
    {
        #region Properties

        #region Operations

        /// <summary>
        /// Gets or sets the current results display page.
        /// </summary>
        internal static ResultsDisplay Current { get; set; }

        private static float counterGridChanges = 0;
        private readonly float totalGridChanges = 40;
        private SelectionState currentSelectionState = SelectionState.Ready;
        private byte originalMinorGridAlpha;
        private byte originalNormalGridAlpha;
        private byte originalMajorGridAlpha;
        private float minorGridAlphaChange;
        private float normalGridAlphaChange;
        private float majorGridAlphaChange;

        #endregion

        #region Colors

        private Color colorBackground = Options.ColorBackground;
        private Color colorForce = Options.ColorForce;
        private Color colorReaction = Options.ColorReaction;
        private Color colorGridNormal = Options.ColorGridNormal;
        private Color colorGridMajor = Options.ColorGridMajor;
        private Color colorGridMinor = Options.ColorGridMinor;
        private Color colorGridMajorFont = Options.ColorGridMajorFont;
        private Color colorSelectedElement = Options.ColorSelectedElement;
        private Color colorSelectedNode = Options.ColorSelectedNode;
        private Color colorShearForceSelected = Options.ColorShearForceSelected;
        private Color colorMomentForceSelected = Options.ColorMomentForceSelected;
        private Color colorShearForceFont = Options.ColorShearForceFont;
        private Color colorMomentForceFont = Options.ColorMomentForceFont;
        private Color colorShearForce = Options.ColorShearForce;
        private Color colorMomentForce = Options.ColorMomentForce;
        private Color colorDistributedForce = Options.ColorDistributedForce;
        private Color colorDistributedForceSelected = Options.ColorDistributedForceSelected;
        private Color colorNodeFree = Options.ColorNodeFree;
        private Color colorNodeFixed = Options.ColorNodeFixed;
        private Color colorNodePin = Options.ColorNodePin;
        private Color colorNodeRollerX = Options.ColorNodeRollerX;
        private Color colorNodeRollerY = Options.ColorNodeRollerY;
        private Color colorNodeOther = Options.ColorNodeFree;
        private Color colorLabel = Color.FromArgb(255, 205, 205, 205);
        private Color colorHeaderLabel = Color.FromArgb(255, 255, 255, 255);
        private Brush brushBackground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        #endregion

        #region Fonts

        // Font setup is in the create resources method.
        private CanvasTextFormat labelGridX;
        private CanvasTextFormat labelGridY;
        private CanvasTextFormat labelFormat;
        private CanvasTextFormat labelHeaderFormat;

        #endregion

        #region Lines

        private CanvasStrokeStyle lineGridNormal = Options.LineGridNormal;
        private CanvasStrokeStyle lineGridMinor = Options.LineGridMinor;
        private CanvasStrokeStyle lineGridMajor = Options.LineGridMajor;
        private CanvasStrokeStyle lineForce = Options.LineForce;
        private CanvasStrokeStyle lineReaction = Options.LineReaction;
        private CanvasStrokeStyle lineSelectedElement = Options.LineSelectedElement;
        private CanvasStrokeStyle lineShearForceSelected = Options.LineShearForceSelected;
        private CanvasStrokeStyle lineMomentForceSelected = Options.LineMomentForceSelected;
        private CanvasStrokeStyle lineShearForce = Options.LineShearForce;
        private CanvasStrokeStyle lineMomentForce = Options.LineMomentForce;
        private CanvasStrokeStyle lineDistributedForce = Options.LineDistributedForce;
        private CanvasStrokeStyle lineDistributedForceSelected = Options.LineDistributedForceSelected;
        private CanvasStrokeStyle lineNodeFree = Options.LineNodeFree;
        private CanvasStrokeStyle lineNodeFixed = Options.LineNodeFixed;
        private CanvasStrokeStyle lineNodePin = Options.LineNodePin;
        private CanvasStrokeStyle lineNodeRollerX = Options.LineNodeRollerX;
        private CanvasStrokeStyle lineNodeRollerY = Options.LineNodeRollerY;
        private CanvasStrokeStyle lineNodeOther = Options.LineNodeOther;

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

        private CanvasBitmap bitMapMomentForceAntiClockwise;
        private CanvasBitmap bitMapMomentForceClockwise;
        private CanvasBitmap bitMapMomentReactionAntiClockwise;
        private CanvasBitmap bitMapMomentReactionClockwise;

        #endregion

        #region Transforms

        private TransformGroup transforms;
        private MatrixTransform previousTransform;
        private CompositeTransform deltaTransform;
        private bool forceManipulationsToEnd;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultsDisplay"/> class.
        /// </summary>
        public ResultsDisplay()
        {
            InitializeComponent();
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

        #endregion

        #region Canvas Other
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Camera.Viewport.Size = new Vector2((int)canvas.ActualWidth, (int)canvas.ActualHeight);
        }

        private void Canvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            labelGridX = new CanvasTextFormat() { FontSize = 12, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };
            labelGridY = new CanvasTextFormat() { FontSize = 12, FontWeight = FontWeights.Normal, HorizontalAlignment = CanvasHorizontalAlignment.Right, FontFamily = "Segoe UI" };

            labelFormat = new CanvasTextFormat() { FontSize = 14, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };
            labelHeaderFormat = new CanvasTextFormat() { FontSize = 14, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };

            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        private async Task CreateResourcesAsync(CanvasAnimatedControl sender)
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

            bitMapMomentForceAntiClockwise = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\MomentForceAntiClockwise.png");
            bitMapMomentForceClockwise = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\MomentForceClockwise.png");
            bitMapMomentReactionAntiClockwise = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\MomentReactionAntiClockwise.png");
            bitMapMomentReactionClockwise = await CanvasBitmap.LoadAsync(sender, @"Assets\Nodes\MomentReactionClockwise.png");

        }

        #endregion

        #region Draw Loop

        private void Canvas_DrawAnimated(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.Clear(colorBackground);
            args.DrawingSession.Transform = Camera.TranslationMatrix;
            args.DrawingSession.Antialiasing = CanvasAntialiasing.Aliased;

            float iX = Camera.Viewport.TopLeftMinor.X;
            float iY = Camera.Viewport.TopLeftMinor.Y;
            int lineCountX = 0;
            int lineCountY = 0;

            try
            {
                if (counterGridChanges < totalGridChanges)
                {
                    counterGridChanges += 1;
                    colorGridMinor = Color.FromArgb(Convert.ToByte(minorGridAlphaChange * counterGridChanges), colorGridMinor.R, colorGridMinor.G, colorGridMinor.B);
                    colorGridNormal = Color.FromArgb(Convert.ToByte(normalGridAlphaChange * counterGridChanges), colorGridNormal.R, colorGridNormal.G, colorGridNormal.B);
                    colorGridMajor = Color.FromArgb(Convert.ToByte(majorGridAlphaChange * counterGridChanges), colorGridMajor.R, colorGridMajor.G, colorGridMajor.B);
                }

                do
                {
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, colorGridMinor, Camera.Line.Unit, lineGridMinor);
                    iX += Camera.Grid.SizeMinor;
                    lineCountX++;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, colorGridMinor, Camera.Line.Unit, lineGridMinor);
                    iY += Camera.Grid.SizeMinor;
                    lineCountY++;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
                iX = Camera.Viewport.TopLeftNormal.X;
                iY = Camera.Viewport.TopLeftNormal.Y;
                do
                {
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, colorBackground, Camera.Line.Unit, lineGridNormal);
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, colorGridNormal, Camera.Line.Unit, lineGridNormal);
                    iX += Camera.Grid.SizeNormal;
                    lineCountX++;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, colorBackground, Camera.Line.Unit, lineGridNormal);
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, colorGridNormal, Camera.Line.Unit, lineGridNormal);
                    iY += Camera.Grid.SizeNormal;
                    lineCountY++;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
                iX = Camera.Viewport.TopLeftMajor.X;
                iY = Camera.Viewport.TopLeftMajor.Y;
                do
                {
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, colorBackground, Camera.Line.Unit, lineGridMajor);
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, colorGridMajor, Camera.Line.Unit, lineGridMajor);
                    iX += Camera.Grid.SizeMajor;
                    lineCountX++;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, colorBackground, Camera.Line.Unit, lineGridMajor);
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, colorGridMajor, Camera.Line.Unit, lineGridMajor);
                    iY += Camera.Grid.SizeMajor;
                    lineCountY++;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
            }
            catch
            {
            }

            args.DrawingSession.Antialiasing = CanvasAntialiasing.Antialiased;

            if (Options.ShowLinear)
            {
                try
                {
                    foreach (var item in Model.Members.MembersWithLinearLoads)
                    {
                        foreach (var nextSegment in item.Value.Segments)
                        {
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearLDLLine, colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarLDLLine, colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearLDLLine, nextSegment.Value.FarLDLLine, colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.Line.LengthLDLArrow), colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.Line.LengthLDLArrow), colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.Line.LengthLDLArrow), colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.Line.LengthLDLArrow), colorDistributedForce, Camera.Line.Unit * Options.LineDistributedForceWeight, lineDistributedForce);
                        }
                    }
                }
                catch
                {
                }
            }

            if (Options.ShowShear)
            {
                try
                {
                    foreach (var item in Model.Members)
                    {
                        foreach (var nextItem in item.Value.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.ShearNear, colorShearForce, Camera.Line.Unit * Options.LineShearForceWeight, lineShearForce);
                            }

                            args.DrawingSession.DrawLine(nextItem.Value.ShearNear, nextItem.Value.ShearFar, colorShearForce, Camera.Line.Unit * Options.LineShearForceWeight, lineShearForce);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.ShearFar, colorShearForce, Camera.Line.Unit * Options.LineShearForceWeight, lineShearForce);
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            if (Options.ShowMoment)
            {
                try
                {
                    foreach (var item in Model.Members)
                    {
                        foreach (var nextItem in item.Value.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.MomentNear, colorMomentForce, Camera.Line.Unit * Options.LineMomentForceWeight, lineMomentForce);
                            }

                            args.DrawingSession.DrawLine(nextItem.Value.MomentNear, nextItem.Value.MomentFar, colorMomentForce, Camera.Line.Unit * Options.LineMomentForceWeight, lineMomentForce);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.MomentFar, colorMomentForce, Camera.Line.Unit * Options.LineMomentForceWeight, lineMomentForce);
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            try
            {
                foreach (var item in Model.Members)
                {
                    foreach (var nextItem in item.Value.Segments)
                    {
                        args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.FarVectorDisplaced, nextItem.Value.CurrentColor, Camera.Line.Unit * item.Value.Section.LineWeight, item.Value.Section.LineStyle);
                    }
                }
            }
            catch
            {
            }

            try
            {
                foreach (var item in Model.Nodes.NodesWithConstraints)
                {
                    switch (item.Value.Constraints.ConstraintType)
                    {
                        case ConstraintType.FixedBottom:
                            args.DrawingSession.DrawImage(bitMapNodeFixedBottom, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y - (33 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.FixedTop:
                            args.DrawingSession.DrawImage(bitMapNodeFixedTop, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y, 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.FixedLeft:
                            args.DrawingSession.DrawImage(bitMapNodeFixedLeft, new Rect(item.Value.Location.X - (33 * Camera.Line.Unit), item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.FixedRight:
                            args.DrawingSession.DrawImage(bitMapNodeFixedRight, new Rect(item.Value.Location.X, item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;

                        case ConstraintType.PinnedBottom:
                            args.DrawingSession.DrawImage(bitMapNodePinnedBottom, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y - (33 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.PinnedTop:
                            args.DrawingSession.DrawImage(bitMapNodePinnedTop, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y, 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.PinnedLeft:
                            args.DrawingSession.DrawImage(bitMapNodePinnedLeft, new Rect(item.Value.Location.X - (33 * Camera.Line.Unit), item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.PinnedRight:
                            args.DrawingSession.DrawImage(bitMapNodePinnedRight, new Rect(item.Value.Location.X, item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;

                        case ConstraintType.RollerBottom:
                            args.DrawingSession.DrawImage(bitMapNodeRollerBottom, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y - (33 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.RollerTop:
                            args.DrawingSession.DrawImage(bitMapNodeRollerTop, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y, 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.RollerLeft:
                            args.DrawingSession.DrawImage(bitMapNodeRollerLeft, new Rect(item.Value.Location.X - (33 * Camera.Line.Unit), item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.RollerRight:
                            args.DrawingSession.DrawImage(bitMapNodeRollerRight, new Rect(item.Value.Location.X, item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;

                        case ConstraintType.TrackBottom:
                            args.DrawingSession.DrawImage(bitMapNodeTrackBottom, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y - (33 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.TrackTop:
                            args.DrawingSession.DrawImage(bitMapNodeTrackTop, new Rect(item.Value.Location.X - (16 * Camera.Line.Unit), item.Value.Location.Y, 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.TrackLeft:
                            args.DrawingSession.DrawImage(bitMapNodeTrackLeft, new Rect(item.Value.Location.X - (33 * Camera.Line.Unit), item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                        case ConstraintType.TrackRight:
                            args.DrawingSession.DrawImage(bitMapNodeTrackRight, new Rect(item.Value.Location.X, item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            break;
                    }
                }
            }
            catch
            {
            }

            try
            {
                foreach (var item in Model.Nodes.NodesWithNodalLoads)
                {
                    args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + item.Value.ForceLine, colorForce, Camera.Line.Unit * Options.LineForceWeight, lineForce);
                    args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + (item.Value.ForceUnitLeft * Camera.Line.LengthForceArrow), colorForce, Camera.Line.Unit * Options.LineForceWeight, lineForce);
                    args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + (item.Value.ForceUnitRight * Camera.Line.LengthForceArrow), colorForce, Camera.Line.Unit * Options.LineForceWeight, lineForce);
                }
            }
            catch
            {
            }

            try
            {
                if (Options.ShowReactions)
                {
                    foreach (var item in Model.Nodes.NodesWithReactions)
                    {
                        args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + item.Value.ReactionLine, colorReaction, Camera.Line.Unit * Options.LineReactionWeight, lineForce);
                        args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + (item.Value.ReactionUnitLeft * Camera.Line.LengthForceArrow), colorReaction, Camera.Line.Unit * Options.LineReactionWeight, lineReaction);
                        args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + (item.Value.ReactionUnitRight * Camera.Line.LengthForceArrow), colorReaction, Camera.Line.Unit * Options.LineReactionWeight, lineReaction);
                    }
                }
            }
            catch
            {
            }

            try
            {
                if (Options.ShowReactions)
                {
                    foreach (var item in Model.Nodes.NodesWithMomentReactions)
                    {
                        if(item.Value.LoadReaction.M > 0)
                        {
                            args.DrawingSession.DrawImage(bitMapMomentReactionClockwise, new Rect(item.Value.Location.X - (32 * Camera.Line.Unit), item.Value.Location.Y - (32 * Camera.Line.Unit), 65 * Camera.Line.Unit, 65 * Camera.Line.Unit));
                        }
                        else
                        {
                            args.DrawingSession.DrawImage(bitMapMomentReactionAntiClockwise, new Rect(item.Value.Location.X - (32 * Camera.Line.Unit), item.Value.Location.Y - (32 * Camera.Line.Unit), 65 * Camera.Line.Unit, 65 * Camera.Line.Unit));
                        }
                    }
                }
            }
            catch
            {
            }

            try
            {
                if (Options.ShowForce)
                {
                    foreach (var item in Model.Nodes.NodesWithMomentForces)
                    {
                        if (item.Value.LoadReaction.M > 0)
                        {
                            args.DrawingSession.DrawImage(bitMapMomentForceClockwise, new Rect(item.Value.Location.X - (32 * Camera.Line.Unit), item.Value.Location.Y - (32 * Camera.Line.Unit), 65 * Camera.Line.Unit, 65 * Camera.Line.Unit));
                        }
                        else
                        {
                            args.DrawingSession.DrawImage(bitMapMomentForceAntiClockwise, new Rect(item.Value.Location.X - (32 * Camera.Line.Unit), item.Value.Location.Y - (32 * Camera.Line.Unit), 65 * Camera.Line.Unit, 65 * Camera.Line.Unit));
                        }
                    }
                }
            }
            catch
            {
            }



            try
            {
                foreach (var item in Model.Nodes.NodesWithConstraints)
                {
                    switch (item.Value.Constraints.ConstraintType)
                    {
                        case ConstraintType.FixedBottom:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeFixed, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.FixedTop:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeFixed, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.FixedLeft:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeFixed, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.FixedRight:
                            args.DrawingSession.DrawImage(bitMapNodeFixedRight, new Rect(item.Value.Location.X, item.Value.Location.Y - (16 * Camera.Line.Unit), 33 * Camera.Line.Unit, 33 * Camera.Line.Unit));
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeFixed, Camera.Line.ConstraintWidth);
                            break;

                        case ConstraintType.PinnedBottom:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedTop:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedLeft:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedRight:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;

                        case ConstraintType.RollerBottom:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeRollerX, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.RollerTop:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeRollerX, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.RollerLeft:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeRollerY, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.RollerRight:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodeRollerY, Camera.Line.ConstraintWidth);
                            break;

                        case ConstraintType.TrackBottom:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.TrackTop:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.TrackLeft:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                        case ConstraintType.TrackRight:
                            args.DrawingSession.FillCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(item.Value.Location.X, item.Value.Location.Y, Camera.Line.ConstraintRadius, colorNodePin, Camera.Line.ConstraintWidth);
                            break;
                    }
                }
            }
            catch
            {
            }

            try
            {
                if (Model.Members.CurrentMember is object)
                {
                    // Draw Shear
                    if (Options.ShowShear)
                    {
                        foreach (var nextItem in Model.Members.CurrentMember.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.ShearNear, colorShearForceSelected, Camera.Line.Unit * Options.LineShearForceSelectedWeight, lineShearForceSelected);
                            }

                            args.DrawingSession.DrawLine(nextItem.Value.ShearNear, nextItem.Value.ShearFar, colorShearForceSelected, Camera.Line.Unit * Options.LineShearForceSelectedWeight, lineShearForceSelected);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.ShearFar, colorShearForceSelected, Camera.Line.Unit * Options.LineShearForceSelectedWeight, lineShearForceSelected);
                            }
                        }
                    }

                    // Draw Moment
                    if (Options.ShowMoment)
                    {
                        foreach (var nextItem in Model.Members.CurrentMember.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.MomentNear, colorMomentForce, Camera.Line.Unit * Options.LineMomentForceSelectedWeight, lineMomentForceSelected);
                            }

                            args.DrawingSession.DrawLine(nextItem.Value.MomentNear, nextItem.Value.MomentFar, colorMomentForce, Camera.Line.Unit * Options.LineMomentForceSelectedWeight, lineMomentForceSelected);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.MomentFar, colorMomentForce, Camera.Line.Unit * Options.LineMomentForceSelectedWeight, lineMomentForceSelected);
                            }
                        }
                    }

                    foreach (var nextItem in Model.Members.CurrentMember.Segments)
                    {
                        // Draw Member
                        args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.FarVectorDisplaced, colorSelectedElement, Camera.Line.Unit * (Model.Members.CurrentMember.Section.LineWeight + 2), nextItem.Value.Section.LineStyle);
                    }

                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.Line.ConstraintRadius, colorSelectedElement, Camera.Line.ConstraintWidth);

                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.Line.ConstraintRadius, colorBackground);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.Line.ConstraintRadius, colorSelectedElement, Camera.Line.ConstraintWidth);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }

            try
            {
                if (Model.Members.CurrentMember is object)
                {
                    args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(10, 10));

                    // Draw Shear
                    if (Options.ShowShear)
                    {
                        if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentNear.ShearNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentNear.ShearNear.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat);
                        }
                        else if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentNear.ShearNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentNear.ShearNear.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat);
                        }
                        else
                        {
                        }

                        if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentFar.ShearFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentFar.ShearFar.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat);
                        }
                        else if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentFar.ShearFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentFar.ShearFar.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat);
                        }
                        else
                        {
                        }
                    }

                    // Draw Moment
                    if (Options.ShowMoment)
                    {
                        if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentNear.MomentNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentNear.MomentNear.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat);
                        }
                        else if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentNear.MomentNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentNear.MomentNear.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat);
                        }
                        else
                        {
                        }

                        if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentFar.MomentFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentFar.MomentFar.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat);
                        }
                        else if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (Model.Members.CurrentMember.SegmentFar.MomentFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y + (-Model.Members.CurrentMember.SegmentFar.MomentFar.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat);
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch
            {
            }

            try
            {
                args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(10, -20));

                iX = Camera.Viewport.TopLeftMinor.X;
                iY = Camera.Viewport.TopLeftMinor.Y;
                do
                {
                    args.DrawingSession.DrawText(
                        Math.Round(iX * Camera.LengthUnitFactor, 3).ToString() + Camera.LengthUnitString,
                        (Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (iX * Camera.ZoomTrimmed),
                        Camera.Viewport.Size.Y + 2,
                        colorGridMajorFont,
                        labelGridX);

                    iX += Camera.Grid.SizeMinor;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawText(
                        Math.Round(
                            iY * Camera.LengthUnitFactor, 3).ToString() + Camera.LengthUnitString, Camera.Viewport.Size.X - 15,
                        (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y - (iY * Camera.ZoomTrimmed),
                        colorGridMajorFont,
                        labelGridY);
                    iY += Camera.Grid.SizeMinor;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
            }
            catch
            {
            }
        }

        #endregion

        #region Input

        private void Page_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            try
            {
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
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }

        private void Canvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
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
                    Camera.ScaleDeltaScrollWheel((float)e.Delta.Scale, new Vector2((float)center.X, (float)center.Y));
                }

                if ((e.Delta.Translation.X != 0) | e.Delta.Translation.Y != 0)
                {
                    Camera.MoveCamera(e.Delta.Translation.ToVector2());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
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
                switch (currentSelectionState)
                {
                    case SelectionState.Ready:
                        currentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                        break;

                    case SelectionState.FirstNode:
                        // Cancel selection?
                        currentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                        break;

                    case SelectionState.SecondNode:
                        currentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }

        private void Canvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Vector2 mousePoint = Camera.ScreenToWorld(new Vector2((float)e.GetPosition(canvas).X, (float)e.GetPosition(canvas).Y));
            switch (currentSelectionState)
            {
                case SelectionState.Ready:
                    // nothing or select member.
                    int tempInt = Model.Members.FindNearestElement(mousePoint);
                    if (tempInt != -1)
                    {
                        Model.Members.CurrentMember = Model.Members[tempInt];
                        Results.Current.ShowMember();
                    }
                    else
                    {
                        currentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                    }

                    break;

                case SelectionState.FirstNode:
                    currentSelectionState = SelectionState.Ready;
                    Model.Members.CurrentMember = null;
                    Results.Current.ShowModel();
                    break;

                case SelectionState.SecondNode:
                    // should not get here?
                    break;
            }

            try
            {
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }

        private void Canvas_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Camera.Viewport.Size = new Vector2((int)ActualWidth, (int)ActualHeight);
        }

        #endregion

        /// <summary>
        /// Updates the colors.
        /// </summary>
        public void UpdateColors()
        {
            colorBackground = Options.ColorBackground;

            colorForce = Options.ColorForce;
            colorReaction = Options.ColorReaction;
            colorGridNormal = Options.ColorGridNormal;
            colorGridMajor = Options.ColorGridMajor;
            colorGridMinor = Options.ColorGridMinor;
            colorGridMajorFont = Options.ColorGridMajorFont;
            colorSelectedElement = Options.ColorSelectedElement;
            colorSelectedNode = Options.ColorSelectedNode;
            colorShearForceSelected = Options.ColorShearForceSelected;
            colorMomentForceSelected = Options.ColorMomentForceSelected;

            colorShearForceFont = Options.ColorShearForceFont;
            colorMomentForceFont = Options.ColorMomentForceFont;

            colorShearForce = Options.ColorShearForce;
            colorMomentForce = Options.ColorMomentForce;
            colorDistributedForce = Options.ColorDistributedForce;
            colorDistributedForceSelected = Options.ColorDistributedForceSelected;
            colorNodeFree = Options.ColorNodeFree;
            colorNodeFixed = Options.ColorNodeFixed;
            colorNodePin = Options.ColorNodePin;
            colorNodeRollerX = Options.ColorNodeRollerX;
            colorNodeRollerY = Options.ColorNodeRollerY;
            colorNodeOther = Options.ColorNodeFree;

            lineGridNormal = Options.LineGridNormal;
            lineGridMinor = Options.LineGridMinor;
            lineGridMajor = Options.LineGridMajor;
            lineForce = Options.LineForce;
            lineReaction = Options.LineReaction;
            lineSelectedElement = Options.LineSelectedElement;
            lineShearForceSelected = Options.LineShearForceSelected;
            lineMomentForceSelected = Options.LineMomentForceSelected;
            lineShearForce = Options.LineShearForce;
            lineMomentForce = Options.LineMomentForce;
            lineDistributedForce = Options.LineDistributedForce;
            lineDistributedForceSelected = Options.LineDistributedForceSelected;
            lineNodeFree = Options.LineNodeFree;
            lineNodeFixed = Options.LineNodeFixed;
            lineNodePin = Options.LineNodePin;
            lineNodeRollerX = Options.LineNodeRollerX;
            lineNodeRollerY = Options.LineNodeRollerY;
            lineNodeFree = Options.LineNodeFree;

            originalMinorGridAlpha = colorGridMinor.A;
            originalNormalGridAlpha = colorGridNormal.A;
            originalMajorGridAlpha = colorGridMajor.A;

            minorGridAlphaChange = originalMinorGridAlpha / totalGridChanges;
            normalGridAlphaChange = originalNormalGridAlpha / totalGridChanges;
            majorGridAlphaChange = originalMajorGridAlpha / totalGridChanges;
        }

        private string ConvertToEngineeringNotation(decimal d)
        {
            int roundingFactor = 6;
            string numberString = string.Empty;
            string exponentString = string.Empty;

            bool isNegative = false;

            if (d < 0)
            {
                isNegative = true;
                d = DMath.Abs(d);
            }
            else if (d == 0)
            {
            }

            double exponent = Math.Log10(Math.Abs((double)d));
            if (Math.Abs(d) >= 1)
            {
                switch ((int)Math.Floor(exponent))
                {
                    case 0:
                    case 1:
                    case 2:
                        numberString = Math.Round(d, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = string.Empty;
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = "e+03";
                        }

                        break;
                    case 3:
                    case 4:
                    case 5:
                        numberString = Math.Round(d / 1e3m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+03";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        numberString = Math.Round(d / 1e6m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+06";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        numberString = Math.Round(d / 1e9m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+09";
                        break;
                    case 12:
                    case 13:
                    case 14:
                        numberString = Math.Round(d / 1e12m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+12";
                        break;
                    case 15:
                    case 16:
                    case 17:
                        numberString = Math.Round(d / 1e15m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+15";
                        break;
                    case 18:
                    case 19:
                    case 20:
                        numberString = Math.Round(d / 1e18m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+18";
                        break;
                    case 21:
                    case 22:
                    case 23:
                        numberString = Math.Round(d / 1e21m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+21";
                        break;
                    default:
                        numberString = Math.Round(d / 1e24m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e+24";
                        break;
                }
            }
            else if (Math.Abs(d) > 0)
            {
                switch ((int)Math.Floor(exponent))
                {
                    case -1:
                    case -2:
                    case -3:
                        numberString = Math.Round(d * 1e3m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-03";
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = string.Empty;
                        }

                        break;
                    case -4:
                    case -5:
                    case -6:
                        numberString = Math.Round(d * 1e6m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-06";
                        break;
                    case -7:
                    case -8:
                    case -9:
                        numberString = Math.Round(d * 1e9m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-09";
                        break;
                    case -10:
                    case -11:
                    case -12:
                        numberString = Math.Round(d * 1e12m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-12";
                        break;
                    case -13:
                    case -14:
                    case -15:
                        numberString = Math.Round(d * 1e15m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-15";
                        break;
                    case -16:
                    case -17:
                    case -18:
                        numberString = Math.Round(d * 1e18m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-18";
                        break;
                    case -19:
                    case -20:
                    case -21:
                        numberString = Math.Round(d * 1e21m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-21";
                        break;
                    default:
                        numberString = Math.Round(d * 1e24m, roundingFactor).ToString("000.000") + string.Empty;
                        exponentString = "e-24";
                        break;
                }
            }
            else
            {
                numberString = "000.000";
                exponentString = string.Empty;
            }

            if (numberString.Substring(0, 1) == "0")
            {
                numberString = numberString.Substring(1);
            }

            if (numberString.Substring(0, 1) == "0")
            {
                numberString = numberString.Substring(1);
            }

            if (numberString.Substring(numberString.Length - 1, 1) == "0")
            {
                numberString = numberString.Substring(0, numberString.Length - 1);
            }

            if (numberString.Substring(numberString.Length - 1, 1) == "0")
            {
                numberString = numberString.Substring(0, numberString.Length - 1);
            }

            if (isNegative)
            {
                return "-" + numberString + exponentString;
            }
            else
            {
                return numberString + exponentString;
            }
        }
    }
}