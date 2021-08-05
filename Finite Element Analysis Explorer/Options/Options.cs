using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Microsoft.Graphics.Canvas.Geometry;
using System;

namespace Finite_Element_Analysis_Explorer
{
    internal static class Options
    {

        internal static bool FirstRun = true;


        #region Camera

        internal static float CameraZoomTrim = 500f;

        internal static float SelectGridSize = 1f;

        #endregion

        #region Lines

        internal static float LineGridNormalWeight = 1f;
        internal static CanvasStrokeStyle LineGridNormal = new CanvasStrokeStyle();

        internal static float LineGridMinorWeight = 1f;
        internal static CanvasStrokeStyle LineGridMinor = new CanvasStrokeStyle();

        internal static float LineGridMajorWeight = 1f;
        internal static CanvasStrokeStyle LineGridMajor = new CanvasStrokeStyle();

        internal static float LineForceWeight = 5f;
        internal static CanvasStrokeStyle LineForce = new CanvasStrokeStyle();

        internal static float LineReactionWeight = 5f;
        internal static CanvasStrokeStyle LineReaction = new CanvasStrokeStyle();

        internal static float LineSelectedElementWeight = 2.8f;
        internal static CanvasStrokeStyle LineSelectedElement = new CanvasStrokeStyle();

        internal static float LineShearForceSelectedWeight = 2.8f;
        internal static CanvasStrokeStyle LineShearForceSelected = new CanvasStrokeStyle();

        internal static float LineMomentForceSelectedWeight = 2.8f;
        internal static CanvasStrokeStyle LineMomentForceSelected = new CanvasStrokeStyle();

        internal static float LineShearForceFontWeight = 2.8f;
        internal static CanvasStrokeStyle LineShearForceFont = new CanvasStrokeStyle();

        internal static float LineMomentForceFontWeight = 2.8f;
        internal static CanvasStrokeStyle LineMomentForceFont = new CanvasStrokeStyle();


        internal static float LineShearForceWeight = 1.5f;
        internal static CanvasStrokeStyle LineShearForce = new CanvasStrokeStyle();

        internal static float LineMomentForceWeight = 1.5f;
        internal static CanvasStrokeStyle LineMomentForce = new CanvasStrokeStyle();

        internal static float LineDistributedForceWeight = 1.5f;
        internal static CanvasStrokeStyle LineDistributedForce = new CanvasStrokeStyle();

        internal static float LineDistributedForceSelectedWeight = 1.8f;
        internal static CanvasStrokeStyle LineDistributedForceSelected = new CanvasStrokeStyle();

        internal static float LineNodeFreeWeight = 1f;
        internal static CanvasStrokeStyle LineNodeFree = new CanvasStrokeStyle();

        internal static float LineNodeFixedWeight = 1f;
        internal static CanvasStrokeStyle LineNodeFixed = new CanvasStrokeStyle();

        internal static float LineNodePinWeight = 1f;
        internal static CanvasStrokeStyle LineNodePin = new CanvasStrokeStyle();

        internal static float LineNodeRollerXWeight = 1f;
        internal static CanvasStrokeStyle LineNodeRollerX = new CanvasStrokeStyle();

        internal static float LineNodeRollerYWeight = 1f;
        internal static CanvasStrokeStyle LineNodeRollerY = new CanvasStrokeStyle();

        internal static float LineNodeOtherWeight = 1f;
        internal static CanvasStrokeStyle LineNodeOther = new CanvasStrokeStyle();

        #endregion

        #region Colors

        //
        internal static string ColorToEdit;


        #region Dark Colors

        //Custom Colors.
        internal static Color ColorBackground = Color.FromArgb(255, 8, 28, 88);
        internal static Color ColorLabel = Color.FromArgb(255, 255, 255, 255);

        //internal static Color ColorBackground = Color.FromArgb(255, 128,128,128);

        internal static Color ColorForce = Color.FromArgb(255, 255, 255, 0);
        internal static Color ColorReaction = Color.FromArgb(255, 255, 0, 0);


        internal static Color ColorGridNormal = Color.FromArgb(192, 48, 48, 96);
        internal static Color ColorGridMinor = Color.FromArgb(192, 48, 48, 48);
        internal static Color ColorGridMajor = Color.FromArgb(192, 48, 96, 48);
        internal static Color ColorGridMajorFont = Color.FromArgb(255, 48, 48, 156);

        internal static Color ColorSelectedNode = Color.FromArgb(255, 64, 64, 255);
        internal static Color ColorSelectedElement = Color.FromArgb(255, 255, 0, 255);

        internal static Color ColorShearForceSelected = Color.FromArgb(255, 64, 64, 255);
        internal static Color ColorMomentForceSelected = Color.FromArgb(255, 0, 255, 0);
        internal static Color ColorDistributedForceSelected = Color.FromArgb(255, 255, 255, 64);

        internal static Color ColorShearForceFont = Color.FromArgb(255, 128, 128, 255);
        internal static Color ColorMomentForceFont = Color.FromArgb(255, 64, 255, 64);

        internal static Color ColorShearForce = Color.FromArgb(128, 0, 0, 255);
        internal static Color ColorMomentForce = Color.FromArgb(128, 0, 255, 0);
        internal static Color ColorDistributedForce = Color.FromArgb(128, 255, 255, 0);

        internal static Color ColorNodeFree = Color.FromArgb(255, 0, 0, 0);
        internal static Color ColorNodeFixed = Color.FromArgb(255, 192, 192, 192);
        internal static Color ColorNodePin = Color.FromArgb(255, 192, 192, 192);
        internal static Color ColorNodeRollerX = Color.FromArgb(255, 192, 192, 192);
        internal static Color ColorNodeRollerY = Color.FromArgb(255, 192, 192, 192);
        internal static Color ColorNodeOther = Color.FromArgb(255, 0, 0, 0);

        #endregion

        #region Light Colors (Printing)

        ////Custom Colors.
        //internal static Color ColorBackground = Color.FromArgb(255, 255, 255, 255);
        //internal static Color ColorLabel = Color.FromArgb(255, 0,0,0);
        
        //internal static Color ColorForce = Color.FromArgb(255, 255,255, 0);
        //internal static Color ColorReaction = Color.FromArgb(255, 255, 0, 0);

        //internal static Color ColorGridNormal = Color.FromArgb(255, 192, 192, 192);
        //internal static Color ColorGridMinor = Color.FromArgb(255,192,192,192);
        //internal static Color ColorGridMajor = Color.FromArgb(255, 192, 192, 192);
        //internal static Color ColorGridMajorFont = Color.FromArgb(255, 48, 48, 156);

        //internal static Color ColorSelectedNode = Color.FromArgb(255, 255, 0, 255);
        //internal static Color ColorSelectedElement = Color.FromArgb(255, 255, 0, 255);

        //internal static Color ColorShearForceSelected = Color.FromArgb(255, 64, 64, 255);
        //internal static Color ColorMomentForceSelected = Color.FromArgb(255, 64, 255, 64);
        //internal static Color ColorDistributedForceSelected = Color.FromArgb(255, 255, 255, 64);

        //internal static Color ColorShearForceFont = Color.FromArgb(255, 0, 0, 128);
        //internal static Color ColorMomentForceFont = Color.FromArgb(255, 0, 128, 0);

        //internal static Color ColorShearForce = Color.FromArgb(128, 0, 0, 255);
        //internal static Color ColorMomentForce = Color.FromArgb(128, 0, 255, 0);
        //internal static Color ColorDistributedForce = Color.FromArgb(128, 255, 255, 0);

        //internal static Color ColorNodeFree = Color.FromArgb(255, 0, 0, 0);
        //internal static Color ColorNodeFixed = Color.FromArgb(255, 128,128,128);
        //internal static Color ColorNodePin = Color.FromArgb(255, 128, 128, 128);
        //internal static Color ColorNodeRollerX = Color.FromArgb(255, 128, 128, 128);
        //internal static Color ColorNodeRollerY = Color.FromArgb(255, 128, 128, 128);
        //internal static Color ColorNodeOther = Color.FromArgb(255, 0, 0, 0);

        #endregion
        
        #endregion

        #region General

        private static bool lockNumericalInput = false;
        public static bool LockNumericalInput
        {
            get { return lockNumericalInput; }
            set { lockNumericalInput = value; }
        }

        private static decimal lastNumericalInput = 0;
        public static decimal LastNumericalInput
        {
            get { return lastNumericalInput; }
            set { lastNumericalInput = value; }
        }

        private static bool loadLastFileOnStartup = true;
        internal static bool LoadLastFileOnStartup
        {
            get
            {
                return loadLastFileOnStartup;
            }
            //set { loadLastFileOnStartup = value; }
        }

        private static int defaultNumberOfSegments = 10;
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
        internal static string LastCurrentSectionName
        {
            get
            {


                return lastCurrentSectionName;
            }
            //set { lastCurrentSectionName = value; }
        }

        private static bool resetExistingMembers = true;
        public static bool ResetExistingMembers
        {
            get { return resetExistingMembers; }
            set { resetExistingMembers = value; }
        }

        #endregion

        #region Units

