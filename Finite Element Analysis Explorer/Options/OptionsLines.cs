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
            GridNormal.DashCap = CanvasCapStyle.Round;
            GridNormal.DashOffset = 0;
            GridNormal.DashStyle = CanvasDashStyle.Solid;
            GridNormal.EndCap = CanvasCapStyle.Flat;
            GridNormal.LineJoin = CanvasLineJoin.Bevel;
            GridNormal.MiterLimit = 0;
            GridNormal.StartCap = CanvasCapStyle.Flat;
            GridNormalWeight = 1;

            GridMinor.DashCap = CanvasCapStyle.Round;
            GridMinor.DashOffset = 0;
            GridMinor.DashStyle = CanvasDashStyle.Solid;
            GridMinor.EndCap = CanvasCapStyle.Flat;
            GridMinor.LineJoin = CanvasLineJoin.Bevel;
            GridMinor.MiterLimit = 0;
            GridMinor.StartCap = CanvasCapStyle.Flat;
            GridMinorWeight = 1;

            GridMajor.DashCap = CanvasCapStyle.Round;
            GridMajor.DashOffset = 0;
            GridMajor.DashStyle = CanvasDashStyle.Solid;
            GridMajor.EndCap = CanvasCapStyle.Flat;
            GridMajor.LineJoin = CanvasLineJoin.Bevel;
            GridMajor.MiterLimit = 0;
            GridMajor.StartCap = CanvasCapStyle.Flat;
            GridMajorWeight = 1;

            Force.DashCap = CanvasCapStyle.Round;
            Force.DashOffset = 0;
            Force.DashStyle = CanvasDashStyle.Solid;
            Force.EndCap = CanvasCapStyle.Flat;
            Force.LineJoin = CanvasLineJoin.Bevel;
            Force.MiterLimit = 0;
            Force.StartCap = CanvasCapStyle.Round;
            ForceWeight = 5f;

            Reaction.DashCap = CanvasCapStyle.Round;
            Reaction.DashOffset = 0;
            Reaction.DashStyle = CanvasDashStyle.Solid;
            Reaction.EndCap = CanvasCapStyle.Flat;
            Reaction.LineJoin = CanvasLineJoin.Bevel;
            Reaction.MiterLimit = 0;
            Reaction.StartCap = CanvasCapStyle.Round;
            ReactionWeight = 5f;

            SelectedElement.DashCap = CanvasCapStyle.Round;
            SelectedElement.DashOffset = 0;
            SelectedElement.DashStyle = CanvasDashStyle.Solid;
            SelectedElement.EndCap = CanvasCapStyle.Flat;
            SelectedElement.LineJoin = CanvasLineJoin.Bevel;
            SelectedElement.MiterLimit = 0;
            SelectedElement.StartCap = CanvasCapStyle.Flat;
            SelectedElementWeight = 2.4f;

            ShearForceSelected.DashCap = CanvasCapStyle.Round;
            ShearForceSelected.DashOffset = 0;
            ShearForceSelected.DashStyle = CanvasDashStyle.Solid;
            ShearForceSelected.EndCap = CanvasCapStyle.Flat;
            ShearForceSelected.LineJoin = CanvasLineJoin.Bevel;
            ShearForceSelected.MiterLimit = 0;
            ShearForceSelected.StartCap = CanvasCapStyle.Flat;
            ShearForceSelectedWeight = 2.4f;

            MomentForceSelected.DashCap = CanvasCapStyle.Round;
            MomentForceSelected.DashOffset = 0;
            MomentForceSelected.DashStyle = CanvasDashStyle.Solid;
            MomentForceSelected.EndCap = CanvasCapStyle.Flat;
            MomentForceSelected.LineJoin = CanvasLineJoin.Bevel;
            MomentForceSelected.MiterLimit = 0;
            MomentForceSelected.StartCap = CanvasCapStyle.Flat;
            MomentForceSelectedWeight = 2.4f;

            ShearForceFont.DashCap = CanvasCapStyle.Round;
            ShearForceFont.DashOffset = 0;
            ShearForceFont.DashStyle = CanvasDashStyle.Solid;
            ShearForceFont.EndCap = CanvasCapStyle.Flat;
            ShearForceFont.LineJoin = CanvasLineJoin.Bevel;
            ShearForceFont.MiterLimit = 0;
            ShearForceFont.StartCap = CanvasCapStyle.Flat;
            ShearForceFontWeight = 2.4f;

            MomentForceFont.DashCap = CanvasCapStyle.Round;
            MomentForceFont.DashOffset = 0;
            MomentForceFont.DashStyle = CanvasDashStyle.Solid;
            MomentForceFont.EndCap = CanvasCapStyle.Flat;
            MomentForceFont.LineJoin = CanvasLineJoin.Bevel;
            MomentForceFont.MiterLimit = 0;
            MomentForceFont.StartCap = CanvasCapStyle.Flat;
            MomentForceFontWeight = 2.4f;

            ShearForce.DashCap = CanvasCapStyle.Round;
            ShearForce.DashOffset = 0;
            ShearForce.DashStyle = CanvasDashStyle.Solid;
            ShearForce.EndCap = CanvasCapStyle.Flat;
            ShearForce.LineJoin = CanvasLineJoin.Bevel;
            ShearForce.MiterLimit = 0;
            ShearForce.StartCap = CanvasCapStyle.Flat;
            ShearForceWeight = 1.5f;

            MomentForce.DashCap = CanvasCapStyle.Round;
            MomentForce.DashOffset = 0;
            MomentForce.DashStyle = CanvasDashStyle.Solid;
            MomentForce.EndCap = CanvasCapStyle.Flat;
            MomentForce.LineJoin = CanvasLineJoin.Bevel;
            MomentForce.MiterLimit = 0;
            MomentForce.StartCap = CanvasCapStyle.Flat;
            MomentForceWeight = 1.5f;

            DistributedForce.DashCap = CanvasCapStyle.Round;
            DistributedForce.DashOffset = 0;
            DistributedForce.DashStyle = CanvasDashStyle.Solid;
            DistributedForce.EndCap = CanvasCapStyle.Flat;
            DistributedForce.LineJoin = CanvasLineJoin.Bevel;
            DistributedForce.MiterLimit = 0;
            DistributedForce.StartCap = CanvasCapStyle.Flat;
            DistributedForceWeight = 1.5f;

            DistributedForceSelected.DashCap = CanvasCapStyle.Round;
            DistributedForceSelected.DashOffset = 0;
            DistributedForceSelected.DashStyle = CanvasDashStyle.Solid;
            DistributedForceSelected.EndCap = CanvasCapStyle.Flat;
            DistributedForceSelected.LineJoin = CanvasLineJoin.Bevel;
            DistributedForceSelected.MiterLimit = 0;
            DistributedForceSelected.StartCap = CanvasCapStyle.Flat;
            DistributedForceSelectedWeight = 1.5f;

            try
            {
                GridNormal.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalDashCap"];
                GridNormal.DashOffset = (float)FileManager.LocalSettings.Values["LineGridNormalDashOffset"];
                GridNormal.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridNormalDashStyle"];
                GridNormal.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalEndCap"];
                GridNormal.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridNormalLineJoin"];
                GridNormal.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridNormalMiterLimit"];
                GridNormal.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalStartCap"];
                GridNormalWeight = (float)FileManager.LocalSettings.Values["LineGridNormalWeight"];

                GridMinor.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorDashCap"];
                GridMinor.DashOffset = (float)FileManager.LocalSettings.Values["LineGridMinorDashOffset"];
                GridMinor.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridMinorDashStyle"];
                GridMinor.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorEndCap"];
                GridMinor.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridMinorLineJoin"];
                GridMinor.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridMinorMiterLimit"];
                GridMinor.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorStartCap"];
                GridMinorWeight = (float)FileManager.LocalSettings.Values["LineGridMinorWeight"];

                GridMajor.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorDashCap"];
                GridMajor.DashOffset = (float)FileManager.LocalSettings.Values["LineGridMajorDashOffset"];
                GridMajor.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridMajorDashStyle"];
                GridMajor.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorEndCap"];
                GridMajor.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridMajorLineJoin"];
                GridMajor.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridMajorMiterLimit"];
                GridMajor.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorStartCap"];
                GridMajorWeight = (float)FileManager.LocalSettings.Values["LineGridMajorWeight"];

                Force.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceDashCap"];
                Force.DashOffset = (float)FileManager.LocalSettings.Values["LineForceDashOffset"];
                Force.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineForceDashStyle"];
                Force.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceEndCap"];
                Force.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineForceLineJoin"];
                Force.MiterLimit = (float)FileManager.LocalSettings.Values["LineForceMiterLimit"];
                Force.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceStartCap"];
                ForceWeight = (float)FileManager.LocalSettings.Values["LineForceWeight"];

                Reaction.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionDashCap"];
                Reaction.DashOffset = (float)FileManager.LocalSettings.Values["LineReactionDashOffset"];
                Reaction.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineReactionDashStyle"];
                Reaction.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionEndCap"];
                Reaction.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineReactionLineJoin"];
                Reaction.MiterLimit = (float)FileManager.LocalSettings.Values["LineReactionMiterLimit"];
                Reaction.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionStartCap"];
                ReactionWeight = (float)FileManager.LocalSettings.Values["LineReactionWeight"];

                SelectedElement.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementDashCap"];
                SelectedElement.DashOffset = (float)FileManager.LocalSettings.Values["LineSelectedElementDashOffset"];
                SelectedElement.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineSelectedElementDashStyle"];
                SelectedElement.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementEndCap"];
                SelectedElement.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineSelectedElementLineJoin"];
                SelectedElement.MiterLimit = (float)FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"];
                SelectedElement.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementStartCap"];
                SelectedElementWeight = (float)FileManager.LocalSettings.Values["LineSelectedElementWeight"];

                ShearForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"];
                ShearForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"];
                ShearForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"];
                ShearForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"];
                ShearForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"];
                ShearForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"];
                ShearForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"];
                ShearForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineShearForceSelectedWeight"];

                MomentForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"];
                MomentForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"];
                MomentForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"];
                MomentForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"];
                MomentForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"];
                MomentForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"];
                MomentForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"];
                MomentForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"];

                // TODO Check if this is still used.
                ShearForceFont.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontDashCap"];
                ShearForceFont.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceFontDashOffset"];
                ShearForceFont.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceFontDashStyle"];
                ShearForceFont.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontEndCap"];
                ShearForceFont.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceFontLineJoin"];
                ShearForceFont.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"];
                ShearForceFont.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontStartCap"];
                ShearForceFontWeight = (float)FileManager.LocalSettings.Values["LineShearForceFontWeight"];

                // TODO Check if this is still used.
                MomentForceFont.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontDashCap"];
                MomentForceFont.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"];
                MomentForceFont.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"];
                MomentForceFont.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontEndCap"];
                MomentForceFont.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"];
                MomentForceFont.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"];
                MomentForceFont.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontStartCap"];
                MomentForceFontWeight = (float)FileManager.LocalSettings.Values["LineMomentForceFontWeight"];

                ShearForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceDashCap"];
                ShearForce.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceDashOffset"];
                ShearForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceDashStyle"];
                ShearForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceEndCap"];
                ShearForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceLineJoin"];
                ShearForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceMiterLimit"];
                ShearForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceStartCap"];
                ShearForceWeight = (float)FileManager.LocalSettings.Values["LineShearForceWeight"];

                MomentForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceDashCap"];
                MomentForce.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceDashOffset"];
                MomentForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceDashStyle"];
                MomentForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceEndCap"];
                MomentForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceLineJoin"];
                MomentForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceMiterLimit"];
                MomentForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceStartCap"];
                MomentForceWeight = (float)FileManager.LocalSettings.Values["LineMomentForceWeight"];

                DistributedForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceDashCap"];
                DistributedForce.DashOffset = (float)FileManager.LocalSettings.Values["LineDistributedForceDashOffset"];
                DistributedForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineDistributedForceDashStyle"];
                DistributedForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceEndCap"];
                DistributedForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineDistributedForceLineJoin"];
                DistributedForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"];
                DistributedForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceStartCap"];
                DistributedForceWeight = (float)FileManager.LocalSettings.Values["LineDistributedForceWeight"];

                // TODO Check if this is still used.
                DistributedForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"];
                DistributedForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"];
                DistributedForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"];
                DistributedForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"];
                DistributedForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"];
                DistributedForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"];
                DistributedForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"];
                DistributedForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"];
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}