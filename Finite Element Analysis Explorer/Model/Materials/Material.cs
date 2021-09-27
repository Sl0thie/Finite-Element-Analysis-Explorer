namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Material class.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Material"/> class.
        /// </summary>
        public Material()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Material"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="cost">cost.</param>
        /// <param name="density">density.</param>
        /// <param name="ultimateStrengthTension">ultimateStrengthTension.</param>
        /// <param name="ultimateStrengthCompression">ultimateStrengthCompression.</param>
        /// <param name="ultimateStrengthShear">ultimateStrengthShear.</param>
        /// <param name="yieldStrengthTension">yieldStrengthTension.</param>
        /// <param name="yieldStrengthShear">yieldStrengthShear.</param>
        /// <param name="modulusOfElasticity">modulusOfElasticity.</param>
        /// <param name="modulusOfRigidity">modulusOfRigidity.</param>
        /// <param name="coefficientOfThermalExpansion">coefficientOfThermalExpansion.</param>
        /// <param name="ductility">ductility.</param>
        /// <param name="atomic_Number">atomic_Number.</param>
        /// <param name="symbol">symbol.</param>
        /// <param name="atomic_Mass">atomic_Mass.</param>
        /// <param name="allotrope_Names">allotrope_Names.</param>
        /// <param name="alternate_Names">alternate_Names.</param>
        /// <param name="cAS_Number">cAS_Number.</param>
        /// <param name="icon_Color">icon_Color.</param>
        /// <param name="block">block.</param>
        /// <param name="group">group.</param>
        /// <param name="period">period.</param>
        /// <param name="series">series.</param>
        /// <param name="atomic_Weight">atomic_Weight.</param>
        /// <param name="brinell_Hardness">brinell_Hardness.</param>
        /// <param name="bulk_Modulus">bulk_Modulus.</param>
        /// <param name="liquid_Density">liquid_Density.</param>
        /// <param name="mohs_Hardness">mohs_Hardness.</param>
        /// <param name="molar_Volume">molar_Volume.</param>
        /// <param name="poission_Ratio">poission_Ratio.</param>
        /// <param name="shear_Modulus">shear_Modulus.</param>
        /// <param name="sound_Speed">sound_Speed.</param>
        /// <param name="thermal_Conductivity">thermal_Conductivity.</param>
        /// <param name="thermal_Expansion">thermal_Expansion.</param>
        /// <param name="vickers_Hardness">vickers_Hardness.</param>
        /// <param name="young_Modulus">young_Modulus.</param>
        /// <param name="absolute_Boiling_Point">absolute_Boiling_Point.</param>
        /// <param name="absolute_Melting_Point">absolute_Melting_Point.</param>
        /// <param name="adiabatic_Index">adiabatic_Index.</param>
        /// <param name="boiling_Point">boiling_Point.</param>
        /// <param name="critical_Pressure">critical_Pressure.</param>
        /// <param name="critical_Temperature">critical_Temperature.</param>
        /// <param name="curie_Point">curie_Point.</param>
        /// <param name="fusion_Heat">fusion_Heat.</param>
        /// <param name="melting_Point">melting_Point.</param>
        /// <param name="neel_Point">neel_Point.</param>
        /// <param name="phase">phase.</param>
        /// <param name="specific_Heat">specific_Heat.</param>
        /// <param name="superconducting_Point">superconducting_Point.</param>
        /// <param name="vaporization_Heat">vaporization_Heat.</param>
        /// <param name="color">color.</param>
        /// <param name="electrical_Conductivity">electrical_Conductivity.</param>
        /// <param name="electrical_Type">electrical_Type.</param>
        /// <param name="magnetic_Type">magnetic_Type.</param>
        /// <param name="mass_Magnetic_Susceptibility">mass_Magnetic_Susceptibility.</param>
        /// <param name="molar_Magnetic_Susceptibility">molar_Magnetic_Susceptibility.</param>
        /// <param name="refractive_Index">refractive_Index.</param>
        /// <param name="resistivity">resistivity.</param>
        /// <param name="volume_Magnetic_Susceptibility">volume_Magnetic_Susceptibility.</param>
        /// <param name="allotropic_Multiplicities">allotropic_Multiplicities.</param>
        /// <param name="electron_Affinity">electron_Affinity.</param>
        /// <param name="electronegativity">electro-negativity.</param>
        /// <param name="gas_Atomic_Multiplicities">gas_Atomic_Multiplicities.</param>
        /// <param name="valence">valence.</param>
        /// <param name="crystal_Structure">crystal_Structure.</param>
        /// <param name="lattice_Angles">lattice_Angles.</param>
        /// <param name="lattice_Constants">lattice_Constants.</param>
        /// <param name="space_Group_Number">space_Group_Number.</param>
        /// <param name="space_Group_Name">space_Group_Name.</param>
        /// <param name="atomic_Radius">atomic_Radius.</param>
        /// <param name="covalent_Radius">covalent_Radius.</param>
        /// <param name="electron_Configuration">electron_Configuration.</param>
        /// <param name="electron_Configuration_String">electron_Configuration_String.</param>
        /// <param name="electron_Shell_Configuration">electron_Shell_Configuration.</param>
        /// <param name="ionization_Energies">ionization_Energies.</param>
        /// <param name="quantum_Numbers">quantum_Numbers.</param>
        /// <param name="van_Der_Waals_Radius">van_Der_Waals_Radius.</param>
        /// <param name="decay_Mode">decay_Mode.</param>
        /// <param name="halfLife">halfLife.</param>
        /// <param name="isotope_Abundances">isotope_Abundances.</param>
        /// <param name="known_Isotopes">known_Isotopes.</param>
        /// <param name="lifetime">lifetime.</param>
        /// <param name="neutron_Cross_Section">neutron_Cross_Section.</param>
        /// <param name="neutron_Mass_Absorption">neutron_Mass_Absorption.</param>
        /// <param name="radioactive">radioactive.</param>
        /// <param name="stable_Isotopes">stable_Isotopes.</param>
        /// <param name="crust_Abundance">crust_Abundance.</param>
        /// <param name="human_Abundance">human_Abundance.</param>
        /// <param name="meteorite_Abundance">meteorite_Abundance.</param>
        /// <param name="ocean_Abundance">ocean_Abundance.</param>
        /// <param name="solar_Abundance">solar_Abundance.</param>
        /// <param name="universe_Abundance">universe_Abundance.</param>
        /// <param name="radius_Empirical">radius_Empirical.</param>
        /// <param name="radius_Calculated">radius_Calculated.</param>
        /// <param name="radius_Van_Der_Waals">radius_Van_Der_Waals.</param>
        /// <param name="radius_Covalent_Single_Bond">radius_Covalent_Single_Bond.</param>
        /// <param name="radius_Covalent_Triple_Bond">radius_Covalent_Triple_Bond.</param>
        /// <param name="radius_Metallic">radius_Metallic.</param>
        /// <param name="materialType">materialType.</param>
        public Material(
            string name,
            string description,
            decimal cost,
            decimal density,
            decimal ultimateStrengthTension,
            decimal ultimateStrengthCompression,
            decimal ultimateStrengthShear,
            decimal yieldStrengthTension,
            decimal yieldStrengthShear,
            decimal modulusOfElasticity,
            decimal modulusOfRigidity,
            decimal coefficientOfThermalExpansion,
            decimal ductility,
            int atomic_Number,
            string symbol,
            decimal atomic_Mass,
            string allotrope_Names,
            string alternate_Names,
            string cAS_Number,
            string icon_Color,
            string block,
            string group,
            string period,
            string series,
            decimal atomic_Weight,
            decimal brinell_Hardness,
            decimal bulk_Modulus,
            decimal liquid_Density,
            decimal mohs_Hardness,
            decimal molar_Volume,
            decimal poission_Ratio,
            decimal shear_Modulus,
            decimal sound_Speed,
            decimal thermal_Conductivity,
            decimal thermal_Expansion,
            decimal vickers_Hardness,
            decimal young_Modulus,
            decimal absolute_Boiling_Point,
            decimal absolute_Melting_Point,
            decimal adiabatic_Index,
            decimal boiling_Point,
            decimal critical_Pressure,
            decimal critical_Temperature,
            decimal curie_Point,
            decimal fusion_Heat,
            decimal melting_Point,
            decimal neel_Point,
            string phase,
            decimal specific_Heat,
            decimal superconducting_Point,
            decimal vaporization_Heat,
            string color,
            decimal electrical_Conductivity,
            string electrical_Type,
            string magnetic_Type,
            decimal mass_Magnetic_Susceptibility,
            decimal molar_Magnetic_Susceptibility,
            decimal refractive_Index,
            decimal resistivity,
            decimal volume_Magnetic_Susceptibility,
            string allotropic_Multiplicities,
            string electron_Affinity,
            string electronegativity,
            string gas_Atomic_Multiplicities,
            string valence,
            string crystal_Structure,
            string lattice_Angles,
            string lattice_Constants,
            string space_Group_Number,
            string space_Group_Name,
            string atomic_Radius,
            string covalent_Radius,
            string electron_Configuration,
            string electron_Configuration_String,
            string electron_Shell_Configuration,
            string ionization_Energies,
            string quantum_Numbers,
            string van_Der_Waals_Radius,
            string decay_Mode,
            string halfLife,
            string isotope_Abundances,
            string known_Isotopes,
            string lifetime,
            string neutron_Cross_Section,
            string neutron_Mass_Absorption,
            string radioactive,
            string stable_Isotopes,
            decimal crust_Abundance,
            decimal human_Abundance,
            decimal meteorite_Abundance,
            decimal ocean_Abundance,
            decimal solar_Abundance,
            decimal universe_Abundance,
            string radius_Empirical,
            string radius_Calculated,
            string radius_Van_Der_Waals,
            string radius_Covalent_Single_Bond,
            string radius_Covalent_Triple_Bond,
            string radius_Metallic,
            string materialType)
        {
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.density = density;
            this.ultimateStrengthTension = ultimateStrengthTension;
            this.ultimateStrengthCompression = ultimateStrengthCompression;
            this.ultimateStrengthShear = ultimateStrengthShear;
            this.yieldStrengthTension = yieldStrengthTension;
            this.yieldStrengthShear = yieldStrengthShear;
            this.modulusOfElasticity = modulusOfElasticity;
            this.modulusOfRigidity = modulusOfRigidity;
            this.coefficientOfThermalExpansion = coefficientOfThermalExpansion;
            this.ductility = ductility;
            Atomic_Number = atomic_Number;
            Symbol = symbol;
            Atomic_Mass = atomic_Mass;
            Allotrope_Names = allotrope_Names;
            Alternate_Names = alternate_Names;
            CAS_Number = cAS_Number;
            Icon_Color = icon_Color;
            Block = block;
            Group = group;
            Period = period;
            Series = series;
            Atomic_Weight = atomic_Weight;
            Brinell_Hardness = brinell_Hardness;
            Bulk_Modulus = bulk_Modulus;
            Liquid_Density = liquid_Density;
            Mohs_Hardness = mohs_Hardness;
            Molar_Volume = molar_Volume;
            Poission_Ratio = poission_Ratio;
            ModulusOfRigidity = shear_Modulus;
            Sound_Speed = sound_Speed;
            Thermal_Conductivity = thermal_Conductivity;
            Thermal_Expansion = thermal_Expansion;
            Vickers_Hardness = vickers_Hardness;
            ModulusOfElasticity = young_Modulus;
            Absolute_Boiling_Point = absolute_Boiling_Point;
            Absolute_Melting_Point = absolute_Melting_Point;
            Adiabatic_Index = adiabatic_Index;
            Boiling_Point = boiling_Point;
            Critical_Pressure = critical_Pressure;
            Critical_Temperature = critical_Temperature;
            Curie_Point = curie_Point;
            Fusion_Heat = fusion_Heat;
            Melting_Point = melting_Point;
            Neel_Point = neel_Point;
            Phase = phase;
            Specific_Heat = specific_Heat;
            Superconducting_Point = superconducting_Point;
            Vaporization_Heat = vaporization_Heat;
            Color = color;
            Electrical_Conductivity = electrical_Conductivity;
            Electrical_Type = electrical_Type;
            Magnetic_Type = magnetic_Type;
            Mass_Magnetic_Susceptibility = mass_Magnetic_Susceptibility;
            Molar_Magnetic_Susceptibility = molar_Magnetic_Susceptibility;
            Refractive_Index = refractive_Index;
            Resistivity = resistivity;
            Volume_Magnetic_Susceptibility = volume_Magnetic_Susceptibility;
            Allotropic_Multiplicities = allotropic_Multiplicities;
            Electron_Affinity = electron_Affinity;
            Electronegativity = electronegativity;
            Gas_Atomic_Multiplicities = gas_Atomic_Multiplicities;
            Valence = valence;
            Crystal_Structure = crystal_Structure;
            Lattice_Angles = lattice_Angles;
            Lattice_Constants = lattice_Constants;
            Space_Group_Number = space_Group_Number;
            Space_Group_Name = space_Group_Name;
            Atomic_Radius = atomic_Radius;
            Covalent_Radius = covalent_Radius;
            Electron_Configuration = electron_Configuration;
            Electron_Configuration_String = electron_Configuration_String;
            Electron_Shell_Configuration = electron_Shell_Configuration;
            Ionization_Energies = ionization_Energies;
            Quantum_Numbers = quantum_Numbers;
            Van_Der_Waals_Radius = van_Der_Waals_Radius;
            Decay_Mode = decay_Mode;
            HalfLife = halfLife;
            Isotope_Abundances = isotope_Abundances;
            Known_Isotopes = known_Isotopes;
            Lifetime = lifetime;
            Neutron_Cross_Section = neutron_Cross_Section;
            Neutron_Mass_Absorption = neutron_Mass_Absorption;
            Radioactive = radioactive;
            Stable_Isotopes = stable_Isotopes;
            Crust_Abundance = crust_Abundance;
            Human_Abundance = human_Abundance;
            Meteorite_Abundance = meteorite_Abundance;
            Ocean_Abundance = ocean_Abundance;
            Solar_Abundance = solar_Abundance;
            Universe_Abundance = universe_Abundance;
            Radius_Empirical = radius_Empirical;
            Radius_Calculated = radius_Calculated;
            Radius_Van_Der_Waals = radius_Van_Der_Waals;
            Radius_Covalent_Single_Bond = radius_Covalent_Single_Bond;
            Radius_Covalent_Triple_Bond = radius_Covalent_Triple_Bond;
            Radius_Metallic = radius_Metallic;
            MaterialType = materialType;
        }

        #region Added

        private string name;

        /// <summary>
        /// Gets or sets the name of the material.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private string description = string.Empty;

        /// <summary>
        /// Gets or sets the description of the material.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        private decimal cost = 0;

        /// <summary>
        /// Gets or sets the cost of the material.
        /// </summary>
        public decimal Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }

        private decimal density = 0;

        /// <summary>
        /// Gets or sets the density of the material.
        /// </summary>
        public decimal Density
        {
            get
            {
                return density;
            }

            set
            {
                density = value;
            }
        }

        private decimal ultimateStrengthTension = 0;

        /// <summary>
        /// Gets or sets the ultimate strength tension.
        /// </summary>
        public decimal UltimateStrengthTension
        {
            get
            {
                return ultimateStrengthTension;
            }

            set
            {
                ultimateStrengthTension = value;
            }
        }

        private decimal ultimateStrengthCompression = 0;

        /// <summary>
        /// Gets or sets the ultimate strength compression.
        /// </summary>
        public decimal UltimateStrengthCompression
        {
            get
            {
                return ultimateStrengthCompression;
            }

            set
            {
                ultimateStrengthCompression = value;
            }
        }

        private decimal ultimateStrengthShear = 0;

        /// <summary>
        /// Gets or sets the ultimate strength shear.
        /// </summary>
        public decimal UltimateStrengthShear
        {
            get
            {
                return ultimateStrengthShear;
            }

            set
            {
                ultimateStrengthShear = value;
            }
        }

        private decimal yieldStrengthTension = 0;

        /// <summary>
        /// Gets or sets the yield strength tension.
        /// </summary>
        public decimal YieldStrengthTension
        {
            get
            {
                return yieldStrengthTension;
            }

            set
            {
                yieldStrengthTension = value;
            }
        }

        private decimal yieldStrengthShear = 0;

        /// <summary>
        /// Gets or sets the yield strength shear.
        /// </summary>
        public decimal YieldStrengthShear
        {
            get
            {
                return yieldStrengthShear;
            }

            set
            {
                yieldStrengthShear = value;
            }
        }

        private decimal modulusOfElasticity = 0;

        /// <summary>
        /// Gets or sets the Modulus of Elasticity (E) or Young's Modulus.
        /// </summary>
        public decimal ModulusOfElasticity
        {
            get
            {
                return modulusOfElasticity;
            }

            set
            {
                modulusOfElasticity = value;
            }
        }

        private decimal modulusOfRigidity = 0;

        /// <summary>
        /// Gets or sets the Modulus of Rigidity (G).
        /// .
        /// G = E/2(1+v).
        /// E = 2G(1+v).
        /// </summary>
        public decimal ModulusOfRigidity
        {
            get
            {
                return modulusOfRigidity;
            }

            set
            {
                modulusOfRigidity = value;
            }
        }

        private decimal bulkModulus = 0;

        /// <summary>
        /// Gets or sets the Bulk Modulus (K).
        /// Ability to resist compression.
        ///
        /// Relation Equation E = 3K(1-2v).
        ///                   K = E/3(1-2v).
        /// </summary>
        internal decimal Bulk_Modulus
        {
            get { return bulkModulus; }
            set { bulkModulus = value; }
        }

        private decimal coefficientOfThermalExpansion = 0;

        /// <summary>
        /// Gets or sets the co-efficient of thermal expansion.
        /// </summary>
        public decimal CoefficientOfThermalExpansion
        {
            get
            {
                return coefficientOfThermalExpansion;
            }

            set
            {
                coefficientOfThermalExpansion = value;
            }
        }

        private decimal ductility = 0;

        /// <summary>
        /// Gets or sets the ductility.
        /// </summary>
        public decimal Ductility
        {
            get
            {
                return ductility;
            }

            set
            {
                ductility = value;
            }
        }

        #endregion

        private int atomicNumber = 0;

        /// <summary>
        /// Gets or sets the atomic number.
        /// </summary>
        internal int Atomic_Number
        {
            get
            {
                return atomicNumber;
            }

            set
            {
                atomicNumber = value;
            }
        }

        private string symbol = string.Empty;

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        internal string Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
            }
        }

        private decimal atomicMass = 0;

        /// <summary>
        /// Gets or sets the atomic mass.
        /// </summary>
        internal decimal Atomic_Mass
        {
            get
            {
                return atomicMass;
            }

            set
            {
                atomicMass = value;
            }
        }

        private string allotropeNames = string.Empty;

        /// <summary>
        /// Gets or sets the allotrope names.
        /// </summary>
        internal string Allotrope_Names
        {
            get
            {
                return allotropeNames;
            }

            set
            {
                allotropeNames = value;
            }
        }

        private string alternateNames = string.Empty;

        /// <summary>
        /// Gets or sets the alternate names.
        /// </summary>
        internal string Alternate_Names
        {
            get
            {
                return alternateNames;
            }

            set
            {
                alternateNames = value;
            }
        }

        private string cASNumber = string.Empty;

        /// <summary>
        /// Gets or sets the CAS number.
        /// </summary>
        internal string CAS_Number
        {
            get
            {
                return cASNumber;
            }

            set
            {
                cASNumber = value;
            }
        }

        private string iconColor = string.Empty;

        /// <summary>
        /// Gets or sets the icon color.
        /// </summary>
        internal string Icon_Color
        {
            get
            {
                return iconColor;
            }

            set
            {
                iconColor = value;
            }
        }

        private string block = string.Empty;

        /// <summary>
        /// Gets or sets the block.
        /// </summary>
        internal string Block
        {
            get
            {
                return block;
            }

            set
            {
                block = value;
            }
        }

        private string group = string.Empty;

        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        internal string Group
        {
            get
            {
                return group;
            }

            set
            {
                group = value;
            }
        }

        private string period = string.Empty;

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        internal string Period
        {
            get
            {
                return period;
            }

            set
            {
                period = value;
            }
        }

        private string series = string.Empty;

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        internal string Series
        {
            get
            {
                return series;
            }

            set
            {
                series = value;
            }
        }

        private decimal atomicWeight = 0;

        /// <summary>
        /// Gets or sets the atomic weight.
        /// </summary>
        internal decimal Atomic_Weight
        {
            get
            {
                return atomicWeight;
            }

            set
            {
                atomicWeight = value;
            }
        }

        private decimal brinellHardness = 0;

        /// <summary>
        /// Gets or sets the Brinell hardness.
        /// </summary>
        internal decimal Brinell_Hardness
        {
            get
            {
                return brinellHardness;
            }

            set
            {
                brinellHardness = value;
            }
        }

        private decimal liquidDensity = 0;

        /// <summary>
        /// Gets or sets the liquid density.
        /// </summary>
        internal decimal Liquid_Density
        {
            get
            {
                return liquidDensity;
            }

            set
            {
                liquidDensity = value;
            }
        }

        private decimal mohsHardness = 0;

        /// <summary>
        /// Gets or sets the Mohs hardness.
        /// </summary>
        internal decimal Mohs_Hardness
        {
            get
            {
                return mohsHardness;
            }

            set
            {
                mohsHardness = value;
            }
        }

        private decimal molarVolume = 0;

        /// <summary>
        /// Gets or sets the molar volume.
        /// </summary>
        internal decimal Molar_Volume
        {
            get
            {
                return molarVolume;
            }

            set
            {
                molarVolume = value;
            }
        }

        private decimal poissionRatio = 0;

        /// <summary>
        /// Gets or sets the Poission ration.
        /// </summary>
        internal decimal Poission_Ratio
        {
            get
            {
                return poissionRatio;
            }

            set
            {
                poissionRatio = value;
            }
        }

        private decimal soundSpeed = 0;

        /// <summary>
        /// Gets or sets the sound speed.
        /// </summary>
        internal decimal Sound_Speed
        {
            get
            {
                return soundSpeed;
            }

            set
            {
                soundSpeed = value;
            }
        }

        private decimal thermalConductivity = 0;

        /// <summary>
        /// Gets or sets the thermal conductivity.
        /// </summary>
        internal decimal Thermal_Conductivity
        {
            get
            {
                return thermalConductivity;
            }

            set
            {
                thermalConductivity = value;
            }
        }

        private decimal thermalExpansion = 0;

        /// <summary>
        /// Gets or sets the thermal expansion.
        /// </summary>
        internal decimal Thermal_Expansion
        {
            get
            {
                return thermalExpansion;
            }

            set
            {
                thermalExpansion = value;
            }
        }

        private decimal vickersHardness = 0;

        /// <summary>
        /// Gets or sets the Vickers hardness.
        /// </summary>
        internal decimal Vickers_Hardness
        {
            get
            {
                return vickersHardness;
            }

            set
            {
                vickersHardness = value;
            }
        }

        private decimal absoluteBoilingPoint = 0;

        /// <summary>
        /// Gets or sets the absolute boiling point.
        /// </summary>
        internal decimal Absolute_Boiling_Point
        {
            get
            {
                return absoluteBoilingPoint;
            }

            set
            {
                absoluteBoilingPoint = value;
            }
        }

        private decimal absoluteMeltingPoint = 0;

        /// <summary>
        /// Gets or sets the absolute melting point.
        /// </summary>
        internal decimal Absolute_Melting_Point
        {
            get
            {
                return absoluteMeltingPoint;
            }

            set
            {
                absoluteMeltingPoint = value;
            }
        }

        private decimal adiabaticIndex = 0;

        /// <summary>
        /// Gets or sets the adiabatic index.
        /// </summary>
        internal decimal Adiabatic_Index
        {
            get
            {
                return adiabaticIndex;
            }

            set
            {
                adiabaticIndex = value;
            }
        }

        private decimal boilingPoint = 0;

        /// <summary>
        /// Gets or sets the boiling point.
        /// </summary>
        internal decimal Boiling_Point
        {
            get
            {
                return boilingPoint;
            }

            set
            {
                boilingPoint = value;
            }
        }

        private decimal criticalPressure = 0;

        /// <summary>
        /// Gets or sets the critical pressure.
        /// </summary>
        internal decimal Critical_Pressure
        {
            get
            {
                return criticalPressure;
            }

            set
            {
                criticalPressure = value;
            }
        }

        private decimal criticalTemperature = 0;

        /// <summary>
        /// Gets or sets the critical temperature.
        /// </summary>
        internal decimal Critical_Temperature
        {
            get
            {
                return criticalTemperature;
            }

            set
            {
                criticalTemperature = value;
            }
        }

        private decimal curiePoint = 0;

        /// <summary>
        /// Gets or sets the Curie point.
        /// </summary>
        internal decimal Curie_Point
        {
            get
            {
                return curiePoint;
            }

            set
            {
                curiePoint = value;
            }
        }

        private decimal fusionHeat = 0;

        /// <summary>
        /// Gets or sets the fusion heat.
        /// </summary>
        internal decimal Fusion_Heat
        {
            get
            {
                return fusionHeat;
            }

            set
            {
                fusionHeat = value;
            }
        }

        private decimal meltingPoint = 0;

        /// <summary>
        /// Gets or sets the melting point.
        /// </summary>
        internal decimal Melting_Point
        {
            get
            {
                return meltingPoint;
            }

            set
            {
                meltingPoint = value;
            }
        }

        private decimal neelPoint = 0;

        /// <summary>
        /// Gets or sets the neel point.
        /// </summary>
        internal decimal Neel_Point
        {
            get
            {
                return neelPoint;
            }

            set
            {
                neelPoint = value;
            }
        }

        private string phase = string.Empty;

        /// <summary>
        /// Gets or sets the phase.
        /// </summary>
        internal string Phase
        {
            get
            {
                return phase;
            }

            set
            {
                phase = value;
            }
        }

        private decimal specificHeat = 0;

        /// <summary>
        /// Gets or sets the specific heat.
        /// </summary>
        internal decimal Specific_Heat
        {
            get
            {
                return specificHeat;
            }

            set
            {
                specificHeat = value;
            }
        }

        private decimal superconductingPoint = 0;

        /// <summary>
        /// Gets or sets the superconducting point.
        /// </summary>
        internal decimal Superconducting_Point
        {
            get
            {
                return superconductingPoint;
            }

            set
            {
                superconductingPoint = value;
            }
        }

        private decimal vaporizationHeat = 0;

        /// <summary>
        /// Gets or sets the vaporization heat.
        /// </summary>
        internal decimal Vaporization_Heat
        {
            get
            {
                return vaporizationHeat;
            }

            set
            {
                vaporizationHeat = value;
            }
        }

        private string color = string.Empty;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        internal string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        private decimal electricalConductivity = 0;

        /// <summary>
        /// Gets or sets the electrical conductivity.
        /// </summary>
        internal decimal Electrical_Conductivity
        {
            get
            {
                return electricalConductivity;
            }

            set
            {
                electricalConductivity = value;
            }
        }

        private string electricalType = string.Empty;

        /// <summary>
        /// Gets or sets the electrical type.
        /// </summary>
        internal string Electrical_Type
        {
            get
            {
                return electricalType;
            }

            set
            {
                electricalType = value;
            }
        }

        private string magneticType = string.Empty;

        /// <summary>
        /// Gets or sets the magnetic type.
        /// </summary>
        internal string Magnetic_Type
        {
            get
            {
                return magneticType;
            }

            set
            {
                magneticType = value;
            }
        }

        private decimal massMagneticSusceptibility = 0;

        /// <summary>
        /// Gets or sets mass magnetic susceptibility.
        /// </summary>
        internal decimal Mass_Magnetic_Susceptibility
        {
            get
            {
                return massMagneticSusceptibility;
            }

            set
            {
                massMagneticSusceptibility = value;
            }
        }

        private decimal molarMagneticSusceptibility = 0;

        /// <summary>
        /// Gets or sets the Molor magnetic susceptibility.
        /// </summary>
        internal decimal Molar_Magnetic_Susceptibility
        {
            get
            {
                return molarMagneticSusceptibility;
            }

            set
            {
                molarMagneticSusceptibility = value;
            }
        }

        private decimal refractiveIndex = 0;

        /// <summary>
        /// Gets or sets the refractive index.
        /// </summary>
        internal decimal Refractive_Index
        {
            get
            {
                return refractiveIndex;
            }

            set
            {
                refractiveIndex = value;
            }
        }

        private decimal resistivity = 0;

        /// <summary>
        /// Gets or sets the resistivity.
        /// </summary>
        internal decimal Resistivity
        {
            get
            {
                return resistivity;
            }

            set
            {
                resistivity = value;
            }
        }

        private decimal volumeMagneticSusceptibility = 0;

        /// <summary>
        /// Gets or sets the volume magnetic susceptibility.
        /// </summary>
        internal decimal Volume_Magnetic_Susceptibility
        {
            get
            {
                return volumeMagneticSusceptibility;
            }

            set
            {
                volumeMagneticSusceptibility = value;
            }
        }

        private string allotropicMultiplicities = string.Empty;

        /// <summary>
        /// Gets or sets the allotropic multiplicities.
        /// </summary>
        internal string Allotropic_Multiplicities
        {
            get
            {
                return allotropicMultiplicities;
            }

            set
            {
                allotropicMultiplicities = value;
            }
        }

        private string electronAffinity = string.Empty;

        /// <summary>
        /// Gets or sets the electron affinity.
        /// </summary>
        internal string Electron_Affinity
        {
            get
            {
                return electronAffinity;
            }

            set
            {
                electronAffinity = value;
            }
        }

        private string electronegativity = string.Empty;

        /// <summary>
        /// Gets or sets the elctronegativity.
        /// </summary>
        internal string Electronegativity
        {
            get
            {
                return electronegativity;
            }

            set
            {
                electronegativity = value;
            }
        }

        private string gasAtomicMultiplicities = string.Empty;

        /// <summary>
        /// Gets or sets the gas atomic multiplicities.
        /// </summary>
        internal string Gas_Atomic_Multiplicities
        {
            get
            {
                return gasAtomicMultiplicities;
            }

            set
            {
                gasAtomicMultiplicities = value;
            }
        }

        private string valence = string.Empty;

        /// <summary>
        /// Gets or sets the valence.
        /// </summary>
        internal string Valence
        {
            get
            {
                return valence;
            }

            set
            {
                valence = value;
            }
        }

        private string crystalStructure = string.Empty;

        /// <summary>
        /// Gets or sets the crystal structure.
        /// </summary>
        internal string Crystal_Structure
        {
            get
            {
                return crystalStructure;
            }

            set
            {
                crystalStructure = value;
            }
        }

        private string latticeAngles = string.Empty;

        /// <summary>
        /// Gets or sets the lattice angles.
        /// </summary>
        internal string Lattice_Angles
        {
            get
            {
                return latticeAngles;
            }

            set
            {
                latticeAngles = value;
            }
        }

        private string latticeConstants = string.Empty;

        /// <summary>
        /// Gets or sets the lattice constants.
        /// </summary>
        internal string Lattice_Constants
        {
            get
            {
                return latticeConstants;
            }

            set
            {
                latticeConstants = value;
            }
        }

        private string spaceGroupNumber = string.Empty;

        /// <summary>
        /// Gets or sets the space group number.
        /// </summary>
        internal string Space_Group_Number
        {
            get
            {
                return spaceGroupNumber;
            }

            set
            {
                spaceGroupNumber = value;
            }
        }

        private string spaceGroupName = string.Empty;

        /// <summary>
        /// Gets or sets the space group name.
        /// </summary>
        internal string Space_Group_Name
        {
            get
            {
                return spaceGroupName;
            }

            set
            {
                spaceGroupName = value;
            }
        }

        private string atomicRadius = string.Empty;

        /// <summary>
        /// Gets or sets the atomic radius.
        /// </summary>
        internal string Atomic_Radius
        {
            get
            {
                return atomicRadius;
            }

            set
            {
                atomicRadius = value;
            }
        }

        private string covalentRadius = string.Empty;

        /// <summary>
        /// Gets or sets the covalent radius.
        /// </summary>
        internal string Covalent_Radius
        {
            get
            {
                return covalentRadius;
            }

            set
            {
                covalentRadius = value;
            }
        }

        private string electronConfiguration = string.Empty;

        /// <summary>
        /// Gets or sets the electron configuration.
        /// </summary>
        internal string Electron_Configuration
        {
            get
            {
                return electronConfiguration;
            }

            set
            {
                electronConfiguration = value;
            }
        }

        private string electronConfigurationString = string.Empty;

        /// <summary>
        /// Gets or sets the electron configuration string.
        /// </summary>
        internal string Electron_Configuration_String
        {
            get
            {
                return electronConfigurationString;
            }

            set
            {
                electronConfigurationString = value;
            }
        }

        private string electronShellConfiguration = string.Empty;

        /// <summary>
        /// Gets or sets the electron shell configuration.
        /// </summary>
        internal string Electron_Shell_Configuration
        {
            get
            {
                return electronShellConfiguration;
            }

            set
            {
                electronShellConfiguration = value;
            }
        }

        private string ionizationEnergies = string.Empty;

        /// <summary>
        /// Gets or sets the ionization energies.
        /// </summary>
        internal string Ionization_Energies
        {
            get
            {
                return ionizationEnergies;
            }

            set
            {
                ionizationEnergies = value;
            }
        }

        private string quantumNumbers = string.Empty;

        /// <summary>
        /// Gets or sets the quantum numbers.
        /// </summary>
        internal string Quantum_Numbers
        {
            get
            {
                return quantumNumbers;
            }

            set
            {
                quantumNumbers = value;
            }
        }

        private string vanDerWaalsRadius = string.Empty;

        /// <summary>
        /// Gets or sets the van der walls radius.
        /// </summary>
        internal string Van_Der_Waals_Radius
        {
            get
            {
                return vanDerWaalsRadius;
            }

            set
            {
                vanDerWaalsRadius = value;
            }
        }

        private string decayMode = string.Empty;

        /// <summary>
        /// Gets or sets the decay mode.
        /// </summary>
        internal string Decay_Mode
        {
            get
            {
                return decayMode;
            }

            set
            {
                decayMode = value;
            }
        }

        private string halfLife = string.Empty;

        /// <summary>
        /// Gets or sets the half-life.
        /// </summary>
        internal string HalfLife
        {
            get
            {
                return halfLife;
            }

            set
            {
                halfLife = value;
            }
        }

        private string isotopeAbundances = string.Empty;

        /// <summary>
        /// Gets or sets the isotope abundance.
        /// </summary>
        internal string Isotope_Abundances
        {
            get
            {
                return isotopeAbundances;
            }

            set
            {
                isotopeAbundances = value;
            }
        }

        private string knownIsotopes = string.Empty;

        /// <summary>
        /// Gets or sets the known isotopes.
        /// </summary>
        internal string Known_Isotopes
        {
            get
            {
                return knownIsotopes;
            }

            set
            {
                knownIsotopes = value;
            }
        }

        private string lifetime = string.Empty;

        /// <summary>
        /// Gets or sets the lifetime.
        /// </summary>
        internal string Lifetime
        {
            get
            {
                return lifetime;
            }

            set
            {
                lifetime = value;
            }
        }

        private string neutronCrossSection = string.Empty;

        /// <summary>
        /// Gets or sets the neutron mass absorption.
        /// </summary>
        internal string Neutron_Cross_Section
        {
            get
            {
                return neutronCrossSection;
            }

            set
            {
                neutronCrossSection = value;
            }
        }

        private string neutronMassAbsorption = string.Empty;

        /// <summary>
        /// Gets or sets the neutron mass absorption.
        /// </summary>
        internal string Neutron_Mass_Absorption
        {
            get
            {
                return neutronMassAbsorption;
            }

            set
            {
                neutronMassAbsorption = value;
            }
        }

        private string radioactive = string.Empty;

        /// <summary>
        /// Gets or sets the radioactive.
        /// </summary>
        internal string Radioactive
        {
            get
            {
                return radioactive;
            }

            set
            {
                radioactive = value;
            }
        }

        private string stableIsotopes = string.Empty;

        /// <summary>
        /// Gets or sets the stable isotopes.
        /// </summary>
        internal string Stable_Isotopes
        {
            get
            {
                return stableIsotopes;
            }

            set
            {
                stableIsotopes = value;
            }
        }

        private decimal crustAbundance = 0;

        /// <summary>
        /// Gets or sets the crust abundance.
        /// </summary>
        internal decimal Crust_Abundance
        {
            get
            {
                return crustAbundance;
            }

            set
            {
                crustAbundance = value;
            }
        }

        private decimal humanAbundance = 0;

        /// <summary>
        /// Gets or sets the human abundance.
        /// </summary>
        internal decimal Human_Abundance
        {
            get
            {
                return humanAbundance;
            }

            set
            {
                humanAbundance = value;
            }
        }

        private decimal meteoriteAbundance = 0;

        /// <summary>
        /// Gets or sets the meteorite abundance.
        /// </summary>
        internal decimal Meteorite_Abundance
        {
            get
            {
                return meteoriteAbundance;
            }

            set
            {
                meteoriteAbundance = value;
            }
        }

        private decimal oceanAbundance = 0;

        /// <summary>
        /// Gets or sets the ocean abundance.
        /// </summary>
        internal decimal Ocean_Abundance
        {
            get
            {
                return oceanAbundance;
            }

            set
            {
                oceanAbundance = value;
            }
        }

        private decimal solarAbundance = 0;

        /// <summary>
        /// Gets or sets the solar abundance.
        /// </summary>
        internal decimal Solar_Abundance
        {
            get
            {
                return solarAbundance;
            }

            set
            {
                solarAbundance = value;
            }
        }

        private decimal universeAbundance = 0;

        /// <summary>
        /// Gets or sets the universe abundance.
        /// </summary>
        internal decimal Universe_Abundance
        {
            get
            {
                return universeAbundance;
            }

            set
            {
                universeAbundance = value;
            }
        }

        private string radiusEmpirical = string.Empty;

        /// <summary>
        /// Gets or sets the radius empirical.
        /// </summary>
        internal string Radius_Empirical
        {
            get
            {
                return radiusEmpirical;
            }

            set
            {
                radiusEmpirical = value;
            }
        }

        private string radiusCalculated = string.Empty;

        /// <summary>
        /// Gets or sets the radius calculated.
        /// </summary>
        internal string Radius_Calculated
        {
            get
            {
                return radiusCalculated;
            }

            set
            {
                radiusCalculated = value;
            }
        }

        private string radiusVanDerWaals = string.Empty;

        /// <summary>
        /// Gets or sets the radius van der waals.
        /// </summary>
        internal string Radius_Van_Der_Waals
        {
            get
            {
                return radiusVanDerWaals;
            }

            set
            {
                radiusVanDerWaals = value;
            }
        }

        private string radiusCovalentSingleBond = string.Empty;

        /// <summary>
        /// Gets or sets the radius covalent single bind.
        /// </summary>
        internal string Radius_Covalent_Single_Bond
        {
            get
            {
                return radiusCovalentSingleBond;
            }

            set
            {
                radiusCovalentSingleBond = value;
            }
        }

        private string radiusCovalentTripleBond = string.Empty;

        /// <summary>
        /// Gets or sets the radius covalent triple bond.
        /// </summary>
        internal string Radius_Covalent_Triple_Bond
        {
            get
            {
                return radiusCovalentTripleBond;
            }

            set
            {
                radiusCovalentTripleBond = value;
            }
        }

        private string radiusMetallic = string.Empty;

        /// <summary>
        /// Gets or sets the radius metallic.
        /// </summary>
        internal string Radius_Metallic
        {
            get
            {
                return radiusMetallic;
            }

            set
            {
                radiusMetallic = value;
            }
        }

        private string materialType;

        /// <summary>
        /// Gets or sets the material type.
        /// </summary>
        public string MaterialType
        {
            get
            {
                return materialType;
            }

            set
            {
                materialType = value;
            }
        }
    }
}