        private static AngleType angle = AngleType.Radians;
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
                    case LengthType.mil:
                        break;
                    case LengthType.mile:
                        break;
                    case LengthType.Millimeter:
                        Camera.LengthUnitFactor = (float)Constants.MilliMeterPerMeter;
                        break;
                    case LengthType.yard:
                        break;
                }
            }
        }

        private static VolumeType volume = VolumeType.CubicMetre;
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
        public static ForceType Force
        {
            get { return force; }
            set { force = value; }
        }

        private static ForcePerLengthType forcePerLength;
        public static ForcePerLengthType ForcePerLength
        {
            get { return forcePerLength; }
            set { forcePerLength = value; }
        }

        #endregion

        #region Show

        private static bool showMoment = true;
        internal static bool ShowMoment
        {
            get
            { return showMoment; }
            set
            { showMoment = value; }
        }

        private static bool showShear = true;
        internal static bool ShowShear
        {
            get { return showShear; }
            set { showShear = value; }
        }

        private static bool showForce = true;
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
        internal static bool ShowAxial
        {
            //get { return showAxial; }
            set
            {
                showAxial = value;
            }
        }

        private static bool showReactions;
        public static bool ShowReactions
        {
            get { return showReactions; }
            set { showReactions = value; }
        }

        private static int memberDisplay = 0;
        public static int MemberDisplay
        {
            get { return memberDisplay; }
            set { memberDisplay = value; }
        }

        #endregion

        #region Factors

        private static float momentFactor = 0.0001f;
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
        public static int CurrentSolver
        {
            get { return currentSolver; }
            set { currentSolver = value; }
        }

        #endregion

        #region Methods

        internal static void LoadOptions()
        {
            if (FileManager.localSettings.Values["FirstRun"] is object)
            {
                FirstRun = (bool)FileManager.localSettings.Values["FirstRun"];
            }
            else
            {
                FileManager.localSettings.Values["FirstRun"] = (bool)true;
                FirstRun = true;
            }

            if (FirstRun)
            {
                FileManager.localSettings.Values["UnitAngle"] = (int)AngleType.Degrees;
                angle = AngleType.Degrees;
                FileManager.localSettings.Values["UnitArea"] = (int)AreaType.SquareMetre;
                area = AreaType.SquareMetre;
                FileManager.localSettings.Values["UnitDensity"] = (int)DensityType.KilogramPerCubicMetre;
                density = DensityType.KilogramPerCubicMetre;
                FileManager.localSettings.Values["UnitForce"] = (int)ForceType.Newton;
                force = ForceType.Newton;
                FileManager.localSettings.Values["UnitForcePerLength"] = (int)ForcePerLengthType.NewtonPerMeter;
                forcePerLength = ForcePerLengthType.NewtonPerMeter;
                FileManager.localSettings.Values["UnitLength"] = (int)LengthType.Meter;
                Length = LengthType.Meter;
                FileManager.localSettings.Values["UnitMass"] = (int)MassType.Kilogram;
                mass = MassType.Kilogram;
                FileManager.localSettings.Values["UnitMoment"] = (int)MomentType.NewtonMetre;
                moment = MomentType.NewtonMetre;
                FileManager.localSettings.Values["UnitMomentOfInertia"] = (int)MomentOfInertiaType.QuadMeter;
                momentOfInertia = MomentOfInertiaType.QuadMeter;
                FileManager.localSettings.Values["UnitPressure"] = (int)PressureType.Pascal;
                pressure = PressureType.Pascal;
                FileManager.localSettings.Values["UnitVolume"] = (int)VolumeType.CubicMetre;
                volume = VolumeType.CubicMetre;
                FileManager.localSettings.Values["ShowMoment"] = true;
                showMoment = true;
                FileManager.localSettings.Values["ShowShear"] = true;
                showShear = true;
                FileManager.localSettings.Values["ShowForce"] = true;
                showForce = true;
                FileManager.localSettings.Values["ShowLinear"] = true;
                showLinear = true;
                FileManager.localSettings.Values["ShowAxial"] = true;
                showAxial = true;
                FileManager.localSettings.Values["ShowReactions"] = true;
                showReactions = true;
                FileManager.localSettings.Values["MemberDisplay"] = 0;
                memberDisplay = 0;
                FileManager.localSettings.Values["AutoStartSolver"] = true;
                autoStartSolver = true;
                FileManager.localSettings.Values["AutoFinishSolver"] = true;
                autoFinishSolver = true;
                currentSolver = 0;
                FileManager.localSettings.Values["CurrentSolver"] = (int)currentSolver;
                FileManager.localSettings.Values["LockNumericalInput"] = false;
                lockNumericalInput = false;
                FileManager.localSettings.Values["LoadLastFileOnStartup"] = true;
                loadLastFileOnStartup = true;
                FileManager.localSettings.Values["defaultNumberOfSegments"] = (int)defaultNumberOfSegments;
                defaultNumberOfSegments = 10;
                FileManager.localSettings.Values["ResetExistingMembers"] = true;
                resetExistingMembers = true;
                FileManager.localSettings.Values["lastCurrentSection"] = "Default";
                lastCurrentSectionName = "Default";
                FileManager.localSettings.Values["ColorBackgroundA"] = (int)ColorBackground.A;
                FileManager.localSettings.Values["ColorBackgroundR"] = (int)ColorBackground.R;
                FileManager.localSettings.Values["ColorBackgroundG"] = (int)ColorBackground.G;
                FileManager.localSettings.Values["ColorBackgroundB"] = (int)ColorBackground.B;
                FileManager.localSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
                FileManager.localSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
                FileManager.localSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
                FileManager.localSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;
                FileManager.localSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
                FileManager.localSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
                FileManager.localSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
                FileManager.localSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;
                FileManager.localSettings.Values["ColorLabelA"] = (int)ColorLabel.A;
                FileManager.localSettings.Values["ColorLabelR"] = (int)ColorLabel.R;
                FileManager.localSettings.Values["ColorLabelG"] = (int)ColorLabel.G;
                FileManager.localSettings.Values["ColorLabelB"] = (int)ColorLabel.B;
                FileManager.localSettings.Values["ColorGridNormalA"] = (int)ColorGridNormal.A;
                FileManager.localSettings.Values["ColorGridNormalR"] = (int)ColorGridNormal.R;
                FileManager.localSettings.Values["ColorGridNormalG"] = (int)ColorGridNormal.G;
                FileManager.localSettings.Values["ColorGridNormalB"] = (int)ColorGridNormal.B;

                LineGridNormal.DashCap = CanvasCapStyle.Round;
                LineGridNormal.DashOffset = 0;
                LineGridNormal.DashStyle = CanvasDashStyle.Solid;
                LineGridNormal.EndCap = CanvasCapStyle.Flat;
                LineGridNormal.LineJoin = CanvasLineJoin.Bevel;
                LineGridNormal.MiterLimit = 0;
                LineGridNormal.StartCap = CanvasCapStyle.Flat;
                LineGridNormalWeight = 1;

                FileManager.localSettings.Values["LineGridNormalDashCap"] = (int)LineGridNormal.DashCap;
                FileManager.localSettings.Values["LineGridNormalDashOffset"] = (float)LineGridNormal.DashOffset;
                FileManager.localSettings.Values["LineGridNormalDashStyle"] = (int)LineGridNormal.DashStyle;
                FileManager.localSettings.Values["LineGridNormalEndCap"] = (int)LineGridNormal.EndCap;

                FileManager.localSettings.Values["LineGridNormalLineJoin"] = (int)LineGridNormal.LineJoin;
                FileManager.localSettings.Values["LineGridNormalMiterLimit"] = (float)LineGridNormal.MiterLimit;
                FileManager.localSettings.Values["LineGridNormalStartCap"] = (int)LineGridNormal.StartCap;
                FileManager.localSettings.Values["LineGridNormalWeight"] = (float)LineGridNormalWeight;

                FileManager.localSettings.Values["ColorGridMinorA"] = (int)ColorGridMinor.A;
                FileManager.localSettings.Values["ColorGridMinorR"] = (int)ColorGridMinor.R;
                FileManager.localSettings.Values["ColorGridMinorG"] = (int)ColorGridMinor.G;
                FileManager.localSettings.Values["ColorGridMinorB"] = (int)ColorGridMinor.B;

                LineGridMinor.DashCap = CanvasCapStyle.Round;
                LineGridMinor.DashOffset = 0;
                LineGridMinor.DashStyle = CanvasDashStyle.Solid;
                LineGridMinor.EndCap = CanvasCapStyle.Flat;
                LineGridMinor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMinor.MiterLimit = 0;
                LineGridMinor.StartCap = CanvasCapStyle.Flat;
                LineGridMinorWeight = 1;

                FileManager.localSettings.Values["LineGridMinorDashCap"] = (int)LineGridMinor.DashCap;
                FileManager.localSettings.Values["LineGridMinorDashOffset"] = (float)LineGridMinor.DashOffset;
                FileManager.localSettings.Values["LineGridMinorDashStyle"] = (int)LineGridMinor.DashStyle;
                FileManager.localSettings.Values["LineGridMinorEndCap"] = (int)LineGridMinor.EndCap;

                FileManager.localSettings.Values["LineGridMinorLineJoin"] = (int)LineGridMinor.LineJoin;
                FileManager.localSettings.Values["LineGridMinorMiterLimit"] = (float)LineGridMinor.MiterLimit;
                FileManager.localSettings.Values["LineGridMinorStartCap"] = (int)LineGridMinor.StartCap;
                FileManager.localSettings.Values["LineGridMinorWeight"] = (float)LineGridMinorWeight;

                FileManager.localSettings.Values["ColorGridMajorA"] = (int)ColorGridMajor.A;
                FileManager.localSettings.Values["ColorGridMajorR"] = (int)ColorGridMajor.R;
                FileManager.localSettings.Values["ColorGridMajorG"] = (int)ColorGridMajor.G;
                FileManager.localSettings.Values["ColorGridMajorB"] = (int)ColorGridMajor.B;

                LineGridMajor.DashCap = CanvasCapStyle.Round;
                LineGridMajor.DashOffset = 0;
                LineGridMajor.DashStyle = CanvasDashStyle.Solid;
                LineGridMajor.EndCap = CanvasCapStyle.Flat;
                LineGridMajor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMajor.MiterLimit = 0;
                LineGridMajor.StartCap = CanvasCapStyle.Flat;
                LineGridMajorWeight = 1;

                FileManager.localSettings.Values["LineGridMajorDashCap"] = (int)LineGridMajor.DashCap;
                FileManager.localSettings.Values["LineGridMajorDashOffset"] = (float)LineGridMajor.DashOffset;
                FileManager.localSettings.Values["LineGridMajorDashStyle"] = (int)LineGridMajor.DashStyle;
                FileManager.localSettings.Values["LineGridMajorEndCap"] = (int)LineGridMajor.EndCap;

                FileManager.localSettings.Values["LineGridMajorLineJoin"] = (int)LineGridMajor.LineJoin;
                FileManager.localSettings.Values["LineGridMajorMiterLimit"] = (float)LineGridMajor.MiterLimit;
                FileManager.localSettings.Values["LineGridMajorStartCap"] = (int)LineGridMajor.StartCap;
                FileManager.localSettings.Values["LineGridMajorWeight"] = (float)LineGridMajorWeight;

                FileManager.localSettings.Values["ColorForceA"] = (int)ColorForce.A;
                FileManager.localSettings.Values["ColorForceR"] = (int)ColorForce.R;
                FileManager.localSettings.Values["ColorForceG"] = (int)ColorForce.G;
                FileManager.localSettings.Values["ColorForceB"] = (int)ColorForce.B;

                LineForce.DashCap = CanvasCapStyle.Round;
                LineForce.DashOffset = 0;
                LineForce.DashStyle = CanvasDashStyle.Solid;
                LineForce.EndCap = CanvasCapStyle.Flat;
                LineForce.LineJoin = CanvasLineJoin.Bevel;
                LineForce.MiterLimit = 0;
                LineForce.StartCap = CanvasCapStyle.Round;
                LineForceWeight = 5f;

                FileManager.localSettings.Values["LineForceDashCap"] = (int)LineForce.DashCap;
                FileManager.localSettings.Values["LineForceDashOffset"] = (float)LineForce.DashOffset;
                FileManager.localSettings.Values["LineForceDashStyle"] = (int)LineForce.DashStyle;
                FileManager.localSettings.Values["LineForceEndCap"] = (int)LineForce.EndCap;

                FileManager.localSettings.Values["LineForceLineJoin"] = (int)LineForce.LineJoin;
                FileManager.localSettings.Values["LineForceMiterLimit"] = (float)LineForce.MiterLimit;
                FileManager.localSettings.Values["LineForceStartCap"] = (int)LineForce.StartCap;
                FileManager.localSettings.Values["LineForceWeight"] = (float)LineForceWeight;

                FileManager.localSettings.Values["ColorReactionA"] = (int)ColorReaction.A;
                FileManager.localSettings.Values["ColorReactionR"] = (int)ColorReaction.R;
                FileManager.localSettings.Values["ColorReactionG"] = (int)ColorReaction.G;
                FileManager.localSettings.Values["ColorReactionB"] = (int)ColorReaction.B;

                LineReaction.DashCap = CanvasCapStyle.Round;
                LineReaction.DashOffset = 0;
                LineReaction.DashStyle = CanvasDashStyle.Solid;
                LineReaction.EndCap = CanvasCapStyle.Flat;
                LineReaction.LineJoin = CanvasLineJoin.Bevel;
                LineReaction.MiterLimit = 0;
                LineReaction.StartCap = CanvasCapStyle.Round;
                LineReactionWeight = 5f;

                FileManager.localSettings.Values["LineReactionDashCap"] = (int)LineReaction.DashCap;
                FileManager.localSettings.Values["LineReactionDashOffset"] = (float)LineReaction.DashOffset;
                FileManager.localSettings.Values["LineReactionDashStyle"] = (int)LineReaction.DashStyle;
                FileManager.localSettings.Values["LineReactionEndCap"] = (int)LineReaction.EndCap;

                FileManager.localSettings.Values["LineReactionLineJoin"] = (int)LineReaction.LineJoin;
                FileManager.localSettings.Values["LineReactionMiterLimit"] = (float)LineReaction.MiterLimit;
                FileManager.localSettings.Values["LineReactionStartCap"] = (int)LineReaction.StartCap;
                FileManager.localSettings.Values["LineReactionWeight"] = (float)LineReactionWeight;

                FileManager.localSettings.Values["ColorSelectedElementA"] = (int)ColorSelectedElement.A;
                FileManager.localSettings.Values["ColorSelectedElementR"] = (int)ColorSelectedElement.R;
                FileManager.localSettings.Values["ColorSelectedElementG"] = (int)ColorSelectedElement.G;
                FileManager.localSettings.Values["ColorSelectedElementB"] = (int)ColorSelectedElement.B;

                LineSelectedElement.DashCap = CanvasCapStyle.Round;
                LineSelectedElement.DashOffset = 0;
                LineSelectedElement.DashStyle = CanvasDashStyle.Solid;
                LineSelectedElement.EndCap = CanvasCapStyle.Flat;
                LineSelectedElement.LineJoin = CanvasLineJoin.Bevel;
                LineSelectedElement.MiterLimit = 0;
                LineSelectedElement.StartCap = CanvasCapStyle.Flat;
                LineSelectedElementWeight = 2.4f;

                FileManager.localSettings.Values["LineSelectedElementDashCap"] = (int)LineSelectedElement.DashCap;
                FileManager.localSettings.Values["LineSelectedElementDashOffset"] = (float)LineSelectedElement.DashOffset;
                FileManager.localSettings.Values["LineSelectedElementDashStyle"] = (int)LineSelectedElement.DashStyle;
                FileManager.localSettings.Values["LineSelectedElementEndCap"] = (int)LineSelectedElement.EndCap;

                FileManager.localSettings.Values["LineSelectedElementLineJoin"] = (int)LineSelectedElement.LineJoin;
                FileManager.localSettings.Values["LineSelectedElementMiterLimit"] = (float)LineSelectedElement.MiterLimit;
                FileManager.localSettings.Values["LineSelectedElementStartCap"] = (int)LineSelectedElement.StartCap;
                FileManager.localSettings.Values["LineSelectedElementWeight"] = (float)LineSelectedElementWeight;

                FileManager.localSettings.Values["ColorShearForceSelectedA"] = (int)ColorShearForceSelected.A;
                FileManager.localSettings.Values["ColorShearForceSelectedR"] = (int)ColorShearForceSelected.R;
                FileManager.localSettings.Values["ColorShearForceSelectedG"] = (int)ColorShearForceSelected.G;
                FileManager.localSettings.Values["ColorShearForceSelectedB"] = (int)ColorShearForceSelected.B;

                LineShearForceSelected.DashCap = CanvasCapStyle.Round;
                LineShearForceSelected.DashOffset = 0;
                LineShearForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineShearForceSelected.EndCap = CanvasCapStyle.Flat;
                LineShearForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceSelected.MiterLimit = 0;
                LineShearForceSelected.StartCap = CanvasCapStyle.Flat;
                LineShearForceSelectedWeight = 2.4f;

                FileManager.localSettings.Values["LineShearForceSelectedDashCap"] = (int)LineShearForceSelected.DashCap;
                FileManager.localSettings.Values["LineShearForceSelectedDashOffset"] = (float)LineShearForceSelected.DashOffset;
                FileManager.localSettings.Values["LineShearForceSelectedDashStyle"] = (int)LineShearForceSelected.DashStyle;
                FileManager.localSettings.Values["LineShearForceSelectedEndCap"] = (int)LineShearForceSelected.EndCap;

                FileManager.localSettings.Values["LineShearForceSelectedLineJoin"] = (int)LineShearForceSelected.LineJoin;
                FileManager.localSettings.Values["LineShearForceSelectedMiterLimit"] = (float)LineShearForceSelected.MiterLimit;
                FileManager.localSettings.Values["LineShearForceSelectedStartCap"] = (int)LineShearForceSelected.StartCap;
                FileManager.localSettings.Values["LineShearForceSelectedWeight"] = (float)LineShearForceSelectedWeight;

                FileManager.localSettings.Values["ColorMomentForceSelectedA"] = (int)ColorMomentForceSelected.A;
                FileManager.localSettings.Values["ColorMomentForceSelectedR"] = (int)ColorMomentForceSelected.R;
                FileManager.localSettings.Values["ColorMomentForceSelectedG"] = (int)ColorMomentForceSelected.G;
                FileManager.localSettings.Values["ColorMomentForceSelectedB"] = (int)ColorMomentForceSelected.B;

                LineMomentForceSelected.DashCap = CanvasCapStyle.Round;
                LineMomentForceSelected.DashOffset = 0;
                LineMomentForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceSelected.EndCap = CanvasCapStyle.Flat;
                LineMomentForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceSelected.MiterLimit = 0;
                LineMomentForceSelected.StartCap = CanvasCapStyle.Flat;
                LineMomentForceSelectedWeight = 2.4f;

                FileManager.localSettings.Values["LineMomentForceSelectedDashCap"] = (int)LineMomentForceSelected.DashCap;
                FileManager.localSettings.Values["LineMomentForceSelectedDashOffset"] = (float)LineMomentForceSelected.DashOffset;
                FileManager.localSettings.Values["LineMomentForceSelectedDashStyle"] = (int)LineMomentForceSelected.DashStyle;
                FileManager.localSettings.Values["LineMomentForceSelectedEndCap"] = (int)LineMomentForceSelected.EndCap;

                FileManager.localSettings.Values["LineMomentForceSelectedLineJoin"] = (int)LineMomentForceSelected.LineJoin;
                FileManager.localSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)LineMomentForceSelected.MiterLimit;
                FileManager.localSettings.Values["LineMomentForceSelectedStartCap"] = (int)LineMomentForceSelected.StartCap;
                FileManager.localSettings.Values["LineMomentForceSelectedWeight"] = (float)LineMomentForceSelectedWeight;

                FileManager.localSettings.Values["ColorShearForceFontA"] = (int)ColorShearForceFont.A;
                FileManager.localSettings.Values["ColorShearForceFontR"] = (int)ColorShearForceFont.R;
                FileManager.localSettings.Values["ColorShearForceFontG"] = (int)ColorShearForceFont.G;
                FileManager.localSettings.Values["ColorShearForceFontB"] = (int)ColorShearForceFont.B;

                LineShearForceFont.DashCap = CanvasCapStyle.Round;
                LineShearForceFont.DashOffset = 0;
                LineShearForceFont.DashStyle = CanvasDashStyle.Solid;
                LineShearForceFont.EndCap = CanvasCapStyle.Flat;
                LineShearForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceFont.MiterLimit = 0;
                LineShearForceFont.StartCap = CanvasCapStyle.Flat;
                LineShearForceFontWeight = 2.4f;

                FileManager.localSettings.Values["LineShearForceFontDashCap"] = (int)LineShearForceFont.DashCap;
                FileManager.localSettings.Values["LineShearForceFontDashOffset"] = (float)LineShearForceFont.DashOffset;
                FileManager.localSettings.Values["LineShearForceFontDashStyle"] = (int)LineShearForceFont.DashStyle;
                FileManager.localSettings.Values["LineShearForceFontEndCap"] = (int)LineShearForceFont.EndCap;

                FileManager.localSettings.Values["LineShearForceFontLineJoin"] = (int)LineShearForceFont.LineJoin;
                FileManager.localSettings.Values["LineShearForceFontMiterLimit"] = (float)LineShearForceFont.MiterLimit;
                FileManager.localSettings.Values["LineShearForceFontStartCap"] = (int)LineShearForceFont.StartCap;
                FileManager.localSettings.Values["LineShearForceFontWeight"] = (float)LineShearForceFontWeight;

                FileManager.localSettings.Values["ColorMomentForceFontA"] = (int)ColorMomentForceFont.A;
                FileManager.localSettings.Values["ColorMomentForceFontR"] = (int)ColorMomentForceFont.R;
                FileManager.localSettings.Values["ColorMomentForceFontG"] = (int)ColorMomentForceFont.G;
                FileManager.localSettings.Values["ColorMomentForceFontB"] = (int)ColorMomentForceFont.B;

                LineMomentForceFont.DashCap = CanvasCapStyle.Round;
                LineMomentForceFont.DashOffset = 0;
                LineMomentForceFont.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceFont.EndCap = CanvasCapStyle.Flat;
                LineMomentForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceFont.MiterLimit = 0;
                LineMomentForceFont.StartCap = CanvasCapStyle.Flat;
                LineMomentForceFontWeight = 2.4f;

                FileManager.localSettings.Values["LineMomentForceFontDashCap"] = (int)LineMomentForceFont.DashCap;
                FileManager.localSettings.Values["LineMomentForceFontDashOffset"] = (float)LineMomentForceFont.DashOffset;
                FileManager.localSettings.Values["LineMomentForceFontDashStyle"] = (int)LineMomentForceFont.DashStyle;
                FileManager.localSettings.Values["LineMomentForceFontEndCap"] = (int)LineMomentForceFont.EndCap;

                FileManager.localSettings.Values["LineMomentForceFontLineJoin"] = (int)LineMomentForceFont.LineJoin;
                FileManager.localSettings.Values["LineMomentForceFontMiterLimit"] = (float)LineMomentForceFont.MiterLimit;
                FileManager.localSettings.Values["LineMomentForceFontStartCap"] = (int)LineMomentForceFont.StartCap;
                FileManager.localSettings.Values["LineMomentForceFontWeight"] = (float)LineMomentForceFontWeight;

                FileManager.localSettings.Values["ColorShearForceA"] = (int)ColorShearForce.A;
                FileManager.localSettings.Values["ColorShearForceR"] = (int)ColorShearForce.R;
                FileManager.localSettings.Values["ColorShearForceG"] = (int)ColorShearForce.G;
                FileManager.localSettings.Values["ColorShearForceB"] = (int)ColorShearForce.B;

                LineShearForce.DashCap = CanvasCapStyle.Round;
                LineShearForce.DashOffset = 0;
                LineShearForce.DashStyle = CanvasDashStyle.Solid;
                LineShearForce.EndCap = CanvasCapStyle.Flat;
                LineShearForce.LineJoin = CanvasLineJoin.Bevel;
                LineShearForce.MiterLimit = 0;
                LineShearForce.StartCap = CanvasCapStyle.Flat;
                LineShearForceWeight = 1.5f;

                FileManager.localSettings.Values["LineShearForceDashCap"] = (int)LineShearForce.DashCap;
                FileManager.localSettings.Values["LineShearForceDashOffset"] = (float)LineShearForce.DashOffset;
                FileManager.localSettings.Values["LineShearForceDashStyle"] = (int)LineShearForce.DashStyle;
                FileManager.localSettings.Values["LineShearForceEndCap"] = (int)LineShearForce.EndCap;

                FileManager.localSettings.Values["LineShearForceLineJoin"] = (int)LineShearForce.LineJoin;
                FileManager.localSettings.Values["LineShearForceMiterLimit"] = (float)LineShearForce.MiterLimit;
                FileManager.localSettings.Values["LineShearForceStartCap"] = (int)LineShearForce.StartCap;
                FileManager.localSettings.Values["LineShearForceWeight"] = (float)LineShearForceWeight;

                FileManager.localSettings.Values["ColorMomentForceA"] = (int)ColorMomentForce.A;
                FileManager.localSettings.Values["ColorMomentForceR"] = (int)ColorMomentForce.R;
                FileManager.localSettings.Values["ColorMomentForceG"] = (int)ColorMomentForce.G;
                FileManager.localSettings.Values["ColorMomentForceB"] = (int)ColorMomentForce.B;

                LineMomentForce.DashCap = CanvasCapStyle.Round;
                LineMomentForce.DashOffset = 0;
                LineMomentForce.DashStyle = CanvasDashStyle.Solid;
                LineMomentForce.EndCap = CanvasCapStyle.Flat;
                LineMomentForce.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForce.MiterLimit = 0;
                LineMomentForce.StartCap = CanvasCapStyle.Flat;
                LineMomentForceWeight = 1.5f;

                FileManager.localSettings.Values["LineMomentForceDashCap"] = (int)LineMomentForce.DashCap;
                FileManager.localSettings.Values["LineMomentForceDashOffset"] = (float)LineMomentForce.DashOffset;
                FileManager.localSettings.Values["LineMomentForceDashStyle"] = (int)LineMomentForce.DashStyle;
                FileManager.localSettings.Values["LineMomentForceEndCap"] = (int)LineMomentForce.EndCap;

                FileManager.localSettings.Values["LineMomentForceLineJoin"] = (int)LineMomentForce.LineJoin;
                FileManager.localSettings.Values["LineMomentForceMiterLimit"] = (float)LineMomentForce.MiterLimit;
                FileManager.localSettings.Values["LineMomentForceStartCap"] = (int)LineMomentForce.StartCap;
                FileManager.localSettings.Values["LineMomentForceWeight"] = (float)LineMomentForceWeight;

                FileManager.localSettings.Values["ColorDistributedForceA"] = (int)ColorDistributedForce.A;
                FileManager.localSettings.Values["ColorDistributedForceR"] = (int)ColorDistributedForce.R;
                FileManager.localSettings.Values["ColorDistributedForceG"] = (int)ColorDistributedForce.G;
                FileManager.localSettings.Values["ColorDistributedForceB"] = (int)ColorDistributedForce.B;

                LineDistributedForce.DashCap = CanvasCapStyle.Round;
                LineDistributedForce.DashOffset = 0;
                LineDistributedForce.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForce.EndCap = CanvasCapStyle.Flat;
                LineDistributedForce.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForce.MiterLimit = 0;
                LineDistributedForce.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceWeight = 1.5f;

                FileManager.localSettings.Values["LineDistributedForceDashCap"] = (int)LineDistributedForce.DashCap;
                FileManager.localSettings.Values["LineDistributedForceDashOffset"] = (float)LineDistributedForce.DashOffset;
                FileManager.localSettings.Values["LineDistributedForceDashStyle"] = (int)LineDistributedForce.DashStyle;
                FileManager.localSettings.Values["LineDistributedForceEndCap"] = (int)LineDistributedForce.EndCap;

                FileManager.localSettings.Values["LineDistributedForceLineJoin"] = (int)LineDistributedForce.LineJoin;
                FileManager.localSettings.Values["LineDistributedForceMiterLimit"] = (float)LineDistributedForce.MiterLimit;
                FileManager.localSettings.Values["LineDistributedForceStartCap"] = (int)LineDistributedForce.StartCap;
                FileManager.localSettings.Values["LineDistributedForceWeight"] = (float)LineDistributedForceWeight;

                FileManager.localSettings.Values["ColorDistributedForceSelectedA"] = (int)ColorDistributedForceSelected.A;
                FileManager.localSettings.Values["ColorDistributedForceSelectedR"] = (int)ColorDistributedForceSelected.R;
                FileManager.localSettings.Values["ColorDistributedForceSelectedG"] = (int)ColorDistributedForceSelected.G;
                FileManager.localSettings.Values["ColorDistributedForceSelectedB"] = (int)ColorDistributedForceSelected.B;

                LineDistributedForceSelected.DashCap = CanvasCapStyle.Round;
                LineDistributedForceSelected.DashOffset = 0;
                LineDistributedForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForceSelected.EndCap = CanvasCapStyle.Flat;
                LineDistributedForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForceSelected.MiterLimit = 0;
                LineDistributedForceSelected.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceSelectedWeight = 1.5f;

                FileManager.localSettings.Values["LineDistributedForceSelectedDashCap"] = (int)LineDistributedForceSelected.DashCap;
                FileManager.localSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)LineDistributedForceSelected.DashOffset;
                FileManager.localSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)LineDistributedForceSelected.DashStyle;
                FileManager.localSettings.Values["LineDistributedForceSelectedEndCap"] = (int)LineDistributedForceSelected.EndCap;

                FileManager.localSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)LineDistributedForceSelected.LineJoin;
                FileManager.localSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)LineDistributedForceSelected.MiterLimit;
                FileManager.localSettings.Values["LineDistributedForceSelectedStartCap"] = (int)LineDistributedForceSelected.StartCap;
                FileManager.localSettings.Values["LineDistributedForceSelectedWeight"] = (float)LineDistributedForceSelectedWeight;

                FileManager.localSettings.Values["ColorNodeFreeA"] = (int)ColorNodeFree.A;
                FileManager.localSettings.Values["ColorNodeFreeR"] = (int)ColorNodeFree.R;
                FileManager.localSettings.Values["ColorNodeFreeG"] = (int)ColorNodeFree.G;
                FileManager.localSettings.Values["ColorNodeFreeB"] = (int)ColorNodeFree.B;

                LineNodeFree.DashCap = CanvasCapStyle.Round;
                LineNodeFree.DashOffset = 0;
                LineNodeFree.DashStyle = CanvasDashStyle.Solid;
                LineNodeFree.EndCap = CanvasCapStyle.Flat;
                LineNodeFree.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFree.MiterLimit = 0;
                LineNodeFree.StartCap = CanvasCapStyle.Flat;
                LineNodeFreeWeight = 1;

                FileManager.localSettings.Values["LineNodeFreeDashCap"] = (int)LineNodeFree.DashCap;
                FileManager.localSettings.Values["LineNodeFreeDashOffset"] = (float)LineNodeFree.DashOffset;
                FileManager.localSettings.Values["LineNodeFreeDashStyle"] = (int)LineNodeFree.DashStyle;
                FileManager.localSettings.Values["LineNodeFreeEndCap"] = (int)LineNodeFree.EndCap;

                FileManager.localSettings.Values["LineNodeFreeLineJoin"] = (int)LineNodeFree.LineJoin;
                FileManager.localSettings.Values["LineNodeFreeMiterLimit"] = (float)LineNodeFree.MiterLimit;
                FileManager.localSettings.Values["LineNodeFreeStartCap"] = (int)LineNodeFree.StartCap;
                FileManager.localSettings.Values["LineNodeFreeWeight"] = (float)LineNodeFreeWeight;

                FileManager.localSettings.Values["ColorNodeFixedA"] = (int)ColorNodeFixed.A;
                FileManager.localSettings.Values["ColorNodeFixedR"] = (int)ColorNodeFixed.R;
                FileManager.localSettings.Values["ColorNodeFixedG"] = (int)ColorNodeFixed.G;
                FileManager.localSettings.Values["ColorNodeFixedB"] = (int)ColorNodeFixed.B;

                LineNodeFixed.DashCap = CanvasCapStyle.Round;
                LineNodeFixed.DashOffset = 0;
                LineNodeFixed.DashStyle = CanvasDashStyle.Solid;
                LineNodeFixed.EndCap = CanvasCapStyle.Flat;
                LineNodeFixed.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFixed.MiterLimit = 0;
                LineNodeFixed.StartCap = CanvasCapStyle.Flat;
                LineNodeFixedWeight = 1;

                FileManager.localSettings.Values["LineNodeFixedDashCap"] = (int)LineNodeFixed.DashCap;
                FileManager.localSettings.Values["LineNodeFixedDashOffset"] = (float)LineNodeFixed.DashOffset;
                FileManager.localSettings.Values["LineNodeFixedDashStyle"] = (int)LineNodeFixed.DashStyle;
                FileManager.localSettings.Values["LineNodeFixedEndCap"] = (int)LineNodeFixed.EndCap;

                FileManager.localSettings.Values["LineNodeFixedLineJoin"] = (int)LineNodeFixed.LineJoin;
                FileManager.localSettings.Values["LineNodeFixedMiterLimit"] = (float)LineNodeFixed.MiterLimit;
                FileManager.localSettings.Values["LineNodeFixedStartCap"] = (int)LineNodeFixed.StartCap;
                FileManager.localSettings.Values["LineNodeFixedWeight"] = (float)LineNodeFixedWeight;

                FileManager.localSettings.Values["ColorNodePinA"] = (int)ColorNodePin.A;
                FileManager.localSettings.Values["ColorNodePinR"] = (int)ColorNodePin.R;
                FileManager.localSettings.Values["ColorNodePinG"] = (int)ColorNodePin.G;
                FileManager.localSettings.Values["ColorNodePinB"] = (int)ColorNodePin.B;

                LineNodePin.DashCap = CanvasCapStyle.Round;
                LineNodePin.DashOffset = 0;
                LineNodePin.DashStyle = CanvasDashStyle.Solid;
                LineNodePin.EndCap = CanvasCapStyle.Flat;
                LineNodePin.LineJoin = CanvasLineJoin.Bevel;
                LineNodePin.MiterLimit = 0;
                LineNodePin.StartCap = CanvasCapStyle.Flat;
                LineNodePinWeight = 1;

                FileManager.localSettings.Values["LineNodePinDashCap"] = (int)LineNodePin.DashCap;
                FileManager.localSettings.Values["LineNodePinDashOffset"] = (float)LineNodePin.DashOffset;
                FileManager.localSettings.Values["LineNodePinDashStyle"] = (int)LineNodePin.DashStyle;
                FileManager.localSettings.Values["LineNodePinEndCap"] = (int)LineNodePin.EndCap;

                FileManager.localSettings.Values["LineNodePinLineJoin"] = (int)LineNodePin.LineJoin;
                FileManager.localSettings.Values["LineNodePinMiterLimit"] = (float)LineNodePin.MiterLimit;
                FileManager.localSettings.Values["LineNodePinStartCap"] = (int)LineNodePin.StartCap;
                FileManager.localSettings.Values["LineNodePinWeight"] = (float)LineNodePinWeight;

                FileManager.localSettings.Values["ColorNodeRollerXA"] = (int)ColorNodeRollerX.A;
                FileManager.localSettings.Values["ColorNodeRollerXR"] = (int)ColorNodeRollerX.R;
                FileManager.localSettings.Values["ColorNodeRollerXG"] = (int)ColorNodeRollerX.G;
                FileManager.localSettings.Values["ColorNodeRollerXB"] = (int)ColorNodeRollerX.B;

                LineNodeRollerX.DashCap = CanvasCapStyle.Round;
                LineNodeRollerX.DashOffset = 0;
                LineNodeRollerX.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerX.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerX.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerX.MiterLimit = 0;
                LineNodeRollerX.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerXWeight = 1;

                FileManager.localSettings.Values["LineNodeRollerXDashCap"] = (int)LineNodeRollerX.DashCap;
                FileManager.localSettings.Values["LineNodeRollerXDashOffset"] = (float)LineNodeRollerX.DashOffset;
                FileManager.localSettings.Values["LineNodeRollerXDashStyle"] = (int)LineNodeRollerX.DashStyle;
                FileManager.localSettings.Values["LineNodeRollerXEndCap"] = (int)LineNodeRollerX.EndCap;

                FileManager.localSettings.Values["LineNodeRollerXLineJoin"] = (int)LineNodeRollerX.LineJoin;
                FileManager.localSettings.Values["LineNodeRollerXMiterLimit"] = (float)LineNodeRollerX.MiterLimit;
                FileManager.localSettings.Values["LineNodeRollerXStartCap"] = (int)LineNodeRollerX.StartCap;
                FileManager.localSettings.Values["LineNodeRollerXWeight"] = (float)LineNodeRollerXWeight;

                FileManager.localSettings.Values["ColorNodeRollerYA"] = (int)ColorNodeRollerY.A;
                FileManager.localSettings.Values["ColorNodeRollerYR"] = (int)ColorNodeRollerY.R;
                FileManager.localSettings.Values["ColorNodeRollerYG"] = (int)ColorNodeRollerY.G;
                FileManager.localSettings.Values["ColorNodeRollerYB"] = (int)ColorNodeRollerY.B;

                LineNodeRollerY.DashCap = CanvasCapStyle.Round;
                LineNodeRollerY.DashOffset = 0;
                LineNodeRollerY.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerY.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerY.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerY.MiterLimit = 0;
                LineNodeRollerY.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerYWeight = 1;

                FileManager.localSettings.Values["LineNodeRollerYDashCap"] = (int)LineNodeRollerY.DashCap;
                FileManager.localSettings.Values["LineNodeRollerYDashOffset"] = (float)LineNodeRollerY.DashOffset;
                FileManager.localSettings.Values["LineNodeRollerYDashStyle"] = (int)LineNodeRollerY.DashStyle;
                FileManager.localSettings.Values["LineNodeRollerYEndCap"] = (int)LineNodeRollerY.EndCap;

                FileManager.localSettings.Values["LineNodeRollerYLineJoin"] = (int)LineNodeRollerY.LineJoin;
                FileManager.localSettings.Values["LineNodeRollerYMiterLimit"] = (float)LineNodeRollerY.MiterLimit;
                FileManager.localSettings.Values["LineNodeRollerYStartCap"] = (int)LineNodeRollerY.StartCap;
                FileManager.localSettings.Values["LineNodeRollerYWeight"] = (float)LineNodeRollerYWeight;

                FileManager.localSettings.Values["ColorNodeOtherA"] = (int)ColorNodeOther.A;
                FileManager.localSettings.Values["ColorNodeOtherR"] = (int)ColorNodeOther.R;
                FileManager.localSettings.Values["ColorNodeOtherG"] = (int)ColorNodeOther.G;
                FileManager.localSettings.Values["ColorNodeOtherB"] = (int)ColorNodeOther.B;

                LineNodeOther.DashCap = CanvasCapStyle.Round;
                LineNodeOther.DashOffset = 0;
                LineNodeOther.DashStyle = CanvasDashStyle.Solid;
                LineNodeOther.EndCap = CanvasCapStyle.Flat;
                LineNodeOther.LineJoin = CanvasLineJoin.Bevel;
                LineNodeOther.MiterLimit = 0;
                LineNodeOther.StartCap = CanvasCapStyle.Flat;
                LineNodeOtherWeight = 1;

                FileManager.localSettings.Values["LineNodeOtherDashCap"] = (int)LineNodeOther.DashCap;
                FileManager.localSettings.Values["LineNodeOtherDashOffset"] = (float)LineNodeOther.DashOffset;
                FileManager.localSettings.Values["LineNodeOtherDashStyle"] = (int)LineNodeOther.DashStyle;
                FileManager.localSettings.Values["LineNodeOtherEndCap"] = (int)LineNodeOther.EndCap;

                FileManager.localSettings.Values["LineNodeOtherLineJoin"] = (int)LineNodeOther.LineJoin;
                FileManager.localSettings.Values["LineNodeOtherMiterLimit"] = (float)LineNodeOther.MiterLimit;
                FileManager.localSettings.Values["LineNodeOtherStartCap"] = (int)LineNodeOther.StartCap;
                FileManager.localSettings.Values["LineNodeOtherWeight"] = (float)LineNodeOtherWeight;

                FileManager.localSettings.Values["MomentFactor"] = 0.0001f;
                momentFactor = 0.0001f;
                FileManager.localSettings.Values["ShearFactor"] = 0.0001f;
                shearFactor = 0.0001f;
                FileManager.localSettings.Values["LinearFactor"] = 0.0001f;
                linearFactor = 0.0001f;
                FileManager.localSettings.Values["ForcesFactor"] = 0.0001f;
                forcesFactor = 0.0001f;
                FileManager.localSettings.Values["ReactionsFactor"] = 0.0001f;
                reactionsFactor = 0.0001f;
                FileManager.localSettings.Values["DisplacementFactor"] = 1f;
                displacementFactor = 1f;
                FileManager.localSettings.Values["CameraZoomTrim"] = 500f;
                CameraZoomTrim = 500f;
                FileManager.localSettings.Values["SelectGridSize"] = 1f;
                SelectGridSize = 1f;


            }


            #region Units

            if (FileManager.localSettings.Values["UnitAngle"] is object)
            {
                angle = (AngleType)FileManager.localSettings.Values["UnitAngle"];
            }
            else
            {
                FileManager.localSettings.Values["UnitAngle"] = (int)AngleType.Degrees;
                angle = AngleType.Degrees;
            }

            if (FileManager.localSettings.Values["UnitArea"] is object)
            {
                area = (AreaType)FileManager.localSettings.Values["UnitArea"];
            }
            else
            {
                FileManager.localSettings.Values["UnitArea"] = (int)AreaType.SquareMetre;
                area = AreaType.SquareMetre;
            }

            if (FileManager.localSettings.Values["UnitDensity"] is object)
            {
                density = (DensityType)FileManager.localSettings.Values["UnitDensity"];
            }
            else
            {
                FileManager.localSettings.Values["UnitDensity"] = (int)DensityType.KilogramPerCubicMetre;
                density = DensityType.KilogramPerCubicMetre;
            }




            try
            {
                force = (ForceType)FileManager.localSettings.Values["UnitForce"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitForce"] = (int)ForceType.Newton;
                force = ForceType.Newton;
            }

            try
            {
                forcePerLength = (ForcePerLengthType)FileManager.localSettings.Values["UnitForcePerLength"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitForcePerLength"] = (int)ForcePerLengthType.NewtonPerMeter;
                forcePerLength = ForcePerLengthType.NewtonPerMeter;
            }





            try
            {
                Length = (LengthType)FileManager.localSettings.Values["UnitLength"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitLength"] = (int)LengthType.Meter;
                Length = LengthType.Meter;
            }


            try
            {
                mass = (MassType)FileManager.localSettings.Values["UnitMass"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitMass"] = (int)MassType.Kilogram;
                mass = MassType.Kilogram;
            }


            try
            {
                moment = (MomentType)FileManager.localSettings.Values["UnitMoment"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitMoment"] = (int)MomentType.NewtonMetre;
                moment = MomentType.NewtonMetre;
            }


            try
            {
                momentOfInertia = (MomentOfInertiaType)FileManager.localSettings.Values["UnitMomentOfInertia"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitMomentOfInertia"] = (int)MomentOfInertiaType.QuadMeter;
                momentOfInertia = MomentOfInertiaType.QuadMeter;
            }

            try
            {
                pressure = (PressureType)FileManager.localSettings.Values["UnitPressure"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitPressure"] = (int)PressureType.Pascal;
                pressure = PressureType.Pascal;
            }


            try
            {
                volume = (VolumeType)FileManager.localSettings.Values["UnitVolume"];
            }
            catch
            {
                FileManager.localSettings.Values["UnitVolume"] = (int)VolumeType.CubicMetre;
                volume = VolumeType.CubicMetre;
            }



            #endregion

            #region Show

            try
            {
                showMoment = (bool)FileManager.localSettings.Values["ShowMoment"];
            }
            catch
            {
                FileManager.localSettings.Values["ShowMoment"] = true;
                showMoment = true;
            }

            try
            {
                showShear = (bool)FileManager.localSettings.Values["ShowShear"];
            }
            catch
            {
                FileManager.localSettings.Values["ShowShear"] = true;
                showShear = true;
            }

            try
            {
                showForce = (bool)FileManager.localSettings.Values["ShowForce"];
            }
            catch
            {
                FileManager.localSettings.Values["ShowForce"] = true;
                showForce = true;
            }

            try
            {
                showLinear = (bool)FileManager.localSettings.Values["ShowLinear"];
            }
            catch
            {
                FileManager.localSettings.Values["ShowLinear"] = true;
                showLinear = true;
            }

            try
            {
                showAxial = (bool)FileManager.localSettings.Values["ShowAxial"];
            }
            catch
            {
                FileManager.localSettings.Values["ShowAxial"] = true;
                showAxial = true;
            }

            try
            {
                showReactions = (bool)FileManager.localSettings.Values["ShowReactions"];
            }
            catch
            {
                FileManager.localSettings.Values["ShowReactions"] = true;
                showReactions = true;
            }

            try
            {
                memberDisplay = (int)FileManager.localSettings.Values["MemberDisplay"];
            }
            catch
            {
                FileManager.localSettings.Values["MemberDisplay"] = 0;
                memberDisplay = 0;
            }

            #endregion

            #region Solver

            try
            {
                autoStartSolver = (bool)FileManager.localSettings.Values["AutoStartSolver"];
            }
            catch
            {
                FileManager.localSettings.Values["AutoStartSolver"] = true;
                autoStartSolver = true;
            }

            try
            {
                autoFinishSolver = (bool)FileManager.localSettings.Values["AutoFinishSolver"];
            }
            catch
            {
                FileManager.localSettings.Values["AutoFinishSolver"] = true;
                autoFinishSolver = true;
            }

            try
            {
                currentSolver = (int)FileManager.localSettings.Values["CurrentSolver"];
            }
            catch
            {
                currentSolver = 0;
                FileManager.localSettings.Values["CurrentSolver"] = (int)currentSolver;
            }

            #endregion

            #region General

            try
            {
                lockNumericalInput = (bool)FileManager.localSettings.Values["LockNumericalInput"];
            }
            catch
            {
                FileManager.localSettings.Values["LockNumericalInput"] = false;
                lockNumericalInput = false;
            }

            try
            {
                loadLastFileOnStartup = (bool)FileManager.localSettings.Values["LoadLastFileOnStartup"];
            }
            catch
            {
                FileManager.localSettings.Values["LoadLastFileOnStartup"] = true;
                loadLastFileOnStartup = true;
            }

            try
            {
                defaultNumberOfSegments = (int)FileManager.localSettings.Values["defaultNumberOfSegments"];
                if (defaultNumberOfSegments < 1) { defaultNumberOfSegments = 1; }
            }
            catch
            {
                FileManager.localSettings.Values["defaultNumberOfSegments"] = (int)defaultNumberOfSegments;
                defaultNumberOfSegments = 10;
            }

            try
            {
                resetExistingMembers = (bool)FileManager.localSettings.Values["ResetExistingMembers"];
            }
            catch
            {
                FileManager.localSettings.Values["ResetExistingMembers"] = true;
                resetExistingMembers = true;
            }

            try
            {
                lastCurrentSectionName = (string)FileManager.localSettings.Values["lastCurrentSection"];
            }
            catch
            {
                FileManager.localSettings.Values["lastCurrentSection"] = "Default";
                lastCurrentSectionName = "Default";
            }
            if (lastCurrentSectionName is null) { lastCurrentSectionName = "Default"; }
            if (string.IsNullOrEmpty(lastCurrentSectionName.Trim())) { lastCurrentSectionName = "Default"; }

            #endregion

            #region Colors

            try
            {
                int A = (int)FileManager.localSettings.Values["ColorBackgroundA"];
                int R = (int)FileManager.localSettings.Values["ColorBackgroundR"];
                int G = (int)FileManager.localSettings.Values["ColorBackgroundG"];
                int B = (int)FileManager.localSettings.Values["ColorBackgroundB"];

                ColorBackground = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);
            }
            catch
            {
                FileManager.localSettings.Values["ColorBackgroundA"] = (int)ColorBackground.A;
                FileManager.localSettings.Values["ColorBackgroundR"] = (int)ColorBackground.R;
                FileManager.localSettings.Values["ColorBackgroundG"] = (int)ColorBackground.G;
                FileManager.localSettings.Values["ColorBackgroundB"] = (int)ColorBackground.B;
            }

            try
            {
                int A = (int)FileManager.localSettings.Values["ColorGridMajorFontA"];
                int R = (int)FileManager.localSettings.Values["ColorGridMajorFontR"];
                int G = (int)FileManager.localSettings.Values["ColorGridMajorFontG"];
                int B = (int)FileManager.localSettings.Values["ColorGridMajorFontB"];

                ColorGridMajorFont = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);
            }
            catch
            {
                FileManager.localSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
                FileManager.localSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
                FileManager.localSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
                FileManager.localSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;
            }

            try
            {
                int A = (int)FileManager.localSettings.Values["ColorLabelA"];
                int R = (int)FileManager.localSettings.Values["ColorLabelR"];
                int G = (int)FileManager.localSettings.Values["ColorLabelG"];
                int B = (int)FileManager.localSettings.Values["ColorLabelB"];

                ColorLabel = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);
            }
            catch
            {
                FileManager.localSettings.Values["ColorLabelA"] = (int)ColorLabel.A;
                FileManager.localSettings.Values["ColorLabelR"] = (int)ColorLabel.R;
                FileManager.localSettings.Values["ColorLabelG"] = (int)ColorLabel.G;
                FileManager.localSettings.Values["ColorLabelB"] = (int)ColorLabel.B;

            }

            #endregion

            #region Lines

            #region Line Grid Normal
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorGridNormalA"];
                int R = (int)FileManager.localSettings.Values["ColorGridNormalR"];
                int G = (int)FileManager.localSettings.Values["ColorGridNormalG"];
                int B = (int)FileManager.localSettings.Values["ColorGridNormalB"];

                ColorGridNormal = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineGridNormal.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridNormalDashCap"];
                LineGridNormal.DashOffset = (float)FileManager.localSettings.Values["LineGridNormalDashOffset"];
                LineGridNormal.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineGridNormalDashStyle"];
                LineGridNormal.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridNormalEndCap"];
                LineGridNormal.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineGridNormalLineJoin"];
                LineGridNormal.MiterLimit = (float)FileManager.localSettings.Values["LineGridNormalMiterLimit"];
                LineGridNormal.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridNormalStartCap"];
                LineGridNormalWeight = (float)FileManager.localSettings.Values["LineGridNormalWeight"];

            }
            catch
            {
                FileManager.localSettings.Values["ColorGridNormalA"] = (int)ColorGridNormal.A;
                FileManager.localSettings.Values["ColorGridNormalR"] = (int)ColorGridNormal.R;
                FileManager.localSettings.Values["ColorGridNormalG"] = (int)ColorGridNormal.G;
                FileManager.localSettings.Values["ColorGridNormalB"] = (int)ColorGridNormal.B;

                LineGridNormal.DashCap = CanvasCapStyle.Round;
                LineGridNormal.DashOffset = 0;
                LineGridNormal.DashStyle = CanvasDashStyle.Solid;
                LineGridNormal.EndCap = CanvasCapStyle.Flat;
                LineGridNormal.LineJoin = CanvasLineJoin.Bevel;
                LineGridNormal.MiterLimit = 0;
                LineGridNormal.StartCap = CanvasCapStyle.Flat;
                LineGridNormalWeight = 1;

                FileManager.localSettings.Values["LineGridNormalDashCap"] = (int)LineGridNormal.DashCap;
                FileManager.localSettings.Values["LineGridNormalDashOffset"] = (float)LineGridNormal.DashOffset;
                FileManager.localSettings.Values["LineGridNormalDashStyle"] = (int)LineGridNormal.DashStyle;
                FileManager.localSettings.Values["LineGridNormalEndCap"] = (int)LineGridNormal.EndCap;

                FileManager.localSettings.Values["LineGridNormalLineJoin"] = (int)LineGridNormal.LineJoin;
                FileManager.localSettings.Values["LineGridNormalMiterLimit"] = (float)LineGridNormal.MiterLimit;
                FileManager.localSettings.Values["LineGridNormalStartCap"] = (int)LineGridNormal.StartCap;
                FileManager.localSettings.Values["LineGridNormalWeight"] = (float)LineGridNormalWeight;

            }

            #endregion
            #region Line Grid Minor

            try
            {
                int A = (int)FileManager.localSettings.Values["ColorGridMinorA"];
                int R = (int)FileManager.localSettings.Values["ColorGridMinorR"];
                int G = (int)FileManager.localSettings.Values["ColorGridMinorG"];
                int B = (int)FileManager.localSettings.Values["ColorGridMinorB"];

                ColorGridMinor = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineGridMinor.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridMinorDashCap"];
                LineGridMinor.DashOffset = (float)FileManager.localSettings.Values["LineGridMinorDashOffset"];
                LineGridMinor.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineGridMinorDashStyle"];
                LineGridMinor.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridMinorEndCap"];
                LineGridMinor.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineGridMinorLineJoin"];
                LineGridMinor.MiterLimit = (float)FileManager.localSettings.Values["LineGridMinorMiterLimit"];
                LineGridMinor.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridMinorStartCap"];
                LineGridMinorWeight = (float)FileManager.localSettings.Values["LineGridMinorWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorGridMinorA"] = (int)ColorGridMinor.A;
                FileManager.localSettings.Values["ColorGridMinorR"] = (int)ColorGridMinor.R;
                FileManager.localSettings.Values["ColorGridMinorG"] = (int)ColorGridMinor.G;
                FileManager.localSettings.Values["ColorGridMinorB"] = (int)ColorGridMinor.B;

                LineGridMinor.DashCap = CanvasCapStyle.Round;
                LineGridMinor.DashOffset = 0;
                LineGridMinor.DashStyle = CanvasDashStyle.Solid;
                LineGridMinor.EndCap = CanvasCapStyle.Flat;
                LineGridMinor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMinor.MiterLimit = 0;
                LineGridMinor.StartCap = CanvasCapStyle.Flat;
                LineGridMinorWeight = 1;

                FileManager.localSettings.Values["LineGridMinorDashCap"] = (int)LineGridMinor.DashCap;
                FileManager.localSettings.Values["LineGridMinorDashOffset"] = (float)LineGridMinor.DashOffset;
                FileManager.localSettings.Values["LineGridMinorDashStyle"] = (int)LineGridMinor.DashStyle;
                FileManager.localSettings.Values["LineGridMinorEndCap"] = (int)LineGridMinor.EndCap;

                FileManager.localSettings.Values["LineGridMinorLineJoin"] = (int)LineGridMinor.LineJoin;
                FileManager.localSettings.Values["LineGridMinorMiterLimit"] = (float)LineGridMinor.MiterLimit;
                FileManager.localSettings.Values["LineGridMinorStartCap"] = (int)LineGridMinor.StartCap;
                FileManager.localSettings.Values["LineGridMinorWeight"] = (float)LineGridMinorWeight;

            }

            #endregion
            #region Line Grid Major

            try
            {
                int A = (int)FileManager.localSettings.Values["ColorGridMajorA"];
                int R = (int)FileManager.localSettings.Values["ColorGridMajorR"];
                int G = (int)FileManager.localSettings.Values["ColorGridMajorG"];
                int B = (int)FileManager.localSettings.Values["ColorGridMajorB"];

                ColorGridMajor = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineGridMajor.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridMajorDashCap"];
                LineGridMajor.DashOffset = (float)FileManager.localSettings.Values["LineGridMajorDashOffset"];
                LineGridMajor.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineGridMajorDashStyle"];
                LineGridMajor.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridMajorEndCap"];
                LineGridMajor.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineGridMajorLineJoin"];
                LineGridMajor.MiterLimit = (float)FileManager.localSettings.Values["LineGridMajorMiterLimit"];
                LineGridMajor.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridMajorStartCap"];
                LineGridMajorWeight = (float)FileManager.localSettings.Values["LineGridMajorWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorGridMajorA"] = (int)ColorGridMajor.A;
                FileManager.localSettings.Values["ColorGridMajorR"] = (int)ColorGridMajor.R;
                FileManager.localSettings.Values["ColorGridMajorG"] = (int)ColorGridMajor.G;
                FileManager.localSettings.Values["ColorGridMajorB"] = (int)ColorGridMajor.B;

                LineGridMajor.DashCap = CanvasCapStyle.Round;
                LineGridMajor.DashOffset = 0;
                LineGridMajor.DashStyle = CanvasDashStyle.Solid;
                LineGridMajor.EndCap = CanvasCapStyle.Flat;
                LineGridMajor.LineJoin = CanvasLineJoin.Bevel;
                LineGridMajor.MiterLimit = 0;
                LineGridMajor.StartCap = CanvasCapStyle.Flat;
                LineGridMajorWeight = 1;

                FileManager.localSettings.Values["LineGridMajorDashCap"] = (int)LineGridMajor.DashCap;
                FileManager.localSettings.Values["LineGridMajorDashOffset"] = (float)LineGridMajor.DashOffset;
                FileManager.localSettings.Values["LineGridMajorDashStyle"] = (int)LineGridMajor.DashStyle;
                FileManager.localSettings.Values["LineGridMajorEndCap"] = (int)LineGridMajor.EndCap;

                FileManager.localSettings.Values["LineGridMajorLineJoin"] = (int)LineGridMajor.LineJoin;
                FileManager.localSettings.Values["LineGridMajorMiterLimit"] = (float)LineGridMajor.MiterLimit;
                FileManager.localSettings.Values["LineGridMajorStartCap"] = (int)LineGridMajor.StartCap;
                FileManager.localSettings.Values["LineGridMajorWeight"] = (float)LineGridMajorWeight;

            }

            #endregion
            #region Line Force
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorForceA"];
                int R = (int)FileManager.localSettings.Values["ColorForceR"];
                int G = (int)FileManager.localSettings.Values["ColorForceG"];
                int B = (int)FileManager.localSettings.Values["ColorForceB"];

                ColorForce = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineForce.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineForceDashCap"];
                LineForce.DashOffset = (float)FileManager.localSettings.Values["LineForceDashOffset"];
                LineForce.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineForceDashStyle"];
                LineForce.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineForceEndCap"];
                LineForce.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineForceLineJoin"];
                LineForce.MiterLimit = (float)FileManager.localSettings.Values["LineForceMiterLimit"];
                LineForce.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineForceStartCap"];
                LineForceWeight = (float)FileManager.localSettings.Values["LineForceWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorForceA"] = (int)ColorForce.A;
                FileManager.localSettings.Values["ColorForceR"] = (int)ColorForce.R;
                FileManager.localSettings.Values["ColorForceG"] = (int)ColorForce.G;
                FileManager.localSettings.Values["ColorForceB"] = (int)ColorForce.B;

                LineForce.DashCap = CanvasCapStyle.Round;
                LineForce.DashOffset = 0;
                LineForce.DashStyle = CanvasDashStyle.Solid;
                LineForce.EndCap = CanvasCapStyle.Flat;
                LineForce.LineJoin = CanvasLineJoin.Bevel;
                LineForce.MiterLimit = 0;
                LineForce.StartCap = CanvasCapStyle.Round;
                LineForceWeight = 5f;

                FileManager.localSettings.Values["LineForceDashCap"] = (int)LineForce.DashCap;
                FileManager.localSettings.Values["LineForceDashOffset"] = (float)LineForce.DashOffset;
                FileManager.localSettings.Values["LineForceDashStyle"] = (int)LineForce.DashStyle;
                FileManager.localSettings.Values["LineForceEndCap"] = (int)LineForce.EndCap;

                FileManager.localSettings.Values["LineForceLineJoin"] = (int)LineForce.LineJoin;
                FileManager.localSettings.Values["LineForceMiterLimit"] = (float)LineForce.MiterLimit;
                FileManager.localSettings.Values["LineForceStartCap"] = (int)LineForce.StartCap;
                FileManager.localSettings.Values["LineForceWeight"] = (float)LineForceWeight;

            }

            #endregion
            #region Line Reaction
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorReactionA"];
                int R = (int)FileManager.localSettings.Values["ColorReactionR"];
                int G = (int)FileManager.localSettings.Values["ColorReactionG"];
                int B = (int)FileManager.localSettings.Values["ColorReactionB"];

                ColorReaction = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineReaction.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineReactionDashCap"];
                LineReaction.DashOffset = (float)FileManager.localSettings.Values["LineReactionDashOffset"];
                LineReaction.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineReactionDashStyle"];
                LineReaction.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineReactionEndCap"];
                LineReaction.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineReactionLineJoin"];
                LineReaction.MiterLimit = (float)FileManager.localSettings.Values["LineReactionMiterLimit"];
                LineReaction.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineReactionStartCap"];
                LineReactionWeight = (float)FileManager.localSettings.Values["LineReactionWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorReactionA"] = (int)ColorReaction.A;
                FileManager.localSettings.Values["ColorReactionR"] = (int)ColorReaction.R;
                FileManager.localSettings.Values["ColorReactionG"] = (int)ColorReaction.G;
                FileManager.localSettings.Values["ColorReactionB"] = (int)ColorReaction.B;

                LineReaction.DashCap = CanvasCapStyle.Round;
                LineReaction.DashOffset = 0;
                LineReaction.DashStyle = CanvasDashStyle.Solid;
                LineReaction.EndCap = CanvasCapStyle.Flat;
                LineReaction.LineJoin = CanvasLineJoin.Bevel;
                LineReaction.MiterLimit = 0;
                LineReaction.StartCap = CanvasCapStyle.Round;
                LineReactionWeight = 5f;

                FileManager.localSettings.Values["LineReactionDashCap"] = (int)LineReaction.DashCap;
                FileManager.localSettings.Values["LineReactionDashOffset"] = (float)LineReaction.DashOffset;
                FileManager.localSettings.Values["LineReactionDashStyle"] = (int)LineReaction.DashStyle;
                FileManager.localSettings.Values["LineReactionEndCap"] = (int)LineReaction.EndCap;

                FileManager.localSettings.Values["LineReactionLineJoin"] = (int)LineReaction.LineJoin;
                FileManager.localSettings.Values["LineReactionMiterLimit"] = (float)LineReaction.MiterLimit;
                FileManager.localSettings.Values["LineReactionStartCap"] = (int)LineReaction.StartCap;
                FileManager.localSettings.Values["LineReactionWeight"] = (float)LineReactionWeight;

            }

            #endregion
            #region Line Selected Element
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorSelectedElementA"];
                int R = (int)FileManager.localSettings.Values["ColorSelectedElementR"];
                int G = (int)FileManager.localSettings.Values["ColorSelectedElementG"];
                int B = (int)FileManager.localSettings.Values["ColorSelectedElementB"];

                ColorSelectedElement = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineSelectedElement.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineSelectedElementDashCap"];
                LineSelectedElement.DashOffset = (float)FileManager.localSettings.Values["LineSelectedElementDashOffset"];
                LineSelectedElement.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineSelectedElementDashStyle"];
                LineSelectedElement.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineSelectedElementEndCap"];
                LineSelectedElement.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineSelectedElementLineJoin"];
                LineSelectedElement.MiterLimit = (float)FileManager.localSettings.Values["LineSelectedElementMiterLimit"];
                LineSelectedElement.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineSelectedElementStartCap"];
                LineSelectedElementWeight = (float)FileManager.localSettings.Values["LineSelectedElementWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorSelectedElementA"] = (int)ColorSelectedElement.A;
                FileManager.localSettings.Values["ColorSelectedElementR"] = (int)ColorSelectedElement.R;
                FileManager.localSettings.Values["ColorSelectedElementG"] = (int)ColorSelectedElement.G;
                FileManager.localSettings.Values["ColorSelectedElementB"] = (int)ColorSelectedElement.B;

                LineSelectedElement.DashCap = CanvasCapStyle.Round;
                LineSelectedElement.DashOffset = 0;
                LineSelectedElement.DashStyle = CanvasDashStyle.Solid;
                LineSelectedElement.EndCap = CanvasCapStyle.Flat;
                LineSelectedElement.LineJoin = CanvasLineJoin.Bevel;
                LineSelectedElement.MiterLimit = 0;
                LineSelectedElement.StartCap = CanvasCapStyle.Flat;
                LineSelectedElementWeight = 2.4f;

                FileManager.localSettings.Values["LineSelectedElementDashCap"] = (int)LineSelectedElement.DashCap;
                FileManager.localSettings.Values["LineSelectedElementDashOffset"] = (float)LineSelectedElement.DashOffset;
                FileManager.localSettings.Values["LineSelectedElementDashStyle"] = (int)LineSelectedElement.DashStyle;
                FileManager.localSettings.Values["LineSelectedElementEndCap"] = (int)LineSelectedElement.EndCap;

                FileManager.localSettings.Values["LineSelectedElementLineJoin"] = (int)LineSelectedElement.LineJoin;
                FileManager.localSettings.Values["LineSelectedElementMiterLimit"] = (float)LineSelectedElement.MiterLimit;
                FileManager.localSettings.Values["LineSelectedElementStartCap"] = (int)LineSelectedElement.StartCap;
                FileManager.localSettings.Values["LineSelectedElementWeight"] = (float)LineSelectedElementWeight;

            }

            #endregion
            #region Line Shear Force Selected
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorShearForceSelectedA"];
                int R = (int)FileManager.localSettings.Values["ColorShearForceSelectedR"];
                int G = (int)FileManager.localSettings.Values["ColorShearForceSelectedG"];
                int B = (int)FileManager.localSettings.Values["ColorShearForceSelectedB"];

                ColorShearForceSelected = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineShearForceSelected.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceSelectedDashCap"];
                LineShearForceSelected.DashOffset = (float)FileManager.localSettings.Values["LineShearForceSelectedDashOffset"];
                LineShearForceSelected.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineShearForceSelectedDashStyle"];
                LineShearForceSelected.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceSelectedEndCap"];
                LineShearForceSelected.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineShearForceSelectedLineJoin"];
                LineShearForceSelected.MiterLimit = (float)FileManager.localSettings.Values["LineShearForceSelectedMiterLimit"];
                LineShearForceSelected.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceSelectedStartCap"];
                LineShearForceSelectedWeight = (float)FileManager.localSettings.Values["LineShearForceSelectedWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorShearForceSelectedA"] = (int)ColorShearForceSelected.A;
                FileManager.localSettings.Values["ColorShearForceSelectedR"] = (int)ColorShearForceSelected.R;
                FileManager.localSettings.Values["ColorShearForceSelectedG"] = (int)ColorShearForceSelected.G;
                FileManager.localSettings.Values["ColorShearForceSelectedB"] = (int)ColorShearForceSelected.B;

                LineShearForceSelected.DashCap = CanvasCapStyle.Round;
                LineShearForceSelected.DashOffset = 0;
                LineShearForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineShearForceSelected.EndCap = CanvasCapStyle.Flat;
                LineShearForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceSelected.MiterLimit = 0;
                LineShearForceSelected.StartCap = CanvasCapStyle.Flat;
                LineShearForceSelectedWeight = 2.4f;

                FileManager.localSettings.Values["LineShearForceSelectedDashCap"] = (int)LineShearForceSelected.DashCap;
                FileManager.localSettings.Values["LineShearForceSelectedDashOffset"] = (float)LineShearForceSelected.DashOffset;
                FileManager.localSettings.Values["LineShearForceSelectedDashStyle"] = (int)LineShearForceSelected.DashStyle;
                FileManager.localSettings.Values["LineShearForceSelectedEndCap"] = (int)LineShearForceSelected.EndCap;

                FileManager.localSettings.Values["LineShearForceSelectedLineJoin"] = (int)LineShearForceSelected.LineJoin;
                FileManager.localSettings.Values["LineShearForceSelectedMiterLimit"] = (float)LineShearForceSelected.MiterLimit;
                FileManager.localSettings.Values["LineShearForceSelectedStartCap"] = (int)LineShearForceSelected.StartCap;
                FileManager.localSettings.Values["LineShearForceSelectedWeight"] = (float)LineShearForceSelectedWeight;

            }

            #endregion
            #region Line Moment Force Selected
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorMomentForceSelectedA"];
                int R = (int)FileManager.localSettings.Values["ColorMomentForceSelectedR"];
                int G = (int)FileManager.localSettings.Values["ColorMomentForceSelectedG"];
                int B = (int)FileManager.localSettings.Values["ColorMomentForceSelectedB"];

                ColorMomentForceSelected = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineMomentForceSelected.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceSelectedDashCap"];
                LineMomentForceSelected.DashOffset = (float)FileManager.localSettings.Values["LineMomentForceSelectedDashOffset"];
                LineMomentForceSelected.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineMomentForceSelectedDashStyle"];
                LineMomentForceSelected.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceSelectedEndCap"];
                LineMomentForceSelected.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineMomentForceSelectedLineJoin"];
                LineMomentForceSelected.MiterLimit = (float)FileManager.localSettings.Values["LineMomentForceSelectedMiterLimit"];
                LineMomentForceSelected.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceSelectedStartCap"];
                LineMomentForceSelectedWeight = (float)FileManager.localSettings.Values["LineMomentForceSelectedWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorMomentForceSelectedA"] = (int)ColorMomentForceSelected.A;
                FileManager.localSettings.Values["ColorMomentForceSelectedR"] = (int)ColorMomentForceSelected.R;
                FileManager.localSettings.Values["ColorMomentForceSelectedG"] = (int)ColorMomentForceSelected.G;
                FileManager.localSettings.Values["ColorMomentForceSelectedB"] = (int)ColorMomentForceSelected.B;

                LineMomentForceSelected.DashCap = CanvasCapStyle.Round;
                LineMomentForceSelected.DashOffset = 0;
                LineMomentForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceSelected.EndCap = CanvasCapStyle.Flat;
                LineMomentForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceSelected.MiterLimit = 0;
                LineMomentForceSelected.StartCap = CanvasCapStyle.Flat;
                LineMomentForceSelectedWeight = 2.4f;

                FileManager.localSettings.Values["LineMomentForceSelectedDashCap"] = (int)LineMomentForceSelected.DashCap;
                FileManager.localSettings.Values["LineMomentForceSelectedDashOffset"] = (float)LineMomentForceSelected.DashOffset;
                FileManager.localSettings.Values["LineMomentForceSelectedDashStyle"] = (int)LineMomentForceSelected.DashStyle;
                FileManager.localSettings.Values["LineMomentForceSelectedEndCap"] = (int)LineMomentForceSelected.EndCap;

                FileManager.localSettings.Values["LineMomentForceSelectedLineJoin"] = (int)LineMomentForceSelected.LineJoin;
                FileManager.localSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)LineMomentForceSelected.MiterLimit;
                FileManager.localSettings.Values["LineMomentForceSelectedStartCap"] = (int)LineMomentForceSelected.StartCap;
                FileManager.localSettings.Values["LineMomentForceSelectedWeight"] = (float)LineMomentForceSelectedWeight;

            }

            #endregion

            #region Line Shear Force Font
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorShearForceFontA"];
                int R = (int)FileManager.localSettings.Values["ColorShearForceFontR"];
                int G = (int)FileManager.localSettings.Values["ColorShearForceFontG"];
                int B = (int)FileManager.localSettings.Values["ColorShearForceFontB"];

                ColorShearForceFont = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineShearForceFont.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceFontDashCap"];
                LineShearForceFont.DashOffset = (float)FileManager.localSettings.Values["LineShearForceFontDashOffset"];
                LineShearForceFont.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineShearForceFontDashStyle"];
                LineShearForceFont.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceFontEndCap"];
                LineShearForceFont.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineShearForceFontLineJoin"];
                LineShearForceFont.MiterLimit = (float)FileManager.localSettings.Values["LineShearForceFontMiterLimit"];
                LineShearForceFont.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceFontStartCap"];
                LineShearForceFontWeight = (float)FileManager.localSettings.Values["LineShearForceFontWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorShearForceFontA"] = (int)ColorShearForceFont.A;
                FileManager.localSettings.Values["ColorShearForceFontR"] = (int)ColorShearForceFont.R;
                FileManager.localSettings.Values["ColorShearForceFontG"] = (int)ColorShearForceFont.G;
                FileManager.localSettings.Values["ColorShearForceFontB"] = (int)ColorShearForceFont.B;

                LineShearForceFont.DashCap = CanvasCapStyle.Round;
                LineShearForceFont.DashOffset = 0;
                LineShearForceFont.DashStyle = CanvasDashStyle.Solid;
                LineShearForceFont.EndCap = CanvasCapStyle.Flat;
                LineShearForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineShearForceFont.MiterLimit = 0;
                LineShearForceFont.StartCap = CanvasCapStyle.Flat;
                LineShearForceFontWeight = 2.4f;

                FileManager.localSettings.Values["LineShearForceFontDashCap"] = (int)LineShearForceFont.DashCap;
                FileManager.localSettings.Values["LineShearForceFontDashOffset"] = (float)LineShearForceFont.DashOffset;
                FileManager.localSettings.Values["LineShearForceFontDashStyle"] = (int)LineShearForceFont.DashStyle;
                FileManager.localSettings.Values["LineShearForceFontEndCap"] = (int)LineShearForceFont.EndCap;

                FileManager.localSettings.Values["LineShearForceFontLineJoin"] = (int)LineShearForceFont.LineJoin;
                FileManager.localSettings.Values["LineShearForceFontMiterLimit"] = (float)LineShearForceFont.MiterLimit;
                FileManager.localSettings.Values["LineShearForceFontStartCap"] = (int)LineShearForceFont.StartCap;
                FileManager.localSettings.Values["LineShearForceFontWeight"] = (float)LineShearForceFontWeight;

            }

            #endregion
            #region Line Moment Force Font
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorMomentForceFontA"];
                int R = (int)FileManager.localSettings.Values["ColorMomentForceFontR"];
                int G = (int)FileManager.localSettings.Values["ColorMomentForceFontG"];
                int B = (int)FileManager.localSettings.Values["ColorMomentForceFontB"];

                ColorMomentForceFont = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineMomentForceFont.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceFontDashCap"];
                LineMomentForceFont.DashOffset = (float)FileManager.localSettings.Values["LineMomentForceFontDashOffset"];
                LineMomentForceFont.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineMomentForceFontDashStyle"];
                LineMomentForceFont.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceFontEndCap"];
                LineMomentForceFont.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineMomentForceFontLineJoin"];
                LineMomentForceFont.MiterLimit = (float)FileManager.localSettings.Values["LineMomentForceFontMiterLimit"];
                LineMomentForceFont.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceFontStartCap"];
                LineMomentForceFontWeight = (float)FileManager.localSettings.Values["LineMomentForceFontWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorMomentForceFontA"] = (int)ColorMomentForceFont.A;
                FileManager.localSettings.Values["ColorMomentForceFontR"] = (int)ColorMomentForceFont.R;
                FileManager.localSettings.Values["ColorMomentForceFontG"] = (int)ColorMomentForceFont.G;
                FileManager.localSettings.Values["ColorMomentForceFontB"] = (int)ColorMomentForceFont.B;

                LineMomentForceFont.DashCap = CanvasCapStyle.Round;
                LineMomentForceFont.DashOffset = 0;
                LineMomentForceFont.DashStyle = CanvasDashStyle.Solid;
                LineMomentForceFont.EndCap = CanvasCapStyle.Flat;
                LineMomentForceFont.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForceFont.MiterLimit = 0;
                LineMomentForceFont.StartCap = CanvasCapStyle.Flat;
                LineMomentForceFontWeight = 2.4f;

                FileManager.localSettings.Values["LineMomentForceFontDashCap"] = (int)LineMomentForceFont.DashCap;
                FileManager.localSettings.Values["LineMomentForceFontDashOffset"] = (float)LineMomentForceFont.DashOffset;
                FileManager.localSettings.Values["LineMomentForceFontDashStyle"] = (int)LineMomentForceFont.DashStyle;
                FileManager.localSettings.Values["LineMomentForceFontEndCap"] = (int)LineMomentForceFont.EndCap;

                FileManager.localSettings.Values["LineMomentForceFontLineJoin"] = (int)LineMomentForceFont.LineJoin;
                FileManager.localSettings.Values["LineMomentForceFontMiterLimit"] = (float)LineMomentForceFont.MiterLimit;
                FileManager.localSettings.Values["LineMomentForceFontStartCap"] = (int)LineMomentForceFont.StartCap;
                FileManager.localSettings.Values["LineMomentForceFontWeight"] = (float)LineMomentForceFontWeight;

            }

            #endregion



            #region Line Shear Force
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorShearForceA"];
                int R = (int)FileManager.localSettings.Values["ColorShearForceR"];
                int G = (int)FileManager.localSettings.Values["ColorShearForceG"];
                int B = (int)FileManager.localSettings.Values["ColorShearForceB"];

                ColorShearForce = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineShearForce.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceDashCap"];
                LineShearForce.DashOffset = (float)FileManager.localSettings.Values["LineShearForceDashOffset"];
                LineShearForce.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineShearForceDashStyle"];
                LineShearForce.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceEndCap"];
                LineShearForce.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineShearForceLineJoin"];
                LineShearForce.MiterLimit = (float)FileManager.localSettings.Values["LineShearForceMiterLimit"];
                LineShearForce.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineShearForceStartCap"];
                LineShearForceWeight = (float)FileManager.localSettings.Values["LineShearForceWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorShearForceA"] = (int)ColorShearForce.A;
                FileManager.localSettings.Values["ColorShearForceR"] = (int)ColorShearForce.R;
                FileManager.localSettings.Values["ColorShearForceG"] = (int)ColorShearForce.G;
                FileManager.localSettings.Values["ColorShearForceB"] = (int)ColorShearForce.B;

                LineShearForce.DashCap = CanvasCapStyle.Round;
                LineShearForce.DashOffset = 0;
                LineShearForce.DashStyle = CanvasDashStyle.Solid;
                LineShearForce.EndCap = CanvasCapStyle.Flat;
                LineShearForce.LineJoin = CanvasLineJoin.Bevel;
                LineShearForce.MiterLimit = 0;
                LineShearForce.StartCap = CanvasCapStyle.Flat;
                LineShearForceWeight = 1.5f;

                FileManager.localSettings.Values["LineShearForceDashCap"] = (int)LineShearForce.DashCap;
                FileManager.localSettings.Values["LineShearForceDashOffset"] = (float)LineShearForce.DashOffset;
                FileManager.localSettings.Values["LineShearForceDashStyle"] = (int)LineShearForce.DashStyle;
                FileManager.localSettings.Values["LineShearForceEndCap"] = (int)LineShearForce.EndCap;

                FileManager.localSettings.Values["LineShearForceLineJoin"] = (int)LineShearForce.LineJoin;
                FileManager.localSettings.Values["LineShearForceMiterLimit"] = (float)LineShearForce.MiterLimit;
                FileManager.localSettings.Values["LineShearForceStartCap"] = (int)LineShearForce.StartCap;
                FileManager.localSettings.Values["LineShearForceWeight"] = (float)LineShearForceWeight;

            }

            #endregion
            #region Line Moment Force
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorMomentForceA"];
                int R = (int)FileManager.localSettings.Values["ColorMomentForceR"];
                int G = (int)FileManager.localSettings.Values["ColorMomentForceG"];
                int B = (int)FileManager.localSettings.Values["ColorMomentForceB"];

                ColorMomentForce = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineMomentForce.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceDashCap"];
                LineMomentForce.DashOffset = (float)FileManager.localSettings.Values["LineMomentForceDashOffset"];
                LineMomentForce.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineMomentForceDashStyle"];
                LineMomentForce.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceEndCap"];
                LineMomentForce.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineMomentForceLineJoin"];
                LineMomentForce.MiterLimit = (float)FileManager.localSettings.Values["LineMomentForceMiterLimit"];
                LineMomentForce.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineMomentForceStartCap"];
                LineMomentForceWeight = (float)FileManager.localSettings.Values["LineMomentForceWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorMomentForceA"] = (int)ColorMomentForce.A;
                FileManager.localSettings.Values["ColorMomentForceR"] = (int)ColorMomentForce.R;
                FileManager.localSettings.Values["ColorMomentForceG"] = (int)ColorMomentForce.G;
                FileManager.localSettings.Values["ColorMomentForceB"] = (int)ColorMomentForce.B;

                LineMomentForce.DashCap = CanvasCapStyle.Round;
                LineMomentForce.DashOffset = 0;
                LineMomentForce.DashStyle = CanvasDashStyle.Solid;
                LineMomentForce.EndCap = CanvasCapStyle.Flat;
                LineMomentForce.LineJoin = CanvasLineJoin.Bevel;
                LineMomentForce.MiterLimit = 0;
                LineMomentForce.StartCap = CanvasCapStyle.Flat;
                LineMomentForceWeight = 1.5f;

                FileManager.localSettings.Values["LineMomentForceDashCap"] = (int)LineMomentForce.DashCap;
                FileManager.localSettings.Values["LineMomentForceDashOffset"] = (float)LineMomentForce.DashOffset;
                FileManager.localSettings.Values["LineMomentForceDashStyle"] = (int)LineMomentForce.DashStyle;
                FileManager.localSettings.Values["LineMomentForceEndCap"] = (int)LineMomentForce.EndCap;

                FileManager.localSettings.Values["LineMomentForceLineJoin"] = (int)LineMomentForce.LineJoin;
                FileManager.localSettings.Values["LineMomentForceMiterLimit"] = (float)LineMomentForce.MiterLimit;
                FileManager.localSettings.Values["LineMomentForceStartCap"] = (int)LineMomentForce.StartCap;
                FileManager.localSettings.Values["LineMomentForceWeight"] = (float)LineMomentForceWeight;

            }

            #endregion
            #region Line Distributed Force
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorDistributedForceA"];
                int R = (int)FileManager.localSettings.Values["ColorDistributedForceR"];
                int G = (int)FileManager.localSettings.Values["ColorDistributedForceG"];
                int B = (int)FileManager.localSettings.Values["ColorDistributedForceB"];

                ColorDistributedForce = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineDistributedForce.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineDistributedForceDashCap"];
                LineDistributedForce.DashOffset = (float)FileManager.localSettings.Values["LineDistributedForceDashOffset"];
                LineDistributedForce.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineDistributedForceDashStyle"];
                LineDistributedForce.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineDistributedForceEndCap"];
                LineDistributedForce.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineDistributedForceLineJoin"];
                LineDistributedForce.MiterLimit = (float)FileManager.localSettings.Values["LineDistributedForceMiterLimit"];
                LineDistributedForce.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineDistributedForceStartCap"];
                LineDistributedForceWeight = (float)FileManager.localSettings.Values["LineDistributedForceWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorDistributedForceA"] = (int)ColorDistributedForce.A;
                FileManager.localSettings.Values["ColorDistributedForceR"] = (int)ColorDistributedForce.R;
                FileManager.localSettings.Values["ColorDistributedForceG"] = (int)ColorDistributedForce.G;
                FileManager.localSettings.Values["ColorDistributedForceB"] = (int)ColorDistributedForce.B;

                LineDistributedForce.DashCap = CanvasCapStyle.Round;
                LineDistributedForce.DashOffset = 0;
                LineDistributedForce.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForce.EndCap = CanvasCapStyle.Flat;
                LineDistributedForce.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForce.MiterLimit = 0;
                LineDistributedForce.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceWeight = 1.5f;

                FileManager.localSettings.Values["LineDistributedForceDashCap"] = (int)LineDistributedForce.DashCap;
                FileManager.localSettings.Values["LineDistributedForceDashOffset"] = (float)LineDistributedForce.DashOffset;
                FileManager.localSettings.Values["LineDistributedForceDashStyle"] = (int)LineDistributedForce.DashStyle;
                FileManager.localSettings.Values["LineDistributedForceEndCap"] = (int)LineDistributedForce.EndCap;

                FileManager.localSettings.Values["LineDistributedForceLineJoin"] = (int)LineDistributedForce.LineJoin;
                FileManager.localSettings.Values["LineDistributedForceMiterLimit"] = (float)LineDistributedForce.MiterLimit;
                FileManager.localSettings.Values["LineDistributedForceStartCap"] = (int)LineDistributedForce.StartCap;
                FileManager.localSettings.Values["LineDistributedForceWeight"] = (float)LineDistributedForceWeight;

            }

            #endregion
            #region Line Distributed Force Selected
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorDistributedForceSelectedA"];
                int R = (int)FileManager.localSettings.Values["ColorDistributedForceSelectedR"];
                int G = (int)FileManager.localSettings.Values["ColorDistributedForceSelectedG"];
                int B = (int)FileManager.localSettings.Values["ColorDistributedForceSelectedB"];

                ColorDistributedForceSelected = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineDistributedForceSelected.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineDistributedForceSelectedDashCap"];
                LineDistributedForceSelected.DashOffset = (float)FileManager.localSettings.Values["LineDistributedForceSelectedDashOffset"];
                LineDistributedForceSelected.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineDistributedForceSelectedDashStyle"];
                LineDistributedForceSelected.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineDistributedForceSelectedEndCap"];
                LineDistributedForceSelected.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineDistributedForceSelectedLineJoin"];
                LineDistributedForceSelected.MiterLimit = (float)FileManager.localSettings.Values["LineDistributedForceSelectedMiterLimit"];
                LineDistributedForceSelected.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineDistributedForceSelectedStartCap"];
                LineDistributedForceSelectedWeight = (float)FileManager.localSettings.Values["LineDistributedForceSelectedWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorDistributedForceSelectedA"] = (int)ColorDistributedForceSelected.A;
                FileManager.localSettings.Values["ColorDistributedForceSelectedR"] = (int)ColorDistributedForceSelected.R;
                FileManager.localSettings.Values["ColorDistributedForceSelectedG"] = (int)ColorDistributedForceSelected.G;
                FileManager.localSettings.Values["ColorDistributedForceSelectedB"] = (int)ColorDistributedForceSelected.B;

                LineDistributedForceSelected.DashCap = CanvasCapStyle.Round;
                LineDistributedForceSelected.DashOffset = 0;
                LineDistributedForceSelected.DashStyle = CanvasDashStyle.Solid;
                LineDistributedForceSelected.EndCap = CanvasCapStyle.Flat;
                LineDistributedForceSelected.LineJoin = CanvasLineJoin.Bevel;
                LineDistributedForceSelected.MiterLimit = 0;
                LineDistributedForceSelected.StartCap = CanvasCapStyle.Flat;
                LineDistributedForceSelectedWeight = 1.5f;

                FileManager.localSettings.Values["LineDistributedForceSelectedDashCap"] = (int)LineDistributedForceSelected.DashCap;
                FileManager.localSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)LineDistributedForceSelected.DashOffset;
                FileManager.localSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)LineDistributedForceSelected.DashStyle;
                FileManager.localSettings.Values["LineDistributedForceSelectedEndCap"] = (int)LineDistributedForceSelected.EndCap;

                FileManager.localSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)LineDistributedForceSelected.LineJoin;
                FileManager.localSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)LineDistributedForceSelected.MiterLimit;
                FileManager.localSettings.Values["LineDistributedForceSelectedStartCap"] = (int)LineDistributedForceSelected.StartCap;
                FileManager.localSettings.Values["LineDistributedForceSelectedWeight"] = (float)LineDistributedForceSelectedWeight;

            }

            #endregion
            #region Line Node Free
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorNodeFreeA"];
                int R = (int)FileManager.localSettings.Values["ColorNodeFreeR"];
                int G = (int)FileManager.localSettings.Values["ColorNodeFreeG"];
                int B = (int)FileManager.localSettings.Values["ColorNodeFreeB"];

                ColorNodeFree = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineNodeFree.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeFreeDashCap"];
                LineNodeFree.DashOffset = (float)FileManager.localSettings.Values["LineNodeFreeDashOffset"];
                LineNodeFree.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineNodeFreeDashStyle"];
                LineNodeFree.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeFreeEndCap"];
                LineNodeFree.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineNodeFreeLineJoin"];
                LineNodeFree.MiterLimit = (float)FileManager.localSettings.Values["LineNodeFreeMiterLimit"];
                LineNodeFree.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeFreeStartCap"];
                LineNodeFreeWeight = (float)FileManager.localSettings.Values["LineNodeFreeWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorNodeFreeA"] = (int)ColorNodeFree.A;
                FileManager.localSettings.Values["ColorNodeFreeR"] = (int)ColorNodeFree.R;
                FileManager.localSettings.Values["ColorNodeFreeG"] = (int)ColorNodeFree.G;
                FileManager.localSettings.Values["ColorNodeFreeB"] = (int)ColorNodeFree.B;

                LineNodeFree.DashCap = CanvasCapStyle.Round;
                LineNodeFree.DashOffset = 0;
                LineNodeFree.DashStyle = CanvasDashStyle.Solid;
                LineNodeFree.EndCap = CanvasCapStyle.Flat;
                LineNodeFree.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFree.MiterLimit = 0;
                LineNodeFree.StartCap = CanvasCapStyle.Flat;
                LineNodeFreeWeight = 1;

                FileManager.localSettings.Values["LineNodeFreeDashCap"] = (int)LineNodeFree.DashCap;
                FileManager.localSettings.Values["LineNodeFreeDashOffset"] = (float)LineNodeFree.DashOffset;
                FileManager.localSettings.Values["LineNodeFreeDashStyle"] = (int)LineNodeFree.DashStyle;
                FileManager.localSettings.Values["LineNodeFreeEndCap"] = (int)LineNodeFree.EndCap;

                FileManager.localSettings.Values["LineNodeFreeLineJoin"] = (int)LineNodeFree.LineJoin;
                FileManager.localSettings.Values["LineNodeFreeMiterLimit"] = (float)LineNodeFree.MiterLimit;
                FileManager.localSettings.Values["LineNodeFreeStartCap"] = (int)LineNodeFree.StartCap;
                FileManager.localSettings.Values["LineNodeFreeWeight"] = (float)LineNodeFreeWeight;

            }

            #endregion
            #region Line Node Fixed
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorNodeFixedA"];
                int R = (int)FileManager.localSettings.Values["ColorNodeFixedR"];
                int G = (int)FileManager.localSettings.Values["ColorNodeFixedG"];
                int B = (int)FileManager.localSettings.Values["ColorNodeFixedB"];

                ColorNodeFixed = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineNodeFixed.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeFixedDashCap"];
                LineNodeFixed.DashOffset = (float)FileManager.localSettings.Values["LineNodeFixedDashOffset"];
                LineNodeFixed.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineNodeFixedDashStyle"];
                LineNodeFixed.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeFixedEndCap"];
                LineNodeFixed.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineNodeFixedLineJoin"];
                LineNodeFixed.MiterLimit = (float)FileManager.localSettings.Values["LineNodeFixedMiterLimit"];
                LineNodeFixed.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeFixedStartCap"];
                LineNodeFixedWeight = (float)FileManager.localSettings.Values["LineNodeFixedWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorNodeFixedA"] = (int)ColorNodeFixed.A;
                FileManager.localSettings.Values["ColorNodeFixedR"] = (int)ColorNodeFixed.R;
                FileManager.localSettings.Values["ColorNodeFixedG"] = (int)ColorNodeFixed.G;
                FileManager.localSettings.Values["ColorNodeFixedB"] = (int)ColorNodeFixed.B;

                LineNodeFixed.DashCap = CanvasCapStyle.Round;
                LineNodeFixed.DashOffset = 0;
                LineNodeFixed.DashStyle = CanvasDashStyle.Solid;
                LineNodeFixed.EndCap = CanvasCapStyle.Flat;
                LineNodeFixed.LineJoin = CanvasLineJoin.Bevel;
                LineNodeFixed.MiterLimit = 0;
                LineNodeFixed.StartCap = CanvasCapStyle.Flat;
                LineNodeFixedWeight = 1;

                FileManager.localSettings.Values["LineNodeFixedDashCap"] = (int)LineNodeFixed.DashCap;
                FileManager.localSettings.Values["LineNodeFixedDashOffset"] = (float)LineNodeFixed.DashOffset;
                FileManager.localSettings.Values["LineNodeFixedDashStyle"] = (int)LineNodeFixed.DashStyle;
                FileManager.localSettings.Values["LineNodeFixedEndCap"] = (int)LineNodeFixed.EndCap;

                FileManager.localSettings.Values["LineNodeFixedLineJoin"] = (int)LineNodeFixed.LineJoin;
                FileManager.localSettings.Values["LineNodeFixedMiterLimit"] = (float)LineNodeFixed.MiterLimit;
                FileManager.localSettings.Values["LineNodeFixedStartCap"] = (int)LineNodeFixed.StartCap;
                FileManager.localSettings.Values["LineNodeFixedWeight"] = (float)LineNodeFixedWeight;

            }

            #endregion
            #region Line Node Pin
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorNodePinA"];
                int R = (int)FileManager.localSettings.Values["ColorNodePinR"];
                int G = (int)FileManager.localSettings.Values["ColorNodePinG"];
                int B = (int)FileManager.localSettings.Values["ColorNodePinB"];

                ColorNodePin = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineNodePin.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodePinDashCap"];
                LineNodePin.DashOffset = (float)FileManager.localSettings.Values["LineNodePinDashOffset"];
                LineNodePin.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineNodePinDashStyle"];
                LineNodePin.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodePinEndCap"];
                LineNodePin.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineNodePinLineJoin"];
                LineNodePin.MiterLimit = (float)FileManager.localSettings.Values["LineNodePinMiterLimit"];
                LineNodePin.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodePinStartCap"];
                LineNodePinWeight = (float)FileManager.localSettings.Values["LineNodePinWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorNodePinA"] = (int)ColorNodePin.A;
                FileManager.localSettings.Values["ColorNodePinR"] = (int)ColorNodePin.R;
                FileManager.localSettings.Values["ColorNodePinG"] = (int)ColorNodePin.G;
                FileManager.localSettings.Values["ColorNodePinB"] = (int)ColorNodePin.B;

                LineNodePin.DashCap = CanvasCapStyle.Round;
                LineNodePin.DashOffset = 0;
                LineNodePin.DashStyle = CanvasDashStyle.Solid;
                LineNodePin.EndCap = CanvasCapStyle.Flat;
                LineNodePin.LineJoin = CanvasLineJoin.Bevel;
                LineNodePin.MiterLimit = 0;
                LineNodePin.StartCap = CanvasCapStyle.Flat;
                LineNodePinWeight = 1;

                FileManager.localSettings.Values["LineNodePinDashCap"] = (int)LineNodePin.DashCap;
                FileManager.localSettings.Values["LineNodePinDashOffset"] = (float)LineNodePin.DashOffset;
                FileManager.localSettings.Values["LineNodePinDashStyle"] = (int)LineNodePin.DashStyle;
                FileManager.localSettings.Values["LineNodePinEndCap"] = (int)LineNodePin.EndCap;

                FileManager.localSettings.Values["LineNodePinLineJoin"] = (int)LineNodePin.LineJoin;
                FileManager.localSettings.Values["LineNodePinMiterLimit"] = (float)LineNodePin.MiterLimit;
                FileManager.localSettings.Values["LineNodePinStartCap"] = (int)LineNodePin.StartCap;
                FileManager.localSettings.Values["LineNodePinWeight"] = (float)LineNodePinWeight;

            }

            #endregion
            #region Line Node Roller X
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorNodeRollerXA"];
                int R = (int)FileManager.localSettings.Values["ColorNodeRollerXR"];
                int G = (int)FileManager.localSettings.Values["ColorNodeRollerXG"];
                int B = (int)FileManager.localSettings.Values["ColorNodeRollerXB"];

                ColorNodeRollerX = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineNodeRollerX.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeRollerXDashCap"];
                LineNodeRollerX.DashOffset = (float)FileManager.localSettings.Values["LineNodeRollerXDashOffset"];
                LineNodeRollerX.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineNodeRollerXDashStyle"];
                LineNodeRollerX.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeRollerXEndCap"];
                LineNodeRollerX.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineNodeRollerXLineJoin"];
                LineNodeRollerX.MiterLimit = (float)FileManager.localSettings.Values["LineNodeRollerXMiterLimit"];
                LineNodeRollerX.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeRollerXStartCap"];
                LineNodeRollerXWeight = (float)FileManager.localSettings.Values["LineNodeRollerXWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorNodeRollerXA"] = (int)ColorNodeRollerX.A;
                FileManager.localSettings.Values["ColorNodeRollerXR"] = (int)ColorNodeRollerX.R;
                FileManager.localSettings.Values["ColorNodeRollerXG"] = (int)ColorNodeRollerX.G;
                FileManager.localSettings.Values["ColorNodeRollerXB"] = (int)ColorNodeRollerX.B;

                LineNodeRollerX.DashCap = CanvasCapStyle.Round;
                LineNodeRollerX.DashOffset = 0;
                LineNodeRollerX.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerX.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerX.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerX.MiterLimit = 0;
                LineNodeRollerX.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerXWeight = 1;

                FileManager.localSettings.Values["LineNodeRollerXDashCap"] = (int)LineNodeRollerX.DashCap;
                FileManager.localSettings.Values["LineNodeRollerXDashOffset"] = (float)LineNodeRollerX.DashOffset;
                FileManager.localSettings.Values["LineNodeRollerXDashStyle"] = (int)LineNodeRollerX.DashStyle;
                FileManager.localSettings.Values["LineNodeRollerXEndCap"] = (int)LineNodeRollerX.EndCap;

                FileManager.localSettings.Values["LineNodeRollerXLineJoin"] = (int)LineNodeRollerX.LineJoin;
                FileManager.localSettings.Values["LineNodeRollerXMiterLimit"] = (float)LineNodeRollerX.MiterLimit;
                FileManager.localSettings.Values["LineNodeRollerXStartCap"] = (int)LineNodeRollerX.StartCap;
                FileManager.localSettings.Values["LineNodeRollerXWeight"] = (float)LineNodeRollerXWeight;

            }

            #endregion
            #region Line Node Roller Y
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorNodeRollerYA"];
                int R = (int)FileManager.localSettings.Values["ColorNodeRollerYR"];
                int G = (int)FileManager.localSettings.Values["ColorNodeRollerYG"];
                int B = (int)FileManager.localSettings.Values["ColorNodeRollerYB"];

                ColorNodeRollerY = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineNodeRollerY.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeRollerYDashCap"];
                LineNodeRollerY.DashOffset = (float)FileManager.localSettings.Values["LineNodeRollerYDashOffset"];
                LineNodeRollerY.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineNodeRollerYDashStyle"];
                LineNodeRollerY.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeRollerYEndCap"];
                LineNodeRollerY.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineNodeRollerYLineJoin"];
                LineNodeRollerY.MiterLimit = (float)FileManager.localSettings.Values["LineNodeRollerYMiterLimit"];
                LineNodeRollerY.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeRollerYStartCap"];
                LineNodeRollerYWeight = (float)FileManager.localSettings.Values["LineNodeRollerYWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorNodeRollerYA"] = (int)ColorNodeRollerY.A;
                FileManager.localSettings.Values["ColorNodeRollerYR"] = (int)ColorNodeRollerY.R;
                FileManager.localSettings.Values["ColorNodeRollerYG"] = (int)ColorNodeRollerY.G;
                FileManager.localSettings.Values["ColorNodeRollerYB"] = (int)ColorNodeRollerY.B;

                LineNodeRollerY.DashCap = CanvasCapStyle.Round;
                LineNodeRollerY.DashOffset = 0;
                LineNodeRollerY.DashStyle = CanvasDashStyle.Solid;
                LineNodeRollerY.EndCap = CanvasCapStyle.Flat;
                LineNodeRollerY.LineJoin = CanvasLineJoin.Bevel;
                LineNodeRollerY.MiterLimit = 0;
                LineNodeRollerY.StartCap = CanvasCapStyle.Flat;
                LineNodeRollerYWeight = 1;

                FileManager.localSettings.Values["LineNodeRollerYDashCap"] = (int)LineNodeRollerY.DashCap;
                FileManager.localSettings.Values["LineNodeRollerYDashOffset"] = (float)LineNodeRollerY.DashOffset;
                FileManager.localSettings.Values["LineNodeRollerYDashStyle"] = (int)LineNodeRollerY.DashStyle;
                FileManager.localSettings.Values["LineNodeRollerYEndCap"] = (int)LineNodeRollerY.EndCap;

                FileManager.localSettings.Values["LineNodeRollerYLineJoin"] = (int)LineNodeRollerY.LineJoin;
                FileManager.localSettings.Values["LineNodeRollerYMiterLimit"] = (float)LineNodeRollerY.MiterLimit;
                FileManager.localSettings.Values["LineNodeRollerYStartCap"] = (int)LineNodeRollerY.StartCap;
                FileManager.localSettings.Values["LineNodeRollerYWeight"] = (float)LineNodeRollerYWeight;

            }

            #endregion
            #region Line Node Other
            try
            {
                int A = (int)FileManager.localSettings.Values["ColorNodeOtherA"];
                int R = (int)FileManager.localSettings.Values["ColorNodeOtherR"];
                int G = (int)FileManager.localSettings.Values["ColorNodeOtherG"];
                int B = (int)FileManager.localSettings.Values["ColorNodeOtherB"];

                ColorNodeOther = Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);

                LineNodeOther.DashCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeOtherDashCap"];
                LineNodeOther.DashOffset = (float)FileManager.localSettings.Values["LineNodeOtherDashOffset"];
                LineNodeOther.DashStyle = (CanvasDashStyle)FileManager.localSettings.Values["LineNodeOtherDashStyle"];
                LineNodeOther.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeOtherEndCap"];
                LineNodeOther.LineJoin = (CanvasLineJoin)FileManager.localSettings.Values["LineNodeOtherLineJoin"];
                LineNodeOther.MiterLimit = (float)FileManager.localSettings.Values["LineNodeOtherMiterLimit"];
                LineNodeOther.StartCap = (CanvasCapStyle)FileManager.localSettings.Values["LineNodeOtherStartCap"];
                LineNodeOtherWeight = (float)FileManager.localSettings.Values["LineNodeOtherWeight"];

            }
            catch
            {

                FileManager.localSettings.Values["ColorNodeOtherA"] = (int)ColorNodeOther.A;
                FileManager.localSettings.Values["ColorNodeOtherR"] = (int)ColorNodeOther.R;
                FileManager.localSettings.Values["ColorNodeOtherG"] = (int)ColorNodeOther.G;
                FileManager.localSettings.Values["ColorNodeOtherB"] = (int)ColorNodeOther.B;

                LineNodeOther.DashCap = CanvasCapStyle.Round;
                LineNodeOther.DashOffset = 0;
                LineNodeOther.DashStyle = CanvasDashStyle.Solid;
                LineNodeOther.EndCap = CanvasCapStyle.Flat;
                LineNodeOther.LineJoin = CanvasLineJoin.Bevel;
                LineNodeOther.MiterLimit = 0;
                LineNodeOther.StartCap = CanvasCapStyle.Flat;
                LineNodeOtherWeight = 1;

                FileManager.localSettings.Values["LineNodeOtherDashCap"] = (int)LineNodeOther.DashCap;
                FileManager.localSettings.Values["LineNodeOtherDashOffset"] = (float)LineNodeOther.DashOffset;
                FileManager.localSettings.Values["LineNodeOtherDashStyle"] = (int)LineNodeOther.DashStyle;
                FileManager.localSettings.Values["LineNodeOtherEndCap"] = (int)LineNodeOther.EndCap;

                FileManager.localSettings.Values["LineNodeOtherLineJoin"] = (int)LineNodeOther.LineJoin;
                FileManager.localSettings.Values["LineNodeOtherMiterLimit"] = (float)LineNodeOther.MiterLimit;
                FileManager.localSettings.Values["LineNodeOtherStartCap"] = (int)LineNodeOther.StartCap;
                FileManager.localSettings.Values["LineNodeOtherWeight"] = (float)LineNodeOtherWeight;

            }

            #endregion

            #endregion

            #region Factors

            try
            {
                double tmpDouble = (double)FileManager.localSettings.Values["MomentFactor"];
                momentFactor = (float)tmpDouble;
            }
            catch
            {
                Debug.WriteLine("Error Loading MomentFactor");
                FileManager.localSettings.Values["MomentFactor"] = 0.0001f;
                momentFactor = 0.0001f;
            }

            try
            {
                double tmpDouble = (double)FileManager.localSettings.Values["ShearFactor"];
                shearFactor = (float)tmpDouble;
            }
            catch
            {
                Debug.WriteLine("Error Loading ShearFactor");
                FileManager.localSettings.Values["ShearFactor"] = 0.0001f;
                shearFactor = 0.0001f;
            }

            try
            {
                double tmpDouble = (double)FileManager.localSettings.Values["LinearFactor"];
                linearFactor = (float)tmpDouble;
            }
            catch
            {
                Debug.WriteLine("Error Loading LinearFactor");
                FileManager.localSettings.Values["LinearFactor"] = 0.0001f;
                linearFactor = 0.0001f;
            }


            try
            {
                double tmpDouble = (double)FileManager.localSettings.Values["ForcesFactor"];
                forcesFactor = (float)tmpDouble;
            }
            catch
            {
                Debug.WriteLine("Error Loading ForcesFactor");
                FileManager.localSettings.Values["ForcesFactor"] = 0.0001f;
                forcesFactor = 0.0001f;
            }

            try
            {
                double tmpDouble = (double)FileManager.localSettings.Values["ReactionsFactor"];
                reactionsFactor = (float)tmpDouble;
            }
            catch
            {
                Debug.WriteLine("Error Loading ReactionsFactor");
                FileManager.localSettings.Values["ReactionsFactor"] = 0.0001f;
                reactionsFactor = 0.0001f;
            }




            try
            {
                double tmpDouble = (double)FileManager.localSettings.Values["DisplacementFactor"];
                displacementFactor = (float)tmpDouble;
            }
            catch
            {
                Debug.WriteLine("Error Loading DisplacementFactor");
                FileManager.localSettings.Values["DisplacementFactor"] = 1f;
                displacementFactor = 1f;
            }

            #endregion

            #region Camera

            try
            {
                Single tmpSingle = (Single)FileManager.localSettings.Values["CameraZoomTrim"];
                CameraZoomTrim = (float)tmpSingle;
            }
            catch
            {
                Debug.WriteLine("Error Loading ZoomTrim");
                FileManager.localSettings.Values["CameraZoomTrim"] = 500f;
                CameraZoomTrim = 500f;
            }
            Camera.ZoomTrim = CameraZoomTrim;


            try
            {
                Single tmpSingle = (Single)FileManager.localSettings.Values["SelectGridSize"];
                SelectGridSize = (float)tmpSingle;
            }
            catch
            {
                Debug.WriteLine("Error Loading SelectGridSize");
                FileManager.localSettings.Values["SelectGridSize"] = 1f;
                SelectGridSize = 1f;
            }

            #endregion
        }

        internal static void SaveOptions()
        {

            #region Camera

            FileManager.localSettings.Values["CameraZoomTrim"] = (float)CameraZoomTrim;
            FileManager.localSettings.Values["SelectGridSize"] = (float)SelectGridSize;

            #endregion

            #region Lines

            #region Line Grid Normal

            FileManager.localSettings.Values["ColorGridNormalA"] = (int)ColorGridNormal.A;
            FileManager.localSettings.Values["ColorGridNormalR"] = (int)ColorGridNormal.R;
            FileManager.localSettings.Values["ColorGridNormalG"] = (int)ColorGridNormal.G;
            FileManager.localSettings.Values["ColorGridNormalB"] = (int)ColorGridNormal.B;

            FileManager.localSettings.Values["LineGridNormalDashCap"] = (int)LineGridNormal.DashCap;
            FileManager.localSettings.Values["LineGridNormalDashOffset"] = (float)LineGridNormal.DashOffset;
            FileManager.localSettings.Values["LineGridNormalDashStyle"] = (int)LineGridNormal.DashStyle;
            FileManager.localSettings.Values["LineGridNormalEndCap"] = (int)LineGridNormal.EndCap;
            FileManager.localSettings.Values["LineGridNormalLineJoin"] = (int)LineGridNormal.LineJoin;
            FileManager.localSettings.Values["LineGridNormalMiterLimit"] = (float)LineGridNormal.MiterLimit;
            FileManager.localSettings.Values["LineGridNormalStartCap"] = (int)LineGridNormal.StartCap;
            FileManager.localSettings.Values["LineGridNormalWeight"] = (float)LineGridNormalWeight;

            #endregion
            #region Line Grid Minor

            FileManager.localSettings.Values["ColorGridMinorA"] = (int)ColorGridMinor.A;
            FileManager.localSettings.Values["ColorGridMinorR"] = (int)ColorGridMinor.R;
            FileManager.localSettings.Values["ColorGridMinorG"] = (int)ColorGridMinor.G;
            FileManager.localSettings.Values["ColorGridMinorB"] = (int)ColorGridMinor.B;

            FileManager.localSettings.Values["LineGridMinorDashCap"] = (int)LineGridMinor.DashCap;
            FileManager.localSettings.Values["LineGridMinorDashOffset"] = (float)LineGridMinor.DashOffset;
            FileManager.localSettings.Values["LineGridMinorDashStyle"] = (int)LineGridMinor.DashStyle;
            FileManager.localSettings.Values["LineGridMinorEndCap"] = (int)LineGridMinor.EndCap;
            FileManager.localSettings.Values["LineGridMinorLineJoin"] = (int)LineGridMinor.LineJoin;
            FileManager.localSettings.Values["LineGridMinorMiterLimit"] = (float)LineGridMinor.MiterLimit;
            FileManager.localSettings.Values["LineGridMinorStartCap"] = (int)LineGridMinor.StartCap;
            FileManager.localSettings.Values["LineGridMinorWeight"] = (float)LineGridMinorWeight;

            #endregion
            #region Line Grid Major

            FileManager.localSettings.Values["ColorGridMajorA"] = (int)ColorGridMajor.A;
            FileManager.localSettings.Values["ColorGridMajorR"] = (int)ColorGridMajor.R;
            FileManager.localSettings.Values["ColorGridMajorG"] = (int)ColorGridMajor.G;
            FileManager.localSettings.Values["ColorGridMajorB"] = (int)ColorGridMajor.B;

            FileManager.localSettings.Values["LineGridMajorDashCap"] = (int)LineGridMajor.DashCap;
            FileManager.localSettings.Values["LineGridMajorDashOffset"] = (float)LineGridMajor.DashOffset;
            FileManager.localSettings.Values["LineGridMajorDashStyle"] = (int)LineGridMajor.DashStyle;
            FileManager.localSettings.Values["LineGridMajorEndCap"] = (int)LineGridMajor.EndCap;
            FileManager.localSettings.Values["LineGridMajorLineJoin"] = (int)LineGridMajor.LineJoin;
            FileManager.localSettings.Values["LineGridMajorMiterLimit"] = (float)LineGridMajor.MiterLimit;
            FileManager.localSettings.Values["LineGridMajorStartCap"] = (int)LineGridMajor.StartCap;
            FileManager.localSettings.Values["LineGridMajorWeight"] = (float)LineGridMajorWeight;

            #endregion
            #region Line Selected Element

            FileManager.localSettings.Values["ColorSelectedElementA"] = (int)ColorSelectedElement.A;
            FileManager.localSettings.Values["ColorSelectedElementR"] = (int)ColorSelectedElement.R;
            FileManager.localSettings.Values["ColorSelectedElementG"] = (int)ColorSelectedElement.G;
            FileManager.localSettings.Values["ColorSelectedElementB"] = (int)ColorSelectedElement.B;

            FileManager.localSettings.Values["LineSelectedElementDashCap"] = (int)LineSelectedElement.DashCap;
            FileManager.localSettings.Values["LineSelectedElementDashOffset"] = (float)LineSelectedElement.DashOffset;
            FileManager.localSettings.Values["LineSelectedElementDashStyle"] = (int)LineSelectedElement.DashStyle;
            FileManager.localSettings.Values["LineSelectedElementEndCap"] = (int)LineSelectedElement.EndCap;
            FileManager.localSettings.Values["LineSelectedElementLineJoin"] = (int)LineSelectedElement.LineJoin;
            FileManager.localSettings.Values["LineSelectedElementMiterLimit"] = (float)LineSelectedElement.MiterLimit;
            FileManager.localSettings.Values["LineSelectedElementStartCap"] = (int)LineSelectedElement.StartCap;
            FileManager.localSettings.Values["LineSelectedElementWeight"] = (float)LineSelectedElementWeight;

            #endregion
            #region Line Force

            FileManager.localSettings.Values["ColorForceA"] = (int)ColorForce.A;
            FileManager.localSettings.Values["ColorForceR"] = (int)ColorForce.R;
            FileManager.localSettings.Values["ColorForceG"] = (int)ColorForce.G;
            FileManager.localSettings.Values["ColorForceB"] = (int)ColorForce.B;

            FileManager.localSettings.Values["LineForceDashCap"] = (int)LineForce.DashCap;
            FileManager.localSettings.Values["LineForceDashOffset"] = (float)LineForce.DashOffset;
            FileManager.localSettings.Values["LineForceDashStyle"] = (int)LineForce.DashStyle;
            FileManager.localSettings.Values["LineForceEndCap"] = (int)LineForce.EndCap;
            FileManager.localSettings.Values["LineForceLineJoin"] = (int)LineForce.LineJoin;
            FileManager.localSettings.Values["LineForceMiterLimit"] = (float)LineForce.MiterLimit;
            FileManager.localSettings.Values["LineForceStartCap"] = (int)LineForce.StartCap;
            FileManager.localSettings.Values["LineForceWeight"] = (float)LineForceWeight;

            #endregion
            #region Line Reaction

            FileManager.localSettings.Values["ColorReactionA"] = (int)ColorReaction.A;
            FileManager.localSettings.Values["ColorReactionR"] = (int)ColorReaction.R;
            FileManager.localSettings.Values["ColorReactionG"] = (int)ColorReaction.G;
            FileManager.localSettings.Values["ColorReactionB"] = (int)ColorReaction.B;

            FileManager.localSettings.Values["LineReactionDashCap"] = (int)LineReaction.DashCap;
            FileManager.localSettings.Values["LineReactionDashOffset"] = (float)LineReaction.DashOffset;
            FileManager.localSettings.Values["LineReactionDashStyle"] = (int)LineReaction.DashStyle;
            FileManager.localSettings.Values["LineReactionEndCap"] = (int)LineReaction.EndCap;
            FileManager.localSettings.Values["LineReactionLineJoin"] = (int)LineReaction.LineJoin;
            FileManager.localSettings.Values["LineReactionMiterLimit"] = (float)LineReaction.MiterLimit;
            FileManager.localSettings.Values["LineReactionStartCap"] = (int)LineReaction.StartCap;
            FileManager.localSettings.Values["LineReactionWeight"] = (float)LineReactionWeight;

            #endregion
            #region Line Shear Force Selected

            FileManager.localSettings.Values["ColorShearForceSelectedA"] = (int)ColorShearForceSelected.A;
            FileManager.localSettings.Values["ColorShearForceSelectedR"] = (int)ColorShearForceSelected.R;
            FileManager.localSettings.Values["ColorShearForceSelectedG"] = (int)ColorShearForceSelected.G;
            FileManager.localSettings.Values["ColorShearForceSelectedB"] = (int)ColorShearForceSelected.B;

            FileManager.localSettings.Values["LineShearForceSelectedDashCap"] = (int)LineShearForceSelected.DashCap;
            FileManager.localSettings.Values["LineShearForceSelectedDashOffset"] = (float)LineShearForceSelected.DashOffset;
            FileManager.localSettings.Values["LineShearForceSelectedDashStyle"] = (int)LineShearForceSelected.DashStyle;
            FileManager.localSettings.Values["LineShearForceSelectedEndCap"] = (int)LineShearForceSelected.EndCap;
            FileManager.localSettings.Values["LineShearForceSelectedLineJoin"] = (int)LineShearForceSelected.LineJoin;
            FileManager.localSettings.Values["LineShearForceSelectedMiterLimit"] = (float)LineShearForceSelected.MiterLimit;
            FileManager.localSettings.Values["LineShearForceSelectedStartCap"] = (int)LineShearForceSelected.StartCap;
            FileManager.localSettings.Values["LineShearForceSelectedWeight"] = (float)LineShearForceSelectedWeight;

            #endregion
            #region Line Shear Force

            FileManager.localSettings.Values["ColorShearForceA"] = (int)ColorShearForce.A;
            FileManager.localSettings.Values["ColorShearForceR"] = (int)ColorShearForce.R;
            FileManager.localSettings.Values["ColorShearForceG"] = (int)ColorShearForce.G;
            FileManager.localSettings.Values["ColorShearForceB"] = (int)ColorShearForce.B;

            FileManager.localSettings.Values["LineShearForceDashCap"] = (int)LineShearForce.DashCap;
            FileManager.localSettings.Values["LineShearForceDashOffset"] = (float)LineShearForce.DashOffset;
            FileManager.localSettings.Values["LineShearForceDashStyle"] = (int)LineShearForce.DashStyle;
            FileManager.localSettings.Values["LineShearForceEndCap"] = (int)LineShearForce.EndCap;
            FileManager.localSettings.Values["LineShearForceLineJoin"] = (int)LineShearForce.LineJoin;
            FileManager.localSettings.Values["LineShearForceMiterLimit"] = (float)LineShearForce.MiterLimit;
            FileManager.localSettings.Values["LineShearForceStartCap"] = (int)LineShearForce.StartCap;
            FileManager.localSettings.Values["LineShearForceWeight"] = (float)LineShearForceWeight;

            #endregion
            #region Line Moment Force Selected

            FileManager.localSettings.Values["ColorMomentForceSelectedA"] = (int)ColorMomentForceSelected.A;
            FileManager.localSettings.Values["ColorMomentForceSelectedR"] = (int)ColorMomentForceSelected.R;
            FileManager.localSettings.Values["ColorMomentForceSelectedG"] = (int)ColorMomentForceSelected.G;
            FileManager.localSettings.Values["ColorMomentForceSelectedB"] = (int)ColorMomentForceSelected.B;

            FileManager.localSettings.Values["LineMomentForceSelectedDashCap"] = (int)LineMomentForceSelected.DashCap;
            FileManager.localSettings.Values["LineMomentForceSelectedDashOffset"] = (float)LineMomentForceSelected.DashOffset;
            FileManager.localSettings.Values["LineMomentForceSelectedDashStyle"] = (int)LineMomentForceSelected.DashStyle;
            FileManager.localSettings.Values["LineMomentForceSelectedEndCap"] = (int)LineMomentForceSelected.EndCap;
            FileManager.localSettings.Values["LineMomentForceSelectedLineJoin"] = (int)LineMomentForceSelected.LineJoin;
            FileManager.localSettings.Values["LineMomentForceSelectedMiterLimit"] = (float)LineMomentForceSelected.MiterLimit;
            FileManager.localSettings.Values["LineMomentForceSelectedStartCap"] = (int)LineMomentForceSelected.StartCap;
            FileManager.localSettings.Values["LineMomentForceSelectedWeight"] = (float)LineMomentForceSelectedWeight;

            #endregion
            #region Line Moment Force

            FileManager.localSettings.Values["ColorMomentForceA"] = (int)ColorMomentForce.A;
            FileManager.localSettings.Values["ColorMomentForceR"] = (int)ColorMomentForce.R;
            FileManager.localSettings.Values["ColorMomentForceG"] = (int)ColorMomentForce.G;
            FileManager.localSettings.Values["ColorMomentForceB"] = (int)ColorMomentForce.B;

            FileManager.localSettings.Values["LineMomentForceDashCap"] = (int)LineMomentForce.DashCap;
            FileManager.localSettings.Values["LineMomentForceDashOffset"] = (float)LineMomentForce.DashOffset;
            FileManager.localSettings.Values["LineMomentForceDashStyle"] = (int)LineMomentForce.DashStyle;
            FileManager.localSettings.Values["LineMomentForceEndCap"] = (int)LineMomentForce.EndCap;
            FileManager.localSettings.Values["LineMomentForceLineJoin"] = (int)LineMomentForce.LineJoin;
            FileManager.localSettings.Values["LineMomentForceMiterLimit"] = (float)LineMomentForce.MiterLimit;
            FileManager.localSettings.Values["LineMomentForceStartCap"] = (int)LineMomentForce.StartCap;
            FileManager.localSettings.Values["LineMomentForceWeight"] = (float)LineMomentForceWeight;

            #endregion
            #region Line Distributed Force Collected

            FileManager.localSettings.Values["ColorDistributedForceSelectedA"] = (int)ColorDistributedForceSelected.A;
            FileManager.localSettings.Values["ColorDistributedForceSelectedR"] = (int)ColorDistributedForceSelected.R;
            FileManager.localSettings.Values["ColorDistributedForceSelectedG"] = (int)ColorDistributedForceSelected.G;
            FileManager.localSettings.Values["ColorDistributedForceSelectedB"] = (int)ColorDistributedForceSelected.B;

            FileManager.localSettings.Values["LineDistributedForceSelectedDashCap"] = (int)LineDistributedForceSelected.DashCap;
            FileManager.localSettings.Values["LineDistributedForceSelectedDashOffset"] = (float)LineDistributedForceSelected.DashOffset;
            FileManager.localSettings.Values["LineDistributedForceSelectedDashStyle"] = (int)LineDistributedForceSelected.DashStyle;
            FileManager.localSettings.Values["LineDistributedForceSelectedEndCap"] = (int)LineDistributedForceSelected.EndCap;
            FileManager.localSettings.Values["LineDistributedForceSelectedLineJoin"] = (int)LineDistributedForceSelected.LineJoin;
            FileManager.localSettings.Values["LineDistributedForceSelectedMiterLimit"] = (float)LineDistributedForceSelected.MiterLimit;
            FileManager.localSettings.Values["LineDistributedForceSelectedStartCap"] = (int)LineDistributedForceSelected.StartCap;
            FileManager.localSettings.Values["LineDistributedForceSelectedWeight"] = (float)LineDistributedForceSelectedWeight;

            #endregion
            #region Line Distributed Force

            FileManager.localSettings.Values["ColorDistributedForceA"] = (int)ColorDistributedForce.A;
            FileManager.localSettings.Values["ColorDistributedForceR"] = (int)ColorDistributedForce.R;
            FileManager.localSettings.Values["ColorDistributedForceG"] = (int)ColorDistributedForce.G;
            FileManager.localSettings.Values["ColorDistributedForceB"] = (int)ColorDistributedForce.B;

            FileManager.localSettings.Values["LineDistributedForceDashCap"] = (int)LineDistributedForce.DashCap;
            FileManager.localSettings.Values["LineDistributedForceDashOffset"] = (float)LineDistributedForce.DashOffset;
            FileManager.localSettings.Values["LineDistributedForceDashStyle"] = (int)LineDistributedForce.DashStyle;
            FileManager.localSettings.Values["LineDistributedForceEndCap"] = (int)LineDistributedForce.EndCap;
            FileManager.localSettings.Values["LineDistributedForceLineJoin"] = (int)LineDistributedForce.LineJoin;
            FileManager.localSettings.Values["LineDistributedForceMiterLimit"] = (float)LineDistributedForce.MiterLimit;
            FileManager.localSettings.Values["LineDistributedForceStartCap"] = (int)LineDistributedForce.StartCap;
            FileManager.localSettings.Values["LineDistributedForceWeight"] = (float)LineDistributedForceWeight;

            #endregion
            #region Line Node Free

            FileManager.localSettings.Values["ColorNodeFreeA"] = (int)ColorNodeFree.A;
            FileManager.localSettings.Values["ColorNodeFreeR"] = (int)ColorNodeFree.R;
            FileManager.localSettings.Values["ColorNodeFreeG"] = (int)ColorNodeFree.G;
            FileManager.localSettings.Values["ColorNodeFreeB"] = (int)ColorNodeFree.B;

            FileManager.localSettings.Values["LineNodeFreeDashCap"] = (int)LineNodeFree.DashCap;
            FileManager.localSettings.Values["LineNodeFreeDashOffset"] = (float)LineNodeFree.DashOffset;
            FileManager.localSettings.Values["LineNodeFreeDashStyle"] = (int)LineNodeFree.DashStyle;
            FileManager.localSettings.Values["LineNodeFreeEndCap"] = (int)LineNodeFree.EndCap;
            FileManager.localSettings.Values["LineNodeFreeLineJoin"] = (int)LineNodeFree.LineJoin;
            FileManager.localSettings.Values["LineNodeFreeMiterLimit"] = (float)LineNodeFree.MiterLimit;
            FileManager.localSettings.Values["LineNodeFreeStartCap"] = (int)LineNodeFree.StartCap;
            FileManager.localSettings.Values["LineNodeFreeWeight"] = (float)LineNodeFreeWeight;

            #endregion
            #region Line Node Fixed

            FileManager.localSettings.Values["ColorNodeFixedA"] = (int)ColorNodeFixed.A;
            FileManager.localSettings.Values["ColorNodeFixedR"] = (int)ColorNodeFixed.R;
            FileManager.localSettings.Values["ColorNodeFixedG"] = (int)ColorNodeFixed.G;
            FileManager.localSettings.Values["ColorNodeFixedB"] = (int)ColorNodeFixed.B;

            FileManager.localSettings.Values["LineNodeFixedDashCap"] = (int)LineNodeFixed.DashCap;
            FileManager.localSettings.Values["LineNodeFixedDashOffset"] = (float)LineNodeFixed.DashOffset;
            FileManager.localSettings.Values["LineNodeFixedDashStyle"] = (int)LineNodeFixed.DashStyle;
            FileManager.localSettings.Values["LineNodeFixedEndCap"] = (int)LineNodeFixed.EndCap;
            FileManager.localSettings.Values["LineNodeFixedLineJoin"] = (int)LineNodeFixed.LineJoin;
            FileManager.localSettings.Values["LineNodeFixedMiterLimit"] = (float)LineNodeFixed.MiterLimit;
            FileManager.localSettings.Values["LineNodeFixedStartCap"] = (int)LineNodeFixed.StartCap;
            FileManager.localSettings.Values["LineNodeFixedWeight"] = (float)LineNodeFixedWeight;

            #endregion
            #region Line Node Pin

            FileManager.localSettings.Values["ColorNodePinA"] = (int)ColorNodePin.A;
            FileManager.localSettings.Values["ColorNodePinR"] = (int)ColorNodePin.R;
            FileManager.localSettings.Values["ColorNodePinG"] = (int)ColorNodePin.G;
            FileManager.localSettings.Values["ColorNodePinB"] = (int)ColorNodePin.B;

            FileManager.localSettings.Values["LineNodePinDashCap"] = (int)LineNodePin.DashCap;
            FileManager.localSettings.Values["LineNodePinDashOffset"] = (float)LineNodePin.DashOffset;
            FileManager.localSettings.Values["LineNodePinDashStyle"] = (int)LineNodePin.DashStyle;
            FileManager.localSettings.Values["LineNodePinEndCap"] = (int)LineNodePin.EndCap;
            FileManager.localSettings.Values["LineNodePinLineJoin"] = (int)LineNodePin.LineJoin;
            FileManager.localSettings.Values["LineNodePinMiterLimit"] = (float)LineNodePin.MiterLimit;
            FileManager.localSettings.Values["LineNodePinStartCap"] = (int)LineNodePin.StartCap;
            FileManager.localSettings.Values["LineNodePinWeight"] = (float)LineNodePinWeight;

            #endregion
            #region Line Node Roller X

            FileManager.localSettings.Values["ColorNodeRollerXA"] = (int)ColorNodeRollerX.A;
            FileManager.localSettings.Values["ColorNodeRollerXR"] = (int)ColorNodeRollerX.R;
            FileManager.localSettings.Values["ColorNodeRollerXG"] = (int)ColorNodeRollerX.G;
            FileManager.localSettings.Values["ColorNodeRollerXB"] = (int)ColorNodeRollerX.B;

            FileManager.localSettings.Values["LineNodeRollerXDashCap"] = (int)LineNodeRollerX.DashCap;
            FileManager.localSettings.Values["LineNodeRollerXDashOffset"] = (float)LineNodeRollerX.DashOffset;
            FileManager.localSettings.Values["LineNodeRollerXDashStyle"] = (int)LineNodeRollerX.DashStyle;
            FileManager.localSettings.Values["LineNodeRollerXEndCap"] = (int)LineNodeRollerX.EndCap;
            FileManager.localSettings.Values["LineNodeRollerXLineJoin"] = (int)LineNodeRollerX.LineJoin;
            FileManager.localSettings.Values["LineNodeRollerXMiterLimit"] = (float)LineNodeRollerX.MiterLimit;
            FileManager.localSettings.Values["LineNodeRollerXStartCap"] = (int)LineNodeRollerX.StartCap;
            FileManager.localSettings.Values["LineNodeRollerXWeight"] = (float)LineNodeRollerXWeight;

            #endregion
            #region Line Node Roller Y

            FileManager.localSettings.Values["ColorNodeRollerYA"] = (int)ColorNodeRollerY.A;
            FileManager.localSettings.Values["ColorNodeRollerYR"] = (int)ColorNodeRollerY.R;
            FileManager.localSettings.Values["ColorNodeRollerYG"] = (int)ColorNodeRollerY.G;
            FileManager.localSettings.Values["ColorNodeRollerYB"] = (int)ColorNodeRollerY.B;

            FileManager.localSettings.Values["LineNodeRollerYDashCap"] = (int)LineNodeRollerY.DashCap;
            FileManager.localSettings.Values["LineNodeRollerYDashOffset"] = (float)LineNodeRollerY.DashOffset;
            FileManager.localSettings.Values["LineNodeRollerYDashStyle"] = (int)LineNodeRollerY.DashStyle;
            FileManager.localSettings.Values["LineNodeRollerYEndCap"] = (int)LineNodeRollerY.EndCap;
            FileManager.localSettings.Values["LineNodeRollerYLineJoin"] = (int)LineNodeRollerY.LineJoin;
            FileManager.localSettings.Values["LineNodeRollerYMiterLimit"] = (float)LineNodeRollerY.MiterLimit;
            FileManager.localSettings.Values["LineNodeRollerYStartCap"] = (int)LineNodeRollerY.StartCap;
            FileManager.localSettings.Values["LineNodeRollerYWeight"] = (float)LineNodeRollerYWeight;

            #endregion
            #region Line Node Other

            FileManager.localSettings.Values["ColorNodeOtherA"] = (int)ColorNodeOther.A;
            FileManager.localSettings.Values["ColorNodeOtherR"] = (int)ColorNodeOther.R;
            FileManager.localSettings.Values["ColorNodeOtherG"] = (int)ColorNodeOther.G;
            FileManager.localSettings.Values["ColorNodeOtherB"] = (int)ColorNodeOther.B;

            FileManager.localSettings.Values["LineNodeOtherDashCap"] = (int)LineNodeOther.DashCap;
            FileManager.localSettings.Values["LineNodeOtherDashOffset"] = (float)LineNodeOther.DashOffset;
            FileManager.localSettings.Values["LineNodeOtherDashStyle"] = (int)LineNodeOther.DashStyle;
            FileManager.localSettings.Values["LineNodeOtherEndCap"] = (int)LineNodeOther.EndCap;
            FileManager.localSettings.Values["LineNodeOtherLineJoin"] = (int)LineNodeOther.LineJoin;
            FileManager.localSettings.Values["LineNodeOtherMiterLimit"] = (float)LineNodeOther.MiterLimit;
            FileManager.localSettings.Values["LineNodeOtherStartCap"] = (int)LineNodeOther.StartCap;
            FileManager.localSettings.Values["LineNodeOtherWeight"] = (float)LineNodeOtherWeight;

            #endregion

            #endregion
            #region Colors

            FileManager.localSettings.Values["ColorBackgroundA"] = (int)ColorBackground.A;
            FileManager.localSettings.Values["ColorBackgroundR"] = (int)ColorBackground.R;
            FileManager.localSettings.Values["ColorBackgroundG"] = (int)ColorBackground.G;
            FileManager.localSettings.Values["ColorBackgroundB"] = (int)ColorBackground.B;

            FileManager.localSettings.Values["ColorGridMajorFontA"] = (int)ColorGridMajorFont.A;
            FileManager.localSettings.Values["ColorGridMajorFontR"] = (int)ColorGridMajorFont.R;
            FileManager.localSettings.Values["ColorGridMajorFontG"] = (int)ColorGridMajorFont.G;
            FileManager.localSettings.Values["ColorGridMajorFontB"] = (int)ColorGridMajorFont.B;

            FileManager.localSettings.Values["ColorLabelA"] = (int)ColorLabel.A;
            FileManager.localSettings.Values["ColorLabelR"] = (int)ColorLabel.R;
            FileManager.localSettings.Values["ColorLabelG"] = (int)ColorLabel.G;
            FileManager.localSettings.Values["ColorLabelB"] = (int)ColorLabel.B;

            #endregion
            #region Units

            FileManager.localSettings.Values["UnitAngle"] = (int)angle;
            FileManager.localSettings.Values["UnitArea"] = (int)area;
            FileManager.localSettings.Values["UnitDensity"] = (int)density;
            FileManager.localSettings.Values["UnitForce"] = (int)force;
            FileManager.localSettings.Values["UnitForcePerLength"] = (int)forcePerLength;
            FileManager.localSettings.Values["UnitLength"] = (int)length;
            FileManager.localSettings.Values["UnitMass"] = (int)mass;


            FileManager.localSettings.Values["UnitMoment"] = (int)moment;
            FileManager.localSettings.Values["UnitMomentOfInertia"] = (int)momentOfInertia;
            FileManager.localSettings.Values["UnitPressure"] = (int)pressure;

            FileManager.localSettings.Values["UnitVolume"] = (int)volume;



            #endregion
            #region Show

            FileManager.localSettings.Values["ShowMoment"] = showMoment;
            FileManager.localSettings.Values["ShowShear"] = showShear;
            FileManager.localSettings.Values["ShowForce"] = showForce;
            FileManager.localSettings.Values["ShowLinear"] = showLinear;
            FileManager.localSettings.Values["ShowAxial"] = showAxial;
            FileManager.localSettings.Values["ShowReactions"] = showReactions;
            FileManager.localSettings.Values["MemberDisplay"] = (int)memberDisplay;

            #endregion
            #region Solver


            FileManager.localSettings.Values["AutoStartSolver"] = (bool)autoStartSolver;
            FileManager.localSettings.Values["AutoFinishSolver"] = (bool)autoFinishSolver;
            FileManager.localSettings.Values["CurrentSolver"] = (int)currentSolver;

            #endregion
            #region General

            FileManager.localSettings.Values["LockNumericalInput"] = lockNumericalInput;
            FileManager.localSettings.Values["LoadLastFileOnStartup"] = loadLastFileOnStartup;
            FileManager.localSettings.Values["defaultNumberOfSegments"] = (int)defaultNumberOfSegments;
            FileManager.localSettings.Values["lastCurrentSection"] = (string)lastCurrentSectionName;
            FileManager.localSettings.Values["ResetExistingMembers"] = (bool)resetExistingMembers;


            #endregion
            #region Factors

            FileManager.localSettings.Values["MomentFactor"] = (double)momentFactor;
            FileManager.localSettings.Values["ShearFactor"] = (double)shearFactor;
            FileManager.localSettings.Values["LinearFactor"] = (double)linearFactor;
            FileManager.localSettings.Values["ForcesFactor"] = (double)forcesFactor;
            FileManager.localSettings.Values["ReactionsFactor"] = (double)reactionsFactor;
            FileManager.localSettings.Values["DisplacementFactor"] = (double)displacementFactor;

            #endregion
        }

        #endregion
    }
}