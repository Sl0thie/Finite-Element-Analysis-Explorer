namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Camera class provides a camera object to provide methods to manage the 2D display.
    /// </summary>
    internal static class Camera
    {
        /// <summary>
        /// The trim for the translation.
        /// </summary>
        private static readonly float TranslationTrim = 0.5f;
        private static string lengthUnitString = string.Empty;
        private static float lengthUnitFactor;
        private static float zoomTrimmed;
        private static float zoom;
        private static decimal largestLengthRatio;
        private static decimal largestAxialRatio;
        private static decimal largestNormalStress;

        /// <summary>
        /// Gets or sets the camera's grid.
        /// </summary>
        internal static Grid Grid { get; set; } = new Grid();

        /// <summary>
        /// Gets or sets the camera's view-port.
        /// </summary>
        internal static Viewport Viewport { get; set; } = new Viewport();

        /// <summary>
        /// Gets or sets the camera's line properties.
        /// </summary>
        internal static Line Line { get; set; } = new Line();

        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        internal static float UpperBound { get; set; }

        /// <summary>
        /// Gets or sets the lower bound.
        /// </summary>
        internal static float LowerBound { get; set; }

        /// <summary>
        /// Gets a matrix after calculating the translation, scale and centering.
        /// </summary>
        internal static Matrix3x2 TranslationMatrix
        {
            get
            {
                return Matrix3x2.CreateTranslation(Position)
                    * Matrix3x2.CreateScale(zoomTrimmed, -zoomTrimmed)
                    * Matrix3x2.CreateTranslation(Viewport.Center);
            }
        }

        /// <summary>
        /// Gets or sets the LengthUnitString.
        /// This is the postfix for length measurements such as mm, cm, m, km.
        /// </summary>
        internal static string LengthUnitString
        {
            get { return lengthUnitString; }
            set { lengthUnitString = value; }
        }

        /// <summary>
        /// Gets or sets the LengthUnitFactor.
        /// Example, millimeters per meter (1000) or inch per meter.
        /// </summary>
        internal static float LengthUnitFactor
        {
            get { return lengthUnitFactor; }
            set { lengthUnitFactor = value; }
        }

        /// <summary>
        /// Gets the Position. The centered position of the Camera in pixels.
        /// </summary>
        internal static Vector2 Position { get; private set; }

        /// <summary>
        /// Gets or sets the ZoomTrimmed.
        /// </summary>
        internal static float ZoomTrimmed
        {
            get
            {
                return zoomTrimmed;
            }

            set
            {
                zoomTrimmed = value;
                zoom = zoomTrimmed / Options.Display.CameraZoomTrim;
                Line.Unit = 1 / zoomTrimmed;
                UpdateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the Zoom. Current Zoom level with 1.0f being standard.
        /// </summary>
        internal static float Zoom
        {
            get
            {
                return zoom;
            }

            set
            {
                zoom = value;
                zoomTrimmed = zoom * Options.Display.CameraZoomTrim;
                Line.Unit = 1 / zoomTrimmed;
                UpdateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the largest length ratio.
        /// </summary>
        internal static decimal LargestLengthRatio
        {
            get { return largestLengthRatio; }
            set { largestLengthRatio = value; }
        }

        /// <summary>
        /// Gets or sets the largest axial ratio.
        /// </summary>
        internal static decimal LargestAxialRatio
        {
            get { return largestAxialRatio; }
            set { largestAxialRatio = value; }
        }

        /// <summary>
        /// Gets or sets the largest normal stress.
        /// </summary>
        internal static decimal LargestNormalStress
        {
            get { return largestNormalStress; }
            set { largestNormalStress = value; }
        }

        /// <summary>
        /// Returns the position after calculating the movement.
        /// </summary>
        /// <param name="cameraMovement">The movement vector.</param>
        internal static void MoveCamera(Vector2 cameraMovement)
        {
            Position += new Vector2(cameraMovement.X * Line.Unit * TranslationTrim, -cameraMovement.Y * Line.Unit * TranslationTrim);
            UpdateBounds();
        }

        /// <summary>
        /// Centers the camera on specific pixel coordinates.
        /// </summary>
        /// <param name="position">The position vector to center on.</param>
        internal static void CenterOn(Vector2 position)
        {
            Position = position;
            UpdateBounds();
        }

        /// <summary>
        /// Converts a screen position to a world position.
        /// </summary>
        /// <param name="screenPosition">The screen position to convert.</param>
        /// <returns>The converted world position.</returns>
        internal static Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            _ = Matrix3x2.Invert(TranslationMatrix, out Matrix3x2 tm);
            return Vector2.Transform(screenPosition, tm);
        }

        /// <summary>
        /// Calculates the scale changes when the mouse is scrolled.
        /// </summary>
        /// <param name="delta">The amount of change to calculate.</param>
        /// <param name="scalePoint">The center point of the scale operation.</param>
        internal static void ScaleDeltaScrollWheel(float delta, Vector2 scalePoint)
        {
            Vector2 scalePointWorld = ScreenToWorld(scalePoint);
            Vector2 oldCenterWorld = ScreenToWorld(Viewport.Center);
            Vector2 oldDistanceWorld = scalePointWorld - oldCenterWorld;
            float oldZoom = zoom;
            float scaleChange = 1 - (zoom * delta / oldZoom);
            Position = new Vector2(Position.X + (oldDistanceWorld.X * scaleChange), Position.Y + (oldDistanceWorld.Y * scaleChange));
            Zoom = zoom * delta;
            UpdateBounds();
            oldCenterWorld = ScreenToWorld(Viewport.Center);
        }

        #region Snap

        /// <summary>
        /// Snaps the distance to a snap point.
        /// </summary>
        /// <param name="distance">The distance to snap.</param>
        /// <param name="snapDistance">The snap length.</param>
        /// <returns>The distance after it is snapped.</returns>
        internal static float Snap(float distance, float snapDistance)
        {
            if (distance > 0)
            {
                if (distance % snapDistance < snapDistance / 2)
                {
                    return distance - (distance % snapDistance);
                }
                else
                {
                    return distance + (snapDistance - (distance % snapDistance));
                }
            }
            else
            {
                if (Math.Abs(distance % snapDistance) < snapDistance / 2)
                {
                    return distance - (distance % snapDistance);
                }
                else
                {
                    return distance + (-snapDistance - (distance % snapDistance));
                }
            }
        }

        #endregion

        /// <summary>
        /// Setup the camera from properties provided by a file.
        /// </summary>
        /// <param name="zoom">The zoom from the file.</param>
        /// <param name="centerOn">The center point to zoom.</param>
        internal static void SetupFromFile(float zoom, Vector2 centerOn)
        {
            CenterOn(centerOn);
            Zoom = zoom;
            UpdateBounds();
        }

        /// <summary>
        /// Updates the bounds. These are used to limit the calculations to only the screen size.
        /// </summary>
        internal static void UpdateBounds()
        {
            Viewport.CenterWorld = Viewport.Center / -zoomTrimmed;
            Viewport.BottomRight = new Vector2(-Position.X - Viewport.CenterWorld.X, -Position.Y - Viewport.CenterWorld.Y);
            Viewport.TopLeftMinor = new Vector2(
                Snap(-Position.X + Viewport.CenterWorld.X - Grid.SizeMinor, Grid.SizeMinor),
                Snap(-Position.Y + Viewport.CenterWorld.Y - Grid.SizeMinor, Grid.SizeMinor));
            Viewport.TopLeftNormal = new Vector2(
                Snap(-Position.X + Viewport.CenterWorld.X - Grid.SizeNormal, Grid.SizeNormal),
                Snap(-Position.Y + Viewport.CenterWorld.Y - Grid.SizeNormal, Grid.SizeNormal));
            Viewport.TopLeftMajor = new Vector2(
                Snap(-Position.X + Viewport.CenterWorld.X - Grid.SizeMajor, Grid.SizeMajor),
                Snap(-Position.Y + Viewport.CenterWorld.Y - Grid.SizeMajor, Grid.SizeMajor));
        }

        /// <summary>
        /// Update the length type.
        /// </summary>
        internal static void UpdateLengthType()
        {
            // Find the Smallest bound to suit the selected length type.
            switch (Options.Units.Length)
            {
                case LengthType.Millimeter:
                    lengthUnitString = " mm";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.CentiMeter:
                    lengthUnitString = " cm";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.Meter:
                    lengthUnitString = " m";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.KiloMeter:
                    lengthUnitString = " km";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        Grid.SizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        Grid.SizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        Grid.SizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.Inch:
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        Grid.SizeNormal = (float)Constants.MeterPerInch;
                        Grid.SizeMajor = (float)(Constants.MeterPerInch * 12);
                        Grid.SizeMinor = (float)(Constants.MeterPerInch / 16);
                    }

                    break;

                case LengthType.Foot:
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        Grid.SizeNormal = (float)Constants.MeterPerFoot;
                        Grid.SizeMajor = (float)(Constants.MeterPerFoot * 3);
                        Grid.SizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }

                    break;
            }

            UpdateBounds();
        }

        /// <summary>
        /// Updates all graphical elements.
        /// </summary>
        internal static void UpdateAllGraphics()
        {
            foreach (System.Collections.Generic.KeyValuePair<Tuple<decimal, decimal>, Node> node in Model.Nodes)
            {
                node.Value.UpdateDisplacement();
                node.Value.UpdateNodeGraphics();
            }

            foreach (System.Collections.Generic.KeyValuePair<int, Member> member in Model.Members)
            {
                foreach (System.Collections.Generic.KeyValuePair<int, Segment> segment in member.Value.Segments)
                {
                    segment.Value.UpdateGraphicsProperties();
                }
            }
        }

        /// <summary>
        /// Resets the camera.
        /// </summary>
        internal static void Reset()
        {
            Zoom = 0.5f;
            CenterOn(new Vector2(-Viewport.Center.X, -Viewport.Center.Y));
        }

        /// <summary>
        /// Updates the segment color.
        /// </summary>
        /// <param name="colorMode">The mode to use.</param>
        internal static void UpdateSegmentColor(int colorMode)
        {
            switch (colorMode)
            {
                case 0:
                    foreach (System.Collections.Generic.KeyValuePair<int, Member> member in Model.Members)
                    {
                        foreach (System.Collections.Generic.KeyValuePair<int, Segment> nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = member.Value.Section.Color;
                        }
                    }

                    break;

                case 1:
                    foreach (System.Collections.Generic.KeyValuePair<int, Member> member in Model.Members)
                    {
                        foreach (System.Collections.Generic.KeyValuePair<int, Segment> nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.LengthRatioColor;
                        }
                    }

                    break;

                case 2:
                    foreach (System.Collections.Generic.KeyValuePair<int, Member> member in Model.Members)
                    {
                        foreach (System.Collections.Generic.KeyValuePair<int, Segment> nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.AxialRatioColor;
                        }
                    }

                    break;

                case 3:
                    foreach (System.Collections.Generic.KeyValuePair<int, Member> member in Model.Members)
                    {
                        foreach (System.Collections.Generic.KeyValuePair<int, Segment> nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.NormalStressColor;
                        }
                    }

                    break;
            }
        }
    }
}