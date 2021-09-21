namespace Finite_Element_Analysis_Explorer
{
    using System;

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

        internal AngleType Angle
        {
            get => angle;

            set
            {
                angle = value;
                FileManager.LocalSettings.Values["UnitAngle"] = (int)angle;
            }
        }

        internal MassType Mass
        {
            get => mass;

            set
            {
                mass = value;
                FileManager.LocalSettings.Values["UnitMass"] = (int)mass;
            }
        }

        /// <summary>
        /// Gets or sets the length type.
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

        internal VolumeType Volume
        {
            get => volume;

            set
            {
                volume = value;
                FileManager.LocalSettings.Values["UnitVolume"] = (int)volume;
            }
        }

        internal MomentType Moment
        {
            get => moment;

            set
            {
                moment = value;
                FileManager.LocalSettings.Values["UnitMoment"] = (int)moment;
            }
        }

        internal PressureType Pressure
        {
            get => pressure;

            set
            {
                pressure = value;
                FileManager.LocalSettings.Values["UnitPressure"] = (int)pressure;
            }
        }

        internal MomentOfInertiaType MomentOfInertia
        {
            get => momentOfInertia;

            set
            {
                momentOfInertia = value;
                FileManager.LocalSettings.Values["UnitMomentOfInertia"] = (int)momentOfInertia;
            }
        }

        internal AreaType Area
        {
            get => area;

            set
            {
                area = value;
                FileManager.LocalSettings.Values["UnitArea"] = (int)area;
            }
        }

        internal DensityType Density
        {
            get => density;

            set
            {
                density = value;
                FileManager.LocalSettings.Values["UnitDensity"] = (int)density;
            }
        }

        internal ForceType Force
        {
            get => force;

            set
            {
                force = value;
                FileManager.LocalSettings.Values["UnitForce"] = (int)force;
            }
        }

        internal ForcePerLengthType ForcePerLength
        {
            get => forcePerLength;

            set
            {
                forcePerLength = value;
                FileManager.LocalSettings.Values["UnitForcePerLength"] = (int)forcePerLength;
            }
        }

        internal OptionsUnits()
        {
            try
            {
                Angle = (AngleType)FileManager.LocalSettings.Values["UnitAngle"];
                Mass = (MassType)FileManager.LocalSettings.Values["UnitMass"];
                Length = (LengthType)FileManager.LocalSettings.Values["UnitLength"];
                Volume = (VolumeType)FileManager.LocalSettings.Values["UnitVolume"];
                Moment = (MomentType)FileManager.LocalSettings.Values["UnitMoment"];
                Pressure = (PressureType)FileManager.LocalSettings.Values["UnitPressure"];
                MomentOfInertia = (MomentOfInertiaType)FileManager.LocalSettings.Values["UnitMomentOfInertia"];
                Area = (AreaType)FileManager.LocalSettings.Values["UnitArea"];
                Density = (DensityType)FileManager.LocalSettings.Values["UnitDensity"];
                Force = (ForceType)FileManager.LocalSettings.Values["UnitForce"];
                ForcePerLength = (ForcePerLengthType)FileManager.LocalSettings.Values["UnitForcePerLength"];
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }
    }
}
