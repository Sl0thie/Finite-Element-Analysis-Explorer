namespace Finite_Element_Analysis_Explorer
{
    internal static class Constants
    {

        internal const int HeightTitleBar = 33;
        internal const int WidthDetailsSlim = 33;
        internal const int WidthDetailsNormal = 300;

        // Grid
        internal const decimal MetersPerMilliMeter = 0.001m;
        internal const decimal MetePerCentiMeter = 0.01m;
        internal const decimal MeterPerMeter = 1m;
        internal const decimal MeterPerKiloMeter = 1000m;
        internal const decimal MeterPerInch = 0.0254m;
        internal const decimal MeterPerFoot = 0.3048m;

        // Angle
        internal const decimal DegreePerRadian = 57.2957795m;

        // Area
        internal const decimal SquareCentimeterPerSquareMeter = 10000m;
        internal const decimal SquareMillimeterPerSquareMeter = 1000000m;
        internal const decimal SquareFootPerSquareMeter = 10.7639104m;
        internal const decimal SquareInchPerSquareMeter = 1550.0031m;

        internal const decimal PoundPerCubicFootPerKilogramPerMeter = 62.427961m;

        // Force
        internal const decimal KiloNewtonPerNewton = 0.001m;
        internal const decimal MegaNewtonPerNewton = 0.000001m;
        internal const decimal GigaNewtonPerNewton = 0.000000001m;
        internal const decimal KilogramForcePerNewton = 0.10197m;
        internal const decimal PoundForcePerNewton = 0.22481m; // lb or lbf
        internal const decimal PoundalPerNewton = 7.2330m;
        internal const decimal DynePerNewton = 100000m;

        // Force Per Length
        internal const decimal NewtonPerMeterNewtonPerMeter = 1; // N/m
        internal const decimal PoundForcePerFootPerNewPerMeter = 14.5939028871m; //

        // Mass
        internal const decimal PoundPerKilogram = 2.20462262m;

        // Length
        internal const decimal MilliMeterPerMeter = 1000m;
        internal const decimal CentiMeterPerMeter = 100m;
        internal const decimal KiloMeterPerMeter = 0.001m;
        internal const decimal InchPerMeter = 39.37007874m;
        internal const decimal FootPerMeter = 3.2808399m;

        // Pressure
        internal const decimal MillpascalPerPascal = 1000m;
        internal const decimal HectopascalPerPascal = 0.01m;
        internal const decimal KilopascalPerPascal = 0.001m;
        internal const decimal MegapascalPerPascal = 0.000001m;
        internal const decimal GigapascalPerPascal = 0.000000001m;
        internal const decimal PoundPerSquareInchPerPascal = 0.00014503773800721815m;
        internal const decimal KilopoundPerSquareInchPerPascal = 0.14503773800721815m;
        internal const decimal MegapoundPerSquareInchPerPascal = 145.03773800721815m;
        internal const decimal PoundPerSquareFootPerPascal = 0.020885434273m;

        // Moment/Torque
        internal const decimal PoundFootPerNewtonMeter = 0.737562149277m; // lb-ft
        internal const decimal OunceFootPerNewtonMeter = 11.8009943565m; // oz-ft
        internal const decimal OunceInchPerNewtonMeter = 141.61193227812538m; // oz-in
        internal const decimal PoundInchPerNewtonMeter = 8.850745767404769m; // lb-in

        // 2nd Moment of Area
        internal const decimal QuadMillimeterPerQuadMeter = 1000000000000m; // mm⁴
        internal const decimal QuadCentimetersPerQuadMeter = 100000000m; // cm⁴
        internal const decimal QuadFootPerQuadMeter = 115.8617675m; // ft⁴
        internal const decimal QuadInchPerQuadMeter = 2402509.61m; // in⁴

        // Volume
        internal const decimal CubicCentimeterPerCubicMeter = 1000000m; // cm^3
        internal const decimal CubicMillimeterPerCubicMeter = 1000000000m; // mm^3
        internal const decimal CubicFootPerCubicMeter = 35.3146665722m; // ft^3
        internal const decimal CubicInchPerCubicMeter = 61023.7438368m; // in^3
    }
}
