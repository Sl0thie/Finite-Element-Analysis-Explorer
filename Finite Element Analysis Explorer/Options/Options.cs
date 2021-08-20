using System;
using System.Diagnostics;
using Microsoft.Graphics.Canvas.Geometry;
using Windows.UI;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Options static class manages the options for the application.
    /// </summary>
    internal static class Options
    {
        /// <summary>
        /// Gets or sets a value indicating whether the application has run before.
        /// </summary>
        internal static bool FirstRun { get; set; } = true;

        #region Camera

        /// <summary>
        /// Gets or sets the camera zoom trim.
        /// </summary>
        internal static float CameraZoomTrim { get; set; } = 500f;

        /// <summary>
        /// Gets or sets the selected grid size.
        /// </summary>
        internal static float SelectGridSize { get; set; } = 1f;

        #endregion

        #region Lines

        /// <summary>
        /// Gets or sets the line grid normal weight.
        /// </summary>
        internal static float LineGridNormalWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line grid normal canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineGridNormal { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line grid minor weight.
        /// </summary>
        internal static float LineGridMinorWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line grid minor canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineGridMinor { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line grid major weight.
        /// </summary>
        internal static float LineGridMajorWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line grid major canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineGridMajor { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line force weight.
        /// </summary>
        internal static float LineForceWeight { get; set; } = 5f;

        /// <summary>
        /// Gets or sets the line force canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line reaction weight.
        /// </summary>
        internal static float LineReactionWeight { get; set; } = 5f;

        /// <summary>
        /// Gets or sets the line reaction canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineReaction { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line selected element weight.
        /// </summary>
        internal static float LineSelectedElementWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line selected element canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineSelectedElement { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line shear force selected weight.
        /// </summary>
        internal static float LineShearForceSelectedWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line shear force selected canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineShearForceSelected { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line moment force selected weight.
        /// </summary>
        internal static float LineMomentForceSelectedWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line moment force selected canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineMomentForceSelected { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line shear force font weight.
        /// </summary>
        internal static float LineShearForceFontWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line shear force font canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineShearForceFont { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line moment force font weight.
        /// </summary>
        internal static float LineMomentForceFontWeight { get; set; } = 2.8f;

        /// <summary>
        /// Gets or sets the line moment force font canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineMomentForceFont { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line shear force weight.
        /// </summary>
        internal static float LineShearForceWeight { get; set; } = 1.5f;

        /// <summary>
        /// Gets or sets the line shear force canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineShearForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line moment force weight.
        /// </summary>
        internal static float LineMomentForceWeight { get; set; } = 1.5f;

        /// <summary>
        /// Gets or sets the line moment force canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineMomentForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line distributed force weight.
        /// </summary>
        internal static float LineDistributedForceWeight { get; set; } = 1.5f;

        /// <summary>
        /// Gets or sets the line distributed force canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineDistributedForce { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line distributed force selected weight.
        /// </summary>
        internal static float LineDistributedForceSelectedWeight { get; set; } = 1.8f;

        /// <summary>
        /// Gets or sets the line distributed force selected canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineDistributedForceSelected { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line node free weight.
        /// </summary>
        internal static float LineNodeFreeWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line node free canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineNodeFree { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line node fixed weight.
        /// </summary>
        internal static float LineNodeFixedWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line node fixed canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineNodeFixed { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line node pin weight.
        /// </summary>
        internal static float LineNodePinWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line node pin canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineNodePin { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line node roller X weight.
        /// </summary>
        internal static float LineNodeRollerXWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line node roller X canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineNodeRollerX { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line node roller Y weight.
        /// </summary>
        internal static float LineNodeRollerYWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line node roller Y canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineNodeRollerY { get; set; } = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line node other weight.
        /// </summary>
        internal static float LineNodeOtherWeight { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the line node other canvas stroke style.
        /// </summary>
        internal static CanvasStrokeStyle LineNodeOther { get; set; } = new CanvasStrokeStyle();

        #endregion

        #region Colors

        /// <summary>
        /// Gets or sets the color to edit.
        /// </summary>
        internal static string ColorToEdit { get; set; }

        /// <summary>
        /// Gets or sets background color.
        /// </summary>
        internal static Color ColorBackground { get; set; } = Color.FromArgb(255, 8, 28, 88);

        /// <summary>
        /// Gets or sets the label color.
        /// </summary>
        internal static Color ColorLabel { get; set; } = Color.FromArgb(255, 255, 255, 255);

        /// <summary>
        /// Gets or sets the force color.
        /// </summary>
        internal static Color ColorForce { get; set; } = Color.FromArgb(255, 255, 255, 0);

        /// <summary>
        /// Gets or sets the reaction color.
        /// </summary>
        internal static Color ColorReaction { get; set; } = Color.FromArgb(255, 255, 0, 0);

        /// <summary>
        /// Gets or sets the normal grid color.
        /// </summary>
        internal static Color ColorGridNormal { get; set; } = Color.FromArgb(192, 48, 48, 96);

        /// <summary>
        /// Gets or sets the minor grid color.
        /// </summary>
        internal static Color ColorGridMinor { get; set; } = Color.FromArgb(192, 48, 48, 48);

        /// <summary>
        /// Gets or sets the major grid color.
        /// </summary>
        internal static Color ColorGridMajor { get; set; } = Color.FromArgb(192, 48, 96, 48);

        /// <summary>
        /// Gets or sets the major grid font.
        /// </summary>
        internal static Color ColorGridMajorFont { get; set; } = Color.FromArgb(255, 48, 48, 156);

        /// <summary>
        /// Gets or sets the selected node color.
        /// </summary>
        internal static Color ColorSelectedNode { get; set; } = Color.FromArgb(255, 64, 64, 255);

        /// <summary>
        /// Gets or sets the selected element color.
        /// </summary>
        internal static Color ColorSelectedElement { get; set; } = Color.FromArgb(255, 255, 0, 255);

        /// <summary>
        /// Gets or sets the selected shear force color.
        /// </summary>
        internal static Color ColorShearForceSelected { get; set; } = Color.FromArgb(255, 64, 64, 255);

        /// <summary>
        /// Gets or sets the selected moment force color.
        /// </summary>
        internal static Color ColorMomentForceSelected { get; set; } = Color.FromArgb(255, 0, 255, 0);

        /// <summary>
        /// Gets or sets the selected distributed force color.
        /// </summary>
        internal static Color ColorDistributedForceSelected { get; set; } = Color.FromArgb(255, 255, 255, 64);

        /// <summary>
        /// Gets or sets the shear force font.
        /// </summary>
        internal static Color ColorShearForceFont { get; set; } = Color.FromArgb(255, 128, 128, 255);

        /// <summary>
        /// Gets or sets the moment force font.
        /// </summary>
        internal static Color ColorMomentForceFont { get; set; } = Color.FromArgb(255, 64, 255, 64);

        /// <summary>
        /// Gets or sets the shear force color.
        /// </summary>
        internal static Color ColorShearForce { get; set; } = Color.FromArgb(128, 0, 0, 255);

        /// <summary>
        /// Gets or sets the moment force color.
        /// </summary>
        internal static Color ColorMomentForce { get; set; } = Color.FromArgb(128, 0, 255, 0);

        /// <summary>
        /// Gets or sets the distributed force color.
        /// </summary>
        internal static Color ColorDistributedForce { get; set; } = Color.FromArgb(128, 255, 255, 0);

        /// <summary>
        /// Gets or sets the free node color.
        /// </summary>
        internal static Color ColorNodeFree { get; set; } = Color.FromArgb(255, 0, 0, 0);

        /// <summary>
        /// Gets or sets the fixed node color.
        /// </summary>
        internal static Color ColorNodeFixed { get; set; } = Color.FromArgb(255, 192, 192, 192);

        /// <summary>
        /// Gets or sets the pin node color.
        /// </summary>
        internal static Color ColorNodePin { get; set; } = Color.FromArgb(255, 192, 192, 192);

        /// <summary>
        /// Gets or sets the node roller X color.
        /// </summary>
        internal static Color ColorNodeRollerX { get; set; } = Color.FromArgb(255, 192, 192, 192);

        /// <summary>
        /// Gets or sets the node roller Y color.
        /// </summary>
        internal static Color ColorNodeRollerY { get; set; } = Color.FromArgb(255, 192, 192, 192);

        /// <summary>
        /// Gets or sets the other node color.
        /// </summary>
        internal static Color ColorNodeOther { get; set; } = Color.FromArgb(255, 0, 0, 0);

        #endregion

        #region General

        private static bool lockNumericalInput = false;

        /// <summary>
        /// Gets or sets a value indicating whether the numerical input is locked.
        /// </summary>
        public static bool LockNumericalInput
        {
            get { return lockNumericalInput; }
            set { lockNumericalInput = value; }
        }

        private static decimal lastNumericalInput = 0;

        /// <summary>
        /// Gets or sets the last numerical input.
        /// </summary>
        public static decimal LastNumericalInput
        {
            get { return lastNumericalInput; }
            set { lastNumericalInput = value; }
        }

        private static bool loadLastFileOnStartup = true;

        /// <summary>
        /// Gets a value indicating whether to load the last opened file on startup.
        /// </summary>
        internal static bool LoadLastFileOnStartup
        {
            get
            {
                return loadLastFileOnStartup;
            }
        }

        private static int defaultNumberOfSegments = 10;

        /// <summary>
        /// Gets or sets the default number of segments for a member.
        /// </summary>
        internal static int DefaultNumberOfSegments
        {
            get
            {
                return defaultNumberOfSegments;
            }

            set
            {
                defaultNumberOfSegments = value;
            }
        }

        private static string lastCurrentSectionName = "Default";

        /// <summary>
        /// Gets the last current section name.
        /// </summary>
        internal static string LastCurrentSectionName
        {
            get
            {
                return lastCurrentSectionName;
            }
        }

        private static bool resetExistingMembers = true;

        /// <summary>
        /// Gets or sets a value indicating whether to reset existing members.
        /// </summary>
        public static bool ResetExistingMembers
        {
            get { return resetExistingMembers; }
            set { resetExistingMembers = value; }
        }

        #endregion

        #region Units

        private static AngleType angle = AngleType.Radians;

        /// <summary>
        /// Gets or sets the angle type.
        /// </summary>
        internal static AngleType Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
            }
        }

        private static MassType mass = MassType.Kilogram;

        /// <summary>
        /// Gets or sets the mass type.
        /// </summary>
        internal static MassType Mass
        {
            get
            {
                return mass;
            }

            set
            {
                mass = value;
            }
        }

        private static LengthType length = LengthType.Meter;

        /// <summary>
        /// Gets or sets the length type.
        /// </summary>
        internal static LengthType Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;

                switch (length)
                {
                    case LengthType.Meter:
                        Camera.LengthUnitFactor = 1;
                        break;
                    case LengthType.CentiMeter:
                        Camera.LengthUnitFactor = (float)Constants.CentiMeterPerMeter;
                        break;
                    case LengthType.Foot:
                        Camera.LengthUnitFactor = (float)Constants.FootPerMeter;
                        break;
                    case LengthType.Inch:
                        Camera.LengthUnitFactor = (float)Constants.InchPerMeter;
                        break;
                    case LengthType.KiloMeter:
                        Camera.LengthUnitFactor = (float)Constants.KiloMeterPerMeter;
                        break;
                    case LengthType.Mil:
                        break;
                    case LengthType.Mile:
                        break;
                    case LengthType.Millimeter:
                        Camera.LengthUnitFactor = (float)Constants.MilliMeterPerMeter;
                        break;
                    case LengthType.Yard:
                        break;
                }
            }
        }

        private static VolumeType volume = VolumeType.CubicMetre;

        /// <summary>
        /// Gets or sets the volume type.
        /// </summary>
        internal static VolumeType Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }

        private static MomentType moment = MomentType.NewtonMetre;

        /// <summary>
        /// Gets or sets the moment type.
        /// </summary>
        internal static MomentType Moment
        {
            get
            {
                return moment;
            }

            set
            {
                moment = value;
            }
        }

        private static PressureType pressure = PressureType.Pascal;

        /// <summary>
        /// Gets or sets the pressure type.
        /// </summary>
        internal static PressureType Pressure
        {
            get
            {
                return pressure;
            }

            set
            {
                pressure = value;
            }
        }

        private static MomentOfInertiaType momentOfInertia = MomentOfInertiaType.QuadMeter;

        /// <summary>
        /// Gets or sets the moment of inertia type.
        /// </summary>
        internal static MomentOfInertiaType MomentOfInertia
        {
            get
            {
                return momentOfInertia;
            }

            set
            {
                momentOfInertia = value;
            }
        }

        private static AreaType area = AreaType.SquareMetre;

        /// <summary>
        /// Gets or sets the area type.
        /// </summary>
        internal static AreaType Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        private static DensityType density = DensityType.KilogramPerCubicMetre;

        /// <summary>
        /// Gets or sets the density type.
        /// </summary>
        internal static DensityType Density
        {
            get
            {
                return density;
            }

            set
            {
                density = value;
            }
        }

        private static ForceType force;

        /// <summary>
        /// Gets or sets the force type.
        /// </summary>
        public static ForceType Force
        {
            get { return force; }
            set { force = value; }
        }

        private static ForcePerLengthType forcePerLength;

        /// <summary>
        /// Gets or sets the force per length type.
        /// </summary>
        public static ForcePerLengthType ForcePerLength
        {
            get { return forcePerLength; }
            set { forcePerLength = value; }
        }

        #endregion

        #region Show

        private static bool showMoment = true;

        /// <summary>
        /// Gets or sets a value indicating whether to display moment.
        /// </summary>
        internal static bool ShowMoment
        {
            get
            {
                return showMoment;
            }

            set
            {
                showMoment = value;
            }
        }

        private static bool showShear = true;

        /// <summary>
        /// Gets or sets a value indicating whether to display shear.
        /// </summary>
        internal static bool ShowShear
        {
            get { return showShear; }
            set { showShear = value; }
        }

        private static bool showForce = true;

        /// <summary>
        /// Gets or sets a value indicating whether to display force.
        /// </summary>
        internal static bool ShowForce
        {
            get
            {
                return showForce;
            }

            set
            {
                showForce = value;
            }
        }

        private static bool showLinear = true;

        /// <summary>
        /// Gets or sets a value indicating whether to display linear force.
        /// </summary>
        internal static bool ShowLinear
        {
            get
            {
                return showLinear;
            }

            set
            {
                showLinear = value;
            }
        }

        private static bool showAxial = true;

        /// <summary>
        /// Sets a value indicating whether to display axial force.
        /// </summary>
        internal static bool ShowAxial
        {
            set
            {
                showAxial = value;
            }
        }

        private static bool showReactions;

        /// <summary>
        /// Gets or sets a value indicating whether to display reaction force.
        /// </summary>
        public static bool ShowReactions
        {
            get { return showReactions; }
            set { showReactions = value; }
        }

        private static int memberDisplay = 0;

        /// <summary>
        /// Gets or sets a value indicating whether to display members.
        /// </summary>
        public static int MemberDisplay
        {
            get { return memberDisplay; }
            set { memberDisplay = value; }
        }

        #endregion

        #region Factors

        private static float momentFactor = 0.0001f;

        /// <summary>
        /// Gets or sets the moment factor.
        /// </summary>
        internal static float MomentFactor
        {
            get
            {
                return momentFactor;
            }

            set
            {
                momentFactor = value;
                Camera.UpdateAllGraphics();
            }
        }

        private static float shearFactor = 0.0001f;

        /// <summary>
        /// Gets or sets the shear factor.
        /// </summary>
        internal static float ShearFactor
        {
            get
            {
                return shearFactor;
            }

            set
            {
                shearFactor = value;
                Camera.UpdateAllGraphics();
            }
        }

        private static float linearFactor = 0.0001f;

        /// <summary>
        /// Gets or sets the linear factor.
        /// </summary>
        internal static float LinearFactor
        {
            get
            {
                return linearFactor;
            }

            set
            {
                linearFactor = value;
                Camera.UpdateAllGraphics();
            }
        }

        private static float forcesFactor = 0.0001f;

        /// <summary>
        /// Gets or sets the force factor.
        /// </summary>
        internal static float ForcesFactor
        {
            get
            {
                return forcesFactor;
            }

            set
            {
                forcesFactor = value;
                Camera.UpdateAllGraphics();
            }
        }

        private static float reactionsFactor = 0.0001f;

        /// <summary>
        /// Gets or sets the reactions factor.
        /// </summary>
        internal static float ReactionsFactor
        {
            get
            {
                return reactionsFactor;
            }

            set
            {
                reactionsFactor = value;
                Camera.UpdateAllGraphics();
            }
        }

        private static float displacementFactor = 1;

        /// <summary>
        /// Gets or sets the displacement factor.
        /// </summary>
        internal static float DisplacementFactor
        {
            get
            {
                return displacementFactor;
            }

            set
            {
                displacementFactor = value;
                Camera.UpdateAllGraphics();
            }
        }

        #endregion

        #region Solver

        private static bool autoStartSolver = true;

        /// <summary>
        /// Gets or sets a value indicating whether to automatically start the solver.
        /// </summary>
        internal static bool AutoStartSolver
        {
            get
            {
                return autoStartSolver;
            }

            set
            {
                autoStartSolver = value;
            }
        }

        private static bool autoFinishSolver = true;

        /// <summary>
        /// Gets or sets a value indicating whether to automatically finish the solver.
        /// </summary>
        internal static bool AutoFinishSolver
        {
            get
            {
                return autoFinishSolver;
            }

            set
            {
                autoFinishSolver = value;
            }
        }

        private static int currentSolver = 0;

        /// <summary>
        /// Gets or sets the current solver.
        /// </summary>
        public static int CurrentSolver
        {
            get { return currentSolver; }
            set { currentSolver = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the options from the Application Data Container named LocalSettings.
        /// </summary>
        internal static void LoadOptions()
        {
            if (FileManager.LocalSettings.Values["FirstRun"] is object)
            {
                FirstRun = (bool)FileManager.LocalSettings.Values["FirstRun"];
            }
            else
            {
                FileManager.LocalSettings.Values["FirstRun"] = (bool)true;
                FirstRun = true;
            }

            if (FirstRun)
            {
                FileManager.LocalSettings.Values["UnitAngle"] = (int)AngleType.Degrees;
                angle = AngleType.Degrees;
                FileManager.LocalSettings.Values["UnitArea"] = (int)AreaType.SquareMetre;
                area = AreaType.SquareMetre;
                FileManager.LocalSettings.Values["UnitDensity"] = (int)DensityType.KilogramPerCubicMetre;
                density = DensityType.KilogramPerCubicMetre;
                FileManager.LocalSettings.Values["UnitForce"] = (int)ForceType.Newton;
                force = ForceType.Newton;
                FileManager.LocalSettings.Values["UnitForcePerLength"] = (int)ForcePerLengthType.NewtonPerMeter;
                forcePerLength = ForcePerLengthType.NewtonPerMeter;
                FileManager.LocalSettings.Values["UnitLength"] = (int)LengthType.Meter;
                Length = LengthType.Meter;
                FileManager.LocalSettings.Values["UnitMass"] = (int)MassType.Kilogram;
                mass = MassType.Kilogram;
                FileManager.LocalSettings.Values["UnitMoment"] = (int)MomentType.NewtonMetre;
                moment = MomentType.NewtonMetre;
                FileManager.LocalSettings.Values["UnitMomentOfInertia"] = (int)MomentOfInertiaType.QuadMeter;
                momentOfInertia = MomentOfInertiaType.QuadMeter;
                FileManager.LocalSettings.Values["UnitPressure"] = (int)PressureType.Pascal;
                pressure = PressureType.Pascal;
                FileManager.LocalSettings.Values["UnitVolume"] = (int)VolumeType.CubicMetre;
                volume = VolumeType.CubicMetre;
                FileManager.LocalSettings.Values["ShowMoment"] = true;
                showMoment = true;
                FileManager.LocalSettings.Values["ShowShear"] = true;
                showShear = true;
                FileManager.LocalSettings.Values["ShowForce"] = true;
                showForce = true;
                FileManager.LocalSettings.Values["ShowLinear"] = true;
                showLinear = true;
                FileManager.LocalSettings.Values["ShowAxial"] = true;
                showAxial = true;
                FileManager.LocalSettings.Values["ShowReactions"] = true;
                showReactions = true;
                FileManager.LocalSettings.Values["MemberDisplay"] = 0;
                memberDisplay = 0;
                FileManager.LocalSettings.Values["AutoStartSolver"] = true;
                autoStartSolver = true;
                FileManager.LocalSettings.Values["AutoFinishSolver"] = true;
                autoFinishSolver = true;
                currentSolver = 0;
                FileManager.LocalSettings.Values["CurrentSolver"] = (int)currentSolver;
                FileManager.LocalSettings.Values["LockNumericalInput"] = false;
                lockNumericalInput = false;
                FileManager.LocalSettings.Values["LoadLastFileOnStartup"] = true;
                loadLastFileOnStartup = true;
                FileManager.LocalSettings.Values["defaultNumberOfSegments"] = (int)defaultNumberOfSegments;
                defaultNumberOfSegments = 10;
                FileManager.LocalSettings.Values["ResetExistingMembers"] = true;
                resetExistingMembers = true;
                FileManager.LocalSettings.Values["lastCurrentSection"] = "Default";
                lastCurrentSectionName = "Default";
                FileManager.LocalSettings.Values["ColorBackgroundA"] = (int)ColorBackground.A;
                FileManager.LocalSettings.Values["ColorBackgroundR"] = (int)ColorBackground.R;
                FileManager.LocalSettings.Values["ColorBackgroundG"] = (int)ColorBackground.G;
                FileManager.LocalSettings.Values["ColorBackgroundB"] = (int)ColorBackground.B;
                FileManager.LocalSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
                FileManager.LocalSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
                FileManager.LocalSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
                FileManager.LocalSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;
                FileManager.LocalSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
                FileManager.LocalSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
                FileManager.LocalSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
                FileManager.LocalSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;
                FileManager.LocalSettings.Values["ColorLabelA"] = (int)ColorLabel.A;
                FileManager.LocalSettings.Values["ColorLabelR"] = (int)ColorLabel.R;
                FileManager.LocalSettings.Values["ColorLabelG"] = (int)ColorLabel.G;
                FileManager.LocalSettings.Values["ColorLabelB"] = (int)ColorLabel.B;
                FileManager.LocalSettings.Values["ColorGridNormalA"] = (int)ColorGridNormal.A;
                FileManager.LocalSettings.Values["ColorGridNormalR"] = (int)ColorGridNormal.R;
                FileManager.LocalSettings.Values["ColorGridNormalG"] = (int)ColorGridNormal.G;
                FileManager.LocalSettings.Values["ColorGridNormalB"] = (int)ColorGridNormal.B;

                LineGridNormal.DashCap = CanvasCapStyle.Round;
                LineGridNormal.DashOffset = 0;
                LineGridNormal.DashStyle = CanvasDashStyle.Solid;
                LineGridNormal.EndCap = CanvasCapStyle.Flat;
                LineGridNormal.LineJoin = CanvasLineJoin.Bevel;
                LineGridNormal.MiterLimit = 0;
                LineGridNormal.StartCap = CanvasCapStyle.Flat;
                LineGridNormalWeight = 1;

                FileManager.LocalSettings.Values["LineGridNormalDashCap"] = (int)LineGridNormal.DashCap;
                FileManager.LocalSettings.Values["LineGridNormalDashOffset"] = (float)LineGridNormal.DashOffset;
                FileManager.LocalSettings.Values["LineGridNormalDashStyle"] = (int)LineGridNormal.DashStyle;
                FileManager.LocalSettings.Values["LineGridNormalEndCap"] = (int)LineGridNormal.EndCap;

                FileManager.LocalSettings.Values["LineGridNormalLineJoin"] = (int)LineGridNormal.LineJoin;
                FileManager.LocalSettings.Values["LineGridNormalMiterLimit"] = (float)LineGridNormal.MiterLimit;
                FileManager.LocalSettings.Values["LineGridNormalStartCap"] = (int)LineGridNormal.StartCap;
                FileManager.LocalSettings.Values["LineGridNormalWeight"] = (float)LineGridNormalWeight;

                FileManager.LocalSettings.Values["ColorGridMinorA"] = (int)ColorGridMinor.A;
                FileManager.LocalSettings.Values["ColorGridMinorR"] = (int)ColorGridMinor.R;
                FileManager.LocalSettings.Values["ColorGridMinorG"] = (int)ColorGridMinor.G;
                FileManager.LocalSettings.Values["ColorGridMinorB"] = (int)ColorGridMinor.B;

                LineGridMinor.DashCap = CanvasCapStyle.Round;
                LineGridMinor.DashOffset = 0;
                LineGridMinor.DashStyle = CanvasDashStyle.Solid;
                LineGridMinor.EndCap = CanvasCapStyle.Flat;
                LineGridMinor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMinor.MiterLimit = 0;
                LineGridMinor.StartCap = CanvasCapStyle.Flat;
                LineGridMinorWeight = 1;

                FileManager.LocalSettings.Values["LineGridMinorDashCap"] = (int)LineGridMinor.DashCap;
                FileManager.LocalSettings.Values["LineGridMinorDashOffset"] = (float)LineGridMinor.DashOffset;
                FileManager.LocalSettings.Values["LineGridMinorDashStyle"] = (int)LineGridMinor.DashStyle;
                FileManager.LocalSettings.Values["LineGridMinorEndCap"] = (int)LineGridMinor.EndCap;

                FileManager.LocalSettings.Values["LineGridMinorLineJoin"] = (int)LineGridMinor.LineJoin;
                FileManager.LocalSettings.Values["LineGridMinorMiterLimit"] = (float)LineGridMinor.MiterLimit;
                FileManager.LocalSettings.Values["LineGridMinorStartCap"] = (int)LineGridMinor.StartCap;
                FileManager.LocalSettings.Values["LineGridMinorWeight"] = (float)LineGridMinorWeight;

                FileManager.LocalSettings.Values["ColorGridMajorA"] = (int)ColorGridMajor.A;
                FileManager.LocalSettings.Values["ColorGridMajorR"] = (int)ColorGridMajor.R;
                FileManager.LocalSettings.Values["ColorGridMajorG"] = (int)ColorGridMajor.G;
                FileManager.LocalSettings.Values["ColorGridMajorB"] = (int)ColorGridMajor.B;

                LineGridMajor.DashCap = CanvasCapStyle.Round;
                LineGridMajor.DashOffset = 0;
                LineGridMajor.DashStyle = CanvasDashStyle.Solid;
                LineGridMajor.EndCap = CanvasCapStyle.Flat;
                LineGridMajor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMajor.MiterLimit = 0;
                LineGridMajor.StartCap = CanvasCapStyle.Flat;
                LineGridMajorWeight = 1;

                FileManager.LocalSettings.Values["LineGridMajorDashCap"] = (int)LineGridMajor.DashCap;
                FileManager.LocalSettings.Values["LineGridMajorDashOffset"] = (float)LineGridMajor.DashOffset;
                FileManager.LocalSettings.Values["LineGridMajorDashStyle"] = (int)LineGridMajor.DashStyle;
                FileManager.LocalSettings.Values["LineGridMajorEndCap"] = (int)LineGridMajor.EndCap;

                FileManager.LocalSettings.Values["LineGridMajorLineJoin"] = (int)LineGridMajor.LineJoin;
                FileManager.LocalSettings.Values["LineGridMajorMiterLimit"] = (float)LineGridMajor.MiterLimit;
                FileManager.LocalSettings.Values["LineGridMajorStartCap"] = (int)LineGridMajor.StartCap;
                FileManager.LocalSettings.Values["LineGridMajorWeight"] = (float)LineGridMajorWeight;

                FileManager.LocalSettings.Values["ColorForceA"] = (int)ColorForce.A;
                FileManager.LocalSettings.Values["ColorForceR"] = (int)ColorForce.R;
                FileManager.LocalSettings.Values["ColorForceG"] = (int)ColorForce.G;
                FileManager.LocalSettings.Values["ColorForceB"] = (int)ColorForce.B;

                LineForce.DashCap = CanvasCapStyle.Round;
                LineForce.DashOffset = 0;
                LineForce.DashStyle = CanvasDashStyle.Solid;
                LineForce.EndCap = CanvasCapStyle.Flat;
                LineForce.LineJoin = CanvasLineJoin.Bevel;
                LineForce.MiterLimit = 0;
                LineForce.StartCap = CanvasCapStyle.Round;
                LineForceWeight = 5f;

                FileManager.LocalSettings.Values["LineForceDashCap"] = (int)LineForce.DashCap;
                FileManager.LocalSettings.Values["LineForceDashOffset"] = (float)LineForce.DashOffset;
                FileManager.LocalSettings.Values["LineForceDashStyle"] = (int)LineForce.DashStyle;
                FileManager.LocalSettings.Values["LineForceEndCap"] = (int)LineForce.EndCap;

                FileManager.LocalSettings.Values["LineForceLineJoin"] = (int)LineForce.LineJoin;
                FileManager.LocalSettings.Values["LineForceMiterLimit"] = (float)LineForce.MiterLimit;
                FileManager.LocalSettings.Values["LineForceStartCap"] = (int)LineForce.StartCap;
                FileManager.LocalSettings.Values["LineForceWeight"] = (float)LineForceWeight;

                FileManager.LocalSettings.Values["ColorReactionA"] = (int)ColorReaction.A;
                FileManager.LocalSettings.Values["ColorReactionR"] = (int)ColorReaction.R;
                FileManager.LocalSettings.Values["ColorReactionG"] = (int)ColorReaction.G;
                FileManager.LocalSettings.Values["ColorReactionB"] = (int)ColorReaction.B;

                LineReaction.DashCap = CanvasCapStyle.Round;
                LineReaction.DashOffset = 0;
                LineReaction.DashStyle = CanvasDashStyle.Solid;
                LineReaction.EndCap = CanvasCapStyle.Flat;
                LineReaction.LineJoin = CanvasLineJoin.Bevel;
                LineReaction.MiterLimit = 0;
                LineReaction.StartCap = CanvasCapStyle.Round;
                LineReactionWeight = 5f;

                FileManager.LocalSettings.Values["LineReactionDashCap"] = (int)LineReaction.DashCap;
                FileManager.LocalSettings.Values["LineReactionDashOffset"] = (float)LineReaction.DashOffset;
                FileManager.LocalSettings.Values["LineReactionDashStyle"] = (int)LineReaction.DashStyle;
                FileManager.LocalSettings.Values["LineReactionEndCap"] = (int)LineReaction.EndCap;

                FileManager.LocalSettings.Values["LineReactionLineJoin"] = (int)LineReaction.LineJoin;
                FileManager.LocalSettings.Values["LineReactionMiterLimit"] = (float)LineReaction.MiterLimit;
                FileManager.LocalSettings.Values["LineReactionStartCap"] = (int)LineReaction.StartCap;
                FileManager.LocalSettings.Values["LineReactionWeight"] = (float)LineReactionWeight;

                FileManager.LocalSettings.Values["ColorSelectedElementA"] = (int)ColorSelectedElement.A;
                FileManager.LocalSettings.Values["ColorSelectedElementR"] = (int)ColorSelectedElement.R;
                FileManager.LocalSettings.Values["ColorSelectedElementG"] = (int)ColorSelectedElement.G;
                FileManager.LocalSettings.Values["ColorSelectedElementB"] = (int)ColorSelectedElement.B;

                LineSelectedElement.DashCap = CanvasCapStyle.Round;
                LineSelectedElement.DashOffset = 0;
                LineSelectedElement.DashStyle = CanvasDashStyle.Solid;
                LineSelectedElement.EndCap = CanvasCapStyle.Flat;
                LineSelectedElement.LineJoin = CanvasLineJoin.Bevel;
                LineSelectedElement.MiterLimit = 0;
                LineSelectedElement.StartCap = CanvasCapStyle.Flat;
                LineSelectedElementWeight = 2.4f;

                FileManager.LocalSettings.Values["LineSelectedElementDashCap"] = (int)LineSelectedElement.DashCap;
                FileManager.LocalSettings.Values["LineSelectedElementDashOffset"] = (float)LineSelectedElement.DashOffset;
                FileManager.LocalSettings.Values["LineSelectedElementDashStyle"] = (int)LineSelectedElement.DashStyle;
                FileManager.LocalSettings.Values["LineSelectedElementEndCap"] = (int)LineSelectedElement.EndCap;

                FileManager.LocalSettings.Values["LineSelectedElementLineJoin"] = (int)LineSelectedElement.LineJoin;
                FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"] = (float)LineSelectedElement.MiterLimit;
                FileManager.LocalSettings.Values["LineSelectedElementStartCap"] = (int)LineSelectedElement.StartCap;
                FileManager.LocalSettings.Values["LineSelectedElementWeight"] = (float)LineSelectedElementWeight;

                FileManager.LocalSettings.Values["ColorShearForceSelectedA"] = (int)ColorShearForceSelected.A;
                FileManager.LocalSettings.Values["ColorShearForceSelectedR"] = (int)ColorShearForceSelected.R;
                FileManager.LocalSettings.Values["ColorShearForceSelectedG"] = (int)ColorShearForceSelected.G;
                FileManager.LocalSettings.Values["ColorShearForceSelectedB"] = (int)ColorShearForceSelected.B;

                LineShearForceSelected.DashCap = CanvasCapStyle.Round;
                LineShearForceSelected.DashOffset = 0;
                LineShearForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineShearForceSelected.EndCap = CanvasCapStyle.Flat;
                LineShearForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceSelected.MiterLimit = 0;
                LineShearForceSelected.StartCap = CanvasCapStyle.Flat;
                LineShearForceSelectedWeight = 2.4f;

                FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"] = (int)LineShearForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"] = (float)LineShearForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"] = (int)LineShearForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"] = (int)LineShearForceSelected.EndCap;

                FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"] = (int)LineShearForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"] = (float)LineShearForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"] = (int)LineShearForceSelected.StartCap;
                FileManager.LocalSettings.Values["LineShearForceSelectedWeight"] = (float)LineShearForceSelectedWeight;

                FileManager.LocalSettings.Values["ColorMomentForceSelectedA"] = (int)ColorMomentForceSelected.A;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedR"] = (int)ColorMomentForceSelected.R;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedG"] = (int)ColorMomentForceSelected.G;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedB"] = (int)ColorMomentForceSelected.B;

                LineMomentForceSelected.DashCap = CanvasCapStyle.Round;
                LineMomentForceSelected.DashOffset = 0;
                LineMomentForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceSelected.EndCap = CanvasCapStyle.Flat;
                LineMomentForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceSelected.MiterLimit = 0;
                LineMomentForceSelected.StartCap = CanvasCapStyle.Flat;
                LineMomentForceSelectedWeight = 2.4f;

                FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"] = (int)LineMomentForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"] = (float)LineMomentForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"] = (int)LineMomentForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"] = (int)LineMomentForceSelected.EndCap;

                FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"] = (int)LineMomentForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)LineMomentForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"] = (int)LineMomentForceSelected.StartCap;
                FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"] = (float)LineMomentForceSelectedWeight;

                FileManager.LocalSettings.Values["ColorShearForceFontA"] = (int)ColorShearForceFont.A;
                FileManager.LocalSettings.Values["ColorShearForceFontR"] = (int)ColorShearForceFont.R;
                FileManager.LocalSettings.Values["ColorShearForceFontG"] = (int)ColorShearForceFont.G;
                FileManager.LocalSettings.Values["ColorShearForceFontB"] = (int)ColorShearForceFont.B;

                LineShearForceFont.DashCap = CanvasCapStyle.Round;
                LineShearForceFont.DashOffset = 0;
                LineShearForceFont.DashStyle = CanvasDashStyle.Solid;
                LineShearForceFont.EndCap = CanvasCapStyle.Flat;
                LineShearForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceFont.MiterLimit = 0;
                LineShearForceFont.StartCap = CanvasCapStyle.Flat;
                LineShearForceFontWeight = 2.4f;

                FileManager.LocalSettings.Values["LineShearForceFontDashCap"] = (int)LineShearForceFont.DashCap;
                FileManager.LocalSettings.Values["LineShearForceFontDashOffset"] = (float)LineShearForceFont.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceFontDashStyle"] = (int)LineShearForceFont.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceFontEndCap"] = (int)LineShearForceFont.EndCap;

                FileManager.LocalSettings.Values["LineShearForceFontLineJoin"] = (int)LineShearForceFont.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"] = (float)LineShearForceFont.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceFontStartCap"] = (int)LineShearForceFont.StartCap;
                FileManager.LocalSettings.Values["LineShearForceFontWeight"] = (float)LineShearForceFontWeight;

                FileManager.LocalSettings.Values["ColorMomentForceFontA"] = (int)ColorMomentForceFont.A;
                FileManager.LocalSettings.Values["ColorMomentForceFontR"] = (int)ColorMomentForceFont.R;
                FileManager.LocalSettings.Values["ColorMomentForceFontG"] = (int)ColorMomentForceFont.G;
                FileManager.LocalSettings.Values["ColorMomentForceFontB"] = (int)ColorMomentForceFont.B;

                LineMomentForceFont.DashCap = CanvasCapStyle.Round;
                LineMomentForceFont.DashOffset = 0;
                LineMomentForceFont.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceFont.EndCap = CanvasCapStyle.Flat;
                LineMomentForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceFont.MiterLimit = 0;
                LineMomentForceFont.StartCap = CanvasCapStyle.Flat;
                LineMomentForceFontWeight = 2.4f;

                FileManager.LocalSettings.Values["LineMomentForceFontDashCap"] = (int)LineMomentForceFont.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"] = (float)LineMomentForceFont.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"] = (int)LineMomentForceFont.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceFontEndCap"] = (int)LineMomentForceFont.EndCap;

                FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"] = (int)LineMomentForceFont.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"] = (float)LineMomentForceFont.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceFontStartCap"] = (int)LineMomentForceFont.StartCap;
                FileManager.LocalSettings.Values["LineMomentForceFontWeight"] = (float)LineMomentForceFontWeight;

                FileManager.LocalSettings.Values["ColorShearForceA"] = (int)ColorShearForce.A;
                FileManager.LocalSettings.Values["ColorShearForceR"] = (int)ColorShearForce.R;
                FileManager.LocalSettings.Values["ColorShearForceG"] = (int)ColorShearForce.G;
                FileManager.LocalSettings.Values["ColorShearForceB"] = (int)ColorShearForce.B;

                LineShearForce.DashCap = CanvasCapStyle.Round;
                LineShearForce.DashOffset = 0;
                LineShearForce.DashStyle = CanvasDashStyle.Solid;
                LineShearForce.EndCap = CanvasCapStyle.Flat;
                LineShearForce.LineJoin = CanvasLineJoin.Bevel;
                LineShearForce.MiterLimit = 0;
                LineShearForce.StartCap = CanvasCapStyle.Flat;
                LineShearForceWeight = 1.5f;

                FileManager.LocalSettings.Values["LineShearForceDashCap"] = (int)LineShearForce.DashCap;
                FileManager.LocalSettings.Values["LineShearForceDashOffset"] = (float)LineShearForce.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceDashStyle"] = (int)LineShearForce.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceEndCap"] = (int)LineShearForce.EndCap;

                FileManager.LocalSettings.Values["LineShearForceLineJoin"] = (int)LineShearForce.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceMiterLimit"] = (float)LineShearForce.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceStartCap"] = (int)LineShearForce.StartCap;
                FileManager.LocalSettings.Values["LineShearForceWeight"] = (float)LineShearForceWeight;

                FileManager.LocalSettings.Values["ColorMomentForceA"] = (int)ColorMomentForce.A;
                FileManager.LocalSettings.Values["ColorMomentForceR"] = (int)ColorMomentForce.R;
                FileManager.LocalSettings.Values["ColorMomentForceG"] = (int)ColorMomentForce.G;
                FileManager.LocalSettings.Values["ColorMomentForceB"] = (int)ColorMomentForce.B;

                LineMomentForce.DashCap = CanvasCapStyle.Round;
                LineMomentForce.DashOffset = 0;
                LineMomentForce.DashStyle = CanvasDashStyle.Solid;
                LineMomentForce.EndCap = CanvasCapStyle.Flat;
                LineMomentForce.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForce.MiterLimit = 0;
                LineMomentForce.StartCap = CanvasCapStyle.Flat;
                LineMomentForceWeight = 1.5f;

                FileManager.LocalSettings.Values["LineMomentForceDashCap"] = (int)LineMomentForce.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceDashOffset"] = (float)LineMomentForce.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceDashStyle"] = (int)LineMomentForce.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceEndCap"] = (int)LineMomentForce.EndCap;

                FileManager.LocalSettings.Values["LineMomentForceLineJoin"] = (int)LineMomentForce.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceMiterLimit"] = (float)LineMomentForce.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceStartCap"] = (int)LineMomentForce.StartCap;
                FileManager.LocalSettings.Values["LineMomentForceWeight"] = (float)LineMomentForceWeight;

                FileManager.LocalSettings.Values["ColorDistributedForceA"] = (int)ColorDistributedForce.A;
                FileManager.LocalSettings.Values["ColorDistributedForceR"] = (int)ColorDistributedForce.R;
                FileManager.LocalSettings.Values["ColorDistributedForceG"] = (int)ColorDistributedForce.G;
                FileManager.LocalSettings.Values["ColorDistributedForceB"] = (int)ColorDistributedForce.B;

                LineDistributedForce.DashCap = CanvasCapStyle.Round;
                LineDistributedForce.DashOffset = 0;
                LineDistributedForce.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForce.EndCap = CanvasCapStyle.Flat;
                LineDistributedForce.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForce.MiterLimit = 0;
                LineDistributedForce.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceWeight = 1.5f;

                FileManager.LocalSettings.Values["LineDistributedForceDashCap"] = (int)LineDistributedForce.DashCap;
                FileManager.LocalSettings.Values["LineDistributedForceDashOffset"] = (float)LineDistributedForce.DashOffset;
                FileManager.LocalSettings.Values["LineDistributedForceDashStyle"] = (int)LineDistributedForce.DashStyle;
                FileManager.LocalSettings.Values["LineDistributedForceEndCap"] = (int)LineDistributedForce.EndCap;

                FileManager.LocalSettings.Values["LineDistributedForceLineJoin"] = (int)LineDistributedForce.LineJoin;
                FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"] = (float)LineDistributedForce.MiterLimit;
                FileManager.LocalSettings.Values["LineDistributedForceStartCap"] = (int)LineDistributedForce.StartCap;
                FileManager.LocalSettings.Values["LineDistributedForceWeight"] = (float)LineDistributedForceWeight;

                FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"] = (int)ColorDistributedForceSelected.A;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"] = (int)ColorDistributedForceSelected.R;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"] = (int)ColorDistributedForceSelected.G;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"] = (int)ColorDistributedForceSelected.B;

                LineDistributedForceSelected.DashCap = CanvasCapStyle.Round;
                LineDistributedForceSelected.DashOffset = 0;
                LineDistributedForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForceSelected.EndCap = CanvasCapStyle.Flat;
                LineDistributedForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForceSelected.MiterLimit = 0;
                LineDistributedForceSelected.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceSelectedWeight = 1.5f;

                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"] = (int)LineDistributedForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)LineDistributedForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)LineDistributedForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"] = (int)LineDistributedForceSelected.EndCap;

                FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)LineDistributedForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)LineDistributedForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"] = (int)LineDistributedForceSelected.StartCap;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"] = (float)LineDistributedForceSelectedWeight;

                FileManager.LocalSettings.Values["ColorNodeFreeA"] = (int)ColorNodeFree.A;
                FileManager.LocalSettings.Values["ColorNodeFreeR"] = (int)ColorNodeFree.R;
                FileManager.LocalSettings.Values["ColorNodeFreeG"] = (int)ColorNodeFree.G;
                FileManager.LocalSettings.Values["ColorNodeFreeB"] = (int)ColorNodeFree.B;

                LineNodeFree.DashCap = CanvasCapStyle.Round;
                LineNodeFree.DashOffset = 0;
                LineNodeFree.DashStyle = CanvasDashStyle.Solid;
                LineNodeFree.EndCap = CanvasCapStyle.Flat;
                LineNodeFree.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFree.MiterLimit = 0;
                LineNodeFree.StartCap = CanvasCapStyle.Flat;
                LineNodeFreeWeight = 1;

                FileManager.LocalSettings.Values["LineNodeFreeDashCap"] = (int)LineNodeFree.DashCap;
                FileManager.LocalSettings.Values["LineNodeFreeDashOffset"] = (float)LineNodeFree.DashOffset;
                FileManager.LocalSettings.Values["LineNodeFreeDashStyle"] = (int)LineNodeFree.DashStyle;
                FileManager.LocalSettings.Values["LineNodeFreeEndCap"] = (int)LineNodeFree.EndCap;

                FileManager.LocalSettings.Values["LineNodeFreeLineJoin"] = (int)LineNodeFree.LineJoin;
                FileManager.LocalSettings.Values["LineNodeFreeMiterLimit"] = (float)LineNodeFree.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeFreeStartCap"] = (int)LineNodeFree.StartCap;
                FileManager.LocalSettings.Values["LineNodeFreeWeight"] = (float)LineNodeFreeWeight;

                FileManager.LocalSettings.Values["ColorNodeFixedA"] = (int)ColorNodeFixed.A;
                FileManager.LocalSettings.Values["ColorNodeFixedR"] = (int)ColorNodeFixed.R;
                FileManager.LocalSettings.Values["ColorNodeFixedG"] = (int)ColorNodeFixed.G;
                FileManager.LocalSettings.Values["ColorNodeFixedB"] = (int)ColorNodeFixed.B;

                LineNodeFixed.DashCap = CanvasCapStyle.Round;
                LineNodeFixed.DashOffset = 0;
                LineNodeFixed.DashStyle = CanvasDashStyle.Solid;
                LineNodeFixed.EndCap = CanvasCapStyle.Flat;
                LineNodeFixed.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFixed.MiterLimit = 0;
                LineNodeFixed.StartCap = CanvasCapStyle.Flat;
                LineNodeFixedWeight = 1;

                FileManager.LocalSettings.Values["LineNodeFixedDashCap"] = (int)LineNodeFixed.DashCap;
                FileManager.LocalSettings.Values["LineNodeFixedDashOffset"] = (float)LineNodeFixed.DashOffset;
                FileManager.LocalSettings.Values["LineNodeFixedDashStyle"] = (int)LineNodeFixed.DashStyle;
                FileManager.LocalSettings.Values["LineNodeFixedEndCap"] = (int)LineNodeFixed.EndCap;

                FileManager.LocalSettings.Values["LineNodeFixedLineJoin"] = (int)LineNodeFixed.LineJoin;
                FileManager.LocalSettings.Values["LineNodeFixedMiterLimit"] = (float)LineNodeFixed.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeFixedStartCap"] = (int)LineNodeFixed.StartCap;
                FileManager.LocalSettings.Values["LineNodeFixedWeight"] = (float)LineNodeFixedWeight;

                FileManager.LocalSettings.Values["ColorNodePinA"] = (int)ColorNodePin.A;
                FileManager.LocalSettings.Values["ColorNodePinR"] = (int)ColorNodePin.R;
                FileManager.LocalSettings.Values["ColorNodePinG"] = (int)ColorNodePin.G;
                FileManager.LocalSettings.Values["ColorNodePinB"] = (int)ColorNodePin.B;

                LineNodePin.DashCap = CanvasCapStyle.Round;
                LineNodePin.DashOffset = 0;
                LineNodePin.DashStyle = CanvasDashStyle.Solid;
                LineNodePin.EndCap = CanvasCapStyle.Flat;
                LineNodePin.LineJoin = CanvasLineJoin.Bevel;
                LineNodePin.MiterLimit = 0;
                LineNodePin.StartCap = CanvasCapStyle.Flat;
                LineNodePinWeight = 1;

                FileManager.LocalSettings.Values["LineNodePinDashCap"] = (int)LineNodePin.DashCap;
                FileManager.LocalSettings.Values["LineNodePinDashOffset"] = (float)LineNodePin.DashOffset;
                FileManager.LocalSettings.Values["LineNodePinDashStyle"] = (int)LineNodePin.DashStyle;
                FileManager.LocalSettings.Values["LineNodePinEndCap"] = (int)LineNodePin.EndCap;

                FileManager.LocalSettings.Values["LineNodePinLineJoin"] = (int)LineNodePin.LineJoin;
                FileManager.LocalSettings.Values["LineNodePinMiterLimit"] = (float)LineNodePin.MiterLimit;
                FileManager.LocalSettings.Values["LineNodePinStartCap"] = (int)LineNodePin.StartCap;
                FileManager.LocalSettings.Values["LineNodePinWeight"] = (float)LineNodePinWeight;

                FileManager.LocalSettings.Values["ColorNodeRollerXA"] = (int)ColorNodeRollerX.A;
                FileManager.LocalSettings.Values["ColorNodeRollerXR"] = (int)ColorNodeRollerX.R;
                FileManager.LocalSettings.Values["ColorNodeRollerXG"] = (int)ColorNodeRollerX.G;
                FileManager.LocalSettings.Values["ColorNodeRollerXB"] = (int)ColorNodeRollerX.B;

                LineNodeRollerX.DashCap = CanvasCapStyle.Round;
                LineNodeRollerX.DashOffset = 0;
                LineNodeRollerX.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerX.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerX.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerX.MiterLimit = 0;
                LineNodeRollerX.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerXWeight = 1;

                FileManager.LocalSettings.Values["LineNodeRollerXDashCap"] = (int)LineNodeRollerX.DashCap;
                FileManager.LocalSettings.Values["LineNodeRollerXDashOffset"] = (float)LineNodeRollerX.DashOffset;
                FileManager.LocalSettings.Values["LineNodeRollerXDashStyle"] = (int)LineNodeRollerX.DashStyle;
                FileManager.LocalSettings.Values["LineNodeRollerXEndCap"] = (int)LineNodeRollerX.EndCap;

                FileManager.LocalSettings.Values["LineNodeRollerXLineJoin"] = (int)LineNodeRollerX.LineJoin;
                FileManager.LocalSettings.Values["LineNodeRollerXMiterLimit"] = (float)LineNodeRollerX.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeRollerXStartCap"] = (int)LineNodeRollerX.StartCap;
                FileManager.LocalSettings.Values["LineNodeRollerXWeight"] = (float)LineNodeRollerXWeight;

                FileManager.LocalSettings.Values["ColorNodeRollerYA"] = (int)ColorNodeRollerY.A;
                FileManager.LocalSettings.Values["ColorNodeRollerYR"] = (int)ColorNodeRollerY.R;
                FileManager.LocalSettings.Values["ColorNodeRollerYG"] = (int)ColorNodeRollerY.G;
                FileManager.LocalSettings.Values["ColorNodeRollerYB"] = (int)ColorNodeRollerY.B;

                LineNodeRollerY.DashCap = CanvasCapStyle.Round;
                LineNodeRollerY.DashOffset = 0;
                LineNodeRollerY.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerY.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerY.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerY.MiterLimit = 0;
                LineNodeRollerY.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerYWeight = 1;

                FileManager.LocalSettings.Values["LineNodeRollerYDashCap"] = (int)LineNodeRollerY.DashCap;
                FileManager.LocalSettings.Values["LineNodeRollerYDashOffset"] = (float)LineNodeRollerY.DashOffset;
                FileManager.LocalSettings.Values["LineNodeRollerYDashStyle"] = (int)LineNodeRollerY.DashStyle;
                FileManager.LocalSettings.Values["LineNodeRollerYEndCap"] = (int)LineNodeRollerY.EndCap;

                FileManager.LocalSettings.Values["LineNodeRollerYLineJoin"] = (int)LineNodeRollerY.LineJoin;
                FileManager.LocalSettings.Values["LineNodeRollerYMiterLimit"] = (float)LineNodeRollerY.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeRollerYStartCap"] = (int)LineNodeRollerY.StartCap;
                FileManager.LocalSettings.Values["LineNodeRollerYWeight"] = (float)LineNodeRollerYWeight;

                FileManager.LocalSettings.Values["ColorNodeOtherA"] = (int)ColorNodeOther.A;
                FileManager.LocalSettings.Values["ColorNodeOtherR"] = (int)ColorNodeOther.R;
                FileManager.LocalSettings.Values["ColorNodeOtherG"] = (int)ColorNodeOther.G;
                FileManager.LocalSettings.Values["ColorNodeOtherB"] = (int)ColorNodeOther.B;

                LineNodeOther.DashCap = CanvasCapStyle.Round;
                LineNodeOther.DashOffset = 0;
                LineNodeOther.DashStyle = CanvasDashStyle.Solid;
                LineNodeOther.EndCap = CanvasCapStyle.Flat;
                LineNodeOther.LineJoin = CanvasLineJoin.Bevel;
                LineNodeOther.MiterLimit = 0;
                LineNodeOther.StartCap = CanvasCapStyle.Flat;
                LineNodeOtherWeight = 1;

                FileManager.LocalSettings.Values["LineNodeOtherDashCap"] = (int)LineNodeOther.DashCap;
                FileManager.LocalSettings.Values["LineNodeOtherDashOffset"] = (float)LineNodeOther.DashOffset;
                FileManager.LocalSettings.Values["LineNodeOtherDashStyle"] = (int)LineNodeOther.DashStyle;
                FileManager.LocalSettings.Values["LineNodeOtherEndCap"] = (int)LineNodeOther.EndCap;

                FileManager.LocalSettings.Values["LineNodeOtherLineJoin"] = (int)LineNodeOther.LineJoin;
                FileManager.LocalSettings.Values["LineNodeOtherMiterLimit"] = (float)LineNodeOther.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeOtherStartCap"] = (int)LineNodeOther.StartCap;
                FileManager.LocalSettings.Values["LineNodeOtherWeight"] = (float)LineNodeOtherWeight;

                FileManager.LocalSettings.Values["MomentFactor"] = 0.0001f;
                momentFactor = 0.0001f;
                FileManager.LocalSettings.Values["ShearFactor"] = 0.0001f;
                shearFactor = 0.0001f;
                FileManager.LocalSettings.Values["LinearFactor"] = 0.0001f;
                linearFactor = 0.0001f;
                FileManager.LocalSettings.Values["ForcesFactor"] = 0.0001f;
                forcesFactor = 0.0001f;
                FileManager.LocalSettings.Values["ReactionsFactor"] = 0.0001f;
                reactionsFactor = 0.0001f;
                FileManager.LocalSettings.Values["DisplacementFactor"] = 1f;
                displacementFactor = 1f;
                FileManager.LocalSettings.Values["CameraZoomTrim"] = 500f;
                CameraZoomTrim = 500f;
                FileManager.LocalSettings.Values["SelectGridSize"] = 1f;
                SelectGridSize = 1f;
            }

            if (FileManager.LocalSettings.Values["UnitAngle"] is object)
            {
                angle = (AngleType)FileManager.LocalSettings.Values["UnitAngle"];
            }
            else
            {
                FileManager.LocalSettings.Values["UnitAngle"] = (int)AngleType.Degrees;
                angle = AngleType.Degrees;
            }

            if (FileManager.LocalSettings.Values["UnitArea"] is object)
            {
                area = (AreaType)FileManager.LocalSettings.Values["UnitArea"];
            }
            else
            {
                FileManager.LocalSettings.Values["UnitArea"] = (int)AreaType.SquareMetre;
                area = AreaType.SquareMetre;
            }

            if (FileManager.LocalSettings.Values["UnitDensity"] is object)
            {
                density = (DensityType)FileManager.LocalSettings.Values["UnitDensity"];
            }
            else
            {
                FileManager.LocalSettings.Values["UnitDensity"] = (int)DensityType.KilogramPerCubicMetre;
                density = DensityType.KilogramPerCubicMetre;
            }

            try
            {
                force = (ForceType)FileManager.LocalSettings.Values["UnitForce"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitForce"] = (int)ForceType.Newton;
                force = ForceType.Newton;
                WService.ReportException(ex);
            }

            try
            {
                forcePerLength = (ForcePerLengthType)FileManager.LocalSettings.Values["UnitForcePerLength"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitForcePerLength"] = (int)ForcePerLengthType.NewtonPerMeter;
                forcePerLength = ForcePerLengthType.NewtonPerMeter;
                WService.ReportException(ex);
            }

            try
            {
                Length = (LengthType)FileManager.LocalSettings.Values["UnitLength"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitLength"] = (int)LengthType.Meter;
                Length = LengthType.Meter;
                WService.ReportException(ex);
            }

            try
            {
                mass = (MassType)FileManager.LocalSettings.Values["UnitMass"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitMass"] = (int)MassType.Kilogram;
                mass = MassType.Kilogram;
                WService.ReportException(ex);
            }

            try
            {
                moment = (MomentType)FileManager.LocalSettings.Values["UnitMoment"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitMoment"] = (int)MomentType.NewtonMetre;
                moment = MomentType.NewtonMetre;
                WService.ReportException(ex);
            }

            try
            {
                momentOfInertia = (MomentOfInertiaType)FileManager.LocalSettings.Values["UnitMomentOfInertia"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitMomentOfInertia"] = (int)MomentOfInertiaType.QuadMeter;
                momentOfInertia = MomentOfInertiaType.QuadMeter;
                WService.ReportException(ex);
            }

            try
            {
                pressure = (PressureType)FileManager.LocalSettings.Values["UnitPressure"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitPressure"] = (int)PressureType.Pascal;
                pressure = PressureType.Pascal;
                WService.ReportException(ex);
            }

            try
            {
                volume = (VolumeType)FileManager.LocalSettings.Values["UnitVolume"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["UnitVolume"] = (int)VolumeType.CubicMetre;
                volume = VolumeType.CubicMetre;
                WService.ReportException(ex);
            }

            try
            {
                showMoment = (bool)FileManager.LocalSettings.Values["ShowMoment"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ShowMoment"] = true;
                showMoment = true;
                WService.ReportException(ex);
            }

            try
            {
                showShear = (bool)FileManager.LocalSettings.Values["ShowShear"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ShowShear"] = true;
                showShear = true;
                WService.ReportException(ex);
            }

            try
            {
                showForce = (bool)FileManager.LocalSettings.Values["ShowForce"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ShowForce"] = true;
                showForce = true;
                WService.ReportException(ex);
            }

            try
            {
                showLinear = (bool)FileManager.LocalSettings.Values["ShowLinear"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ShowLinear"] = true;
                showLinear = true;
                WService.ReportException(ex);
            }

            try
            {
                showAxial = (bool)FileManager.LocalSettings.Values["ShowAxial"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ShowAxial"] = true;
                showAxial = true;
                WService.ReportException(ex);
            }

            try
            {
                showReactions = (bool)FileManager.LocalSettings.Values["ShowReactions"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ShowReactions"] = true;
                showReactions = true;
                WService.ReportException(ex);
            }

            try
            {
                memberDisplay = (int)FileManager.LocalSettings.Values["MemberDisplay"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["MemberDisplay"] = 0;
                memberDisplay = 0;
                WService.ReportException(ex);
            }

            try
            {
                autoStartSolver = (bool)FileManager.LocalSettings.Values["AutoStartSolver"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["AutoStartSolver"] = true;
                autoStartSolver = true;
                WService.ReportException(ex);
            }

            try
            {
                autoFinishSolver = (bool)FileManager.LocalSettings.Values["AutoFinishSolver"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["AutoFinishSolver"] = true;
                autoFinishSolver = true;
                WService.ReportException(ex);
            }

            try
            {
                currentSolver = (int)FileManager.LocalSettings.Values["CurrentSolver"];
            }
            catch (Exception ex)
            {
                currentSolver = 0;
                FileManager.LocalSettings.Values["CurrentSolver"] = (int)currentSolver;
                WService.ReportException(ex);
            }

            try
            {
                lockNumericalInput = (bool)FileManager.LocalSettings.Values["LockNumericalInput"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["LockNumericalInput"] = false;
                lockNumericalInput = false;
                WService.ReportException(ex);
            }

            try
            {
                loadLastFileOnStartup = (bool)FileManager.LocalSettings.Values["LoadLastFileOnStartup"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["LoadLastFileOnStartup"] = true;
                loadLastFileOnStartup = true;
                WService.ReportException(ex);
            }

            try
            {
                defaultNumberOfSegments = (int)FileManager.LocalSettings.Values["defaultNumberOfSegments"];
                if (defaultNumberOfSegments < 1)
                {
                    defaultNumberOfSegments = 1;
                }
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["defaultNumberOfSegments"] = (int)defaultNumberOfSegments;
                defaultNumberOfSegments = 10;
                WService.ReportException(ex);
            }

            try
            {
                resetExistingMembers = (bool)FileManager.LocalSettings.Values["ResetExistingMembers"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ResetExistingMembers"] = true;
                resetExistingMembers = true;
                WService.ReportException(ex);
            }

            try
            {
                lastCurrentSectionName = (string)FileManager.LocalSettings.Values["lastCurrentSection"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["lastCurrentSection"] = "Default";
                lastCurrentSectionName = "Default";
                WService.ReportException(ex);
            }

            if (lastCurrentSectionName is null)
            {
                lastCurrentSectionName = "Default";
            }

            if (string.IsNullOrEmpty(lastCurrentSectionName.Trim()))
            {
                lastCurrentSectionName = "Default";
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorBackgroundA"];
                int r = (int)FileManager.LocalSettings.Values["ColorBackgroundR"];
                int g = (int)FileManager.LocalSettings.Values["ColorBackgroundG"];
                int b = (int)FileManager.LocalSettings.Values["ColorBackgroundB"];

                ColorBackground = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ColorBackgroundA"] = (int)ColorBackground.A;
                FileManager.LocalSettings.Values["ColorBackgroundR"] = (int)ColorBackground.R;
                FileManager.LocalSettings.Values["ColorBackgroundG"] = (int)ColorBackground.G;
                FileManager.LocalSettings.Values["ColorBackgroundB"] = (int)ColorBackground.B;
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridMajorFontA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridMajorFontR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridMajorFontG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridMajorFontB"];

                ColorGridMajorFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
                FileManager.LocalSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
                FileManager.LocalSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
                FileManager.LocalSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorLabelA"];
                int r = (int)FileManager.LocalSettings.Values["ColorLabelR"];
                int g = (int)FileManager.LocalSettings.Values["ColorLabelG"];
                int b = (int)FileManager.LocalSettings.Values["ColorLabelB"];

                ColorLabel = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ColorLabelA"] = (int)ColorLabel.A;
                FileManager.LocalSettings.Values["ColorLabelR"] = (int)ColorLabel.R;
                FileManager.LocalSettings.Values["ColorLabelG"] = (int)ColorLabel.G;
                FileManager.LocalSettings.Values["ColorLabelB"] = (int)ColorLabel.B;
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridNormalA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridNormalR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridNormalG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridNormalB"];

                ColorGridNormal = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineGridNormal.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalDashCap"];
                LineGridNormal.DashOffset = (float)FileManager.LocalSettings.Values["LineGridNormalDashOffset"];
                LineGridNormal.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridNormalDashStyle"];
                LineGridNormal.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalEndCap"];
                LineGridNormal.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridNormalLineJoin"];
                LineGridNormal.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridNormalMiterLimit"];
                LineGridNormal.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalStartCap"];
                LineGridNormalWeight = (float)FileManager.LocalSettings.Values["LineGridNormalWeight"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ColorGridNormalA"] = (int)ColorGridNormal.A;
                FileManager.LocalSettings.Values["ColorGridNormalR"] = (int)ColorGridNormal.R;
                FileManager.LocalSettings.Values["ColorGridNormalG"] = (int)ColorGridNormal.G;
                FileManager.LocalSettings.Values["ColorGridNormalB"] = (int)ColorGridNormal.B;

                LineGridNormal.DashCap = CanvasCapStyle.Round;
                LineGridNormal.DashOffset = 0;
                LineGridNormal.DashStyle = CanvasDashStyle.Solid;
                LineGridNormal.EndCap = CanvasCapStyle.Flat;
                LineGridNormal.LineJoin = CanvasLineJoin.Bevel;
                LineGridNormal.MiterLimit = 0;
                LineGridNormal.StartCap = CanvasCapStyle.Flat;
                LineGridNormalWeight = 1;

                FileManager.LocalSettings.Values["LineGridNormalDashCap"] = (int)LineGridNormal.DashCap;
                FileManager.LocalSettings.Values["LineGridNormalDashOffset"] = (float)LineGridNormal.DashOffset;
                FileManager.LocalSettings.Values["LineGridNormalDashStyle"] = (int)LineGridNormal.DashStyle;
                FileManager.LocalSettings.Values["LineGridNormalEndCap"] = (int)LineGridNormal.EndCap;

                FileManager.LocalSettings.Values["LineGridNormalLineJoin"] = (int)LineGridNormal.LineJoin;
                FileManager.LocalSettings.Values["LineGridNormalMiterLimit"] = (float)LineGridNormal.MiterLimit;
                FileManager.LocalSettings.Values["LineGridNormalStartCap"] = (int)LineGridNormal.StartCap;
                FileManager.LocalSettings.Values["LineGridNormalWeight"] = (float)LineGridNormalWeight;
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridMinorA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridMinorR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridMinorG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridMinorB"];

                ColorGridMinor = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineGridMinor.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorDashCap"];
                LineGridMinor.DashOffset = (float)FileManager.LocalSettings.Values["LineGridMinorDashOffset"];
                LineGridMinor.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridMinorDashStyle"];
                LineGridMinor.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorEndCap"];
                LineGridMinor.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridMinorLineJoin"];
                LineGridMinor.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridMinorMiterLimit"];
                LineGridMinor.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMinorStartCap"];
                LineGridMinorWeight = (float)FileManager.LocalSettings.Values["LineGridMinorWeight"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ColorGridMinorA"] = (int)ColorGridMinor.A;
                FileManager.LocalSettings.Values["ColorGridMinorR"] = (int)ColorGridMinor.R;
                FileManager.LocalSettings.Values["ColorGridMinorG"] = (int)ColorGridMinor.G;
                FileManager.LocalSettings.Values["ColorGridMinorB"] = (int)ColorGridMinor.B;

                LineGridMinor.DashCap = CanvasCapStyle.Round;
                LineGridMinor.DashOffset = 0;
                LineGridMinor.DashStyle = CanvasDashStyle.Solid;
                LineGridMinor.EndCap = CanvasCapStyle.Flat;
                LineGridMinor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMinor.MiterLimit = 0;
                LineGridMinor.StartCap = CanvasCapStyle.Flat;
                LineGridMinorWeight = 1;

                FileManager.LocalSettings.Values["LineGridMinorDashCap"] = (int)LineGridMinor.DashCap;
                FileManager.LocalSettings.Values["LineGridMinorDashOffset"] = (float)LineGridMinor.DashOffset;
                FileManager.LocalSettings.Values["LineGridMinorDashStyle"] = (int)LineGridMinor.DashStyle;
                FileManager.LocalSettings.Values["LineGridMinorEndCap"] = (int)LineGridMinor.EndCap;

                FileManager.LocalSettings.Values["LineGridMinorLineJoin"] = (int)LineGridMinor.LineJoin;
                FileManager.LocalSettings.Values["LineGridMinorMiterLimit"] = (float)LineGridMinor.MiterLimit;
                FileManager.LocalSettings.Values["LineGridMinorStartCap"] = (int)LineGridMinor.StartCap;
                FileManager.LocalSettings.Values["LineGridMinorWeight"] = (float)LineGridMinorWeight;
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorGridMajorA"];
                int r = (int)FileManager.LocalSettings.Values["ColorGridMajorR"];
                int g = (int)FileManager.LocalSettings.Values["ColorGridMajorG"];
                int b = (int)FileManager.LocalSettings.Values["ColorGridMajorB"];

                ColorGridMajor = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineGridMajor.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorDashCap"];
                LineGridMajor.DashOffset = (float)FileManager.LocalSettings.Values["LineGridMajorDashOffset"];
                LineGridMajor.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineGridMajorDashStyle"];
                LineGridMajor.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorEndCap"];
                LineGridMajor.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineGridMajorLineJoin"];
                LineGridMajor.MiterLimit = (float)FileManager.LocalSettings.Values["LineGridMajorMiterLimit"];
                LineGridMajor.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridMajorStartCap"];
                LineGridMajorWeight = (float)FileManager.LocalSettings.Values["LineGridMajorWeight"];
            }
            catch (Exception ex)
            {
                FileManager.LocalSettings.Values["ColorGridMajorA"] = (int)ColorGridMajor.A;
                FileManager.LocalSettings.Values["ColorGridMajorR"] = (int)ColorGridMajor.R;
                FileManager.LocalSettings.Values["ColorGridMajorG"] = (int)ColorGridMajor.G;
                FileManager.LocalSettings.Values["ColorGridMajorB"] = (int)ColorGridMajor.B;

                LineGridMajor.DashCap = CanvasCapStyle.Round;
                LineGridMajor.DashOffset = 0;
                LineGridMajor.DashStyle = CanvasDashStyle.Solid;
                LineGridMajor.EndCap = CanvasCapStyle.Flat;
                LineGridMajor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMajor.MiterLimit = 0;
                LineGridMajor.StartCap = CanvasCapStyle.Flat;
                LineGridMajorWeight = 1;

                FileManager.LocalSettings.Values["LineGridMajorDashCap"] = (int)LineGridMajor.DashCap;
                FileManager.LocalSettings.Values["LineGridMajorDashOffset"] = (float)LineGridMajor.DashOffset;
                FileManager.LocalSettings.Values["LineGridMajorDashStyle"] = (int)LineGridMajor.DashStyle;
                FileManager.LocalSettings.Values["LineGridMajorEndCap"] = (int)LineGridMajor.EndCap;

                FileManager.LocalSettings.Values["LineGridMajorLineJoin"] = (int)LineGridMajor.LineJoin;
                FileManager.LocalSettings.Values["LineGridMajorMiterLimit"] = (float)LineGridMajor.MiterLimit;
                FileManager.LocalSettings.Values["LineGridMajorStartCap"] = (int)LineGridMajor.StartCap;
                FileManager.LocalSettings.Values["LineGridMajorWeight"] = (float)LineGridMajorWeight;
                WService.ReportException(ex);
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorForceB"];

                ColorForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceDashCap"];
                LineForce.DashOffset = (float)FileManager.LocalSettings.Values["LineForceDashOffset"];
                LineForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineForceDashStyle"];
                LineForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceEndCap"];
                LineForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineForceLineJoin"];
                LineForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineForceMiterLimit"];
                LineForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineForceStartCap"];
                LineForceWeight = (float)FileManager.LocalSettings.Values["LineForceWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorForceA"] = (int)ColorForce.A;
                FileManager.LocalSettings.Values["ColorForceR"] = (int)ColorForce.R;
                FileManager.LocalSettings.Values["ColorForceG"] = (int)ColorForce.G;
                FileManager.LocalSettings.Values["ColorForceB"] = (int)ColorForce.B;

                LineForce.DashCap = CanvasCapStyle.Round;
                LineForce.DashOffset = 0;
                LineForce.DashStyle = CanvasDashStyle.Solid;
                LineForce.EndCap = CanvasCapStyle.Flat;
                LineForce.LineJoin = CanvasLineJoin.Bevel;
                LineForce.MiterLimit = 0;
                LineForce.StartCap = CanvasCapStyle.Round;
                LineForceWeight = 5f;

                FileManager.LocalSettings.Values["LineForceDashCap"] = (int)LineForce.DashCap;
                FileManager.LocalSettings.Values["LineForceDashOffset"] = (float)LineForce.DashOffset;
                FileManager.LocalSettings.Values["LineForceDashStyle"] = (int)LineForce.DashStyle;
                FileManager.LocalSettings.Values["LineForceEndCap"] = (int)LineForce.EndCap;

                FileManager.LocalSettings.Values["LineForceLineJoin"] = (int)LineForce.LineJoin;
                FileManager.LocalSettings.Values["LineForceMiterLimit"] = (float)LineForce.MiterLimit;
                FileManager.LocalSettings.Values["LineForceStartCap"] = (int)LineForce.StartCap;
                FileManager.LocalSettings.Values["LineForceWeight"] = (float)LineForceWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorReactionA"];
                int r = (int)FileManager.LocalSettings.Values["ColorReactionR"];
                int g = (int)FileManager.LocalSettings.Values["ColorReactionG"];
                int b = (int)FileManager.LocalSettings.Values["ColorReactionB"];

                ColorReaction = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineReaction.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionDashCap"];
                LineReaction.DashOffset = (float)FileManager.LocalSettings.Values["LineReactionDashOffset"];
                LineReaction.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineReactionDashStyle"];
                LineReaction.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionEndCap"];
                LineReaction.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineReactionLineJoin"];
                LineReaction.MiterLimit = (float)FileManager.LocalSettings.Values["LineReactionMiterLimit"];
                LineReaction.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineReactionStartCap"];
                LineReactionWeight = (float)FileManager.LocalSettings.Values["LineReactionWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorReactionA"] = (int)ColorReaction.A;
                FileManager.LocalSettings.Values["ColorReactionR"] = (int)ColorReaction.R;
                FileManager.LocalSettings.Values["ColorReactionG"] = (int)ColorReaction.G;
                FileManager.LocalSettings.Values["ColorReactionB"] = (int)ColorReaction.B;

                LineReaction.DashCap = CanvasCapStyle.Round;
                LineReaction.DashOffset = 0;
                LineReaction.DashStyle = CanvasDashStyle.Solid;
                LineReaction.EndCap = CanvasCapStyle.Flat;
                LineReaction.LineJoin = CanvasLineJoin.Bevel;
                LineReaction.MiterLimit = 0;
                LineReaction.StartCap = CanvasCapStyle.Round;
                LineReactionWeight = 5f;

                FileManager.LocalSettings.Values["LineReactionDashCap"] = (int)LineReaction.DashCap;
                FileManager.LocalSettings.Values["LineReactionDashOffset"] = (float)LineReaction.DashOffset;
                FileManager.LocalSettings.Values["LineReactionDashStyle"] = (int)LineReaction.DashStyle;
                FileManager.LocalSettings.Values["LineReactionEndCap"] = (int)LineReaction.EndCap;

                FileManager.LocalSettings.Values["LineReactionLineJoin"] = (int)LineReaction.LineJoin;
                FileManager.LocalSettings.Values["LineReactionMiterLimit"] = (float)LineReaction.MiterLimit;
                FileManager.LocalSettings.Values["LineReactionStartCap"] = (int)LineReaction.StartCap;
                FileManager.LocalSettings.Values["LineReactionWeight"] = (float)LineReactionWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorSelectedElementA"];
                int r = (int)FileManager.LocalSettings.Values["ColorSelectedElementR"];
                int g = (int)FileManager.LocalSettings.Values["ColorSelectedElementG"];
                int b = (int)FileManager.LocalSettings.Values["ColorSelectedElementB"];

                ColorSelectedElement = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineSelectedElement.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementDashCap"];
                LineSelectedElement.DashOffset = (float)FileManager.LocalSettings.Values["LineSelectedElementDashOffset"];
                LineSelectedElement.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineSelectedElementDashStyle"];
                LineSelectedElement.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementEndCap"];
                LineSelectedElement.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineSelectedElementLineJoin"];
                LineSelectedElement.MiterLimit = (float)FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"];
                LineSelectedElement.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineSelectedElementStartCap"];
                LineSelectedElementWeight = (float)FileManager.LocalSettings.Values["LineSelectedElementWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorSelectedElementA"] = (int)ColorSelectedElement.A;
                FileManager.LocalSettings.Values["ColorSelectedElementR"] = (int)ColorSelectedElement.R;
                FileManager.LocalSettings.Values["ColorSelectedElementG"] = (int)ColorSelectedElement.G;
                FileManager.LocalSettings.Values["ColorSelectedElementB"] = (int)ColorSelectedElement.B;

                LineSelectedElement.DashCap = CanvasCapStyle.Round;
                LineSelectedElement.DashOffset = 0;
                LineSelectedElement.DashStyle = CanvasDashStyle.Solid;
                LineSelectedElement.EndCap = CanvasCapStyle.Flat;
                LineSelectedElement.LineJoin = CanvasLineJoin.Bevel;
                LineSelectedElement.MiterLimit = 0;
                LineSelectedElement.StartCap = CanvasCapStyle.Flat;
                LineSelectedElementWeight = 2.4f;

                FileManager.LocalSettings.Values["LineSelectedElementDashCap"] = (int)LineSelectedElement.DashCap;
                FileManager.LocalSettings.Values["LineSelectedElementDashOffset"] = (float)LineSelectedElement.DashOffset;
                FileManager.LocalSettings.Values["LineSelectedElementDashStyle"] = (int)LineSelectedElement.DashStyle;
                FileManager.LocalSettings.Values["LineSelectedElementEndCap"] = (int)LineSelectedElement.EndCap;

                FileManager.LocalSettings.Values["LineSelectedElementLineJoin"] = (int)LineSelectedElement.LineJoin;
                FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"] = (float)LineSelectedElement.MiterLimit;
                FileManager.LocalSettings.Values["LineSelectedElementStartCap"] = (int)LineSelectedElement.StartCap;
                FileManager.LocalSettings.Values["LineSelectedElementWeight"] = (float)LineSelectedElementWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorShearForceSelectedB"];

                ColorShearForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineShearForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"];
                LineShearForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"];
                LineShearForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"];
                LineShearForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"];
                LineShearForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"];
                LineShearForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"];
                LineShearForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"];
                LineShearForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineShearForceSelectedWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorShearForceSelectedA"] = (int)ColorShearForceSelected.A;
                FileManager.LocalSettings.Values["ColorShearForceSelectedR"] = (int)ColorShearForceSelected.R;
                FileManager.LocalSettings.Values["ColorShearForceSelectedG"] = (int)ColorShearForceSelected.G;
                FileManager.LocalSettings.Values["ColorShearForceSelectedB"] = (int)ColorShearForceSelected.B;

                LineShearForceSelected.DashCap = CanvasCapStyle.Round;
                LineShearForceSelected.DashOffset = 0;
                LineShearForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineShearForceSelected.EndCap = CanvasCapStyle.Flat;
                LineShearForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceSelected.MiterLimit = 0;
                LineShearForceSelected.StartCap = CanvasCapStyle.Flat;
                LineShearForceSelectedWeight = 2.4f;

                FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"] = (int)LineShearForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"] = (float)LineShearForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"] = (int)LineShearForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"] = (int)LineShearForceSelected.EndCap;

                FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"] = (int)LineShearForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"] = (float)LineShearForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"] = (int)LineShearForceSelected.StartCap;
                FileManager.LocalSettings.Values["LineShearForceSelectedWeight"] = (float)LineShearForceSelectedWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorMomentForceSelectedB"];

                ColorMomentForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineMomentForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"];
                LineMomentForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"];
                LineMomentForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"];
                LineMomentForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"];
                LineMomentForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"];
                LineMomentForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"];
                LineMomentForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"];
                LineMomentForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorMomentForceSelectedA"] = (int)ColorMomentForceSelected.A;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedR"] = (int)ColorMomentForceSelected.R;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedG"] = (int)ColorMomentForceSelected.G;
                FileManager.LocalSettings.Values["ColorMomentForceSelectedB"] = (int)ColorMomentForceSelected.B;

                LineMomentForceSelected.DashCap = CanvasCapStyle.Round;
                LineMomentForceSelected.DashOffset = 0;
                LineMomentForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceSelected.EndCap = CanvasCapStyle.Flat;
                LineMomentForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceSelected.MiterLimit = 0;
                LineMomentForceSelected.StartCap = CanvasCapStyle.Flat;
                LineMomentForceSelectedWeight = 2.4f;

                FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"] = (int)LineMomentForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"] = (float)LineMomentForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"] = (int)LineMomentForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"] = (int)LineMomentForceSelected.EndCap;

                FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"] = (int)LineMomentForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)LineMomentForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"] = (int)LineMomentForceSelected.StartCap;
                FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"] = (float)LineMomentForceSelectedWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorShearForceFontA"];
                int r = (int)FileManager.LocalSettings.Values["ColorShearForceFontR"];
                int g = (int)FileManager.LocalSettings.Values["ColorShearForceFontG"];
                int b = (int)FileManager.LocalSettings.Values["ColorShearForceFontB"];

                ColorShearForceFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineShearForceFont.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontDashCap"];
                LineShearForceFont.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceFontDashOffset"];
                LineShearForceFont.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceFontDashStyle"];
                LineShearForceFont.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontEndCap"];
                LineShearForceFont.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceFontLineJoin"];
                LineShearForceFont.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"];
                LineShearForceFont.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceFontStartCap"];
                LineShearForceFontWeight = (float)FileManager.LocalSettings.Values["LineShearForceFontWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorShearForceFontA"] = (int)ColorShearForceFont.A;
                FileManager.LocalSettings.Values["ColorShearForceFontR"] = (int)ColorShearForceFont.R;
                FileManager.LocalSettings.Values["ColorShearForceFontG"] = (int)ColorShearForceFont.G;
                FileManager.LocalSettings.Values["ColorShearForceFontB"] = (int)ColorShearForceFont.B;

                LineShearForceFont.DashCap = CanvasCapStyle.Round;
                LineShearForceFont.DashOffset = 0;
                LineShearForceFont.DashStyle = CanvasDashStyle.Solid;
                LineShearForceFont.EndCap = CanvasCapStyle.Flat;
                LineShearForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceFont.MiterLimit = 0;
                LineShearForceFont.StartCap = CanvasCapStyle.Flat;
                LineShearForceFontWeight = 2.4f;

                FileManager.LocalSettings.Values["LineShearForceFontDashCap"] = (int)LineShearForceFont.DashCap;
                FileManager.LocalSettings.Values["LineShearForceFontDashOffset"] = (float)LineShearForceFont.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceFontDashStyle"] = (int)LineShearForceFont.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceFontEndCap"] = (int)LineShearForceFont.EndCap;

                FileManager.LocalSettings.Values["LineShearForceFontLineJoin"] = (int)LineShearForceFont.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceFontMiterLimit"] = (float)LineShearForceFont.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceFontStartCap"] = (int)LineShearForceFont.StartCap;
                FileManager.LocalSettings.Values["LineShearForceFontWeight"] = (float)LineShearForceFontWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorMomentForceFontA"];
                int r = (int)FileManager.LocalSettings.Values["ColorMomentForceFontR"];
                int g = (int)FileManager.LocalSettings.Values["ColorMomentForceFontG"];
                int b = (int)FileManager.LocalSettings.Values["ColorMomentForceFontB"];

                ColorMomentForceFont = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineMomentForceFont.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontDashCap"];
                LineMomentForceFont.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"];
                LineMomentForceFont.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"];
                LineMomentForceFont.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontEndCap"];
                LineMomentForceFont.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"];
                LineMomentForceFont.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"];
                LineMomentForceFont.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceFontStartCap"];
                LineMomentForceFontWeight = (float)FileManager.LocalSettings.Values["LineMomentForceFontWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorMomentForceFontA"] = (int)ColorMomentForceFont.A;
                FileManager.LocalSettings.Values["ColorMomentForceFontR"] = (int)ColorMomentForceFont.R;
                FileManager.LocalSettings.Values["ColorMomentForceFontG"] = (int)ColorMomentForceFont.G;
                FileManager.LocalSettings.Values["ColorMomentForceFontB"] = (int)ColorMomentForceFont.B;

                LineMomentForceFont.DashCap = CanvasCapStyle.Round;
                LineMomentForceFont.DashOffset = 0;
                LineMomentForceFont.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceFont.EndCap = CanvasCapStyle.Flat;
                LineMomentForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceFont.MiterLimit = 0;
                LineMomentForceFont.StartCap = CanvasCapStyle.Flat;
                LineMomentForceFontWeight = 2.4f;

                FileManager.LocalSettings.Values["LineMomentForceFontDashCap"] = (int)LineMomentForceFont.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceFontDashOffset"] = (float)LineMomentForceFont.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceFontDashStyle"] = (int)LineMomentForceFont.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceFontEndCap"] = (int)LineMomentForceFont.EndCap;

                FileManager.LocalSettings.Values["LineMomentForceFontLineJoin"] = (int)LineMomentForceFont.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceFontMiterLimit"] = (float)LineMomentForceFont.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceFontStartCap"] = (int)LineMomentForceFont.StartCap;
                FileManager.LocalSettings.Values["LineMomentForceFontWeight"] = (float)LineMomentForceFontWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorShearForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorShearForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorShearForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorShearForceB"];

                ColorShearForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineShearForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceDashCap"];
                LineShearForce.DashOffset = (float)FileManager.LocalSettings.Values["LineShearForceDashOffset"];
                LineShearForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineShearForceDashStyle"];
                LineShearForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceEndCap"];
                LineShearForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineShearForceLineJoin"];
                LineShearForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineShearForceMiterLimit"];
                LineShearForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineShearForceStartCap"];
                LineShearForceWeight = (float)FileManager.LocalSettings.Values["LineShearForceWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorShearForceA"] = (int)ColorShearForce.A;
                FileManager.LocalSettings.Values["ColorShearForceR"] = (int)ColorShearForce.R;
                FileManager.LocalSettings.Values["ColorShearForceG"] = (int)ColorShearForce.G;
                FileManager.LocalSettings.Values["ColorShearForceB"] = (int)ColorShearForce.B;

                LineShearForce.DashCap = CanvasCapStyle.Round;
                LineShearForce.DashOffset = 0;
                LineShearForce.DashStyle = CanvasDashStyle.Solid;
                LineShearForce.EndCap = CanvasCapStyle.Flat;
                LineShearForce.LineJoin = CanvasLineJoin.Bevel;
                LineShearForce.MiterLimit = 0;
                LineShearForce.StartCap = CanvasCapStyle.Flat;
                LineShearForceWeight = 1.5f;

                FileManager.LocalSettings.Values["LineShearForceDashCap"] = (int)LineShearForce.DashCap;
                FileManager.LocalSettings.Values["LineShearForceDashOffset"] = (float)LineShearForce.DashOffset;
                FileManager.LocalSettings.Values["LineShearForceDashStyle"] = (int)LineShearForce.DashStyle;
                FileManager.LocalSettings.Values["LineShearForceEndCap"] = (int)LineShearForce.EndCap;

                FileManager.LocalSettings.Values["LineShearForceLineJoin"] = (int)LineShearForce.LineJoin;
                FileManager.LocalSettings.Values["LineShearForceMiterLimit"] = (float)LineShearForce.MiterLimit;
                FileManager.LocalSettings.Values["LineShearForceStartCap"] = (int)LineShearForce.StartCap;
                FileManager.LocalSettings.Values["LineShearForceWeight"] = (float)LineShearForceWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorMomentForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorMomentForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorMomentForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorMomentForceB"];

                ColorMomentForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineMomentForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceDashCap"];
                LineMomentForce.DashOffset = (float)FileManager.LocalSettings.Values["LineMomentForceDashOffset"];
                LineMomentForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineMomentForceDashStyle"];
                LineMomentForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceEndCap"];
                LineMomentForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineMomentForceLineJoin"];
                LineMomentForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineMomentForceMiterLimit"];
                LineMomentForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineMomentForceStartCap"];
                LineMomentForceWeight = (float)FileManager.LocalSettings.Values["LineMomentForceWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorMomentForceA"] = (int)ColorMomentForce.A;
                FileManager.LocalSettings.Values["ColorMomentForceR"] = (int)ColorMomentForce.R;
                FileManager.LocalSettings.Values["ColorMomentForceG"] = (int)ColorMomentForce.G;
                FileManager.LocalSettings.Values["ColorMomentForceB"] = (int)ColorMomentForce.B;

                LineMomentForce.DashCap = CanvasCapStyle.Round;
                LineMomentForce.DashOffset = 0;
                LineMomentForce.DashStyle = CanvasDashStyle.Solid;
                LineMomentForce.EndCap = CanvasCapStyle.Flat;
                LineMomentForce.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForce.MiterLimit = 0;
                LineMomentForce.StartCap = CanvasCapStyle.Flat;
                LineMomentForceWeight = 1.5f;

                FileManager.LocalSettings.Values["LineMomentForceDashCap"] = (int)LineMomentForce.DashCap;
                FileManager.LocalSettings.Values["LineMomentForceDashOffset"] = (float)LineMomentForce.DashOffset;
                FileManager.LocalSettings.Values["LineMomentForceDashStyle"] = (int)LineMomentForce.DashStyle;
                FileManager.LocalSettings.Values["LineMomentForceEndCap"] = (int)LineMomentForce.EndCap;

                FileManager.LocalSettings.Values["LineMomentForceLineJoin"] = (int)LineMomentForce.LineJoin;
                FileManager.LocalSettings.Values["LineMomentForceMiterLimit"] = (float)LineMomentForce.MiterLimit;
                FileManager.LocalSettings.Values["LineMomentForceStartCap"] = (int)LineMomentForce.StartCap;
                FileManager.LocalSettings.Values["LineMomentForceWeight"] = (float)LineMomentForceWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorDistributedForceA"];
                int r = (int)FileManager.LocalSettings.Values["ColorDistributedForceR"];
                int g = (int)FileManager.LocalSettings.Values["ColorDistributedForceG"];
                int b = (int)FileManager.LocalSettings.Values["ColorDistributedForceB"];

                ColorDistributedForce = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineDistributedForce.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceDashCap"];
                LineDistributedForce.DashOffset = (float)FileManager.LocalSettings.Values["LineDistributedForceDashOffset"];
                LineDistributedForce.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineDistributedForceDashStyle"];
                LineDistributedForce.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceEndCap"];
                LineDistributedForce.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineDistributedForceLineJoin"];
                LineDistributedForce.MiterLimit = (float)FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"];
                LineDistributedForce.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceStartCap"];
                LineDistributedForceWeight = (float)FileManager.LocalSettings.Values["LineDistributedForceWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorDistributedForceA"] = (int)ColorDistributedForce.A;
                FileManager.LocalSettings.Values["ColorDistributedForceR"] = (int)ColorDistributedForce.R;
                FileManager.LocalSettings.Values["ColorDistributedForceG"] = (int)ColorDistributedForce.G;
                FileManager.LocalSettings.Values["ColorDistributedForceB"] = (int)ColorDistributedForce.B;

                LineDistributedForce.DashCap = CanvasCapStyle.Round;
                LineDistributedForce.DashOffset = 0;
                LineDistributedForce.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForce.EndCap = CanvasCapStyle.Flat;
                LineDistributedForce.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForce.MiterLimit = 0;
                LineDistributedForce.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceWeight = 1.5f;

                FileManager.LocalSettings.Values["LineDistributedForceDashCap"] = (int)LineDistributedForce.DashCap;
                FileManager.LocalSettings.Values["LineDistributedForceDashOffset"] = (float)LineDistributedForce.DashOffset;
                FileManager.LocalSettings.Values["LineDistributedForceDashStyle"] = (int)LineDistributedForce.DashStyle;
                FileManager.LocalSettings.Values["LineDistributedForceEndCap"] = (int)LineDistributedForce.EndCap;

                FileManager.LocalSettings.Values["LineDistributedForceLineJoin"] = (int)LineDistributedForce.LineJoin;
                FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"] = (float)LineDistributedForce.MiterLimit;
                FileManager.LocalSettings.Values["LineDistributedForceStartCap"] = (int)LineDistributedForce.StartCap;
                FileManager.LocalSettings.Values["LineDistributedForceWeight"] = (float)LineDistributedForceWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"];

                ColorDistributedForceSelected = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineDistributedForceSelected.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"];
                LineDistributedForceSelected.DashOffset = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"];
                LineDistributedForceSelected.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"];
                LineDistributedForceSelected.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"];
                LineDistributedForceSelected.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"];
                LineDistributedForceSelected.MiterLimit = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"];
                LineDistributedForceSelected.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"];
                LineDistributedForceSelectedWeight = (float)FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"] = (int)ColorDistributedForceSelected.A;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"] = (int)ColorDistributedForceSelected.R;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"] = (int)ColorDistributedForceSelected.G;
                FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"] = (int)ColorDistributedForceSelected.B;

                LineDistributedForceSelected.DashCap = CanvasCapStyle.Round;
                LineDistributedForceSelected.DashOffset = 0;
                LineDistributedForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForceSelected.EndCap = CanvasCapStyle.Flat;
                LineDistributedForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForceSelected.MiterLimit = 0;
                LineDistributedForceSelected.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceSelectedWeight = 1.5f;

                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"] = (int)LineDistributedForceSelected.DashCap;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)LineDistributedForceSelected.DashOffset;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)LineDistributedForceSelected.DashStyle;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"] = (int)LineDistributedForceSelected.EndCap;

                FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)LineDistributedForceSelected.LineJoin;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)LineDistributedForceSelected.MiterLimit;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"] = (int)LineDistributedForceSelected.StartCap;
                FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"] = (float)LineDistributedForceSelectedWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorNodeFreeA"];
                int r = (int)FileManager.LocalSettings.Values["ColorNodeFreeR"];
                int g = (int)FileManager.LocalSettings.Values["ColorNodeFreeG"];
                int b = (int)FileManager.LocalSettings.Values["ColorNodeFreeB"];

                ColorNodeFree = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineNodeFree.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeFreeDashCap"];
                LineNodeFree.DashOffset = (float)FileManager.LocalSettings.Values["LineNodeFreeDashOffset"];
                LineNodeFree.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineNodeFreeDashStyle"];
                LineNodeFree.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeFreeEndCap"];
                LineNodeFree.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineNodeFreeLineJoin"];
                LineNodeFree.MiterLimit = (float)FileManager.LocalSettings.Values["LineNodeFreeMiterLimit"];
                LineNodeFree.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeFreeStartCap"];
                LineNodeFreeWeight = (float)FileManager.LocalSettings.Values["LineNodeFreeWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorNodeFreeA"] = (int)ColorNodeFree.A;
                FileManager.LocalSettings.Values["ColorNodeFreeR"] = (int)ColorNodeFree.R;
                FileManager.LocalSettings.Values["ColorNodeFreeG"] = (int)ColorNodeFree.G;
                FileManager.LocalSettings.Values["ColorNodeFreeB"] = (int)ColorNodeFree.B;

                LineNodeFree.DashCap = CanvasCapStyle.Round;
                LineNodeFree.DashOffset = 0;
                LineNodeFree.DashStyle = CanvasDashStyle.Solid;
                LineNodeFree.EndCap = CanvasCapStyle.Flat;
                LineNodeFree.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFree.MiterLimit = 0;
                LineNodeFree.StartCap = CanvasCapStyle.Flat;
                LineNodeFreeWeight = 1;

                FileManager.LocalSettings.Values["LineNodeFreeDashCap"] = (int)LineNodeFree.DashCap;
                FileManager.LocalSettings.Values["LineNodeFreeDashOffset"] = (float)LineNodeFree.DashOffset;
                FileManager.LocalSettings.Values["LineNodeFreeDashStyle"] = (int)LineNodeFree.DashStyle;
                FileManager.LocalSettings.Values["LineNodeFreeEndCap"] = (int)LineNodeFree.EndCap;

                FileManager.LocalSettings.Values["LineNodeFreeLineJoin"] = (int)LineNodeFree.LineJoin;
                FileManager.LocalSettings.Values["LineNodeFreeMiterLimit"] = (float)LineNodeFree.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeFreeStartCap"] = (int)LineNodeFree.StartCap;
                FileManager.LocalSettings.Values["LineNodeFreeWeight"] = (float)LineNodeFreeWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorNodeFixedA"];
                int r = (int)FileManager.LocalSettings.Values["ColorNodeFixedR"];
                int g = (int)FileManager.LocalSettings.Values["ColorNodeFixedG"];
                int b = (int)FileManager.LocalSettings.Values["ColorNodeFixedB"];

                ColorNodeFixed = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineNodeFixed.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeFixedDashCap"];
                LineNodeFixed.DashOffset = (float)FileManager.LocalSettings.Values["LineNodeFixedDashOffset"];
                LineNodeFixed.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineNodeFixedDashStyle"];
                LineNodeFixed.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeFixedEndCap"];
                LineNodeFixed.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineNodeFixedLineJoin"];
                LineNodeFixed.MiterLimit = (float)FileManager.LocalSettings.Values["LineNodeFixedMiterLimit"];
                LineNodeFixed.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeFixedStartCap"];
                LineNodeFixedWeight = (float)FileManager.LocalSettings.Values["LineNodeFixedWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorNodeFixedA"] = (int)ColorNodeFixed.A;
                FileManager.LocalSettings.Values["ColorNodeFixedR"] = (int)ColorNodeFixed.R;
                FileManager.LocalSettings.Values["ColorNodeFixedG"] = (int)ColorNodeFixed.G;
                FileManager.LocalSettings.Values["ColorNodeFixedB"] = (int)ColorNodeFixed.B;

                LineNodeFixed.DashCap = CanvasCapStyle.Round;
                LineNodeFixed.DashOffset = 0;
                LineNodeFixed.DashStyle = CanvasDashStyle.Solid;
                LineNodeFixed.EndCap = CanvasCapStyle.Flat;
                LineNodeFixed.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFixed.MiterLimit = 0;
                LineNodeFixed.StartCap = CanvasCapStyle.Flat;
                LineNodeFixedWeight = 1;

                FileManager.LocalSettings.Values["LineNodeFixedDashCap"] = (int)LineNodeFixed.DashCap;
                FileManager.LocalSettings.Values["LineNodeFixedDashOffset"] = (float)LineNodeFixed.DashOffset;
                FileManager.LocalSettings.Values["LineNodeFixedDashStyle"] = (int)LineNodeFixed.DashStyle;
                FileManager.LocalSettings.Values["LineNodeFixedEndCap"] = (int)LineNodeFixed.EndCap;

                FileManager.LocalSettings.Values["LineNodeFixedLineJoin"] = (int)LineNodeFixed.LineJoin;
                FileManager.LocalSettings.Values["LineNodeFixedMiterLimit"] = (float)LineNodeFixed.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeFixedStartCap"] = (int)LineNodeFixed.StartCap;
                FileManager.LocalSettings.Values["LineNodeFixedWeight"] = (float)LineNodeFixedWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorNodePinA"];
                int r = (int)FileManager.LocalSettings.Values["ColorNodePinR"];
                int g = (int)FileManager.LocalSettings.Values["ColorNodePinG"];
                int b = (int)FileManager.LocalSettings.Values["ColorNodePinB"];

                ColorNodePin = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineNodePin.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodePinDashCap"];
                LineNodePin.DashOffset = (float)FileManager.LocalSettings.Values["LineNodePinDashOffset"];
                LineNodePin.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineNodePinDashStyle"];
                LineNodePin.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodePinEndCap"];
                LineNodePin.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineNodePinLineJoin"];
                LineNodePin.MiterLimit = (float)FileManager.LocalSettings.Values["LineNodePinMiterLimit"];
                LineNodePin.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodePinStartCap"];
                LineNodePinWeight = (float)FileManager.LocalSettings.Values["LineNodePinWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorNodePinA"] = (int)ColorNodePin.A;
                FileManager.LocalSettings.Values["ColorNodePinR"] = (int)ColorNodePin.R;
                FileManager.LocalSettings.Values["ColorNodePinG"] = (int)ColorNodePin.G;
                FileManager.LocalSettings.Values["ColorNodePinB"] = (int)ColorNodePin.B;

                LineNodePin.DashCap = CanvasCapStyle.Round;
                LineNodePin.DashOffset = 0;
                LineNodePin.DashStyle = CanvasDashStyle.Solid;
                LineNodePin.EndCap = CanvasCapStyle.Flat;
                LineNodePin.LineJoin = CanvasLineJoin.Bevel;
                LineNodePin.MiterLimit = 0;
                LineNodePin.StartCap = CanvasCapStyle.Flat;
                LineNodePinWeight = 1;

                FileManager.LocalSettings.Values["LineNodePinDashCap"] = (int)LineNodePin.DashCap;
                FileManager.LocalSettings.Values["LineNodePinDashOffset"] = (float)LineNodePin.DashOffset;
                FileManager.LocalSettings.Values["LineNodePinDashStyle"] = (int)LineNodePin.DashStyle;
                FileManager.LocalSettings.Values["LineNodePinEndCap"] = (int)LineNodePin.EndCap;

                FileManager.LocalSettings.Values["LineNodePinLineJoin"] = (int)LineNodePin.LineJoin;
                FileManager.LocalSettings.Values["LineNodePinMiterLimit"] = (float)LineNodePin.MiterLimit;
                FileManager.LocalSettings.Values["LineNodePinStartCap"] = (int)LineNodePin.StartCap;
                FileManager.LocalSettings.Values["LineNodePinWeight"] = (float)LineNodePinWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorNodeRollerXA"];
                int r = (int)FileManager.LocalSettings.Values["ColorNodeRollerXR"];
                int g = (int)FileManager.LocalSettings.Values["ColorNodeRollerXG"];
                int b = (int)FileManager.LocalSettings.Values["ColorNodeRollerXB"];

                ColorNodeRollerX = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineNodeRollerX.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeRollerXDashCap"];
                LineNodeRollerX.DashOffset = (float)FileManager.LocalSettings.Values["LineNodeRollerXDashOffset"];
                LineNodeRollerX.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineNodeRollerXDashStyle"];
                LineNodeRollerX.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeRollerXEndCap"];
                LineNodeRollerX.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineNodeRollerXLineJoin"];
                LineNodeRollerX.MiterLimit = (float)FileManager.LocalSettings.Values["LineNodeRollerXMiterLimit"];
                LineNodeRollerX.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeRollerXStartCap"];
                LineNodeRollerXWeight = (float)FileManager.LocalSettings.Values["LineNodeRollerXWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorNodeRollerXA"] = (int)ColorNodeRollerX.A;
                FileManager.LocalSettings.Values["ColorNodeRollerXR"] = (int)ColorNodeRollerX.R;
                FileManager.LocalSettings.Values["ColorNodeRollerXG"] = (int)ColorNodeRollerX.G;
                FileManager.LocalSettings.Values["ColorNodeRollerXB"] = (int)ColorNodeRollerX.B;

                LineNodeRollerX.DashCap = CanvasCapStyle.Round;
                LineNodeRollerX.DashOffset = 0;
                LineNodeRollerX.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerX.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerX.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerX.MiterLimit = 0;
                LineNodeRollerX.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerXWeight = 1;

                FileManager.LocalSettings.Values["LineNodeRollerXDashCap"] = (int)LineNodeRollerX.DashCap;
                FileManager.LocalSettings.Values["LineNodeRollerXDashOffset"] = (float)LineNodeRollerX.DashOffset;
                FileManager.LocalSettings.Values["LineNodeRollerXDashStyle"] = (int)LineNodeRollerX.DashStyle;
                FileManager.LocalSettings.Values["LineNodeRollerXEndCap"] = (int)LineNodeRollerX.EndCap;

                FileManager.LocalSettings.Values["LineNodeRollerXLineJoin"] = (int)LineNodeRollerX.LineJoin;
                FileManager.LocalSettings.Values["LineNodeRollerXMiterLimit"] = (float)LineNodeRollerX.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeRollerXStartCap"] = (int)LineNodeRollerX.StartCap;
                FileManager.LocalSettings.Values["LineNodeRollerXWeight"] = (float)LineNodeRollerXWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorNodeRollerYA"];
                int r = (int)FileManager.LocalSettings.Values["ColorNodeRollerYR"];
                int g = (int)FileManager.LocalSettings.Values["ColorNodeRollerYG"];
                int b = (int)FileManager.LocalSettings.Values["ColorNodeRollerYB"];

                ColorNodeRollerY = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineNodeRollerY.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeRollerYDashCap"];
                LineNodeRollerY.DashOffset = (float)FileManager.LocalSettings.Values["LineNodeRollerYDashOffset"];
                LineNodeRollerY.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineNodeRollerYDashStyle"];
                LineNodeRollerY.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeRollerYEndCap"];
                LineNodeRollerY.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineNodeRollerYLineJoin"];
                LineNodeRollerY.MiterLimit = (float)FileManager.LocalSettings.Values["LineNodeRollerYMiterLimit"];
                LineNodeRollerY.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeRollerYStartCap"];
                LineNodeRollerYWeight = (float)FileManager.LocalSettings.Values["LineNodeRollerYWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorNodeRollerYA"] = (int)ColorNodeRollerY.A;
                FileManager.LocalSettings.Values["ColorNodeRollerYR"] = (int)ColorNodeRollerY.R;
                FileManager.LocalSettings.Values["ColorNodeRollerYG"] = (int)ColorNodeRollerY.G;
                FileManager.LocalSettings.Values["ColorNodeRollerYB"] = (int)ColorNodeRollerY.B;

                LineNodeRollerY.DashCap = CanvasCapStyle.Round;
                LineNodeRollerY.DashOffset = 0;
                LineNodeRollerY.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerY.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerY.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerY.MiterLimit = 0;
                LineNodeRollerY.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerYWeight = 1;

                FileManager.LocalSettings.Values["LineNodeRollerYDashCap"] = (int)LineNodeRollerY.DashCap;
                FileManager.LocalSettings.Values["LineNodeRollerYDashOffset"] = (float)LineNodeRollerY.DashOffset;
                FileManager.LocalSettings.Values["LineNodeRollerYDashStyle"] = (int)LineNodeRollerY.DashStyle;
                FileManager.LocalSettings.Values["LineNodeRollerYEndCap"] = (int)LineNodeRollerY.EndCap;

                FileManager.LocalSettings.Values["LineNodeRollerYLineJoin"] = (int)LineNodeRollerY.LineJoin;
                FileManager.LocalSettings.Values["LineNodeRollerYMiterLimit"] = (float)LineNodeRollerY.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeRollerYStartCap"] = (int)LineNodeRollerY.StartCap;
                FileManager.LocalSettings.Values["LineNodeRollerYWeight"] = (float)LineNodeRollerYWeight;
            }

            try
            {
                int a = (int)FileManager.LocalSettings.Values["ColorNodeOtherA"];
                int r = (int)FileManager.LocalSettings.Values["ColorNodeOtherR"];
                int g = (int)FileManager.LocalSettings.Values["ColorNodeOtherG"];
                int b = (int)FileManager.LocalSettings.Values["ColorNodeOtherB"];

                ColorNodeOther = Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);

                LineNodeOther.DashCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeOtherDashCap"];
                LineNodeOther.DashOffset = (float)FileManager.LocalSettings.Values["LineNodeOtherDashOffset"];
                LineNodeOther.DashStyle = (CanvasDashStyle)FileManager.LocalSettings.Values["LineNodeOtherDashStyle"];
                LineNodeOther.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeOtherEndCap"];
                LineNodeOther.LineJoin = (CanvasLineJoin)FileManager.LocalSettings.Values["LineNodeOtherLineJoin"];
                LineNodeOther.MiterLimit = (float)FileManager.LocalSettings.Values["LineNodeOtherMiterLimit"];
                LineNodeOther.StartCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineNodeOtherStartCap"];
                LineNodeOtherWeight = (float)FileManager.LocalSettings.Values["LineNodeOtherWeight"];
            }
            catch
            {
                FileManager.LocalSettings.Values["ColorNodeOtherA"] = (int)ColorNodeOther.A;
                FileManager.LocalSettings.Values["ColorNodeOtherR"] = (int)ColorNodeOther.R;
                FileManager.LocalSettings.Values["ColorNodeOtherG"] = (int)ColorNodeOther.G;
                FileManager.LocalSettings.Values["ColorNodeOtherB"] = (int)ColorNodeOther.B;

                LineNodeOther.DashCap = CanvasCapStyle.Round;
                LineNodeOther.DashOffset = 0;
                LineNodeOther.DashStyle = CanvasDashStyle.Solid;
                LineNodeOther.EndCap = CanvasCapStyle.Flat;
                LineNodeOther.LineJoin = CanvasLineJoin.Bevel;
                LineNodeOther.MiterLimit = 0;
                LineNodeOther.StartCap = CanvasCapStyle.Flat;
                LineNodeOtherWeight = 1;

                FileManager.LocalSettings.Values["LineNodeOtherDashCap"] = (int)LineNodeOther.DashCap;
                FileManager.LocalSettings.Values["LineNodeOtherDashOffset"] = (float)LineNodeOther.DashOffset;
                FileManager.LocalSettings.Values["LineNodeOtherDashStyle"] = (int)LineNodeOther.DashStyle;
                FileManager.LocalSettings.Values["LineNodeOtherEndCap"] = (int)LineNodeOther.EndCap;

                FileManager.LocalSettings.Values["LineNodeOtherLineJoin"] = (int)LineNodeOther.LineJoin;
                FileManager.LocalSettings.Values["LineNodeOtherMiterLimit"] = (float)LineNodeOther.MiterLimit;
                FileManager.LocalSettings.Values["LineNodeOtherStartCap"] = (int)LineNodeOther.StartCap;
                FileManager.LocalSettings.Values["LineNodeOtherWeight"] = (float)LineNodeOtherWeight;
            }

            try
            {
                momentFactor = Convert.ToSingle(FileManager.LocalSettings.Values["MomentFactor"]);
            }
            catch
            {
                FileManager.LocalSettings.Values["MomentFactor"] = 0.001f;
                momentFactor = 0.001f;
            }

            try
            {
                shearFactor = Convert.ToSingle(FileManager.LocalSettings.Values["ShearFactor"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading ShearFactor");
                FileManager.LocalSettings.Values["ShearFactor"] = 0.001f;
                shearFactor = 0.001f;
            }

            try
            {
                linearFactor = Convert.ToSingle(FileManager.LocalSettings.Values["LinearFactor"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading LinearFactor");
                FileManager.LocalSettings.Values["LinearFactor"] = 0.001f;
                linearFactor = 0.001f;
            }

            try
            {
                forcesFactor = Convert.ToSingle(FileManager.LocalSettings.Values["ForcesFactor"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading ForcesFactor");
                FileManager.LocalSettings.Values["ForcesFactor"] = 0.001f;
                forcesFactor = 0.001f;
            }

            try
            {
                reactionsFactor = Convert.ToSingle(FileManager.LocalSettings.Values["ReactionsFactor"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading ReactionsFactor");
                FileManager.LocalSettings.Values["ReactionsFactor"] = 0.001f;
                reactionsFactor = 0.001f;
            }

            try
            {
                displacementFactor = Convert.ToSingle(FileManager.LocalSettings.Values["DisplacementFactor"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading DisplacementFactor");
                FileManager.LocalSettings.Values["DisplacementFactor"] = 1f;
                displacementFactor = 1f;
            }

            try
            {
                CameraZoomTrim = Convert.ToSingle(FileManager.LocalSettings.Values["CameraZoomTrim"]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Loading CameraZoomTrim " + ex.Message);
                FileManager.LocalSettings.Values["CameraZoomTrim"] = 500f;
                CameraZoomTrim = 500f;
            }

            Camera.ZoomTrim = CameraZoomTrim;

            try
            {
                SelectGridSize = Convert.ToSingle(FileManager.LocalSettings.Values["SelectGridSize"]);
            }
            catch
            {
                Debug.WriteLine("Error Loading SelectGridSize");
                FileManager.LocalSettings.Values["SelectGridSize"] = 1f;
                SelectGridSize = 1f;
            }
        }

        /// <summary>
        /// Saves the options to the Application Data Container named LocalSettings.
        /// </summary>
        internal static void SaveOptions()
        {
            FileManager.LocalSettings.Values["FirstRun"] = (bool)FirstRun;

            FileManager.LocalSettings.Values["CameraZoomTrim"] = (float)CameraZoomTrim;
            FileManager.LocalSettings.Values["SelectGridSize"] = (float)SelectGridSize;
            FileManager.LocalSettings.Values["ColorGridNormalA"] = (int)ColorGridNormal.A;
            FileManager.LocalSettings.Values["ColorGridNormalR"] = (int)ColorGridNormal.R;
            FileManager.LocalSettings.Values["ColorGridNormalG"] = (int)ColorGridNormal.G;
            FileManager.LocalSettings.Values["ColorGridNormalB"] = (int)ColorGridNormal.B;

            FileManager.LocalSettings.Values["LineGridNormalDashCap"] = (int)LineGridNormal.DashCap;
            FileManager.LocalSettings.Values["LineGridNormalDashOffset"] = (float)LineGridNormal.DashOffset;
            FileManager.LocalSettings.Values["LineGridNormalDashStyle"] = (int)LineGridNormal.DashStyle;
            FileManager.LocalSettings.Values["LineGridNormalEndCap"] = (int)LineGridNormal.EndCap;
            FileManager.LocalSettings.Values["LineGridNormalLineJoin"] = (int)LineGridNormal.LineJoin;
            FileManager.LocalSettings.Values["LineGridNormalMiterLimit"] = (float)LineGridNormal.MiterLimit;
            FileManager.LocalSettings.Values["LineGridNormalStartCap"] = (int)LineGridNormal.StartCap;
            FileManager.LocalSettings.Values["LineGridNormalWeight"] = (float)LineGridNormalWeight;
            FileManager.LocalSettings.Values["ColorGridMinorA"] = (int)ColorGridMinor.A;
            FileManager.LocalSettings.Values["ColorGridMinorR"] = (int)ColorGridMinor.R;
            FileManager.LocalSettings.Values["ColorGridMinorG"] = (int)ColorGridMinor.G;
            FileManager.LocalSettings.Values["ColorGridMinorB"] = (int)ColorGridMinor.B;

            FileManager.LocalSettings.Values["LineGridMinorDashCap"] = (int)LineGridMinor.DashCap;
            FileManager.LocalSettings.Values["LineGridMinorDashOffset"] = (float)LineGridMinor.DashOffset;
            FileManager.LocalSettings.Values["LineGridMinorDashStyle"] = (int)LineGridMinor.DashStyle;
            FileManager.LocalSettings.Values["LineGridMinorEndCap"] = (int)LineGridMinor.EndCap;
            FileManager.LocalSettings.Values["LineGridMinorLineJoin"] = (int)LineGridMinor.LineJoin;
            FileManager.LocalSettings.Values["LineGridMinorMiterLimit"] = (float)LineGridMinor.MiterLimit;
            FileManager.LocalSettings.Values["LineGridMinorStartCap"] = (int)LineGridMinor.StartCap;
            FileManager.LocalSettings.Values["LineGridMinorWeight"] = (float)LineGridMinorWeight;
            FileManager.LocalSettings.Values["ColorGridMajorA"] = (int)ColorGridMajor.A;
            FileManager.LocalSettings.Values["ColorGridMajorR"] = (int)ColorGridMajor.R;
            FileManager.LocalSettings.Values["ColorGridMajorG"] = (int)ColorGridMajor.G;
            FileManager.LocalSettings.Values["ColorGridMajorB"] = (int)ColorGridMajor.B;

            FileManager.LocalSettings.Values["LineGridMajorDashCap"] = (int)LineGridMajor.DashCap;
            FileManager.LocalSettings.Values["LineGridMajorDashOffset"] = (float)LineGridMajor.DashOffset;
            FileManager.LocalSettings.Values["LineGridMajorDashStyle"] = (int)LineGridMajor.DashStyle;
            FileManager.LocalSettings.Values["LineGridMajorEndCap"] = (int)LineGridMajor.EndCap;
            FileManager.LocalSettings.Values["LineGridMajorLineJoin"] = (int)LineGridMajor.LineJoin;
            FileManager.LocalSettings.Values["LineGridMajorMiterLimit"] = (float)LineGridMajor.MiterLimit;
            FileManager.LocalSettings.Values["LineGridMajorStartCap"] = (int)LineGridMajor.StartCap;
            FileManager.LocalSettings.Values["LineGridMajorWeight"] = (float)LineGridMajorWeight;
            FileManager.LocalSettings.Values["ColorSelectedElementA"] = (int)ColorSelectedElement.A;
            FileManager.LocalSettings.Values["ColorSelectedElementR"] = (int)ColorSelectedElement.R;
            FileManager.LocalSettings.Values["ColorSelectedElementG"] = (int)ColorSelectedElement.G;
            FileManager.LocalSettings.Values["ColorSelectedElementB"] = (int)ColorSelectedElement.B;

            FileManager.LocalSettings.Values["LineSelectedElementDashCap"] = (int)LineSelectedElement.DashCap;
            FileManager.LocalSettings.Values["LineSelectedElementDashOffset"] = (float)LineSelectedElement.DashOffset;
            FileManager.LocalSettings.Values["LineSelectedElementDashStyle"] = (int)LineSelectedElement.DashStyle;
            FileManager.LocalSettings.Values["LineSelectedElementEndCap"] = (int)LineSelectedElement.EndCap;
            FileManager.LocalSettings.Values["LineSelectedElementLineJoin"] = (int)LineSelectedElement.LineJoin;
            FileManager.LocalSettings.Values["LineSelectedElementMiterLimit"] = (float)LineSelectedElement.MiterLimit;
            FileManager.LocalSettings.Values["LineSelectedElementStartCap"] = (int)LineSelectedElement.StartCap;
            FileManager.LocalSettings.Values["LineSelectedElementWeight"] = (float)LineSelectedElementWeight;
            FileManager.LocalSettings.Values["ColorForceA"] = (int)ColorForce.A;
            FileManager.LocalSettings.Values["ColorForceR"] = (int)ColorForce.R;
            FileManager.LocalSettings.Values["ColorForceG"] = (int)ColorForce.G;
            FileManager.LocalSettings.Values["ColorForceB"] = (int)ColorForce.B;

            FileManager.LocalSettings.Values["LineForceDashCap"] = (int)LineForce.DashCap;
            FileManager.LocalSettings.Values["LineForceDashOffset"] = (float)LineForce.DashOffset;
            FileManager.LocalSettings.Values["LineForceDashStyle"] = (int)LineForce.DashStyle;
            FileManager.LocalSettings.Values["LineForceEndCap"] = (int)LineForce.EndCap;
            FileManager.LocalSettings.Values["LineForceLineJoin"] = (int)LineForce.LineJoin;
            FileManager.LocalSettings.Values["LineForceMiterLimit"] = (float)LineForce.MiterLimit;
            FileManager.LocalSettings.Values["LineForceStartCap"] = (int)LineForce.StartCap;
            FileManager.LocalSettings.Values["LineForceWeight"] = (float)LineForceWeight;
            FileManager.LocalSettings.Values["ColorReactionA"] = (int)ColorReaction.A;
            FileManager.LocalSettings.Values["ColorReactionR"] = (int)ColorReaction.R;
            FileManager.LocalSettings.Values["ColorReactionG"] = (int)ColorReaction.G;
            FileManager.LocalSettings.Values["ColorReactionB"] = (int)ColorReaction.B;

            FileManager.LocalSettings.Values["LineReactionDashCap"] = (int)LineReaction.DashCap;
            FileManager.LocalSettings.Values["LineReactionDashOffset"] = (float)LineReaction.DashOffset;
            FileManager.LocalSettings.Values["LineReactionDashStyle"] = (int)LineReaction.DashStyle;
            FileManager.LocalSettings.Values["LineReactionEndCap"] = (int)LineReaction.EndCap;
            FileManager.LocalSettings.Values["LineReactionLineJoin"] = (int)LineReaction.LineJoin;
            FileManager.LocalSettings.Values["LineReactionMiterLimit"] = (float)LineReaction.MiterLimit;
            FileManager.LocalSettings.Values["LineReactionStartCap"] = (int)LineReaction.StartCap;
            FileManager.LocalSettings.Values["LineReactionWeight"] = (float)LineReactionWeight;
            FileManager.LocalSettings.Values["ColorShearForceSelectedA"] = (int)ColorShearForceSelected.A;
            FileManager.LocalSettings.Values["ColorShearForceSelectedR"] = (int)ColorShearForceSelected.R;
            FileManager.LocalSettings.Values["ColorShearForceSelectedG"] = (int)ColorShearForceSelected.G;
            FileManager.LocalSettings.Values["ColorShearForceSelectedB"] = (int)ColorShearForceSelected.B;

            FileManager.LocalSettings.Values["LineShearForceSelectedDashCap"] = (int)LineShearForceSelected.DashCap;
            FileManager.LocalSettings.Values["LineShearForceSelectedDashOffset"] = (float)LineShearForceSelected.DashOffset;
            FileManager.LocalSettings.Values["LineShearForceSelectedDashStyle"] = (int)LineShearForceSelected.DashStyle;
            FileManager.LocalSettings.Values["LineShearForceSelectedEndCap"] = (int)LineShearForceSelected.EndCap;
            FileManager.LocalSettings.Values["LineShearForceSelectedLineJoin"] = (int)LineShearForceSelected.LineJoin;
            FileManager.LocalSettings.Values["LineShearForceSelectedMiterLimit"] = (float)LineShearForceSelected.MiterLimit;
            FileManager.LocalSettings.Values["LineShearForceSelectedStartCap"] = (int)LineShearForceSelected.StartCap;
            FileManager.LocalSettings.Values["LineShearForceSelectedWeight"] = (float)LineShearForceSelectedWeight;
            FileManager.LocalSettings.Values["ColorShearForceA"] = (int)ColorShearForce.A;
            FileManager.LocalSettings.Values["ColorShearForceR"] = (int)ColorShearForce.R;
            FileManager.LocalSettings.Values["ColorShearForceG"] = (int)ColorShearForce.G;
            FileManager.LocalSettings.Values["ColorShearForceB"] = (int)ColorShearForce.B;

            FileManager.LocalSettings.Values["LineShearForceDashCap"] = (int)LineShearForce.DashCap;
            FileManager.LocalSettings.Values["LineShearForceDashOffset"] = (float)LineShearForce.DashOffset;
            FileManager.LocalSettings.Values["LineShearForceDashStyle"] = (int)LineShearForce.DashStyle;
            FileManager.LocalSettings.Values["LineShearForceEndCap"] = (int)LineShearForce.EndCap;
            FileManager.LocalSettings.Values["LineShearForceLineJoin"] = (int)LineShearForce.LineJoin;
            FileManager.LocalSettings.Values["LineShearForceMiterLimit"] = (float)LineShearForce.MiterLimit;
            FileManager.LocalSettings.Values["LineShearForceStartCap"] = (int)LineShearForce.StartCap;
            FileManager.LocalSettings.Values["LineShearForceWeight"] = (float)LineShearForceWeight;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedA"] = (int)ColorMomentForceSelected.A;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedR"] = (int)ColorMomentForceSelected.R;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedG"] = (int)ColorMomentForceSelected.G;
            FileManager.LocalSettings.Values["ColorMomentForceSelectedB"] = (int)ColorMomentForceSelected.B;

            FileManager.LocalSettings.Values["LineMomentForceSelectedDashCap"] = (int)LineMomentForceSelected.DashCap;
            FileManager.LocalSettings.Values["LineMomentForceSelectedDashOffset"] = (float)LineMomentForceSelected.DashOffset;
            FileManager.LocalSettings.Values["LineMomentForceSelectedDashStyle"] = (int)LineMomentForceSelected.DashStyle;
            FileManager.LocalSettings.Values["LineMomentForceSelectedEndCap"] = (int)LineMomentForceSelected.EndCap;
            FileManager.LocalSettings.Values["LineMomentForceSelectedLineJoin"] = (int)LineMomentForceSelected.LineJoin;
            FileManager.LocalSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)LineMomentForceSelected.MiterLimit;
            FileManager.LocalSettings.Values["LineMomentForceSelectedStartCap"] = (int)LineMomentForceSelected.StartCap;
            FileManager.LocalSettings.Values["LineMomentForceSelectedWeight"] = (float)LineMomentForceSelectedWeight;
            FileManager.LocalSettings.Values["ColorMomentForceA"] = (int)ColorMomentForce.A;
            FileManager.LocalSettings.Values["ColorMomentForceR"] = (int)ColorMomentForce.R;
            FileManager.LocalSettings.Values["ColorMomentForceG"] = (int)ColorMomentForce.G;
            FileManager.LocalSettings.Values["ColorMomentForceB"] = (int)ColorMomentForce.B;

            FileManager.LocalSettings.Values["LineMomentForceDashCap"] = (int)LineMomentForce.DashCap;
            FileManager.LocalSettings.Values["LineMomentForceDashOffset"] = (float)LineMomentForce.DashOffset;
            FileManager.LocalSettings.Values["LineMomentForceDashStyle"] = (int)LineMomentForce.DashStyle;
            FileManager.LocalSettings.Values["LineMomentForceEndCap"] = (int)LineMomentForce.EndCap;
            FileManager.LocalSettings.Values["LineMomentForceLineJoin"] = (int)LineMomentForce.LineJoin;
            FileManager.LocalSettings.Values["LineMomentForceMiterLimit"] = (float)LineMomentForce.MiterLimit;
            FileManager.LocalSettings.Values["LineMomentForceStartCap"] = (int)LineMomentForce.StartCap;
            FileManager.LocalSettings.Values["LineMomentForceWeight"] = (float)LineMomentForceWeight;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedA"] = (int)ColorDistributedForceSelected.A;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedR"] = (int)ColorDistributedForceSelected.R;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedG"] = (int)ColorDistributedForceSelected.G;
            FileManager.LocalSettings.Values["ColorDistributedForceSelectedB"] = (int)ColorDistributedForceSelected.B;

            FileManager.LocalSettings.Values["LineDistributedForceSelectedDashCap"] = (int)LineDistributedForceSelected.DashCap;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)LineDistributedForceSelected.DashOffset;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)LineDistributedForceSelected.DashStyle;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedEndCap"] = (int)LineDistributedForceSelected.EndCap;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)LineDistributedForceSelected.LineJoin;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)LineDistributedForceSelected.MiterLimit;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedStartCap"] = (int)LineDistributedForceSelected.StartCap;
            FileManager.LocalSettings.Values["LineDistributedForceSelectedWeight"] = (float)LineDistributedForceSelectedWeight;
            FileManager.LocalSettings.Values["ColorDistributedForceA"] = (int)ColorDistributedForce.A;
            FileManager.LocalSettings.Values["ColorDistributedForceR"] = (int)ColorDistributedForce.R;
            FileManager.LocalSettings.Values["ColorDistributedForceG"] = (int)ColorDistributedForce.G;
            FileManager.LocalSettings.Values["ColorDistributedForceB"] = (int)ColorDistributedForce.B;

            FileManager.LocalSettings.Values["LineDistributedForceDashCap"] = (int)LineDistributedForce.DashCap;
            FileManager.LocalSettings.Values["LineDistributedForceDashOffset"] = (float)LineDistributedForce.DashOffset;
            FileManager.LocalSettings.Values["LineDistributedForceDashStyle"] = (int)LineDistributedForce.DashStyle;
            FileManager.LocalSettings.Values["LineDistributedForceEndCap"] = (int)LineDistributedForce.EndCap;
            FileManager.LocalSettings.Values["LineDistributedForceLineJoin"] = (int)LineDistributedForce.LineJoin;
            FileManager.LocalSettings.Values["LineDistributedForceMiterLimit"] = (float)LineDistributedForce.MiterLimit;
            FileManager.LocalSettings.Values["LineDistributedForceStartCap"] = (int)LineDistributedForce.StartCap;
            FileManager.LocalSettings.Values["LineDistributedForceWeight"] = (float)LineDistributedForceWeight;
            FileManager.LocalSettings.Values["ColorNodeFreeA"] = (int)ColorNodeFree.A;
            FileManager.LocalSettings.Values["ColorNodeFreeR"] = (int)ColorNodeFree.R;
            FileManager.LocalSettings.Values["ColorNodeFreeG"] = (int)ColorNodeFree.G;
            FileManager.LocalSettings.Values["ColorNodeFreeB"] = (int)ColorNodeFree.B;

            FileManager.LocalSettings.Values["LineNodeFreeDashCap"] = (int)LineNodeFree.DashCap;
            FileManager.LocalSettings.Values["LineNodeFreeDashOffset"] = (float)LineNodeFree.DashOffset;
            FileManager.LocalSettings.Values["LineNodeFreeDashStyle"] = (int)LineNodeFree.DashStyle;
            FileManager.LocalSettings.Values["LineNodeFreeEndCap"] = (int)LineNodeFree.EndCap;
            FileManager.LocalSettings.Values["LineNodeFreeLineJoin"] = (int)LineNodeFree.LineJoin;
            FileManager.LocalSettings.Values["LineNodeFreeMiterLimit"] = (float)LineNodeFree.MiterLimit;
            FileManager.LocalSettings.Values["LineNodeFreeStartCap"] = (int)LineNodeFree.StartCap;
            FileManager.LocalSettings.Values["LineNodeFreeWeight"] = (float)LineNodeFreeWeight;
            FileManager.LocalSettings.Values["ColorNodeFixedA"] = (int)ColorNodeFixed.A;
            FileManager.LocalSettings.Values["ColorNodeFixedR"] = (int)ColorNodeFixed.R;
            FileManager.LocalSettings.Values["ColorNodeFixedG"] = (int)ColorNodeFixed.G;
            FileManager.LocalSettings.Values["ColorNodeFixedB"] = (int)ColorNodeFixed.B;

            FileManager.LocalSettings.Values["LineNodeFixedDashCap"] = (int)LineNodeFixed.DashCap;
            FileManager.LocalSettings.Values["LineNodeFixedDashOffset"] = (float)LineNodeFixed.DashOffset;
            FileManager.LocalSettings.Values["LineNodeFixedDashStyle"] = (int)LineNodeFixed.DashStyle;
            FileManager.LocalSettings.Values["LineNodeFixedEndCap"] = (int)LineNodeFixed.EndCap;
            FileManager.LocalSettings.Values["LineNodeFixedLineJoin"] = (int)LineNodeFixed.LineJoin;
            FileManager.LocalSettings.Values["LineNodeFixedMiterLimit"] = (float)LineNodeFixed.MiterLimit;
            FileManager.LocalSettings.Values["LineNodeFixedStartCap"] = (int)LineNodeFixed.StartCap;
            FileManager.LocalSettings.Values["LineNodeFixedWeight"] = (float)LineNodeFixedWeight;
            FileManager.LocalSettings.Values["ColorNodePinA"] = (int)ColorNodePin.A;
            FileManager.LocalSettings.Values["ColorNodePinR"] = (int)ColorNodePin.R;
            FileManager.LocalSettings.Values["ColorNodePinG"] = (int)ColorNodePin.G;
            FileManager.LocalSettings.Values["ColorNodePinB"] = (int)ColorNodePin.B;

            FileManager.LocalSettings.Values["LineNodePinDashCap"] = (int)LineNodePin.DashCap;
            FileManager.LocalSettings.Values["LineNodePinDashOffset"] = (float)LineNodePin.DashOffset;
            FileManager.LocalSettings.Values["LineNodePinDashStyle"] = (int)LineNodePin.DashStyle;
            FileManager.LocalSettings.Values["LineNodePinEndCap"] = (int)LineNodePin.EndCap;
            FileManager.LocalSettings.Values["LineNodePinLineJoin"] = (int)LineNodePin.LineJoin;
            FileManager.LocalSettings.Values["LineNodePinMiterLimit"] = (float)LineNodePin.MiterLimit;
            FileManager.LocalSettings.Values["LineNodePinStartCap"] = (int)LineNodePin.StartCap;
            FileManager.LocalSettings.Values["LineNodePinWeight"] = (float)LineNodePinWeight;
            FileManager.LocalSettings.Values["ColorNodeRollerXA"] = (int)ColorNodeRollerX.A;
            FileManager.LocalSettings.Values["ColorNodeRollerXR"] = (int)ColorNodeRollerX.R;
            FileManager.LocalSettings.Values["ColorNodeRollerXG"] = (int)ColorNodeRollerX.G;
            FileManager.LocalSettings.Values["ColorNodeRollerXB"] = (int)ColorNodeRollerX.B;

            FileManager.LocalSettings.Values["LineNodeRollerXDashCap"] = (int)LineNodeRollerX.DashCap;
            FileManager.LocalSettings.Values["LineNodeRollerXDashOffset"] = (float)LineNodeRollerX.DashOffset;
            FileManager.LocalSettings.Values["LineNodeRollerXDashStyle"] = (int)LineNodeRollerX.DashStyle;
            FileManager.LocalSettings.Values["LineNodeRollerXEndCap"] = (int)LineNodeRollerX.EndCap;
            FileManager.LocalSettings.Values["LineNodeRollerXLineJoin"] = (int)LineNodeRollerX.LineJoin;
            FileManager.LocalSettings.Values["LineNodeRollerXMiterLimit"] = (float)LineNodeRollerX.MiterLimit;
            FileManager.LocalSettings.Values["LineNodeRollerXStartCap"] = (int)LineNodeRollerX.StartCap;
            FileManager.LocalSettings.Values["LineNodeRollerXWeight"] = (float)LineNodeRollerXWeight;
            FileManager.LocalSettings.Values["ColorNodeRollerYA"] = (int)ColorNodeRollerY.A;
            FileManager.LocalSettings.Values["ColorNodeRollerYR"] = (int)ColorNodeRollerY.R;
            FileManager.LocalSettings.Values["ColorNodeRollerYG"] = (int)ColorNodeRollerY.G;
            FileManager.LocalSettings.Values["ColorNodeRollerYB"] = (int)ColorNodeRollerY.B;

            FileManager.LocalSettings.Values["LineNodeRollerYDashCap"] = (int)LineNodeRollerY.DashCap;
            FileManager.LocalSettings.Values["LineNodeRollerYDashOffset"] = (float)LineNodeRollerY.DashOffset;
            FileManager.LocalSettings.Values["LineNodeRollerYDashStyle"] = (int)LineNodeRollerY.DashStyle;
            FileManager.LocalSettings.Values["LineNodeRollerYEndCap"] = (int)LineNodeRollerY.EndCap;
            FileManager.LocalSettings.Values["LineNodeRollerYLineJoin"] = (int)LineNodeRollerY.LineJoin;
            FileManager.LocalSettings.Values["LineNodeRollerYMiterLimit"] = (float)LineNodeRollerY.MiterLimit;
            FileManager.LocalSettings.Values["LineNodeRollerYStartCap"] = (int)LineNodeRollerY.StartCap;
            FileManager.LocalSettings.Values["LineNodeRollerYWeight"] = (float)LineNodeRollerYWeight;
            FileManager.LocalSettings.Values["ColorNodeOtherA"] = (int)ColorNodeOther.A;
            FileManager.LocalSettings.Values["ColorNodeOtherR"] = (int)ColorNodeOther.R;
            FileManager.LocalSettings.Values["ColorNodeOtherG"] = (int)ColorNodeOther.G;
            FileManager.LocalSettings.Values["ColorNodeOtherB"] = (int)ColorNodeOther.B;

            FileManager.LocalSettings.Values["LineNodeOtherDashCap"] = (int)LineNodeOther.DashCap;
            FileManager.LocalSettings.Values["LineNodeOtherDashOffset"] = (float)LineNodeOther.DashOffset;
            FileManager.LocalSettings.Values["LineNodeOtherDashStyle"] = (int)LineNodeOther.DashStyle;
            FileManager.LocalSettings.Values["LineNodeOtherEndCap"] = (int)LineNodeOther.EndCap;
            FileManager.LocalSettings.Values["LineNodeOtherLineJoin"] = (int)LineNodeOther.LineJoin;
            FileManager.LocalSettings.Values["LineNodeOtherMiterLimit"] = (float)LineNodeOther.MiterLimit;
            FileManager.LocalSettings.Values["LineNodeOtherStartCap"] = (int)LineNodeOther.StartCap;
            FileManager.LocalSettings.Values["LineNodeOtherWeight"] = (float)LineNodeOtherWeight;
            FileManager.LocalSettings.Values["ColorBackgroundA"] = (int)ColorBackground.A;
            FileManager.LocalSettings.Values["ColorBackgroundR"] = (int)ColorBackground.R;
            FileManager.LocalSettings.Values["ColorBackgroundG"] = (int)ColorBackground.G;
            FileManager.LocalSettings.Values["ColorBackgroundB"] = (int)ColorBackground.B;

            FileManager.LocalSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
            FileManager.LocalSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
            FileManager.LocalSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
            FileManager.LocalSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;

            FileManager.LocalSettings.Values["ColorLabelA"] = (int)ColorLabel.A;
            FileManager.LocalSettings.Values["ColorLabelR"] = (int)ColorLabel.R;
            FileManager.LocalSettings.Values["ColorLabelG"] = (int)ColorLabel.G;
            FileManager.LocalSettings.Values["ColorLabelB"] = (int)ColorLabel.B;
            FileManager.LocalSettings.Values["UnitAngle"] = (int)angle;
            FileManager.LocalSettings.Values["UnitArea"] = (int)area;
            FileManager.LocalSettings.Values["UnitDensity"] = (int)density;
            FileManager.LocalSettings.Values["UnitForce"] = (int)force;
            FileManager.LocalSettings.Values["UnitForcePerLength"] = (int)forcePerLength;
            FileManager.LocalSettings.Values["UnitLength"] = (int)length;
            FileManager.LocalSettings.Values["UnitMass"] = (int)mass;

            FileManager.LocalSettings.Values["UnitMoment"] = (int)moment;
            FileManager.LocalSettings.Values["UnitMomentOfInertia"] = (int)momentOfInertia;
            FileManager.LocalSettings.Values["UnitPressure"] = (int)pressure;

            FileManager.LocalSettings.Values["UnitVolume"] = (int)volume;
            FileManager.LocalSettings.Values["ShowMoment"] = showMoment;
            FileManager.LocalSettings.Values["ShowShear"] = showShear;
            FileManager.LocalSettings.Values["ShowForce"] = showForce;
            FileManager.LocalSettings.Values["ShowLinear"] = showLinear;
            FileManager.LocalSettings.Values["ShowAxial"] = showAxial;
            FileManager.LocalSettings.Values["ShowReactions"] = showReactions;
            FileManager.LocalSettings.Values["MemberDisplay"] = (int)memberDisplay;
            FileManager.LocalSettings.Values["AutoStartSolver"] = (bool)autoStartSolver;
            FileManager.LocalSettings.Values["AutoFinishSolver"] = (bool)autoFinishSolver;
            FileManager.LocalSettings.Values["CurrentSolver"] = (int)currentSolver;
            FileManager.LocalSettings.Values["LockNumericalInput"] = lockNumericalInput;
            FileManager.LocalSettings.Values["LoadLastFileOnStartup"] = loadLastFileOnStartup;
            FileManager.LocalSettings.Values["defaultNumberOfSegments"] = (int)defaultNumberOfSegments;
            FileManager.LocalSettings.Values["lastCurrentSection"] = (string)lastCurrentSectionName;
            FileManager.LocalSettings.Values["ResetExistingMembers"] = (bool)resetExistingMembers;
            FileManager.LocalSettings.Values["MomentFactor"] = (double)momentFactor;
            FileManager.LocalSettings.Values["ShearFactor"] = (double)shearFactor;
            FileManager.LocalSettings.Values["LinearFactor"] = (double)linearFactor;
            FileManager.LocalSettings.Values["ForcesFactor"] = (double)forcesFactor;
            FileManager.LocalSettings.Values["ReactionsFactor"] = (double)reactionsFactor;
            FileManager.LocalSettings.Values["DisplacementFactor"] = (double)displacementFactor;
        }

        #endregion
    }
}