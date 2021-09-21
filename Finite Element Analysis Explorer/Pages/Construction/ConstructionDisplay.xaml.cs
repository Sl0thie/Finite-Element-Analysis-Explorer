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
    /// ConstructionDisplay page.
    /// </summary>
    public sealed partial class ConstructionDisplay : Page
    {
        #region Properties

        #region Operations

        /// <summary>
        /// Gets or sets the current construction display page.
        /// </summary>
        internal static ConstructionDisplay Current { get; set; }

        private static float counterGridChanges = 0;

        private SelectionState currentSelectionState = SelectionState.Ready;
        private Vector2 firstNodePosition;
        private bool isPageLoaded = false;

        private byte originalMinorGridAlpha;
        private byte originalNormalGridAlpha;
        private byte originalMajorGridAlpha;
        private float minorGridAlphaChange;
        private float normalGridAlphaChange;
        private float majorGridAlphaChange;
        private float totalGridChanges = 40;

        #endregion

        #region Lines

        //private CanvasStrokeStyle lineGridNormal = Options.Lines.GridNormal;
        //private CanvasStrokeStyle lineGridMinor = Options.Lines.GridMinor;
        //private CanvasStrokeStyle lineGridMajor = Options.LineGridMajor;
        private CanvasStrokeStyle lineForce = Options.Lines.Force;
        //private CanvasStrokeStyle lineDistributedForce = Options.Lines.DistributedForce;

        #endregion

        #region Fonts

        // Font setup is in the create resources method.
        private CanvasTextFormat labelGridX;
        private CanvasTextFormat labelGridY;
        private CanvasTextFormat labelFormat;
        private CanvasTextFormat labelHeaderFormat;

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
        /// Initializes a new instance of the <see cref="ConstructionDisplay"/> class.
        /// </summary>
        public ConstructionDisplay()
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

            // Set the render transform on the rect.
            canvas.RenderTransform = transforms;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;

            UpdateColors();
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (isPageLoaded)
            {
                Camera.Viewport.Size = new Vector2((int)canvas.ActualWidth, (int)canvas.ActualHeight);
            }
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
        }

        #endregion

        #region Draw Loop

        private void Canvas_DrawAnimated(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.Clear(Options.Colors.Background);
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
                    Options.Colors.GridMinor = Color.FromArgb(Convert.ToByte(minorGridAlphaChange * counterGridChanges), Options.Colors.GridMinor.R, Options.Colors.GridMinor.G, Options.Colors.GridMinor.B);
                    Options.Colors.GridNormal = Color.FromArgb(Convert.ToByte(normalGridAlphaChange * counterGridChanges), Options.Colors.GridNormal.R, Options.Colors.GridNormal.G, Options.Colors.GridNormal.B);
                    Options.Colors.GridMajor = Color.FromArgb(Convert.ToByte(majorGridAlphaChange * counterGridChanges), Options.Colors.GridMajor.R, Options.Colors.GridMajor.G, Options.Colors.GridMajor.B);
                }

                do
                {
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, Options.Colors.GridMinor, Camera.Line.Unit, Options.Lines.GridMinor);
                    iX += Camera.Grid.SizeMinor;
                    lineCountX++;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, Options.Colors.GridMinor, Camera.Line.Unit, Options.Lines.GridMinor);
                    iY += Camera.Grid.SizeMinor;
                    lineCountY++;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
                iX = Camera.Viewport.TopLeftNormal.X;
                iY = Camera.Viewport.TopLeftNormal.Y;
                do
                {
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, Options.Colors.Background, Camera.Line.Unit, Options.Lines.GridNormal);
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, Options.Colors.GridNormal, Camera.Line.Unit, Options.Lines.GridNormal);
                    iX += Camera.Grid.SizeNormal;
                    lineCountX++;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, Options.Colors.Background, Camera.Line.Unit, Options.Lines.GridNormal);
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, Options.Colors.GridNormal, Camera.Line.Unit, Options.Lines.GridNormal);
                    iY += Camera.Grid.SizeNormal;
                    lineCountY++;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
                iX = Camera.Viewport.TopLeftMajor.X;
                iY = Camera.Viewport.TopLeftMajor.Y;
                do
                {
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, Options.Colors.Background, Camera.Line.Unit, Options.Lines.GridMajor);
                    args.DrawingSession.DrawLine(iX, Camera.Viewport.TopLeftNormal.Y, iX, Camera.Viewport.BottomRight.Y, Options.Colors.GridMajor, Camera.Line.Unit, Options.Lines.GridMajor);
                    iX += Camera.Grid.SizeMajor;
                    lineCountX++;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, Options.Colors.Background, Camera.Line.Unit, Options.Lines.GridMajor);
                    args.DrawingSession.DrawLine(Camera.Viewport.TopLeftNormal.X, iY, Camera.Viewport.BottomRight.X, iY, Options.Colors.GridMajor, Camera.Line.Unit, Options.Lines.GridMajor);
                    iY += Camera.Grid.SizeMajor;
                    lineCountY++;
                }
                while (iY < Camera.Viewport.BottomRight.Y);
            }
            catch
            {
            }

            args.DrawingSession.Antialiasing = CanvasAntialiasing.Antialiased;

            if (Options.Display.ShowLinear)
            {
                try
                {
                    foreach (var item in Model.Members.MembersWithLinearLoads)
                    {
                        foreach (var nextSegment in item.Value.Segments)
                        {
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearLDLLine, Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarLDLLine, Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearLDLLine, nextSegment.Value.FarLDLLine, Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.Line.LengthLDLArrow), Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.Line.LengthLDLArrow), Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.Line.LengthLDLArrow), Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.Line.LengthLDLArrow), Options.Colors.DistributedForce, Camera.Line.Unit * Options.Lines.DistributedForceWeight, Options.Lines.DistributedForce);
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
                        args.DrawingSession.DrawLine(nextItem.Value.NearVector, nextItem.Value.FarVector, nextItem.Value.CurrentColor, Camera.Line.Unit * item.Value.Section.LineWeight, item.Value.Section.LineStyle);
                    }
                }
            }
            catch
            {
            }

            try
            {
                if (Options.Display.ShowForce)
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
                    args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + item.Value.ForceLine, Options.Colors.Force, Camera.Line.Unit * Options.Lines.ForceWeight, lineForce);
                    args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + (item.Value.ForceUnitLeft * Camera.Line.LengthForceArrow), Options.Colors.Force, Camera.Line.Unit * Options.Lines.ForceWeight, lineForce);
                    args.DrawingSession.DrawLine(item.Value.Location, item.Value.Location + (item.Value.ForceUnitRight * Camera.Line.LengthForceArrow), Options.Colors.Force, Camera.Line.Unit * Options.Lines.ForceWeight, lineForce);
                }
            }
            catch
            {
            }

            try
            {
                if (Model.Members.CurrentMember is object)
                {
                    foreach (var nextItem in Model.Members.CurrentMember.Segments)
                    {
                        args.DrawingSession.DrawLine(nextItem.Value.NearVector, nextItem.Value.FarVector, Options.Colors.SelectedElement, Camera.Line.Unit * (Model.Members.CurrentMember.Section.LineWeight + 2), nextItem.Value.Section.LineStyle);
                    }

                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.Line.ConstraintRadius, Options.Colors.Background);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.Line.ConstraintRadius, Options.Colors.SelectedElement, Camera.Line.ConstraintWidth);
                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.Line.ConstraintRadius, Options.Colors.Background);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.Line.ConstraintRadius, Options.Colors.SelectedElement, Camera.Line.ConstraintWidth);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }

            try
            {
                switch (currentSelectionState)
                {
                    case SelectionState.Ready:
                        // nothing?
                        break;

                    case SelectionState.FirstNode:
                        // create member and continue.
                        args.DrawingSession.FillCircle(firstNodePosition, 4 * Camera.Line.Unit, Options.Colors.SelectedNode);
                        break;

                    case SelectionState.SecondNode:
                        // should not get here?
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }

            try
            {
                args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(10, -20));

                iX = Camera.Viewport.TopLeftMinor.X;
                iY = Camera.Viewport.TopLeftMinor.Y;

                do
                {
                    args.DrawingSession.DrawText(Math.Round(iX * Camera.LengthUnitFactor, 3).ToString() + Camera.LengthUnitString, (Camera.Position.X * Camera.ZoomTrimmed) + Camera.Viewport.Center.X + (iX * Camera.ZoomTrimmed), Camera.Viewport.Size.Y + 2, Options.Colors.GridMajorFont, labelGridX);

                    iX += Camera.Grid.SizeMinor;
                }
                while (iX < Camera.Viewport.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawText(Math.Round(iY * Camera.LengthUnitFactor, 3).ToString() + Camera.LengthUnitString, Camera.Viewport.Size.X - 15, (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.Viewport.Center.Y - (iY * Camera.ZoomTrimmed), Options.Colors.GridMajorFont, labelGridY);
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
                counterGridChanges = 0;
                PointerPoint mousePosition = e.GetCurrentPoint(Current);
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
                WService.ReportException(ex);
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
                WService.ReportException(ex);
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
                    counterGridChanges = 0;
                    Camera.ScaleDeltaScrollWheel((float)e.Delta.Scale, new Vector2((float)center.X, (float)center.Y));
                }

                if ((e.Delta.Translation.X != 0) | e.Delta.Translation.Y != 0)
                {
                    counterGridChanges = 0;
                    Camera.MoveCamera(e.Delta.Translation.ToVector2());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
                WService.ReportException(ex);
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
                Vector2 mousePoint = Camera.ScreenToWorld(new Vector2((float)e.GetPosition(canvas).X, (float)e.GetPosition(canvas).Y));
                switch (currentSelectionState)
                {
                    case SelectionState.Ready:
                        // Start new member.
                        firstNodePosition = new Vector2(Camera.Snap(mousePoint.X, Camera.Grid.SizeMinor), Camera.Snap(mousePoint.Y, Camera.Grid.SizeMinor));
                        Model.Members.CurrentMember = null;
                        currentSelectionState = SelectionState.FirstNode;
                        break;

                    case SelectionState.FirstNode:
                        // Cancel selection?
                        currentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Construction.Current.ShowModel();
                        break;

                    case SelectionState.SecondNode:
                        // finish member then cancel.
                        AddMember(firstNodePosition, new Vector2(Camera.Snap(mousePoint.X, Camera.Grid.SizeMinor), Camera.Snap(mousePoint.Y, Camera.Grid.SizeMinor)));
                        currentSelectionState = SelectionState.Ready;

                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
                WService.ReportException(ex);
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
                    if (tempInt == -1)
                    {
                        currentSelectionState = SelectionState.Ready;
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
                    // create member and continue.
                    AddMember(firstNodePosition, new Vector2(Camera.Snap(mousePoint.X, Camera.Grid.SizeMinor), Camera.Snap(mousePoint.Y, Camera.Grid.SizeMinor)));
                    firstNodePosition = new Vector2(Camera.Snap(mousePoint.X, Camera.Grid.SizeMinor), Camera.Snap(mousePoint.Y, Camera.Grid.SizeMinor));
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
                WService.ReportException(ex);
            }
        }

        private void Canvas_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            switch (currentSelectionState)
            {
                case SelectionState.Ready:
                    // nothing?
                    break;

                case SelectionState.FirstNode:
                    // create member and continue.
                    currentSelectionState = SelectionState.Ready;
                    break;

                case SelectionState.SecondNode:
                    // should not get here?
                    currentSelectionState = SelectionState.Ready;
                    break;
            }

            try
            {
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
                WService.ReportException(ex);
            }
        }

        #endregion

        private void AddMember(Vector2 firstNodePosition, Vector2 secondNodePosition)
        {
            // Check if Nodes are the same location.
            if ((firstNodePosition.X == secondNodePosition.X) && (firstNodePosition.Y == secondNodePosition.Y))
            {
                return;
            }

            Node nodeNear = null;
            Node nodeFar = null;

            // Switch nodes to suit quadrant.
            if (firstNodePosition.X < secondNodePosition.X)
            {
                nodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                nodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
            }
            else if (firstNodePosition.X > secondNodePosition.X)
            {
                nodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                nodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
            }
            else
            {
                if (firstNodePosition.Y < secondNodePosition.Y)
                {
                    nodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                    nodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                }
                else
                {
                    nodeNear = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 1, new Point((decimal)secondNodePosition.X, (decimal)secondNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                    nodeFar = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y), new Node((Model.Members.NextIndex * 1000) + 2, new Point((decimal)firstNodePosition.X, (decimal)firstNodePosition.Y, 0), new Codes(0, 0, 0), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), true));
                }
            }

            // Add Member to the collection.
            try
            {
                Model.Members.CurrentMember = new Member(Model.Members.NextIndex, nodeNear, nodeFar, Model.Sections.CurrentSection, Options.DefaultNumberOfSegments, 0, 0);
                Construction.Current.ShowMember();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Adding Member " + ex.Message);
                WService.ReportException(ex);
            }

            // Update primary node count.
            Model.Nodes.UpdateNoOfPrimaryNodes();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Camera.Viewport.Size = new Vector2((int)ActualWidth, (int)ActualHeight);
        }

        /// <summary>
        /// Updates the colors.
        /// </summary>
        public void UpdateColors()
        {
            //colorBackground = Options.Colors.Background;
            //colorForce = Options.Colors.Force;
            //colorGridNormal = Options.Colors.GridNormal;
            //colorGridMajor = Options.Colors.GridMajor;
            //colorGridMinor = Options.Colors.GridMinor;
            //colorGridMajorFont = Options.Colors.GridMajorFont;
            //colorSelectedElement = Options.Colors.SelectedElement;
            //colorSelectedNode = Options.Colors.SelectedNode;
            //colorDistributedForce = Options.ColorDistributedForce;
            //colorNodeFixed = Options.ColorNodeFixed;
            //colorNodePin = Options.ColorNodePin;
            //colorNodeRollerX = Options.ColorNodeRollerX;
            //colorNodeRollerY = Options.ColorNodeRollerY;

            //lineGridNormal = Options.LineGridNormal;
            //lineGridMinor = Options.Lines.GridMinor;
            //lineGridMajor = Options.LineGridMajor;
            lineForce = Options.Lines.Force;
            //lineDistributedForce = Options.LineDistributedForce;

            originalMinorGridAlpha = Options.Colors.GridMinor.A;
            originalNormalGridAlpha = Options.Colors.GridNormal.A;
            originalMajorGridAlpha = Options.Colors.GridMajor.A;

            minorGridAlphaChange = originalMinorGridAlpha / totalGridChanges;
            normalGridAlphaChange = originalNormalGridAlpha / totalGridChanges;
            majorGridAlphaChange = originalMajorGridAlpha / totalGridChanges;
        }
    }
}
