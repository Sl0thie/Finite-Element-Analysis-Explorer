﻿namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    /// <summary>
    /// DoubleValue UserControl provides two inputs. One for each node.
    /// </summary>
    public sealed partial class DoubleValue : UserControl
    {
        private decimal multiplicationFactor = 1;
        private int axis;
        private bool displayOnly;
        private UnitType unitType = UnitType.Unitless;
        private decimal nearValue;
        private decimal farValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleValue"/> class.
        /// </summary>
        public DoubleValue()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for when the value has changed.
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// Event for when the near value has changed.
        /// </summary>
        public event EventHandler NearValueChanged;

        /// <summary>
        /// Event for when the far value has changed.
        /// </summary>
        public event EventHandler FarValueChanged;

        /// <summary>
        /// Gets or sets the near value.
        /// </summary>
        public decimal NearValue
        {
            get
            {
                return nearValue;
            }

            set
            {
                nearValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the far value.
        /// </summary>
        public decimal FarValue
        {
            get
            {
                return farValue;
            }

            set
            {
                farValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the axis.
        /// </summary>
        internal int Axis
        {
            get
            {
                return axis;
            }

            set
            {
                axis = value;
                switch (axis)
                {
                    case 0:
                        TextBlock_Axis.Text = string.Empty;
                        break;
                    case 1:
                        TextBlock_Axis.Text = "⭢";
                        TextBlock_Axis.FontSize = 24;
                        break;
                    case 2:
                        TextBlock_Axis.Text = "⭡";
                        TextBlock_Axis.FontSize = 24;
                        break;
                    case 3:
                        TextBlock_Axis.Text = "⭯";
                        TextBlock_Axis.FontSize = 20;
                        break;
                    case 4:
                        TextBlock_Axis.Text = "";
                        TextBlock_Axis.FontSize = 16;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to only display values or also process input to change the value.
        /// </summary>
        public bool DisplayOnly
        {
            get
            {
                return displayOnly;
            }

            set
            {
                displayOnly = value;
                NumericInput_NearValue.DisplayOnly = value;
                NumericInput_FarValue.DisplayOnly = value;
            }
        }

        /// <summary>
        /// Gets or sets the unit type.
        /// </summary>
        internal UnitType UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
                NumericInput_NearValue.IsInteger = false;
                NumericInput_FarValue.IsInteger = false;
                switch (unitType)
                {
                    case UnitType.Angle:
                        switch (Options.Units.Angle)
                        {
                            case AngleType.Degrees:
                                multiplicationFactor = Constants.DegreePerRadian;
                                TextBlock_UnitType.Text = "°";
                                break;

                            case AngleType.Radians:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "rad";
                                break;
                        }

                        break;

                    case UnitType.Area:

                        switch (Options.Units.Area)
                        {
                            case AreaType.SquareMetre:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "m²";
                                break;

                            case AreaType.SquareCentiMetre:
                                multiplicationFactor = Constants.SquareCentimeterPerSquareMeter;
                                TextBlock_UnitType.Text = "cm²";
                                break;

                            case AreaType.SquareMilliMetre:
                                multiplicationFactor = Constants.SquareMillimeterPerSquareMeter;
                                TextBlock_UnitType.Text = "mm²";
                                break;

                            case AreaType.SquareFoot:
                                multiplicationFactor = Constants.SquareFootPerSquareMeter;
                                TextBlock_UnitType.Text = "ft²";
                                break;

                            case AreaType.SquareInch:
                                multiplicationFactor = Constants.SquareInchPerSquareMeter;
                                TextBlock_UnitType.Text = "in²";
                                break;
                        }

                        break;

                    case UnitType.Density:
                        switch (Options.Units.Density)
                        {
                            case DensityType.KilogramPerCubicMetre:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "kg/m³";
                                break;

                            case DensityType.PoundPerCubicFoot:
                                multiplicationFactor = Constants.PoundPerCubicFootPerKilogramPerMeter;
                                TextBlock_UnitType.Text = " lb/ft³";
                                break;
                        }

                        break;

                    case UnitType.Force:
                        switch (Options.Units.Force)
                        {
                            case ForceType.Dyne:
                                multiplicationFactor = Constants.DynePerNewton;
                                TextBlock_UnitType.Text = "?";
                                break;

                            case ForceType.GigaNewton:
                                multiplicationFactor = Constants.GigaNewtonPerNewton;
                                TextBlock_UnitType.Text = "GN";
                                break;

                            case ForceType.KilogramForce:
                                multiplicationFactor = Constants.KilogramForcePerNewton;
                                TextBlock_UnitType.Text = "?";
                                break;

                            case ForceType.KiloNewton:
                                multiplicationFactor = Constants.KiloNewtonPerNewton;
                                TextBlock_UnitType.Text = "kN";
                                break;

                            case ForceType.MegaNewton:
                                multiplicationFactor = Constants.MegaNewtonPerNewton;
                                TextBlock_UnitType.Text = "MN";
                                break;

                            case ForceType.Newton:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "N";
                                break;

                            case ForceType.Poundal:
                                multiplicationFactor = Constants.PoundalPerNewton;
                                TextBlock_UnitType.Text = "?";
                                break;

                            case ForceType.PoundForce:
                                multiplicationFactor = Constants.PoundForcePerNewton;
                                TextBlock_UnitType.Text = "lbf";
                                break;
                        }

                        break;

                    case UnitType.ForcePerLength:

                        switch (Options.Units.ForcePerLength)
                        {
                            case ForcePerLengthType.NewtonPerMeter:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "N/m";
                                break;
                            case ForcePerLengthType.PoundPerFoot:
                                multiplicationFactor = Constants.PoundForcePerFootPerNewPerMeter;
                                TextBlock_UnitType.Text = "lb/ft";
                                break;
                        }

                        break;

                    case UnitType.Length:
                        switch (Options.Units.Length)
                        {
                            case LengthType.Meter:
                                multiplicationFactor = Constants.MeterPerMeter;
                                TextBlock_UnitType.Text = "m";
                                break;
                            case LengthType.Millimeter:
                                multiplicationFactor = Constants.MilliMeterPerMeter;
                                TextBlock_UnitType.Text = "mm";
                                break;
                            case LengthType.CentiMeter:
                                multiplicationFactor = Constants.CentiMeterPerMeter;
                                TextBlock_UnitType.Text = "cm";
                                break;
                            case LengthType.KiloMeter:
                                multiplicationFactor = Constants.KiloMeterPerMeter;
                                TextBlock_UnitType.Text = "km";
                                break;
                            case LengthType.Inch:
                                multiplicationFactor = Constants.InchPerMeter;
                                TextBlock_UnitType.Text = "in";
                                break;
                            case LengthType.Foot:
                                multiplicationFactor = Constants.FootPerMeter;
                                TextBlock_UnitType.Text = "ft";
                                break;
                        }

                        break;

                    case UnitType.Mass:
                        switch (Options.Units.Mass)
                        {
                            case MassType.Kilogram:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "kg";
                                break;
                            case MassType.Pound:
                                multiplicationFactor = Constants.PoundPerKilogram;
                                TextBlock_UnitType.Text = "lb";
                                break;
                        }

                        break;

                    case UnitType.MomentOfInertia:
                        switch (Options.Units.MomentOfInertia)
                        {
                            case MomentOfInertiaType.QuadMeter:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "m⁴";
                                break;

                            case MomentOfInertiaType.QuadCentmeter:
                                multiplicationFactor = Constants.QuadCentimetersPerQuadMeter;
                                TextBlock_UnitType.Text = "cm⁴";
                                break;

                            case MomentOfInertiaType.QuadFoot:
                                multiplicationFactor = Constants.QuadFootPerQuadMeter;
                                TextBlock_UnitType.Text = "ft⁴";
                                break;

                            case MomentOfInertiaType.QuadInch:
                                multiplicationFactor = Constants.QuadInchPerQuadMeter;
                                TextBlock_UnitType.Text = "in⁴";
                                break;

                            case MomentOfInertiaType.QuadMillimeter:
                                multiplicationFactor = Constants.QuadMillimeterPerQuadMeter;
                                TextBlock_UnitType.Text = "mm⁴";
                                break;
                        }

                        break;

                    case UnitType.Moment:
                        switch (Options.Units.Moment)
                        {
                            case MomentType.NewtonMetre:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "N·m";
                                break;

                            case MomentType.OunceFoot:
                                multiplicationFactor = Constants.OunceFootPerNewtonMeter;
                                TextBlock_UnitType.Text = "oz·ft";
                                break;

                            case MomentType.OunceInch:
                                multiplicationFactor = Constants.OunceInchPerNewtonMeter;
                                TextBlock_UnitType.Text = "oz·in";
                                break;

                            case MomentType.PoundFoot:
                                multiplicationFactor = Constants.PoundFootPerNewtonMeter;
                                TextBlock_UnitType.Text = "lb·ft";
                                break;

                            case MomentType.PoundInch:
                                multiplicationFactor = Constants.PoundInchPerNewtonMeter;
                                TextBlock_UnitType.Text = "lb·in";
                                break;
                        }

                        break;

                    case UnitType.Money:
                        multiplicationFactor = 1;
                        TextBlock_UnitType.Text = string.Empty;
                        break;

                    case UnitType.Pressure:
                        switch (Options.Units.Pressure)
                        {
                            case PressureType.Pascal:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "Pa";
                                break;
                            case PressureType.Gigapascal:
                                multiplicationFactor = Constants.GigapascalPerPascal;
                                TextBlock_UnitType.Text = "GPa";
                                break;
                            case PressureType.Hectopascal:
                                multiplicationFactor = Constants.HectopascalPerPascal;
                                TextBlock_UnitType.Text = "hPa";
                                break;
                            case PressureType.Kilopascal:
                                multiplicationFactor = Constants.KilopascalPerPascal;
                                TextBlock_UnitType.Text = "kPa";
                                break;
                            case PressureType.KilopoundPerSquareInch:
                                multiplicationFactor = Constants.KilopoundPerSquareInchPerPascal;
                                TextBlock_UnitType.Text = "kPsi";
                                break;
                            case PressureType.Megapascal:
                                multiplicationFactor = Constants.MegapascalPerPascal;
                                TextBlock_UnitType.Text = "MPa";
                                break;
                            case PressureType.MegapoundPerSquareInch:
                                multiplicationFactor = Constants.MegapoundPerSquareInchPerPascal;
                                TextBlock_UnitType.Text = "MPsi";
                                break;
                            case PressureType.Millipascal:
                                multiplicationFactor = Constants.MillpascalPerPascal;
                                TextBlock_UnitType.Text = "mPa";
                                break;
                            case PressureType.PoundPerSqareFoot:
                                multiplicationFactor = Constants.PoundPerSquareFootPerPascal;
                                TextBlock_UnitType.Text = "Psft";
                                break;
                            case PressureType.PoundPerSquareInch:
                                multiplicationFactor = Constants.PoundPerSquareInchPerPascal;
                                TextBlock_UnitType.Text = "Psi";
                                break;
                        }

                        break;

                    case UnitType.Volume:
                        switch (Options.Units.Volume)
                        {
                            case VolumeType.CubicMetre:
                                multiplicationFactor = 1;
                                TextBlock_UnitType.Text = "m³";
                                break;

                            case VolumeType.CubicCentimeter:
                                multiplicationFactor = Constants.CubicCentimeterPerCubicMeter;
                                TextBlock_UnitType.Text = "cm³";
                                break;

                            case VolumeType.CubicFoot:
                                multiplicationFactor = Constants.CubicFootPerCubicMeter;
                                TextBlock_UnitType.Text = "ft³";
                                break;

                            case VolumeType.CubicInch:
                                multiplicationFactor = Constants.CubicInchPerCubicMeter;
                                TextBlock_UnitType.Text = "in³";
                                break;

                            case VolumeType.CubicMillimeter:
                                multiplicationFactor = Constants.CubicMillimeterPerCubicMeter;
                                TextBlock_UnitType.Text = "mm³";
                                break;
                        }

                        break;

                    case UnitType.Unitless:
                        multiplicationFactor = 1;
                        TextBlock_UnitType.Text = string.Empty;
                        break;

                    case UnitType.UnitlessInteger:
                        NumericInput_NearValue.IsInteger = true;
                        NumericInput_FarValue.IsInteger = true;
                        multiplicationFactor = 1;
                        TextBlock_UnitType.Text = string.Empty;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets values to null.
        /// </summary>
        internal void SetNull()
        {
            NumericInput_NearValue.SetNull();
            NumericInput_FarValue.SetNull();
        }

        /// <summary>
        /// Sets the values.
        /// </summary>
        /// <param name="newNearValue">The near value.</param>
        /// <param name="newFarValue">The far value.</param>
        internal void SetValue(decimal newNearValue, decimal newFarValue)
        {
            // TODO: Multiply by unit type factor then pass
            NearValue = newNearValue;
            FarValue = newFarValue;

            if (multiplicationFactor == 1)
            {
                NumericInput_NearValue.SetValue(newNearValue);
            }
            else
            {
                NumericInput_NearValue.SetValue(newNearValue * multiplicationFactor);
            }

            if (multiplicationFactor == 1)
            {
                NumericInput_FarValue.SetValue(newFarValue);
            }
            else
            {
                NumericInput_FarValue.SetValue(newFarValue * multiplicationFactor);
            }
        }

        private void NumericInput_NearValue_ValueChanged(object sender, EventArgs e)
        {
            NearValue = NumericInput_NearValue.NewValue;
            NearValueChanged?.Invoke(this, new EventArgs());
        }

        private void NumericInput_FarValue_ValueChanged(object sender, EventArgs e)
        {
            FarValue = NumericInput_FarValue.NewValue;
            FarValueChanged?.Invoke(this, new EventArgs());
        }

        private void TextBlock_UnitType_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (unitType)
            {
                case UnitType.Angle:
                    MenuFlyout nextMenuFlyoutAngle = new MenuFlyout();
                    MenuFlyoutItem itemRadians = new MenuFlyoutItem
                    {
                        Text = "Radians (rad)",
                    };
                    itemRadians.Click += ItemRadians_Click;
                    MenuFlyoutItem itemDegrees = new MenuFlyoutItem
                    {
                        Text = "Degrees (°)",
                    };
                    itemDegrees.Click += ItemDegrees_Click;
                    nextMenuFlyoutAngle.Items.Add(itemDegrees);
                    nextMenuFlyoutAngle.Items.Add(itemRadians);
                    nextMenuFlyoutAngle.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Area:
                    MenuFlyout nextMenuFlyoutArea = new MenuFlyout();
                    MenuFlyoutItem itemSquareMetre = new MenuFlyoutItem
                    {
                        Text = "Square Metre (m²)",
                    };
                    itemSquareMetre.Click += ItemSquareMetre_Click;
                    MenuFlyoutItem itemSquareCentiMetre = new MenuFlyoutItem
                    {
                        Text = "Square Centimetre (cm²)",
                    };
                    itemSquareCentiMetre.Click += ItemSquareCentiMetre_Click;
                    MenuFlyoutItem itemSquareMilliMetre = new MenuFlyoutItem
                    {
                        Text = "Square Millimetre (mm²)",
                    };
                    itemSquareMilliMetre.Click += ItemSquareMilliMetre_Click;
                    MenuFlyoutItem itemSquareFoot = new MenuFlyoutItem
                    {
                        Text = "Square Foot (ft²)",
                    };
                    itemSquareFoot.Click += ItemSquareFoot_Click;
                    MenuFlyoutItem itemSquareInch = new MenuFlyoutItem
                    {
                        Text = "Square Inch (in²)",
                    };
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
                    MenuFlyoutItem itemKilogramPerCubicMetre = new MenuFlyoutItem
                    {
                        Text = "Kilogram per cubic Metre (kg/m³)",
                    };
                    itemKilogramPerCubicMetre.Click += ItemKilogramPerCubicMetre_Click;
                    MenuFlyoutItem itemPoundPerCubicFoot = new MenuFlyoutItem
                    {
                        Text = "Pound per cubic Foot( (lb/ft³)",
                    };
                    itemPoundPerCubicFoot.Click += ItemPoundPerCubicFoot_Click;
                    nextMenuFlyoutDensity.Items.Add(itemKilogramPerCubicMetre);
                    nextMenuFlyoutDensity.Items.Add(itemPoundPerCubicFoot);
                    nextMenuFlyoutDensity.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Force:
                    MenuFlyout nextMenuFlyoutForce = new MenuFlyout();
                    MenuFlyoutItem itemNewton = new MenuFlyoutItem
                    {
                        Text = "Newton (N)",
                    };
                    itemNewton.Click += ItemNewton_Click;
                    MenuFlyoutItem itemKiloNewton = new MenuFlyoutItem
                    {
                        Text = "KiloNewton (kN)",
                    };
                    itemKiloNewton.Click += ItemKiloNewton_Click;
                    MenuFlyoutItem itemMegaNewton = new MenuFlyoutItem
                    {
                        Text = "MegaNewton (MN)",
                    };
                    itemMegaNewton.Click += ItemMegaNewton_Click;
                    MenuFlyoutItem itemGigaNewton = new MenuFlyoutItem
                    {
                        Text = "GigaNewton (GN)",
                    };
                    itemGigaNewton.Click += ItemGigaNewton_Click;
                    MenuFlyoutItem itemDyne = new MenuFlyoutItem
                    {
                        Text = "Dyne",
                    };
                    itemDyne.Click += ItemDyne_Click;
                    MenuFlyoutItem itemKilogramForce = new MenuFlyoutItem
                    {
                        Text = "Kilogram Force",
                    };
                    itemKilogramForce.Click += ItemKilogramForce_Click;
                    MenuFlyoutItem itemPoundForce = new MenuFlyoutItem
                    {
                        Text = "Pound Force",
                    };
                    itemPoundForce.Click += ItemPoundForce_Click;
                    MenuFlyoutItem itemPoundal = new MenuFlyoutItem
                    {
                        Text = "Poundal",
                    };
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
                    MenuFlyoutItem itemNewtonPerMeter = new MenuFlyoutItem
                    {
                        Text = "Newton per Meter (N/m)",
                    };
                    itemNewtonPerMeter.Click += ItemNewtonPerMeter_Click;
                    MenuFlyoutItem itemPoundPerFoot = new MenuFlyoutItem
                    {
                        Text = "Pound per Foot (lb/ft)",
                    };
                    itemPoundPerFoot.Click += ItemPoundPerFoot_Click;
                    nextMenuFlyoutForcePerLength.Items.Add(itemNewtonPerMeter);
                    nextMenuFlyoutForcePerLength.Items.Add(itemPoundPerFoot);
                    nextMenuFlyoutForcePerLength.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Length:
                    MenuFlyout nextMenuFlyoutLength = new MenuFlyout();
                    MenuFlyoutItem itemMilliMeter = new MenuFlyoutItem
                    {
                        Text = "MilliMeter (mm)",
                    };
                    itemMilliMeter.Click += ItemMilliMeter_Click;
                    MenuFlyoutItem itemCentiMeter = new MenuFlyoutItem
                    {
                        Text = "CentiMeter (cm)",
                    };
                    itemCentiMeter.Click += ItemCentiMeter_Click;
                    MenuFlyoutItem itemMeter = new MenuFlyoutItem
                    {
                        Text = "Meter (m)",
                    };
                    itemMeter.Click += ItemMeter_Click;
                    MenuFlyoutItem itemKiloMeter = new MenuFlyoutItem
                    {
                        Text = "KiloMeter (km)",
                    };
                    itemKiloMeter.Click += ItemKiloMeter_Click;
                    MenuFlyoutSeparator seperatorMetric = new MenuFlyoutSeparator();
                    MenuFlyoutItem itemInch = new MenuFlyoutItem
                    {
                        Text = "Inch (in)",
                    };
                    itemInch.Click += ItemInch_Click;
                    MenuFlyoutItem itemFoot = new MenuFlyoutItem
                    {
                        Text = "Foot (ft)",
                    };
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
                    MenuFlyoutItem itemKilogram = new MenuFlyoutItem
                    {
                        Text = "Kilograms (kg)",
                    };
                    itemKilogram.Click += ItemKilogram_Click;
                    MenuFlyoutItem itemGram = new MenuFlyoutItem
                    {
                        Text = "CentiMeters (g)",
                    };
                    itemGram.Click += ItemGram_Click;
                    MenuFlyoutItem itemTon = new MenuFlyoutItem
                    {
                        Text = "Ton (t)",
                    };
                    itemTon.Click += ItemTon_Click;
                    MenuFlyoutItem itemPound = new MenuFlyoutItem
                    {
                        Text = "Pound (lb)",
                    };
                    itemPound.Click += ItemPound_Click;
                    nextMenuFlyoutMass.Items.Add(itemKilogram);
                    nextMenuFlyoutMass.Items.Add(itemGram);
                    nextMenuFlyoutMass.Items.Add(itemTon);
                    nextMenuFlyoutMass.Items.Add(itemPound);
                    nextMenuFlyoutMass.ShowAt((FrameworkElement)sender);
                    break;

                case UnitType.Moment:
                    MenuFlyout nextMenuFlyoutMoment = new MenuFlyout();
                    MenuFlyoutItem itemNewtonMetre = new MenuFlyoutItem
                    {
                        Text = "Newton Meter (N·m)",
                    };
                    itemNewtonMetre.Click += ItemNewtonMetre_Click;
                    MenuFlyoutItem itemPoundFoot = new MenuFlyoutItem
                    {
                        Text = "Pound Foot (lb·ft)",
                    };
                    itemPoundFoot.Click += ItemPoundFoot_Click;
                    MenuFlyoutItem itemPoundInch = new MenuFlyoutItem
                    {
                        Text = "Pound Inch (lb·in)",
                    };
                    itemPoundInch.Click += ItemPoundInch_Click;
                    MenuFlyoutItem itemOunceInch = new MenuFlyoutItem
                    {
                        Text = "Ounce Inch (oz·in)",
                    };
                    itemOunceInch.Click += ItemOunceInch_Click;
                    MenuFlyoutItem itemOunceFoot = new MenuFlyoutItem
                    {
                        Text = "Ounce Foot (oz·ft)",
                    };
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
                    MenuFlyoutItem itemQuadMeter = new MenuFlyoutItem
                    {
                        Text = "Quad Meter (m⁴)",
                    };
                    itemQuadMeter.Click += ItemQuadMeter_Click;
                    MenuFlyoutItem itemQuadMillimeter = new MenuFlyoutItem
                    {
                        Text = "Quad Millimeter (mm⁴)",
                    };
                    itemQuadMillimeter.Click += ItemQuadMillimeter_Click;
                    MenuFlyoutItem itemQuadCentimeter = new MenuFlyoutItem
                    {
                        Text = "Quad Centimeter (cm⁴)",
                    };
                    itemQuadCentimeter.Click += ItemQuadCentimeter_Click;
                    MenuFlyoutItem itemQuadInch = new MenuFlyoutItem
                    {
                        Text = "Quad Inch (in⁴)",
                    };
                    itemQuadInch.Click += ItemQuadInch_Click;
                    MenuFlyoutItem itemQuadFoot = new MenuFlyoutItem
                    {
                        Text = "Quad Foot (ft⁴)",
                    };
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
                    MenuFlyoutItem itemPascal = new MenuFlyoutItem
                    {
                        Text = "Pascal (Pa)",
                    };
                    itemPascal.Click += ItemPascal_Click;

                    MenuFlyoutItem itemMilliPascal = new MenuFlyoutItem
                    {
                        Text = "Milli-pascal (mPa)",
                    };
                    itemMilliPascal.Click += ItemMilliPascal_Click;

                    MenuFlyoutItem itemHectoPascal = new MenuFlyoutItem
                    {
                        Text = "Hecto-pascal (hPa)",
                    };
                    itemHectoPascal.Click += ItemHectoPascal_Click;

                    MenuFlyoutItem itemKiloPascal = new MenuFlyoutItem
                    {
                        Text = "Kilo-pascal (kPa)",
                    };
                    itemKiloPascal.Click += ItemKiloPascal_Click;

                    MenuFlyoutItem itemMegaPascal = new MenuFlyoutItem
                    {
                        Text = "Mega-pascal (MPa)",
                    };
                    itemMegaPascal.Click += ItemMegaPascal_Click;

                    MenuFlyoutItem itemGigaPascal = new MenuFlyoutItem
                    {
                        Text = "Giga-pascal (GPa)",
                    };
                    itemGigaPascal.Click += ItemGigaPascal_Click;

                    MenuFlyoutItem itemPoundPerSquareInch = new MenuFlyoutItem
                    {
                        Text = " ()",
                    };
                    itemPoundPerSquareInch.Click += ItemPoundPerSquareInch_Click;

                    MenuFlyoutItem itemKilopoundPerSquareInch = new MenuFlyoutItem
                    {
                        Text = " ()",
                    };
                    itemKilopoundPerSquareInch.Click += ItemKilopoundPerSquareInch_Click;

                    MenuFlyoutItem itemMegaPoundPerSquareInch = new MenuFlyoutItem
                    {
                        Text = " ()",
                    };
                    itemMegaPoundPerSquareInch.Click += ItemMegaPoundPerSquareInch_Click;

                    MenuFlyoutItem itemPoundPerSquareFoot = new MenuFlyoutItem
                    {
                        Text = " ()",
                    };
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

                case UnitType.Temperature:

                    break;

                case UnitType.Time:

                    break;

                case UnitType.Unitless:

                    break;

                case UnitType.UnitlessInteger:

                    break;

                case UnitType.Volume:
                    MenuFlyout nextMenuFlyoutVolume = new MenuFlyout();
                    MenuFlyoutItem itemCubicMeter = new MenuFlyoutItem
                    {
                        Text = "Cubic Meter (m³)",
                    };
                    itemCubicMeter.Click += ItemCubicMeter_Click;

                    MenuFlyoutItem itemCubicCentimeter = new MenuFlyoutItem
                    {
                        Text = "Cubic Centimeter (cm³)",
                    };
                    itemCubicCentimeter.Click += ItemCubicCentimeter_Click;

                    MenuFlyoutItem itemCubicMillimeter = new MenuFlyoutItem
                    {
                        Text = "Cubic Millimeter (mm³)",
                    };
                    itemCubicMillimeter.Click += ItemCubicMillimeter_Click;

                    MenuFlyoutItem itemCubicFoot = new MenuFlyoutItem
                    {
                        Text = "Cubic Foot (ft³)",
                    };
                    itemCubicFoot.Click += ItemCubicFoot_Click;

                    MenuFlyoutItem itemCubicInch = new MenuFlyoutItem
                    {
                        Text = "Cubic Inch (in³)",
                    };
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
            Options.Units.Volume = VolumeType.CubicInch;
            Model.UpdatePanelPage();
        }

        private void ItemCubicFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Volume = VolumeType.CubicFoot;
            Model.UpdatePanelPage();
        }

        private void ItemCubicMillimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Volume = VolumeType.CubicMillimeter;
            Model.UpdatePanelPage();
        }

        private void ItemCubicCentimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Volume = VolumeType.CubicCentimeter;
            Model.UpdatePanelPage();
        }

        private void ItemCubicMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Volume = VolumeType.CubicMetre;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Pressure

        private void ItemPoundPerSquareFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.PoundPerSqareFoot;
            Model.UpdatePanelPage();
        }

        private void ItemMegaPoundPerSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.MegapoundPerSquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemKilopoundPerSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.KilopoundPerSquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemPoundPerSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.PoundPerSquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemGigaPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.Gigapascal;
            Model.UpdatePanelPage();
        }

        private void ItemMegaPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.Megapascal;
            Model.UpdatePanelPage();
        }

        private void ItemKiloPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.Kilopascal;
            Model.UpdatePanelPage();
        }

        private void ItemHectoPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.Hectopascal;
            Model.UpdatePanelPage();
        }

        private void ItemMilliPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.Millipascal;
            Model.UpdatePanelPage();
        }

        private void ItemPascal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Pressure = PressureType.Pascal;
            Model.UpdatePanelPage();
        }

        #endregion
        #region 2nd Moment of Area

        private void ItemQuadFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.MomentOfInertia = MomentOfInertiaType.QuadFoot;
            Model.UpdatePanelPage();
        }

        private void ItemQuadInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.MomentOfInertia = MomentOfInertiaType.QuadInch;
            Model.UpdatePanelPage();
        }

        private void ItemQuadCentimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.MomentOfInertia = MomentOfInertiaType.QuadCentmeter;
            Model.UpdatePanelPage();
        }

        private void ItemQuadMillimeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.MomentOfInertia = MomentOfInertiaType.QuadMillimeter;
            Model.UpdatePanelPage();
        }

        private void ItemQuadMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.MomentOfInertia = MomentOfInertiaType.QuadMeter;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Moment

        private void ItemOunceFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Moment = MomentType.OunceFoot;
            Model.UpdatePanelPage();
        }

        private void ItemOunceInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Moment = MomentType.OunceInch;
            Model.UpdatePanelPage();
        }

        private void ItemPoundInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Moment = MomentType.PoundInch;
            Model.UpdatePanelPage();
        }

        private void ItemPoundFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Moment = MomentType.PoundFoot;
            Model.UpdatePanelPage();
        }

        private void ItemNewtonMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Moment = MomentType.NewtonMetre;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Mass

        private void ItemTon_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Mass = MassType.Ton;
            Model.UpdatePanelPage();
        }

        private void ItemGram_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Mass = MassType.Gram;
            Model.UpdatePanelPage();
        }

        private void ItemKilogram_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Mass = MassType.Kilogram;
            Model.UpdatePanelPage();
        }

        private void ItemPound_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Mass = MassType.Pound;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Force Per Length

        private void ItemPoundPerFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.ForcePerLength = ForcePerLengthType.PoundPerFoot;
            Model.UpdatePanelPage();
        }

        private void ItemNewtonPerMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.ForcePerLength = ForcePerLengthType.NewtonPerMeter;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Force

        private void ItemPoundal_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.Poundal;
            Model.UpdatePanelPage();
        }

        private void ItemPoundForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.PoundForce;
            Model.UpdatePanelPage();
        }

        private void ItemKilogramForce_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.KilogramForce;
            Model.UpdatePanelPage();
        }

        private void ItemDyne_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.Dyne;
            Model.UpdatePanelPage();
        }

        private void ItemGigaNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.GigaNewton;
            Model.UpdatePanelPage();
        }

        private void ItemMegaNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.MegaNewton;
            Model.UpdatePanelPage();
        }

        private void ItemKiloNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.KiloNewton;
            Model.UpdatePanelPage();
        }

        private void ItemNewton_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Force = ForceType.Newton;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Density

        private void ItemPoundPerCubicFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Density = DensityType.PoundPerCubicFoot;
            Model.UpdatePanelPage();
        }

        private void ItemKilogramPerCubicMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Density = DensityType.KilogramPerCubicMetre;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Angle

        private void ItemDegrees_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Angle = AngleType.Degrees;
            Model.UpdatePanelPage();
        }

        private void ItemRadians_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Angle = AngleType.Radians;
            Model.UpdatePanelPage();
        }

        #endregion
        #region Length

        private void ItemFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Length = LengthType.Foot;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Length = LengthType.Inch;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemKiloMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Length = LengthType.KiloMeter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Length = LengthType.Meter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemCentiMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Length = LengthType.CentiMeter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        private void ItemMilliMeter_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Length = LengthType.Millimeter;
            Camera.UpdateLengthType();
            Model.UpdatePanelPage();
        }

        #endregion
        #region Area

        private void ItemSquareInch_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Area = AreaType.SquareInch;
            Model.UpdatePanelPage();
        }

        private void ItemSquareFoot_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Area = AreaType.SquareFoot;
            Model.UpdatePanelPage();
        }

        private void ItemSquareMilliMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Area = AreaType.SquareMilliMetre;
            Model.UpdatePanelPage();
        }

        private void ItemSquareCentiMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Area = AreaType.SquareCentiMetre;
            Model.UpdatePanelPage();
        }

        private void ItemSquareMetre_Click(object sender, RoutedEventArgs e)
        {
            Options.Units.Area = AreaType.SquareMetre;
            Model.UpdatePanelPage();
        }

        #endregion

        private void NumericInput_FarValue_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
        }

        private void TextBlock_Axis_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                flyOut_Shared.ShowAt(TextBlock_Axis);
                TextBox_Input.SetTheValue(NearValue);
            }
        }

        private void TextBox_Input_ValueChanged(object sender, EventArgs e)
        {
            NearValue = TextBox_Input.NewValue;
            FarValue = TextBox_Input.NewValue;
            flyOut_Shared.Hide();
            ValueChanged?.Invoke(this, new EventArgs());
        }
    }
}
