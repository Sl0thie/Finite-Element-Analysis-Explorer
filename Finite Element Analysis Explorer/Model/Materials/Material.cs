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
            this.Atomic_Number = atomic_Number;
            this.Symbol = symbol;
            this.Atomic_Mass = atomic_Mass;
            this.Allotrope_Names = allotrope_Names;
            this.Alternate_Names = alternate_Names;
            this.CAS_Number = cAS_Number;
            this.Icon_Color = icon_Color;
            this.Block = block;
            this.Group = group;
            this.Period = period;
            this.Series = series;
            this.Atomic_Weight = atomic_Weight;
            this.Brinell_Hardness = brinell_Hardness;
            this.Bulk_Modulus = bulk_Modulus;
            this.Liquid_Density = liquid_Density;
            this.Mohs_Hardness = mohs_Hardness;
            this.Molar_Volume = molar_Volume;
            this.Poission_Ratio = poission_Ratio;
            this.ModulusOfRigidity = shear_Modulus;
            this.Sound_Speed = sound_Speed;
            this.Thermal_Conductivity = thermal_Conductivity;
            this.Thermal_Expansion = thermal_Expansion;
            this.Vickers_Hardness = vickers_Hardness;
            this.ModulusOfElasticity = young_Modulus;
            this.Absolute_Boiling_Point = absolute_Boiling_Point;
            this.Absolute_Melting_Point = absolute_Melting_Point;
            this.Adiabatic_Index = adiabatic_Index;
            this.Boiling_Point = boiling_Point;
            this.Critical_Pressure = critical_Pressure;
            this.Critical_Temperature = critical_Temperature;
            this.Curie_Point = curie_Point;
            this.Fusion_Heat = fusion_Heat;
            this.Melting_Point = melting_Point;
            this.Neel_Point = neel_Point;
            this.Phase = phase;
            this.Specific_Heat = specific_Heat;
            this.Superconducting_Point = superconducting_Point;
            this.Vaporization_Heat = vaporization_Heat;
            this.Color = color;
            this.Electrical_Conductivity = electrical_Conductivity;
            this.Electrical_Type = electrical_Type;
            this.Magnetic_Type = magnetic_Type;
            this.Mass_Magnetic_Susceptibility = mass_Magnetic_Susceptibility;
            this.Molar_Magnetic_Susceptibility = molar_Magnetic_Susceptibility;
            this.Refractive_Index = refractive_Index;
            this.Resistivity = resistivity;
            this.Volume_Magnetic_Susceptibility = volume_Magnetic_Susceptibility;
            this.Allotropic_Multiplicities = allotropic_Multiplicities;
            this.Electron_Affinity = electron_Affinity;
            this.Electronegativity = electronegativity;
            this.Gas_Atomic_Multiplicities = gas_Atomic_Multiplicities;
            this.Valence = valence;
            this.Crystal_Structure = crystal_Structure;
            this.Lattice_Angles = lattice_Angles;
            this.Lattice_Constants = lattice_Constants;
            this.Space_Group_Number = space_Group_Number;
            this.Space_Group_Name = space_Group_Name;
            this.Atomic_Radius = atomic_Radius;
            this.Covalent_Radius = covalent_Radius;
            this.Electron_Configuration = electron_Configuration;
            this.Electron_Configuration_String = electron_Configuration_String;
            this.Electron_Shell_Configuration = electron_Shell_Configuration;
            this.Ionization_Energies = ionization_Energies;
            this.Quantum_Numbers = quantum_Numbers;
            this.Van_Der_Waals_Radius = van_Der_Waals_Radius;
            this.Decay_Mode = decay_Mode;
            this.HalfLife = halfLife;
            this.Isotope_Abundances = isotope_Abundances;
            this.Known_Isotopes = known_Isotopes;
            this.Lifetime = lifetime;
            this.Neutron_Cross_Section = neutron_Cross_Section;
            this.Neutron_Mass_Absorption = neutron_Mass_Absorption;
            this.Radioactive = radioactive;
            this.Stable_Isotopes = stable_Isotopes;
            this.Crust_Abundance = crust_Abundance;
            this.Human_Abundance = human_Abundance;
            this.Meteorite_Abundance = meteorite_Abundance;
            this.Ocean_Abundance = ocean_Abundance;
            this.Solar_Abundance = solar_Abundance;
            this.Universe_Abundance = universe_Abundance;
            this.Radius_Empirical = radius_Empirical;
            this.Radius_Calculated = radius_Calculated;
            this.Radius_Van_Der_Waals = radius_Van_Der_Waals;
            this.Radius_Covalent_Single_Bond = radius_Covalent_Single_Bond;
            this.Radius_Covalent_Triple_Bond = radius_Covalent_Triple_Bond;
            this.Radius_Metallic = radius_Metallic;
            this.MaterialType = materialType;
        }

        #region Added

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description = string.Empty;

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
            get
            {
                return yieldStrengthShear;
            }

            set
            {
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
        /// Modulus of Rigidity (G).
        ///
        ///
        ///  G = E/2(1+v).
        ///  E = 2G(1+v).
        ///
        /// </summary>
        private decimal modulusOfRigidity = 0;

        public decimal ModulusOfRigidity
        {
            get { return modulusOfRigidity; }
            set { modulusOfRigidity = value; }
        }

        /// <summary>
        /// Bulk Modulus (K)
        /// Ability to resist compression.
        ///
        /// Relation Equation E = 3K(1-2v).
        ///                   K = E/3(1-2v).
        ///
        ///
        /// </summary>
        private decimal bulkModulus = 0;

        internal decimal Bulk_Modulus
        {
            get { return bulkModulus; }
            set { bulkModulus = value; }
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

        private int atomicNumber = 0;

        internal int Atomic_Number
        {
            get { return atomicNumber; }
            set { atomicNumber = value; }
        }

        private string symbol = string.Empty;

        internal string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        private decimal atomicMass = 0;

        internal decimal Atomic_Mass
        {
            get { return atomicMass; }
            set { atomicMass = value; }
        }

        private string allotropeNames = string.Empty;

        internal string Allotrope_Names
        {
            get { return allotropeNames; }
            set { allotropeNames = value; }
        }

        private string alternateNames = string.Empty;

        internal string Alternate_Names
        {
            get { return alternateNames; }
            set { alternateNames = value; }
        }

        private string cASNumber = string.Empty;

        internal string CAS_Number
        {
            get { return cASNumber; }
            set { cASNumber = value; }
        }

        private string iconColor = string.Empty;

        internal string Icon_Color
        {
            get { return iconColor; }
            set { iconColor = value; }
        }

        private string block = string.Empty;

        internal string Block
        {
            get { return block; }
            set { block = value; }
        }

        private string group = string.Empty;

        internal string Group
        {
            get { return group; }
            set { group = value; }
        }

        private string period = string.Empty;

        internal string Period
        {
            get { return period; }
            set { period = value; }
        }

        private string series = string.Empty;

        internal string Series
        {
            get { return series; }
            set { series = value; }
        }

        private decimal atomicWeight = 0;

        internal decimal Atomic_Weight
        {
            get { return atomicWeight; }
            set { atomicWeight = value; }
        }

        private decimal brinellHardness = 0;

        internal decimal Brinell_Hardness
        {
            get { return brinellHardness; }
            set { brinellHardness = value; }
        }

        private decimal liquidDensity = 0;

        internal decimal Liquid_Density
        {
            get { return liquidDensity; }
            set { liquidDensity = value; }
        }

        private decimal mohsHardness = 0;

        internal decimal Mohs_Hardness
        {
            get { return mohsHardness; }
            set { mohsHardness = value; }
        }

        private decimal molarVolume = 0;

        internal decimal Molar_Volume
        {
            get { return molarVolume; }
            set { molarVolume = value; }
        }

        private decimal poissionRatio = 0;

        internal decimal Poission_Ratio
        {
            get { return poissionRatio; }
            set { poissionRatio = value; }
        }

        private decimal soundSpeed = 0;

        internal decimal Sound_Speed
        {
            get { return soundSpeed; }
            set { soundSpeed = value; }
        }

        private decimal thermalConductivity = 0;

        internal decimal Thermal_Conductivity
        {
            get { return thermalConductivity; }
            set { thermalConductivity = value; }
        }

        private decimal thermalExpansion = 0;

        internal decimal Thermal_Expansion
        {
            get { return thermalExpansion; }
            set { thermalExpansion = value; }
        }

        private decimal vickersHardness = 0;

        internal decimal Vickers_Hardness
        {
            get { return vickersHardness; }
            set { vickersHardness = value; }
        }

        private decimal absoluteBoilingPoint = 0;

        internal decimal Absolute_Boiling_Point
        {
            get { return absoluteBoilingPoint; }
            set { absoluteBoilingPoint = value; }
        }

        private decimal absoluteMeltingPoint = 0;

        internal decimal Absolute_Melting_Point
        {
            get { return absoluteMeltingPoint; }
            set { absoluteMeltingPoint = value; }
        }

        private decimal adiabaticIndex = 0;

        internal decimal Adiabatic_Index
        {
            get { return adiabaticIndex; }
            set { adiabaticIndex = value; }
        }

        private decimal boilingPoint = 0;

        internal decimal Boiling_Point
        {
            get { return boilingPoint; }
            set { boilingPoint = value; }
        }

        private decimal criticalPressure = 0;

        internal decimal Critical_Pressure
        {
            get { return criticalPressure; }
            set { criticalPressure = value; }
        }

        private decimal criticalTemperature = 0;

        internal decimal Critical_Temperature
        {
            get { return criticalTemperature; }
            set { criticalTemperature = value; }
        }

        private decimal curiePoint = 0;

        internal decimal Curie_Point
        {
            get { return curiePoint; }
            set { curiePoint = value; }
        }

        private decimal fusionHeat = 0;

        internal decimal Fusion_Heat
        {
            get { return fusionHeat; }
            set { fusionHeat = value; }
        }

        private decimal meltingPoint = 0;

        internal decimal Melting_Point
        {
            get { return meltingPoint; }
            set { meltingPoint = value; }
        }

        private decimal neelPoint = 0;

        internal decimal Neel_Point
        {
            get { return neelPoint; }
            set { neelPoint = value; }
        }

        private string phase = string.Empty;

        internal string Phase
        {
            get { return phase; }
            set { phase = value; }
        }

        private decimal specificHeat = 0;

        internal decimal Specific_Heat
        {
            get { return specificHeat; }
            set { specificHeat = value; }
        }

        private decimal superconductingPoint = 0;

        internal decimal Superconducting_Point
        {
            get { return superconductingPoint; }
            set { superconductingPoint = value; }
        }

        private decimal vaporizationHeat = 0;

        internal decimal Vaporization_Heat
        {
            get { return vaporizationHeat; }
            set { vaporizationHeat = value; }
        }

        private string color = string.Empty;

        internal string Color
        {
            get { return color; }
            set { color = value; }
        }

        private decimal electricalConductivity = 0;

        internal decimal Electrical_Conductivity
        {
            get { return electricalConductivity; }
            set { electricalConductivity = value; }
        }

        private string electricalType = string.Empty;

        internal string Electrical_Type
        {
            get { return electricalType; }
            set { electricalType = value; }
        }

        private string magneticType = string.Empty;

        internal string Magnetic_Type
        {
            get { return magneticType; }
            set { magneticType = value; }
        }

        private decimal massMagneticSusceptibility = 0;

        internal decimal Mass_Magnetic_Susceptibility
        {
            get { return massMagneticSusceptibility; }
            set { massMagneticSusceptibility = value; }
        }

        private decimal molarMagneticSusceptibility = 0;

        internal decimal Molar_Magnetic_Susceptibility
        {
            get { return molarMagneticSusceptibility; }
            set { molarMagneticSusceptibility = value; }
        }

        private decimal refractiveIndex = 0;

        internal decimal Refractive_Index
        {
            get { return refractiveIndex; }
            set { refractiveIndex = value; }
        }

        private decimal resistivity = 0;

        internal decimal Resistivity
        {
            get { return resistivity; }
            set { resistivity = value; }
        }

        private decimal volumeMagneticSusceptibility = 0;

        internal decimal Volume_Magnetic_Susceptibility
        {
            get { return volumeMagneticSusceptibility; }
            set { volumeMagneticSusceptibility = value; }
        }

        private string allotropicMultiplicities = string.Empty;

        internal string Allotropic_Multiplicities
        {
            get { return allotropicMultiplicities; }
            set { allotropicMultiplicities = value; }
        }

        private string electronAffinity = string.Empty;

        internal string Electron_Affinity
        {
            get { return electronAffinity; }
            set { electronAffinity = value; }
        }

        private string electronegativity = string.Empty;

        internal string Electronegativity
        {
            get { return electronegativity; }
            set { electronegativity = value; }
        }

        private string gasAtomicMultiplicities = string.Empty;

        internal string Gas_Atomic_Multiplicities
        {
            get { return gasAtomicMultiplicities; }
            set { gasAtomicMultiplicities = value; }
        }

        private string valence = string.Empty;

        internal string Valence
        {
            get { return valence; }
            set { valence = value; }
        }

        private string crystalStructure = string.Empty;

        internal string Crystal_Structure
        {
            get { return crystalStructure; }
            set { crystalStructure = value; }
        }

        private string latticeAngles = string.Empty;

        internal string Lattice_Angles
        {
            get { return latticeAngles; }
            set { latticeAngles = value; }
        }

        private string latticeConstants = string.Empty;

        internal string Lattice_Constants
        {
            get { return latticeConstants; }
            set { latticeConstants = value; }
        }

        private string spaceGroupNumber = string.Empty;

        internal string Space_Group_Number
        {
            get { return spaceGroupNumber; }
            set { spaceGroupNumber = value; }
        }

        private string spaceGroupName = string.Empty;

        internal string Space_Group_Name
        {
            get { return spaceGroupName; }
            set { spaceGroupName = value; }
        }

        private string atomicRadius = string.Empty;

        internal string Atomic_Radius
        {
            get { return atomicRadius; }
            set { atomicRadius = value; }
        }

        private string covalentRadius = string.Empty;

        internal string Covalent_Radius
        {
            get { return covalentRadius; }
            set { covalentRadius = value; }
        }

        private string electronConfiguration = string.Empty;

        internal string Electron_Configuration
        {
            get { return electronConfiguration; }
            set { electronConfiguration = value; }
        }

        private string electronConfigurationString = string.Empty;

        internal string Electron_Configuration_String
        {
            get { return electronConfigurationString; }
            set { electronConfigurationString = value; }
        }

        private string electronShellConfiguration = string.Empty;

        internal string Electron_Shell_Configuration
        {
            get { return electronShellConfiguration; }
            set { electronShellConfiguration = value; }
        }

        private string ionizationEnergies = string.Empty;

        internal string Ionization_Energies
        {
            get { return ionizationEnergies; }
            set { ionizationEnergies = value; }
        }

        private string quantumNumbers = string.Empty;

        internal string Quantum_Numbers
        {
            get { return quantumNumbers; }
            set { quantumNumbers = value; }
        }

        private string vanDerWaalsRadius = string.Empty;

        internal string Van_Der_Waals_Radius
        {
            get { return vanDerWaalsRadius; }
            set { vanDerWaalsRadius = value; }
        }

        private string decayMode = string.Empty;

        internal string Decay_Mode
        {
            get { return decayMode; }
            set { decayMode = value; }
        }

        private string halfLife = string.Empty;

        internal string HalfLife
        {
            get { return halfLife; }
            set { halfLife = value; }
        }

        private string isotopeAbundances = string.Empty;

        internal string Isotope_Abundances
        {
            get { return isotopeAbundances; }
            set { isotopeAbundances = value; }
        }

        private string knownIsotopes = string.Empty;

        internal string Known_Isotopes
        {
            get { return knownIsotopes; }
            set { knownIsotopes = value; }
        }

        private string lifetime = string.Empty;

        internal string Lifetime
        {
            get { return lifetime; }
            set { lifetime = value; }
        }

        private string neutronCrossSection = string.Empty;

        internal string Neutron_Cross_Section
        {
            get { return neutronCrossSection; }
            set { neutronCrossSection = value; }
        }

        private string neutronMassAbsorption = string.Empty;

        internal string Neutron_Mass_Absorption
        {
            get { return neutronMassAbsorption; }
            set { neutronMassAbsorption = value; }
        }

        private string radioactive = string.Empty;

        internal string Radioactive
        {
            get { return radioactive; }
            set { radioactive = value; }
        }

        private string stableIsotopes = string.Empty;

        internal string Stable_Isotopes
        {
            get { return stableIsotopes; }
            set { stableIsotopes = value; }
        }

        private decimal crustAbundance = 0;

        internal decimal Crust_Abundance
        {
            get { return crustAbundance; }
            set { crustAbundance = value; }
        }

        private decimal humanAbundance = 0;

        internal decimal Human_Abundance
        {
            get { return humanAbundance; }
            set { humanAbundance = value; }
        }

        private decimal meteoriteAbundance = 0;

        internal decimal Meteorite_Abundance
        {
            get { return meteoriteAbundance; }
            set { meteoriteAbundance = value; }
        }

        private decimal oceanAbundance = 0;

        internal decimal Ocean_Abundance
        {
            get { return oceanAbundance; }
            set { oceanAbundance = value; }
        }

        private decimal solarAbundance = 0;

        internal decimal Solar_Abundance
        {
            get { return solarAbundance; }
            set { solarAbundance = value; }
        }

        private decimal universeAbundance = 0;

        internal decimal Universe_Abundance
        {
            get { return universeAbundance; }
            set { universeAbundance = value; }
        }

        private string radiusEmpirical = string.Empty;

        internal string Radius_Empirical
        {
            get { return radiusEmpirical; }
            set { radiusEmpirical = value; }
        }

        private string radiusCalculated = string.Empty;

        internal string Radius_Calculated
        {
            get { return radiusCalculated; }
            set { radiusCalculated = value; }
        }

        private string radiusVanDerWaals = string.Empty;

        internal string Radius_Van_Der_Waals
        {
            get { return radiusVanDerWaals; }
            set { radiusVanDerWaals = value; }
        }

        private string radiusCovalentSingleBond = string.Empty;

        internal string Radius_Covalent_Single_Bond
        {
            get { return radiusCovalentSingleBond; }
            set { radiusCovalentSingleBond = value; }
        }

        private string radiusCovalentTripleBond = string.Empty;

        internal string Radius_Covalent_Triple_Bond
        {
            get { return radiusCovalentTripleBond; }
            set { radiusCovalentTripleBond = value; }
        }

        private string radiusMetallic = string.Empty;

        internal string Radius_Metallic
        {
            get { return radiusMetallic; }
            set { radiusMetallic = value; }
        }

        private string materialType;

        public string MaterialType
        {
            get { return materialType; }
            set { materialType = value; }
        }
    }
}