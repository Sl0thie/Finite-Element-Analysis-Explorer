namespace Finite_Element_Analysis_Explorer
{
    using Microsoft.Graphics.Canvas.Geometry;
    using System;

    internal class OptionsLines
    {
        private float gridNormalWeight = 1f;
        private CanvasStrokeStyle gridNormal = new CanvasStrokeStyle();
        private float gridMinorWeight = 1f;
        private CanvasStrokeStyle gridMinor = new CanvasStrokeStyle();
        private float gridMajorWeight = 1f;
        private CanvasStrokeStyle gridMajor = new CanvasStrokeStyle();
        private float forceWeight = 5f;
        private CanvasStrokeStyle force = new CanvasStrokeStyle();
        private float reactionWeight = 5f;
        private CanvasStrokeStyle reaction = new CanvasStrokeStyle();
        private float selectedElementWeight = 2.8f;
        private CanvasStrokeStyle selectedElement = new CanvasStrokeStyle();
        private float shearForceSelectedWeight = 2.8f;
        private CanvasStrokeStyle shearForceSelected = new CanvasStrokeStyle();
        private float momentForceSelectedWeight = 2.8f;
        private CanvasStrokeStyle momentForceSelected = new CanvasStrokeStyle();
        private float shearForceFontWeight = 2.8f;
        private CanvasStrokeStyle shearForceFont = new CanvasStrokeStyle();
        private float momentForceFontWeight = 2.8f;
        private CanvasStrokeStyle momentForceFont = new CanvasStrokeStyle();
        private float shearForceWeight = 1.5f;
        private CanvasStrokeStyle shearForce = new CanvasStrokeStyle();
        private float momentForceWeight = 1.5f;
        private CanvasStrokeStyle momentForce = new CanvasStrokeStyle();
        private float distributedForceWeight = 1.5f;
        private CanvasStrokeStyle distributedForce = new CanvasStrokeStyle();
        private float distributedForceSelectedWeight = 1.8f;
        private CanvasStrokeStyle distributedForceSelected = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line grid normal weight.
        /// </summary>
        internal float GridNormalWeight
        {
            get => gridNormalWeight;

            set
            {
                gridNormalWeight = value;
                FileManager.LocalSettings.Values["LineGridNormalWeight"] = (float)gridNormalWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line grid normal canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle GridNormal
        {
            get => gridNormal;

            set
            {
                gridNormal = value;
                FileManager.LocalSettings.Values["LineGridNormalDashCap"] = (int)gridNormal.DashCap;
                FileManager.LocalSettings.Values["LineGridNormalDashOffset"] = (float)gridNormal.DashOffset;
                FileManager.LocalSettings.Values["LineGridNormalDashStyle"] = (int)gridNormal.DashStyle;
                FileManager.LocalSettings.Values["LineGridNormalEndCap"] = (int)gridNormal.EndCap;
                FileManager.LocalSettings.Values["LineGridNormalLineJoin"] = (int)gridNormal.LineJoin;
                FileManager.LocalSettings.Values["LineGridNormalMiterLimit"] = (float)gridNormal.MiterLimit;
                FileManager.LocalSettings.Values["LineGridNormalStartCap"] = (int)gridNormal.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line grid minor weight.
        /// </summary>
        internal float GridMinorWeight
        {
            get => gridMinorWeight;

            set
            {
                gridMinorWeight = value;
                FileManager.LocalSettings.Values["LineGridMinorWeight"] = (float)gridMinorWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line grid minor canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle GridMinor
        {
            get => gridMinor;

            set
            {
                gridMinor = value;
                FileManager.LocalSettings.Values["LineGridMinorDashCap"] = (int)gridMinor.DashCap;
                FileManager.LocalSettings.Values["LineGridMinorDashOffset"] = (float)gridMinor.DashOffset;
                FileManager.LocalSettings.Values["LineGridMinorDashStyle"] = (int)gridMinor.DashStyle;
                FileManager.LocalSettings.Values["LineGridMinorEndCap"] = (int)gridMinor.EndCap;
                FileManager.LocalSettings.Values["LineGridMinorLineJoin"] = (int)gridMinor.LineJoin;
                FileManager.LocalSettings.Values["LineGridMinorMiterLimit"] = (float)gridMinor.MiterLimit;
                FileManager.LocalSettings.Values["LineGridMinorStartCap"] = (int)gridMinor.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line grid major weight.
        /// </summary>
        internal float GridMajorWeight
        {
            get => gridMajorWeight;

            set
            {
                gridMajorWeight = value;
                FileManager.LocalSettings.Values["LineGridMajorWeight"] = (float)gridMajorWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line grid major canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle GridMajor
        {
            get => gridMajor;

            set
            {
                gridMajor = value;
                FileManager.LocalSettings.Values["LineGridMajorDashCap"] = (int)gridMajor.DashCap;
                FileManager.LocalSettings.Values["LineGridMajorDashOffset"] = (float)gridMajor.DashOffset;
                FileManager.LocalSettings.Values["LineGridMajorDashStyle"] = (int)gridMajor.DashStyle;
                FileManager.LocalSettings.Values["LineGridMajorEndCap"] = (int)gridMajor.EndCap;
                FileManager.LocalSettings.Values["LineGridMajorLineJoin"] = (int)gridMajor.LineJoin;
                FileManager.LocalSettings.Values["LineGridMajorMiterLimit"] = (float)gridMajor.MiterLimit;
                FileManager.LocalSettings.Values["LineGridMajorStartCap"] = (int)gridMajor.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line force weight.
        /// </summary>
        internal float ForceWeight
        {
            get => forceWeight;

            set
            {
                forceWeight = value;
                FileManager.LocalSettings.Values["LineForceWeight"] = (float)forceWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle Force
        {
            get => force;

            set
            {
                force = value;
                FileManager.LocalSettings.Values["LineForceDashCap"] = (int)force.DashCap;
                FileManager.LocalSettings.Values["LineForceDashOffset"] = (float)force.DashOffset;
                FileManager.LocalSettings.Values["LineForceDashStyle"] = (int)force.DashStyle;
                FileManager.LocalSettings.Values["LineForceEndCap"] = (int)force.EndCap;
                FileManager.LocalSettings.Values["LineForceLineJoin"] = (int)force.LineJoin;
                FileManager.LocalSettings.Values["LineForceMiterLimit"] = (float)force.MiterLimit;
                FileManager.LocalSettings.Values["LineForceStartCap"] = (int)force.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line reaction weight.
        /// </summary>
        internal float ReactionWeight
        {
            get => reactionWeight;

            set
            {
                reactionWeight = value;
                FileManager.LocalSettings.Values["LineReactionWeight"] = (float)reactionWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line reaction canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle Reaction
        {
            get => reaction;

            set
            {
                reaction = value;
                FileManager.LocalSettings.Values["LineReactionDashCap"] = (int)reaction.DashCap;
                FileManager.LocalSettings.Values["LineReactionDashOffset"] = (float)reaction.DashOffset;
                FileManager.LocalSettings.Values["LineReactionDashStyle"] = (int)reaction.DashStyle;
                FileManager.LocalSettings.Values["LineReactionEndCap"] = (int)reaction.EndCap;
                FileManager.LocalSettings.Values["LineReactionLineJoin"] = (int)reaction.LineJoin;
                FileManager.LocalSettings.Values["LineReactionMiterLimit"] = (float)reaction.MiterLimit;
                FileManager.LocalSettings.Values["LineReactionStartCap"] = (int)reaction.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line selected element weight.
        /// </summary>
        internal float SelectedElementWeight
        {
            get => selectedElementWeight;

            set
            {
                selectedElementWeight = value;
                FileManager.LocalSettings.Values["LineSelectedElementWeight"] = (float)selectedElementWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line selected element canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle SelectedElement
        {
            get => selectedElement;

            set
            {
                selectedElement = value;
                FileManager.LocalSettings.Values["LineSelectedElementDashCap"] = (int)selectedElement.DashCap;
                FileManager.LocalSettings.Values["LineSelectedElementDashOffset"] = (float)selectedElement.DashOffset;
                FileManager.LocalSettings.Values["LineSelectedElementDashStyle"] = (int)selectedElement.DashStyle;
                FileManager.LocalSettings.Values["LineSelectedElementEndCap"] = (int)selectedElement.EndCap;
                FileManager.LocalSettings.Values["LineSelectedElementLineJoin"] = (int)selectedElement.LineJoin;
                FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"] = (float)selectedElement.MiterLimit;
                FileManager.LocalSettings.Values["LineSelectedElementStartCap"] = (int)selectedElement.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line shear force selected weight.
        /// </summary>
        internal float ShearForceSelectedWeight
        {
            get => shearForceSelectedWeight;

            set
            {
                shearForceSelectedWeight = value;
                FileManager.LocalSettings.Values["LineShearForceSelectedWeight"] = (float)shearForceSelectedWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line shear force selected canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle ShearForceSelected
        {
            get => shearForceSelected;

            set
            {
                shearForceSelected = value;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"] = (int)shearForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"] = (float)shearForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"] = (int)shearForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"] = (int)shearForceSelected.EndCap;
                FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"] = (int)shearForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"] = (float)shearForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"] = (int)shearForceSelected.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line moment force selected weight.
        /// </summary>
        internal float MomentForceSelectedWeight
        {
            get => momentForceSelectedWeight;

            set
            {
                momentForceSelectedWeight = value;
                FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"] = (float)momentForceSelectedWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line moment force selected canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle MomentForceSelected
        {
            get => momentForceSelected;

            set
            {
                momentForceSelected = value;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"] = (int)momentForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"] = (float)momentForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"] = (int)momentForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"] = (int)momentForceSelected.EndCap;
                FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"] = (int)momentForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)momentForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"] = (int)momentForceSelected.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line shear force font weight.
        /// </summary>
        internal float ShearForceFontWeight
        {
            get => shearForceFontWeight;

            set
            {
                shearForceFontWeight = value;
                FileManager.LocalSettings.Values["LineShearForceFontWeight"] = (float)shearForceFontWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line shear force font canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle ShearForceFont
        {
            get => shearForceFont;

            set
            {
                shearForceFont = value;
                FileManager.LocalSettings.Values["LineShearForceFontDashCap"] = (int)shearForceFont.DashCap;
                FileManager.LocalSettings.Values["LineShearForceFontDashOffset"] = (float)shearForceFont.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceFontDashStyle"] = (int)shearForceFont.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceFontEndCap"] = (int)shearForceFont.EndCap;
                FileManager.LocalSettings.Values["LineShearForceFontLineJoin"] = (int)shearForceFont.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"] = (float)shearForceFont.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceFontStartCap"] = (int)shearForceFont.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line moment force font weight.
        /// </summary>
        internal float MomentForceFontWeight
        {
            get => momentForceFontWeight;

            set
            {
                momentForceFontWeight = value;
                FileManager.LocalSettings.Values["LineMomentForceFontWeight"] = (float)momentForceFontWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line moment force font canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle MomentForceFont
        {
            get => momentForceFont;

            set
            {
                momentForceFont = value;
                FileManager.LocalSettings.Values["LineMomentForceFontDashCap"] = (int)momentForceFont.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"] = (float)momentForceFont.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"] = (int)momentForceFont.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceFontEndCap"] = (int)momentForceFont.EndCap;
                FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"] = (int)momentForceFont.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"] = (float)momentForceFont.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceFontStartCap"] = (int)momentForceFont.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line shear force weight.
        /// </summary>
        internal float ShearForceWeight
        {
            get => shearForceWeight;

            set
            {
                shearForceWeight = value;
                FileManager.LocalSettings.Values["LineShearForceWeight"] = (float)shearForceWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line shear force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle ShearForce
        {
            get => shearForce;

            set
            {
                shearForce = value;
                FileManager.LocalSettings.Values["LineShearForceDashCap"] = (int)shearForce.DashCap;
                FileManager.LocalSettings.Values["LineShearForceDashOffset"] = (float)shearForce.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceDashStyle"] = (int)shearForce.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceEndCap"] = (int)shearForce.EndCap;
                FileManager.LocalSettings.Values["LineShearForceLineJoin"] = (int)shearForce.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceMiterLimit"] = (float)shearForce.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceStartCap"] = (int)shearForce.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line moment force weight.
        /// </summary>
        internal float MomentForceWeight
        {
            get => momentForceWeight;

            set
            {
                momentForceWeight = value;
                FileManager.LocalSettings.Values["LineMomentForceWeight"] = (float)momentForceWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line moment force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle MomentForce
        {
            get => momentForce;

            set
            {
                momentForce = value;
                FileManager.LocalSettings.Values["LineMomentForceDashCap"] = (int)momentForce.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceDashOffset"] = (float)momentForce.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceDashStyle"] = (int)momentForce.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceEndCap"] = (int)momentForce.EndCap;
                FileManager.LocalSettings.Values["LineMomentForceLineJoin"] = (int)momentForce.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceMiterLimit"] = (float)momentForce.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceStartCap"] = (int)momentForce.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line distributed force weight.
        /// </summary>
        internal float DistributedForceWeight
        {
            get => distributedForceWeight;

            set
            {
                distributedForceWeight = value;
                FileManager.LocalSettings.Values["LineDistributedForceWeight"] = (float)distributedForceWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line distributed force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle DistributedForce
        {
            get => distributedForce;

            set
            {
                distributedForce = value;
                FileManager.LocalSettings.Values["LineDistributedForceDashCap"] = (int)distributedForce.DashCap;
                FileManager.LocalSettings.Values["LineDistributedForceDashOffset"] = (float)distributedForce.DashOffset;
                FileManager.LocalSettings.Values["LineDistributedForceDashStyle"] = (int)distributedForce.DashStyle;
                FileManager.LocalSettings.Values["LineDistributedForceEndCap"] = (int)distributedForce.EndCap;
                FileManager.LocalSettings.Values["LineDistributedForceLineJoin"] = (int)distributedForce.LineJoin;
                FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"] = (float)distributedForce.MiterLimit;
                FileManager.LocalSettings.Values["LineDistributedForceStartCap"] = (int)distributedForce.StartCap;
            }
        }

        /// <summary>
        /// Gets or sets the line distributed force selected weight.
        /// </summary>
        internal float DistributedForceSelectedWeight
        {
            get => distributedForceSelectedWeight;

            set
            {
                distributedForceSelectedWeight = value;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"] = (float)distributedForceSelectedWeight;
            }
        }

        /// <summary>
        /// Gets or sets the line distributed force selected canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle DistributedForceSelected
        {
            get => distributedForceSelected;

            set
            {
                distributedForceSelected = value;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"] = (int)distributedForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)distributedForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)distributedForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"] = (int)distributedForceSelected.EndCap;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)distributedForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)distributedForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"] = (int)distributedForceSelected.StartCap;
            }
        }

        internal OptionsLines()
        {
            gridNormal.DashCap = CanvasCapStyle.Round;
            gridNormal.DashOffset = 0;
            gridNormal.DashStyle = CanvasDashStyle.Solid;
            gridNormal.EndCap = CanvasCapStyle.Flat;
            gridNormal.LineJoin = CanvasLineJoin.Bevel;
            gridNormal.MiterLimit = 0;
            gridNormal.StartCap = CanvasCapStyle.Flat;
            gridNormalWeight = 1;

            gridMinor.DashCap = CanvasCapStyle.Round;
            gridMinor.DashOffset = 0;
            gridMinor.DashStyle = CanvasDashStyle.Solid;
            gridMinor.EndCap = CanvasCapStyle.Flat;
            gridMinor.LineJoin = CanvasLineJoin.Bevel;
            gridMinor.MiterLimit = 0;
            gridMinor.StartCap = CanvasCapStyle.Flat;
            gridMinorWeight = 1;

            gridMajor.DashCap = CanvasCapStyle.Round;
            gridMajor.DashOffset = 0;
            gridMajor.DashStyle = CanvasDashStyle.Solid;
            gridMajor.EndCap = CanvasCapStyle.Flat;
            gridMajor.LineJoin = CanvasLineJoin.Bevel;
            gridMajor.MiterLimit = 0;
            gridMajor.StartCap = CanvasCapStyle.Flat;
            gridMajorWeight = 1;

            force.DashCap = CanvasCapStyle.Round;
            force.DashOffset = 0;
            force.DashStyle = CanvasDashStyle.Solid;
            force.EndCap = CanvasCapStyle.Flat;
            force.LineJoin = CanvasLineJoin.Bevel;
            force.MiterLimit = 0;
            force.StartCap = CanvasCapStyle.Round;
            forceWeight = 5f;

            reaction.DashCap = CanvasCapStyle.Round;
            reaction.DashOffset = 0;
            reaction.DashStyle = CanvasDashStyle.Solid;
            reaction.EndCap = CanvasCapStyle.Flat;
            reaction.LineJoin = CanvasLineJoin.Bevel;
            reaction.MiterLimit = 0;
            reaction.StartCap = CanvasCapStyle.Round;
            reactionWeight = 5f;

            selectedElement.DashCap = CanvasCapStyle.Round;
            selectedElement.DashOffset = 0;
            selectedElement.DashStyle = CanvasDashStyle.Solid;
            selectedElement.EndCap = CanvasCapStyle.Flat;
            selectedElement.LineJoin = CanvasLineJoin.Bevel;
            selectedElement.MiterLimit = 0;
            selectedElement.StartCap = CanvasCapStyle.Flat;
            selectedElementWeight = 2.4f;

            shearForceSelected.DashCap = CanvasCapStyle.Round;
            shearForceSelected.DashOffset = 0;
            shearForceSelected.DashStyle = CanvasDashStyle.Solid;
            shearForceSelected.EndCap = CanvasCapStyle.Flat;
            shearForceSelected.LineJoin = CanvasLineJoin.Bevel;
            shearForceSelected.MiterLimit = 0;
            shearForceSelected.StartCap = CanvasCapStyle.Flat;
            shearForceSelectedWeight = 2.4f;

            momentForceSelected.DashCap = CanvasCapStyle.Round;
            momentForceSelected.DashOffset = 0;
            momentForceSelected.DashStyle = CanvasDashStyle.Solid;
            momentForceSelected.EndCap = CanvasCapStyle.Flat;
            momentForceSelected.LineJoin = CanvasLineJoin.Bevel;
            momentForceSelected.MiterLimit = 0;
            momentForceSelected.StartCap = CanvasCapStyle.Flat;
            momentForceSelectedWeight = 2.4f;

            shearForceFont.DashCap = CanvasCapStyle.Round;
            shearForceFont.DashOffset = 0;
            shearForceFont.DashStyle = CanvasDashStyle.Solid;
            shearForceFont.EndCap = CanvasCapStyle.Flat;
            shearForceFont.LineJoin = CanvasLineJoin.Bevel;
            shearForceFont.MiterLimit = 0;
            shearForceFont.StartCap = CanvasCapStyle.Flat;
            shearForceFontWeight = 2.4f;

            momentForceFont.DashCap = CanvasCapStyle.Round;
            momentForceFont.DashOffset = 0;
            momentForceFont.DashStyle = CanvasDashStyle.Solid;
            momentForceFont.EndCap = CanvasCapStyle.Flat;
            momentForceFont.LineJoin = CanvasLineJoin.Bevel;
            momentForceFont.MiterLimit = 0;
            momentForceFont.StartCap = CanvasCapStyle.Flat;
            momentForceFontWeight = 2.4f;

            shearForce.DashCap = CanvasCapStyle.Round;
            shearForce.DashOffset = 0;
            shearForce.DashStyle = CanvasDashStyle.Solid;
            shearForce.EndCap = CanvasCapStyle.Flat;
            shearForce.LineJoin = CanvasLineJoin.Bevel;
            shearForce.MiterLimit = 0;
            shearForce.StartCap = CanvasCapStyle.Flat;
            shearForceWeight = 1.5f;

            momentForce.DashCap = CanvasCapStyle.Round;
            momentForce.DashOffset = 0;
            momentForce.DashStyle = CanvasDashStyle.Solid;
            momentForce.EndCap = CanvasCapStyle.Flat;
            momentForce.LineJoin = CanvasLineJoin.Bevel;
            momentForce.MiterLimit = 0;
            momentForce.StartCap = CanvasCapStyle.Flat;
            momentForceWeight = 1.5f;

            distributedForce.DashCap = CanvasCapStyle.Round;
            distributedForce.DashOffset = 0;
            distributedForce.DashStyle = CanvasDashStyle.Solid;
            distributedForce.EndCap = CanvasCapStyle.Flat;
            distributedForce.LineJoin = CanvasLineJoin.Bevel;
            distributedForce.MiterLimit = 0;
            distributedForce.StartCap = CanvasCapStyle.Flat;
            distributedForceWeight = 1.5f;

            distributedForceSelected.DashCap = CanvasCapStyle.Round;
            distributedForceSelected.DashOffset = 0;
            distributedForceSelected.DashStyle = CanvasDashStyle.Solid;
            distributedForceSelected.EndCap = CanvasCapStyle.Flat;
            distributedForceSelected.LineJoin = CanvasLineJoin.Bevel;
            distributedForceSelected.MiterLimit = 0;
            distributedForceSelected.StartCap = CanvasCapStyle.Flat;
            distributedForceSelectedWeight = 1.5f;

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("LineGridNormalDashCap"))
                {
                    gridNormal.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalDashCap"];
                    gridNormal.DashOffset = (float)FileManager.LocalSettings.Values["LineGridNormalDashOffset"];
                    gridNormal.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridNormalDashStyle"];
                    gridNormal.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalEndCap"];
                    gridNormal.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridNormalLineJoin"];
                    gridNormal.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridNormalMiterLimit"];
                    gridNormal.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalStartCap"];
                    gridNormalWeight = (float)FileManager.LocalSettings.Values["LineGridNormalWeight"];

                    gridMinor.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorDashCap"];
                    gridMinor.DashOffset = (float)FileManager.LocalSettings.Values["LineGridMinorDashOffset"];
                    gridMinor.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridMinorDashStyle"];
                    gridMinor.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorEndCap"];
                    gridMinor.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridMinorLineJoin"];
                    gridMinor.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridMinorMiterLimit"];
                    gridMinor.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorStartCap"];
                    gridMinorWeight = (float)FileManager.LocalSettings.Values["LineGridMinorWeight"];

                    gridMajor.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorDashCap"];
                    gridMajor.DashOffset = (float)FileManager.LocalSettings.Values["LineGridMajorDashOffset"];
                    gridMajor.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridMajorDashStyle"];
                    gridMajor.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorEndCap"];
                    gridMajor.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridMajorLineJoin"];
                    gridMajor.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridMajorMiterLimit"];
                    gridMajor.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorStartCap"];
                    gridMajorWeight = (float)FileManager.LocalSettings.Values["LineGridMajorWeight"];

                    force.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceDashCap"];
                    force.DashOffset = (float)FileManager.LocalSettings.Values["LineForceDashOffset"];
                    force.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineForceDashStyle"];
                    force.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceEndCap"];
                    force.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineForceLineJoin"];
                    force.MiterLimit = (float)FileManager.LocalSettings.Values["LineForceMiterLimit"];
                    force.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceStartCap"];
                    forceWeight = (float)FileManager.LocalSettings.Values["LineForceWeight"];

                    reaction.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionDashCap"];
                    reaction.DashOffset = (float)FileManager.LocalSettings.Values["LineReactionDashOffset"];
                    reaction.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineReactionDashStyle"];
                    reaction.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionEndCap"];
                    reaction.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineReactionLineJoin"];
                    reaction.MiterLimit = (float)FileManager.LocalSettings.Values["LineReactionMiterLimit"];
                    reaction.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionStartCap"];
                    reactionWeight = (float)FileManager.LocalSettings.Values["LineReactionWeight"];

                    selectedElement.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementDashCap"];
                    selectedElement.DashOffset = (float)FileManager.LocalSettings.Values["LineSelectedElementDashOffset"];
                    selectedElement.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineSelectedElementDashStyle"];
                    selectedElement.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementEndCap"];
                    selectedElement.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineSelectedElementLineJoin"];
                    selectedElement.MiterLimit = (float)FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"];
                    selectedElement.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementStartCap"];
                    selectedElementWeight = (float)FileManager.LocalSettings.Values["LineSelectedElementWeight"];

                    shearForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"];
                    shearForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"];
                    shearForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"];
                    shearForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"];
                    shearForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"];
                    shearForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"];
                    shearForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"];
                    shearForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineShearForceSelectedWeight"];

                    momentForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"];
                    momentForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"];
                    momentForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"];
                    momentForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"];
                    momentForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"];
                    momentForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"];
                    momentForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"];
                    momentForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"];

                    // TODO Check if this is still used.
                    shearForceFont.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontDashCap"];
                    shearForceFont.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceFontDashOffset"];
                    shearForceFont.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceFontDashStyle"];
                    shearForceFont.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontEndCap"];
                    shearForceFont.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceFontLineJoin"];
                    shearForceFont.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"];
                    shearForceFont.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontStartCap"];
                    shearForceFontWeight = (float)FileManager.LocalSettings.Values["LineShearForceFontWeight"];

                    // TODO Check if this is still used.
                    momentForceFont.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontDashCap"];
                    momentForceFont.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"];
                    momentForceFont.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"];
                    momentForceFont.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontEndCap"];
                    momentForceFont.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"];
                    momentForceFont.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"];
                    momentForceFont.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontStartCap"];
                    momentForceFontWeight = (float)FileManager.LocalSettings.Values["LineMomentForceFontWeight"];

                    shearForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceDashCap"];
                    shearForce.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceDashOffset"];
                    shearForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceDashStyle"];
                    shearForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceEndCap"];
                    shearForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceLineJoin"];
                    shearForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceMiterLimit"];
                    shearForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceStartCap"];
                    shearForceWeight = (float)FileManager.LocalSettings.Values["LineShearForceWeight"];

                    momentForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceDashCap"];
                    momentForce.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceDashOffset"];
                    momentForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceDashStyle"];
                    momentForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceEndCap"];
                    momentForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceLineJoin"];
                    momentForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceMiterLimit"];
                    momentForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceStartCap"];
                    momentForceWeight = (float)FileManager.LocalSettings.Values["LineMomentForceWeight"];

                    distributedForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceDashCap"];
                    distributedForce.DashOffset = (float)FileManager.LocalSettings.Values["LineDistributedForceDashOffset"];
                    distributedForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineDistributedForceDashStyle"];
                    distributedForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceEndCap"];
                    distributedForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineDistributedForceLineJoin"];
                    distributedForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"];
                    distributedForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceStartCap"];
                    distributedForceWeight = (float)FileManager.LocalSettings.Values["LineDistributedForceWeight"];

                    // TODO Check if this is still used.
                    distributedForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"];
                    distributedForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"];
                    distributedForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"];
                    distributedForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"];
                    distributedForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"];
                    distributedForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"];
                    distributedForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"];
                    distributedForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"];
                }



            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}