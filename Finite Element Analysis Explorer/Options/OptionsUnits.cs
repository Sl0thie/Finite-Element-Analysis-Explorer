namespace Finite_Element_Analysis_Explorer
{
    using System;

    /// <summary>
    /// OptionsUnits class manages unit options.
    /// </summary>
    internal class OptionsUnits
    {
        private LengthType length = LengthType.Meter;
        private ForcePerLengthType forcePerLength = ForcePerLengthType.NewtonPerMeter;
        private ForceType force = ForceType.Newton;
        private DensityType density = DensityType.KilogramPerCubicMetre;
        private AreaType area = AreaType.SquareMetre;
        private MomentOfInertiaType momentOfInertia = MomentOfInertiaType.QuadMeter;
        private PressureType pressure = PressureType.Pascal;
        private MomentType moment = MomentType.NewtonMetre;
        private VolumeType volume = VolumeType.CubicMetre;
        private MassType mass = MassType.Kilogram;
        private AngleType angle = AngleType.Degrees;

        /// <summary>
        /// Gets or sets the type of angle unit.
        /// </summary>
        internal AngleType Angle
        {
            get
            {
                return angle;
            }

            set
            {
                angle = value;
                FileManager.LocalSettings.Values["UnitAngle"] = (int)angle;
            }
        }

        /// <summary>
        /// Gets or sets the type of mass unit.
        /// </summary>
        internal MassType Mass
        {
            get
            {
                return mass;
            }

            set
            {
                mass = value;
                FileManager.LocalSettings.Values["UnitMass"] = (int)mass;
            }
        }

        /// <summary>
        /// Gets or sets the type of length unit.
        /// </summary>
        internal LengthType Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;

                switch (length)
                {
                    case LengthType.Meter:
                        Camera.LengthUnitFactor = 1;
                        break;
                    case LengthType.CentiMeter:
                        Camera.LengthUnitFactor = (float)Constants.CentiMeterPerMeter;
                        break;
                    case LengthType.Foot:
                        Camera.LengthUnitFactor = (float)Constants.FootPerMeter;
                        break;
                    case LengthType.Inch:
                        Camera.LengthUnitFactor = (float)Constants.InchPerMeter;
                        break;
                    case LengthType.KiloMeter:
                        Camera.LengthUnitFactor = (float)Constants.KiloMeterPerMeter;
                        break;
                    case LengthType.Mil:
                        break;
                    case LengthType.Mile:
                        break;
                    case LengthType.Millimeter:
                        Camera.LengthUnitFactor = (float)Constants.MilliMeterPerMeter;
                        break;
                    case LengthType.Yard:
                        break;
                }

                FileManager.LocalSettings.Values["UnitLength"] = (int)length;
            }
        }

        /// <summary>
        /// Gets or sets the type of volume unit.
        /// </summary>
        internal VolumeType Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
                FileManager.LocalSettings.Values["UnitVolume"] = (int)volume;
            }
        }

        /// <summary>
        /// Gets or sets the type of moment unit.
        /// </summary>
        internal MomentType Moment
        {
            get
            {
                return moment;
            }

            set
            {
                moment = value;
                FileManager.LocalSettings.Values["UnitMoment"] = (int)moment;
            }
        }

        /// <summary>
        /// Gets or sets the type of pressure unit.
        /// </summary>
        internal PressureType Pressure
        {
            get
            {
                return pressure;
            }

            set
            {
                pressure = value;
                FileManager.LocalSettings.Values["UnitPressure"] = (int)pressure;
            }
        }

        /// <summary>
        /// Gets or sets the type of moment of inertia unit.
        /// </summary>
        internal MomentOfInertiaType MomentOfInertia
        {
            get
            {
                return momentOfInertia;
            }

            set
            {
                momentOfInertia = value;
                FileManager.LocalSettings.Values["UnitMomentOfInertia"] = (int)momentOfInertia;
            }
        }

        /// <summary>
        /// Gets or sets the type of area unit.
        /// </summary>
        internal AreaType Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
                FileManager.LocalSettings.Values["UnitArea"] = (int)area;
            }
        }

        /// <summary>
        /// Gets or sets the type of density unit.
        /// </summary>
        internal DensityType Density
        {
            get
            {
                return density;
            }

            set
            {
                density = value;
                FileManager.LocalSettings.Values["UnitDensity"] = (int)density;
            }
        }

        /// <summary>
        /// Gets or sets the type of force unit.
        /// </summary>
        internal ForceType Force
        {
            get
            {
                return force;
            }

            set
            {
                force = value;
                FileManager.LocalSettings.Values["UnitForce"] = (int)force;
            }
        }

        /// <summary>
        /// Gets or sets the type of force per length units.
        /// </summary>
        internal ForcePerLengthType ForcePerLength
        {
            get
            {
                return forcePerLength;
            }

            set
            {
                forcePerLength = value;
                FileManager.LocalSettings.Values["UnitForcePerLength"] = (int)forcePerLength;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsUnits"/> class.
        /// </summary>
        internal OptionsUnits()
        {
            try
            {
                if (FileManager.LocalSettings.Values.ContainsKey("UnitAngle"))
                {
                    angle = (AngleType)FileManager.LocalSettings.Values["UnitAngle"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitMass"))
                {
                    mass = (MassType)FileManager.LocalSettings.Values["UnitMass"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitLength"))
                {
                    length = (LengthType)FileManager.LocalSettings.Values["UnitLength"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitVolume"))
                {
                    volume = (VolumeType)FileManager.LocalSettings.Values["UnitVolume"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitMoment"))
                {
                    moment = (MomentType)FileManager.LocalSettings.Values["UnitMoment"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitPressure"))
                {
                    pressure = (PressureType)FileManager.LocalSettings.Values["UnitPressure"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitMomentOfInertia"))
                {
                    momentOfInertia = (MomentOfInertiaType)FileManager.LocalSettings.Values["UnitMomentOfInertia"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitArea"))
                {
                    area = (AreaType)FileManager.LocalSettings.Values["UnitArea"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitDensity"))
                {
                    density = (DensityType)FileManager.LocalSettings.Values["UnitDensity"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitForce"))
                {
                    force = (ForceType)FileManager.LocalSettings.Values["UnitForce"];
                }

                if (FileManager.LocalSettings.Values.ContainsKey("UnitForcePerLength"))
                {
                    forcePerLength = (ForcePerLengthType)FileManager.LocalSettings.Values["UnitForcePerLength"];
                }
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}