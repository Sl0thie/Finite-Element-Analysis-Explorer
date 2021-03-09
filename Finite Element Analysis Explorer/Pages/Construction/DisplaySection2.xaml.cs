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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class DisplaySection2 : Page
    {
        //private string lastMaterialName = "";
        //private string lastProfileSection = "";

        public DisplaySection2()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Set item sources.
            listView_Materials.ItemsSource = Model.Materials.Values;
            listView_Profile.ItemsSource = Model.SectionProfiles.Values;

            //Setup form.
            singleValue_CalculatedArea.UnitType = UnitType.Area;
            singleValue_CalculatedArea.SetNull();
            singleValue_CalculatedArea.DisplayOnly = true;
            singleValue_CalculatedArea.Title = "Area";
            singleValue_CalculatedMoment.UnitType = UnitType.MomentOfInertia;
            singleValue_CalculatedMoment.SetNull();
            singleValue_CalculatedMoment.DisplayOnly = true;
            singleValue_CalculatedMoment.Title = "Moment of Inertia";

            singleValue_Property1.UnitType = UnitType.Length;
            singleValue_Property2.UnitType = UnitType.Length;
            singleValue_Property3.UnitType = UnitType.Length;
            singleValue_Property4.UnitType = UnitType.Length;
            singleValue_Property5.UnitType = UnitType.Length;
            singleValue_Property6.UnitType = UnitType.Length;
            singleValue_Property7.UnitType = UnitType.Length;
            singleValue_Property1.Visibility = Visibility.Collapsed;
            singleValue_Property2.Visibility = Visibility.Collapsed;
            singleValue_Property3.Visibility = Visibility.Collapsed;
            singleValue_Property4.Visibility = Visibility.Collapsed;
            singleValue_Property5.Visibility = Visibility.Collapsed;
            singleValue_Property6.Visibility = Visibility.Collapsed;
            singleValue_Property7.Visibility = Visibility.Collapsed;

            if (!object.ReferenceEquals(null, Model.Sections.CurrentSection))
            {
                #region Setup Section Panel

                textBlock_Section_Title.Text = "SECTION : " + Model.Sections.CurrentSection.Name;

                singleValue_YoungsModulus.Title = "Elastic Modulus";
                singleValue_YoungsModulus.UnitType = UnitType.Pressure;
                singleValue_YoungsModulus.SetTheValue(Model.Sections.CurrentSection.E);

                singleValue_MomentOfInertia.Title = "2nd Moment of Area";
                singleValue_MomentOfInertia.UnitType = UnitType.MomentOfInertia;
                singleValue_MomentOfInertia.SetTheValue(Model.Sections.CurrentSection.I);

                singleValue_Area.Title = "Sectional Area";
                singleValue_Area.UnitType = UnitType.Area;
                singleValue_Area.SetTheValue(Model.Sections.CurrentSection.Area);

                singleValue_Density.Title = "Density";
                singleValue_Density.UnitType = UnitType.Area;
                singleValue_Density.SetTheValue(Model.Sections.CurrentSection.Density);

                singleValue_MaintenanceNodeFree.Title = "Free Node";
                singleValue_MaintenanceNodeFree.UnitType = UnitType.Money;
                singleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);

                singleValue_MaintenanceFixed.Title = "Fixed Node";
                singleValue_MaintenanceFixed.UnitType = UnitType.Money;
                singleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);

                singleValue_MaintenancePinned.Title = "Free Node";
                singleValue_MaintenancePinned.UnitType = UnitType.Money;
                singleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);

                singleValue_MaintenanceRoller.Title = "Roller Node";
                singleValue_MaintenanceRoller.UnitType = UnitType.Money;
                singleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);

                singleValue_MaintenanceTrack.Title = "Track Node";
                singleValue_MaintenanceTrack.UnitType = UnitType.Money;
                singleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);

                singleValue_MaintenancePerLength.Title = "Per Length";
                singleValue_MaintenancePerLength.UnitType = UnitType.Money;
                singleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);


                singleValue_CostPerLength.Title = "Cost per Length";
                singleValue_CostPerLength.UnitType = UnitType.Money;
                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength);

                singleValue_CostVerticalTransport.Title = "Vertical Transport";
                singleValue_CostVerticalTransport.UnitType = UnitType.Money;
                singleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);

                singleValue_CostHorizontalTransport.Title = "Horizontal";
                singleValue_CostHorizontalTransport.UnitType = UnitType.Money;
                singleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);

                singleValue_CostNodeFree.Title = "Free Node";
                singleValue_CostNodeFree.UnitType = UnitType.Money;
                singleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);

                singleValue_CostNodeFixed.Title = "Fixed Node";
                singleValue_CostNodeFixed.UnitType = UnitType.Money;
                singleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodeFixed);

                singleValue_CostNodePinned.Title = "Pinned Node";
                singleValue_CostNodePinned.UnitType = UnitType.Money;
                singleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);

                singleValue_CostNodeRoller.Title = "Roller Node";
                singleValue_CostNodeRoller.UnitType = UnitType.Money;
                singleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);

                singleValue_CostNodeTrack.Title = "Track Node";
                singleValue_CostNodeTrack.UnitType = UnitType.Money;
                singleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);

                singleValue_FactorVerticalTransport.Title = "Vertical Factor";
                singleValue_FactorVerticalTransport.UnitType = UnitType.Percentage;
                singleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);

                singleValue_FactorHorizontalTransport.Title = "Horizontal Factor";
                singleValue_FactorHorizontalTransport.UnitType = UnitType.Percentage;
                singleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);


                #endregion


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

            singleValue_MaterialDensity.SetNull();
            singleValue_MaterialYoungsModulus.SetNull();
            singleValue_MaterialShearModulus.SetNull();
            singleValue_MaterialBulkModulus.SetNull();
            singleValue_MaterialPoissonRatio.SetNull();
            singleValue_MaterialLiquidDensity.SetNull();
            singleValue_MaterialMohsHardness.SetNull();
            singleValue_MaterialBrinellHardness.SetNull();
            singleValue_MaterialVickersHardness.SetNull();
            singleValue_MaterialThermalExpansion.SetNull();
            singleValue_MaterialThermalConductivity.SetNull();
            singleValue_MaterialSoundSpeed.SetNull();
            singleValue_MaterialMolarVolume.SetNull();
            singleValue_MaterialAbsoluteBoilingPoint.SetNull();

            textBlock_Material_Title.Text = "Material : " + selectedMaterial.Name;


            if (Model.Sections.CurrentSection.Material == selectedMaterial.Name)
            {

            }
            else
            {
                //Set Properties to the Section.
                Model.Sections.CurrentSection.Material = selectedMaterial.Name;
                singleValue_YoungsModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
                Model.Sections.CurrentSection.E = selectedMaterial.ModulusOfElasticity;

                //Debug.WriteLine("E " + selectedMaterial.ModulusOfElasticity + " " + singleValue_YoungsModulus.NewValue);

                singleValue_YoungsModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
                singleValue_Density.SetTheValue(selectedMaterial.Density);
                Model.Sections.CurrentSection.Density = selectedMaterial.Density;


                //Update Material Cost.

                //singleValue_CostPerLength.SetTheValue(selectedMaterial.Cost * );

            }


            ////Material
            singleValue_MaterialDensity.DisplayOnly = true;
            singleValue_MaterialDensity.Title = "Density";
            singleValue_MaterialDensity.UnitType = UnitType.Density;
            singleValue_MaterialDensity.SetNull();
            singleValue_MaterialDensity.SetTheValue(selectedMaterial.Density);

            singleValue_MaterialYoungsModulus.DisplayOnly = true;
            singleValue_MaterialYoungsModulus.Title = "Elastic Modulus";
            singleValue_MaterialYoungsModulus.UnitType = UnitType.Pressure;
            singleValue_MaterialYoungsModulus.SetNull();
            try
            {
                singleValue_MaterialYoungsModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
            }
            catch { }

            singleValue_MaterialShearModulus.DisplayOnly = true;
            singleValue_MaterialShearModulus.Title = "Rigidity Modulus";
            singleValue_MaterialShearModulus.UnitType = UnitType.Pressure;
            singleValue_MaterialShearModulus.SetNull();
            try
            {
                singleValue_MaterialShearModulus.SetTheValue(selectedMaterial.ModulusOfRigidity);
            }
            catch { }

            singleValue_MaterialBulkModulus.DisplayOnly = true;
            singleValue_MaterialBulkModulus.Title = "Bulk Modulus";
            singleValue_MaterialBulkModulus.UnitType = UnitType.Pressure;
            singleValue_MaterialBulkModulus.SetNull();
            try
            {
                singleValue_MaterialBulkModulus.SetTheValue(selectedMaterial.Bulk_Modulus);
            }
            catch { }

            singleValue_MaterialPoissonRatio.DisplayOnly = true;
            singleValue_MaterialPoissonRatio.Title = "Poisson Ratio";
            singleValue_MaterialPoissonRatio.UnitType = UnitType.Unitless;
            singleValue_MaterialPoissonRatio.SetNull();
            try
            {
                singleValue_MaterialPoissonRatio.SetTheValue(selectedMaterial.Poission_Ratio);
            }
            catch { }

            singleValue_MaterialLiquidDensity.DisplayOnly = true;
            singleValue_MaterialLiquidDensity.Title = "Liquid Density";
            singleValue_MaterialLiquidDensity.UnitType = UnitType.Density;
            singleValue_MaterialLiquidDensity.SetNull();
            try
            {
                singleValue_MaterialLiquidDensity.SetTheValue(selectedMaterial.Liquid_Density);
            }
            catch { }

            singleValue_MaterialMohsHardness.DisplayOnly = true;
            singleValue_MaterialMohsHardness.Title = "Mohs Hardness";
            singleValue_MaterialMohsHardness.UnitType = UnitType.Density;
            singleValue_MaterialMohsHardness.SetNull();
            try
            {
                singleValue_MaterialMohsHardness.SetTheValue(selectedMaterial.Mohs_Hardness);
            }
            catch { }

            singleValue_MaterialBrinellHardness.DisplayOnly = true;
            singleValue_MaterialBrinellHardness.Title = "Brinell Hardness";
            singleValue_MaterialBrinellHardness.UnitType = UnitType.Pressure;
            singleValue_MaterialBrinellHardness.SetNull();
            try
            {
                singleValue_MaterialBrinellHardness.SetTheValue(selectedMaterial.Brinell_Hardness);
            }
            catch { }

            singleValue_MaterialVickersHardness.DisplayOnly = true;
            singleValue_MaterialVickersHardness.Title = "Vickers Hardness";
            singleValue_MaterialVickersHardness.UnitType = UnitType.Pressure;
            singleValue_MaterialVickersHardness.SetNull();
            try
            {
                singleValue_MaterialVickersHardness.SetTheValue(selectedMaterial.Vickers_Hardness);
            }
            catch { }

            singleValue_MaterialThermalExpansion.DisplayOnly = true;
            singleValue_MaterialThermalExpansion.Title = "Thermal Expansions";
            singleValue_MaterialThermalExpansion.UnitType = UnitType.Unitless;
            singleValue_MaterialThermalExpansion.SetNull();
            try
            {
                singleValue_MaterialThermalExpansion.SetTheValue(selectedMaterial.Thermal_Expansion);
            }
            catch { }

            singleValue_MaterialThermalConductivity.DisplayOnly = true;
            singleValue_MaterialThermalConductivity.Title = "Thermal Conductivity";
            singleValue_MaterialThermalConductivity.UnitType = UnitType.Unitless;
            singleValue_MaterialThermalConductivity.SetNull();
            try
            {
                singleValue_MaterialThermalConductivity.SetTheValue(selectedMaterial.Thermal_Conductivity);
            }
            catch { }

            singleValue_MaterialSoundSpeed.DisplayOnly = true;
            singleValue_MaterialSoundSpeed.Title = "SoundSpeed";
            singleValue_MaterialSoundSpeed.UnitType = UnitType.Speed;
            singleValue_MaterialSoundSpeed.SetNull();
            try
            {
                singleValue_MaterialSoundSpeed.SetTheValue(selectedMaterial.Sound_Speed);
            }
            catch { }

            singleValue_MaterialMolarVolume.DisplayOnly = true;
            singleValue_MaterialMolarVolume.Title = "MolarVolume";
            singleValue_MaterialMolarVolume.UnitType = UnitType.Unitless;
            singleValue_MaterialMolarVolume.SetNull();
            try
            {
                singleValue_MaterialMolarVolume.SetTheValue(selectedMaterial.Molar_Volume);
            }
            catch { }

            singleValue_MaterialMolarVolume.DisplayOnly = true;
            singleValue_MaterialMolarVolume.Title = "MolarVolume";
            singleValue_MaterialMolarVolume.UnitType = UnitType.Temprature;
            singleValue_MaterialMolarVolume.SetNull();
            try
            {
                singleValue_MaterialMolarVolume.SetTheValue(selectedMaterial.Molar_Volume);
            }
            catch { }

            //Thermo
            singleValue_MaterialAbsoluteBoilingPoint.DisplayOnly = true;
            singleValue_MaterialAbsoluteBoilingPoint.Title = "Absolute Boiling Point";
            singleValue_MaterialAbsoluteBoilingPoint.UnitType = UnitType.Temprature;
            singleValue_MaterialAbsoluteBoilingPoint.SetNull();
            singleValue_MaterialAbsoluteBoilingPoint.SetTheValue(selectedMaterial.Absolute_Boiling_Point);

            singleValue_MaterialAbsoluteMeltingPoint.DisplayOnly = true;
            singleValue_MaterialAbsoluteMeltingPoint.Title = "Absolute Melting Point";
            singleValue_MaterialAbsoluteMeltingPoint.UnitType = UnitType.Temprature;
            singleValue_MaterialAbsoluteMeltingPoint.SetNull();
            singleValue_MaterialAbsoluteMeltingPoint.SetTheValue(selectedMaterial.Absolute_Melting_Point);

            singleValue_MaterialAdiabaticIndex.DisplayOnly = true;
            singleValue_MaterialAdiabaticIndex.Title = "Adiabatic Index";
            singleValue_MaterialAdiabaticIndex.UnitType = UnitType.Unitless;
            singleValue_MaterialAdiabaticIndex.SetNull();
            singleValue_MaterialAdiabaticIndex.SetTheValue(selectedMaterial.Adiabatic_Index);

            singleValue_MaterialBoilingPoint.DisplayOnly = true;
            singleValue_MaterialBoilingPoint.Title = "Boiling Point";
            singleValue_MaterialBoilingPoint.UnitType = UnitType.Temprature;
            singleValue_MaterialBoilingPoint.SetNull();
            singleValue_MaterialBoilingPoint.SetTheValue(selectedMaterial.Boiling_Point);

            singleValue_MaterialCriticalPressure.DisplayOnly = true;
            singleValue_MaterialCriticalPressure.Title = "Critical Pressure";
            singleValue_MaterialCriticalPressure.UnitType = UnitType.Pressure;
            singleValue_MaterialCriticalPressure.SetNull();
            singleValue_MaterialCriticalPressure.SetTheValue(selectedMaterial.Critical_Pressure);

            singleValue_MaterialCriticalTemperature.DisplayOnly = true;
            singleValue_MaterialCriticalTemperature.Title = "Critical Temperature";
            singleValue_MaterialCriticalTemperature.UnitType = UnitType.Temprature;
            singleValue_MaterialCriticalTemperature.SetNull();
            singleValue_MaterialCriticalTemperature.SetTheValue(selectedMaterial.Critical_Temperature);

            singleValue_MaterialCuriePoint.DisplayOnly = true;
            singleValue_MaterialCuriePoint.Title = "Curie Point";
            singleValue_MaterialCuriePoint.UnitType = UnitType.Temprature;
            singleValue_MaterialCuriePoint.SetNull();
            singleValue_MaterialCuriePoint.SetTheValue(selectedMaterial.Curie_Point);

            singleValue_MaterialFusionHeat.DisplayOnly = true;
            singleValue_MaterialFusionHeat.Title = "Fusion Heat";
            singleValue_MaterialFusionHeat.UnitType = UnitType.Unitless;
            singleValue_MaterialFusionHeat.SetNull();
            singleValue_MaterialFusionHeat.SetTheValue(selectedMaterial.Fusion_Heat);

            singleValue_MaterialMeltingPoint.DisplayOnly = true;
            singleValue_MaterialMeltingPoint.Title = "Melting Point";
            singleValue_MaterialMeltingPoint.UnitType = UnitType.Temprature;
            singleValue_MaterialMeltingPoint.SetNull();
            singleValue_MaterialMeltingPoint.SetTheValue(selectedMaterial.Melting_Point);

            singleValue_MaterialNeelPoint.DisplayOnly = true;
            singleValue_MaterialNeelPoint.Title = "Neel Point";
            singleValue_MaterialNeelPoint.UnitType = UnitType.Temprature;
            singleValue_MaterialNeelPoint.SetNull();
            singleValue_MaterialNeelPoint.SetTheValue(selectedMaterial.Neel_Point);

            singleValue_MaterialSpecificHeat.DisplayOnly = true;
            singleValue_MaterialSpecificHeat.Title = "Specific Heat";
            singleValue_MaterialSpecificHeat.UnitType = UnitType.Unitless;
            singleValue_MaterialSpecificHeat.SetNull();
            singleValue_MaterialSpecificHeat.SetTheValue(selectedMaterial.Specific_Heat);

            singleValue_MaterialSuperconductingPoint.DisplayOnly = true;
            singleValue_MaterialSuperconductingPoint.Title = "Superconducting Point";
            singleValue_MaterialSuperconductingPoint.UnitType = UnitType.Temprature;
            singleValue_MaterialSuperconductingPoint.SetNull();
            singleValue_MaterialSuperconductingPoint.SetTheValue(selectedMaterial.Superconducting_Point);

            singleValue_MaterialVaporizationHeat.DisplayOnly = true;
            singleValue_MaterialVaporizationHeat.Title = "Vaporization Heat";
            singleValue_MaterialVaporizationHeat.UnitType = UnitType.Unitless;
            singleValue_MaterialVaporizationHeat.SetNull();
            singleValue_MaterialVaporizationHeat.SetTheValue(selectedMaterial.Vaporization_Heat);


            //Electro
            singleValue_MaterialElectricalConductivity.DisplayOnly = true;
            singleValue_MaterialElectricalConductivity.Title = "Electrical Conductivity";
            singleValue_MaterialElectricalConductivity.UnitType = UnitType.Unitless;
            singleValue_MaterialElectricalConductivity.SetNull();
            singleValue_MaterialElectricalConductivity.SetTheValue(selectedMaterial.Electrical_Conductivity);

            singleValue_MaterialMassMagneticSusceptibility.DisplayOnly = true;
            singleValue_MaterialMassMagneticSusceptibility.Title = "Mass Magnetic Susceptibility";
            singleValue_MaterialMassMagneticSusceptibility.UnitType = UnitType.Unitless;
            singleValue_MaterialMassMagneticSusceptibility.SetNull();
            singleValue_MaterialMassMagneticSusceptibility.SetTheValue(selectedMaterial.Mass_Magnetic_Susceptibility);

            singleValue_MaterialMolarMagneticSusceptibility.DisplayOnly = true;
            singleValue_MaterialMolarMagneticSusceptibility.Title = "Molar Magnetic Susceptibility";
            singleValue_MaterialMolarMagneticSusceptibility.UnitType = UnitType.Unitless;
            singleValue_MaterialMolarMagneticSusceptibility.SetNull();
            singleValue_MaterialMolarMagneticSusceptibility.SetTheValue(selectedMaterial.Molar_Magnetic_Susceptibility);

            singleValue_MaterialResistivity.DisplayOnly = true;
            singleValue_MaterialResistivity.Title = "Resistivity";
            singleValue_MaterialResistivity.UnitType = UnitType.Temprature;
            singleValue_MaterialResistivity.SetNull();
            singleValue_MaterialResistivity.SetTheValue(Convert.ToDecimal(selectedMaterial.Resistivity.ToString()));

            singleValue_MaterialVolumeMagneticSusceptibility.DisplayOnly = true;
            singleValue_MaterialVolumeMagneticSusceptibility.Title = "Volume Magnetic Susceptibility";
            singleValue_MaterialVolumeMagneticSusceptibility.UnitType = UnitType.Unitless;
            singleValue_MaterialVolumeMagneticSusceptibility.SetNull();
            singleValue_MaterialVolumeMagneticSusceptibility.SetTheValue(Convert.ToDecimal(selectedMaterial.Molar_Volume.ToString()));


            //Abundance
            singleValue_MaterialCrustAbundance.DisplayOnly = true;
            singleValue_MaterialCrustAbundance.Title = "Crust";
            singleValue_MaterialCrustAbundance.UnitType = UnitType.Percentage;
            singleValue_MaterialCrustAbundance.SetNull();
            singleValue_MaterialCrustAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Crust_Abundance.ToString()));

            singleValue_MaterialHumanAbundance.DisplayOnly = true;
            singleValue_MaterialHumanAbundance.Title = "Human";
            singleValue_MaterialHumanAbundance.UnitType = UnitType.Percentage;
            singleValue_MaterialHumanAbundance.SetNull();
            singleValue_MaterialHumanAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Human_Abundance.ToString()));

            singleValue_MaterialMeteoriteAbundance.DisplayOnly = true;
            singleValue_MaterialMeteoriteAbundance.Title = "Meteorite";
            singleValue_MaterialMeteoriteAbundance.UnitType = UnitType.Percentage;
            singleValue_MaterialMeteoriteAbundance.SetNull();
            singleValue_MaterialMeteoriteAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Meteorite_Abundance.ToString()));

            singleValue_MaterialOceanAbundance.DisplayOnly = true;
            singleValue_MaterialOceanAbundance.Title = "Ocean";
            singleValue_MaterialOceanAbundance.UnitType = UnitType.Percentage;
            singleValue_MaterialOceanAbundance.SetNull();
            singleValue_MaterialOceanAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Ocean_Abundance.ToString()));

            singleValue_MaterialSolarAbundance.DisplayOnly = true;
            singleValue_MaterialSolarAbundance.Title = "Solar";
            singleValue_MaterialSolarAbundance.UnitType = UnitType.Percentage;
            singleValue_MaterialSolarAbundance.SetNull();
            singleValue_MaterialSolarAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Solar_Abundance.ToString()));

            singleValue_MaterialUniverseAbundance.DisplayOnly = true;
            singleValue_MaterialUniverseAbundance.Title = "Universe";
            singleValue_MaterialUniverseAbundance.UnitType = UnitType.Percentage;
            singleValue_MaterialUniverseAbundance.SetNull();
            singleValue_MaterialUniverseAbundance.SetTheValue(Convert.ToDecimal(selectedMaterial.Universe_Abundance.ToString()));






        }

        private void listView_Materials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Material selectedMaterial = (Material)listView_Materials.SelectedItem;
            UpdateMaterial(selectedMaterial);
        }

        #endregion

        #region Profile

        private void UpdateProfile(SectionProfile selectedProfile)
        {
            singleValue_Property1.Visibility = Visibility.Collapsed;
            singleValue_Property2.Visibility = Visibility.Collapsed;
            singleValue_Property3.Visibility = Visibility.Collapsed;
            singleValue_Property4.Visibility = Visibility.Collapsed;
            singleValue_Property5.Visibility = Visibility.Collapsed;
            singleValue_Property1.SetNull();
            singleValue_Property2.SetNull();
            singleValue_Property3.SetNull();
            singleValue_Property4.SetNull();
            singleValue_Property5.SetNull();

            singleValue_CalculatedArea.SetNull();
            singleValue_CalculatedMoment.SetNull();

            singleValue_RadiusOfGyration.Title = "Radius of Gyration";
            singleValue_RadiusOfGyration.UnitType = UnitType.Length;
            singleValue_RadiusOfGyration.SetNull();

            singleValue_SectionModulus.Title = "Section Modulus";
            singleValue_SectionModulus.UnitType = UnitType.Volume;
            singleValue_SectionModulus.SetNull();

            textBlock_Profile_Title.Text = "MATERIAL : " + selectedProfile.Name;
            if (selectedProfile.ImagePath != null)
            {
                image_Profile.Source = new BitmapImage(new Uri(selectedProfile.ImagePath));
            }


            if (selectedProfile.Name == Model.Sections.CurrentSection.SectionProfile)
            {
                switch (selectedProfile.Name)
                {
                    case "I Beam":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetNull();


                        decimal Breadth = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Height = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal Width = Model.Sections.CurrentSection.SectionProfileProperty3;
                        decimal OuterArea = Breadth * Height;
                        decimal InnerBreadth = Breadth - Width;
                        decimal InnerHeight = Height - Width - Width;
                        decimal InnerArea = InnerBreadth * InnerHeight;
                        decimal Area = OuterArea - InnerArea;

                        if (Area == Model.Sections.CurrentSection.Area)
                        {
                            singleValue_Property1.SetTheValue(Breadth);
                            singleValue_Property2.SetTheValue(Height);
                            singleValue_Property3.SetTheValue(Width);
                            singleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                singleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Height / 2));
                            }
                        }
                        break;

                    case "Solid Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;

                        if ((decimal)Math.PI * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 == Model.Sections.CurrentSection.Area)
                        {
                            singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            singleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);
                            singleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.SectionProfileProperty1);
                            }
                        }

                        break;
                    case "Solid Elipse":
                        //singleValue_Property1.Title = "Length x-axis (a)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Length y-axis (b)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Solid Rectangle":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();

                        if (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 == Model.Sections.CurrentSection.Area)
                        {
                            singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                            singleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                singleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
                            }
                        }

                        break;
                    case "Solid Triangle":
                        //singleValue_Property1.Title = "Base (b)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Height (h)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;

                    case "Hollow Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property2.Title = "Width (w)";
                        singleValue_Property2.Visibility = Visibility.Visible;

                        if (((decimal)Math.PI * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1) - ((decimal)Math.PI * (Model.Sections.CurrentSection.SectionProfileProperty1 - Model.Sections.CurrentSection.SectionProfileProperty2) * (Model.Sections.CurrentSection.SectionProfileProperty1 - Model.Sections.CurrentSection.SectionProfileProperty2)) == Model.Sections.CurrentSection.Area)
                        {
                            singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                            singleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                singleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.SectionProfileProperty1);
                            }

                        }

                        break;
                    case "Hollow Elipse":
                        //singleValue_Property1.Title = "Radius (a)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Radius (b)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Hollow Rectangle":

                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetNull();
                        if ((Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2) - ((Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2)) * (Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2))) == Model.Sections.CurrentSection.Area)
                        {
                            singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                            singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                            singleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                            singleValue_CalculatedArea.SetTheValue(Model.Sections.CurrentSection.Area);

                            if (Model.Sections.CurrentSection.Area > 0)
                            {
                                singleValue_CalculatedMoment.SetTheValue(Model.Sections.CurrentSection.I);
                                singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                                singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.SectionProfileProperty1);
                            }
                        }

                        break;
                    case "Hollow Triangle":
                        //singleValue_Property1.Title = "Width (b)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Height (h)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                }
            }
            else
            {
                switch (selectedProfile.Name)
                {
                    case "Solid Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;

                        break;
                    case "Solid Elipse":
                        //singleValue_Property1.Title = "Length x-axis (a)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Length y-axis (b)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Solid Rectangle":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        break;
                    case "Solid Triangle":
                        //singleValue_Property1.Title = "Base (b)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Height (h)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Hollow Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property2.Title = "Width (w)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Hollow Elipse":
                        //singleValue_Property1.Title = "Radius (a)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Radius (b)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                    case "Hollow Rectangle":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetNull();
                        break;
                    case "Hollow Triangle":
                        //singleValue_Property1.Title = "Width (b)";
                        //singleValue_Property1.Visibility = Visibility.Visible;
                        //singleValue_Property2.Title = "Height (h)";
                        //singleValue_Property2.Visibility = Visibility.Visible;
                        break;
                }
                singleValue_Property1.SetTheValue(0);
                singleValue_Property2.SetTheValue(0);
                singleValue_Property3.SetTheValue(0);
                singleValue_Property4.SetTheValue(0);
                singleValue_Property5.SetTheValue(0);
                singleValue_Property6.SetTheValue(0);
                singleValue_Property7.SetTheValue(0);
                Model.Sections.CurrentSection.SectionProfileProperty1 = (0);
                Model.Sections.CurrentSection.SectionProfileProperty2 = (0);
                Model.Sections.CurrentSection.SectionProfileProperty3 = (0);
                Model.Sections.CurrentSection.SectionProfileProperty4 = (0);
                Model.Sections.CurrentSection.SectionProfileProperty5 = (0);
                Model.Sections.CurrentSection.SectionProfileProperty6 = (0);
                Model.Sections.CurrentSection.SectionProfileProperty7 = (0);
            }

        }

        private void listView_Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SectionProfile selectedProfile = (SectionProfile)listView_Profile.SelectedItem;
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
                        decimal Breadth = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Height = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal Width = Model.Sections.CurrentSection.SectionProfileProperty3;
                        decimal OuterArea = Breadth * Height;
                        decimal InnerBreadth = Breadth - Width;
                        decimal InnerHeight = Height - Width - Width;
                        decimal InnerArea = InnerBreadth * InnerHeight;
                        decimal Area = OuterArea - InnerArea;

                        //Debug.WriteLine("A " + Area + " O " + OuterArea + " I " + InnerArea);

                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal OuterMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                        decimal InnerMoment = (InnerBreadth * InnerHeight * InnerHeight * InnerHeight) / 12;
                        decimal SecondMoment = OuterMoment - InnerMoment;
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Height / 2));



                        switch (Options.Length)
                        {
                            case LengthType.Meter:
                                singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                break;
                            case LengthType.Millimeter:
                                singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                break;
                            case LengthType.CentiMeter:
                                singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                break;
                            case LengthType.KiloMeter:
                                singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                break;
                            case LengthType.Inch:
                                //
                                singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                break;
                            case LengthType.Foot:
                                singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                break;

                        }

                    }
                    break;

                case "Solid Circle":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal Radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Area = DMath.PI * Radius * Radius;
                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal SecondMoment = ((DMath.PI / 4) * Radius * Radius * Radius * Radius);
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Radius);
                    }
                    break;

                case "Hollow Circle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty3 > 0))
                    {
                        decimal Radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Width = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal InnerRadius = Radius - Width;
                        decimal OuterArea = DMath.PI * Radius * Radius;
                        decimal InnerArea = DMath.PI * InnerRadius * InnerRadius;
                        decimal Area = OuterArea - InnerArea;
                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal SecondMoment = ((DMath.PI / 4) * Radius * Radius * Radius * Radius) - ((DMath.PI / 4) * InnerRadius * InnerRadius * InnerRadius * InnerRadius);
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Radius);
                    }
                    break;

                case "Solid Elipse":

                    break;
                case "Solid Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal Area = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal SecondMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
                    }
                    break;

                case "Hollow Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty3 > 0))
                    {
                        decimal Outer = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal InnerBreadth = (Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal InnerHeight = (Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal Inner = InnerBreadth * InnerHeight;
                        decimal Area = Outer - Inner;
                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal OuterMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                        decimal InnerMoment = (InnerBreadth * InnerHeight * InnerHeight * InnerHeight) / 12;
                        decimal SecondMoment = OuterMoment - InnerMoment;
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));
                    }
                    break;

                case "Solid Square":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal Area = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1;
                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal SecondMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1) / 12;
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty1 / 2));
                    }
                    break;

                case "Hollow Square":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal Outer = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal InnerBreadth = (Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal InnerHeight = (Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal Inner = InnerBreadth * InnerHeight;
                        decimal Area = Outer - Inner;
                        singleValue_CalculatedArea.SetTheValue(Area);
                        singleValue_Area.SetTheValue(Area);
                        Model.Sections.CurrentSection.Area = Area;
                        decimal OuterMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                        decimal InnerMoment = (InnerBreadth * InnerHeight * InnerHeight * InnerHeight) / 12;
                        decimal SecondMoment = OuterMoment - InnerMoment;
                        singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                        singleValue_MomentOfInertia.SetTheValue(SecondMoment);
                        Model.Sections.CurrentSection.I = SecondMoment;
                        singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                        singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));

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


        private void singleValue_Property1_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty1 = singleValue_Property1.NewValue;
            singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
            CheckForProfileAnswer();
        }

        private void singleValue_Property2_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty2 = singleValue_Property2.NewValue;
            singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
            CheckForProfileAnswer();
        }

        private void singleValue_Property3_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty3 = singleValue_Property3.NewValue;
            singleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
            CheckForProfileAnswer();
        }

        private void singleValue_Property4_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty4 = singleValue_Property4.NewValue;
            singleValue_Property4.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty4);
            CheckForProfileAnswer();
        }

        private void singleValue_Property5_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty5 = singleValue_Property5.NewValue;
            singleValue_Property5.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty5);
            CheckForProfileAnswer();
        }

        private void singleValue_Property6_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty6 = singleValue_Property6.NewValue;
            singleValue_Property6.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty6);
            CheckForProfileAnswer();
        }

        private void singleValue_Property7_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty7 = singleValue_Property7.NewValue;
            singleValue_Property7.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty7);
            CheckForProfileAnswer();
        }

        #endregion

        #region Section Properties

        private void singleValue_YoungsModulus_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.E = singleValue_YoungsModulus.NewValue;
            singleValue_YoungsModulus.SetTheValue(Model.Sections.CurrentSection.E);
        }

        private void singleValue_MomentOfInertia_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.I = singleValue_MomentOfInertia.NewValue;
            singleValue_MomentOfInertia.SetTheValue(Model.Sections.CurrentSection.I);
        }

        private void singleValue_Area_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.Area = singleValue_Area.NewValue;
            singleValue_Area.SetTheValue(Model.Sections.CurrentSection.Area);
        }

        private void singleValue_Density_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.Density = singleValue_Density.NewValue;
            singleValue_Density.SetTheValue(Model.Sections.CurrentSection.Density);
        }

        private void singleValue_MaintenancePerLength_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenancePerLength = singleValue_MaintenancePerLength.NewValue;
            singleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);
        }

        private void singleValue_MaintenanceNodeFree_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceNodeFree = singleValue_MaintenanceNodeFree.NewValue;
            singleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);
        }

        private void singleValue_MaintenanceFixed_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceFixed = singleValue_MaintenanceFixed.NewValue;
            singleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);
        }

        private void singleValue_MaintenancePinned_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenancePinned = singleValue_MaintenancePinned.NewValue;
            singleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);
        }

        private void singleValue_MaintenanceRoller_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceRoller = singleValue_MaintenanceRoller.NewValue;
            singleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);
        }

        private void singleValue_MaintenanceTrack_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceTrack = singleValue_MaintenanceTrack.NewValue;
            singleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);
        }

        private void singleValue_CostPerLength_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostPerLength = singleValue_CostPerLength.NewValue;
            singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength);
        }

        private void singleValue_CostVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostVerticalTransport = singleValue_CostVerticalTransport.NewValue;
            singleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);
        }

        private void singleValue_CostHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostHorizontalTransport = singleValue_CostHorizontalTransport.NewValue;
            singleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);
        }

        private void singleValue_CostNodeFree_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeFree = singleValue_CostNodeFree.NewValue;
            singleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);
        }

        private void singleValue_CostNodeFixed_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeFixed = singleValue_CostNodeFixed.NewValue;
            singleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodeFixed);
        }

        private void singleValue_CostNodePinned_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodePinned = singleValue_CostNodePinned.NewValue;
            singleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
        }

        private void singleValue_CostNodeRoller_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeRoller = singleValue_CostNodeRoller.NewValue;
            singleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);
        }

        private void singleValue_CostNodeTrack_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeTrack = singleValue_CostNodeTrack.NewValue;
            singleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);
        }

        private void singleValue_FactorVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.FactorVerticalTransport = singleValue_FactorVerticalTransport.NewValue;
            singleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);
        }

        private void singleValue_FactorHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.FactorHorizontalTransport = singleValue_FactorHorizontalTransport.NewValue;
            singleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);
        }

        #endregion

    }
}
