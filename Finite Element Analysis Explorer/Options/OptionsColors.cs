namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.UI;

    internal class OptionsColors
    {
        private Color background = Color.FromArgb(255, 0, 12, 24);
        private Color label = Color.FromArgb(255, 255, 255, 255);
        private Color force = Color.FromArgb(255, 255, 255, 0);
        private Color reaction = Color.FromArgb(255, 255, 0, 0);
        private Color gridNormal = Color.FromArgb(192, 48, 48, 96);
        private Color gridMinor = Color.FromArgb(192, 48, 48, 48);
        private Color gridMajor = Color.FromArgb(192, 48, 96, 48);
        private Color gridMajorFont = Color.FromArgb(255, 48, 48, 156);
        private Color selectedNode = Color.FromArgb(255, 64, 64, 255);
        private Color selectedElement = Color.FromArgb(255, 255, 0, 255);
        private Color shearForceSelected = Color.FromArgb(255, 64, 64, 255);
        private Color momentForceSelected = Color.FromArgb(255, 0, 255, 0);
        private Color distributedForceSelected = Color.FromArgb(255, 255, 255, 64);
        private Color shearForceFont = Color.FromArgb(255, 128, 128, 255);
        private Color momentForceFont = Color.FromArgb(255, 64, 255, 64);
        private Color shearForce = Color.FromArgb(128, 0, 0, 255);
        private Color momentForce = Color.FromArgb(128, 0, 255, 0);
        private Color distributedForce = Color.FromArgb(128, 255, 255, 0);
        private string colorToEdit;

        /// <summary>
        /// Gets or sets background color.
        /// </summary>
        internal Color Background
        {
            get
            {
                return background;
            }

            set
            {
                background = value;
                FileManager.LocalSettings.Values["ColorBackgroundA"] = (int)background.A;
                FileManager.LocalSettings.Values["ColorBackgroundR"] = (int)background.R;
                FileManager.LocalSettings.Values["ColorBackgroundG"] = (int)background.G;
                FileManager.LocalSettings.Values["ColorBackgroundB"] = (int)background.B;
            }
        }

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        internal Color Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
                FileManager.LocalSettings.Values["ColorLabelA"] = (int)label.A;
                FileManager.LocalSettings.Values["ColorLabelR"] = (int)label.R;
                FileManager.LocalSettings.Values["ColorLabelG"] = (int)label.G;
                FileManager.LocalSettings.Values["ColorLabelB"] = (int)label.B;
            }
        }

        /// <summary>
        /// Gets or sets the force color.
        /// </summary>
        internal Color Force
        {
            get
            {
                return force;
            }

            set
            {
                force = value;
                FileManager.LocalSettings.Values["ColorForceA"] = (int)force.A;
                FileManager.LocalSettings.Values["ColorForceR"] = (int)force.R;
                FileManager.LocalSettings.Values["ColorForceG"] = (int)force.G;
                FileManager.LocalSettings.Values["ColorForceB"] = (int)force.B;
            }
        }

        /// <summary>
        /// Gets or sets the reaction color.
        /// </summary>
        internal Color Reaction
        {
            get
            {
                return reaction;
            }

            set
            {
                reaction = value;
                FileManager.LocalSettings.Values["ColorReactionA"] = (int)reaction.A;
                FileManager.LocalSettings.Values["ColorReactionR"] = (int)reaction.R;
                FileManager.LocalSettings.Values["ColorReactionG"] = (int)reaction.G;
                FileManager.LocalSettings.Values["ColorReactionB"] = (int)reaction.B;
            }
        }

        /// <summary>
        /// Gets or sets the normal grid color.
        /// </summary>
        internal Color GridNormal
        {
            get
            {
                return gridNormal;
            }

            set
            {
                gridNormal = value;
                FileManager.LocalSettings.Values["ColorGridNormalA"] = (int)gridNormal.A;
                FileManager.LocalSettings.Values["ColorGridNormalR"] = (int)gridNormal.R;
                FileManager.LocalSettings.Values["ColorGridNormalG"] = (int)gridNormal.G;
                FileManager.LocalSettings.Values["ColorGridNormalB"] = (int)gridNormal.B;
            }
        }

        /// <summary>
        /// Gets or sets the minor grid color.
        /// </summary>
        internal Color GridMinor
        {
            get
            {
                return gridMinor;
            }

            set
            {
                gridMinor = value;
                FileManager.LocalSettings.Values["ColorGridMinorA"] = (int)gridMinor.A;
                FileManager.LocalSettings.Values["ColorGridMinorR"] = (int)gridMinor.R;
                FileManager.LocalSettings.Values["ColorGridMinorG"] = (int)gridMinor.G;
                FileManager.LocalSettings.Values["ColorGridMinorB"] = (int)gridMinor.B;
            }
        }

        /// <summary>
        /// Gets or sets the major grid color.
        /// </summary>
        internal Color GridMajor
        {
            get
            {
                return gridMajor;
            }

            set
            {
                gridMajor = value;
                FileManager.LocalSettings.Values["ColorGridMajorA"] = (int)gridMajor.A;
                FileManager.LocalSettings.Values["ColorGridMajorR"] = (int)gridMajor.R;
                FileManager.LocalSettings.Values["ColorGridMajorG"] = (int)gridMajor.G;
                FileManager.LocalSettings.Values["ColorGridMajorB"] = (int)gridMajor.B;
            }
        }

        /// <summary>
        /// Gets or sets the major grid font.
        /// </summary>
        internal Color GridMajorFont
        {
            get
            {
                return gridMajorFont;
            }

            set
            {
                gridMajorFont = value;
                FileManager.LocalSettings.Values["ColorGridMajorFontA"] = (int)gridMajorFont.A;
                FileManager.LocalSettings.Values["ColorGridMajorFontR"] = (int)gridMajorFont.R;
                FileManager.LocalSettings.Values["ColorGridMajorFontG"] = (int)gridMajorFont.G;
                FileManager.LocalSettings.Values["ColorGridMajorFontB"] = (int)gridMajorFont.B;
            }
        }

        /// <summary>
        /// Gets or sets the selected node color.
        /// </summary>
        internal Color SelectedNode
        {
            get
            {
                return selectedNode;
            }

            set
            {
                selectedNode = value;
                FileManager.LocalSettings.Values["ColorSelectedNodeA"] = (int)selectedNode.A;
                FileManager.LocalSettings.Values["ColorSelectedNodeR"] = (int)selectedNode.R;
                FileManager.LocalSettings.Values["ColorSelectedNodeG"] = (int)selectedNode.G;
                FileManager.LocalSettings.Values["ColorSelectedNodeB"] = (int)selectedNode.B;
            }
        }

        /// <summary>
        /// Gets or sets the selected element color.
        /// </summary>
        internal Color SelectedElement
        {
            get
            {
                return selectedElement;
            }

            set
            {
                selectedElement = value;
                FileManager.LocalSettings.Values["ColorSelectedElementA"] = (int)selectedElement.A;
                FileManager.LocalSettings.Values["ColorSelectedElementR"] = (int)selectedElement.R;
                FileManager.LocalSettings.Values["ColorSelectedElementG"] = (int)selectedElement.G;
                FileManager.LocalSettings.Values["ColorSelectedElementB"] = (int)selectedElement.B;
            }
        }

        /// <summary>
        /// Gets or sets the selected shear force color.
        /// </summary>
        internal Color ShearForceSelected
        {
            get
            {
                return shearForceSelected;
            }

            set
            {
                shearForceSelected = value;
                FileManager.LocalSettings.Values["ColorShearForceSelectedA"] = (int)shearForceSelected.A;
                FileManager.LocalSettings.Values["ColorShearForceSelectedR"] = (int)shearForceSelected.R;
                FileManager.LocalSettings.Values["ColorShearForceSelectedG"] = (int)shearForceSelected.G;
                FileManager.LocalSettings.Values["ColorShearForceSelectedB"] = (int)shearForceSelected.B;
            }
        }

        /// <summary>
        /// Gets or sets the selected moment force color.
        /// </summary>
        internal Color MomentForceSelected
        {
            get
            {
                return momentForceSelected;
            }

            set
            {
                momentForceSelected = value;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedA"] = (int)momentForceSelected.A;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedR"] = (int)momentForceSelected.R;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedG"] = (int)momentForceSelected.G;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedB"] = (int)momentForceSelected.B;
            }
        }

        /// <summary>
        /// Gets or sets the selected distributed force color.
        /// </summary>
        internal Color DistributedForceSelected
        {
            get
            {
                return distributedForceSelected;
            }

            set
            {
                distributedForceSelected = value;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"] = (int)distributedForceSelected.A;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"] = (int)distributedForceSelected.R;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"] = (int)distributedForceSelected.G;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"] = (int)distributedForceSelected.B;
            }
        }

        /// <summary>
        /// Gets or sets the shear force font.
        /// </summary>
        internal Color ShearForceFont
        {
            get
            {
                return shearForceFont;
            }

            set
            {
                shearForceFont = value;
                FileManager.LocalSettings.Values["ColorShearForceFontA"] = (int)shearForceFont.A;
                FileManager.LocalSettings.Values["ColorShearForceFontR"] = (int)shearForceFont.R;
                FileManager.LocalSettings.Values["ColorShearForceFontG"] = (int)shearForceFont.G;
                FileManager.LocalSettings.Values["ColorShearForceFontB"] = (int)shearForceFont.B;
            }
        }

        /// <summary>
        /// Gets or sets the moment force font.
        /// </summary>
        internal Color MomentForceFont
        {
            get
            {
                return momentForceFont;
            }

            set
            {
                momentForceFont = value;
                FileManager.LocalSettings.Values["ColorMomentForceFontA"] = (int)momentForceFont.A;
                FileManager.LocalSettings.Values["ColorMomentForceFontR"] = (int)momentForceFont.R;
                FileManager.LocalSettings.Values["ColorMomentForceFontG"] = (int)momentForceFont.G;
                FileManager.LocalSettings.Values["ColorMomentForceFontB"] = (int)momentForceFont.B;
            }
        }

        /// <summary>
        /// Gets or sets the shear force color.
        /// </summary>
        internal Color ShearForce
        {
            get
            {
                return shearForce;
            }

            set
            {
                shearForce = value;
                FileManager.LocalSettings.Values["ColorShearForceA"] = (int)shearForce.A;
                FileManager.LocalSettings.Values["ColorShearForceR"] = (int)shearForce.R;
                FileManager.LocalSettings.Values["ColorShearForceG"] = (int)shearForce.G;
                FileManager.LocalSettings.Values["ColorShearForceB"] = (int)shearForce.B;
            }
        }

        /// <summary>
        /// Gets or sets the moment force color.
        /// </summary>
        internal Color MomentForce
        {
            get
            {
                return momentForce;
            }

            set
            {
                momentForce = value;
                FileManager.LocalSettings.Values["ColorMomentForceA"] = (int)momentForce.A;
                FileManager.LocalSettings.Values["ColorMomentForceR"] = (int)momentForce.R;
                FileManager.LocalSettings.Values["ColorMomentForceG"] = (int)momentForce.G;
                FileManager.LocalSettings.Values["ColorMomentForceB"] = (int)momentForce.B;
            }
        }

        /// <summary>
        /// Gets or sets the distributed force color.
        /// </summary>
        internal Color DistributedForce
        {
            get
            {
                return distributedForce;
            }

            set
            {
                distributedForce = value;
                FileManager.LocalSettings.Values["ColorDistributedForceA"] = (int)distributedForce.A;
                FileManager.LocalSettings.Values["ColorDistributedForceR"] = (int)distributedForce.R;
                FileManager.LocalSettings.Values["ColorDistributedForceG"] = (int)distributedForce.G;
                FileManager.LocalSettings.Values["ColorDistributedForceB"] = (int)distributedForce.B;
            }
        }

        /// <summary>
        /// Gets or sets the color to edit.
        /// </summary>
        internal string ColorToEdit
        {
            get
            {
                return colorToEdit;
            }

            set
            {
                colorToEdit = value;
            }
        }

        internal OptionsColors()
        {
            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorBackgroundA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorBackgroundA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorBackgroundR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorBackgroundG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorBackgroundB"];
                    Background = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorLabelA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorLabelA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorLabelR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorLabelG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorLabelB"];
                    Label = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorForceA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorForceA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorForceR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorForceG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorForceB"];
                    Force = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorReactionA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorReactionA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorReactionR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorReactionG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorReactionB"];
                    Reaction = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorGridNormalA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorGridNormalA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorGridNormalR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorGridNormalG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorGridNormalB"];
                    GridNormal = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorGridMinorA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorGridMinorA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorGridMinorR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorGridMinorG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorGridMinorB"];
                    GridMinor = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorGridMajorA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorGridMajorA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorGridMajorR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorGridMajorG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorGridMajorB"];
                    GridMajor = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorGridMajorFontA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorGridMajorFontA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorGridMajorFontR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorGridMajorFontG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorGridMajorFontB"];
                    GridMajorFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorSelectedNodeA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                    int g = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                    int b = (int)FileManager.LocalSettings.Values["ColorSelectedNodeA"];
                    SelectedNode = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorSelectedElementA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorSelectedElementA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorSelectedElementR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorSelectedElementG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorSelectedElementB"];
                    SelectedElement = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorShearForceSelectedA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedB"];
                    ShearForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorMomentForceSelectedA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedB"];
                    MomentForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorDistributedForceSelectedA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"];
                    DistributedForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorShearForceFontA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorShearForceFontA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorShearForceFontR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorShearForceFontG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorShearForceFontB"];
                    ShearForceFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorMomentForceFontA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorMomentForceFontA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorMomentForceFontR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorMomentForceFontG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorMomentForceFontB"];
                    MomentForceFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorMomentForceA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorMomentForceA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorMomentForceR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorMomentForceG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorMomentForceB"];

                    MomentForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ColorDistributedForceA"))
                {
                    int a = (int)FileManager.LocalSettings.Values["ColorDistributedForceA"];
                    int r = (int)FileManager.LocalSettings.Values["ColorDistributedForceR"];
                    int g = (int)FileManager.LocalSettings.Values["ColorDistributedForceG"];
                    int b = (int)FileManager.LocalSettings.Values["ColorDistributedForceB"];

                    DistributedForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}