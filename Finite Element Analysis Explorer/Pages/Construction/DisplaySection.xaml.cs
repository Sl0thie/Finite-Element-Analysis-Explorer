using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class DisplaySection : Page
    {
        //private string lastMaterialName = "";
        //private string lastProfileSection = "";

        public DisplaySection()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            //Set item sources.
            listView_Materials.ItemsSource = Model.Materials.Values;
            listView_Profile.ItemsSource = Model.SectionProfiles.Values;

            #region Set Form Properties  

            if (Model.Members.CurrentMember == null)
            {
                if (Model.Sections.CurrentSection == null)
                {
                    Model.Sections.CurrentSection = Model.Sections["Default"];
                }
            }

            textBlock_Section_Title.Text = "Section : " + Model.Sections.CurrentSection.Name;

            //Section.
            singleValue_CalculatedArea.Title = "Area";
            singleValue_CalculatedArea.UnitType = UnitType.Area;

            singleValue_CalculatedMoment.Title = "2nd Moment of Area";
            singleValue_CalculatedMoment.UnitType = UnitType.MomentOfInertia;

            singleValue_RadiusOfGyration.Title = "Radius of Gyration";
            singleValue_RadiusOfGyration.UnitType = UnitType.Length;

            singleValue_SectionModulus.Title = "Section Modulus";
            singleValue_SectionModulus.UnitType = UnitType.Volume;

            singleValue_VolumePerLength.Title = "Volume per Length";
            singleValue_VolumePerLength.UnitType = UnitType.Volume;

            singleValue_MassPerLength.Title = "Mass per Length";
            singleValue_MassPerLength.UnitType = UnitType.Mass;

            singleValue_WeightPerLength.Title = "Weight per Length";
            singleValue_WeightPerLength.UnitType = UnitType.Force;


            singleValue_Property1.UnitType = UnitType.Length;
            singleValue_Property2.UnitType = UnitType.Length;
            singleValue_Property3.UnitType = UnitType.Length;
            singleValue_Property4.UnitType = UnitType.Length;
            singleValue_Property5.UnitType = UnitType.Length;
            singleValue_Property6.UnitType = UnitType.Length;
            singleValue_Property7.UnitType = UnitType.Length;


            //Profile.
            singleValue_ElasticModulus.Title = "Elastic Modulus";
            singleValue_ElasticModulus.UnitType = UnitType.Pressure;

            singleValue_RigidityModulus.Title = "Rigidity Modulus";
            singleValue_RigidityModulus.UnitType = UnitType.Pressure;

            singleValue_BulkModulus.Title = "Bulk Modulus";
            singleValue_BulkModulus.UnitType = UnitType.Pressure;

            singleValue_Density.Title = "Density";
            singleValue_Density.UnitType = UnitType.Area;

            singleValue_PoissonRatio.Title = "Poisson Ratio";
            singleValue_PoissonRatio.UnitType = UnitType.Unitless;


            singleValue_ThermalExpansion.Title = "Thermal Expansion";
            singleValue_ThermalExpansion.UnitType = UnitType.Unitless;

            singleValue_ThermalConductivity.Title = "Thermal Conductivity";
            singleValue_ThermalConductivity.UnitType = UnitType.Unitless;

            //Costs.           
            singleValue_CostPerLength.Title = "Cost per Length";
            singleValue_CostPerLength.UnitType = UnitType.Money;

            singleValue_CostVerticalTransport.Title = "Vertical Transport";
            singleValue_CostVerticalTransport.UnitType = UnitType.Money;

            singleValue_CostHorizontalTransport.Title = "Horizontal";
            singleValue_CostHorizontalTransport.UnitType = UnitType.Money;

            singleValue_CostNodeFree.Title = "Free Node";
            singleValue_CostNodeFree.UnitType = UnitType.Money;

            singleValue_CostNodeFixed.Title = "Fixed Node";
            singleValue_CostNodeFixed.UnitType = UnitType.Money;

            singleValue_CostNodePinned.Title = "Pinned Node";
            singleValue_CostNodePinned.UnitType = UnitType.Money;

            singleValue_CostNodeRoller.Title = "Roller Node";
            singleValue_CostNodeRoller.UnitType = UnitType.Money;

            singleValue_CostNodeTrack.Title = "Track Node";
            singleValue_CostNodeTrack.UnitType = UnitType.Money;

            singleValue_FactorVerticalTransport.Title = "Vertical Factor";
            singleValue_FactorVerticalTransport.UnitType = UnitType.Percentage;

            singleValue_FactorHorizontalTransport.Title = "Horizontal Factor";
            singleValue_FactorHorizontalTransport.UnitType = UnitType.Percentage;

            singleValue_MaintenanceNodeFree.Title = "Free Node";
            singleValue_MaintenanceNodeFree.UnitType = UnitType.Money;

            singleValue_MaintenanceFixed.Title = "Fixed Node";
            singleValue_MaintenanceFixed.UnitType = UnitType.Money;

            singleValue_MaintenancePinned.Title = "Free Node";
            singleValue_MaintenancePinned.UnitType = UnitType.Money;

            singleValue_MaintenanceRoller.Title = "Roller Node";
            singleValue_MaintenanceRoller.UnitType = UnitType.Money;

            singleValue_MaintenanceTrack.Title = "Track Node";
            singleValue_MaintenanceTrack.UnitType = UnitType.Money;

            singleValue_MaintenancePerLength.Title = "Per Length";
            singleValue_MaintenancePerLength.UnitType = UnitType.Money;

            singleValue_Cost.Title = "Cost";
            singleValue_Cost.UnitType = UnitType.Money;


            singleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);
            singleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);
            singleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);
            singleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
            singleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
            singleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);
            singleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);
            singleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);
            singleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);
            singleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);
            singleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);
            singleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);
            singleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);
            singleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);
            singleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);

            #endregion

            #region Update Form
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


            //Cost factors.



            #endregion  
        }

        private void CalculateSection()
        {
            singleValue_CalculatedArea.SetNull();
            singleValue_CalculatedMoment.SetNull();
            singleValue_RadiusOfGyration.SetNull();
            singleValue_SectionModulus.SetNull();
            singleValue_VolumePerLength.SetNull();
            singleValue_MassPerLength.SetNull();
            singleValue_WeightPerLength.SetNull();
            singleValue_CostPerLength.SetNull();

            switch (Model.Sections.CurrentSection.SectionProfile)
            {
                #region I Beam
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

                        if (Area > 0)
                        {
                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;

                            decimal OuterMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                            decimal InnerMoment = (InnerBreadth * InnerHeight * InnerHeight * InnerHeight) / 12;
                            decimal SecondMoment = OuterMoment - InnerMoment;
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                            Model.Sections.CurrentSection.I = SecondMoment;

                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Height / 2));


                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }

                        }
                        else { return; }
                    }
                    break;
                #endregion
                #region Solid Rectangle

                case "Solid Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal Breadth = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Height = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal Area = Breadth * Height;

                        if (Area > 0)
                        {
                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;

                            decimal SecondMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                            Model.Sections.CurrentSection.I = SecondMoment;

                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Height / 2));

                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else { return; }
                    }
                    break;
                #endregion
                #region Hollow Rectangle

                case "Hollow Rectangle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty3 > 0))
                    {
                        decimal Outer = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal InnerBreadth = (Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal InnerHeight = (Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal Inner = InnerBreadth * InnerHeight;
                        decimal Area = Outer - Inner;

                        if (Area > 0)
                        {

                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;
                            decimal OuterMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                            decimal InnerMoment = (InnerBreadth * InnerHeight * InnerHeight * InnerHeight) / 12;
                            decimal SecondMoment = OuterMoment - InnerMoment;
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                            Model.Sections.CurrentSection.I = SecondMoment;

                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));

                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else { return; }
                    }
                    break;

                #endregion
                #region Solid Circle

                case "Solid Circle":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal Radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Area = DMath.PI * Radius * Radius;

                        if (Area > 0)
                        {
                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;
                            decimal SecondMoment = ((DMath.PI / 4) * Radius * Radius * Radius * Radius);
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                            Model.Sections.CurrentSection.I = SecondMoment;
                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Radius);

                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else { return; }
                    }
                    break;
                #endregion
                #region Hollow Circle

                case "Hollow Circle":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal Radius = Model.Sections.CurrentSection.SectionProfileProperty1;
                        decimal Width = Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal InnerRadius = Radius - Width;
                        decimal OuterArea = DMath.PI * Radius * Radius;
                        decimal InnerArea = DMath.PI * InnerRadius * InnerRadius;
                        decimal Area = OuterArea - InnerArea;

                        if (Area > 0)
                        {
                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;
                            decimal SecondMoment = ((DMath.PI / 4) * Radius * Radius * Radius * Radius) - ((DMath.PI / 4) * InnerRadius * InnerRadius * InnerRadius * InnerRadius);
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);

                            Model.Sections.CurrentSection.I = SecondMoment;
                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / Radius);

                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }

                        }
                        else { return; }


                    }
                    break;

                #endregion
                #region Solid Square

                case "Solid Square":
                    if (Model.Sections.CurrentSection.SectionProfileProperty1 > 0)
                    {
                        decimal Area = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1;

                        if (Area > 0)
                        {
                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;
                            decimal SecondMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty1) / 12;
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                            Model.Sections.CurrentSection.I = SecondMoment;
                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty1 / 2));

                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else { return; }
                    }
                    break;

                #endregion
                #region Hollow Square

                case "Hollow Square":
                    if ((Model.Sections.CurrentSection.SectionProfileProperty1 > 0) && (Model.Sections.CurrentSection.SectionProfileProperty2 > 0))
                    {
                        decimal Outer = Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2;
                        decimal InnerBreadth = (Model.Sections.CurrentSection.SectionProfileProperty2 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal InnerHeight = (Model.Sections.CurrentSection.SectionProfileProperty1 - (Model.Sections.CurrentSection.SectionProfileProperty3 * 2));
                        decimal Inner = InnerBreadth * InnerHeight;
                        decimal Area = Outer - Inner;

                        if (Area > 0)
                        {
                            singleValue_CalculatedArea.SetTheValue(Area);
                            Model.Sections.CurrentSection.Area = Area;
                            decimal OuterMoment = (Model.Sections.CurrentSection.SectionProfileProperty1 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2 * Model.Sections.CurrentSection.SectionProfileProperty2) / 12;
                            decimal InnerMoment = (InnerBreadth * InnerHeight * InnerHeight * InnerHeight) / 12;
                            decimal SecondMoment = OuterMoment - InnerMoment;
                            singleValue_CalculatedMoment.SetTheValue(SecondMoment);
                            Model.Sections.CurrentSection.I = SecondMoment;
                            singleValue_RadiusOfGyration.SetTheValue(DMath.Sqrt(Model.Sections.CurrentSection.I / Model.Sections.CurrentSection.Area));
                            singleValue_SectionModulus.SetTheValue(Model.Sections.CurrentSection.I / (Model.Sections.CurrentSection.SectionProfileProperty2 / 2));

                            Model.Sections.CurrentSection.CostPerLength = (Model.Sections.CurrentSection.Area * Model.Materials[Model.Sections.CurrentSection.Material].Cost);
                            switch (Options.Length)
                            {
                                case LengthType.Meter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Millimeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.MilliMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.MilliMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.CentiMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.CentiMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.CentiMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.KiloMeter:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.KiloMeterPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.KiloMeterPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Inch:
                                    //
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.InchPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.InchPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.InchPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                                case LengthType.Foot:
                                    singleValue_VolumePerLength.SetTheValue(Model.Sections.CurrentSection.Area / Constants.FootPerMeter);
                                    singleValue_MassPerLength.SetTheValue((Model.Sections.CurrentSection.Area / Constants.FootPerMeter) * singleValue_Density.NewValue);
                                    singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength / Constants.FootPerMeter);
                                    singleValue_WeightPerLength.SetTheValue(singleValue_MassPerLength.NewValue * 9.81m);
                                    break;
                            }
                        }
                        else { return; }
                    }

                    break;

                #endregion
                #region Solid Elipse

                case "Solid Elipse":

                    break;

                #endregion   
                #region Hollow Elipse

                case "Hollow Elipse":

                    break;

                    #endregion
            }
        }

        #region Material

        private void UpdateMaterial(Material selectedMaterial)
        {
            TextBlock_SelectedMaterial.Text = selectedMaterial.Name;
            Model.Sections.CurrentSection.Material = selectedMaterial.Name;


            singleValue_ElasticModulus.SetNull();
            singleValue_RigidityModulus.SetNull();
            singleValue_BulkModulus.SetNull();
            singleValue_Density.SetNull();
            singleValue_PoissonRatio.SetNull();
            singleValue_ThermalExpansion.SetNull();
            singleValue_ThermalConductivity.SetNull();

            //if (Model.Sections.CurrentSection.Material == selectedMaterial.Name)
            //{

            //}
            //else
            //{
            //    //Set Properties to the Section.
            //    Model.Sections.CurrentSection.Material = selectedMaterial.Name;
            //    singleValue_ElasticModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
            //    Model.Sections.CurrentSection.E = selectedMaterial.ModulusOfElasticity;
            //    singleValue_ElasticModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
            //    singleValue_Density.SetTheValue(selectedMaterial.Density);
            //    Model.Sections.CurrentSection.Density = selectedMaterial.Density;            
            //}

            ////Material

            singleValue_Cost.SetNull();
            singleValue_Cost.SetTheValue(selectedMaterial.Cost);


            singleValue_Density.DisplayOnly = true;
            singleValue_Density.SetNull();
            singleValue_Density.SetTheValue(selectedMaterial.Density);

            singleValue_ElasticModulus.DisplayOnly = true;
            singleValue_ElasticModulus.Title = "Elastic Modulus";
            singleValue_ElasticModulus.UnitType = UnitType.Pressure;
            singleValue_ElasticModulus.SetNull();
            try
            {
                singleValue_ElasticModulus.SetTheValue(selectedMaterial.ModulusOfElasticity);
                Model.Sections.CurrentSection.E = selectedMaterial.ModulusOfElasticity;
                //singleValue_CalculatedMoment.SetTheValue(selectedMaterial.ModulusOfElasticity);
            }
            catch { Debug.WriteLine("Error Setting E "); }

            singleValue_RigidityModulus.DisplayOnly = true;
            singleValue_RigidityModulus.Title = "Rigidity Modulus";
            singleValue_RigidityModulus.UnitType = UnitType.Pressure;
            singleValue_RigidityModulus.SetNull();
            try
            {
                singleValue_RigidityModulus.SetTheValue(selectedMaterial.ModulusOfRigidity);
            }
            catch { }

            singleValue_BulkModulus.DisplayOnly = true;
            singleValue_BulkModulus.Title = "Bulk Modulus";
            singleValue_BulkModulus.UnitType = UnitType.Pressure;
            singleValue_BulkModulus.SetNull();
            try
            {
                singleValue_BulkModulus.SetTheValue(selectedMaterial.Bulk_Modulus);
            }
            catch { }

            singleValue_PoissonRatio.DisplayOnly = true;
            singleValue_PoissonRatio.Title = "Poisson Ratio";
            singleValue_PoissonRatio.UnitType = UnitType.Unitless;
            singleValue_PoissonRatio.SetNull();
            try
            {
                singleValue_PoissonRatio.SetTheValue(selectedMaterial.Poission_Ratio);
            }
            catch { }


            singleValue_ThermalExpansion.DisplayOnly = true;
            singleValue_ThermalExpansion.Title = "Thermal Expansions";
            singleValue_ThermalExpansion.UnitType = UnitType.Unitless;
            singleValue_ThermalExpansion.SetNull();
            try
            {
                singleValue_ThermalExpansion.SetTheValue(selectedMaterial.Thermal_Expansion);
            }
            catch { }

            singleValue_ThermalConductivity.DisplayOnly = true;
            singleValue_ThermalConductivity.Title = "Thermal Conductivity";
            singleValue_ThermalConductivity.UnitType = UnitType.Unitless;
            singleValue_ThermalConductivity.SetNull();
            try
            {
                singleValue_ThermalConductivity.SetTheValue(selectedMaterial.Thermal_Conductivity);
            }
            catch { }

            CalculateSection();
        }

        private void ListView_Materials_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Material selectedMaterial = (Material)listView_Materials.SelectedItem;

            UpdateMaterial(selectedMaterial);
        }

        #endregion

        #region Profile

        private void UpdateProfile(SectionProfile selectedProfile)
        {
            TextBlock_SelectedProfile.Text = selectedProfile.Name;

            //Model.Sections.CurrentSection.SectionProfile = selectedProfile.Name;

            if (selectedProfile.ImagePath != null)
            {
                image_Profile.Source = new BitmapImage(new Uri(selectedProfile.ImagePath));
            }

            singleValue_Property1.Visibility = Visibility.Collapsed;
            singleValue_Property2.Visibility = Visibility.Collapsed;
            singleValue_Property3.Visibility = Visibility.Collapsed;
            singleValue_Property4.Visibility = Visibility.Collapsed;
            singleValue_Property5.Visibility = Visibility.Collapsed;
            singleValue_Property6.Visibility = Visibility.Collapsed;
            singleValue_Property7.Visibility = Visibility.Collapsed;
            singleValue_Property1.SetNull();
            singleValue_Property2.SetNull();
            singleValue_Property3.SetNull();
            singleValue_Property4.SetNull();
            singleValue_Property5.SetNull();
            singleValue_Property6.SetNull();
            singleValue_Property7.SetNull();

            singleValue_CalculatedArea.SetNull();
            singleValue_CalculatedMoment.SetNull();

            singleValue_RadiusOfGyration.SetNull();
            singleValue_SectionModulus.SetNull();

            singleValue_VolumePerLength.SetNull();
            singleValue_MassPerLength.SetNull();
            singleValue_WeightPerLength.SetNull();


            if (selectedProfile.Name == Model.Sections.CurrentSection.SectionProfile)
            {
                switch (selectedProfile.Name)
                {
                    case "I Beam":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                        break;

                    case "Solid Rectangle":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Hollow Rectangle":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                        break;

                    case "Solid Square":
                        singleValue_Property1.Title = "Side (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        break;

                    case "Hollow Square":
                        singleValue_Property1.Title = "Side (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Width (w)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Solid Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        break;

                    case "Hollow Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Width (w)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Solid Elipse":
                        singleValue_Property1.Title = "Length x-axis (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Length y-axis (b)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        break;

                    case "Hollow Elipse":
                        singleValue_Property1.Title = "Length x-axis (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
                        singleValue_Property2.Title = "Length y-axis (b)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
                        break;
                }

            }
            else
            {
                switch (selectedProfile.Name)
                {
                    case "I Beam":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        break;

                    case "Solid Rectangle":
                        singleValue_Property1.Title = "Breadth (b)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Height (h)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
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

                    case "Solid Square":
                        singleValue_Property1.Title = "Side (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();

                        break;
                    case "Hollow Square":
                        singleValue_Property1.Title = "Side (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Width (w)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        break;

                    case "Solid Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        break;

                    case "Hollow Circle":
                        singleValue_Property1.Title = "Radius (r)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property2.Title = "Width (w)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        break;

                    case "Solid Elipse":
                        singleValue_Property1.Title = "Length x-axis (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Length y-axis (b)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        break;

                    case "Hollow Elipse":
                        singleValue_Property1.Title = "Length x-axis (a)";
                        singleValue_Property1.Visibility = Visibility.Visible;
                        singleValue_Property1.SetNull();
                        singleValue_Property2.Title = "Length y-axis (b)";
                        singleValue_Property2.Visibility = Visibility.Visible;
                        singleValue_Property2.SetNull();
                        singleValue_Property3.Title = "Width (w)";
                        singleValue_Property3.Visibility = Visibility.Visible;
                        singleValue_Property3.SetNull();
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



            Model.Sections[Model.Sections.CurrentSection.Name].SectionProfile = selectedProfile.Name;
            //Model.Sections.CurrentSection.SectionProfile = selectedProfile.Name;


            CalculateSection();
        }

        private void ListView_Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SectionProfile selectedProfile = (SectionProfile)listView_Profile.SelectedItem;
            //Model.Sections.CurrentSection.SectionProfile = selectedProfile.Name;
            UpdateProfile(selectedProfile);
        }

        private void SingleValue_Property1_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty1 = singleValue_Property1.NewValue;
            singleValue_Property1.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty1);
            CalculateSection();
        }

        private void SingleValue_Property2_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty2 = singleValue_Property2.NewValue;
            singleValue_Property2.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty2);
            CalculateSection();
        }

        private void SingleValue_Property3_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty3 = singleValue_Property3.NewValue;
            singleValue_Property3.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty3);
            CalculateSection();
        }

        private void SingleValue_Property4_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty4 = singleValue_Property4.NewValue;
            singleValue_Property4.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty4);
            CalculateSection();
        }

        private void SingleValue_Property5_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty5 = singleValue_Property5.NewValue;
            singleValue_Property5.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty5);
            CalculateSection();
        }

        private void SingleValue_Property6_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty6 = singleValue_Property6.NewValue;
            singleValue_Property6.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty6);
            CalculateSection();
        }

        private void SingleValue_Property7_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.SectionProfileProperty7 = singleValue_Property7.NewValue;
            singleValue_Property7.SetTheValue(Model.Sections.CurrentSection.SectionProfileProperty7);
            CalculateSection();
        }

        #endregion

        #region Section Properties

        private void SingleValue_YoungsModulus_ValueChanged(object sender, EventArgs e)
        {
            //Model.Sections.CurrentSection.E = singleValue_YoungsModulus.NewValue;
            //singleValue_YoungsModulus.SetTheValue(Model.Sections.CurrentSection.E);
        }

        private void SingleValue_MomentOfInertia_ValueChanged(object sender, EventArgs e)
        {
            //Model.Sections.CurrentSection.I = singleValue_MomentOfInertia.NewValue;
            //singleValue_MomentOfInertia.SetTheValue(Model.Sections.CurrentSection.I);
        }

        private void SingleValue_Area_ValueChanged(object sender, EventArgs e)
        {
            //Model.Sections.CurrentSection.Area = singleValue_Area.NewValue;
            //singleValue_Area.SetTheValue(Model.Sections.CurrentSection.Area);
        }

        private void SingleValue_Density_ValueChanged(object sender, EventArgs e)
        {
            //Model.Sections.CurrentSection.Density = singleValue_Density.NewValue;
            //singleValue_Density.SetTheValue(Model.Sections.CurrentSection.Density);
        }

        private void SingleValue_MaintenancePerLength_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenancePerLength = singleValue_MaintenancePerLength.NewValue;
            singleValue_MaintenancePerLength.SetTheValue(Model.Sections.CurrentSection.MaintenancePerLength);
        }

        private void SingleValue_MaintenanceNodeFree_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceNodeFree = singleValue_MaintenanceNodeFree.NewValue;
            singleValue_MaintenanceNodeFree.SetTheValue(Model.Sections.CurrentSection.MaintenanceNodeFree);
        }

        private void SingleValue_MaintenanceFixed_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceFixed = singleValue_MaintenanceFixed.NewValue;
            singleValue_MaintenanceFixed.SetTheValue(Model.Sections.CurrentSection.MaintenanceFixed);
        }

        private void SingleValue_MaintenancePinned_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenancePinned = singleValue_MaintenancePinned.NewValue;
            singleValue_MaintenancePinned.SetTheValue(Model.Sections.CurrentSection.MaintenancePinned);
        }

        private void SingleValue_MaintenanceRoller_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceRoller = singleValue_MaintenanceRoller.NewValue;
            singleValue_MaintenanceRoller.SetTheValue(Model.Sections.CurrentSection.MaintenanceRoller);
        }

        private void SingleValue_MaintenanceTrack_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.MaintenanceTrack = singleValue_MaintenanceTrack.NewValue;
            singleValue_MaintenanceTrack.SetTheValue(Model.Sections.CurrentSection.MaintenanceTrack);
        }

        private void SingleValue_CostPerLength_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostPerLength = singleValue_CostPerLength.NewValue;
            singleValue_CostPerLength.SetTheValue(Model.Sections.CurrentSection.CostPerLength);
        }

        private void SingleValue_CostVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostVerticalTransport = singleValue_CostVerticalTransport.NewValue;
            singleValue_CostVerticalTransport.SetTheValue(Model.Sections.CurrentSection.CostVerticalTransport);
        }

        private void SingleValue_CostHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostHorizontalTransport = singleValue_CostHorizontalTransport.NewValue;
            singleValue_CostHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.CostHorizontalTransport);
        }

        private void SingleValue_CostNodeFree_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeFree = singleValue_CostNodeFree.NewValue;
            singleValue_CostNodeFree.SetTheValue(Model.Sections.CurrentSection.CostNodeFree);
        }

        private void SingleValue_CostNodeFixed_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeFixed = singleValue_CostNodeFixed.NewValue;
            singleValue_CostNodeFixed.SetTheValue(Model.Sections.CurrentSection.CostNodeFixed);
        }

        private void SingleValue_CostNodePinned_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodePinned = singleValue_CostNodePinned.NewValue;
            singleValue_CostNodePinned.SetTheValue(Model.Sections.CurrentSection.CostNodePinned);
        }

        private void SingleValue_CostNodeRoller_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeRoller = singleValue_CostNodeRoller.NewValue;
            singleValue_CostNodeRoller.SetTheValue(Model.Sections.CurrentSection.CostNodeRoller);
        }

        private void SingleValue_CostNodeTrack_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.CostNodeTrack = singleValue_CostNodeTrack.NewValue;
            singleValue_CostNodeTrack.SetTheValue(Model.Sections.CurrentSection.CostNodeTrack);
        }

        private void SingleValue_FactorVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.FactorVerticalTransport = singleValue_FactorVerticalTransport.NewValue;
            singleValue_FactorVerticalTransport.SetTheValue(Model.Sections.CurrentSection.FactorVerticalTransport);
        }

        private void SingleValue_FactorHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            Model.Sections.CurrentSection.FactorHorizontalTransport = singleValue_FactorHorizontalTransport.NewValue;
            singleValue_FactorHorizontalTransport.SetTheValue(Model.Sections.CurrentSection.FactorHorizontalTransport);
        }

        #endregion

    }
}
