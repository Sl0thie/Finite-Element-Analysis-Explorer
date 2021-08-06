﻿namespace Finite_Element_Analysis_Explorer
{
    internal static class MaterialsList
    {

        internal static void LoadList()
        {
            Material anMaterial = new Material()
            {
                Name = "Default",
                Cost = 100,
                Density = 5000m,
                Poission_Ratio = 0.2m,
                ModulusOfElasticity = 200000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);



            // AnMaterial = new Material()
            // {
            //    Atomic_Number = -1,
            //    Name = "Steel 250N",
            //    Cost = 8000m,
            //    ModulusOfElasticity = 24000000000m,
            //    Density = 2400m,
            //    Poission_Ratio = 0.2m,
            //    MaterialType = "Compound"
            // };
            // Model.Materials.Add(AnMaterial.Name, AnMaterial);

            // AnMaterial = new Material()
            // {
            //    Atomic_Number = -1,
            //    Name = "Steel 300E",
            //    Cost = 8000m,
            //    Density = 2400m,
            //    Poission_Ratio = 0.2m,
            //    ModulusOfElasticity = 24000000000m,
            //    MaterialType = "Compound"
            // };
            // Model.Materials.Add(AnMaterial.Name, AnMaterial);

            // AnMaterial = new Material()
            // {
            //    Atomic_Number = -1,
            //    Name = "Steel 500L",
            //    Cost = 8000m,
            //    Density = 2400m,
            //    ModulusOfElasticity = 24000000000m,
            //    Poission_Ratio = 0.2m,
            //    MaterialType = "Compound"
            // };
            // Model.Materials.Add(AnMaterial.Name, AnMaterial);

            // AnMaterial = new Material()
            // {
            //    Atomic_Number = -1,
            //    Name = "Steel 500N",
            //    Cost = 8000m,
            //    Density = 2400m,
            //    Poission_Ratio = 0.2m,
            //    ModulusOfElasticity = 24000000000m,
            //    MaterialType = "Compound"
            // };
            // Model.Materials.Add(AnMaterial.Name, AnMaterial);

            // AnMaterial = new Material();
            // AnMaterial.Atomic_Number = -1;
            // AnMaterial.Name = "Steel 500E";
            // AnMaterial.Cost = 8000m;
            // AnMaterial.Density = 2400m;
            // AnMaterial.Poission_Ratio = 0.2m;
            // AnMaterial.ModulusOfElasticity = 24000000000m;
            // AnMaterial.MaterialType = "Compound";
            // Model.Materials.Add(AnMaterial.Name, AnMaterial);


            anMaterial = new Material
            {
                Name = "Concrete 20MPa",
                Cost = 250m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 24000000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 24000000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 25MPa",
                Cost = 261m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 26700000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Bulk_Modulus = 0, // K = E/3(1-2v)
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 24000000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 32MPa",
                Cost = 272m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 30100000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 24000000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 40MPa",
                Cost = 283m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 30100000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 32800000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 50MPa",
                Cost = 383m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 34800000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 32800000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 65MPa",
                Cost = 483m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 37400000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 32800000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 80MPa",
                Cost = 583m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 39600000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 32800000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Name = "Concrete 100MPa",
                Cost = 883m,
                UltimateStrengthTension = 3130.4951684997055749728431362238m, // f_r = 0.7 * sqrt(f'c) // 0.7 * sqrt(MPA)
                ModulusOfElasticity = 42200000000m,
                CoefficientOfThermalExpansion = 0.000012m,
                Density = 2400m,
                Poission_Ratio = 0.2m,
                ModulusOfRigidity = 1000000000, // G = E/2(1+v)   // G = E/2 * (1 + 0.2) // G = E/2.4
            };
            anMaterial.ModulusOfElasticity = 32800000000m;
            anMaterial.Specific_Heat = 0.75m;
            anMaterial.MaterialType = "Compound";
            Model.Materials.Add(anMaterial.Name, anMaterial);
            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "ABS Plastic",
                Density = 1060m,
                ModulusOfElasticity = 1.4m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Bone (Compact)",
                Density = 880m,
                ModulusOfElasticity = 18000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Bone (Spongy)",
                Density = 1700m,
                ModulusOfElasticity = 78000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Brass",
                Density = 8480m,
                ModulusOfElasticity = 102000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Bronze",
                ModulusOfElasticity = 96000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Carbon Fiber Reinforced Plastic",
                Density = 3510m,
                ModulusOfElasticity = 150000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Carbon nanotube, single-walled",
                Density = 3150m,
                ModulusOfElasticity = 1000000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "PVC",
                Density = 1390m,
                ModulusOfElasticity = 2900000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Concrete",
                Density = 2200m,
                ModulusOfElasticity = 17000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Concrete, High Strength",
                Density = 2450m,
                ModulusOfElasticity = 30000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Diamond",
                Density = 3500m,
                ModulusOfElasticity = 1220000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Timber, Douglas Fur",
                Density = 520m,
                ModulusOfElasticity = 13000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Epoxy Resins",
                Density = 1110m,
                ModulusOfElasticity = 2000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Fiberboard",
                ModulusOfElasticity = 4000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Glass",
                Density = 2400m,
                ModulusOfElasticity = 50000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Glass reinforced Polyester Matrix",
                Density = 25m,
                ModulusOfElasticity = 17000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Granite",
                Density = 2600m,
                ModulusOfElasticity = 52000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Graphene",
                Density = 2300m,
                ModulusOfElasticity = 1000000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Cast Iron",
                Density = 6800m,
                ModulusOfElasticity = 130000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Hemp Fiber",
                ModulusOfElasticity = 35000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Polycarbonates",
                Density = 1200m,
                ModulusOfElasticity = 2600000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Polyethylene HDPE",
                Density = 910m,
                ModulusOfElasticity = 800000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Polyethylene PET",
                Density = 910m,
                ModulusOfElasticity = 2100000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Polytetrafluoroethylene PTFE",

                Density = 2170m,
                ModulusOfElasticity = 400000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Sapphire",
                ModulusOfElasticity = 450000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Silicon Carbide",
                Density = 2330m,
                ModulusOfElasticity = 450000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Steel, stainless",
                Density = 7480m,
                ModulusOfElasticity = 180000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Steel, Structural",
                Density = 7850m,
                ModulusOfElasticity = 200000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Tooth Enamel",
                ModulusOfElasticity = 83000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Tungsten Carbide",
                Density = 19600m,
                ModulusOfElasticity = 450000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = -1,
                Name = "Wrought Iron",
                Density = 7750m,
                ModulusOfElasticity = 190000000000m,
                MaterialType = "Compound",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);
            anMaterial = new Material
            {
                Atomic_Number = 3,
                Name = "Lithium",
                Cost = 4500,
                Atomic_Weight = 6.941m,
                Bulk_Modulus = 11m,
                Density = 535m,
                Liquid_Density = 512m,
                Mohs_Hardness = 0.6m,
                Molar_Volume = 1.29738317757009E-05m,
                ModulusOfRigidity = 4.2m,
                Sound_Speed = 6000m,
                Thermal_Conductivity = 85m,
                Thermal_Expansion = 0.000046m,
                ModulusOfElasticity = 4900000000m,
                Absolute_Boiling_Point = 1615m,
                Absolute_Melting_Point = 453.69m,
                Boiling_Point = 1342m,
                Critical_Pressure = 67m,
                Critical_Temperature = 3223m,
                Fusion_Heat = 3m,
                Melting_Point = 180.54m,
                Vaporization_Heat = 147m,
                Electrical_Conductivity = 11000000m,
                Mass_Magnetic_Susceptibility = 0.0000000256m,
                Molar_Magnetic_Susceptibility = 0.000000000178m,
                Resistivity = 0.000000094m,
                Volume_Magnetic_Susceptibility = 0.00000137m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 4,
                Name = "Beryllium",
                Cost = 200000000,
                Atomic_Weight = 9.012182m,
                Brinell_Hardness = 600m,
                Bulk_Modulus = 130m,
                Density = 1848m,
                Liquid_Density = 1690m,
                Mohs_Hardness = 5.5m,
                Molar_Volume = 4.87672186147186E-06m,
                Poission_Ratio = 0.032m,
                ModulusOfRigidity = 132m,
                Sound_Speed = 13000m,
                Thermal_Conductivity = 190m,
                Thermal_Expansion = 0.0000113m,
                Vickers_Hardness = 1670m,
                ModulusOfElasticity = 287000000000m,
                Absolute_Boiling_Point = 2743m,
                Absolute_Melting_Point = 1560m,
                Boiling_Point = 2470m,
                Fusion_Heat = 7.95m,
                Melting_Point = 1287m,
                Superconducting_Point = 0.026m,
                Vaporization_Heat = 297m,
                Electrical_Conductivity = 25000000m,
                Mass_Magnetic_Susceptibility = -0.0000000126m,
                Molar_Magnetic_Susceptibility = -0.0000000001136m,
                Resistivity = 0.00000004m,
                Volume_Magnetic_Susceptibility = -0.00002328m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000019m,
                Human_Abundance = 0.0000000004m,
                Meteorite_Abundance = 0.000000029m,
                Ocean_Abundance = 0.0000000000006m,
                Solar_Abundance = 0.0000000001m,
                Universe_Abundance = 0.000000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 11,
                Name = "Sodium",
                Atomic_Weight = 22.98976928m,
                Brinell_Hardness = 0.69m,
                Bulk_Modulus = 6.3m,
                Density = 968m,
                Liquid_Density = 927m,
                Mohs_Hardness = 0.5m,
                Molar_Volume = 2.37497616528926E-05m,
                ModulusOfRigidity = 3.3m,
                Sound_Speed = 3200m,
                Thermal_Conductivity = 140m,
                Thermal_Expansion = 0.000071m,
                ModulusOfElasticity = 10000000000m,
                Absolute_Boiling_Point = 1156m,
                Absolute_Melting_Point = 370.87m,
                Boiling_Point = 883m,
                Critical_Pressure = 35m,
                Critical_Temperature = 2573m,
                Fusion_Heat = 2.6m,
                Melting_Point = 97.72m,
                Vaporization_Heat = 97.7m,
                Electrical_Conductivity = 21000000m,
                Mass_Magnetic_Susceptibility = 0.0000000088m,
                Molar_Magnetic_Susceptibility = 0.0000000002m,
                Resistivity = 0.000000047m,
                Volume_Magnetic_Susceptibility = 0.0000085m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.023m,
                Human_Abundance = 0.0014m,
                Meteorite_Abundance = 0.0055m,
                Ocean_Abundance = 0.011m,
                Solar_Abundance = 0.00004m,
                Universe_Abundance = 0.00002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 12,
                Name = "Magnesium",
                Atomic_Weight = 24.305m,
                Brinell_Hardness = 260m,
                Bulk_Modulus = 45m,
                Density = 1738m,
                Liquid_Density = 1584m,
                Mohs_Hardness = 2.5m,
                Molar_Volume = 1.39844649021864E-05m,
                Poission_Ratio = 0.29m,
                ModulusOfRigidity = 17m,
                Sound_Speed = 4602m,
                Thermal_Conductivity = 160m,
                Thermal_Expansion = 0.0000082m,
                ModulusOfElasticity = 45000000000m,
                Absolute_Boiling_Point = 1363m,
                Absolute_Melting_Point = 923m,
                Boiling_Point = 1090m,
                Fusion_Heat = 8.7m,
                Melting_Point = 650m,
                Vaporization_Heat = 128m,
                Electrical_Conductivity = 23000000m,
                Mass_Magnetic_Susceptibility = 0.0000000069m,
                Molar_Magnetic_Susceptibility = 0.000000000168m,
                Resistivity = 0.000000044m,
                Volume_Magnetic_Susceptibility = 0.000012m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.029m,
                Human_Abundance = 0.00027m,
                Meteorite_Abundance = 0.12m,
                Ocean_Abundance = 0.0013m,
                Solar_Abundance = 0.0007m,
                Universe_Abundance = 0.0006m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 13,
                Name = "Aluminum",
                Atomic_Weight = 26.9815386m,
                Brinell_Hardness = 245m,
                Bulk_Modulus = 76m,
                Density = 2700m,
                Liquid_Density = 2375m,
                Mohs_Hardness = 2.75m,
                Molar_Volume = 9.99316244444444E-06m,
                Poission_Ratio = 0.35m,
                ModulusOfRigidity = 26m,
                Sound_Speed = 5100m,
                Thermal_Conductivity = 235m,
                Thermal_Expansion = 0.0000231m,
                Vickers_Hardness = 167m,
                ModulusOfElasticity = 70000000000m,
                Absolute_Boiling_Point = 2792m,
                Absolute_Melting_Point = 933.47m,
                Boiling_Point = 2519m,
                Fusion_Heat = 10.7m,
                Melting_Point = 660.32m,
                Superconducting_Point = 1.175m,
                Vaporization_Heat = 293m,
                Electrical_Conductivity = 38000000m,
                Mass_Magnetic_Susceptibility = 0.0000000078m,
                Molar_Magnetic_Susceptibility = 0.00000000021m,
                Resistivity = 0.000000026m,
                Volume_Magnetic_Susceptibility = 0.0000211m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.081m,
                Human_Abundance = 0.0000009m,
                Meteorite_Abundance = 0.0091m,
                Ocean_Abundance = 0.000000005m,
                Solar_Abundance = 0.00006m,
                Universe_Abundance = 0.00005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 14,
                Name = "Silicon",
                Atomic_Weight = 28.0855m,
                Bulk_Modulus = 100m,
                Density = 2330m,
                Liquid_Density = 2570m,
                Mohs_Hardness = 6.5m,
                Molar_Volume = 1.20538626609442E-05m,
                Sound_Speed = 2200m,
                Thermal_Conductivity = 150m,
                Thermal_Expansion = 0.0000026m,
                ModulusOfElasticity = 47000000000m,
                Absolute_Boiling_Point = 3173m,
                Absolute_Melting_Point = 1687m,
                Boiling_Point = 2900m,
                Fusion_Heat = 50.2m,
                Melting_Point = 1414m,
                Vaporization_Heat = 359m,
                Electrical_Conductivity = 1000m,
                Mass_Magnetic_Susceptibility = -0.0000000016m,
                Molar_Magnetic_Susceptibility = -0.0000000000449m,
                Resistivity = 0.001m,
                Volume_Magnetic_Susceptibility = -0.00000373m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.27m,
                Human_Abundance = 0.00026m,
                Meteorite_Abundance = 0.14m,
                Ocean_Abundance = 0.000001m,
                Solar_Abundance = 0.0009m,
                Universe_Abundance = 0.0007m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 20,
                Name = "Calcium",
                Atomic_Weight = 40.078m,
                Brinell_Hardness = 167m,
                Bulk_Modulus = 17m,
                Density = 1550m,
                Liquid_Density = 1378m,
                Mohs_Hardness = 1.75m,
                Molar_Volume = 2.58567741935484E-05m,
                Poission_Ratio = 0.31m,
                ModulusOfRigidity = 7.4m,
                Sound_Speed = 3810m,
                Thermal_Conductivity = 200m,
                Thermal_Expansion = 0.0000223m,
                ModulusOfElasticity = 20000000000m,
                Absolute_Boiling_Point = 1757m,
                Absolute_Melting_Point = 1115m,
                Boiling_Point = 1484m,
                Fusion_Heat = 8.54m,
                Melting_Point = 842m,
                Vaporization_Heat = 155m,
                Electrical_Conductivity = 29000000m,
                Mass_Magnetic_Susceptibility = 0.0000000138m,
                Molar_Magnetic_Susceptibility = 0.0000000005531m,
                Resistivity = 0.000000034m,
                Volume_Magnetic_Susceptibility = 0.00002139m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.05m,
                Human_Abundance = 0.014m,
                Meteorite_Abundance = 0.011m,
                Ocean_Abundance = 0.0000042m,
                Solar_Abundance = 0.00007m,
                Universe_Abundance = 0.00007m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 21,
                Name = "Scandium",
                Atomic_Weight = 44.955912m,
                Brinell_Hardness = 750m,
                Bulk_Modulus = 57m,
                Density = 2985m,
                Liquid_Density = 2800m,
                Molar_Volume = 1.50606070351759E-05m,
                Poission_Ratio = 0.28m,
                ModulusOfRigidity = 29m,
                Thermal_Conductivity = 16m,
                Thermal_Expansion = 0.0000102m,
                ModulusOfElasticity = 74000000000m,
                Absolute_Boiling_Point = 3103m,
                Absolute_Melting_Point = 1814m,
                Boiling_Point = 2830m,
                Fusion_Heat = 16m,
                Melting_Point = 1541m,
                Superconducting_Point = 0.05m,
                Vaporization_Heat = 318m,
                Electrical_Conductivity = 1800000m,
                Mass_Magnetic_Susceptibility = 0.000000088m,
                Molar_Magnetic_Susceptibility = 0.000000003956m,
                Resistivity = 0.00000055m,
                Volume_Magnetic_Susceptibility = 0.0002627m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000026m,
                Meteorite_Abundance = 0.0000064m,
                Ocean_Abundance = 0.0000000000015m,
                Solar_Abundance = 0.00000004m,
                Universe_Abundance = 0.00000003m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 22,
                Name = "Titanium",
                Atomic_Weight = 47.867m,
                Brinell_Hardness = 716m,
                Bulk_Modulus = 110m,
                Density = 4507m,
                Liquid_Density = 4110m,
                Mohs_Hardness = 6m,
                Molar_Volume = 1.06205901930331E-05m,
                Poission_Ratio = 0.32m,
                ModulusOfRigidity = 44m,
                Sound_Speed = 4140m,
                Thermal_Conductivity = 22m,
                Thermal_Expansion = 0.0000086m,
                Vickers_Hardness = 970m,
                ModulusOfElasticity = 116000000000m,
                Absolute_Boiling_Point = 3560m,
                Absolute_Melting_Point = 1941m,
                Boiling_Point = 3287m,
                Fusion_Heat = 18.7m,
                Melting_Point = 1668m,
                Superconducting_Point = 0.4m,
                Vaporization_Heat = 425m,
                Electrical_Conductivity = 2500000m,
                Mass_Magnetic_Susceptibility = 0.0000000401m,
                Molar_Magnetic_Susceptibility = 0.000000001919m,
                Resistivity = 0.0000004m,
                Volume_Magnetic_Susceptibility = 0.0001807m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0066m,
                Meteorite_Abundance = 0.00054m,
                Ocean_Abundance = 0.000000001m,
                Solar_Abundance = 0.000004m,
                Universe_Abundance = 0.000003m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 23,
                Name = "Vanadium",
                Atomic_Weight = 50.9415m,
                Brinell_Hardness = 628m,
                Bulk_Modulus = 160m,
                Density = 6110m,
                Liquid_Density = 5500m,
                Mohs_Hardness = 7m,
                Molar_Volume = 8.3373977086743E-06m,
                Poission_Ratio = 0.37m,
                ModulusOfRigidity = 47m,
                Sound_Speed = 4560m,
                Thermal_Conductivity = 31m,
                Thermal_Expansion = 0.0000084m,
                Vickers_Hardness = 628m,
                ModulusOfElasticity = 128000000000m,
                Absolute_Boiling_Point = 3680m,
                Absolute_Melting_Point = 2183m,
                Boiling_Point = 3407m,
                Fusion_Heat = 22.8m,
                Melting_Point = 1910m,
                Superconducting_Point = 5.4m,
                Vaporization_Heat = 453m,
                Electrical_Conductivity = 5000000m,
                Mass_Magnetic_Susceptibility = 0.0000000628m,
                Molar_Magnetic_Susceptibility = 0.000000003199m,
                Resistivity = 0.0000002m,
                Volume_Magnetic_Susceptibility = 0.0003837m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00019m,
                Human_Abundance = 0.00000003m,
                Meteorite_Abundance = 0.000061m,
                Ocean_Abundance = 0.0000000015m,
                Solar_Abundance = 0.0000004m,
                Universe_Abundance = 0.000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 24,
                Name = "Chromium",
                Atomic_Weight = 51.9961m,
                Brinell_Hardness = 1120m,
                Bulk_Modulus = 160m,
                Density = 7140m,
                Liquid_Density = 6300m,
                Mohs_Hardness = 8.5m,
                Molar_Volume = 7.28236694677871E-06m,
                Poission_Ratio = 0.21m,
                ModulusOfRigidity = 115m,
                Sound_Speed = 5940m,
                Thermal_Conductivity = 94m,
                Thermal_Expansion = 0.0000049m,
                Vickers_Hardness = 1060m,
                ModulusOfElasticity = 279000000000m,
                Absolute_Boiling_Point = 2944m,
                Absolute_Melting_Point = 2180m,
                Boiling_Point = 2671m,
                Fusion_Heat = 20.5m,
                Melting_Point = 1907m,
                Neel_Point = 393m,
                Vaporization_Heat = 339m,
                Electrical_Conductivity = 7900000m,
                Mass_Magnetic_Susceptibility = 0.0000000445m,
                Molar_Magnetic_Susceptibility = 0.000000002314m,
                Resistivity = 0.00000013m,
                Volume_Magnetic_Susceptibility = 0.0003177m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00014m,
                Human_Abundance = 0.00000003m,
                Meteorite_Abundance = 0.003m,
                Ocean_Abundance = 0.0000000006m,
                Solar_Abundance = 0.00002m,
                Universe_Abundance = 0.000015m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 25,
                Name = "Manganese",
                Atomic_Weight = 54.938045m,
                Brinell_Hardness = 196m,
                Bulk_Modulus = 120m,
                Density = 7470m,
                Liquid_Density = 5950m,
                Mohs_Hardness = 6m,
                Molar_Volume = 7.3544906291834E-06m,
                Sound_Speed = 5150m,
                Thermal_Conductivity = 7.8m,
                Thermal_Expansion = 0.0000217m,
                ModulusOfElasticity = 198000000000m,
                Absolute_Boiling_Point = 2334m,
                Absolute_Melting_Point = 1519m,
                Boiling_Point = 2061m,
                Fusion_Heat = 13.2m,
                Melting_Point = 1246m,
                Neel_Point = 100m,
                Vaporization_Heat = 220m,
                Electrical_Conductivity = 620000m,
                Mass_Magnetic_Susceptibility = 0.000000121m,
                Molar_Magnetic_Susceptibility = 0.0000000066475m,
                Resistivity = 0.0000016m,
                Volume_Magnetic_Susceptibility = 0.00090387m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0011m,
                Human_Abundance = 0.0000002m,
                Meteorite_Abundance = 0.0027m,
                Ocean_Abundance = 0.000000002m,
                Solar_Abundance = 0.00001m,
                Universe_Abundance = 0.000008m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 26,
                Name = "Iron",
                Atomic_Weight = 55.845m,
                Brinell_Hardness = 490m,
                Bulk_Modulus = 170m,
                Density = 7874m,
                Liquid_Density = 6980m,
                Mohs_Hardness = 4m,
                Molar_Volume = 7.09232918465837E-06m,
                Poission_Ratio = 0.29m,
                ModulusOfRigidity = 82m,
                Sound_Speed = 4910m,
                Thermal_Conductivity = 80m,
                Thermal_Expansion = 0.0000118m,
                Vickers_Hardness = 608m,
                ModulusOfElasticity = 211000000000m,
                Absolute_Boiling_Point = 3134m,
                Absolute_Melting_Point = 1811m,
                Boiling_Point = 2861m,
                Curie_Point = 1043m,
                Fusion_Heat = 13.8m,
                Melting_Point = 1538m,
                Vaporization_Heat = 347m,
                Electrical_Conductivity = 10000000m,
                Resistivity = 0.000000097m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.063m,
                Human_Abundance = 0.00006m,
                Meteorite_Abundance = 0.22m,
                Ocean_Abundance = 0.000000003m,
                Solar_Abundance = 0.001m,
                Universe_Abundance = 0.0011m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 27,
                Name = "Cobalt",
                Atomic_Weight = 58.933195m,
                Brinell_Hardness = 700m,
                Bulk_Modulus = 180m,
                Density = 8900m,
                Liquid_Density = 7750m,
                Mohs_Hardness = 5m,
                Molar_Volume = 6.62170730337079E-06m,
                Poission_Ratio = 0.31m,
                ModulusOfRigidity = 75m,
                Sound_Speed = 4720m,
                Thermal_Conductivity = 100m,
                Thermal_Expansion = 0.000013m,
                Vickers_Hardness = 1043m,
                ModulusOfElasticity = 209000000000m,
                Absolute_Boiling_Point = 3200m,
                Absolute_Melting_Point = 1768m,
                Boiling_Point = 2927m,
                Curie_Point = 1394m,
                Fusion_Heat = 16.2m,
                Melting_Point = 1495m,
                Vaporization_Heat = 375m,
                Electrical_Conductivity = 17000000m,
                Resistivity = 0.00000006m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00003m,
                Human_Abundance = 0.00000002m,
                Meteorite_Abundance = 0.00059m,
                Ocean_Abundance = 0.00000000008m,
                Solar_Abundance = 0.000004m,
                Universe_Abundance = 0.000003m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 28,
                Name = "Nickel",
                Atomic_Weight = 58.6934m,
                Brinell_Hardness = 700m,
                Bulk_Modulus = 180m,
                Density = 8908m,
                Liquid_Density = 7810m,
                Mohs_Hardness = 4m,
                Molar_Volume = 6.58884149079479E-06m,
                Poission_Ratio = 0.31m,
                ModulusOfRigidity = 76m,
                Sound_Speed = 4970m,
                Thermal_Conductivity = 91m,
                Thermal_Expansion = 0.0000134m,
                Vickers_Hardness = 638m,
                ModulusOfElasticity = 200000000000m,
                Absolute_Boiling_Point = 3186m,
                Absolute_Melting_Point = 1728m,
                Boiling_Point = 2913m,
                Curie_Point = 631m,
                Fusion_Heat = 17.2m,
                Melting_Point = 1455m,
                Vaporization_Heat = 378m,
                Electrical_Conductivity = 14000000m,
                Resistivity = 0.00000007m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000089m,
                Human_Abundance = 0.0000001m,
                Meteorite_Abundance = 0.013m,
                Ocean_Abundance = 0.000000002m,
                Solar_Abundance = 0.00008m,
                Universe_Abundance = 0.00006m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 29,
                Name = "Copper",
                Atomic_Weight = 63.546m,
                Brinell_Hardness = 874m,
                Bulk_Modulus = 140m,
                Density = 8920m,
                Liquid_Density = 8020m,
                Mohs_Hardness = 3m,
                Molar_Volume = 7.12399103139013E-06m,
                Poission_Ratio = 0.34m,
                ModulusOfRigidity = 48m,
                Sound_Speed = 3570m,
                Thermal_Conductivity = 400m,
                Thermal_Expansion = 0.0000165m,
                Vickers_Hardness = 369m,
                ModulusOfElasticity = 130000000000m,
                Absolute_Boiling_Point = 3200m,
                Absolute_Melting_Point = 1357.77m,
                Boiling_Point = 2927m,
                Fusion_Heat = 13.1m,
                Melting_Point = 1084.62m,
                Vaporization_Heat = 300m,
                Electrical_Conductivity = 59000000m,
                Mass_Magnetic_Susceptibility = -0.00000000108m,
                Molar_Magnetic_Susceptibility = -0.0000000000686m,
                Resistivity = 0.000000017m,
                Volume_Magnetic_Susceptibility = -0.00000963m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000068m,
                Human_Abundance = 0.000001m,
                Meteorite_Abundance = 0.00011m,
                Ocean_Abundance = 0.000000003m,
                Solar_Abundance = 0.0000007m,
                Universe_Abundance = 0.00000006m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 30,
                Name = "Zinc",
                Atomic_Weight = 65.38m,
                Brinell_Hardness = 412m,
                Bulk_Modulus = 70m,
                Density = 7140m,
                Liquid_Density = 6570m,
                Mohs_Hardness = 2.5m,
                Molar_Volume = 9.15686274509804E-06m,
                Poission_Ratio = 0.25m,
                ModulusOfRigidity = 43m,
                Sound_Speed = 3700m,
                Thermal_Conductivity = 120m,
                Thermal_Expansion = 0.0000302m,
                ModulusOfElasticity = 108000000000m,
                Absolute_Boiling_Point = 1180m,
                Absolute_Melting_Point = 692.68m,
                Boiling_Point = 907m,
                Fusion_Heat = 7.35m,
                Melting_Point = 419.53m,
                Superconducting_Point = 0.85m,
                Vaporization_Heat = 119m,
                Electrical_Conductivity = 17000000m,
                Mass_Magnetic_Susceptibility = -0.00000000221m,
                Molar_Magnetic_Susceptibility = -0.000000000145m,
                Refractive_Index = 1.00205m,
                Resistivity = 0.000000059m,
                Volume_Magnetic_Susceptibility = -0.0000158m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000078m,
                Human_Abundance = 0.000033m,
                Meteorite_Abundance = 0.00018m,
                Ocean_Abundance = 0.000000005m,
                Solar_Abundance = 0.000002m,
                Universe_Abundance = 0.0000003m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 33,
                Name = "Arsenic",
                Atomic_Weight = 74.9216m,
                Brinell_Hardness = 1440m,
                Bulk_Modulus = 22m,
                Density = 5727m,
                Liquid_Density = 5220m,
                Mohs_Hardness = 3.5m,
                Molar_Volume = 1.30821721669286E-05m,
                Thermal_Conductivity = 50m,
                ModulusOfElasticity = 8000000000m,
                Absolute_Boiling_Point = 887m,
                Absolute_Melting_Point = 1090m,
                Boiling_Point = 614m,
                Fusion_Heat = 27.7m,
                Melting_Point = 817m,
                Vaporization_Heat = 32.4m,
                Electrical_Conductivity = 3300000m,
                Mass_Magnetic_Susceptibility = -0.0000000039m,
                Molar_Magnetic_Susceptibility = -0.000000000292m,
                Refractive_Index = 1.001552m,
                Resistivity = 0.0000003m,
                Volume_Magnetic_Susceptibility = -0.0000223m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000021m,
                Human_Abundance = 0.00000005m,
                Meteorite_Abundance = 0.0000018m,
                Ocean_Abundance = 0.0000000023m,
                Universe_Abundance = 0.000000008m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 34,
                Name = "Selenium",
                Atomic_Weight = 78.96m,
                Brinell_Hardness = 736m,
                Bulk_Modulus = 8.3m,
                Density = 4819m,
                Liquid_Density = 3990m,
                Mohs_Hardness = 2m,
                Molar_Volume = 1.63851421456734E-05m,
                Poission_Ratio = 0.33m,
                ModulusOfRigidity = 3.7m,
                Sound_Speed = 3350m,
                Thermal_Conductivity = 0.52m,
                ModulusOfElasticity = 10000000000m,
                Absolute_Boiling_Point = 958m,
                Absolute_Melting_Point = 494m,
                Boiling_Point = 685m,
                Critical_Pressure = 27.2m,
                Critical_Temperature = 1766m,
                Fusion_Heat = 5.4m,
                Melting_Point = 221m,
                Vaporization_Heat = 26m,
                Mass_Magnetic_Susceptibility = -0.000000004m,
                Molar_Magnetic_Susceptibility = -0.000000000316m,
                Refractive_Index = 1.000895m,
                Volume_Magnetic_Susceptibility = -0.0000193m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000005m,
                Human_Abundance = 0.00000005m,
                Meteorite_Abundance = 0.000013m,
                Ocean_Abundance = 0.00000000045m,
                Universe_Abundance = 0.00000003m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 37,
                Name = "Rubidium",
                Atomic_Weight = 85.4678m,
                Brinell_Hardness = 0.216m,
                Bulk_Modulus = 2.5m,
                Density = 1532m,
                Liquid_Density = 1460m,
                Mohs_Hardness = 0.3m,
                Molar_Volume = 5.57883812010444E-05m,
                Sound_Speed = 1300m,
                Thermal_Conductivity = 58m,
                ModulusOfElasticity = 2400000000m,
                Absolute_Boiling_Point = 961m,
                Absolute_Melting_Point = 312.46m,
                Boiling_Point = 688m,
                Critical_Pressure = 16m,
                Critical_Temperature = 2093m,
                Fusion_Heat = 2.19m,
                Melting_Point = 39.31m,
                Vaporization_Heat = 72m,
                Electrical_Conductivity = 8300000m,
                Mass_Magnetic_Susceptibility = 0.0000000026m,
                Molar_Magnetic_Susceptibility = 0.000000000222m,
                Resistivity = 0.00000012m,
                Volume_Magnetic_Susceptibility = 0.00000398m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00006m,
                Human_Abundance = 0.0000046m,
                Meteorite_Abundance = 0.0000032m,
                Ocean_Abundance = 0.00000012m,
                Solar_Abundance = 0.00000003m,
                Universe_Abundance = 0.00000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 39,
                Name = "Yttrium",
                Atomic_Weight = 88.90585m,
                Brinell_Hardness = 589m,
                Bulk_Modulus = 41m,
                Density = 4472m,
                Liquid_Density = 4240m,
                Molar_Volume = 1.98805567978533E-05m,
                Poission_Ratio = 0.24m,
                ModulusOfRigidity = 26m,
                Sound_Speed = 3300m,
                Thermal_Conductivity = 17m,
                Thermal_Expansion = 0.0000106m,
                ModulusOfElasticity = 64000000000m,
                Absolute_Boiling_Point = 3618m,
                Absolute_Melting_Point = 1799m,
                Boiling_Point = 3345m,
                Fusion_Heat = 11.4m,
                Melting_Point = 1526m,
                Superconducting_Point = 1.3m,
                Vaporization_Heat = 380m,
                Electrical_Conductivity = 1800000m,
                Mass_Magnetic_Susceptibility = 0.0000000666m,
                Molar_Magnetic_Susceptibility = 0.000000005921m,
                Resistivity = 0.00000056m,
                Volume_Magnetic_Susceptibility = 0.0002978m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000029m,
                Meteorite_Abundance = 0.0000019m,
                Ocean_Abundance = 0.000000000013m,
                Solar_Abundance = 0.00000001m,
                Universe_Abundance = 0.000000007m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 40,
                Name = "Zirconium",
                Atomic_Weight = 91.224m,
                Brinell_Hardness = 650m,
                Density = 6511m,
                Liquid_Density = 5800m,
                Mohs_Hardness = 5m,
                Molar_Volume = 1.40107510367071E-05m,
                Poission_Ratio = 0.34m,
                ModulusOfRigidity = 33m,
                Sound_Speed = 3800m,
                Thermal_Conductivity = 23m,
                Thermal_Expansion = 0.0000057m,
                Vickers_Hardness = 903m,
                ModulusOfElasticity = 68000000000m,
                Absolute_Boiling_Point = 4682m,
                Absolute_Melting_Point = 2128m,
                Boiling_Point = 4409m,
                Fusion_Heat = 21m,
                Melting_Point = 1855m,
                Superconducting_Point = 0.61m,
                Vaporization_Heat = 580m,
                Electrical_Conductivity = 2400000m,
                Mass_Magnetic_Susceptibility = 0.0000000168m,
                Molar_Magnetic_Susceptibility = 0.00000000153m,
                Resistivity = 0.00000042m,
                Volume_Magnetic_Susceptibility = 0.000109m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00013m,
                Human_Abundance = 0.00000005m,
                Meteorite_Abundance = 0.0000066m,
                Ocean_Abundance = 0.000000000026m,
                Solar_Abundance = 0.00000004m,
                Universe_Abundance = 0.00000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 41,
                Name = "Niobium",
                Atomic_Weight = 92.90638m,
                Brinell_Hardness = 736m,
                Bulk_Modulus = 170m,
                Density = 8570m,
                Mohs_Hardness = 6m,
                Molar_Volume = 1.08408844807468E-05m,
                Poission_Ratio = 0.4m,
                ModulusOfRigidity = 38m,
                Sound_Speed = 3480m,
                Thermal_Conductivity = 54m,
                Thermal_Expansion = 0.0000073m,
                Vickers_Hardness = 1320m,
                ModulusOfElasticity = 105000000000m,
                Absolute_Boiling_Point = 5017m,
                Absolute_Melting_Point = 2750m,
                Boiling_Point = 4744m,
                Fusion_Heat = 26.8m,
                Melting_Point = 2477m,
                Superconducting_Point = 9.25m,
                Vaporization_Heat = 690m,
                Electrical_Conductivity = 6700000m,
                Mass_Magnetic_Susceptibility = 0.0000000276m,
                Molar_Magnetic_Susceptibility = 0.00000000256m,
                Resistivity = 0.00000015m,
                Volume_Magnetic_Susceptibility = 0.000237m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000017m,
                Meteorite_Abundance = 0.00000019m,
                Ocean_Abundance = 0.000000000001m,
                Solar_Abundance = 0.000000004m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 42,
                Name = "Molybdenum",
                Atomic_Weight = 95.96m,
                Brinell_Hardness = 1500m,
                Bulk_Modulus = 230m,
                Density = 10280m,
                Liquid_Density = 9330m,
                Mohs_Hardness = 5.5m,
                Molar_Volume = 9.33463035019455E-06m,
                Poission_Ratio = 0.31m,
                ModulusOfRigidity = 20m,
                Sound_Speed = 6190m,
                Thermal_Conductivity = 139m,
                Thermal_Expansion = 0.0000048m,
                Vickers_Hardness = 1530m,
                ModulusOfElasticity = 329000000000m,
                Absolute_Boiling_Point = 4912m,
                Absolute_Melting_Point = 2896m,
                Boiling_Point = 4639m,
                Fusion_Heat = 36m,
                Melting_Point = 2623m,
                Superconducting_Point = 0.915m,
                Vaporization_Heat = 600m,
                Electrical_Conductivity = 20000000m,
                Mass_Magnetic_Susceptibility = 0.0000000117m,
                Molar_Magnetic_Susceptibility = 0.000000001122m,
                Resistivity = 0.00000005m,
                Volume_Magnetic_Susceptibility = 0.0001203m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000011m,
                Human_Abundance = 0.0000001m,
                Meteorite_Abundance = 0.0000012m,
                Ocean_Abundance = 0.00000001m,
                Solar_Abundance = 0.000000009m,
                Universe_Abundance = 0.000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 44,
                Name = "Ruthenium",
                Atomic_Weight = 101.07m,
                Brinell_Hardness = 2160m,
                Bulk_Modulus = 220m,
                Density = 12370m,
                Liquid_Density = 10650m,
                Mohs_Hardness = 6.5m,
                Molar_Volume = 8.17057396928052E-06m,
                Poission_Ratio = 0.3m,
                ModulusOfRigidity = 173m,
                Sound_Speed = 5970m,
                Thermal_Conductivity = 120m,
                Thermal_Expansion = 0.0000064m,
                ModulusOfElasticity = 447000000000m,
                Absolute_Boiling_Point = 4423m,
                Absolute_Melting_Point = 2607m,
                Boiling_Point = 4150m,
                Fusion_Heat = 25.7m,
                Melting_Point = 2334m,
                Superconducting_Point = 0.49m,
                Vaporization_Heat = 580m,
                Electrical_Conductivity = 14000000m,
                Mass_Magnetic_Susceptibility = 0.00000000542m,
                Molar_Magnetic_Susceptibility = 0.000000000548m,
                Resistivity = 0.000000071m,
                Volume_Magnetic_Susceptibility = 0.000067m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000000099m,
                Meteorite_Abundance = 0.00000081m,
                Ocean_Abundance = 0.0000000000007m,
                Solar_Abundance = 0.000000005m,
                Universe_Abundance = 0.000000004m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 45,
                Name = "Rhodium",
                Atomic_Weight = 102.9055m,
                Brinell_Hardness = 1100m,
                Bulk_Modulus = 380m,
                Density = 12450m,
                Liquid_Density = 10700m,
                Mohs_Hardness = 6m,
                Molar_Volume = 8.26550200803213E-06m,
                Poission_Ratio = 0.26m,
                ModulusOfRigidity = 150m,
                Sound_Speed = 4700m,
                Thermal_Conductivity = 150m,
                Thermal_Expansion = 0.0000082m,
                Vickers_Hardness = 1246m,
                ModulusOfElasticity = 275000000000m,
                Absolute_Boiling_Point = 3968m,
                Absolute_Melting_Point = 2237m,
                Boiling_Point = 3695m,
                Fusion_Heat = 21.7m,
                Melting_Point = 1964m,
                Vaporization_Heat = 495m,
                Electrical_Conductivity = 23000000m,
                Mass_Magnetic_Susceptibility = 0.0000000136m,
                Molar_Magnetic_Susceptibility = 0.0000000014m,
                Resistivity = 0.000000043m,
                Volume_Magnetic_Susceptibility = 0.0001693m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000000007m,
                Meteorite_Abundance = 0.00000018m,
                Solar_Abundance = 0.000000002m,
                Universe_Abundance = 0.0000000006m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 46,
                Name = "Palladium",
                Atomic_Weight = 106.42m,
                Brinell_Hardness = 37.3m,
                Bulk_Modulus = 180m,
                Density = 12023m,
                Liquid_Density = 10380m,
                Mohs_Hardness = 4.75m,
                Molar_Volume = 8.85136821092905E-06m,
                Poission_Ratio = 0.39m,
                ModulusOfRigidity = 44m,
                Sound_Speed = 3070m,
                Thermal_Conductivity = 72m,
                Thermal_Expansion = 0.0000118m,
                Vickers_Hardness = 461m,
                ModulusOfElasticity = 121000000000m,
                Absolute_Boiling_Point = 3236m,
                Absolute_Melting_Point = 1828.05m,
                Boiling_Point = 2963m,
                Fusion_Heat = 16.7m,
                Melting_Point = 1554.9m,
                Vaporization_Heat = 380m,
                Electrical_Conductivity = 10000000m,
                Mass_Magnetic_Susceptibility = 0.0000000657m,
                Molar_Magnetic_Susceptibility = 0.000000006992m,
                Resistivity = 0.0000001m,
                Volume_Magnetic_Susceptibility = 0.0007899m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000000063m,
                Meteorite_Abundance = 0.00000066m,
                Solar_Abundance = 0.000000003m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 47,
                Name = "Silver",
                Atomic_Weight = 107.8682m,
                Brinell_Hardness = 24.5m,
                Bulk_Modulus = 100m,
                Density = 10490m,
                Liquid_Density = 9320m,
                Mohs_Hardness = 2.5m,
                Molar_Volume = 1.02829551954242E-05m,
                Poission_Ratio = 0.37m,
                ModulusOfRigidity = 30m,
                Sound_Speed = 2600m,
                Thermal_Conductivity = 430m,
                Thermal_Expansion = 0.0000189m,
                Vickers_Hardness = 251m,
                ModulusOfElasticity = 83000000000m,
                Absolute_Boiling_Point = 2435m,
                Absolute_Melting_Point = 1234.93m,
                Boiling_Point = 2162m,
                Fusion_Heat = 11.3m,
                Melting_Point = 961.78m,
                Vaporization_Heat = 255m,
                Electrical_Conductivity = 62000000m,
                Mass_Magnetic_Susceptibility = -0.00000000227m,
                Molar_Magnetic_Susceptibility = -0.000000000245m,
                Resistivity = 0.000000016m,
                Volume_Magnetic_Susceptibility = -0.0000238m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000000079m,
                Meteorite_Abundance = 0.00000014m,
                Ocean_Abundance = 0.0000000001m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000006m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 48,
                Name = "Cadmium",
                Atomic_Weight = 112.411m,
                Brinell_Hardness = 203m,
                Bulk_Modulus = 42m,
                Density = 8650m,
                Liquid_Density = 7996m,
                Mohs_Hardness = 2m,
                Molar_Volume = 1.29954913294798E-05m,
                Poission_Ratio = 0.3m,
                ModulusOfRigidity = 19m,
                Sound_Speed = 2310m,
                Thermal_Conductivity = 97m,
                Thermal_Expansion = 0.0000308m,
                ModulusOfElasticity = 50000000000m,
                Absolute_Boiling_Point = 1040m,
                Absolute_Melting_Point = 594.22m,
                Boiling_Point = 767m,
                Fusion_Heat = 6.3m,
                Melting_Point = 321.07m,
                Superconducting_Point = 0.517m,
                Vaporization_Heat = 100m,
                Electrical_Conductivity = 14000000m,
                Mass_Magnetic_Susceptibility = -0.0000000023m,
                Molar_Magnetic_Susceptibility = -0.000000000259m,
                Resistivity = 0.00000007m,
                Volume_Magnetic_Susceptibility = -0.0000199m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000015m,
                Human_Abundance = 0.0000007m,
                Meteorite_Abundance = 0.00000044m,
                Ocean_Abundance = 0.00000000005m,
                Solar_Abundance = 0.000000006m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 49,
                Name = "Indium",
                Atomic_Weight = 114.818m,
                Brinell_Hardness = 8.83m,
                Density = 7310m,
                Liquid_Density = 7020m,
                Mohs_Hardness = 1.2m,
                Molar_Volume = 0.000015706976744186m,
                Sound_Speed = 1215m,
                Thermal_Conductivity = 82m,
                Thermal_Expansion = 0.0000321m,
                ModulusOfElasticity = 11000000000m,
                Absolute_Boiling_Point = 2345m,
                Absolute_Melting_Point = 429.75m,
                Boiling_Point = 2072m,
                Fusion_Heat = 3.26m,
                Melting_Point = 156.6m,
                Superconducting_Point = 3.41m,
                Vaporization_Heat = 230m,
                Electrical_Conductivity = 12000000m,
                Mass_Magnetic_Susceptibility = -0.0000000014m,
                Molar_Magnetic_Susceptibility = -0.000000000161m,
                Resistivity = 0.00000008m,
                Volume_Magnetic_Susceptibility = -0.0000102m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000016m,
                Meteorite_Abundance = 0.000000044m,
                Ocean_Abundance = 0.0000000000001m,
                Solar_Abundance = 0.000000004m,
                Universe_Abundance = 0.0000000003m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 50,
                Name = "Tin",
                Atomic_Weight = 118.71m,
                Brinell_Hardness = 51m,
                Bulk_Modulus = 58m,
                Density = 7310m,
                Liquid_Density = 6990m,
                Mohs_Hardness = 1.5m,
                Molar_Volume = 1.62393980848153E-05m,
                Poission_Ratio = 0.36m,
                ModulusOfRigidity = 18m,
                Sound_Speed = 2500m,
                Thermal_Conductivity = 67m,
                Thermal_Expansion = 0.000022m,
                ModulusOfElasticity = 50000000000m,
                Absolute_Boiling_Point = 2875m,
                Absolute_Melting_Point = 505.08m,
                Boiling_Point = 2602m,
                Fusion_Heat = 7m,
                Melting_Point = 231.93m,
                Superconducting_Point = 3.72m,
                Vaporization_Heat = 290m,
                Electrical_Conductivity = 9100000m,
                Mass_Magnetic_Susceptibility = -0.0000000031m,
                Molar_Magnetic_Susceptibility = -0.000000000368m,
                Resistivity = 0.00000011m,
                Volume_Magnetic_Susceptibility = -0.0000227m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000022m,
                Human_Abundance = 0.0000002m,
                Meteorite_Abundance = 0.0000012m,
                Ocean_Abundance = 0.00000000001m,
                Solar_Abundance = 0.000000009m,
                Universe_Abundance = 0.000000004m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 51,
                Name = "Antimony",
                Atomic_Weight = 121.76m,
                Brinell_Hardness = 294m,
                Bulk_Modulus = 42m,
                Density = 6697m,
                Liquid_Density = 6530m,
                Mohs_Hardness = 3m,
                Molar_Volume = 1.81812751978498E-05m,
                ModulusOfRigidity = 20m,
                Sound_Speed = 3420m,
                Thermal_Conductivity = 24m,
                Thermal_Expansion = 0.000011m,
                ModulusOfElasticity = 55000000000m,
                Absolute_Boiling_Point = 1860m,
                Absolute_Melting_Point = 903.78m,
                Boiling_Point = 1587m,
                Fusion_Heat = 19.7m,
                Melting_Point = 630.63m,
                Vaporization_Heat = 68m,
                Electrical_Conductivity = 2500000m,
                Mass_Magnetic_Susceptibility = -0.0000000109m,
                Molar_Magnetic_Susceptibility = -0.000000001327m,
                Resistivity = 0.0000004m,
                Volume_Magnetic_Susceptibility = -0.000073m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000002m,
                Meteorite_Abundance = 0.00000012m,
                Ocean_Abundance = 0.0000000002m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000004m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 52,
                Name = "Tellurium",
                Atomic_Weight = 127.6m,
                Brinell_Hardness = 180m,
                Bulk_Modulus = 65m,
                Density = 6240m,
                Liquid_Density = 5700m,
                Mohs_Hardness = 2.25m,
                Molar_Volume = 2.04487179487179E-05m,
                ModulusOfRigidity = 16m,
                Sound_Speed = 2610m,
                Thermal_Conductivity = 3m,
                ModulusOfElasticity = 43000000000m,
                Absolute_Boiling_Point = 1261m,
                Absolute_Melting_Point = 722.66m,
                Boiling_Point = 988m,
                Fusion_Heat = 17.5m,
                Melting_Point = 449.51m,
                Vaporization_Heat = 48m,
                Electrical_Conductivity = 10000m,
                Mass_Magnetic_Susceptibility = -0.0000000039m,
                Molar_Magnetic_Susceptibility = -0.000000000498m,
                Refractive_Index = 1.000991m,
                Resistivity = 0.0001m,
                Volume_Magnetic_Susceptibility = -0.0000243m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000000099m,
                Meteorite_Abundance = 0.0000021m,
                Universe_Abundance = 0.000000009m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 55,
                Name = "Cesium",
                Atomic_Weight = 132.9054519m,
                Brinell_Hardness = 0.14m,
                Bulk_Modulus = 1.6m,
                Density = 1879m,
                Liquid_Density = 1843m,
                Mohs_Hardness = 0.2m,
                Molar_Volume = 7.07320127195317E-05m,
                Thermal_Conductivity = 36m,
                ModulusOfElasticity = 1700000000m,
                Absolute_Boiling_Point = 944m,
                Absolute_Melting_Point = 301.59m,
                Boiling_Point = 671m,
                Critical_Pressure = 9.4m,
                Critical_Temperature = 1938m,
                Fusion_Heat = 2.09m,
                Melting_Point = 28.44m,
                Vaporization_Heat = 65m,
                Electrical_Conductivity = 5000000m,
                Mass_Magnetic_Susceptibility = 0.0000000028m,
                Molar_Magnetic_Susceptibility = 0.000000000372m,
                Resistivity = 0.0000002m,
                Volume_Magnetic_Susceptibility = 0.00000526m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000019m,
                Human_Abundance = 0.00000002m,
                Meteorite_Abundance = 0.00000014m,
                Ocean_Abundance = 0.0000000005m,
                Solar_Abundance = 0.000000008m,
                Universe_Abundance = 0.0000000008m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 56,
                Name = "Barium",
                Atomic_Weight = 137.327m,
                Bulk_Modulus = 9.6m,
                Density = 3510m,
                Liquid_Density = 3338m,
                Mohs_Hardness = 1.25m,
                Molar_Volume = 3.91245014245014E-05m,
                ModulusOfRigidity = 4.9m,
                Sound_Speed = 1620m,
                Thermal_Conductivity = 18m,
                Thermal_Expansion = 0.0000206m,
                ModulusOfElasticity = 13000000000m,
                Absolute_Boiling_Point = 2143m,
                Absolute_Melting_Point = 1000m,
                Boiling_Point = 1870m,
                Fusion_Heat = 8m,
                Melting_Point = 727m,
                Vaporization_Heat = 140m,
                Electrical_Conductivity = 2900000m,
                Mass_Magnetic_Susceptibility = 0.0000000113m,
                Molar_Magnetic_Susceptibility = 0.000000001552m,
                Resistivity = 0.00000035m,
                Volume_Magnetic_Susceptibility = 0.00003966m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00034m,
                Human_Abundance = 0.0000003m,
                Meteorite_Abundance = 0.0000027m,
                Ocean_Abundance = 0.00000003m,
                Solar_Abundance = 0.00000001m,
                Universe_Abundance = 0.00000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 57,
                Name = "Lanthanum",
                Atomic_Weight = 138.90547m,
                Brinell_Hardness = 363m,
                Bulk_Modulus = 28m,
                Density = 6146m,
                Liquid_Density = 5940m,
                Mohs_Hardness = 2.5m,
                Molar_Volume = 2.26009550927432E-05m,
                Poission_Ratio = 0.28m,
                ModulusOfRigidity = 14m,
                Sound_Speed = 2475m,
                Thermal_Conductivity = 13m,
                Thermal_Expansion = 0.0000121m,
                Vickers_Hardness = 491m,
                ModulusOfElasticity = 37000000000m,
                Absolute_Boiling_Point = 3737m,
                Absolute_Melting_Point = 1193m,
                Boiling_Point = 3464m,
                Fusion_Heat = 6.2m,
                Melting_Point = 920m,
                Superconducting_Point = 4.88m,
                Vaporization_Heat = 400m,
                Electrical_Conductivity = 1600000m,
                Mass_Magnetic_Susceptibility = 0.000000011m,
                Molar_Magnetic_Susceptibility = 0.000000001528m,
                Resistivity = 0.00000061m,
                Volume_Magnetic_Susceptibility = 0.00006761m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000034m,
                Meteorite_Abundance = 0.00000028m,
                Ocean_Abundance = 0.0000000000034m,
                Solar_Abundance = 0.000000002m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 58,
                Name = "Cerium",
                Atomic_Weight = 140.116m,
                Brinell_Hardness = 412m,
                Bulk_Modulus = 22m,
                Density = 6689m,
                Liquid_Density = 6550m,
                Mohs_Hardness = 2.5m,
                Molar_Volume = 2.09472267902527E-05m,
                Poission_Ratio = 0.24m,
                ModulusOfRigidity = 14m,
                Sound_Speed = 2100m,
                Thermal_Conductivity = 11m,
                Thermal_Expansion = 0.0000063m,
                Vickers_Hardness = 270m,
                ModulusOfElasticity = 34000000000m,
                Absolute_Boiling_Point = 3633m,
                Absolute_Melting_Point = 1071m,
                Boiling_Point = 3360m,
                Fusion_Heat = 5.5m,
                Melting_Point = 798m,
                Neel_Point = 12.5m,
                Superconducting_Point = 0.022m,
                Vaporization_Heat = 350m,
                Electrical_Conductivity = 1400000m,
                Mass_Magnetic_Susceptibility = 0.00000022m,
                Molar_Magnetic_Susceptibility = 0.000000030826m,
                Resistivity = 0.00000074m,
                Volume_Magnetic_Susceptibility = 0.0014716m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00006m,
                Meteorite_Abundance = 0.00000075m,
                Ocean_Abundance = 0.0000000000012m,
                Solar_Abundance = 0.000000004m,
                Universe_Abundance = 0.00000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 59,
                Name = "Praseodymium",
                Atomic_Weight = 140.90765m,
                Brinell_Hardness = 481m,
                Bulk_Modulus = 29m,
                Density = 6640m,
                Liquid_Density = 6500m,
                Molar_Volume = 0.000021221031626506m,
                Poission_Ratio = 0.28m,
                ModulusOfRigidity = 15m,
                Sound_Speed = 2280m,
                Thermal_Conductivity = 13m,
                Thermal_Expansion = 0.0000067m,
                Vickers_Hardness = 400m,
                ModulusOfElasticity = 37000000000m,
                Absolute_Boiling_Point = 3563m,
                Absolute_Melting_Point = 1204m,
                Boiling_Point = 3290m,
                Fusion_Heat = 6.9m,
                Melting_Point = 931m,
                Vaporization_Heat = 330m,
                Electrical_Conductivity = 1400000m,
                Mass_Magnetic_Susceptibility = 0.000000423m,
                Molar_Magnetic_Susceptibility = 0.000000059604m,
                Resistivity = 0.0000007m,
                Volume_Magnetic_Susceptibility = 0.0028087m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000086m,
                Meteorite_Abundance = 0.000000098m,
                Ocean_Abundance = 0.0000000000006m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 60,
                Name = "Neodymium",
                Atomic_Weight = 144.242m,
                Brinell_Hardness = 265m,
                Bulk_Modulus = 32m,
                Density = 7010m,
                Liquid_Density = 6890m,
                Molar_Volume = 0.000020576604850214m,
                Poission_Ratio = 0.28m,
                ModulusOfRigidity = 16m,
                Sound_Speed = 2330m,
                Thermal_Conductivity = 17m,
                Thermal_Expansion = 0.0000096m,
                Vickers_Hardness = 343m,
                ModulusOfElasticity = 41000000000m,
                Absolute_Boiling_Point = 3373m,
                Absolute_Melting_Point = 1294m,
                Boiling_Point = 3100m,
                Fusion_Heat = 7.1m,
                Melting_Point = 1021m,
                Neel_Point = 19.2m,
                Vaporization_Heat = 285m,
                Electrical_Conductivity = 1600000m,
                Mass_Magnetic_Susceptibility = 0.00000048m,
                Molar_Magnetic_Susceptibility = 0.000000069235m,
                Resistivity = 0.00000064m,
                Volume_Magnetic_Susceptibility = 0.0033648m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000033m,
                Meteorite_Abundance = 0.0000005m,
                Ocean_Abundance = 0.0000000000028m,
                Solar_Abundance = 0.000000003m,
                Universe_Abundance = 0.00000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 61,
                Name = "Promethium",
                Atomic_Weight = 145m,
                Bulk_Modulus = 33m,
                Density = 7264m,
                Molar_Volume = 1.99614537444934E-05m,
                Poission_Ratio = 0.28m,
                ModulusOfRigidity = 18m,
                Thermal_Conductivity = 15m,
                Thermal_Expansion = 0.000011m,
                ModulusOfElasticity = 46000000000m,
                Absolute_Boiling_Point = 3273m,
                Absolute_Melting_Point = 1373m,
                Boiling_Point = 3000m,
                Fusion_Heat = 7.7m,
                Melting_Point = 1100m,
                Vaporization_Heat = 290m,
                Electrical_Conductivity = 1300000m,
                Resistivity = 0.00000075m,
                Radioactive = "TRUE",
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 62,
                Name = "Samarium",
                Atomic_Weight = 150.36m,
                Brinell_Hardness = 441m,
                Bulk_Modulus = 38m,
                Density = 7353m,
                Liquid_Density = 7160m,
                Molar_Volume = 2.04487964096287E-05m,
                Poission_Ratio = 0.27m,
                ModulusOfRigidity = 20m,
                Sound_Speed = 2130m,
                Thermal_Conductivity = 13m,
                Thermal_Expansion = 0.0000127m,
                Vickers_Hardness = 412m,
                ModulusOfElasticity = 50000000000m,
                Absolute_Boiling_Point = 2076m,
                Absolute_Melting_Point = 1345m,
                Boiling_Point = 1803m,
                Fusion_Heat = 8.6m,
                Melting_Point = 1072m,
                Neel_Point = 106m,
                Vaporization_Heat = 175m,
                Electrical_Conductivity = 1100000m,
                Mass_Magnetic_Susceptibility = 0.000000111m,
                Molar_Magnetic_Susceptibility = 0.00000001669m,
                Resistivity = 0.00000094m,
                Volume_Magnetic_Susceptibility = 0.00081618m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000006m,
                Meteorite_Abundance = 0.00000017m,
                Ocean_Abundance = 0.00000000000045m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 63,
                Name = "Europium",
                Atomic_Weight = 151.964m,
                Bulk_Modulus = 8.3m,
                Density = 5244m,
                Liquid_Density = 5130m,
                Molar_Volume = 2.89786422578185E-05m,
                Poission_Ratio = 0.15m,
                ModulusOfRigidity = 7.9m,
                Thermal_Conductivity = 14m,
                Thermal_Expansion = 0.000035m,
                Vickers_Hardness = 167m,
                ModulusOfElasticity = 18000000000m,
                Absolute_Boiling_Point = 1800m,
                Absolute_Melting_Point = 1095m,
                Boiling_Point = 1527m,
                Fusion_Heat = 9.2m,
                Melting_Point = 822m,
                Neel_Point = 90.5m,
                Vaporization_Heat = 175m,
                Electrical_Conductivity = 1100000m,
                Mass_Magnetic_Susceptibility = 0.000000276m,
                Molar_Magnetic_Susceptibility = 0.000000041942m,
                Resistivity = 0.0000009m,
                Volume_Magnetic_Susceptibility = 0.0014473m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000018m,
                Meteorite_Abundance = 0.000000059m,
                Ocean_Abundance = 0.00000000000013m,
                Solar_Abundance = 0.0000000005m,
                Universe_Abundance = 0.0000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 64,
                Name = "Gadolinium",
                Atomic_Weight = 157.25m,
                Bulk_Modulus = 38m,
                Density = 7901m,
                Liquid_Density = 7400m,
                Molar_Volume = 1.99025439817745E-05m,
                Poission_Ratio = 0.26m,
                ModulusOfRigidity = 22m,
                Sound_Speed = 2680m,
                Thermal_Conductivity = 11m,
                Thermal_Expansion = 0.0000094m,
                Vickers_Hardness = 570m,
                ModulusOfElasticity = 55000000000m,
                Absolute_Boiling_Point = 3523m,
                Absolute_Melting_Point = 1586m,
                Boiling_Point = 3250m,
                Curie_Point = 292m,
                Fusion_Heat = 10m,
                Melting_Point = 1313m,
                Superconducting_Point = 1.083m,
                Vaporization_Heat = 305m,
                Electrical_Conductivity = 770000m,
                Resistivity = 0.0000013m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000052m,
                Meteorite_Abundance = 0.00000023m,
                Ocean_Abundance = 0.0000000000007m,
                Solar_Abundance = 0.000000002m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 65,
                Name = "Terbium",
                Atomic_Weight = 158.92535m,
                Brinell_Hardness = 677m,
                Bulk_Modulus = 38.7m,
                Density = 8219m,
                Liquid_Density = 7650m,
                Molar_Volume = 1.93363365372916E-05m,
                Poission_Ratio = 0.26m,
                ModulusOfRigidity = 22m,
                Sound_Speed = 2620m,
                Thermal_Conductivity = 11m,
                Thermal_Expansion = 0.0000103m,
                Vickers_Hardness = 863m,
                ModulusOfElasticity = 56000000000m,
                Absolute_Boiling_Point = 3503m,
                Absolute_Melting_Point = 1629m,
                Boiling_Point = 3230m,
                Curie_Point = 222m,
                Fusion_Heat = 10.8m,
                Melting_Point = 1356m,
                Neel_Point = 230m,
                Vaporization_Heat = 295m,
                Electrical_Conductivity = 830000m,
                Mass_Magnetic_Susceptibility = 0.0000136m,
                Molar_Magnetic_Susceptibility = 0.00000216139m,
                Resistivity = 0.0000012m,
                Volume_Magnetic_Susceptibility = 0.1117784m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000093m,
                Meteorite_Abundance = 0.000000039m,
                Ocean_Abundance = 0.00000000000014m,
                Solar_Abundance = 0.0000000001m,
                Universe_Abundance = 0.0000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 66,
                Name = "Dysprosium",
                Atomic_Weight = 162.5m,
                Brinell_Hardness = 500m,
                Bulk_Modulus = 41m,
                Density = 8551m,
                Liquid_Density = 8370m,
                Molar_Volume = 1.90036253069816E-05m,
                Poission_Ratio = 0.25m,
                ModulusOfRigidity = 25m,
                Sound_Speed = 2710m,
                Thermal_Conductivity = 11m,
                Thermal_Expansion = 0.0000099m,
                Vickers_Hardness = 540m,
                ModulusOfElasticity = 61000000000m,
                Absolute_Boiling_Point = 2840m,
                Absolute_Melting_Point = 1685m,
                Boiling_Point = 2567m,
                Curie_Point = 87m,
                Fusion_Heat = 11.1m,
                Melting_Point = 1412m,
                Neel_Point = 178m,
                Vaporization_Heat = 280m,
                Electrical_Conductivity = 1100000m,
                Mass_Magnetic_Susceptibility = 0.00000545m,
                Molar_Magnetic_Susceptibility = 0.000000885625m,
                Resistivity = 0.00000091m,
                Volume_Magnetic_Susceptibility = 0.046603m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000062m,
                Meteorite_Abundance = 0.00000027m,
                Ocean_Abundance = 0.00000000000091m,
                Solar_Abundance = 0.000000002m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 67,
                Name = "Holmium",
                Atomic_Weight = 164.93032m,
                Brinell_Hardness = 746m,
                Bulk_Modulus = 40m,
                Density = 8795m,
                Liquid_Density = 8340m,
                Molar_Volume = 1.87527367822626E-05m,
                Poission_Ratio = 0.23m,
                ModulusOfRigidity = 26m,
                Sound_Speed = 2760m,
                Thermal_Conductivity = 16m,
                Thermal_Expansion = 0.0000112m,
                Vickers_Hardness = 481m,
                ModulusOfElasticity = 65000000000m,
                Absolute_Boiling_Point = 2973m,
                Absolute_Melting_Point = 1747m,
                Boiling_Point = 2700m,
                Curie_Point = 20m,
                Fusion_Heat = 17m,
                Melting_Point = 1474m,
                Neel_Point = 132m,
                Vaporization_Heat = 265m,
                Electrical_Conductivity = 1100000m,
                Mass_Magnetic_Susceptibility = 0.00000549m,
                Molar_Magnetic_Susceptibility = 0.000000905467m,
                Resistivity = 0.00000094m,
                Volume_Magnetic_Susceptibility = 0.0482845m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000012m,
                Meteorite_Abundance = 0.000000059m,
                Ocean_Abundance = 0.00000000000022m,
                Universe_Abundance = 0.0000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 68,
                Name = "Erbium",
                Atomic_Weight = 167.259m,
                Brinell_Hardness = 814m,
                Bulk_Modulus = 44m,
                Density = 9066m,
                Liquid_Density = 8860m,
                Molar_Volume = 1.84490403706155E-05m,
                Poission_Ratio = 0.24m,
                ModulusOfRigidity = 28m,
                Sound_Speed = 2830m,
                Thermal_Conductivity = 15m,
                Thermal_Expansion = 0.0000122m,
                Vickers_Hardness = 589m,
                ModulusOfElasticity = 70000000000m,
                Absolute_Boiling_Point = 3141m,
                Absolute_Melting_Point = 1770m,
                Boiling_Point = 2868m,
                Curie_Point = 32m,
                Fusion_Heat = 19.9m,
                Melting_Point = 1497m,
                Neel_Point = 82m,
                Vaporization_Heat = 285m,
                Electrical_Conductivity = 1200000m,
                Mass_Magnetic_Susceptibility = 0.00000377m,
                Molar_Magnetic_Susceptibility = 0.000000630566m,
                Resistivity = 0.00000086m,
                Volume_Magnetic_Susceptibility = 0.0341788m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000003m,
                Meteorite_Abundance = 0.00000018m,
                Ocean_Abundance = 0.0000000000009m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 69,
                Name = "Thulium",
                Atomic_Weight = 168.93421m,
                Brinell_Hardness = 471m,
                Bulk_Modulus = 45m,
                Density = 9321m,
                Liquid_Density = 8560m,
                Molar_Volume = 1.81240435575582E-05m,
                Poission_Ratio = 0.21m,
                ModulusOfRigidity = 31m,
                Thermal_Conductivity = 17m,
                Thermal_Expansion = 0.0000133m,
                Vickers_Hardness = 520m,
                ModulusOfElasticity = 74000000000m,
                Absolute_Boiling_Point = 2223m,
                Absolute_Melting_Point = 1818m,
                Boiling_Point = 1950m,
                Curie_Point = 25m,
                Fusion_Heat = 16.8m,
                Melting_Point = 1545m,
                Neel_Point = 56m,
                Vaporization_Heat = 250m,
                Electrical_Conductivity = 1400000m,
                Mass_Magnetic_Susceptibility = 0.00000199m,
                Molar_Magnetic_Susceptibility = 0.000000336179m,
                Resistivity = 0.0000007m,
                Volume_Magnetic_Susceptibility = 0.0185488m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000045m,
                Meteorite_Abundance = 0.000000029m,
                Ocean_Abundance = 0.0000000000002m,
                Solar_Abundance = 0.0000000002m,
                Universe_Abundance = 0.0000000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 70,
                Name = "Ytterbium",
                Atomic_Weight = 173.054m,
                Brinell_Hardness = 343m,
                Bulk_Modulus = 31m,
                Density = 6570m,
                Liquid_Density = 6210m,
                Molar_Volume = 2.63400304414003E-05m,
                Poission_Ratio = 0.21m,
                ModulusOfRigidity = 9.9m,
                Sound_Speed = 1590m,
                Thermal_Conductivity = 39m,
                Thermal_Expansion = 0.0000263m,
                Vickers_Hardness = 206m,
                ModulusOfElasticity = 24000000000m,
                Absolute_Boiling_Point = 1469m,
                Absolute_Melting_Point = 1092m,
                Boiling_Point = 1196m,
                Fusion_Heat = 7.7m,
                Melting_Point = 819m,
                Vaporization_Heat = 160m,
                Electrical_Conductivity = 3600000m,
                Mass_Magnetic_Susceptibility = 0.0000000059m,
                Molar_Magnetic_Susceptibility = 0.00000000102m,
                Resistivity = 0.00000028m,
                Volume_Magnetic_Susceptibility = 0.0000388m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000028m,
                Meteorite_Abundance = 0.00000018m,
                Ocean_Abundance = 0.0000000000008m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 71,
                Name = "Lutetium",
                Atomic_Weight = 174.9668m,
                Brinell_Hardness = 893m,
                Bulk_Modulus = 48m,
                Density = 9841m,
                Liquid_Density = 9300m,
                Molar_Volume = 1.77793720150391E-05m,
                Poission_Ratio = 0.26m,
                ModulusOfRigidity = 27m,
                Thermal_Conductivity = 16m,
                Thermal_Expansion = 0.0000099m,
                Vickers_Hardness = 1160m,
                ModulusOfElasticity = 69000000000m,
                Absolute_Boiling_Point = 3675m,
                Absolute_Melting_Point = 1936m,
                Boiling_Point = 3402m,
                Fusion_Heat = 22m,
                Melting_Point = 1663m,
                Superconducting_Point = 0.1m,
                Vaporization_Heat = 415m,
                Electrical_Conductivity = 1800000m,
                Mass_Magnetic_Susceptibility = 0.0000000012m,
                Molar_Magnetic_Susceptibility = 0.00000000021m,
                Resistivity = 0.00000056m,
                Volume_Magnetic_Susceptibility = 0.0000118m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000056m,
                Meteorite_Abundance = 0.000000029m,
                Ocean_Abundance = 0.00000000000015m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 72,
                Name = "Hafnium",
                Atomic_Weight = 178.49m,
                Brinell_Hardness = 1700m,
                Bulk_Modulus = 110m,
                Density = 13310m,
                Liquid_Density = 12000m,
                Mohs_Hardness = 5.5m,
                Molar_Volume = 1.34102178812923E-05m,
                Poission_Ratio = 0.37m,
                ModulusOfRigidity = 30m,
                Sound_Speed = 3010m,
                Thermal_Conductivity = 23m,
                Thermal_Expansion = 0.0000059m,
                Vickers_Hardness = 1760m,
                ModulusOfElasticity = 78000000000m,
                Absolute_Boiling_Point = 4876m,
                Absolute_Melting_Point = 2506m,
                Boiling_Point = 4603m,
                Fusion_Heat = 25.5m,
                Melting_Point = 2233m,
                Superconducting_Point = 0.128m,
                Vaporization_Heat = 630m,
                Electrical_Conductivity = 3300000m,
                Mass_Magnetic_Susceptibility = 0.0000000053m,
                Molar_Magnetic_Susceptibility = 0.000000000946m,
                Resistivity = 0.0000003m,
                Volume_Magnetic_Susceptibility = 0.0000705m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000033m,
                Meteorite_Abundance = 0.00000017m,
                Ocean_Abundance = 0.000000000008m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000007m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 73,
                Name = "Tantalum",
                Atomic_Weight = 180.94788m,
                Brinell_Hardness = 800m,
                Bulk_Modulus = 200m,
                Density = 16650m,
                Liquid_Density = 15000m,
                Mohs_Hardness = 6.5m,
                Molar_Volume = 1.08677405405405E-05m,
                Poission_Ratio = 0.34m,
                ModulusOfRigidity = 69m,
                Sound_Speed = 3400m,
                Thermal_Conductivity = 57m,
                Thermal_Expansion = 0.0000063m,
                Vickers_Hardness = 873m,
                ModulusOfElasticity = 186000000000m,
                Absolute_Boiling_Point = 5731m,
                Absolute_Melting_Point = 3290m,
                Boiling_Point = 5458m,
                Fusion_Heat = 36m,
                Melting_Point = 3017m,
                Superconducting_Point = 4.47m,
                Vaporization_Heat = 735m,
                Electrical_Conductivity = 7700000m,
                Mass_Magnetic_Susceptibility = 0.0000000107m,
                Molar_Magnetic_Susceptibility = 0.000000001936m,
                Resistivity = 0.00000013m,
                Volume_Magnetic_Susceptibility = 0.0001782m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000017m,
                Meteorite_Abundance = 0.00000002m,
                Ocean_Abundance = 0.000000000002m,
                Universe_Abundance = 0.00000000008m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 74,
                Name = "Tungsten",
                Atomic_Weight = 183.84m,
                Brinell_Hardness = 2570m,
                Bulk_Modulus = 310m,
                Density = 19250m,
                Liquid_Density = 17600m,
                Mohs_Hardness = 7.5m,
                Molar_Volume = 9.55012987012987E-06m,
                Poission_Ratio = 0.28m,
                ModulusOfRigidity = 161m,
                Sound_Speed = 5174m,
                Thermal_Conductivity = 170m,
                Thermal_Expansion = 0.0000045m,
                Vickers_Hardness = 3430m,
                ModulusOfElasticity = 411000000000m,
                Absolute_Boiling_Point = 5828m,
                Absolute_Melting_Point = 3695m,
                Boiling_Point = 5555m,
                Fusion_Heat = 35m,
                Melting_Point = 3422m,
                Superconducting_Point = 0.015m,
                Vaporization_Heat = 800m,
                Electrical_Conductivity = 20000000m,
                Mass_Magnetic_Susceptibility = 0.00000000459m,
                Molar_Magnetic_Susceptibility = 0.000000000844m,
                Resistivity = 0.00000005m,
                Volume_Magnetic_Susceptibility = 0.0000884m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000011m,
                Meteorite_Abundance = 0.00000012m,
                Ocean_Abundance = 0.00000000012m,
                Solar_Abundance = 0.000000004m,
                Universe_Abundance = 0.0000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 75,
                Name = "Rhenium",
                Atomic_Weight = 186.207m,
                Brinell_Hardness = 1320m,
                Bulk_Modulus = 370m,
                Density = 21020m,
                Liquid_Density = 18900m,
                Mohs_Hardness = 7m,
                Molar_Volume = 8.85856327307326E-06m,
                Poission_Ratio = 0.3m,
                ModulusOfRigidity = 178m,
                Sound_Speed = 4700m,
                Thermal_Conductivity = 48m,
                Thermal_Expansion = 0.0000062m,
                Vickers_Hardness = 2450m,
                ModulusOfElasticity = 463000000000m,
                Absolute_Boiling_Point = 5869m,
                Absolute_Melting_Point = 3459m,
                Boiling_Point = 5596m,
                Fusion_Heat = 33m,
                Melting_Point = 3186m,
                Superconducting_Point = 1.7m,
                Vaporization_Heat = 705m,
                Electrical_Conductivity = 5600000m,
                Mass_Magnetic_Susceptibility = 0.00000000456m,
                Molar_Magnetic_Susceptibility = 0.000000000849m,
                Resistivity = 0.00000018m,
                Volume_Magnetic_Susceptibility = 0.0000959m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000000026m,
                Meteorite_Abundance = 0.000000049m,
                Ocean_Abundance = 0.000000000001m,
                Solar_Abundance = 0.0000000001m,
                Universe_Abundance = 0.0000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 77,
                Name = "Iridium",
                Atomic_Weight = 192.217m,
                Brinell_Hardness = 1670m,
                Bulk_Modulus = 320m,
                Density = 22560m,
                Liquid_Density = 19000m,
                Mohs_Hardness = 6.5m,
                Molar_Volume = 8.52025709219858E-06m,
                Poission_Ratio = 0.26m,
                ModulusOfRigidity = 210m,
                Sound_Speed = 4825m,
                Thermal_Conductivity = 150m,
                Thermal_Expansion = 0.0000064m,
                Vickers_Hardness = 1760m,
                ModulusOfElasticity = 528000000000m,
                Absolute_Boiling_Point = 4701m,
                Absolute_Melting_Point = 2739m,
                Boiling_Point = 4428m,
                Fusion_Heat = 26m,
                Melting_Point = 2466m,
                Superconducting_Point = 0.11m,
                Vaporization_Heat = 560m,
                Electrical_Conductivity = 21000000m,
                Mass_Magnetic_Susceptibility = 0.00000000167m,
                Molar_Magnetic_Susceptibility = 0.000000000321m,
                Resistivity = 0.000000047m,
                Volume_Magnetic_Susceptibility = 0.0000377m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000000004m,
                Meteorite_Abundance = 0.00000054m,
                Solar_Abundance = 0.000000002m,
                Universe_Abundance = 0.000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 78,
                Name = "Platinum",
                Atomic_Weight = 195.084m,
                Brinell_Hardness = 392m,
                Bulk_Modulus = 230m,
                Density = 21090m,
                Liquid_Density = 19770m,
                Mohs_Hardness = 3.5m,
                Molar_Volume = 9.25007112375533E-06m,
                Poission_Ratio = 0.38m,
                ModulusOfRigidity = 61m,
                Sound_Speed = 2680m,
                Thermal_Conductivity = 72m,
                Thermal_Expansion = 0.0000088m,
                Vickers_Hardness = 549m,
                ModulusOfElasticity = 168000000000m,
                Absolute_Boiling_Point = 4098m,
                Absolute_Melting_Point = 2041.4m,
                Boiling_Point = 3825m,
                Fusion_Heat = 20m,
                Melting_Point = 1768.3m,
                Vaporization_Heat = 490m,
                Electrical_Conductivity = 9400000m,
                Mass_Magnetic_Susceptibility = 0.0000000122m,
                Molar_Magnetic_Susceptibility = 0.00000000238m,
                Resistivity = 0.00000011m,
                Volume_Magnetic_Susceptibility = 0.0002573m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000000037m,
                Meteorite_Abundance = 0.00000098m,
                Solar_Abundance = 0.000000009m,
                Universe_Abundance = 0.000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 79,
                Name = "Gold",
                Atomic_Weight = 196.966569m,
                Brinell_Hardness = 2450m,
                Bulk_Modulus = 220m,
                Density = 19300m,
                Liquid_Density = 17310m,
                Mohs_Hardness = 2.5m,
                Molar_Volume = 1.02055217098446E-05m,
                Poission_Ratio = 0.44m,
                ModulusOfRigidity = 27m,
                Sound_Speed = 1740m,
                Thermal_Conductivity = 320m,
                Thermal_Expansion = 0.0000142m,
                Vickers_Hardness = 216m,
                ModulusOfElasticity = 78000000000m,
                Absolute_Boiling_Point = 3129m,
                Absolute_Melting_Point = 1337.33m,
                Boiling_Point = 2856m,
                Fusion_Heat = 12.5m,
                Melting_Point = 1064.18m,
                Vaporization_Heat = 330m,
                Electrical_Conductivity = 45000000m,
                Mass_Magnetic_Susceptibility = -0.00000000178m,
                Molar_Magnetic_Susceptibility = -0.000000000351m,
                Resistivity = 0.000000022m,
                Volume_Magnetic_Susceptibility = -0.0000344m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000000031m,
                Human_Abundance = 0.0000001m,
                Meteorite_Abundance = 0.00000017m,
                Ocean_Abundance = 0.00000000005m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000006m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 81,
                Name = "Thallium",
                Atomic_Weight = 204.3833m,
                Brinell_Hardness = 26.4m,
                Bulk_Modulus = 43m,
                Density = 11850m,
                Liquid_Density = 11220m,
                Mohs_Hardness = 1.2m,
                Molar_Volume = 1.72475358649789E-05m,
                Poission_Ratio = 0.45m,
                ModulusOfRigidity = 2.8m,
                Sound_Speed = 818m,
                Thermal_Conductivity = 46m,
                Thermal_Expansion = 0.0000299m,
                ModulusOfElasticity = 8000000000m,
                Absolute_Boiling_Point = 1746m,
                Absolute_Melting_Point = 577m,
                Boiling_Point = 1473m,
                Fusion_Heat = 4.2m,
                Melting_Point = 304m,
                Superconducting_Point = 2.38m,
                Vaporization_Heat = 165m,
                Electrical_Conductivity = 6700000m,
                Mass_Magnetic_Susceptibility = -0.000000003m,
                Molar_Magnetic_Susceptibility = -0.000000000613m,
                Resistivity = 0.00000015m,
                Volume_Magnetic_Susceptibility = -0.0000356m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.00000053m,
                Meteorite_Abundance = 0.000000078m,
                Ocean_Abundance = 0.000000000001m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000005m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 82,
                Name = "Lead",
                Atomic_Weight = 207.2m,
                Brinell_Hardness = 38.3m,
                Bulk_Modulus = 46m,
                Density = 11340m,
                Liquid_Density = 10660m,
                Mohs_Hardness = 1.5m,
                Molar_Volume = 1.82716049382716E-05m,
                Poission_Ratio = 0.44m,
                ModulusOfRigidity = 5.6m,
                Sound_Speed = 1260m,
                Thermal_Conductivity = 35m,
                Thermal_Expansion = 0.0000289m,
                ModulusOfElasticity = 16000000000m,
                Absolute_Boiling_Point = 2022m,
                Absolute_Melting_Point = 600.61m,
                Boiling_Point = 1749m,
                Fusion_Heat = 4.77m,
                Melting_Point = 327.46m,
                Superconducting_Point = 7.2m,
                Vaporization_Heat = 178m,
                Electrical_Conductivity = 4800000m,
                Mass_Magnetic_Susceptibility = -0.0000000015m,
                Molar_Magnetic_Susceptibility = -0.000000000311m,
                Resistivity = 0.00000021m,
                Volume_Magnetic_Susceptibility = -0.000017m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.0000099m,
                Human_Abundance = 0.0000017m,
                Meteorite_Abundance = 0.0000014m,
                Ocean_Abundance = 0.00000000003m,
                Solar_Abundance = 0.00000001m,
                Universe_Abundance = 0.00000001m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 83,
                Name = "Bismuth",
                Atomic_Weight = 208.9804m,
                Brinell_Hardness = 94.2m,
                Bulk_Modulus = 31m,
                Density = 9780m,
                Liquid_Density = 10050m,
                Mohs_Hardness = 2.25m,
                Molar_Volume = 2.13681390593047E-05m,
                Poission_Ratio = 0.33m,
                ModulusOfRigidity = 12m,
                Sound_Speed = 1790m,
                Thermal_Conductivity = 8m,
                Thermal_Expansion = 0.0000134m,
                ModulusOfElasticity = 32000000000m,
                Absolute_Boiling_Point = 1837m,
                Absolute_Melting_Point = 544.4m,
                Boiling_Point = 1564m,
                Fusion_Heat = 10.9m,
                Melting_Point = 271.3m,
                Vaporization_Heat = 160m,
                Electrical_Conductivity = 770000m,
                Mass_Magnetic_Susceptibility = -0.000000017m,
                Molar_Magnetic_Susceptibility = -0.0000000036m,
                Resistivity = 0.0000013m,
                Volume_Magnetic_Susceptibility = -0.00017m,
                Radioactive = "FALSE",
                Crust_Abundance = 0.000000025m,
                Meteorite_Abundance = 0.000000069m,
                Ocean_Abundance = 0.00000000002m,
                Solar_Abundance = 0.00000001m,
                Universe_Abundance = 0.0000000007m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 90,
                Name = "Thorium",
                Atomic_Weight = 232.03806m,
                Brinell_Hardness = 400m,
                Bulk_Modulus = 54m,
                Density = 11724m,
                Mohs_Hardness = 3m,
                Molar_Volume = 1.97917144319345E-05m,
                Poission_Ratio = 0.27m,
                ModulusOfRigidity = 31m,
                Sound_Speed = 2490m,
                Thermal_Conductivity = 54m,
                Thermal_Expansion = 0.000011m,
                Vickers_Hardness = 350m,
                ModulusOfElasticity = 79000000000m,
                Absolute_Boiling_Point = 5093m,
                Absolute_Melting_Point = 2023m,
                Boiling_Point = 4820m,
                Fusion_Heat = 16m,
                Melting_Point = 1750m,
                Superconducting_Point = 1.38m,
                Vaporization_Heat = 530m,
                Electrical_Conductivity = 6700000m,
                Mass_Magnetic_Susceptibility = 0.0000000072m,
                Molar_Magnetic_Susceptibility = 0.0000000017m,
                Resistivity = 0.00000015m,
                Volume_Magnetic_Susceptibility = 0.000084m,
                Radioactive = "TRUE",
                Crust_Abundance = 0.000006m,
                Meteorite_Abundance = 0.000000039m,
                Ocean_Abundance = 0.00000000000004m,
                Solar_Abundance = 0.0000000003m,
                Universe_Abundance = 0.0000000004m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 92,
                Name = "Uranium",
                Atomic_Weight = 238.02891m,
                Brinell_Hardness = 2400m,
                Bulk_Modulus = 100m,
                Density = 19050m,
                Liquid_Density = 17300m,
                Mohs_Hardness = 6m,
                Molar_Volume = 1.24949559055118E-05m,
                Poission_Ratio = 0.23m,
                ModulusOfRigidity = 111m,
                Sound_Speed = 3155m,
                Thermal_Conductivity = 27m,
                Thermal_Expansion = 0.0000139m,
                Vickers_Hardness = 1960m,
                ModulusOfElasticity = 208000000000m,
                Absolute_Boiling_Point = 4200m,
                Absolute_Melting_Point = 1408m,
                Boiling_Point = 3927m,
                Fusion_Heat = 14m,
                Melting_Point = 1135m,
                Superconducting_Point = 0.68m,
                Vaporization_Heat = 420m,
                Electrical_Conductivity = 3600000m,
                Mass_Magnetic_Susceptibility = 0.0000000216m,
                Molar_Magnetic_Susceptibility = 0.00000000514m,
                Resistivity = 0.00000028m,
                Volume_Magnetic_Susceptibility = 0.000411m,
                Radioactive = "TRUE",
                Crust_Abundance = 0.0000018m,
                Human_Abundance = 0.000000001m,
                Meteorite_Abundance = 0.0000000098m,
                Ocean_Abundance = 0.0000000033m,
                Solar_Abundance = 0.000000001m,
                Universe_Abundance = 0.0000000002m,
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);

            anMaterial = new Material
            {
                Atomic_Number = 94,
                Name = "Plutonium",
                Atomic_Weight = 244m,
                Density = 19816m,
                Liquid_Density = 16630m,
                Molar_Volume = 1.23132821962051E-05m,
                Poission_Ratio = 0.21m,
                ModulusOfRigidity = 43m,
                Sound_Speed = 2260m,
                Thermal_Conductivity = 6m,
                ModulusOfElasticity = 96000000000m,
                Absolute_Boiling_Point = 3503m,
                Absolute_Melting_Point = 913m,
                Boiling_Point = 3230m,
                Melting_Point = 640m,
                Vaporization_Heat = 325m,
                Electrical_Conductivity = 670000m,
                Mass_Magnetic_Susceptibility = 0.0000000317m,
                Molar_Magnetic_Susceptibility = 0.000000007735m,
                Resistivity = 0.0000015m,
                Volume_Magnetic_Susceptibility = 0.0006282m,
                Radioactive = "TRUE",
                MaterialType = "Element",
            };
            Model.Materials.Add(anMaterial.Name, anMaterial);
        }
    }
}