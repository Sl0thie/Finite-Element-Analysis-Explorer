namespace Finite_Element_Analysis_Explorer
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// DisplaySection2 page.
    /// </summary>
    public sealed partial class DisplaySection2 : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplaySection2"/> class.
        /// </summary>
        public DisplaySection2()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set item sources.
            ListView_Materials.ItemsSource = Model.Materials.Values;
            ListView_Profile.ItemsSource = Model.SectionProfiles.Values;

            // Setup form.
            SingleValue_CalculatedArea.UnitType = UnitType.Area;
            SingleValue_CalculatedArea.SetNull();
            SingleValue_CalculatedArea.DisplayOnly = true;
            SingleValue_CalculatedArea.Title = "Area";
            SingleValue_CalculatedMoment.UnitType = UnitType.MomentOfInertia;
            SingleValue_CalculatedMoment.SetNull();
            SingleValue_CalculatedMoment.DisplayOnly = true;
            SingleValue_CalculatedMoment.Title = "Moment of Inertia";

            SingleValue_Property1.UnitType = UnitType.Length;
            SingleValue_Property2.UnitType = UnitType.Length;
            SingleValue_Property3.UnitType = UnitType.Length;
            SingleValue_Property4.UnitType = UnitType.Length;
            SingleValue_Property5.UnitType = UnitType.Length;
            SingleValue_Property6.UnitType = UnitType.Length;
            SingleValue_Property7.UnitType = UnitType.Length;
            SingleValue_Property1.Visibility = Visibility.Collapsed;
            SingleValue_Property2.Visibility = Visibility.Collapsed;
            SingleValue_Property3.Visibility = Visibility.Collapsed;
            SingleValue_Property4.Visibility = Visibility.Collapsed;
            SingleValue_Property5.Visibility = Visibility.Collapsed;
            SingleValue_Property6.Visibility = Visibility.Collapsed;
            SingleValue_Property7.Visibility = Visibility.Collapsed;

            if (Model.Sections.CurrentSection is object)
            {
                TextBlock_Section_Title.Text = "SECTION : " + Model.Sections.CurrentSection.Name;

                SingleValue_YoungsModulus.Title = "Elastic Modulus";
                SingleValue_YoungsModulus.UnitType = UnitType.Pressure;
                SingleValue_YoungsModulus.SetTheValue(Model.Sections.CurrentSection.E);

                SingleValue_MomentOfInertia.Title = "2nd Moment of Area";
                SingleValue_MomentOfInertia.UnitType = UnitType.MomentOfInertia;
                SingleValue_MomentOfInertia.SetTheValue(Model.Sections.CurrentSection.I);

                SingleValue_Area.Title = "Sectional Area";
                SingleValue_Area.UnitType = UnitType.Area;
                SingleValue_Area.SetTheValue(Model.Sections.CurrentSection.Area);

                SingleValue_Density.Title = "Density";
                SingleValue_Density.UnitType = UnitType.Area;
                SingleValue_Density.SetTheValue(Model.Sections.CurrentSection.Density);

                SingleValue_MaintenanceNodeFree.Title = "Free Node";
                SingleValue_MaintenanceNodeFree.UnitType = UnitType.Money;
                SingleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);

                SingleValue_MaintenanceFixed.Title = "Fixed Node";
                SingleValue_MaintenanceFixed.UnitType = UnitType.Money;
                SingleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);

                SingleValue_MaintenancePinned.Title = "Free Node";
                SingleValue_MaintenancePinned.UnitType = UnitType.Money;
                SingleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);

                SingleValue_MaintenanceRoller.Title = "Roller Node";
                SingleValue_MaintenanceRoller.UnitType = UnitType.Money;
                SingleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);

                SingleValue_MaintenanceTrack.Title = "Track Node";
                SingleValue_MaintenanceTrack.UnitType = UnitType.Money;
                SingleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);

                SingleValue_MaintenancePerLength.Title = "Per Length";
                SingleValue_MaintenancePerLength.UnitType = UnitType.Money;
                SingleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);

                SingleValue_CostPerLength.Title = "Cost per Length";
                SingleValue_CostPerLength.UnitType = UnitType.Money;
                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength);

                SingleValue_CostVerticalTransport.Title = "Vertical Transport";
                SingleValue_CostVerticalTransport.UnitType = UnitType.Money;
                SingleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);

                SingleValue_CostHorizontalTransport.Title = "Horizontal";
                SingleValue_CostHorizontalTransport.UnitType = UnitType.Money;
                SingleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);

                SingleValue_CostNodeFree.Title = "Free Node";
                SingleValue_CostNodeFree.UnitType = UnitType.Money;
                SingleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);

                SingleValue_CostNodeFixed.Title = "Fixed Node";
                SingleValue_CostNodeFixed.UnitType = UnitType.Money;
                SingleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodeFixed);

                SingleValue_CostNodePinned.Title = "Pinned Node";
                SingleValue_CostNodePinned.UnitType = UnitType.Money;
                SingleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);

                SingleValue_CostNodeRoller.Title = "Roller Node";
                SingleValue_CostNodeRoller.UnitType = UnitType.Money;
                SingleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);

                SingleValue_CostNodeTrack.Title = "Track Node";
                SingleValue_CostNodeTrack.UnitType = UnitType.Money;
                SingleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);

                SingleValue_FactorVerticalTransport.Title = "Vertical Factor";
                SingleValue_FactorVerticalTransport.UnitType = UnitType.Percentage;
                SingleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);

                SingleValue_FactorHorizontalTransport.Title = "Horizontal Factor";
                SingleValue_FactorHorizontalTransport.UnitType = UnitType.Percentage;
                SingleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);
                if (Model.SectionProfiles.ContainsKey(Model.Sections.CurrentSection.SectionProfile))
                {
                    UpdateProfile(Model.SectionProfiles[Model.Sections.CurrentSection.SectionProfile]);
                }

                if (Model.Materials.ContainsKey(Model.Sections.CurrentSection.Material))
                {
                    UpdateMaterial(Model.Materials[Model.Sections.CurrentSection.Material]);
                }
            }
            else
            {
            }
        }

        #region Material

        private void UpdateMaterial(Material selectedMaterial)
        {
            SingleValue_MaterialDensity.SetNull();
            SingleValue_MaterialYoungsModulus.SetNull();
            SingleValue_MaterialShearModulus.SetNull();
            SingleValue_MaterialBulkModulus.SetNull();
            SingleValue_MaterialPoissonRatio.SetNull();
            SingleValue_MaterialLiquidDensity.SetNull();
            SingleValue_MaterialMohsHardness.SetNull();
            SingleValue_MaterialBrinellHardness.SetNull();
            SingleValue_MaterialVickersHardness.SetNull();
            SingleValue_MaterialThermalExpansion.SetNull();
            SingleValue_MaterialThermalConductivity.SetNull();
            SingleValue_MaterialSoundSpeed.SetNull();
            SingleValue_MaterialMolarVolume.SetNull();
            SingleValue_MaterialAbsoluteBoilingPoint.SetNull();

            TextBlock_Material_Title.Text = "Material : " + selectedMaterial.Name;

            if (Model.Sections.CurrentSection.Material == selectedMaterial.Name)
            {
            }
            else
            {
                // Set Properties to the Section.
                Model.Sections.CurrentSection.Material = selectedMaterial.Name;
                SingleValue_YoungsModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
                Model.Sections.CurrentSection.E = selectedMaterial.ModulusOfElasticity;
                SingleValue_YoungsModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
                SingleValue_Density.SetTheValue(selectedMaterial.Density);
                Model.Sections.CurrentSection.Density = selectedMaterial.Density;
            }

            // Material
            SingleValue_MaterialDensity.DisplayOnly = true;
            SingleValue_MaterialDensity.Title = "Density";
            SingleValue_MaterialDensity.UnitType = UnitType.Density;
            SingleValue_MaterialDensity.SetNull();
            SingleValue_MaterialDensity.SetTheValue(selectedMaterial.Density);

            SingleValue_MaterialYoungsModulus.DisplayOnly = true;
            SingleValue_MaterialYoungsModulus.Title = "Elastic Modulus";
            SingleValue_MaterialYoungsModulus.UnitType = UnitType.Pressure;
            SingleValue_MaterialYoungsModulus.SetNull();
            try
            {
                SingleValue_MaterialYoungsModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialShearModulus.DisplayOnly = true;
            SingleValue_MaterialShearModulus.Title = "Rigidity Modulus";
            SingleValue_MaterialShearModulus.UnitType = UnitType.Pressure;
            SingleValue_MaterialShearModulus.SetNull();
            try
            {
                SingleValue_MaterialShearModulus.SetTheValue(selectedMaterial.ModulusOfRigidity);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialBulkModulus.DisplayOnly = true;
            SingleValue_MaterialBulkModulus.Title = "Bulk Modulus";
            SingleValue_MaterialBulkModulus.UnitType = UnitType.Pressure;
            SingleValue_MaterialBulkModulus.SetNull();
            try
            {
                SingleValue_MaterialBulkModulus.SetTheValue(selectedMaterial.Bulk_Modulus);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialPoissonRatio.DisplayOnly = true;
            SingleValue_MaterialPoissonRatio.Title = "Poisson Ratio";
            SingleValue_MaterialPoissonRatio.UnitType = UnitType.Unitless;
            SingleValue_MaterialPoissonRatio.SetNull();
            try
            {
                SingleValue_MaterialPoissonRatio.SetTheValue(selectedMaterial.Poission_Ratio);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialLiquidDensity.DisplayOnly = true;
            SingleValue_MaterialLiquidDensity.Title = "Liquid Density";
            SingleValue_MaterialLiquidDensity.UnitType = UnitType.Density;
            SingleValue_MaterialLiquidDensity.SetNull();
            try
            {
                SingleValue_MaterialLiquidDensity.SetTheValue(selectedMaterial.Liquid_Density);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialMohsHardness.DisplayOnly = true;
            SingleValue_MaterialMohsHardness.Title = "Mohs Hardness";
            SingleValue_MaterialMohsHardness.UnitType = UnitType.Density;
            SingleValue_MaterialMohsHardness.SetNull();
            try
            {
                SingleValue_MaterialMohsHardness.SetTheValue(selectedMaterial.Mohs_Hardness);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialBrinellHardness.DisplayOnly = true;
            SingleValue_MaterialBrinellHardness.Title = "Brinell Hardness";
            SingleValue_MaterialBrinellHardness.UnitType = UnitType.Pressure;
            SingleValue_MaterialBrinellHardness.SetNull();
            try
            {
                SingleValue_MaterialBrinellHardness.SetTheValue(selectedMaterial.Brinell_Hardness);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialVickersHardness.DisplayOnly = true;
            SingleValue_MaterialVickersHardness.Title = "Vickers Hardness";
            SingleValue_MaterialVickersHardness.UnitType = UnitType.Pressure;
            SingleValue_MaterialVickersHardness.SetNull();
            try
            {
                SingleValue_MaterialVickersHardness.SetTheValue(selectedMaterial.Vickers_Hardness);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialThermalExpansion.DisplayOnly = true;
            SingleValue_MaterialThermalExpansion.Title = "Thermal Expansions";
            SingleValue_MaterialThermalExpansion.UnitType = UnitType.Unitless;
            SingleValue_MaterialThermalExpansion.SetNull();
            try
            {
                SingleValue_MaterialThermalExpansion.SetTheValue(selectedMaterial.Thermal_Expansion);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialThermalConductivity.DisplayOnly = true;
            SingleValue_MaterialThermalConductivity.Title = "Thermal Conductivity";
            SingleValue_MaterialThermalConductivity.UnitType = UnitType.Unitless;
            SingleValue_MaterialThermalConductivity.SetNull();
            try
            {
                SingleValue_MaterialThermalConductivity.SetTheValue(selectedMaterial.Thermal_Conductivity);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialSoundSpeed.DisplayOnly = true;
            SingleValue_MaterialSoundSpeed.Title = "SoundSpeed";
            SingleValue_MaterialSoundSpeed.UnitType = UnitType.Speed;
            SingleValue_MaterialSoundSpeed.SetNull();
            try
            {
                SingleValue_MaterialSoundSpeed.SetTheValue(selectedMaterial.Sound_Speed);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialMolarVolume.DisplayOnly = true;
            SingleValue_MaterialMolarVolume.Title = "MolarVolume";
            SingleValue_MaterialMolarVolume.UnitType = UnitType.Unitless;
            SingleValue_MaterialMolarVolume.SetNull();
            try
            {
                SingleValue_MaterialMolarVolume.SetTheValue(selectedMaterial.Molar_Volume);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            SingleValue_MaterialMolarVolume.DisplayOnly = true;
            SingleValue_MaterialMolarVolume.Title = "MolarVolume";
            SingleValue_MaterialMolarVolume.UnitType = UnitType.Temperature;
            SingleValue_MaterialMolarVolume.SetNull();
            try
            {
                SingleValue_MaterialMolarVolume.SetTheValue(selectedMaterial.Molar_Volume);
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }

            // Thermo
            SingleValue_MaterialAbsoluteBoilingPoint.DisplayOnly = true;
            SingleValue_MaterialAbsoluteBoilingPoint.Title = "Absolute Boiling Point";
            SingleValue_MaterialAbsoluteBoilingPoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialAbsoluteBoilingPoint.SetNull();
            SingleValue_MaterialAbsoluteBoilingPoint.SetTheValue(selectedMaterial.Absolute_Boiling_Point);

            SingleValue_MaterialAbsoluteMeltingPoint.DisplayOnly = true;
            SingleValue_MaterialAbsoluteMeltingPoint.Title = "Absolute Melting Point";
            SingleValue_MaterialAbsoluteMeltingPoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialAbsoluteMeltingPoint.SetNull();
            SingleValue_MaterialAbsoluteMeltingPoint.SetTheValue(selectedMaterial.Absolute_Melting_Point);

            SingleValue_MaterialAdiabaticIndex.DisplayOnly = true;
            SingleValue_MaterialAdiabaticIndex.Title = "Adiabatic Index";
            SingleValue_MaterialAdiabaticIndex.UnitType = UnitType.Unitless;
            SingleValue_MaterialAdiabaticIndex.SetNull();
            SingleValue_MaterialAdiabaticIndex.SetTheValue(selectedMaterial.Adiabatic_Index);

            SingleValue_MaterialBoilingPoint.DisplayOnly = true;
            SingleValue_MaterialBoilingPoint.Title = "Boiling Point";
            SingleValue_MaterialBoilingPoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialBoilingPoint.SetNull();
            SingleValue_MaterialBoilingPoint.SetTheValue(selectedMaterial.Boiling_Point);

            SingleValue_MaterialCriticalPressure.DisplayOnly = true;
            SingleValue_MaterialCriticalPressure.Title = "Critical Pressure";
            SingleValue_MaterialCriticalPressure.UnitType = UnitType.Pressure;
            SingleValue_MaterialCriticalPressure.SetNull();
            SingleValue_MaterialCriticalPressure.SetTheValue(selectedMaterial.Critical_Pressure);

            SingleValue_MaterialCriticalTemperature.DisplayOnly = true;
            SingleValue_MaterialCriticalTemperature.Title = "Critical Temperature";
            SingleValue_MaterialCriticalTemperature.UnitType = UnitType.Temperature;
            SingleValue_MaterialCriticalTemperature.SetNull();
            SingleValue_MaterialCriticalTemperature.SetTheValue(selectedMaterial.Critical_Temperature);

            SingleValue_MaterialCuriePoint.DisplayOnly = true;
            SingleValue_MaterialCuriePoint.Title = "Curie Point";
            SingleValue_MaterialCuriePoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialCuriePoint.SetNull();
            SingleValue_MaterialCuriePoint.SetTheValue(selectedMaterial.Curie_Point);

            SingleValue_MaterialFusionHeat.DisplayOnly = true;
            SingleValue_MaterialFusionHeat.Title = "Fusion Heat";
            SingleValue_MaterialFusionHeat.UnitType = UnitType.Unitless;
            SingleValue_MaterialFusionHeat.SetNull();
            SingleValue_MaterialFusionHeat.SetTheValue(selectedMaterial.Fusion_Heat);

            SingleValue_MaterialMeltingPoint.DisplayOnly = true;
            SingleValue_MaterialMeltingPoint.Title = "Melting Point";
            SingleValue_MaterialMeltingPoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialMeltingPoint.SetNull();
            SingleValue_MaterialMeltingPoint.SetTheValue(selectedMaterial.Melting_Point);

            SingleValue_MaterialNeelPoint.DisplayOnly = true;
            SingleValue_MaterialNeelPoint.Title = "Neel Point";
            SingleValue_MaterialNeelPoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialNeelPoint.SetNull();
            SingleValue_MaterialNeelPoint.SetTheValue(selectedMaterial.Neel_Point);

            SingleValue_MaterialSpecificHeat.DisplayOnly = true;
            SingleValue_MaterialSpecificHeat.Title = "Specific Heat";
            SingleValue_MaterialSpecificHeat.UnitType = UnitType.Unitless;
            SingleValue_MaterialSpecificHeat.SetNull();
            SingleValue_MaterialSpecificHeat.SetTheValue(selectedMaterial.Specific_Heat);

            SingleValue_MaterialSuperconductingPoint.DisplayOnly = true;
            SingleValue_MaterialSuperconductingPoint.Title = "Superconducting Point";
            SingleValue_MaterialSuperconductingPoint.UnitType = UnitType.Temperature;
            SingleValue_MaterialSuperconductingPoint.SetNull();
            SingleValue_MaterialSuperconductingPoint.SetTheValue(selectedMaterial.Superconducting_Point);

            SingleValue_MaterialVaporizationHeat.DisplayOnly = true;
            SingleValue_MaterialVaporizationHeat.Title = "Vaporization Heat";
            SingleValue_MaterialVaporizationHeat.UnitType = UnitType.Unitless;
            SingleValue_MaterialVaporizationHeat.SetNull();
            SingleValue_MaterialVaporizationHeat.SetTheValue(selectedMaterial.Vaporization_Heat);

            // Electro
            SingleValue_MaterialElectricalConductivity.DisplayOnly = true;
            SingleValue_MaterialElectricalConductivity.Title = "Electrical Conductivity";
            SingleValue_MaterialElectricalConductivity.UnitType = UnitType.Unitless;
            SingleValue_MaterialElectricalConductivity.SetNull();
            SingleValue_MaterialElectricalConductivity.SetTheValue(selectedMaterial.Electrical_Conductivity);

            SingleValue_MaterialMassMagneticSusceptibility.DisplayOnly = true;
            SingleValue_MaterialMassMagneticSusceptibility.Title = "Mass Magnetic Susceptibility";
            SingleValue_MaterialMassMagneticSusceptibility.UnitType = UnitType.Unitless;
            SingleValue_MaterialMassMagneticSusceptibility.SetNull();
            SingleValue_MaterialMassMagneticSusceptibility.SetTheValue(selectedMaterial.Mass_Magnetic_Susceptibility);

            SingleValue_MaterialMolarMagneticSusceptibility.DisplayOnly = true;
            SingleValue_MaterialMolarMagneticSusceptibility.Title = "Molar Magnetic Susceptibility";
            SingleValue_MaterialMolarMagneticSusceptibility.UnitType = UnitType.Unitless;
            SingleValue_MaterialMolarMagneticSusceptibility.SetNull();
            SingleValue_MaterialMolarMagneticSusceptibility.SetTheValue(selectedMaterial.Molar_Magnetic_Susceptibility);

            SingleValue_MaterialResistivity.DisplayOnly = true;
            SingleValue_MaterialResistivity.Title = "Resistivity";
            SingleValue_MaterialResistivity.UnitType = UnitType.Temperature;
            SingleValue_MaterialResistivity.SetNull();
            SingleValue_MaterialResistivity.SetTheValue(Convert.ToDecimal(selectedMaterial.Resistivity.ToString()));

            SingleValue_MaterialVolumeMagneticSusceptibility.DisplayOnly = true;
            SingleValue_MaterialVolumeMagneticSusceptibility.Title = "Volume Magnetic Susceptibility";
            SingleValue_MaterialVolumeMagneticSusceptibility.UnitType = UnitType.Unitless;
            SingleValue_MaterialVolumeMagneticSusceptibility.SetNull();
            SingleValue_MaterialVolumeMagneticSusceptibility.SetTheValue(Convert.ToDecimal(selectedMaterial.Molar_Volume.ToString()));

            // Abundance
            SingleValue_MaterialCrustAbundance.DisplayOnly = true;
            SingleValue_MaterialCrustAbundance.Title = "Crust";
            SingleValue_MaterialCrustAbundance.UnitType = UnitType.Percentage;
            SingleValue_MaterialCrustAbundance.SetNull();
            SingleValue_MaterialCrustAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Crust_Abundance.ToString()));

            SingleValue_MaterialHumanAbundance.DisplayOnly = true;
            SingleValue_MaterialHumanAbundance.Title = "Human";
            SingleValue_MaterialHumanAbundance.UnitType = UnitType.Percentage;
            SingleValue_MaterialHumanAbundance.SetNull();
            SingleValue_MaterialHumanAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Human_Abundance.ToString()));

            SingleValue_MaterialMeteoriteAbundance.DisplayOnly = true;
            SingleValue_MaterialMeteoriteAbundance.Title = "Meteorite";
            SingleValue_MaterialMeteoriteAbundance.UnitType = UnitType.Percentage;
            SingleValue_MaterialMeteoriteAbundance.SetNull();
            SingleValue_MaterialMeteoriteAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Meteorite_Abundance.ToString()));

            SingleValue_MaterialOceanAbundance.DisplayOnly = true;
            SingleValue_MaterialOceanAbundance.Title = "Ocean";
            SingleValue_MaterialOceanAbundance.UnitType = UnitType.Percentage;
            SingleValue_MaterialOceanAbundance.SetNull();
            SingleValue_MaterialOceanAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Ocean_Abundance.ToString()));

            SingleValue_MaterialSolarAbundance.DisplayOnly = true;
            SingleValue_MaterialSolarAbundance.Title = "Solar";
            SingleValue_MaterialSolarAbundance.UnitType = UnitType.Percentage;
            SingleValue_MaterialSolarAbundance.SetNull();
            SingleValue_MaterialSolarAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Solar_Abundance.ToString()));

            SingleValue_MaterialUniverseAbundance.DisplayOnly = true;
            SingleValue_MaterialUniverseAbundance.Title = "Universe";
            SingleValue_MaterialUniverseAbundance.UnitType = UnitType.Percentage;
            SingleValue_MaterialUniverseAbundance.SetNull();
            SingleValue_MaterialUniverseAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Universe_Abundance.ToString()));
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
            SingleValue_Property1.Visibility = Visibility.Collapsed;
            SingleValue_Property2.Visibility = Visibility.Collapsed;
            SingleValue_Property3.Visibility = Visibility.Collapsed;
            SingleValue_Property4.Visibility = Visibility.Collapsed;
            SingleValue_Property5.Visibility = Visibility.Collapsed;
            SingleValue_Property1.SetNull();
            SingleValue_Property2.SetNull();
            SingleValue_Property3.SetNull();
            SingleValue_Property4.SetNull();
            SingleValue_Property5.SetNull();

            SingleValue_CalculatedArea.SetNull();
            SingleValue_CalculatedMoment.SetNull();

            SingleValue_RadiusOfGyration.Title = "Radius of Gyration";
            SingleValue_RadiusOfGyration.UnitType = UnitType.Length;
            SingleValue_RadiusOfGyration.SetNull();

            SingleValue_SectionModulus.Title = "Section Modulus";
            SingleValue_SectionModulus.UnitType = UnitType.Volume;
            SingleValue_SectionModulus.SetNull();

            TextBlock_Profile_Title.Text = "MATERIAL : " + selectedProfile.Name;
            if (selectedProfile.ImagePath != null)
            {
                image_Profile.Source = new BitmapImage(new Uri(selectedProfile.ImagePath));
            }

            if (selectedProfile.Name == Model.Sections.CurrentSection.SectionProfile)
            {
                switch (selectedProfile.Name)
                {
                    case "I Beam":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        SingleValue_Property3.Title = "Width (w)";
                        SingleValue_Property3.Visibility = Visibility.Visible;
                        SingleValue_Property3.SetNull();

                        decimal breadth = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal height = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal width = Model.Sections.CurrentSection.SectionProfileProperty3;
                        decimal outerArea = breadth * height;
                        decimal innerBreadth = breadth - width;
                        decimal innerHeight = height - width - width;
                        decimal innerArea = innerBreadth * innerHeight;
                        decimal area = outerArea - innerArea;

                        if (area == Model.Sections.CurrentSection.Area)
                        {
                            SingleValue_Property1.SetTheValue(breadth);
                            SingleValue_Property2.SetTheValue(height);
                            SingleValue_Property3.SetTheValue(width);
                            SingleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                SingleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (height / 2));
                            }
                        }

                        break;

                    case "Solid Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;

                        if ((decimal)Math.PI * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 == Model.Sections.CurrentSection.Area)
                        {
                            SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            SingleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);
                            SingleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.SectionProfileProperty1);
                            }
                        }

                        break;
                    case "Solid Elipse":
                        // SingleValue_Property1.Title = "Length x-axis (a)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Length y-axis (b)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Solid Rectangle":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();

                        if (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 == Model.Sections.CurrentSection.Area)
                        {
                            SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                            SingleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                SingleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
                            }
                        }

                        break;
                    case "Solid Triangle":
                        // SingleValue_Property1.Title = "Base (b)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Height (h)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
                        break;

                    case "Hollow Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property2.Title = "Width (w)";
                        SingleValue_Property2.Visibility = Visibility.Visible;

                        if (((decimal)Math.PI * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1) - ((decimal)Math.PI * (Model.Sections.CurrentSection.SectionProfileProperty1 - Model.Sections.CurrentSection.SectionProfileProperty2) * (Model.Sections.CurrentSection.SectionProfileProperty1 - Model.Sections.CurrentSection.SectionProfileProperty2)) == Model.Sections.CurrentSection.Area)
                        {
                            SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                            SingleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                SingleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.SectionProfileProperty1);
                            }
                        }

                        break;
                    case "Hollow Elipse":
                        // SingleValue_Property1.Title = "Radius (a)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Radius (b)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
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
                        if ((Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2) - ((Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2)) * (Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2))) == Model.Sections.CurrentSection.Area)
                        {
                            SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                            SingleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                            SingleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                SingleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.SectionProfileProperty1);
                            }
                        }

                        break;
                    case "Hollow Triangle":
                        // SingleValue_Property1.Title = "Width (b)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Height (h)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
                        break;
                }
            }
            else
            {
                switch (selectedProfile.Name)
                {
                    case "Solid Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;

                        break;
                    case "Solid Elipse":
                        // SingleValue_Property1.Title = "Length x-axis (a)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Length y-axis (b)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Solid Rectangle":
                        SingleValue_Property1.Title = "Breadth (b)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property1.SetNull();
                        SingleValue_Property2.Title = "Height (h)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        SingleValue_Property2.SetNull();
                        break;
                    case "Solid Triangle":
                        // SingleValue_Property1.Title = "Base (b)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Height (h)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Hollow Circle":
                        SingleValue_Property1.Title = "Radius (r)";
                        SingleValue_Property1.Visibility = Visibility.Visible;
                        SingleValue_Property2.Title = "Width (w)";
                        SingleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Hollow Elipse":
                        // SingleValue_Property1.Title = "Radius (a)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Radius (b)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
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
                    case "Hollow Triangle":
                        // SingleValue_Property1.Title = "Width (b)";
                        // SingleValue_Property1.Visibility = Visibility.Visible;
                        // SingleValue_Property2.Title = "Height (h)";
                        // SingleValue_Property2.Visibility = Visibility.Visible;
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
        }

        private void ListView_Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SectionProfile selectedProfile = (SectionProfile)ListView_Profile.SelectedItem;
            Model.Sections.CurrentSection.SectionProfile = selectedProfile.Name;
            UpdateProfile(selectedProfile);
        }

        private void CheckForProfileAnswer()
        {
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

                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal outerMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                        decimal innerMoment = innerBreadth * innerHeight * innerHeight * innerHeight / 12;
                        decimal secondMoment = outerMoment - innerMoment;
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (height / 2));

                        switch (Options.Units.Length)
                        {
                            case LengthType.Meter:
                                SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                break;
                            case LengthType.Millimeter:
                                SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                break;
                            case LengthType.CentiMeter:
                                SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                break;
                            case LengthType.KiloMeter:
                                SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                break;
                            case LengthType.Inch:
                                SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                break;
                            case LengthType.Foot:
                                SingleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                SingleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                break;
                        }
                    }

                    break;

                case "Solid Circle":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal area = DMath.PI * radius * radius;
                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal secondMoment = DMath.PI / 4 * radius * radius * radius * radius;
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / radius);
                    }

                    break;

                case "Hollow Circle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty3 > 0))
                    {
                        decimal radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal width = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal innerRadius = radius - width;
                        decimal outerArea = DMath.PI * radius * radius;
                        decimal innerArea = DMath.PI * innerRadius * innerRadius;
                        decimal area = outerArea - innerArea;
                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal secondMoment = (DMath.PI / 4 * radius * radius * radius * radius) - (DMath.PI / 4 * innerRadius * innerRadius * innerRadius * innerRadius);
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / radius);
                    }

                    break;

                case "Solid Elipse":

                    break;
                case "Solid Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal area = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal secondMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
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
                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal outerMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                        decimal innerMoment = innerBreadth * innerHeight * innerHeight * innerHeight / 12;
                        decimal secondMoment = outerMoment - innerMoment;
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
                    }

                    break;

                case "Solid Square":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal area = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1;
                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal secondMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 / 12;
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty1 / 2));
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
                        SingleValue_CalculatedArea.SetTheValue(area);
                        SingleValue_Area.SetTheValue(area);
                        Model.Sections.CurrentSection.Area = area;
                        decimal outerMoment = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 / 12;
                        decimal innerMoment = innerBreadth * innerHeight * innerHeight * innerHeight / 12;
                        decimal secondMoment = outerMoment - innerMoment;
                        SingleValue_CalculatedMoment.SetTheValue(secondMoment);
                        SingleValue_MomentOfInertia.SetTheValue(secondMoment);
                        Model.Sections.CurrentSection.I = secondMoment;
                        SingleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        SingleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
                    }

                    break;

                case "Solid Triangle":

                    break;

                case "Hollow Elipse":

                    break;

                case "Hollow Triangle":

                    break;
            }
        }

        private void SingleValue_Property1_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty1 = SingleValue_Property1.NewValue;
            SingleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
            CheckForProfileAnswer();
        }

        private void SingleValue_Property2_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty2 = SingleValue_Property2.NewValue;
            SingleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
            CheckForProfileAnswer();
        }

        private void SingleValue_Property3_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty3 = SingleValue_Property3.NewValue;
            SingleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
            CheckForProfileAnswer();
        }

        private void SingleValue_Property4_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty4 = SingleValue_Property4.NewValue;
            SingleValue_Property4.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty4);
            CheckForProfileAnswer();
        }

        private void SingleValue_Property5_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty5 = SingleValue_Property5.NewValue;
            SingleValue_Property5.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty5);
            CheckForProfileAnswer();
        }

        private void SingleValue_Property6_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty6 = SingleValue_Property6.NewValue;
            SingleValue_Property6.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty6);
            CheckForProfileAnswer();
        }

        private void SingleValue_Property7_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty7 = SingleValue_Property7.NewValue;
            SingleValue_Property7.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty7);
            CheckForProfileAnswer();
        }

        #endregion

        #region Section Properties

        private void SingleValue_YoungsModulus_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.E = SingleValue_YoungsModulus.NewValue;
            SingleValue_YoungsModulus.SetTheValue(Model.Sections.CurrentSection.E);
        }

        private void SingleValue_MomentOfInertia_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.I = SingleValue_MomentOfInertia.NewValue;
            SingleValue_MomentOfInertia.SetTheValue(Model.Sections.CurrentSection.I);
        }

        private void SingleValue_Area_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.Area = SingleValue_Area.NewValue;
            SingleValue_Area.SetTheValue(Model.Sections.CurrentSection.Area);
        }

        private void SingleValue_Density_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.Density = SingleValue_Density.NewValue;
            SingleValue_Density.SetTheValue(Model.Sections.CurrentSection.Density);
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