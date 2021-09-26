namespace Finite_Element_Analysis_Explorer
{
    #region Constraints

    /// <summary>
    /// The constraint type for the node.
    /// </summary>
    internal enum ConstraintType
    {
        /// <summary>
        /// ???
        /// </summary>
        Unknown,

        /// <summary>
        /// 000
        /// </summary>
        Free,

        /// <summary>
        /// 010
        /// </summary>
        RollerX,

        /// <summary>
        /// 100
        /// </summary>
        RollerY,

        /// <summary>
        /// 110
        /// </summary>
        Pinned,

        /// <summary>
        /// 111
        /// </summary>
        Fixed,

        /// <summary>
        /// 111
        /// </summary>
        FixedBottom,

        /// <summary>
        /// 111
        /// </summary>
        FixedTop,

        /// <summary>
        /// 111
        /// </summary>
        FixedLeft,

        /// <summary>
        /// 111
        /// </summary>
        FixedRight,

        /// <summary>
        /// 110
        /// </summary>
        PinnedBottom,

        /// <summary>
        /// 110
        /// </summary>
        PinnedTop,

        /// <summary>
        /// 110
        /// </summary>
        PinnedLeft,

        /// <summary>
        /// 110
        /// </summary>
        PinnedRight,

        /// <summary>
        /// 010
        /// </summary>
        RollerBottom,

        /// <summary>
        /// 010
        /// </summary>
        RollerTop,

        /// <summary>
        /// 100
        /// </summary>
        RollerLeft,

        /// <summary>
        /// 100
        /// </summary>
        RollerRight,

        /// <summary>
        /// 011
        /// </summary>
        TrackBottom,

        /// <summary>
        /// 011
        /// </summary>
        TrackTop,

        /// <summary>
        /// 101
        /// </summary>
        TrackLeft,

        /// <summary>
        /// 101
        /// </summary>
        TrackRight,
    }

    #endregion

    #region Units

    /// <summary>
    /// The unit type for the value.
    /// </summary>
    internal enum UnitType
    {
        /// <summary>
        /// Angle
        /// </summary>
        Angle,

        /// <summary>
        /// Area
        /// </summary>
        Area,

        /// <summary>
        /// Density
        /// </summary>
        Density,

        /// <summary>
        /// Force
        /// </summary>
        Force,

        /// <summary>
        /// ForcePerLength
        /// </summary>
        ForcePerLength,

        /// <summary>
        /// Length
        /// </summary>
        Length,

        /// <summary>
        /// Mass
        /// </summary>
        Mass,

        /// <summary>
        /// Moment
        /// </summary>
        Moment,

        /// <summary>
        /// MomentOfInertia
        /// </summary>
        MomentOfInertia,

        /// <summary>
        /// Money
        /// </summary>
        Money,

        /// <summary>
        /// Percentage
        /// </summary>
        Percentage,

        /// <summary>
        /// Pressure
        /// </summary>
        Pressure,

        /// <summary>
        /// Speed
        /// </summary>
        Speed,

        /// <summary>
        /// Temperature
        /// </summary>
        Temperature,

        /// <summary>
        /// Time
        /// </summary>
        Time,

        /// <summary>
        /// Unit less
        /// </summary>
        Unitless,

        /// <summary>
        /// UnitlessInteger
        /// </summary>
        UnitlessInteger,

        /// <summary>
        /// Volume
        /// </summary>
        Volume,
    }

    /// <summary>
    /// The type of angle.
    /// </summary>
    internal enum AngleType
    {
        /// <summary>
        /// Degrees
        /// </summary>
        Degrees,

        /// <summary>
        /// Radians
        /// </summary>
        Radians,
    }

    /// <summary>
    /// The type of area.
    /// </summary>
    internal enum AreaType
    {
        /// <summary>
        /// Meter squared
        /// </summary>
        SquareMetre,

        /// <summary>
        /// Centimeter squared
        /// </summary>
        SquareCentiMetre,

        /// <summary>
        /// Millimeter squared
        /// </summary>
        SquareMilliMetre,

        /// <summary>
        /// Feet squared
        /// </summary>
        SquareFoot,

        /// <summary>
        /// Inch squared
        /// </summary>
        SquareInch,
    }

    /// <summary>
    /// The density type.
    /// </summary>
    internal enum DensityType
    {
        /// <summary>
        /// Kilogram per cubic meter
        /// </summary>
        KilogramPerCubicMetre,

        /// <summary>
        /// Pounds per cubit foot
        /// </summary>
        PoundPerCubicFoot,
    }

    /// <summary>
    /// The type of force.
    /// </summary>
    internal enum ForceType
    {
        /// <summary>
        /// Newton
        /// </summary>
        Newton,

        /// <summary>
        /// KiloNewton
        /// </summary>
        KiloNewton,

        /// <summary>
        /// MegaNewton
        /// </summary>
        MegaNewton,

        /// <summary>
        /// GigaNewton
        /// </summary>
        GigaNewton,

        /// <summary>
        /// Dyne
        /// </summary>
        Dyne,

        /// <summary>
        /// KilogramForce
        /// </summary>
        KilogramForce,

        /// <summary>
        /// PoundForce
        /// </summary>
        PoundForce,

        /// <summary>
        /// Poundal
        /// </summary>
        Poundal,
    }

    /// <summary>
    /// The type of force per length.
    /// </summary>
    internal enum ForcePerLengthType
    {
        /// <summary>
        /// NewtonPerMeter
        /// </summary>
        NewtonPerMeter,

        /// <summary>
        /// PoundPerFoot
        /// </summary>
        PoundPerFoot,
    }

    /// <summary>
    /// The type of length.
    /// </summary>
    internal enum LengthType
    {
        /// <summary>
        /// Meter - m  1 / 1m
        /// </summary>
        Meter,

        /// <summary>
        /// Millimeter - mm 1000 / 0.001m
        /// </summary>
        Millimeter,

        /// <summary>
        /// CentiMeter - cm 100 / 0.01m
        /// </summary>
        CentiMeter,

        /// <summary>
        /// KiloMeter - km 0.001 / 1000m
        /// </summary>
        KiloMeter,

        /// <summary>
        /// Mil - 39370.0787 / 0.0000254m
        /// </summary>
        Mil,

        /// <summary>
        /// Inch - in 39.3700787 / 0.0254m
        /// </summary>
        Inch,

        /// <summary>
        /// Foot - ft 3.2808399 / 0.3048m
        /// </summary>
        Foot,

        /// <summary>
        /// Yard - 1.0936133 / 0.9144m
        /// </summary>
        Yard,

        /// <summary>
        /// Mile - 0.00062137 / 1609.344m
        /// </summary>
        Mile,
    }

    /// <summary>
    /// The type of mass.
    /// </summary>
    internal enum MassType
    {
        /// <summary>
        /// Kilogram
        /// </summary>
        Kilogram,

        /// <summary>
        /// Pound
        /// </summary>
        Pound,

        /// <summary>
        /// Gram
        /// </summary>
        Gram,

        /// <summary>
        /// Ton
        /// </summary>
        Ton,
    }

    /// <summary>
    /// The type of moment.
    /// </summary>
    internal enum MomentType
    {
        /// <summary>
        /// NewtonMetre
        /// </summary>
        NewtonMetre,

        /// <summary>
        /// PoundFoot
        /// </summary>
        PoundFoot,

        /// <summary>
        /// PoundInch
        /// </summary>
        PoundInch,

        /// <summary>
        /// OunceInch
        /// </summary>
        OunceInch,

        /// <summary>
        /// OunceFoot
        /// </summary>
        OunceFoot,
    }

    /// <summary>
    /// The type of moment of inertia.
    /// </summary>
    internal enum MomentOfInertiaType
    {
        /// <summary>
        /// QuadMeter
        /// </summary>
        QuadMeter,

        /// <summary>
        /// QuadMillimeter
        /// </summary>
        QuadMillimeter,

        /// <summary>
        /// QuadCentmeter
        /// </summary>
        QuadCentmeter,

        /// <summary>
        /// QuadFoot
        /// </summary>
        QuadFoot,

        /// <summary>
        /// QuadInch
        /// </summary>
        QuadInch,
    }

    /// <summary>
    /// The type of money.
    /// </summary>
    internal enum MoneyType
    {
        /// <summary>
        /// Default
        /// </summary>
        Default,
    }

    /// <summary>
    /// The percentage type.
    /// </summary>
    internal enum PercentageType
    {
        /// <summary>
        /// Default
        /// </summary>
        Default,
    }

    /// <summary>
    /// The type of pressure.
    /// </summary>
    internal enum PressureType
    {
        /// <summary>
        /// Pascal
        /// </summary>
        Pascal,

        /// <summary>
        /// Milli-pascal
        /// </summary>
        Millipascal,

        /// <summary>
        /// Hecto-pascal
        /// </summary>
        Hectopascal,

        /// <summary>
        /// Kilo-pascal
        /// </summary>
        Kilopascal,

        /// <summary>
        /// Mega-pascal
        /// </summary>
        Megapascal,

        /// <summary>
        /// Giga-pascal
        /// </summary>
        Gigapascal,

        /// <summary>
        /// PoundPerSquareInch
        /// </summary>
        PoundPerSquareInch,

        /// <summary>
        /// KilopoundPerSquareInch
        /// </summary>
        KilopoundPerSquareInch,

        /// <summary>
        /// MegapoundPerSquareInch
        /// </summary>
        MegapoundPerSquareInch,

        /// <summary>
        /// PoundPerSqareFoot
        /// </summary>
        PoundPerSqareFoot,
    }

    /// <summary>
    /// The type of speed.
    /// </summary>
    internal enum SpeedType
    {
        /// <summary>
        /// MeterPerSecond
        /// </summary>
        MeterPerSecond,
    }

    /// <summary>
    /// The type of temperature.
    /// </summary>
    internal enum TemperatureType
    {
        /// <summary>
        /// Kelvin
        /// </summary>
        Kelvin,

        /// <summary>
        /// Celsius
        /// </summary>
        Celsius,
    }

    /// <summary>
    /// The type of time.
    /// </summary>
    internal enum TimeType
    {
        /// <summary>
        /// Seconds
        /// </summary>
        Seconds,
    }

    /// <summary>
    /// The type of volume.
    /// </summary>
    internal enum VolumeType
    {
        /// <summary>
        /// CubicMetre
        /// </summary>
        CubicMetre,

        /// <summary>
        /// CubicCentimeter
        /// </summary>
        CubicCentimeter,

        /// <summary>
        /// CubicMillimeter
        /// </summary>
        CubicMillimeter,

        /// <summary>
        /// CubicFoot
        /// </summary>
        CubicFoot,

        /// <summary>
        /// CubicInch
        /// </summary>
        CubicInch,
    }

    #endregion

    #region Line

    /// <summary>
    /// The type of line.
    /// </summary>
    internal enum LineType
    {
        /// <summary>
        /// Solid
        /// </summary>
        Solid,

        /// <summary>
        /// Dash
        /// </summary>
        Dash,

        /// <summary>
        /// Dot
        /// </summary>
        Dot,

        /// <summary>
        /// DashDot
        /// </summary>
        DashDot,

        /// <summary>
        /// DashDotDash
        /// </summary>
        DashDotDash,
    }

    /// <summary>
    /// The type of line cap.
    /// </summary>
    internal enum CapStyle
    {
        /// <summary>
        /// Flat
        /// </summary>
        Flat,

        /// <summary>
        /// Square
        /// </summary>
        Square,

        /// <summary>
        /// Round
        /// </summary>
        Round,

        /// <summary>
        /// Triangle
        /// </summary>
        Triangle,
    }

    /// <summary>
    /// The type of load.
    /// </summary>
    internal enum LoadType
    {
        /// <summary>
        /// Nodal
        /// </summary>
        Nodal,

        /// <summary>
        /// Linear
        /// </summary>
        Linear,
    }

    #endregion

    #region State

    /// <summary>
    /// The construction mode.
    /// </summary>
    internal enum ConstructionMode
    {
        /// <summary>
        /// File
        /// </summary>
        File,

        /// <summary>
        /// Add
        /// </summary>
        Add,

        /// <summary>
        /// Nodes
        /// </summary>
        Nodes,

        /// <summary>
        /// Members
        /// </summary>
        Members,

        /// <summary>
        /// Sections
        /// </summary>
        Sections,

        /// <summary>
        /// Help
        /// </summary>
        Help,

        /// <summary>
        /// Zoom
        /// </summary>
        Zoom,

        /// <summary>
        /// Settings
        /// </summary>
        Settings,
    }

    /// <summary>
    /// The state of the page.
    /// </summary>
    internal enum PageState
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// FileLoading
        /// </summary>
        FileLoading,

        /// <summary>
        /// Construction
        /// </summary>
        Construction,

        /// <summary>
        /// Solver
        /// </summary>
        Solver,

        /// <summary>
        /// Sections
        /// </summary>
        Sections,

        /// <summary>
        /// Results
        /// </summary>
        Results,
    }

    /// <summary>
    /// The selection state.
    /// </summary>
    internal enum SelectionState
    {
        /// <summary>
        /// Ready - not selected.
        /// </summary>
        Ready,

        /// <summary>
        /// FirstNode
        /// </summary>
        FirstNode,

        /// <summary>
        /// SecondNode
        /// </summary>
        SecondNode,
    }

    /// <summary>
    /// The state of the solver.
    /// </summary>
    internal enum SolveState
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// Setup
        /// </summary>
        Setup,

        /// <summary>
        /// Solving
        /// </summary>
        Solving,

        /// <summary>
        /// Solved
        /// </summary>
        Solved,

        /// <summary>
        /// Canceling
        /// </summary>
        Canceling,

        /// <summary>
        /// Canceled
        /// </summary>
        Canceled,
    }
    #endregion
}
