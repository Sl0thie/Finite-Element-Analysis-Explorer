﻿namespace Finite_Element_Analysis_Explorer
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
        /// Clayton's singleton.
        /// </summary>
        internal static ResultsDisplay Current;

        private SelectionState CurrentSelectionState = SelectionState.Ready;

        internal bool IsPageLoaded = false;

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
        private CanvasStrokeStyle LineNodeRollerY = Options.LineNodeRollerY;
        private CanvasStrokeStyle LineNodeOther = Options.LineNodeOther;


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

        public ResultsDisplay()
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
            //Options.Font = 1;
            UpdateColors();
        }

        #endregion

        #region Canvas Other
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Camera.ViewportSize = new Vector2((int)canvas.ActualWidth, (int)canvas.ActualHeight);
        }

        private void Canvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            labelGridX = new CanvasTextFormat() { FontSize = 12, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };
            labelGridY = new CanvasTextFormat() { FontSize = 12, FontWeight = FontWeights.Normal, HorizontalAlignment = CanvasHorizontalAlignment.Right, FontFamily = "Segoe UI" };

            labelFormat = new CanvasTextFormat() { FontSize = 14, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };
            labelHeaderFormat = new CanvasTextFormat() { FontSize = 14, FontWeight = FontWeights.Normal, FontFamily = "Segoe UI" };

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

        }

        #endregion

        #region Draw Loop

        private void Canvas_DrawAnimated(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            #region Transform and other Settings

            args.DrawingSession.Clear(colorBackground);
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
                    colorGridMinor = Color.FromArgb(Convert.ToByte(MinorGridAlphaChange * CounterGridChanges), colorGridMinor.R, colorGridMinor.G, colorGridMinor.B);
                    colorGridNormal = Color.FromArgb(Convert.ToByte(NormalGridAlphaChange * CounterGridChanges), colorGridNormal.R, colorGridNormal.G, colorGridNormal.B);
                    colorGridMajor = Color.FromArgb(Convert.ToByte(MajorGridAlphaChange * CounterGridChanges), colorGridMajor.R, colorGridMajor.G, colorGridMajor.B);
                }

                #endregion

                #region Minor Grid

                do
                {
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, colorGridMinor, Camera.LineUnit, lineGridMinor);
                    iX += Camera.GridSizeMinor;
                    lineCountX++;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), colorGridMinor, Camera.LineUnit, lineGridMinor);
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
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, colorBackground, Camera.LineUnit, lineGridNormal);
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, colorGridNormal, Camera.LineUnit, lineGridNormal);
                    iX += Camera.GridSizeNormal;
                    lineCountX++;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), colorBackground, Camera.LineUnit, lineGridNormal);
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), colorGridNormal, Camera.LineUnit, lineGridNormal);
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
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, colorBackground, Camera.LineUnit, lineGridMajor);
                    args.DrawingSession.DrawLine((iX), Camera.TopLeftNormal.Y, (iX), Camera.BottomRight.Y, colorGridMajor, Camera.LineUnit, lineGridMajor);
                    iX += Camera.GridSizeMajor;
                    lineCountX++;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), colorBackground, Camera.LineUnit, lineGridMajor);
                    args.DrawingSession.DrawLine(Camera.TopLeftNormal.X, (iY), Camera.BottomRight.X, (iY), colorGridMajor, Camera.LineUnit, lineGridMajor);
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
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearLDLLine, colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarLDLLine, colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearLDLLine, nextSegment.Value.FarLDLLine, colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.LineLengthLDLArrow), colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.NearVectorDisplaced, nextSegment.Value.NearVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.LineLengthLDLArrow), colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);

                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitRight * Camera.LineLengthLDLArrow), colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);
                            args.DrawingSession.DrawLine(nextSegment.Value.FarVectorDisplaced, nextSegment.Value.FarVectorDisplaced + (nextSegment.Value.LDLUnitLeft * Camera.LineLengthLDLArrow), colorDistributedForce, Camera.LineUnit * Options.LineDistributedForceWeight, lineDistributedForce);
                        }
                    }
                }
                catch { }
            }

            #endregion
            #region Draw Shear Force Diagrams and Moment Diagrams.

            if (Options.ShowShear)
            {
                try
                {
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextItem in Item.Value.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.ShearNear, colorShearForce, Camera.LineUnit * Options.LineShearForceWeight, lineShearForce);
                            }
                            args.DrawingSession.DrawLine(nextItem.Value.ShearNear, nextItem.Value.ShearFar, colorShearForce, Camera.LineUnit * Options.LineShearForceWeight, lineShearForce);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.ShearFar, colorShearForce, Camera.LineUnit * Options.LineShearForceWeight, lineShearForce);
                            }
                        }
                    }
                }
                catch { }
            }

            if (Options.ShowMoment)
            {
                try
                {
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextItem in Item.Value.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.MomentNear, colorMomentForce, Camera.LineUnit * Options.LineMomentForceWeight, lineMomentForce);
                            }
                            args.DrawingSession.DrawLine(nextItem.Value.MomentNear, nextItem.Value.MomentFar, colorMomentForce, Camera.LineUnit * Options.LineMomentForceWeight, lineMomentForce);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.MomentFar, colorMomentForce, Camera.LineUnit * Options.LineMomentForceWeight, lineMomentForce);
                            }
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
                        args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.FarVectorDisplaced, nextItem.Value.CurrentColor, Camera.LineUnit * Item.Value.Section.LineWeight, Item.Value.Section.LineStyle);
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
                    args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + Item.Value.ForceLine, colorForce, Camera.LineUnit * Options.LineForceWeight, lineForce);
                    args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + (Item.Value.ForceUnitLeft * Camera.LineLengthForceArrow), colorForce, Camera.LineUnit * Options.LineForceWeight, lineForce);
                    args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + (Item.Value.ForceUnitRight * Camera.LineLengthForceArrow), colorForce, Camera.LineUnit * Options.LineForceWeight, lineForce);
                }
            }
            catch { }

            #endregion
            #region Draw Reactions

            try
            {
                if (Options.ShowReactions)
                {
                    foreach (var Item in Model.Nodes.NodesWithReactions)
                    {
                        args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + Item.Value.ReactionLine, colorReaction, Camera.LineUnit * Options.LineReactionWeight, lineForce);
                        args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + (Item.Value.ReactionUnitLeft * Camera.LineLengthForceArrow), colorReaction, Camera.LineUnit * Options.LineReactionWeight, lineReaction);
                        args.DrawingSession.DrawLine(Item.Value.Location, Item.Value.Location + (Item.Value.ReactionUnitRight * Camera.LineLengthForceArrow), colorReaction, Camera.LineUnit * Options.LineReactionWeight, lineReaction);
                    }
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
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeFixed, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.FixedTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeFixed, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.FixedLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeFixed, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.FixedRight:
                            args.DrawingSession.DrawImage(bitMapNodeFixedRight, new Rect(Item.Value.Location.X, Item.Value.Location.Y - 16 * Camera.LineUnit, 33 * Camera.LineUnit, 33 * Camera.LineUnit));
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeFixed, Camera.ConstraintWidth);
                            break;

                        case ConstraintType.PinnedBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.PinnedRight:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;

                        case ConstraintType.RollerBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeRollerX, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.RollerTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeRollerX, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.RollerLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeRollerY, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.RollerRight:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodeRollerY, Camera.ConstraintWidth);
                            break;

                        case ConstraintType.TrackBottom:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.TrackTop:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.TrackLeft:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
                            break;
                        case ConstraintType.TrackRight:
                            args.DrawingSession.FillCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorBackground);
                            args.DrawingSession.DrawCircle(Item.Value.Location.X, Item.Value.Location.Y, Camera.ConstraintRadius, colorNodePin, Camera.ConstraintWidth);
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
                    //Draw Shear
                    if (Options.ShowShear)
                    {
                        foreach (var nextItem in Model.Members.CurrentMember.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.ShearNear, colorShearForceSelected, Camera.LineUnit * Options.LineShearForceSelectedWeight, lineShearForceSelected);
                            }
                            args.DrawingSession.DrawLine(nextItem.Value.ShearNear, nextItem.Value.ShearFar, colorShearForceSelected, Camera.LineUnit * Options.LineShearForceSelectedWeight, lineShearForceSelected);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.ShearFar, colorShearForceSelected, Camera.LineUnit * Options.LineShearForceSelectedWeight, lineShearForceSelected);
                            }
                        }

                        //if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y != 0)
                        //{
                        //    args.DrawingSession.DrawText("Testgsfdghsdfghdsfghdfghdfghdfghdfghdfghdfghdfg", Model.Members.CurrentMember.SegmentNear.ShearNear, ColorShearForceSelected, LabelGridX);
                        //}
                    }

                    //Draw Moment
                    if (Options.ShowMoment)
                    {
                        foreach (var nextItem in Model.Members.CurrentMember.Segments)
                        {
                            if (nextItem.Value.NodeNear.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.MomentNear, colorMomentForce, Camera.LineUnit * Options.LineMomentForceSelectedWeight, lineMomentForceSelected);
                            }
                            args.DrawingSession.DrawLine(nextItem.Value.MomentNear, nextItem.Value.MomentFar, colorMomentForce, Camera.LineUnit * Options.LineMomentForceSelectedWeight, lineMomentForceSelected);
                            if (nextItem.Value.NodeFar.IsPrimary)
                            {
                                args.DrawingSession.DrawLine(nextItem.Value.FarVectorDisplaced, nextItem.Value.MomentFar, colorMomentForce, Camera.LineUnit * Options.LineMomentForceSelectedWeight, lineMomentForceSelected);
                            }
                        }
                    }


                    foreach (var nextItem in Model.Members.CurrentMember.Segments)
                    {
                        //Draw Member
                        args.DrawingSession.DrawLine(nextItem.Value.NearVectorDisplaced, nextItem.Value.FarVectorDisplaced, colorSelectedElement, Camera.LineUnit * (Model.Members.CurrentMember.Section.LineWeight + 2), nextItem.Value.Section.LineStyle);
                    }


                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.ConstraintRadius, colorBackground);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeNear.Location.X, Model.Members.CurrentMember.NodeNear.Location.Y, Camera.ConstraintRadius, colorSelectedElement, Camera.ConstraintWidth);

                    args.DrawingSession.FillCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.ConstraintRadius, colorBackground);
                    args.DrawingSession.DrawCircle(Model.Members.CurrentMember.NodeFar.Location.X, Model.Members.CurrentMember.NodeFar.Location.Y, Camera.ConstraintRadius, colorSelectedElement, Camera.ConstraintWidth);
                }
            }
            catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }

            #endregion
            #region Draw Members Text Labels

            //try
            //{
            //    if (!object.ReferenceEquals(null, Model.Members.CurrentMember))
            //    {
            //        args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(10, 10));
            //        //Draw Shear
            //        if (Options.ShowShear)
            //        {
            //            foreach (var Item in Model.Members)
            //            {
            //                if (Item.Value.SegmentNear.InternalLoadNearLocal.Y > 0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(Item.Value.SegmentNear.InternalLoadNearLocal.Y),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentNear.ShearNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentNear.ShearNear.Y * Camera.ZoomTrimmed)),
            //                    ColorShearForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y < -0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentNear.ShearNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentNear.ShearNear.Y * Camera.ZoomTrimmed)),
            //                    ColorShearForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else
            //                {

            //                }

            //                if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y > 0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(-Item.Value.SegmentFar.InternalLoadFarLocal.Y),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentFar.ShearFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentFar.ShearFar.Y * Camera.ZoomTrimmed)),
            //                    ColorShearForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y < -0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(-Item.Value.SegmentFar.InternalLoadFarLocal.Y),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentFar.ShearFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentFar.ShearFar.Y * Camera.ZoomTrimmed)),
            //                    ColorShearForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else
            //                {

            //                }
            //            }
            //        }

            //        //Draw Moment
            //        if (Options.ShowMoment)
            //        {
            //            foreach (var Item in Model.Members)
            //            {
            //                if (Item.Value.SegmentNear.InternalLoadNearLocal.M > 0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(-Item.Value.SegmentNear.InternalLoadNearLocal.M),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentNear.MomentNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentNear.MomentNear.Y * Camera.ZoomTrimmed)),
            //                    ColorMomentForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else if (Item.Value.SegmentNear.InternalLoadNearLocal.M < -0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(-Item.Value.SegmentNear.InternalLoadNearLocal.M),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentNear.MomentNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentNear.MomentNear.Y * Camera.ZoomTrimmed)),
            //                    ColorMomentForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else
            //                {

            //                }

            //                if (Item.Value.SegmentFar.InternalLoadFarLocal.M > 0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(Item.Value.SegmentFar.InternalLoadFarLocal.M),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentFar.MomentFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentFar.MomentFar.Y * Camera.ZoomTrimmed)),
            //                    ColorMomentForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else if (Item.Value.SegmentFar.InternalLoadFarLocal.M < -0.000001m)
            //                {
            //                    args.DrawingSession.DrawText(
            //                    ConvertToEngineeringNotation(Item.Value.SegmentFar.InternalLoadFarLocal.M),
            //                    new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Item.Value.SegmentFar.MomentFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Item.Value.SegmentFar.MomentFar.Y * Camera.ZoomTrimmed)),
            //                    ColorMomentForceFont,
            //                    LabelFormat
            //                    );
            //                }
            //                else
            //                {

            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }

            #endregion
            #region Draw Selected Member Text Labels

            try
            {

                if (!object.ReferenceEquals(null, Model.Members.CurrentMember))
                {
                    args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(10, 10));
                    //Draw Shear
                    if (Options.ShowShear)
                    {
                        if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentNear.ShearNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentNear.ShearNear.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat
                            );
                        }
                        else if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentNear.ShearNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentNear.ShearNear.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat
                            );
                        }
                        else
                        {

                        }

                        if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentFar.ShearFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentFar.ShearFar.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat
                            );
                        }
                        else if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.Y),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentFar.ShearFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentFar.ShearFar.Y * Camera.ZoomTrimmed)),
                            colorShearForceFont,
                            labelFormat
                            );
                        }
                        else
                        {

                        }
                    }

                    //Draw Moment
                    if (Options.ShowMoment)
                    {

                        if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentNear.MomentNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentNear.MomentNear.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat
                            );
                        }
                        else if (Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(-Model.Members.CurrentMember.SegmentNear.InternalLoadNearLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentNear.MomentNear.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentNear.MomentNear.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat
                            );
                        }
                        else
                        {

                        }

                        if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M > 0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentFar.MomentFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentFar.MomentFar.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat
                            );
                        }
                        else if (Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M < -0.000001m)
                        {
                            args.DrawingSession.DrawText(
                            ConvertToEngineeringNotation(Model.Members.CurrentMember.SegmentFar.InternalLoadFarLocal.M),
                            new Vector2((Camera.Position.X * Camera.ZoomTrimmed) + Camera.ViewportCenter.X + (Model.Members.CurrentMember.SegmentFar.MomentFar.X * Camera.ZoomTrimmed), (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y + (-Model.Members.CurrentMember.SegmentFar.MomentFar.Y * Camera.ZoomTrimmed)),
                            colorMomentForceFont,
                            labelFormat
                            );
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch { }

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
            //args.DrawingSession.DrawText("LineInverse: " + Camera.LineInverse, 0, 120, Colors.White, LabelFormat);

            //args.DrawingSession.Transform = Matrix3x2.CreateTranslation(new Vector2(Camera.CenterXPixels - 3, Camera.CenterYPixels - 3));
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
                        colorGridMajorFont, labelGridX
                        );

                    iX += Camera.GridSizeMinor;
                }
                while (iX < Camera.BottomRight.X);

                do
                {
                    args.DrawingSession.DrawText(
                        Math.Round((iY * Camera.LengthUnitFactor), 3).ToString() + Camera.LengthUnitString, Camera.ViewportSize.X - 15,
                        (-Camera.Position.Y * Camera.ZoomTrimmed) + Camera.ViewportCenter.Y - (iY * Camera.ZoomTrimmed),
                        colorGridMajorFont, labelGridY);
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
                    //Camera.ScaleDelta((float)e.Delta.Scale, new Vector2((float)center.X, (float)center.Y));
                    Camera.ScaleDeltaScrollWheel((float)e.Delta.Scale, new Vector2((float)center.X, (float)center.Y));
                }

                if ((e.Delta.Translation.X != 0) | e.Delta.Translation.Y != 0)
                {
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
                //Vector2 MousePoint = Camera.ScreenToWorld(new Vector2((float)e.GetPosition(canvas).X, (float)e.GetPosition(canvas).Y));
                switch (CurrentSelectionState)
                {
                    case SelectionState.Ready:
                        CurrentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                        break;

                    case SelectionState.FirstNode:
                        //Cancel selection?

                        CurrentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                        break;

                    case SelectionState.SecondNode:
                        CurrentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
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
                    if (tempInt != -1)
                    {
                        Model.Members.CurrentMember = Model.Members[tempInt];
                        Results.Current.ShowMember();

                        //decimal Largest = 0;
                        //decimal NegLargest = 0;

                        //foreach (var Item in Model.Members.CurrentMember.Segments)
                        //{
                        //    Debug.WriteLine(Item.Value.Index + " " + -Item.Value.InternalLoadNearLocal.M + " " + Item.Value.InternalLoadFarLocal.M + Item.Value.NodeNear.Position.X);

                        //    if (-Item.Value.InternalLoadNearLocal.M > Largest) { Largest = -Item.Value.InternalLoadNearLocal.M; }
                        //    if (-Item.Value.InternalLoadNearLocal.M < NegLargest) { NegLargest = -Item.Value.InternalLoadNearLocal.M; }

                        //    if (Item.Value.InternalLoadFarLocal.M > Largest) { Largest = Item.Value.InternalLoadFarLocal.M; }
                        //    if (Item.Value.InternalLoadFarLocal.M < NegLargest) { NegLargest = Item.Value.InternalLoadFarLocal.M; }


                        //}


                        //Debug.WriteLine("Largest " + Largest);
                        //Debug.WriteLine("NegLargest " + NegLargest);

                    }
                    else
                    {
                        CurrentSelectionState = SelectionState.Ready;
                        Model.Members.CurrentMember = null;
                        Results.Current.ShowModel();
                    }
                    break;

                case SelectionState.FirstNode:
                    CurrentSelectionState = SelectionState.Ready;
                    Model.Members.CurrentMember = null;
                    Results.Current.ShowModel();
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
            //switch (CurrentSelectionState)
            //{
            //    case SelectionState.Ready:
            //        //nothing?
            //        break;

            //    case SelectionState.FirstNode:
            //        //create member and continue.
            //        CurrentSelectionState = SelectionState.Ready;
            //        break;

            //    case SelectionState.SecondNode:
            //        //should not get here?
            //        CurrentSelectionState = SelectionState.Ready;
            //        break;
            //}

            //try
            //{

            //}
            //catch (Exception ex) { Debug.WriteLine("Error " + ex.Message); }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Camera.ViewportSize = new Vector2((int)this.ActualWidth, (int)this.ActualHeight);
        }

        #endregion

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
            LineNodeRollerY = Options.LineNodeRollerY;
            lineNodeFree = Options.LineNodeFree;

            OriginalMinorGridAlpha = colorGridMinor.A;
            OriginalNormalGridAlpha = colorGridNormal.A;
            OriginalMajorGridAlpha = colorGridMajor.A;

            MinorGridAlphaChange = OriginalMinorGridAlpha / TotalGridChanges;
            NormalGridAlphaChange = OriginalNormalGridAlpha / TotalGridChanges;
            MajorGridAlphaChange = OriginalMajorGridAlpha / TotalGridChanges;

        }
        
        private string ConvertToEngineeringNotation(decimal d)
        {

            int RoundingFactor = 6;
            //decimal theValue = 0;
            string numberString = "";
            string exponentString = "";

            bool IsNegative = false;

            if (d < 0)
            {
                IsNegative = true;
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
                        numberString = Math.Round(d, RoundingFactor).ToString("000.000") + "";
                        exponentString = "";
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = "e+03";
                        }
                        break;
                    case 3:
                    case 4:
                    case 5:
                        numberString = Math.Round((d / 1e3m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+03";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        numberString = Math.Round((d / 1e6m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+06";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        numberString = Math.Round((d / 1e9m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+09";
                        break;
                    case 12:
                    case 13:
                    case 14:
                        numberString = Math.Round((d / 1e12m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+12";
                        break;
                    case 15:
                    case 16:
                    case 17:
                        numberString = Math.Round((d / 1e15m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+15";
                        break;
                    case 18:
                    case 19:
                    case 20:
                        numberString = Math.Round((d / 1e18m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+18";
                        break;
                    case 21:
                    case 22:
                    case 23:
                        numberString = Math.Round((d / 1e21m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e+21";
                        break;
                    default:
                        numberString = Math.Round((d / 1e24m), RoundingFactor).ToString("000.000") + "";
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
                        numberString = Math.Round((d * 1e3m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-03";
                        if (numberString == "1000.000")
                        {
                            numberString = "001.000";
                            exponentString = "";
                        }
                        break;
                    case -4:
                    case -5:
                    case -6:
                        numberString = Math.Round((d * 1e6m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-06";
                        break;
                    case -7:
                    case -8:
                    case -9:
                        numberString = Math.Round((d * 1e9m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-09";
                        break;
                    case -10:
                    case -11:
                    case -12:
                        numberString = Math.Round((d * 1e12m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-12";
                        break;
                    case -13:
                    case -14:
                    case -15:
                        numberString = Math.Round((d * 1e15m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-15";
                        break;
                    case -16:
                    case -17:
                    case -18:
                        numberString = Math.Round((d * 1e18m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-18";
                        break;
                    case -19:
                    case -20:
                    case -21:
                        numberString = Math.Round((d * 1e21m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-21";
                        break;
                    default:
                        numberString = Math.Round((d * 1e24m), RoundingFactor).ToString("000.000") + "";
                        exponentString = "e-24";
                        break;
                }
            }
            else
            {
                numberString = "000.000";
                exponentString = "";
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




            if (IsNegative)
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

