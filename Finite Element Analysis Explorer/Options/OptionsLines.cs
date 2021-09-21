namespace Finite_Element_Analysis_Explorer
{
    using Microsoft.Graphics.Canvas.Geometry;
    using System;

    internal class OptionsLines
    {
        /// <summary>
        /// Gets or sets the line grid normal weight.
        /// </summary>
        internal float GridNormalWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line grid normal canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle GridNormal { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line grid minor weight.
        /// </summary>
        internal float GridMinorWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line grid minor canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle GridMinor { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line grid major weight.
        /// </summary>
        internal float GridMajorWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line grid major canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle GridMajor { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line force weight.
        /// </summary>
        internal float ForceWeight { get; set; } = 5f;

        /// <summary>
        /// Gets or sets the line force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle Force { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line reaction weight.
        /// </summary>
        internal float ReactionWeight { get; set; } = 5f;

        /// <summary>
        /// Gets or sets the line reaction canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle Reaction { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line selected element weight.
        /// </summary>
        internal float SelectedElementWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line selected element canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle SelectedElement { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line shear force selected weight.
        /// </summary>
        internal float ShearForceSelectedWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line shear force selected canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle ShearForceSelected { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line moment force selected weight.
        /// </summary>
        internal float MomentForceSelectedWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line moment force selected canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle MomentForceSelected { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line shear force font weight.
        /// </summary>
        internal float ShearForceFontWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line shear force font canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle ShearForceFont { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line moment force font weight.
        /// </summary>
        internal float MomentForceFontWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line moment force font canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle MomentForceFont { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line shear force weight.
        /// </summary>
        internal float ShearForceWeight { get; set; } = 1.5f;

        /// <summary>
        /// Gets or sets the line shear force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle ShearForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line moment force weight.
        /// </summary>
        internal float MomentForceWeight { get; set; } = 1.5f;

        /// <summary>
        /// Gets or sets the line moment force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle MomentForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line distributed force weight.
        /// </summary>
        internal float DistributedForceWeight { get; set; } = 1.5f;

        /// <summary>
        /// Gets or sets the line distributed force canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle DistributedForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line distributed force selected weight.
        /// </summary>
        internal float DistributedForceSelectedWeight { get; set; } = 1.8f;

        /// <summary>
        /// Gets or sets the line distributed force selected canvas stroke style.
        /// </summary>
        internal CanvasStrokeStyle DistributedForceSelected { get; set; } = new CanvasStrokeStyle();

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

            Load();
        }

        private void Load()
        {
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

        internal void Save()
        {
            FileManager.LocalSettings.Values["LineGridNormalDashCap"] = (int)GridNormal.DashCap;
            FileManager.LocalSettings.Values["LineGridNormalDashOffset"] = (float)GridNormal.DashOffset;
            FileManager.LocalSettings.Values["LineGridNormalDashStyle"] = (int)GridNormal.DashStyle;
            FileManager.LocalSettings.Values["LineGridNormalEndCap"] = (int)GridNormal.EndCap;
            FileManager.LocalSettings.Values["LineGridNormalLineJoin"] = (int)GridNormal.LineJoin;
            FileManager.LocalSettings.Values["LineGridNormalMiterLimit"] = (float)GridNormal.MiterLimit;
            FileManager.LocalSettings.Values["LineGridNormalStartCap"] = (int)GridNormal.StartCap;
            FileManager.LocalSettings.Values["LineGridNormalWeight"] = (float)GridNormalWeight;

            FileManager.LocalSettings.Values["LineGridMinorDashCap"] = (int)GridMinor.DashCap;
            FileManager.LocalSettings.Values["LineGridMinorDashOffset"] = (float)GridMinor.DashOffset;
            FileManager.LocalSettings.Values["LineGridMinorDashStyle"] = (int)GridMinor.DashStyle;
            FileManager.LocalSettings.Values["LineGridMinorEndCap"] = (int)GridMinor.EndCap;
            FileManager.LocalSettings.Values["LineGridMinorLineJoin"] = (int)GridMinor.LineJoin;
            FileManager.LocalSettings.Values["LineGridMinorMiterLimit"] = (float)GridMinor.MiterLimit;
            FileManager.LocalSettings.Values["LineGridMinorStartCap"] = (int)GridMinor.StartCap;
            FileManager.LocalSettings.Values["LineGridMinorWeight"] = (float)GridMinorWeight;

            FileManager.LocalSettings.Values["LineGridMajorDashCap"] = (int)GridMajor.DashCap;
            FileManager.LocalSettings.Values["LineGridMajorDashOffset"] = (float)GridMajor.DashOffset;
            FileManager.LocalSettings.Values["LineGridMajorDashStyle"] = (int)GridMajor.DashStyle;
            FileManager.LocalSettings.Values["LineGridMajorEndCap"] = (int)GridMajor.EndCap;
            FileManager.LocalSettings.Values["LineGridMajorLineJoin"] = (int)GridMajor.LineJoin;
            FileManager.LocalSettings.Values["LineGridMajorMiterLimit"] = (float)GridMajor.MiterLimit;
            FileManager.LocalSettings.Values["LineGridMajorStartCap"] = (int)GridMajor.StartCap;
            FileManager.LocalSettings.Values["LineGridMajorWeight"] = (float)GridMajorWeight;

            FileManager.LocalSettings.Values["LineForceDashCap"] = (int)Force.DashCap;
            FileManager.LocalSettings.Values["LineForceDashOffset"] = (float)Force.DashOffset;
            FileManager.LocalSettings.Values["LineForceDashStyle"] = (int)Force.DashStyle;
            FileManager.LocalSettings.Values["LineForceEndCap"] = (int)Force.EndCap;
            FileManager.LocalSettings.Values["LineForceLineJoin"] = (int)Force.LineJoin;
            FileManager.LocalSettings.Values["LineForceMiterLimit"] = (float)Force.MiterLimit;
            FileManager.LocalSettings.Values["LineForceStartCap"] = (int)Force.StartCap;
            FileManager.LocalSettings.Values["LineForceWeight"] = (float)ForceWeight;

            FileManager.LocalSettings.Values["LineReactionDashCap"] = (int)Reaction.DashCap;
            FileManager.LocalSettings.Values["LineReactionDashOffset"] = (float)Reaction.DashOffset;
            FileManager.LocalSettings.Values["LineReactionDashStyle"] = (int)Reaction.DashStyle;
            FileManager.LocalSettings.Values["LineReactionEndCap"] = (int)Reaction.EndCap;
            FileManager.LocalSettings.Values["LineReactionLineJoin"] = (int)Reaction.LineJoin;
            FileManager.LocalSettings.Values["LineReactionMiterLimit"] = (float)Reaction.MiterLimit;
            FileManager.LocalSettings.Values["LineReactionStartCap"] = (int)Reaction.StartCap;
            FileManager.LocalSettings.Values["LineReactionWeight"] = (float)ReactionWeight;

            FileManager.LocalSettings.Values["LineSelectedElementDashCap"] = (int)SelectedElement.DashCap;
            FileManager.LocalSettings.Values["LineSelectedElementDashOffset"] = (float)SelectedElement.DashOffset;
            FileManager.LocalSettings.Values["LineSelectedElementDashStyle"] = (int)SelectedElement.DashStyle;
            FileManager.LocalSettings.Values["LineSelectedElementEndCap"] = (int)SelectedElement.EndCap;
            FileManager.LocalSettings.Values["LineSelectedElementLineJoin"] = (int)SelectedElement.LineJoin;
            FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"] = (float)SelectedElement.MiterLimit;
            FileManager.LocalSettings.Values["LineSelectedElementStartCap"] = (int)SelectedElement.StartCap;
            FileManager.LocalSettings.Values["LineSelectedElementWeight"] = (float)SelectedElementWeight;

            FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"] = (int)ShearForceSelected.DashCap;
            FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"] = (float)ShearForceSelected.DashOffset;
            FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"] = (int)ShearForceSelected.DashStyle;
            FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"] = (int)ShearForceSelected.EndCap;
            FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"] = (int)ShearForceSelected.LineJoin;
            FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"] = (float)ShearForceSelected.MiterLimit;
            FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"] = (int)ShearForceSelected.StartCap;
            FileManager.LocalSettings.Values["LineShearForceSelectedWeight"] = (float)ShearForceSelectedWeight;

            FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"] = (int)MomentForceSelected.DashCap;
            FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"] = (float)MomentForceSelected.DashOffset;
            FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"] = (int)MomentForceSelected.DashStyle;
            FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"] = (int)MomentForceSelected.EndCap;
            FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"] = (int)MomentForceSelected.LineJoin;
            FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)MomentForceSelected.MiterLimit;
            FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"] = (int)MomentForceSelected.StartCap;
            FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"] = (float)MomentForceSelectedWeight;

            FileManager.LocalSettings.Values["LineShearForceFontDashCap"] = (int)ShearForceFont.DashCap;
            FileManager.LocalSettings.Values["LineShearForceFontDashOffset"] = (float)ShearForceFont.DashOffset;
            FileManager.LocalSettings.Values["LineShearForceFontDashStyle"] = (int)ShearForceFont.DashStyle;
            FileManager.LocalSettings.Values["LineShearForceFontEndCap"] = (int)ShearForceFont.EndCap;
            FileManager.LocalSettings.Values["LineShearForceFontLineJoin"] = (int)ShearForceFont.LineJoin;
            FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"] = (float)ShearForceFont.MiterLimit;
            FileManager.LocalSettings.Values["LineShearForceFontStartCap"] = (int)ShearForceFont.StartCap;
            FileManager.LocalSettings.Values["LineShearForceFontWeight"] = (float)ShearForceFontWeight;

            FileManager.LocalSettings.Values["LineMomentForceFontDashCap"] = (int)MomentForceFont.DashCap;
            FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"] = (float)MomentForceFont.DashOffset;
            FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"] = (int)MomentForceFont.DashStyle;
            FileManager.LocalSettings.Values["LineMomentForceFontEndCap"] = (int)MomentForceFont.EndCap;
            FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"] = (int)MomentForceFont.LineJoin;
            FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"] = (float)MomentForceFont.MiterLimit;
            FileManager.LocalSettings.Values["LineMomentForceFontStartCap"] = (int)MomentForceFont.StartCap;
            FileManager.LocalSettings.Values["LineMomentForceFontWeight"] = (float)MomentForceFontWeight;

            FileManager.LocalSettings.Values["LineShearForceDashCap"] = (int)ShearForce.DashCap;
            FileManager.LocalSettings.Values["LineShearForceDashOffset"] = (float)ShearForce.DashOffset;
            FileManager.LocalSettings.Values["LineShearForceDashStyle"] = (int)ShearForce.DashStyle;
            FileManager.LocalSettings.Values["LineShearForceEndCap"] = (int)ShearForce.EndCap;
            FileManager.LocalSettings.Values["LineShearForceLineJoin"] = (int)ShearForce.LineJoin;
            FileManager.LocalSettings.Values["LineShearForceMiterLimit"] = (float)ShearForce.MiterLimit;
            FileManager.LocalSettings.Values["LineShearForceStartCap"] = (int)ShearForce.StartCap;
            FileManager.LocalSettings.Values["LineShearForceWeight"] = (float)ShearForceWeight;

            FileManager.LocalSettings.Values["LineMomentForceDashCap"] = (int)MomentForce.DashCap;
            FileManager.LocalSettings.Values["LineMomentForceDashOffset"] = (float)MomentForce.DashOffset;
            FileManager.LocalSettings.Values["LineMomentForceDashStyle"] = (int)MomentForce.DashStyle;
            FileManager.LocalSettings.Values["LineMomentForceEndCap"] = (int)MomentForce.EndCap;
            FileManager.LocalSettings.Values["LineMomentForceLineJoin"] = (int)MomentForce.LineJoin;
            FileManager.LocalSettings.Values["LineMomentForceMiterLimit"] = (float)MomentForce.MiterLimit;
            FileManager.LocalSettings.Values["LineMomentForceStartCap"] = (int)MomentForce.StartCap;
            FileManager.LocalSettings.Values["LineMomentForceWeight"] = (float)MomentForceWeight;

            FileManager.LocalSettings.Values["LineDistributedForceDashCap"] = (int)DistributedForce.DashCap;
            FileManager.LocalSettings.Values["LineDistributedForceDashOffset"] = (float)DistributedForce.DashOffset;
            FileManager.LocalSettings.Values["LineDistributedForceDashStyle"] = (int)DistributedForce.DashStyle;
            FileManager.LocalSettings.Values["LineDistributedForceEndCap"] = (int)DistributedForce.EndCap;
            FileManager.LocalSettings.Values["LineDistributedForceLineJoin"] = (int)DistributedForce.LineJoin;
            FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"] = (float)DistributedForce.MiterLimit;
            FileManager.LocalSettings.Values["LineDistributedForceStartCap"] = (int)DistributedForce.StartCap;
            FileManager.LocalSettings.Values["LineDistributedForceWeight"] = (float)DistributedForceWeight;

            FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"] = (int)DistributedForceSelected.DashCap;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)DistributedForceSelected.DashOffset;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)DistributedForceSelected.DashStyle;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"] = (int)DistributedForceSelected.EndCap;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)DistributedForceSelected.LineJoin;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)DistributedForceSelected.MiterLimit;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"] = (int)DistributedForceSelected.StartCap;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"] = (float)DistributedForceSelectedWeight;

        }
    }
}
