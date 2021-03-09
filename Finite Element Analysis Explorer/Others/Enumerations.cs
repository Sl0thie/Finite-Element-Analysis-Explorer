using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finite_Element_Analysis_Explorer
{
    #region Constraints

    internal enum ConstraintType
    {
        Unknown,            //???
        Free,               //000
        RollerX,            //010 
        RollerY,            //100
        Pinned,             //110 
        Fixed,              //111
        FixedBottom,        //111
        FixedTop,           //111
        FixedLeft,          //111
        FixedRight,         //111
        PinnedBottom,       //110
        PinnedTop,          //110
        PinnedLeft,         //110
        PinnedRight,        //110
        RollerBottom,       //010
        RollerTop,          //010
        RollerLeft,         //100
        RollerRight,        //100
        TrackBottom,        //011
        TrackTop,           //011
        TrackLeft,          //101
        TrackRight          //101
    }

    [Obsolete]
    internal enum ConstraintDirection
    {
        Unknown,
        Top,
        Bottom,
        Left,
        Right
    }

    #endregion

    #region Units

    internal enum UnitType
    {
        Angle,
        Area,
        Density,
        Force,
        ForcePerLength,
        Length,
        Mass,
        Moment,
        MomentOfInertia,
        Money,
        Percentage,
        Pressure,
        Speed,
        Temprature,
        Time,
        Unitless,
        UnitlessInteger,
        Volume
    }

    internal enum AngleType
    {
        Degrees,
        Radians
    }
    internal enum AreaType
    {
        SquareMetre,
        SquareCentiMetre,
        SquareMilliMetre,
        SquareFoot,
        SquareInch
    }
    internal enum DensityType
    {
        KilogramPerCubicMetre,
        PoundPerCubicFoot
    }
    internal enum ForceType
    {
        Newton,
        KiloNewton,
        MegaNewton,
        GigaNewton,
        Dyne,
        KilogramForce,
        PoundForce,
        Poundal
    }
    internal enum ForcePerLengthType
    {
        NewtonPerMeter,
        PoundPerFoot
    }
    internal enum LengthType
    {
        Meter,          //m  1 / 1m
        Millimeter,     //mm 1000 / 0.001m
        CentiMeter,     //cm 100 / 0.01m
        KiloMeter,      //km 0.001 / 1000m
        mil,            //39370.0787 / 0.0000254m
        Inch,           //in 39.3700787 / 0.0254m
        Foot,           //ft 3.2808399 / 0.3048m
        yard,           //yard 1.0936133 / 0.9144m
        mile            //mile 0.00062137 / 1609.344m
    }
    internal enum MassType
    {
        Kilogram,
        Pound,
        Gram,
        Ton
    }
    internal enum MomentType
    {
        NewtonMetre,
        PoundFoot,
        PoundInch,
        OunceInch,
        OunceFoot
    }
    internal enum MomentOfInertiaType
    {
        QuadMeter,
        QuadMillimeter,
        QuadCentmeter,
        QuadFoot,
        QuadInch
    }
    internal enum MoneyType
    {
        Default
    }
    internal enum PercentageType
    {
        Default
    }
    internal enum PressureType
    {
        Pascal,
        Millipascal,
        Hectopascal,
        Kilopascal,
        Megapascal,
        Gigapascal,
        PoundPerSquareInch,
        KilopoundPerSquareInch,
        MegapoundPerSquareInch,
        PoundPerSqareFoot
    }
    internal enum SpeedType
    {
        MeterPerSecond
    }
    internal enum TempratureType
    {
        Kelvin,
        Cel
    }
    internal enum TimeType
    {
        Seconds
    }
    internal enum VolumeType
    {
        CubicMetre,
        CubicCentimeter,
        CubicMillimeter,
        CubicFoot,
        CubicInch
    }

    #endregion

    #region Line

    internal enum LineType
    {
        Solid,
        Dash,
        Dot,
        DashDot,
        DashDotDash
    }
    internal enum CapStyle
    {
        Flat,
        Square,
        Round,
        Triangle
    }
    internal enum LoadType
    {
        Nodal,
        Linear
    }

    #endregion

    #region State

    internal enum ConstructionMode
    {
        File,
        Add,
        Nodes,
        Members,
        Sections,
        Help,
        Zoom,
        Settings
    };

    internal enum PageState
    {
        Unknown,
        FileLoading,
        Construction,
        Solver,
        Sections,
        Results
    };

    internal enum SelectionState
    {
        Ready,  // Not selected.
        FirstNode,
        SecondNode
    };

    internal enum SolveState
    {
        Unknown,
        Setup,
        Solving,
        Solved,
        Cancelling,
        Cancelled
    };
    #endregion

}
