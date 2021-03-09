using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class DoubleValue : UserControl
    {
        public event EventHandler ValueChanged;
        public event EventHandler NearValueChanged;
        public event EventHandler FarValueChanged;
        private decimal multiplicationFactor = 1;

        private decimal nearValue;
        public decimal NearValue
        {
            get { return nearValue; }
            set { nearValue = value; }
        }

        private decimal farValue;
        public decimal FarValue
        {
            get { return farValue; }
            set { farValue = value; }
        }

        private int axis;
        internal int Axis
        {
            get { return axis; }
            set
            {
                axis = value;
                switch (axis)
                {
                    case 0:
                        textBlock_Axis.Text = "";
                        break;
                    case 1:
                        textBlock_Axis.Text = "⭢";
                        textBlock_Axis.FontSize = 24;
                        break;
                    case 2:
                        textBlock_Axis.Text = "⭡";
                        textBlock_Axis.FontSize = 24;
                        break;
                    case 3:
                        textBlock_Axis.Text = "⭯";
                        textBlock_Axis.FontSize = 20;
                        break;
                    case 4:
                        textBlock_Axis.Text = "";
                        textBlock_Axis.FontSize = 16;
                        break;
                }
            }
        }

        private bool displayOnly;
        public bool DisplayOnly
        {
            get { return displayOnly; }
            set
            {
                displayOnly = value;
                numericInput_NearValue.DisplayOnly = value;
                numericInput_FarValue.DisplayOnly = value;
            }
        }

        private UnitType unitType = UnitType.Unitless;
        internal UnitType UnitType
        {
            get { return unitType; }
            set
            {
                unitType = value;
                numericInput_NearValue.IsInteger = false;
                numericInput_FarValue.IsInteger = false;
                switch (unitType)
                {
                    #region Angle
                    case UnitType.Angle:
                        switch (Options.Angle)
                        {
                            case AngleType.Degrees:
                                multiplicationFactor = Constants.DegreePerRadian;
                                textBlock_UnitType.Text = "°";
                                break;

                            case AngleType.Radians:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "rad";
                                break;
                        }
                        break;
                    #endregion
                    #region Area
                    case UnitType.Area:

                        switch (Options.Area)
                        {
                            case AreaType.SquareMetre: // 
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "m²";
                                break;

                            case AreaType.SquareCentiMetre: // 
                                multiplicationFactor = Constants.SquareCentimeterPerSquareMeter;
                                textBlock_UnitType.Text = "cm²";
                                break;

                            case AreaType.SquareMilliMetre: // 
                                multiplicationFactor = Constants.SquareMillimeterPerSquareMeter;
                                textBlock_UnitType.Text = "mm²";
                                break;

                            case AreaType.SquareFoot:
                                multiplicationFactor = Constants.SquareFootPerSquareMeter;
                                textBlock_UnitType.Text = "ft²";
                                break;

                            case AreaType.SquareInch:
                                multiplicationFactor = Constants.SquareInchPerSquareMeter;
                                textBlock_UnitType.Text = "in²";
                                break;
                        }
                        break;
                    #endregion                   
                    #region Density
                    case UnitType.Density:
                        switch (Options.Density)
                        {
                            case DensityType.KilogramPerCubicMetre:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "kg/m³";
                                break;

                            case DensityType.PoundPerCubicFoot:
                                multiplicationFactor = Constants.PoundPerCubicFootPerKilogramPerMeter;
                                textBlock_UnitType.Text = " lb/ft³";
                                break;
                        }

                        break;
                    #endregion
                    #region Force
                    case UnitType.Force:
                        switch (Options.Force)
                        {
                            case ForceType.Dyne:
                                multiplicationFactor = Constants.DynePerNewton;
                                textBlock_UnitType.Text = "?";
                                break;

                            case ForceType.GigaNewton:
                                multiplicationFactor = Constants.GigaNewtonPerNewton;
                                textBlock_UnitType.Text = "GN";
                                break;

                            case ForceType.KilogramForce:
                                multiplicationFactor = Constants.KilogramForcePerNewton;
                                textBlock_UnitType.Text = "?";
                                break;

                            case ForceType.KiloNewton:
                                multiplicationFactor = Constants.KiloNewtonPerNewton;
                                textBlock_UnitType.Text = "kN";
                                break;

                            case ForceType.MegaNewton:
                                multiplicationFactor = Constants.MegaNewtonPerNewton;
                                textBlock_UnitType.Text = "MN";
                                break;

                            case ForceType.Newton:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "N";
                                break;

                            case ForceType.Poundal:
                                multiplicationFactor = Constants.PoundalPerNewton;
                                textBlock_UnitType.Text = "?";
                                break;

                            case ForceType.PoundForce:
                                multiplicationFactor = Constants.PoundForcePerNewton;
                                textBlock_UnitType.Text = "lbf";
                                break;
                        }
                        break;

                    #endregion
                    #region ForcePerLength

                    case UnitType.ForcePerLength:

                        switch (Options.ForcePerLength)
                        {
                            case ForcePerLengthType.NewtonPerMeter:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "N/m";
                                break;
                            case ForcePerLengthType.PoundPerFoot:
                                multiplicationFactor = Constants.PoundForcePerFootPerNewPerMeter;
                                textBlock_UnitType.Text = "lb/ft";
                                break;
                        }

                        break;

                    #endregion
                    #region Length
                    case UnitType.Length:
                        switch (Options.Length)
                        {
                            case LengthType.Meter:
                                multiplicationFactor = Constants.MeterPerMeter;
                                textBlock_UnitType.Text = "m";
                                break;
                            case LengthType.Millimeter:
                                multiplicationFactor = Constants.MilliMeterPerMeter;
                                textBlock_UnitType.Text = "mm";
                                break;
                            case LengthType.CentiMeter:
                                multiplicationFactor = Constants.CentiMeterPerMeter;
                                textBlock_UnitType.Text = "cm";
                                break;
                            case LengthType.KiloMeter:
                                multiplicationFactor = Constants.KiloMeterPerMeter;
                                textBlock_UnitType.Text = "km";
                                break;
                            case LengthType.Inch:
                                //
                                multiplicationFactor = Constants.InchPerMeter;
                                textBlock_UnitType.Text = "in";
                                break;
                            case LengthType.Foot:
                                multiplicationFactor = Constants.FootPerMeter;
                                textBlock_UnitType.Text = "ft";
                                break;

                        }
                        break;
                    #endregion
                    #region Mass
                    case UnitType.Mass:
                        switch (Options.Mass)
                        {
                            case MassType.Kilogram:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "kg";
                                break;
                            case MassType.Pound:
                                multiplicationFactor = Constants.PoundPerKilogram;
                                textBlock_UnitType.Text = "lb";
                                break;
                        }
                        break;
                    #endregion
                    #region Moment of inertia
                    case UnitType.MomentOfInertia:
                        switch (Options.MomentOfInertia)
                        {
                            case MomentOfInertiaType.QuadMeter:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "m⁴";
                                break;

                            case MomentOfInertiaType.QuadCentmeter:
                                multiplicationFactor = Constants.QuadCentimetersPerQuadMeter;
                                textBlock_UnitType.Text = "cm⁴";
                                break;

                            case MomentOfInertiaType.QuadFoot:
                                multiplicationFactor = Constants.QuadFootPerQuadMeter;
                                textBlock_UnitType.Text = "ft⁴";
                                break;

                            case MomentOfInertiaType.QuadInch:
                                multiplicationFactor = Constants.QuadInchPerQuadMeter;
                                textBlock_UnitType.Text = "in⁴";
                                break;

                            case MomentOfInertiaType.QuadMillimeter:
                                multiplicationFactor = Constants.QuadMillimeterPerQuadMeter;
                                textBlock_UnitType.Text = "mm⁴";
                                break;
                        }

                        break;
                    #endregion
                    #region Moment
                    case UnitType.Moment:
                        switch (Options.Moment)
                        {
                            case MomentType.NewtonMetre:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "N·m";
                                break;

                            case MomentType.OunceFoot:
                                multiplicationFactor = Constants.OunceFootPerNewtonMeter;
                                textBlock_UnitType.Text = "oz·ft";
                                break;

                            case MomentType.OunceInch:
                                multiplicationFactor = Constants.OunceInchPerNewtonMeter;
                                textBlock_UnitType.Text = "oz·in";
                                break;

                            case MomentType.PoundFoot:
                                multiplicationFactor = Constants.PoundFootPerNewtonMeter;
                                textBlock_UnitType.Text = "lb·ft";
                                break;

                            case MomentType.PoundInch:
                                multiplicationFactor = Constants.PoundInchPerNewtonMeter;
                                textBlock_UnitType.Text = "lb·in";
                                break;
                        }
                        break;
                    #endregion
                    #region Money
                    case UnitType.Money:
                        multiplicationFactor = 1;
                        //RoundingFactor = 2;
                        textBlock_UnitType.Text = "";
                        break;
                    #endregion
                    #region Pressure
                    case UnitType.Pressure:
                        switch (Options.Pressure)
                        {
                            case PressureType.Pascal:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "Pa";
                                break;
                            case PressureType.Gigapascal:
                                multiplicationFactor = Constants.GigapascalPerPascal;
                                textBlock_UnitType.Text = "GPa";
                                break;
                            case PressureType.Hectopascal:
                                multiplicationFactor = Constants.HectopascalPerPascal;
                                textBlock_UnitType.Text = "hPa";
                                break;
                            case PressureType.Kilopascal:
                                multiplicationFactor = Constants.KilopascalPerPascal;
                                textBlock_UnitType.Text = "kPa";
                                break;
                            case PressureType.KilopoundPerSquareInch:
                                multiplicationFactor = Constants.KilopoundPerSquareInchPerPascal;
                                textBlock_UnitType.Text = "kPsi";
                                break;
                            case PressureType.Megapascal:
                                multiplicationFactor = Constants.MegapascalPerPascal;
                                textBlock_UnitType.Text = "MPa";
                                break;
                            case PressureType.MegapoundPerSquareInch:
                                multiplicationFactor = Constants.MegapoundPerSquareInchPerPascal;
                                textBlock_UnitType.Text = "MPsi";
                                break;
                            case PressureType.Millipascal:
                                multiplicationFactor = Constants.MillpascalPerPascal;
                                textBlock_UnitType.Text = "mPa";
                                break;
                            case PressureType.PoundPerSqareFoot:
                                multiplicationFactor = Constants.PoundPerSquareFootPerPascal;
                                textBlock_UnitType.Text = "Psft";
                                break;
                            case PressureType.PoundPerSquareInch:
                                multiplicationFactor = Constants.PoundPerSquareInchPerPascal;
                                textBlock_UnitType.Text = "Psi";
                                break;
                        }
                        break;
                    #endregion
                    #region Volume

                    case UnitType.Volume:
                        switch (Options.Volume)
                        {
                            case VolumeType.CubicMetre:
                                multiplicationFactor = 1;
                                textBlock_UnitType.Text = "m³";
                                break;

                            case VolumeType.CubicCentimeter:
                                multiplicationFactor = Constants.CubicCentimeterPerCubicMeter;
                                textBlock_UnitType.Text = "cm³";
                                break;

                            case VolumeType.CubicFoot:
                                multiplicationFactor = Constants.CubicFootPerCubicMeter;
                                textBlock_UnitType.Text = "ft³";
                                break;

                            case VolumeType.CubicInch:
                                multiplicationFactor = Constants.CubicInchPerCubicMeter;
                                textBlock_UnitType.Text = "in³";
                                break;

                            case VolumeType.CubicMillimeter:
                                multiplicationFactor = Constants.CubicMillimeterPerCubicMeter;
                                textBlock_UnitType.Text = "mm³";
                                break;
                        }
                        break;
                    #endregion
                    #region Unitless
                    case UnitType.Unitless:
                        multiplicationFactor = 1;
                        //RoundingFactor = 3;
                        textBlock_UnitType.Text = "";
                        break;

                    case UnitType.UnitlessInteger:
                        numericInput_NearValue.IsInteger = true;
                        numericInput_FarValue.IsInteger = true;
                        multiplicationFactor = 1;
                        //RoundingFactor = 3;
                        textBlock_UnitType.Text = "";
                        break;
                        #endregion
                }
            }
        }

        public DoubleValue()
        {
            this.InitializeComponent();
        }

        internal void SetNull()
        {
            numericInput_NearValue.SetNull();
            numericInput_FarValue.SetNull();
        }

        internal void SetValue(decimal newNearValue, decimal newFarValue)
        {
            //todo: Multiply by unit type factor then pass
            nearValue = newNearValue;
            farValue = newFarValue;

            if (multiplicationFactor == 1)
            {
                numericInput_NearValue.SetValue(newNearValue);
            }
            else
            {
                numericInput_NearValue.SetValue(newNearValue * multiplicationFactor);
            }

            if (multiplicationFactor == 1)
            {
                numericInput_FarValue.SetValue(newFarValue);
            }
            else
            {
                numericInput_FarValue.SetValue(newFarValue * multiplicationFactor);
            }
        }

        private void numericInput_NearValue_ValueChanged(object sender, EventArgs e)
        {
            nearValue = numericInput_NearValue.NewValue;
            NearValueChanged?.Invoke(this, new EventArgs());
        }

        private void numericInput_FarValue_ValueChanged(object sender, EventArgs e)
        {
            farValue = numericInput_FarValue.NewValue;
            FarValueChanged?.Invoke(this, new EventArgs());
        }

        private void textBlock_UnitType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (unitType)
            {
                case UnitType.Angle:
                    MenuFlyout nextMenuFlyoutAngle = new MenuFlyout();
                    MenuFlyoutItem itemRadians = new MenuFlyoutItem();
                    itemRadians.Text = "Radians (rad)";
                    itemRadians.Click += ItemRadians_Click;
                    MenuFlyoutItem itemDegrees = new MenuFlyoutItem();
                    itemDegrees.Text = "Degrees (°)";
                    itemDegrees.Click += ItemDegrees_Click;
                    nextMenuFlyoutAngle.Items.Add(itemDegrees);
                    nextMenuFlyoutAngle.Items.Add(itemRadians);
                    nextMenuFlyoutAngle.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Area:
                    MenuFlyout nextMenuFlyoutArea = new MenuFlyout();
                    MenuFlyoutItem itemSquareMetre = new MenuFlyoutItem();
                    itemSquareMetre.Text = "Square Metre (m²)";
                    itemSquareMetre.Click += ItemSquareMetre_Click;
                    MenuFlyoutItem itemSquareCentiMetre = new MenuFlyoutItem();
                    itemSquareCentiMetre.Text = "Square Centimetre (cm²)";
                    itemSquareCentiMetre.Click += ItemSquareCentiMetre_Click;
                    MenuFlyoutItem itemSquareMilliMetre = new MenuFlyoutItem();
                    itemSquareMilliMetre.Text = "Square Millimetre (mm²)";
                    itemSquareMilliMetre.Click += ItemSquareMilliMetre_Click;
                    MenuFlyoutItem itemSquareFoot = new MenuFlyoutItem();
                    itemSquareFoot.Text = "Square Foot (ft²)";
                    itemSquareFoot.Click += ItemSquareFoot_Click;
                    MenuFlyoutItem itemSquareInch = new MenuFlyoutItem();
                    itemSquareInch.Text = "Square Inch (in²)";
                    itemSquareInch.Click += ItemSquareInch_Click;
                    nextMenuFlyoutArea.Items.Add(itemSquareMetre);
                    nextMenuFlyoutArea.Items.Add(itemSquareFoot);
                    nextMenuFlyoutArea.Items.Add(itemSquareMilliMetre);
                    nextMenuFlyoutArea.Items.Add(itemSquareCentiMetre);
                    nextMenuFlyoutArea.Items.Add(itemSquareInch);
                    nextMenuFlyoutArea.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Density:
                    MenuFlyout nextMenuFlyoutDensity = new MenuFlyout();
                    MenuFlyoutItem itemKilogramPerCubicMetre = new MenuFlyoutItem();
                    itemKilogramPerCubicMetre.Text = "Kilogram per cubic Metre (kg/m³)";
                    itemKilogramPerCubicMetre.Click += ItemKilogramPerCubicMetre_Click;
                    MenuFlyoutItem itemPoundPerCubicFoot = new MenuFlyoutItem();
                    itemPoundPerCubicFoot.Text = "Pound per cubic Foot( (lb/ft³)";
                    itemPoundPerCubicFoot.Click += ItemPoundPerCubicFoot_Click;
                    nextMenuFlyoutDensity.Items.Add(itemKilogramPerCubicMetre);
                    nextMenuFlyoutDensity.Items.Add(itemPoundPerCubicFoot);
                    nextMenuFlyoutDensity.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Force:
                    MenuFlyout nextMenuFlyoutForce = new MenuFlyout();
                    MenuFlyoutItem itemNewton = new MenuFlyoutItem();
                    itemNewton.Text = "Newton (N)";
                    itemNewton.Click += ItemNewton_Click;
                    MenuFlyoutItem itemKiloNewton = new MenuFlyoutItem();
                    itemKiloNewton.Text = "KiloNewton (kN)";
                    itemKiloNewton.Click += ItemKiloNewton_Click;
                    MenuFlyoutItem itemMegaNewton = new MenuFlyoutItem();
                    itemMegaNewton.Text = "MegaNewton (MN)";
                    itemMegaNewton.Click += ItemMegaNewton_Click;
                    MenuFlyoutItem itemGigaNewton = new MenuFlyoutItem();
                    itemGigaNewton.Text = "GigaNewton (GN)";
                    itemGigaNewton.Click += ItemGigaNewton_Click;
                    MenuFlyoutItem itemDyne = new MenuFlyoutItem();
                    itemDyne.Text = "Dyne";
                    itemDyne.Click += ItemDyne_Click;
                    MenuFlyoutItem itemKilogramForce = new MenuFlyoutItem();
                    itemKilogramForce.Text = "Kilogram Force";
                    itemKilogramForce.Click += ItemKilogramForce_Click;
                    MenuFlyoutItem itemPoundForce = new MenuFlyoutItem();
                    itemPoundForce.Text = "Pound Force";
                    itemPoundForce.Click += ItemPoundForce_Click;
                    MenuFlyoutItem itemPoundal = new MenuFlyoutItem();
                    itemPoundal.Text = "Poundal";
                    itemPoundal.Click += ItemPoundal_Click;
                    nextMenuFlyoutForce.Items.Add(itemNewton);
                    nextMenuFlyoutForce.Items.Add(itemKiloNewton);
                    nextMenuFlyoutForce.Items.Add(itemMegaNewton);
                    nextMenuFlyoutForce.Items.Add(itemGigaNewton);
                    nextMenuFlyoutForce.Items.Add(itemDyne);
                    nextMenuFlyoutForce.Items.Add(itemKilogramForce);
                    nextMenuFlyoutForce.Items.Add(itemPoundForce);
                    nextMenuFlyoutForce.Items.Add(itemPoundal);
                    nextMenuFlyoutForce.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.ForcePerLength:
                    MenuFlyout nextMenuFlyoutForcePerLength = new MenuFlyout();
                    MenuFlyoutItem itemNewtonPerMeter = new MenuFlyoutItem();
                    itemNewtonPerMeter.Text = "Newton per Meter (N/m)";
                    itemNewtonPerMeter.Click += ItemNewtonPerMeter_Click;
                    MenuFlyoutItem itemPoundPerFoot = new MenuFlyoutItem();
                    itemPoundPerFoot.Text = "Pound per Foot (lb/ft)";
                    itemPoundPerFoot.Click += ItemPoundPerFoot_Click;
                    nextMenuFlyoutForcePerLength.Items.Add(itemNewtonPerMeter);
                    nextMenuFlyoutForcePerLength.Items.Add(itemPoundPerFoot);
                    nextMenuFlyoutForcePerLength.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Length:
                    MenuFlyout nextMenuFlyoutLength = new MenuFlyout();
                    MenuFlyoutItem itemMilliMeter = new MenuFlyoutItem();
                    itemMilliMeter.Text = "MilliMeter (mm)";
                    itemMilliMeter.Click += ItemMilliMeter_Click;
                    MenuFlyoutItem itemCentiMeter = new MenuFlyoutItem();
                    itemCentiMeter.Text = "CentiMeter (cm)";
                    itemCentiMeter.Click += ItemCentiMeter_Click;
                    MenuFlyoutItem itemMeter = new MenuFlyoutItem();
                    itemMeter.Text = "Meter (m)";
                    itemMeter.Click += ItemMeter_Click;
                    MenuFlyoutItem itemKiloMeter = new MenuFlyoutItem();
                    itemKiloMeter.Text = "KiloMeter (km)";
                    itemKiloMeter.Click += ItemKiloMeter_Click;
                    MenuFlyoutSeparator seperatorMetric = new MenuFlyoutSeparator();
                    MenuFlyoutItem itemInch = new MenuFlyoutItem();
                    itemInch.Text = "Inch (in)";
                    itemInch.Click += ItemInch_Click;
                    MenuFlyoutItem itemFoot = new MenuFlyoutItem();
                    itemFoot.Text = "Foot (ft)";
                    itemFoot.Click += ItemFoot_Click;
                    nextMenuFlyoutLength.Items.Add(itemMilliMeter);
                    nextMenuFlyoutLength.Items.Add(itemCentiMeter);
                    nextMenuFlyoutLength.Items.Add(itemMeter);
                    nextMenuFlyoutLength.Items.Add(itemKiloMeter);
                    nextMenuFlyoutLength.Items.Add(seperatorMetric);
                    nextMenuFlyoutLength.Items.Add(itemInch);
                    nextMenuFlyoutLength.Items.Add(itemFoot);
                    nextMenuFlyoutLength.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Mass:
                    MenuFlyout nextMenuFlyoutMass = new MenuFlyout();
                    MenuFlyoutItem itemKilogram = new MenuFlyoutItem();
                    itemKilogram.Text = "Kilograms (kg)";
                    itemKilogram.Click += ItemKilogram_Click;
                    MenuFlyoutItem itemGram = new MenuFlyoutItem();
                    itemGram.Text = "CentiMeters (g)";
                    itemGram.Click += ItemGram_Click;
                    MenuFlyoutItem itemTon = new MenuFlyoutItem();
                    itemTon.Text = "Ton (t)";
                    itemTon.Click += ItemTon_Click;
                    MenuFlyoutItem itemPound = new MenuFlyoutItem();
                    itemPound.Text = "Pound (lb)";
                    itemPound.Click += ItemPound_Click;
                    nextMenuFlyoutMass.Items.Add(itemKilogram);
                    nextMenuFlyoutMass.Items.Add(itemGram);
                    nextMenuFlyoutMass.Items.Add(itemTon);
                    nextMenuFlyoutMass.Items.Add(itemPound);
                    nextMenuFlyoutMass.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Moment:
                    MenuFlyout nextMenuFlyoutMoment = new MenuFlyout();
                    MenuFlyoutItem itemNewtonMetre = new MenuFlyoutItem();
                    itemNewtonMetre.Text = "Newton Meter (N·m)";
                    itemNewtonMetre.Click += ItemNewtonMetre_Click;
                    MenuFlyoutItem itemPoundFoot = new MenuFlyoutItem();
                    itemPoundFoot.Text = "Pound Foot (lb·ft)";
                    itemPoundFoot.Click += ItemPoundFoot_Click;
                    MenuFlyoutItem itemPoundInch = new MenuFlyoutItem();
                    itemPoundInch.Text = "Pound Inch (lb·in)";
                    itemPoundInch.Click += ItemPoundInch_Click;
                    MenuFlyoutItem itemOunceInch = new MenuFlyoutItem();
                    itemOunceInch.Text = "Ounce Inch (oz·in)";
                    itemOunceInch.Click += ItemOunceInch_Click;
                    MenuFlyoutItem itemOunceFoot = new MenuFlyoutItem();
                    itemOunceFoot.Text = "Ounce Foot (oz·ft)";
                    itemOunceFoot.Click += ItemOunceFoot_Click;
                    nextMenuFlyoutMoment.Items.Add(itemNewtonMetre);
                    nextMenuFlyoutMoment.Items.Add(itemPoundFoot);
                    nextMenuFlyoutMoment.Items.Add(itemPoundInch);
                    nextMenuFlyoutMoment.Items.Add(itemOunceInch);
                    nextMenuFlyoutMoment.Items.Add(itemOunceFoot);
                    nextMenuFlyoutMoment.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.MomentOfInertia:
                    MenuFlyout nextMenuFlyoutMomentOfInertia = new MenuFlyout();
                    MenuFlyoutItem itemQuadMeter = new MenuFlyoutItem();
                    itemQuadMeter.Text = "Quad Meter (m⁴)";
                    itemQuadMeter.Click += ItemQuadMeter_Click;
                    MenuFlyoutItem itemQuadMillimeter = new MenuFlyoutItem();
                    itemQuadMillimeter.Text = "Quad Millimeter (mm⁴)";
                    itemQuadMillimeter.Click += ItemQuadMillimeter_Click;
                    MenuFlyoutItem itemQuadCentimeter = new MenuFlyoutItem();
                    itemQuadCentimeter.Text = "Quad Centimeter (cm⁴)";
                    itemQuadCentimeter.Click += ItemQuadCentimeter_Click;
                    MenuFlyoutItem itemQuadInch = new MenuFlyoutItem();
                    itemQuadInch.Text = "Quad Inch (in⁴)";
                    itemQuadInch.Click += ItemQuadInch_Click;
                    MenuFlyoutItem itemQuadFoot = new MenuFlyoutItem();
                    itemQuadFoot.Text = "Quad Foot (ft⁴)";
                    itemQuadFoot.Click += ItemQuadFoot_Click;

                    nextMenuFlyoutMomentOfInertia.Items.Add(itemQuadMeter);
                    nextMenuFlyoutMomentOfInertia.Items.Add(itemQuadMillimeter);
                    nextMenuFlyoutMomentOfInertia.Items.Add(itemQuadCentimeter);
                    nextMenuFlyoutMomentOfInertia.Items.Add(itemQuadInch);
                    nextMenuFlyoutMomentOfInertia.Items.Add(itemQuadFoot);
                    nextMenuFlyoutMomentOfInertia.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Money:

                    break;


                case UnitType.Percentage:

                    break;

                case UnitType.Pressure:
                    MenuFlyout nextMenuFlyoutPressure = new MenuFlyout();
                    MenuFlyoutItem itemPascal = new MenuFlyoutItem();
                    itemPascal.Text = "Pascal (Pa)";
                    itemPascal.Click += ItemPascal_Click;

                    MenuFlyoutItem itemMilliPascal = new MenuFlyoutItem();
                    itemMilliPascal.Text = "Millipascal (mPa)";
                    itemMilliPascal.Click += ItemMilliPascal_Click;

                    MenuFlyoutItem itemHectoPascal = new MenuFlyoutItem();
                    itemHectoPascal.Text = "Hectopascal (hPa)";
                    itemHectoPascal.Click += ItemHectoPascal_Click;

                    MenuFlyoutItem itemKiloPascal = new MenuFlyoutItem();
                    itemKiloPascal.Text = "Kilopascal (kPa)";
                    itemKiloPascal.Click += ItemKiloPascal_Click;

                    MenuFlyoutItem itemMegaPascal = new MenuFlyoutItem();
                    itemMegaPascal.Text = "Megapascal (MPa)";
                    itemMegaPascal.Click += ItemMegaPascal_Click;

                    MenuFlyoutItem itemGigaPascal = new MenuFlyoutItem();
                    itemGigaPascal.Text = "Gigapascal (GPa)";
                    itemGigaPascal.Click += ItemGigaPascal_Click;

                    MenuFlyoutItem itemPoundPerSquareInch = new MenuFlyoutItem();
                    itemPoundPerSquareInch.Text = " ()";
                    itemPoundPerSquareInch.Click += ItemPoundPerSquareInch_Click;

                    MenuFlyoutItem itemKilopoundPerSquareInch = new MenuFlyoutItem();
                    itemKilopoundPerSquareInch.Text = " ()";
                    itemKilopoundPerSquareInch.Click += ItemKilopoundPerSquareInch_Click;

                    MenuFlyoutItem itemMegaPoundPerSquareInch = new MenuFlyoutItem();
                    itemMegaPoundPerSquareInch.Text = " ()";
                    itemMegaPoundPerSquareInch.Click += ItemMegaPoundPerSquareInch_Click;

                    MenuFlyoutItem itemPoundPerSquareFoot = new MenuFlyoutItem();
                    itemPoundPerSquareFoot.Text = " ()";
                    itemPoundPerSquareFoot.Click += ItemPoundPerSquareFoot_Click;

                    nextMenuFlyoutPressure.Items.Add(itemPascal);
                    nextMenuFlyoutPressure.Items.Add(itemMilliPascal);
                    nextMenuFlyoutPressure.Items.Add(itemHectoPascal);
                    nextMenuFlyoutPressure.Items.Add(itemKiloPascal);
                    nextMenuFlyoutPressure.Items.Add(itemMegaPascal);
                    nextMenuFlyoutPressure.Items.Add(itemGigaPascal);
                    nextMenuFlyoutPressure.Items.Add(itemPoundPerSquareInch);
                    nextMenuFlyoutPressure.Items.Add(itemKilopoundPerSquareInch);
                    nextMenuFlyoutPressure.Items.Add(itemMegaPoundPerSquareInch);
                    nextMenuFlyoutPressure.Items.Add(itemPoundPerSquareFoot);
                    nextMenuFlyoutPressure.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Speed:

                    break;

                case UnitType.Temprature:

                    break;

                case UnitType.Time:

                    break;


                case UnitType.Unitless:

                    break;


                case UnitType.UnitlessInteger:

                    break;

                case UnitType.Volume:
                    MenuFlyout nextMenuFlyoutVolume = new MenuFlyout();
                    MenuFlyoutItem itemCubicMeter = new MenuFlyoutItem();
                    itemCubicMeter.Text = "Cubic Meter (m³)";
                    itemCubicMeter.Click += ItemCubicMeter_Click;

                    MenuFlyoutItem itemCubicCentimeter = new MenuFlyoutItem();
                    itemCubicCentimeter.Text = "Cubic Centimeter (cm³)";
                    itemCubicCentimeter.Click += ItemCubicCentimeter_Click;

                    MenuFlyoutItem itemCubicMillimeter = new MenuFlyoutItem();
                    itemCubicMillimeter.Text = "Cubic Millimeter (mm³)";
                    itemCubicMillimeter.Click += ItemCubicMillimeter_Click;

                    MenuFlyoutItem itemCubicFoot = new MenuFlyoutItem();
                    itemCubicFoot.Text = "Cubic Foot (ft³)";
                    itemCubicFoot.Click += ItemCubicFoot_Click;

                    MenuFlyoutItem itemCubicInch = new MenuFlyoutItem();
                    itemCubicInch.Text = "Cubic Inch (in³)";
                    itemCubicInch.Click += ItemCubicInch_Click;

                    nextMenuFlyoutVolume.Items.Add(itemCubicMeter);
                    nextMenuFlyoutVolume.Items.Add(itemCubicCentimeter);
                    nextMenuFlyoutVolume.Items.Add(itemCubicMillimeter);
                    nextMenuFlyoutVolume.Items.Add(itemCubicFoot);
                    nextMenuFlyoutVolume.Items.Add(itemCubicInch);
                    nextMenuFlyoutVolume.ShowAt((FrameworkElement)sender);
                    break;

            }
        }

        #region Volume

        private void ItemCubicInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Volume = VolumeType.CubicInch;
            Model.UpdatePanelPage();
        }

        private void ItemCubicFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Volume = VolumeType.CubicFoot;
            Model.UpdatePanelPage();
        }

        private void ItemCubicMillimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Volume = VolumeType.CubicMillimeter;
            Model.UpdatePanelPage();
        }

        private void ItemCubicCentimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Volume = VolumeType.CubicCentimeter;
            Model.UpdatePanelPage();
        }

        private void ItemCubicMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Volume = VolumeType.CubicMetre;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Pressure

        private void ItemPoundPerSquareFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.PoundPerSqareFoot;
            Model.UpdatePanelPage();
        }

        private void ItemMegaPoundPerSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.MegapoundPerSquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemKilopoundPerSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.KilopoundPerSquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemPoundPerSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.PoundPerSquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemGigaPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.Gigapascal;
            Model.UpdatePanelPage();
        }

        private void ItemMegaPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.Megapascal;
            Model.UpdatePanelPage();
        }

        private void ItemKiloPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.Kilopascal;
            Model.UpdatePanelPage();
        }

        private void ItemHectoPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.Hectopascal;
            Model.UpdatePanelPage();
        }

        private void ItemMilliPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.Millipascal;
            Model.UpdatePanelPage();
        }

        private void ItemPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Pressure = PressureType.Pascal;
            Model.UpdatePanelPage();
        }

        #endregion
        #region 2nd Moment of Area

        private void ItemQuadFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.MomentOfInertia = MomentOfInertiaType.QuadFoot;
            Model.UpdatePanelPage();
        }

        private void ItemQuadInch_Click(object sender, RoutedEventArgs e)
        {
            Options.MomentOfInertia = MomentOfInertiaType.QuadInch;
            Model.UpdatePanelPage();
        }

        private void ItemQuadCentimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.MomentOfInertia = MomentOfInertiaType.QuadCentmeter;
            Model.UpdatePanelPage();
        }

        private void ItemQuadMillimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.MomentOfInertia = MomentOfInertiaType.QuadMillimeter;
            Model.UpdatePanelPage();
        }

        private void ItemQuadMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.MomentOfInertia = MomentOfInertiaType.QuadMeter;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Moment

        private void ItemOunceFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Moment = MomentType.OunceFoot;
            Model.UpdatePanelPage();
        }

        private void ItemOunceInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Moment = MomentType.OunceInch;
            Model.UpdatePanelPage();
        }

        private void ItemPoundInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Moment = MomentType.PoundInch;
            Model.UpdatePanelPage();
        }

        private void ItemPoundFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Moment = MomentType.PoundFoot;
            Model.UpdatePanelPage();
        }

        private void ItemNewtonMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Moment = MomentType.NewtonMetre;
            Model.UpdatePanelPage();
        }

        #endregion 
        #region Mass

        private void ItemTon_Click(object sender, RoutedEventArgs e)
        {
            Options.Mass = MassType.Ton;
            Model.UpdatePanelPage();
        }

        private void ItemGram_Click(object sender, RoutedEventArgs e)
        {
            Options.Mass = MassType.Gram;
            Model.UpdatePanelPage();
        }

        private void ItemKilogram_Click(object sender, RoutedEventArgs e)
        {
            Options.Mass = MassType.Kilogram;
            Model.UpdatePanelPage();
        }

        private void ItemPound_Click(object sender, RoutedEventArgs e)
        {
            Options.Mass = MassType.Pound;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Force Per Length

        private void ItemPoundPerFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.ForcePerLength = ForcePerLengthType.PoundPerFoot;
            Model.UpdatePanelPage();
        }

        private void ItemNewtonPerMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.ForcePerLength = ForcePerLengthType.NewtonPerMeter;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Force

        private void ItemPoundal_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.Poundal;
            Model.UpdatePanelPage();
        }

        private void ItemPoundForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.PoundForce;
            Model.UpdatePanelPage();
        }

        private void ItemKilogramForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.KilogramForce;
            Model.UpdatePanelPage();
        }

        private void ItemDyne_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.Dyne;
            Model.UpdatePanelPage();
        }

        private void ItemGigaNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.GigaNewton;
            Model.UpdatePanelPage();
        }

        private void ItemMegaNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.MegaNewton;
            Model.UpdatePanelPage();
        }

        private void ItemKiloNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.KiloNewton;
            Model.UpdatePanelPage();
        }

        private void ItemNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Force = ForceType.Newton;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Density

        private void ItemPoundPerCubicFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Density = DensityType.PoundPerCubicFoot;
            Model.UpdatePanelPage();
        }

        private void ItemKilogramPerCubicMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Density = DensityType.KilogramPerCubicMetre;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Angle

        private void ItemDegrees_Click(object sender, RoutedEventArgs e)
        {
            Options.Angle = AngleType.Degrees;
            Model.UpdatePanelPage();
        }

        private void ItemRadians_Click(object sender, RoutedEventArgs e)
        {
            Options.Angle = AngleType.Radians;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Length

        private void ItemFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Length = LengthType.Foot;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Length = LengthType.Inch;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemKiloMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Length = LengthType.KiloMeter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Length = LengthType.Meter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemCentiMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Length = LengthType.CentiMeter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemMilliMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Length = LengthType.Millimeter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        #endregion
        #region Area

        private void ItemSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Area = AreaType.SquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemSquareFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Area = AreaType.SquareFoot;
            Model.UpdatePanelPage();
        }

        private void ItemSquareMilliMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Area = AreaType.SquareMilliMetre;
            Model.UpdatePanelPage();
        }

        private void ItemSquareCentiMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Area = AreaType.SquareCentiMetre;
            Model.UpdatePanelPage();
        }

        private void ItemSquareMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Area = AreaType.SquareMetre;
            Model.UpdatePanelPage();
        }

        #endregion

        private void numericInput_FarValue_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            //Debug.WriteLine("ScrollWheel");
        }

        private void textBlock_Axis_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(textBlock_Axis);
                textBox_Input.SetTheValue(NearValue);
            }
        }

        private void textBox_Input_ValueChanged(object sender, EventArgs e)
        {
            nearValue = textBox_Input.NewValue;
            farValue = textBox_Input.NewValue;
            flyOut_Shared.Hide();
            ValueChanged?.Invoke(this, new EventArgs());
        }
    }
}
