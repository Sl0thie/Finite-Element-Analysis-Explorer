namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Windows.UI;

    internal class OptionsColors
    {
        /// <summary>
        /// Gets or sets background color.
        /// </summary>
        internal Color Background { get; set; } = Color.FromArgb(255, 0, 12, 24);

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        internal Color Label { get; set; } = Color.FromArgb(255, 255, 255, 255);

        /// <summary>
        /// Gets or sets the force color.
        /// </summary>
        internal Color Force { get; set; } = Color.FromArgb(255, 255, 255, 0);

        /// <summary>
        /// Gets or sets the reaction color.
        /// </summary>
        internal Color Reaction { get; set; } = Color.FromArgb(255, 255, 0, 0);

        /// <summary>
        /// Gets or sets the normal grid color.
        /// </summary>
        internal Color GridNormal { get; set; } = Color.FromArgb(192, 48, 48, 96);

        /// <summary>
        /// Gets or sets the minor grid color.
        /// </summary>
        internal Color GridMinor { get; set; } = Color.FromArgb(192, 48, 48, 48);

        /// <summary>
        /// Gets or sets the major grid color.
        /// </summary>
        internal Color GridMajor { get; set; } = Color.FromArgb(192, 48, 96, 48);

        /// <summary>
        /// Gets or sets the major grid font.
        /// </summary>
        internal Color GridMajorFont { get; set; } = Color.FromArgb(255, 48, 48, 156);

        /// <summary>
        /// Gets or sets the selected node color.
        /// </summary>
        internal Color SelectedNode { get; set; } = Color.FromArgb(255, 64, 64, 255);

        /// <summary>
        /// Gets or sets the selected element color.
        /// </summary>
        internal Color SelectedElement { get; set; } = Color.FromArgb(255, 255, 0, 255);

        /// <summary>
        /// Gets or sets the selected shear force color.
        /// </summary>
        internal Color ShearForceSelected { get; set; } = Color.FromArgb(255, 64, 64, 255);

        /// <summary>
        /// Gets or sets the selected moment force color.
        /// </summary>
        internal Color MomentForceSelected { get; set; } = Color.FromArgb(255, 0, 255, 0);

        /// <summary>
        /// Gets or sets the selected distributed force color.
        /// </summary>
        internal Color DistributedForceSelected { get; set; } = Color.FromArgb(255, 255, 255, 64);

        /// <summary>
        /// Gets or sets the shear force font.
        /// </summary>
        internal Color ShearForceFont { get; set; } = Color.FromArgb(255, 128, 128, 255);

        /// <summary>
        /// Gets or sets the moment force font.
        /// </summary>
        internal Color MomentForceFont { get; set; } = Color.FromArgb(255, 64, 255, 64);

        /// <summary>
        /// Gets or sets the shear force color.
        /// </summary>
        internal Color ShearForce { get; set; } = Color.FromArgb(128, 0, 0, 255);

        /// <summary>
        /// Gets or sets the moment force color.
        /// </summary>
        internal Color MomentForce { get; set; } = Color.FromArgb(128, 0, 255, 0);

        /// <summary>
        /// Gets or sets the distributed force color.
        /// </summary>
        internal Color DistributedForce { get; set; } = Color.FromArgb(128, 255, 255, 0);

        /// <summary>
        /// Gets or sets the color to edit.
        /// </summary>
        internal string ColorToEdit { get; set; }

        internal OptionsColors()
        {
            Load();
        }

        private void Load()
        {
            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorBackgroundA"];
                int r = (int)FileManager.LocalSettings.Values["ColorBackgroundR"];
                int g = (int)FileManager.LocalSettings.Values["ColorBackgroundG"];
                int b = (int)FileManager.LocalSettings.Values["ColorBackgroundB"];

                Background = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorLabelA"];
                int r = (int)FileManager.LocalSettings.Values["ColorLabelR"];
                int g = (int)FileManager.LocalSettings.Values["ColorLabelG"];
                int b = (int)FileManager.LocalSettings.Values["ColorLabelB"];

                Label = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorForceB"];

                Force = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorReactionA"];
                int r = (int)FileManager.LocalSettings.Values["ColorReactionR"];
                int g = (int)FileManager.LocalSettings.Values["ColorReactionG"];
                int b = (int)FileManager.LocalSettings.Values["ColorReactionB"];

                Reaction = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridNormalA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridNormalR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridNormalG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridNormalB"];

                GridNormal = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridMinorA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridMinorR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridMinorG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridMinorB"];

                GridMinor = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridMajorA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridMajorR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridMajorG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridMajorB"];

                GridMajor = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridMajorFontA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridMajorFontR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridMajorFontG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridMajorFontB"];

                GridMajorFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                int r = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                int g = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                int b = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];

                SelectedNode = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorSelectedElementA"];
                int r = (int)FileManager.LocalSettings.Values["ColorSelectedElementR"];
                int g = (int)FileManager.LocalSettings.Values["ColorSelectedElementG"];
                int b = (int)FileManager.LocalSettings.Values["ColorSelectedElementB"];

                SelectedElement = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedB"];

                ShearForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedB"];

                MomentForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"];

                DistributedForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorShearForceFontA"];
                int r = (int)FileManager.LocalSettings.Values["ColorShearForceFontR"];
                int g = (int)FileManager.LocalSettings.Values["ColorShearForceFontG"];
                int b = (int)FileManager.LocalSettings.Values["ColorShearForceFontB"];

                ShearForceFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorMomentForceFontA"];
                int r = (int)FileManager.LocalSettings.Values["ColorMomentForceFontR"];
                int g = (int)FileManager.LocalSettings.Values["ColorMomentForceFontG"];
                int b = (int)FileManager.LocalSettings.Values["ColorMomentForceFontB"];

                MomentForceFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorMomentForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorMomentForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorMomentForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorMomentForceB"];

                MomentForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorDistributedForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorDistributedForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorDistributedForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorDistributedForceB"];

                DistributedForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }

        internal void Save()
        {
            FileManager.LocalSettings.Values["ColorBackgroundA"] = (int)Background.A;
            FileManager.LocalSettings.Values["ColorBackgroundR"] = (int)Background.R;
            FileManager.LocalSettings.Values["ColorBackgroundG"] = (int)Background.G;
            FileManager.LocalSettings.Values["ColorBackgroundB"] = (int)Background.B;

            FileManager.LocalSettings.Values["ColorLabelA"] = (int)Label.A;
            FileManager.LocalSettings.Values["ColorLabelR"] = (int)Label.R;
            FileManager.LocalSettings.Values["ColorLabelG"] = (int)Label.G;
            FileManager.LocalSettings.Values["ColorLabelB"] = (int)Label.B;

            FileManager.LocalSettings.Values["ColorForceA"] = (int)Force.A;
            FileManager.LocalSettings.Values["ColorForceR"] = (int)Force.R;
            FileManager.LocalSettings.Values["ColorForceG"] = (int)Force.G;
            FileManager.LocalSettings.Values["ColorForceB"] = (int)Force.B;

            FileManager.LocalSettings.Values["ColorReactionA"] = (int)Reaction.A;
            FileManager.LocalSettings.Values["ColorReactionR"] = (int)Reaction.R;
            FileManager.LocalSettings.Values["ColorReactionG"] = (int)Reaction.G;
            FileManager.LocalSettings.Values["ColorReactionB"] = (int)Reaction.B;

            FileManager.LocalSettings.Values["ColorGridNormalA"] = (int)GridNormal.A;
            FileManager.LocalSettings.Values["ColorGridNormalR"] = (int)GridNormal.R;
            FileManager.LocalSettings.Values["ColorGridNormalG"] = (int)GridNormal.G;
            FileManager.LocalSettings.Values["ColorGridNormalB"] = (int)GridNormal.B;

            FileManager.LocalSettings.Values["ColorGridMinorA"] = (int)GridMinor.A;
            FileManager.LocalSettings.Values["ColorGridMinorR"] = (int)GridMinor.R;
            FileManager.LocalSettings.Values["ColorGridMinorG"] = (int)GridMinor.G;
            FileManager.LocalSettings.Values["ColorGridMinorB"] = (int)GridMinor.B;

            FileManager.LocalSettings.Values["ColorGridMajorA"] = (int)GridMajor.A;
            FileManager.LocalSettings.Values["ColorGridMajorR"] = (int)GridMajor.R;
            FileManager.LocalSettings.Values["ColorGridMajorG"] = (int)GridMajor.G;
            FileManager.LocalSettings.Values["ColorGridMajorB"] = (int)GridMajor.B;

            FileManager.LocalSettings.Values["ColorGridMajorFontA"] = (int)GridMajorFont.A;
            FileManager.LocalSettings.Values["ColorGridMajorFontR"] = (int)GridMajorFont.R;
            FileManager.LocalSettings.Values["ColorGridMajorFontG"] = (int)GridMajorFont.G;
            FileManager.LocalSettings.Values["ColorGridMajorFontB"] = (int)GridMajorFont.B;

            FileManager.LocalSettings.Values["ColorSelectedNodeA"] = (int)SelectedNode.A;
            FileManager.LocalSettings.Values["ColorSelectedNodeR"] = (int)SelectedNode.R;
            FileManager.LocalSettings.Values["ColorSelectedNodeG"] = (int)SelectedNode.G;
            FileManager.LocalSettings.Values["ColorSelectedNodeB"] = (int)SelectedNode.B;

            FileManager.LocalSettings.Values["ColorSelectedElementA"] = (int)SelectedElement.A;
            FileManager.LocalSettings.Values["ColorSelectedElementR"] = (int)SelectedElement.R;
            FileManager.LocalSettings.Values["ColorSelectedElementG"] = (int)SelectedElement.G;
            FileManager.LocalSettings.Values["ColorSelectedElementB"] = (int)SelectedElement.B;

            FileManager.LocalSettings.Values["ColorShearForceSelectedA"] = (int)ShearForceSelected.A;
            FileManager.LocalSettings.Values["ColorShearForceSelectedR"] = (int)ShearForceSelected.R;
            FileManager.LocalSettings.Values["ColorShearForceSelectedG"] = (int)ShearForceSelected.G;
            FileManager.LocalSettings.Values["ColorShearForceSelectedB"] = (int)ShearForceSelected.B;

            FileManager.LocalSettings.Values["ColorMomentForceSelectedA"] = (int)MomentForceSelected.A;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedR"] = (int)MomentForceSelected.R;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedG"] = (int)MomentForceSelected.G;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedB"] = (int)MomentForceSelected.B;

            FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"] = (int)DistributedForceSelected.A;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"] = (int)DistributedForceSelected.R;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"] = (int)DistributedForceSelected.G;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"] = (int)DistributedForceSelected.B;

            FileManager.LocalSettings.Values["ColorShearForceFontA"] = (int)ShearForceFont.A;
            FileManager.LocalSettings.Values["ColorShearForceFontR"] = (int)ShearForceFont.R;
            FileManager.LocalSettings.Values["ColorShearForceFontG"] = (int)ShearForceFont.G;
            FileManager.LocalSettings.Values["ColorShearForceFontB"] = (int)ShearForceFont.B;

            FileManager.LocalSettings.Values["ColorMomentForceFontA"] = (int)MomentForceFont.A;
            FileManager.LocalSettings.Values["ColorMomentForceFontR"] = (int)MomentForceFont.R;
            FileManager.LocalSettings.Values["ColorMomentForceFontG"] = (int)MomentForceFont.G;
            FileManager.LocalSettings.Values["ColorMomentForceFontB"] = (int)MomentForceFont.B;

            FileManager.LocalSettings.Values["ColorShearForceA"] = (int)ShearForce.A;
            FileManager.LocalSettings.Values["ColorShearForceR"] = (int)ShearForce.R;
            FileManager.LocalSettings.Values["ColorShearForceG"] = (int)ShearForce.G;
            FileManager.LocalSettings.Values["ColorShearForceB"] = (int)ShearForce.B;

            FileManager.LocalSettings.Values["ColorMomentForceA"] = (int)MomentForce.A;
            FileManager.LocalSettings.Values["ColorMomentForceR"] = (int)MomentForce.R;
            FileManager.LocalSettings.Values["ColorMomentForceG"] = (int)MomentForce.G;
            FileManager.LocalSettings.Values["ColorMomentForceB"] = (int)MomentForce.B;

            FileManager.LocalSettings.Values["ColorDistributedForceA"] = (int)DistributedForce.A;
            FileManager.LocalSettings.Values["ColorDistributedForceR"] = (int)DistributedForce.R;
            FileManager.LocalSettings.Values["ColorDistributedForceG"] = (int)DistributedForce.G;
            FileManager.LocalSettings.Values["ColorDistributedForceB"] = (int)DistributedForce.B;
        }
    }
}