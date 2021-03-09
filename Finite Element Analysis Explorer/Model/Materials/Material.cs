using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finite_Element_Analysis_Explorer
{
    public class Material
    {

        public void Output()
        {

        }

        public Material()
        {

        }

        public Material(string _name,
            string _description,
            decimal _cost,
            decimal _density,
            decimal _ultimateStrengthTension,
            decimal _ultimateStrengthCompression,
            decimal _ultimateStrengthShear,
            decimal _yieldStrengthTension,
            decimal _yieldStrengthShear,
            decimal _modulusOfElasticity,
            decimal _modulusOfRigidity,
            decimal _coefficientOfThermalExpansion,
            decimal _ductility,
            int _Atomic_Number,
            string _Symbol,
            decimal _Atomic_Mass,
            string _Allotrope_Names,
            string _Alternate_Names,
            string _CAS_Number,
            string _Icon_Color,
            string _Block,
            string _Group,
            string _Period,
            string _Series,
            decimal _Atomic_Weight,
            decimal _Brinell_Hardness,
            decimal _Bulk_Modulus,
            decimal _Liquid_Density,
            decimal _Mohs_Hardness,
            decimal _Molar_Volume,
            decimal _Poission_Ratio,
            decimal _Shear_Modulus,
            decimal _Sound_Speed,
            decimal _Thermal_Conductivity,
            decimal _Thermal_Expansion,
            decimal _Vickers_Hardness,
            decimal _Young_Modulus,
            decimal _Absolute_Boiling_Point,
            decimal _Absolute_Melting_Point,
            decimal _Adiabatic_Index,
            decimal _Boiling_Point,
            decimal _Critical_Pressure,
            decimal _Critical_Temperature,
            decimal _Curie_Point,
            decimal _Fusion_Heat,
            decimal _Melting_Point,
            decimal _Neel_Point,
            string _Phase,
            decimal _Specific_Heat,
            decimal _Superconducting_Point,
            decimal _Vaporization_Heat,
            string _Color,
            decimal _Electrical_Conductivity,
            string _Electrical_Type,
            string _Magnetic_Type,
            decimal _Mass_Magnetic_Susceptibility,
            decimal _Molar_Magnetic_Susceptibility,
            decimal _Refractive_Index,
            decimal _Resistivity,
            decimal _Volume_Magnetic_Susceptibility,
            string _Allotropic_Multiplicities,
            string _Electron_Affinity,
            string _Electronegativity,
            string _Gas_Atomic_Multiplicities,
            string _Valence,
            string _Crystal_Structure,
            string _Lattice_Angles,
            string _Lattice_Constants,
            string _Space_Group_Number,
            string _Space_Group_Name,
            string _Atomic_Radius,
            string _Covalent_Radius,
            string _Electron_Configuration,
            string _Electron_Configuration_String,
            string _Electron_Shell_Configuration,
            string _Ionization_Energies,
            string _Quantum_Numbers,
            string _Van_Der_Waals_Radius,
            string _Decay_Mode,
            string _HalfLife,
            string _Isotope_Abundances,
            string _Known_Isotopes,
            string _Lifetime,
            string _Neutron_Cross_Section,
            string _Neutron_Mass_Absorption,
            string _Radioactive,
            string _Stable_Isotopes,
            decimal _Crust_Abundance,
            decimal _Human_Abundance,
            decimal _Meteorite_Abundance,
            decimal _Ocean_Abundance,
            decimal _Solar_Abundance,
            decimal _Universe_Abundance,
            string _Radius_Empirical,
            string _Radius_Calculated,
            string _Radius_Van_Der_Waals,
            string _Radius_Covalent_Single_Bond,
            string _Radius_Covalent_Triple_Bond,
            string _Radius_Metallic,
            string _MaterialType
            )
        {

            name = _name;
            description = _description;
            cost = _cost;
            density = _density;
            ultimateStrengthTension = _ultimateStrengthTension;
            ultimateStrengthCompression = _ultimateStrengthCompression;
            ultimateStrengthShear = _ultimateStrengthShear;
            yieldStrengthTension = _yieldStrengthTension;
            yieldStrengthShear = _yieldStrengthShear;
            modulusOfElasticity = _modulusOfElasticity;
            modulusOfRigidity = _modulusOfRigidity;
            coefficientOfThermalExpansion = _coefficientOfThermalExpansion;
            ductility = _ductility;
            Atomic_Number = _Atomic_Number;
            Symbol = _Symbol;
            Atomic_Mass = _Atomic_Mass;
            Allotrope_Names = _Allotrope_Names;
            Alternate_Names = _Alternate_Names;
            CAS_Number = _CAS_Number;
            Icon_Color = _Icon_Color;
            Block = _Block;
            Group = _Group;
            Period = _Period;
            Series = _Series;
            Atomic_Weight = _Atomic_Weight;
            Brinell_Hardness = _Brinell_Hardness;
            Bulk_Modulus = _Bulk_Modulus;
            Liquid_Density = _Liquid_Density;
            Mohs_Hardness = _Mohs_Hardness;
            Molar_Volume = _Molar_Volume;
            Poission_Ratio = _Poission_Ratio;
            ModulusOfRigidity = _Shear_Modulus;
            Sound_Speed = _Sound_Speed;
            Thermal_Conductivity = _Thermal_Conductivity;
            Thermal_Expansion = _Thermal_Expansion;
            Vickers_Hardness = _Vickers_Hardness;
            ModulusOfElasticity = _Young_Modulus;
            Absolute_Boiling_Point = _Absolute_Boiling_Point;
            Absolute_Melting_Point = _Absolute_Melting_Point;
            Adiabatic_Index = _Adiabatic_Index;
            Boiling_Point = _Boiling_Point;
            Critical_Pressure = _Critical_Pressure;
            Critical_Temperature = _Critical_Temperature;
            Curie_Point = _Curie_Point;
            Fusion_Heat = _Fusion_Heat;
            Melting_Point = _Melting_Point;
            Neel_Point = _Neel_Point;
            Phase = _Phase;
            Specific_Heat = _Specific_Heat;
            Superconducting_Point = _Superconducting_Point;
            Vaporization_Heat = _Vaporization_Heat;
            Color = _Color;
            Electrical_Conductivity = _Electrical_Conductivity;
            Electrical_Type = _Electrical_Type;
            Magnetic_Type = _Magnetic_Type;
            Mass_Magnetic_Susceptibility = _Mass_Magnetic_Susceptibility;
            Molar_Magnetic_Susceptibility = _Molar_Magnetic_Susceptibility;
            Refractive_Index = _Refractive_Index;
            Resistivity = _Resistivity;
            Volume_Magnetic_Susceptibility = _Volume_Magnetic_Susceptibility;
            Allotropic_Multiplicities = _Allotropic_Multiplicities;
            Electron_Affinity = _Electron_Affinity;
            Electronegativity = _Electronegativity;
            Gas_Atomic_Multiplicities = _Gas_Atomic_Multiplicities;
            Valence = _Valence;
            Crystal_Structure = _Crystal_Structure;
            Lattice_Angles = _Lattice_Angles;
            Lattice_Constants = _Lattice_Constants;
            Space_Group_Number = _Space_Group_Number;
            Space_Group_Name = _Space_Group_Name;
            Atomic_Radius = _Atomic_Radius;
            Covalent_Radius = _Covalent_Radius;
            Electron_Configuration = _Electron_Configuration;
            Electron_Configuration_String = _Electron_Configuration_String;
            Electron_Shell_Configuration = _Electron_Shell_Configuration;
            Ionization_Energies = _Ionization_Energies;
            Quantum_Numbers = _Quantum_Numbers;
            Van_Der_Waals_Radius = _Van_Der_Waals_Radius;
            Decay_Mode = _Decay_Mode;
            HalfLife = _HalfLife;
            Isotope_Abundances = _Isotope_Abundances;
            Known_Isotopes = _Known_Isotopes;
            Lifetime = _Lifetime;
            Neutron_Cross_Section = _Neutron_Cross_Section;
            Neutron_Mass_Absorption = _Neutron_Mass_Absorption;
            Radioactive = _Radioactive;
            Stable_Isotopes = _Stable_Isotopes;
            Crust_Abundance = _Crust_Abundance;
            Human_Abundance = _Human_Abundance;
            Meteorite_Abundance = _Meteorite_Abundance;
            Ocean_Abundance = _Ocean_Abundance;
            Solar_Abundance = _Solar_Abundance;
            Universe_Abundance = _Universe_Abundance;
            Radius_Empirical = _Radius_Empirical;
            Radius_Calculated = _Radius_Calculated;
            Radius_Van_Der_Waals = _Radius_Van_Der_Waals;
            Radius_Covalent_Single_Bond = _Radius_Covalent_Single_Bond;
            Radius_Covalent_Triple_Bond = _Radius_Covalent_Triple_Bond;
            Radius_Metallic = _Radius_Metallic;
            MaterialType = _MaterialType;
        }

        #region Added

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private decimal cost = 0;
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private decimal density = 0;
        public decimal Density
        {
            get { return density; }
            set { density = value; }
        }

        private decimal ultimateStrengthTension = 0;
        public decimal UltimateStrengthTension
        {
            get { return ultimateStrengthTension; }
            set { ultimateStrengthTension = value; }
        }

        private decimal ultimateStrengthCompression = 0;
        public decimal UltimateStrengthCompression
        {
            get { return ultimateStrengthCompression; }
            set { ultimateStrengthCompression = value; }
        }

        private decimal ultimateStrengthShear = 0;
        public decimal UltimateStrengthShear
        {
            get { return ultimateStrengthShear; }
            set { ultimateStrengthShear = value; }
        }

        private decimal yieldStrengthTension = 0;
        public decimal YieldStrengthTension
        {
            get { return yieldStrengthTension; }
            set { yieldStrengthTension = value; }
        }

        private decimal yieldStrengthShear = 0;
        public decimal YieldStrengthShear
        {
            get { return yieldStrengthShear; }
            set
            {
                //YieldStrengthShear = value; 
            }
        }

        /// <summary>
        /// Modulus of Elasticity (E) or Young's Modulus.
        ///       
        /// </summary>
        private decimal modulusOfElasticity = 0;
        public decimal ModulusOfElasticity
        {
            get { return modulusOfElasticity; }
            set { modulusOfElasticity = value; }
        }

        /// <summary>
        /// Modulus of Rigidity (G)
        /// 
        /// 
        ///  G = E/2(1+v)
        ///  E = 2G(1+v)
        /// 
        /// </summary>
        private decimal modulusOfRigidity = 0;
        public decimal ModulusOfRigidity
        {
            get { return modulusOfRigidity; }
            set { modulusOfRigidity = value; }
        }

        /// <summary>
        /// Bulk Mudulus (K) 
        /// Ability to resist compression.
        /// 
        /// Relation Equation E = 3K(1-2v)
        ///                   K = E/3(1-2v)
        /// 
        /// 
        /// </summary>
        private decimal _Bulk_Modulus = 0;
        internal decimal Bulk_Modulus
        {
            get { return _Bulk_Modulus; }
            set { _Bulk_Modulus = value; }
        }

        private decimal coefficientOfThermalExpansion = 0;
        public decimal CoefficientOfThermalExpansion
        {
            get { return coefficientOfThermalExpansion; }
            set { coefficientOfThermalExpansion = value; }
        }

        private decimal ductility = 0;
        public decimal Ductility
        {
            get { return ductility; }
            set { ductility = value; }
        }

        #endregion


        private int _Atomic_Number = 0;
        internal int Atomic_Number
        {
            get { return _Atomic_Number; }
            set { _Atomic_Number = value; }
        }

        private string _Symbol = "";
        internal string Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }

        private decimal _Atomic_Mass = 0;
        internal decimal Atomic_Mass
        {
            get { return _Atomic_Mass; }
            set { _Atomic_Mass = value; }
        }

        private string _Allotrope_Names = "";
        internal string Allotrope_Names
        {
            get { return _Allotrope_Names; }
            set { _Allotrope_Names = value; }
        }

        private string _Alternate_Names = "";
        internal string Alternate_Names
        {
            get { return _Alternate_Names; }
            set { _Alternate_Names = value; }
        }

        private string _CAS_Number = "";
        internal string CAS_Number
        {
            get { return _CAS_Number; }
            set { _CAS_Number = value; }
        }

        private string _Icon_Color = "";
        internal string Icon_Color
        {
            get { return _Icon_Color; }
            set { _Icon_Color = value; }
        }

        private string _Block = "";
        internal string Block
        {
            get { return _Block; }
            set { _Block = value; }
        }

        private string _Group = "";
        internal string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        private string _Period = "";
        internal string Period
        {
            get { return _Period; }
            set { _Period = value; }
        }

        private string _Series = "";
        internal string Series
        {
            get { return _Series; }
            set { _Series = value; }
        }

        private decimal _Atomic_Weight = 0;
        internal decimal Atomic_Weight
        {
            get { return _Atomic_Weight; }
            set { _Atomic_Weight = value; }
        }

        private decimal _Brinell_Hardness = 0;
        internal decimal Brinell_Hardness
        {
            get { return _Brinell_Hardness; }
            set { _Brinell_Hardness = value; }
        }



        //private string _Density;
        //public string Density
        //{
        //    get { return _Density; }
        //    set { _Density = value; }
        //}

        private decimal _Liquid_Density = 0;
        internal decimal Liquid_Density
        {
            get { return _Liquid_Density; }
            set { _Liquid_Density = value; }
        }

        private decimal _Mohs_Hardness = 0;
        internal decimal Mohs_Hardness
        {
            get { return _Mohs_Hardness; }
            set { _Mohs_Hardness = value; }
        }

        private decimal _Molar_Volume = 0;
        internal decimal Molar_Volume
        {
            get { return _Molar_Volume; }
            set { _Molar_Volume = value; }
        }

        private decimal _Poission_Ratio = 0;
        internal decimal Poission_Ratio
        {
            get { return _Poission_Ratio; }
            set { _Poission_Ratio = value; }
        }



        private decimal _Sound_Speed = 0;
        internal decimal Sound_Speed
        {
            get { return _Sound_Speed; }
            set { _Sound_Speed = value; }
        }

        private decimal _Thermal_Conductivity = 0;
        internal decimal Thermal_Conductivity
        {
            get { return _Thermal_Conductivity; }
            set { _Thermal_Conductivity = value; }
        }

        private decimal _Thermal_Expansion = 0;
        internal decimal Thermal_Expansion
        {
            get { return _Thermal_Expansion; }
            set { _Thermal_Expansion = value; }
        }

        private decimal _Vickers_Hardness = 0;
        internal decimal Vickers_Hardness
        {
            get { return _Vickers_Hardness; }
            set { _Vickers_Hardness = value; }
        }



        private decimal _Absolute_Boiling_Point = 0;
        internal decimal Absolute_Boiling_Point
        {
            get { return _Absolute_Boiling_Point; }
            set { _Absolute_Boiling_Point = value; }
        }

        private decimal _Absolute_Melting_Point = 0;
        internal decimal Absolute_Melting_Point
        {
            get { return _Absolute_Melting_Point; }
            set { _Absolute_Melting_Point = value; }
        }

        private decimal _Adiabatic_Index = 0;
        internal decimal Adiabatic_Index
        {
            get { return _Adiabatic_Index; }
            set { _Adiabatic_Index = value; }
        }

        private decimal _Boiling_Point = 0;
        internal decimal Boiling_Point
        {
            get { return _Boiling_Point; }
            set { _Boiling_Point = value; }
        }

        private decimal _Critical_Pressure = 0;
        internal decimal Critical_Pressure
        {
            get { return _Critical_Pressure; }
            set { _Critical_Pressure = value; }
        }

        private decimal _Critical_Temperature = 0;
        internal decimal Critical_Temperature
        {
            get { return _Critical_Temperature; }
            set { _Critical_Temperature = value; }
        }

        private decimal _Curie_Point = 0;
        internal decimal Curie_Point
        {
            get { return _Curie_Point; }
            set { _Curie_Point = value; }
        }

        private decimal _Fusion_Heat = 0;
        internal decimal Fusion_Heat
        {
            get { return _Fusion_Heat; }
            set { _Fusion_Heat = value; }
        }

        private decimal _Melting_Point = 0;
        internal decimal Melting_Point
        {
            get { return _Melting_Point; }
            set { _Melting_Point = value; }
        }

        private decimal _Neel_Point = 0;
        internal decimal Neel_Point
        {
            get { return _Neel_Point; }
            set { _Neel_Point = value; }
        }

        private string _Phase = "";
        internal string Phase
        {
            get { return _Phase; }
            set { _Phase = value; }
        }

        private decimal _Specific_Heat = 0;
        internal decimal Specific_Heat
        {
            get { return _Specific_Heat; }
            set { _Specific_Heat = value; }
        }

        private decimal _Superconducting_Point = 0;
        internal decimal Superconducting_Point
        {
            get { return _Superconducting_Point; }
            set { _Superconducting_Point = value; }
        }

        private decimal _Vaporization_Heat = 0;
        internal decimal Vaporization_Heat
        {
            get { return _Vaporization_Heat; }
            set { _Vaporization_Heat = value; }
        }

        private string _Color = "";
        internal string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        private decimal _Electrical_Conductivity = 0;
        internal decimal Electrical_Conductivity
        {
            get { return _Electrical_Conductivity; }
            set { _Electrical_Conductivity = value; }
        }

        private string _Electrical_Type = "";
        internal string Electrical_Type
        {
            get { return _Electrical_Type; }
            set { _Electrical_Type = value; }
        }

        private string _Magnetic_Type = "";
        internal string Magnetic_Type
        {
            get { return _Magnetic_Type; }
            set { _Magnetic_Type = value; }
        }

        private decimal _Mass_Magnetic_Susceptibility = 0;
        internal decimal Mass_Magnetic_Susceptibility
        {
            get { return _Mass_Magnetic_Susceptibility; }
            set { _Mass_Magnetic_Susceptibility = value; }
        }

        private decimal _Molar_Magnetic_Susceptibility = 0;
        internal decimal Molar_Magnetic_Susceptibility
        {
            get { return _Molar_Magnetic_Susceptibility; }
            set { _Molar_Magnetic_Susceptibility = value; }
        }

        private decimal _Refractive_Index = 0;
        internal decimal Refractive_Index
        {
            get { return _Refractive_Index; }
            set { _Refractive_Index = value; }
        }

        private decimal _Resistivity = 0;
        internal decimal Resistivity
        {
            get { return _Resistivity; }
            set { _Resistivity = value; }
        }

        private decimal _Volume_Magnetic_Susceptibility = 0;
        internal decimal Volume_Magnetic_Susceptibility
        {
            get { return _Volume_Magnetic_Susceptibility; }
            set { _Volume_Magnetic_Susceptibility = value; }
        }

        private string _Allotropic_Multiplicities = "";
        internal string Allotropic_Multiplicities
        {
            get { return _Allotropic_Multiplicities; }
            set { _Allotropic_Multiplicities = value; }
        }

        private string _Electron_Affinity = "";
        internal string Electron_Affinity
        {
            get { return _Electron_Affinity; }
            set { _Electron_Affinity = value; }
        }

        private string _Electronegativity = "";
        internal string Electronegativity
        {
            get { return _Electronegativity; }
            set { _Electronegativity = value; }
        }

        private string _Gas_Atomic_Multiplicities = "";
        internal string Gas_Atomic_Multiplicities
        {
            get { return _Gas_Atomic_Multiplicities; }
            set { _Gas_Atomic_Multiplicities = value; }
        }

        private string _Valence = "";
        internal string Valence
        {
            get { return _Valence; }
            set { _Valence = value; }
        }

        private string _Crystal_Structure = "";
        internal string Crystal_Structure
        {
            get { return _Crystal_Structure; }
            set { _Crystal_Structure = value; }
        }

        private string _Lattice_Angles = "";
        internal string Lattice_Angles
        {
            get { return _Lattice_Angles; }
            set { _Lattice_Angles = value; }
        }

        private string _Lattice_Constants = "";
        internal string Lattice_Constants
        {
            get { return _Lattice_Constants; }
            set { _Lattice_Constants = value; }
        }

        private string _Space_Group_Number = "";
        internal string Space_Group_Number
        {
            get { return _Space_Group_Number; }
            set { _Space_Group_Number = value; }
        }

        private string _Space_Group_Name = "";
        internal string Space_Group_Name
        {
            get { return _Space_Group_Name; }
            set { _Space_Group_Name = value; }
        }

        private string _Atomic_Radius = "";
        internal string Atomic_Radius
        {
            get { return _Atomic_Radius; }
            set { _Atomic_Radius = value; }
        }

        private string _Covalent_Radius = "";
        internal string Covalent_Radius
        {
            get { return _Covalent_Radius; }
            set { _Covalent_Radius = value; }
        }

        private string _Electron_Configuration = "";
        internal string Electron_Configuration
        {
            get { return _Electron_Configuration; }
            set { _Electron_Configuration = value; }
        }

        private string _Electron_Configuration_String = "";
        internal string Electron_Configuration_String
        {
            get { return _Electron_Configuration_String; }
            set { _Electron_Configuration_String = value; }
        }

        private string _Electron_Shell_Configuration = "";
        internal string Electron_Shell_Configuration
        {
            get { return _Electron_Shell_Configuration; }
            set { _Electron_Shell_Configuration = value; }
        }

        private string _Ionization_Energies = "";
        internal string Ionization_Energies
        {
            get { return _Ionization_Energies; }
            set { _Ionization_Energies = value; }
        }

        private string _Quantum_Numbers = "";
        internal string Quantum_Numbers
        {
            get { return _Quantum_Numbers; }
            set { _Quantum_Numbers = value; }
        }

        private string _Van_Der_Waals_Radius = "";
        internal string Van_Der_Waals_Radius
        {
            get { return _Van_Der_Waals_Radius; }
            set { _Van_Der_Waals_Radius = value; }
        }

        private string _Decay_Mode = "";
        internal string Decay_Mode
        {
            get { return _Decay_Mode; }
            set { _Decay_Mode = value; }
        }

        private string _HalfLife = "";
        internal string HalfLife
        {
            get { return _HalfLife; }
            set { _HalfLife = value; }
        }

        private string _Isotope_Abundances = "";
        internal string Isotope_Abundances
        {
            get { return _Isotope_Abundances; }
            set { _Isotope_Abundances = value; }
        }

        private string _Known_Isotopes = "";
        internal string Known_Isotopes
        {
            get { return _Known_Isotopes; }
            set { _Known_Isotopes = value; }
        }

        private string _Lifetime = "";
        internal string Lifetime
        {
            get { return _Lifetime; }
            set { _Lifetime = value; }
        }

        private string _Neutron_Cross_Section = "";
        internal string Neutron_Cross_Section
        {
            get { return _Neutron_Cross_Section; }
            set { _Neutron_Cross_Section = value; }
        }

        private string _Neutron_Mass_Absorption = "";
        internal string Neutron_Mass_Absorption
        {
            get { return _Neutron_Mass_Absorption; }
            set { _Neutron_Mass_Absorption = value; }
        }

        private string _Radioactive = "";
        internal string Radioactive
        {
            get { return _Radioactive; }
            set { _Radioactive = value; }
        }

        private string _Stable_Isotopes = "";
        internal string Stable_Isotopes
        {
            get { return _Stable_Isotopes; }
            set { _Stable_Isotopes = value; }
        }

        private decimal _Crust_Abundance = 0;
        internal decimal Crust_Abundance
        {
            get { return _Crust_Abundance; }
            set { _Crust_Abundance = value; }
        }

        private decimal _Human_Abundance = 0;
        internal decimal Human_Abundance
        {
            get { return _Human_Abundance; }
            set { _Human_Abundance = value; }
        }

        private decimal _Meteorite_Abundance = 0;
        internal decimal Meteorite_Abundance
        {
            get { return _Meteorite_Abundance; }
            set { _Meteorite_Abundance = value; }
        }

        private decimal _Ocean_Abundance = 0;
        internal decimal Ocean_Abundance
        {
            get { return _Ocean_Abundance; }
            set { _Ocean_Abundance = value; }
        }

        private decimal _Solar_Abundance = 0;
        internal decimal Solar_Abundance
        {
            get { return _Solar_Abundance; }
            set { _Solar_Abundance = value; }
        }

        private decimal _Universe_Abundance = 0;
        internal decimal Universe_Abundance
        {
            get { return _Universe_Abundance; }
            set { _Universe_Abundance = value; }
        }

        private string _Radius_Empirical = "";
        internal string Radius_Empirical
        {
            get { return _Radius_Empirical; }
            set { _Radius_Empirical = value; }
        }

        private string _Radius_Calculated = "";
        internal string Radius_Calculated
        {
            get { return _Radius_Calculated; }
            set { _Radius_Calculated = value; }
        }

        private string _Radius_Van_Der_Waals = "";
        internal string Radius_Van_Der_Waals
        {
            get { return _Radius_Van_Der_Waals; }
            set { _Radius_Van_Der_Waals = value; }
        }

        private string _Radius_Covalent_Single_Bond = "";
        internal string Radius_Covalent_Single_Bond
        {
            get { return _Radius_Covalent_Single_Bond; }
            set { _Radius_Covalent_Single_Bond = value; }
        }

        private string _Radius_Covalent_Triple_Bond = "";
        internal string Radius_Covalent_Triple_Bond
        {
            get { return _Radius_Covalent_Triple_Bond; }
            set { _Radius_Covalent_Triple_Bond = value; }
        }

        private string _Radius_Metallic = "";
        internal string Radius_Metallic
        {
            get { return _Radius_Metallic; }
            set { _Radius_Metallic = value; }
        }

        private string _MaterialType;
        public string MaterialType
        {
            get { return _MaterialType; }
            set { _MaterialType = value; }
        }

    }
}