namespace Finite_Element_Analysis_Explorer
{
    using System;

    internal class OptionsDisplay
    {
        private float momentFactor = 0.001f;
        private float shearFactor = 0.001f;
        private float linearFactor = 0.001f;
        private float forcesFactor = 0.001f;
        private float reactionsFactor = 0.001f;
        private float displacementFactor = 1;
        private float cameraZoomTrim = 500f;
        private int memberDisplayType = 0;
        private bool showReactions = true;
        private bool showAxial = true;
        private bool showLinear = true;
        private bool showForce = true;
        private bool showShear = true;
        private bool showMoment = true;

        /// <summary>
        /// Gets or sets a value indicating whether to show moment.
        /// </summary>
        internal bool ShowMoment
        {
            get
            {
                return showMoment;
            }

            set
            {
                showMoment = value;
                FileManager.LocalSettings.Values["ShowMoment"] = ShowMoment;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show shear.
        /// </summary>
        internal bool ShowShear
        {
            get
            {
                return showShear;
            }

            set
            {
                showShear = value;
                FileManager.LocalSettings.Values["ShowShear"] = showShear;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show force.
        /// </summary>
        internal bool ShowForce
        {
            get
            {
                return showForce;
            }

            set
            {
                showForce = value;
                FileManager.LocalSettings.Values["ShowForce"] = showForce;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show linear force.
        /// </summary>
        internal bool ShowLinear
        {
            get
            {
                return showLinear;
            }

            set
            {
                showLinear = value;
                FileManager.LocalSettings.Values["ShowLinear"] = showLinear;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show axial.
        /// TODO Check if still in use.
        /// </summary>
        internal bool ShowAxial
        {
            get
            {
                return showAxial;
            }

            set
            {
                showAxial = value;
                FileManager.LocalSettings.Values["ShowAxial"] = showAxial;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show reactions.
        /// </summary>
        internal bool ShowReactions
        {
            get
            {
                return showReactions;
            }

            set
            {
                showReactions = value;
                FileManager.LocalSettings.Values["ShowReactions"] = showReactions;
            }
        }

        /// <summary>
        /// Gets or sets the member display type.
        /// </summary>
        internal int MemberDisplayType
        {
            get
            {
                return memberDisplayType;
            }

            set
            {
                memberDisplayType = value;
                FileManager.LocalSettings.Values["MemberDisplay"] = memberDisplayType;
            }
        }

        /// <summary>
        /// Gets or sets the camera zoom trim.
        /// </summary>
        internal float CameraZoomTrim
        {
            get
            {
                return cameraZoomTrim;
            }

            set
            {
                cameraZoomTrim = value;
                FileManager.LocalSettings.Values["CameraZoomTrim"] = cameraZoomTrim;
            }
        }

        /// <summary>
        /// Gets or sets the moment factor.
        /// </summary>
        internal float MomentFactor
        {
            get
            {
                return momentFactor;
            }

            set
            {
                momentFactor = value;
                FileManager.LocalSettings.Values["MomentFactor"] = (double)momentFactor;
                Camera.UpdateAllGraphics();
            }
        }

        /// <summary>
        /// Gets or sets the shear factor.
        /// </summary>
        internal float ShearFactor
        {
            get
            {
                return shearFactor;
            }

            set
            {
                shearFactor = value;
                FileManager.LocalSettings.Values["ShearFactor"] = (double)shearFactor;
                Camera.UpdateAllGraphics();
            }
        }

        /// <summary>
        /// Gets or sets the linear factor.
        /// </summary>
        internal float LinearFactor
        {
            get
            {
                return linearFactor;
            }

            set
            {
                linearFactor = value;
                FileManager.LocalSettings.Values["LinearFactor"] = (double)linearFactor;
                Camera.UpdateAllGraphics();
            }
        }

        /// <summary>
        /// Gets or sets the force factor.
        /// </summary>
        internal float ForcesFactor
        {
            get
            {
                return forcesFactor;
            }

            set
            {
                forcesFactor = value;
                FileManager.LocalSettings.Values["ForcesFactor"] = (double)forcesFactor;
                Camera.UpdateAllGraphics();
            }
        }

        /// <summary>
        /// Gets or sets the reactions factor.
        /// </summary>
        internal float ReactionsFactor
        {
            get
            {
                return reactionsFactor;
            }

            set
            {
                reactionsFactor = value;
                FileManager.LocalSettings.Values["ReactionsFactor"] = (double)reactionsFactor;
                Camera.UpdateAllGraphics();
            }
        }

        /// <summary>
        /// Gets or sets the displacement factor.
        /// </summary>
        internal float DisplacementFactor
        {
            get
            {
                return displacementFactor;
            }

            set
            {
                displacementFactor = value;
                FileManager.LocalSettings.Values["DisplacementFactor"] = (double)displacementFactor;
                Camera.UpdateAllGraphics();
            }
        }

        internal OptionsDisplay()
        {
            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("ShowMoment"))
                {
                    showMoment = (bool)FileManager.LocalSettings.Values["ShowMoment"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ShowShear"))
                {
                    showShear = (bool)FileManager.LocalSettings.Values["ShowShear"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ShowForce"))
                {
                    showForce = (bool)FileManager.LocalSettings.Values["ShowForce"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ShowLinear"))
                {
                    ShowLinear = (bool)FileManager.LocalSettings.Values["ShowLinear"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ShowAxial"))
                {
                    showAxial = (bool)FileManager.LocalSettings.Values["ShowAxial"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ShowReactions"))
                {
                    showReactions = (bool)FileManager.LocalSettings.Values["ShowReactions"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("MemberDisplayType"))
                {
                    memberDisplayType = (int)FileManager.LocalSettings.Values["MemberDisplayType"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("CameraZoomTrim"))
                {
                    cameraZoomTrim = Convert.ToSingle(FileManager.LocalSettings.Values["CameraZoomTrim"]);
                }

                if (FileManager.LocalSettings.Values.ContainsKey("MomentFactor"))
                {
                    momentFactor = Convert.ToSingle(FileManager.LocalSettings.Values["MomentFactor"]);
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ShearFactor"))
                {
                    shearFactor = Convert.ToSingle(FileManager.LocalSettings.Values["ShearFactor"]);
                }

                if (FileManager.LocalSettings.Values.ContainsKey("LinearFactor"))
                {
                    linearFactor = Convert.ToSingle(FileManager.LocalSettings.Values["LinearFactor"]);
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ForcesFactor"))
                {
                    forcesFactor = Convert.ToSingle(FileManager.LocalSettings.Values["ForcesFactor"]);
                }

                if (FileManager.LocalSettings.Values.ContainsKey("ReactionsFactor"))
                {
                    reactionsFactor = Convert.ToSingle(FileManager.LocalSettings.Values["ReactionsFactor"]);
                }

                if (FileManager.LocalSettings.Values.ContainsKey("DisplacementFactor"))
                {
                    displacementFactor = Convert.ToSingle(FileManager.LocalSettings.Values["DisplacementFactor"]);
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}