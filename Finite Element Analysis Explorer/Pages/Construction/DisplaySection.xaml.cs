namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// DisplaySection page.
    /// </summary>
    public sealed partial class DisplaySection : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplaySection"/> class.
        /// </summary>
        public DisplaySection()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set item sources.
            ListView_Materials.ItemsSource = Model.Materials.Values;
            ListView_Profile.ItemsSource = Model.SectionProfiles.Values;
            if (Model.Members.CurrentMember == null)
            {
                if (Model.Sections.CurrentSection == null)
                {
                    Model.Sections.CurrentSection = Model.Sections["Default"];
                }
            }

            TextBlock_Section_Title.Text = "Section : " + Model.Sections.CurrentSection.Name;

            // Section.
            SingleValue_CalculatedArea.Title = "Area";
            SingleValue_CalculatedArea.UnitType = UnitType.Area;

            SingleValue_CalculatedMoment.Title = "2nd Moment of Area";
            SingleValue_CalculatedMoment.UnitType = UnitType.MomentOfInertia;

            SingleValue_RadiusOfGyration.Title = "Radius of Gyration";
            SingleValue_RadiusOfGyration.UnitType = UnitType.Length;

            SingleValue_SectionModulus.Title = "Section Modulus";
            SingleValue_SectionModulus.UnitType = UnitType.Volume;

            SingleValue_VolumePerLength.Title = "Volume per Length";
            SingleValue_VolumePerLength.UnitType = UnitType.Volume;

            SingleValue_MassPerLength.Title = "Mass per Length";
            SingleValue_MassPerLength.UnitType = UnitType.Mass;

            SingleValue_WeightPerLength.Title = "Weight per Length";
            SingleValue_WeightPerLength.UnitType = UnitType.Force;

            SingleValue_Property1.UnitType = UnitType.Length;
            SingleValue_Property2.UnitType = UnitType.Length;
            SingleValue_Property3.UnitType = UnitType.Length;
            SingleValue_Property4.UnitType = UnitType.Length;
            SingleValue_Property5.UnitType = UnitType.Length;
            SingleValue_Property6.UnitType = UnitType.Length;
            SingleValue_Property7.UnitType = UnitType.Length;

            // Profile.
            SingleValue_ElasticModulus.Title = "Elastic Modulus";
            SingleValue_ElasticModulus.UnitType = UnitType.Pressure;

            SingleValue_RigidityModulus.Title = "Rigidity Modulus";
            SingleValue_RigidityModulus.UnitType = UnitType.Pressure;

            SingleValue_BulkModulus.Title = "Bulk Modulus";
            SingleValue_BulkModulus.UnitType = UnitType.Pressure;

            SingleValue_Density.Title = "Density";
            SingleValue_Density.UnitType = UnitType.Area;

            SingleValue_PoissonRatio.Title = "Poisson Ratio";
            SingleValue_PoissonRatio.UnitType = UnitType.Unitless;

            SingleValue_ThermalExpansion.Title = "Thermal Expansion";
            SingleValue_ThermalExpansion.UnitType = UnitType.Unitless;

            SingleValue_ThermalConductivity.Title = "Thermal Conductivity";
            SingleValue_ThermalConductivity.UnitType = UnitType.Unitless;

            // Costs.
            SingleValue_CostPerLength.Title = "Cost per Length";
            SingleValue_CostPerLength.UnitType = UnitType.Money;

            SingleValue_CostVerticalTransport.Title = "Vertical Transport";
            SingleValue_CostVerticalTransport.UnitType = UnitType.Money;

            SingleValue_CostHorizontalTransport.Title = "Horizontal";
            SingleValue_CostHorizontalTransport.UnitType = UnitType.Money;

            SingleValue_CostNodeFree.Title = "Free Node";
            SingleValue_CostNodeFree.UnitType = UnitType.Money;

            SingleValue_CostNodeFixed.Title = "Fixed Node";
            SingleValue_CostNodeFixed.UnitType = UnitType.Money;

            SingleValue_CostNodePinned.Title = "Pinned Node";
            SingleValue_CostNodePinned.UnitType = UnitType.Money;

            SingleValue_CostNodeRoller.Title = "Roller Node";
            SingleValue_CostNodeRoller.UnitType = UnitType.Money;

            SingleValue_CostNodeTrack.Title = "Track Node";
            SingleValue_CostNodeTrack.UnitType = UnitType.Money;

            SingleValue_FactorVerticalTransport.Title = "Vertical Factor";
            SingleValue_FactorVerticalTransport.UnitType = UnitType.Percentage;

            SingleValue_FactorHorizontalTransport.Title = "Horizontal Factor";
            SingleValue_FactorHorizontalTransport.UnitType = UnitType.Percentage;

            SingleValue_MaintenanceNodeFree.Title = "Free Node";
            SingleValue_MaintenanceNodeFree.UnitType = UnitType.Money;

            SingleValue_MaintenanceFixed.Title = "Fixed Node";
            SingleValue_MaintenanceFixed.UnitType = UnitType.Money;

            SingleValue_MaintenancePinned.Title = "Free Node";
            SingleValue_MaintenancePinned.UnitType = UnitType.Money;

            SingleValue_MaintenanceRoller.Title = "Roller Node";
            SingleValue_MaintenanceRoller.UnitType = UnitType.Money;

            SingleValue_MaintenanceTrack.Title = "Track Node";
            SingleValue_MaintenanceTrack.UnitType = UnitType.Money;

            SingleValue_MaintenancePerLength.Title = "Per Length";
            SingleValue_MaintenancePerLength.UnitType = UnitType.Money;

            SingleValue_Cost.Title = "Cost";
            SingleValue_Cost.UnitType = UnitType.Money;

            SingleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);
            SingleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);
            SingleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);
            SingleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
            SingleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
            SingleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);
            SingleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);
            SingleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);
            SingleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);
            SingleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);
            SingleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);
            SingleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);
            SingleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);
            SingleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);
            SingleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);
            if (Model.SectionProfiles.ContainsKey(Model.Sections.CurrentSection.SectionProfile))
            {
                UpdateProfile(Model.SectionProfiles[Model.Sections.CurrentSection.SectionProfile]);
            }
            else
            {
                Model.Sections.CurrentSection.SectionProfile = "Solid Rectangle";
                UpdateProfile(Model.SectionProfiles[Model.Sections.CurrentSection.SectionProfile]);
            }

            if (Model.Materials.ContainsKey(Model.Sections.CurrentSection.Material))
            {
                UpdateMaterial(Model.Materials[Model.Sections.CurrentSection.Material]);
            }
            else
            {
                Model.Sections.CurrentSection.Material = "Default";
                UpdateMaterial(Model.Materials[Model.Sections.CurrentSection.Material]);
            }

            // Cost factors.
        }

        private void CalculateSection()
        {
            SingleValue_CalculatedArea.SetNull();
            SingleValue_CalculatedMoment.SetNull();
            SingleValue_RadiusOfGyration.SetNull();
            SingleValue_SectionModulus.SetNull();
            SingleValue_VolumePerLength.SetNull();
            SingleValue_MassPerLength.SetNull();
            SingleValue_WeightPerLength.SetNull();
            SingleValue_CostPerLength.SetNull();

            switch (Model.Sections.CurrentSection.SectionProfile)
            {
                case "I Beam":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty3 > 0))
                    {
                        decimal breadth = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal height = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal width = Model.Sections.CurrentSection.SectionProfileProperty3;
                        decimal outerArea = breadth * height;
                        decimal innerBreadth = breadth - width;
                        decimal innerHeight = height - width - width;
                        decimal innerArea = innerBreadth * innerHeight;
                        decimal area = outerArea - innerArea;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;

                            decimal outerMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                            decimal innerMoment = innerBreadth * innerHeight * innerHeight * innerHeight / 12;
                            decimal secondMoment = outerMoment - innerMoment;
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                            Model.Sections.CurrentSection.I = secondMoment;

                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (height / 2));

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Solid Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal breadth = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal height = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal area = breadth * height;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;

                            decimal secondMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                            Model.Sections.CurrentSection.I = secondMoment;

                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (height / 2));

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Hollow Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty3 > 0))
                    {
                        decimal outer = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal innerBreadth = Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2);
                        decimal innerHeight = Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2);
                        decimal inner = innerBreadth * innerHeight;
                        decimal area = outer - inner;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;
                            decimal outerMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                            decimal innerMoment = innerBreadth * innerHeight * innerHeight * innerHeight / 12;
                            decimal secondMoment = outerMoment - innerMoment;
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                            Model.Sections.CurrentSection.I = secondMoment;

                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Solid Circle":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal area = DMath.PI * radius * radius;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;
                            decimal secondMoment = DMath.PI / 4 * radius * radius * radius * radius;
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                            Model.Sections.CurrentSection.I = secondMoment;
                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / radius);

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Hollow Circle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal width = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal innerRadius = radius - width;
                        decimal outerArea = DMath.PI * radius * radius;
                        decimal innerArea = DMath.PI * innerRadius * innerRadius;
                        decimal area = outerArea - innerArea;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;
                            decimal secondMoment = (DMath.PI / 4 * radius * radius * radius * radius) - (DMath.PI / 4 * innerRadius * innerRadius * innerRadius * innerRadius);
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);

                            Model.Sections.CurrentSection.I = secondMoment;
                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / radius);

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Solid Square":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal area = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;
                            decimal secondMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 / 12;
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                            Model.Sections.CurrentSection.I = secondMoment;
                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty1 / 2));

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Hollow Square":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal outer = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal innerBreadth = Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2);
                        decimal innerHeight = Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2);
                        decimal inner = innerBreadth * innerHeight;
                        decimal area = outer - inner;

                        if (area > 0)
                        {
                            SingleValue_CalculatedArea.SetTheValue(area);
                            Model.Sections.CurrentSection.Area = area;
                            decimal outerMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                            decimal innerMoment = innerBreadth * innerHeight * innerHeight * innerHeight / 12;
                            decimal secondMoment = outerMoment - innerMoment;
                            SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                            Model.Sections.CurrentSection.I = secondMoment;
                            SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));

                            Model.Sections.CurrentSection.CostPerLength = Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost;
                            switch (Options.Units.Length)
                            {
                                case LengthType.Meter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    SingleValue_MassPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter * SingleValue_Density.NewValue);
                                    SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    SingleValue_WeightPerLength.SetTheValue(SingleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }

                    break;
                case "Solid Elipse":

                    break;
                case "Hollow Elipse":

                    break;
            }
        }

        #region Material

        private void UpdateMaterial(Material selectedMaterial)
        {
            TextBlock_SelectedMaterial.Text = selectedMaterial.Name;
            Model.Sections.CurrentSection.Material = selectedMaterial.Name;

            SingleValue_ElasticModulus.SetNull();
            SingleValue_RigidityModulus.SetNull();
            SingleValue_BulkModulus.SetNull();
            SingleValue_Density.SetNull();
            SingleValue_PoissonRatio.SetNull();
            SingleValue_ThermalExpansion.SetNull();
            SingleValue_ThermalConductivity.SetNull();

            // Material
            SingleValue_Cost.SetNull();
            SingleValue_Cost.SetTheValue(selectedMaterial.Cost);

            SingleValue_Density.DisplayOnly = true;
            SingleValue_Density.SetNull();
            SingleValue_Density.SetTheValue(selectedMaterial.Density);

            SingleValue_ElasticModulus.DisplayOnly = true;
            SingleValue_ElasticModulus.Title = "Elastic Modulus";
            SingleValue_ElasticModulus.UnitType = UnitType.Pressure;
            SingleValue_ElasticModulus.SetNull();
            try
            {
                SingleValue_ElasticModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
                Model.Sections.CurrentSection.E = selectedMaterial.ModulusOfElasticity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Setting E ");
                WService.ReportException(ex);
            }

            SingleValue_RigidityModulus.DisplayOnly = true;
            SingleValue_RigidityModulus.Title = "Rigidity Modulus";
            SingleValue_RigidityModulus.UnitType = UnitType.Pressure;
            SingleValue_RigidityModulus.SetNull();
            try
            {
                SingleValue_RigidityModulus.SetTheValue(selectedMaterial.ModulusOfRigidity);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_BulkModulus.DisplayOnly = true;
            SingleValue_BulkModulus.Title = "Bulk Modulus";
            SingleValue_BulkModulus.UnitType = UnitType.Pressure;
            SingleValue_BulkModulus.SetNull();
            try
            {
                SingleValue_BulkModulus.SetTheValue(selectedMaterial.Bulk_Modulus);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_PoissonRatio.DisplayOnly = true;
            SingleValue_PoissonRatio.Title = "Poisson Ratio";
            SingleValue_PoissonRatio.UnitType = UnitType.Unitless;
            SingleValue_PoissonRatio.SetNull();
            try
            {
                SingleValue_PoissonRatio.SetTheValue(selectedMaterial.Poission_Ratio);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_ThermalExpansion.DisplayOnly = true;
            SingleValue_ThermalExpansion.Title = "Thermal Expansions";
            SingleValue_ThermalExpansion.UnitType = UnitType.Unitless;
            SingleValue_ThermalExpansion.SetNull();
            try
            {
                SingleValue_ThermalExpansion.SetTheValue(selectedMaterial.Thermal_Expansion);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_ThermalConductivity.DisplayOnly = true;
            SingleValue_ThermalConductivity.Title = "Thermal Conductivity";
            SingleValue_ThermalConductivity.UnitType = UnitType.Unitless;
            SingleValue_ThermalConductivity.SetNull();
            try
            {
                SingleValue_ThermalConductivity.SetTheValue(selectedMaterial.Thermal_Conductivity);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            CalculateSection();
        }

        private void ListView_Materials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Material selectedMaterial = (Material)ListView_Materials.SelectedItem;

            UpdateMaterial(selectedMaterial);
        }

        #endregion

        #region Profile

        private void UpdateProfile(SectionProfile selectedProfile)
        {
            TextBlock_SelectedProfile.Text = selectedProfile.Name;

            if (selectedProfile.ImagePath != null)
            {
                image_Profile.Source = new BitmapImage(new Uri(selectedProfile.ImagePath));
            }

            SingleValue_Property1.Visibility = Visibility.Collapsed;
            SingleValue_Property2.Visibility = Visibility.Collapsed;
            SingleValue_Property3.Visibility = Visibility.Collapsed;
            SingleValue_Property4.Visibility = Visibility.Collapsed;
            SingleValue_Property5.Visibility = Visibility.Collapsed;
            SingleValue_Property6.Visibility = Visibility.Collapsed;
            SingleValue_Property7.Visibility = Visibility.Collapsed;
            SingleValue_Property1.SetNull();
            SingleValue_Property2.SetNull();
            SingleValue_Property3.SetNull();
            SingleValue_Property4.SetNull();
            SingleValue_Property5.SetNull();
            SingleValue_Property6.SetNull();
            SingleValue_Property7.SetNull();

            SingleValue_CalculatedArea.SetNull();
            SingleValue_CalculatedMoment.SetNull();

            SingleValue_RadiusOfGyration.SetNull();
            SingleValue_SectionModulus.SetNull();

            SingleValue_VolumePerLength.SetNull();
            SingleValue_MassPerLength.SetNull();
            SingleValue_WeightPerLength.SetNull();

            if (selectedProfile.Name == Model.Sections.CurrentSection.SectionProfile)
            {
                switch (selectedProfile.Name)
                {
                    case "I Beam":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        SingleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                        break;

                    case "Solid Rectangle":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Hollow Rectangle":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        SingleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                        break;

                    case "Solid Square":
                        SingleValue_Property1.Title = "Side (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        break;

                    case "Hollow Square":
                        SingleValue_Property1.Title = "Side (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Width (w)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Solid Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        break;

                    case "Hollow Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Width (w)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Solid Elipse":
                        SingleValue_Property1.Title = "Length x-axis (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Length y-axis (b)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Hollow Elipse":
                        SingleValue_Property1.Title = "Length x-axis (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        SingleValue_Property2.Title = "Length y-axis (b)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        SingleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                        break;
                }
            }
            else
            {
                switch (selectedProfile.Name)
                {
                    case "I Beam":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        break;

                    case "Solid Rectangle":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        break;

                    case "Hollow Rectangle":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        SingleValue_Property3.SetNull();
                        break;

                    case "Solid Square":
                        SingleValue_Property1.Title = "Side (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();

                        break;
                    case "Hollow Square":
                        SingleValue_Property1.Title = "Side (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Width (w)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        break;

                    case "Solid Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        break;

                    case "Hollow Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property2.Title = "Width (w)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        break;

                    case "Solid Elipse":
                        SingleValue_Property1.Title = "Length x-axis (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Length y-axis (b)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        break;

                    case "Hollow Elipse":
                        SingleValue_Property1.Title = "Length x-axis (a)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Length y-axis (b)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        SingleValue_Property3.SetNull();
                        break;
                }

                SingleValue_Property1.SetTheValue(0);
                SingleValue_Property2.SetTheValue(0);
                SingleValue_Property3.SetTheValue(0);
                SingleValue_Property4.SetTheValue(0);
                SingleValue_Property5.SetTheValue(0);
                SingleValue_Property6.SetTheValue(0);
                SingleValue_Property7.SetTheValue(0);
                Model.Sections.CurrentSection.SectionProfileProperty1 = 0;
                Model.Sections.CurrentSection.SectionProfileProperty2 = 0;
                Model.Sections.CurrentSection.SectionProfileProperty3 = 0;
                Model.Sections.CurrentSection.SectionProfileProperty4 = 0;
                Model.Sections.CurrentSection.SectionProfileProperty5 = 0;
                Model.Sections.CurrentSection.SectionProfileProperty6 = 0;
                Model.Sections.CurrentSection.SectionProfileProperty7 = 0;
            }

            Model.Sections[Model.Sections.CurrentSection.Name].SectionProfile = selectedProfile.Name;
            CalculateSection();
        }

        private void ListView_Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SectionProfile selectedProfile = (SectionProfile)ListView_Profile.SelectedItem;
            UpdateProfile(selectedProfile);
        }

        private void SingleValue_Property1_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty1 = SingleValue_Property1.NewValue;
            SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
            CalculateSection();
        }

        private void SingleValue_Property2_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty2 = SingleValue_Property2.NewValue;
            SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
            CalculateSection();
        }

        private void SingleValue_Property3_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty3 = SingleValue_Property3.NewValue;
            SingleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
            CalculateSection();
        }

        private void SingleValue_Property4_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty4 = SingleValue_Property4.NewValue;
            SingleValue_Property4.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty4);
            CalculateSection();
        }

        private void SingleValue_Property5_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty5 = SingleValue_Property5.NewValue;
            SingleValue_Property5.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty5);
            CalculateSection();
        }

        private void SingleValue_Property6_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty6 = SingleValue_Property6.NewValue;
            SingleValue_Property6.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty6);
            CalculateSection();
        }

        private void SingleValue_Property7_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty7 = SingleValue_Property7.NewValue;
            SingleValue_Property7.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty7);
            CalculateSection();
        }

        #endregion

        #region Section Properties

        private void SingleValue_YoungsModulus_ValueChanged(object sender, EventArgs e)
        {
            // Model.Sections.CurrentSection.E = SingleValue_YoungsModulus.NewValue;
            // SingleValue_YoungsModulus.SetTheValue(Model.Sections.CurrentSection.E);
        }

        private void SingleValue_MomentOfInertia_ValueChanged(object sender, EventArgs e)
        {
            // Model.Sections.CurrentSection.I = SingleValue_MomentOfInertia.NewValue;
            // SingleValue_MomentOfInertia.SetTheValue(Model.Sections.CurrentSection.I);
        }

        private void SingleValue_Area_ValueChanged(object sender, EventArgs e)
        {
            // Model.Sections.CurrentSection.Area = SingleValue_Area.NewValue;
            // SingleValue_Area.SetTheValue(Model.Sections.CurrentSection.Area);
        }

        private void SingleValue_Density_ValueChanged(object sender, EventArgs e)
        {
            // Model.Sections.CurrentSection.Density = SingleValue_Density.NewValue;
            // SingleValue_Density.SetTheValue(Model.Sections.CurrentSection.Density);
        }

        private void SingleValue_MaintenancePerLength_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenancePerLength = SingleValue_MaintenancePerLength.NewValue;
            SingleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);
        }

        private void SingleValue_MaintenanceNodeFree_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceNodeFree = SingleValue_MaintenanceNodeFree.NewValue;
            SingleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);
        }

        private void SingleValue_MaintenanceFixed_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceFixed = SingleValue_MaintenanceFixed.NewValue;
            SingleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);
        }

        private void SingleValue_MaintenancePinned_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenancePinned = SingleValue_MaintenancePinned.NewValue;
            SingleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);
        }

        private void SingleValue_MaintenanceRoller_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceRoller = SingleValue_MaintenanceRoller.NewValue;
            SingleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);
        }

        private void SingleValue_MaintenanceTrack_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceTrack = SingleValue_MaintenanceTrack.NewValue;
            SingleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);
        }

        private void SingleValue_CostPerLength_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostPerLength = SingleValue_CostPerLength.NewValue;
            SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength);
        }

        private void SingleValue_CostVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostVerticalTransport = SingleValue_CostVerticalTransport.NewValue;
            SingleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);
        }

        private void SingleValue_CostHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostHorizontalTransport = SingleValue_CostHorizontalTransport.NewValue;
            SingleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);
        }

        private void SingleValue_CostNodeFree_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeFree = SingleValue_CostNodeFree.NewValue;
            SingleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);
        }

        private void SingleValue_CostNodeFixed_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeFixed = SingleValue_CostNodeFixed.NewValue;
            SingleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodeFixed);
        }

        private void SingleValue_CostNodePinned_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodePinned = SingleValue_CostNodePinned.NewValue;
            SingleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
        }

        private void SingleValue_CostNodeRoller_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeRoller = SingleValue_CostNodeRoller.NewValue;
            SingleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);
        }

        private void SingleValue_CostNodeTrack_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeTrack = SingleValue_CostNodeTrack.NewValue;
            SingleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);
        }

        private void SingleValue_FactorVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.FactorVerticalTransport = SingleValue_FactorVerticalTransport.NewValue;
            SingleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);
        }

        private void SingleValue_FactorHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.FactorHorizontalTransport = SingleValue_FactorHorizontalTransport.NewValue;
            SingleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);
        }

        #endregion

    }
}