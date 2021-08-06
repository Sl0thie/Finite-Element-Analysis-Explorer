using System;
using System.Numerics;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Camera class provides a camera object to provide methods to manage the 2D display.
    /// </summary>
    internal static class Camera
    {
        /// <summary>
        /// Gets or sets the LengthUnitString.
        /// </summary>
        public static string LengthUnitString
        {
            get { return lengthUnitString; }
            set { lengthUnitString = value; }
        }

        /// <summary>
        /// Gets or sets the LengthUnitFactor.
        /// </summary>
        public static float LengthUnitFactor
        {
            get { return lengthUnitFactor; }
            set { lengthUnitFactor = value; }
        }

        /// <summary>
        /// Gets the Position. The centered position of the Camera in pixels.
        /// </summary>
        internal static Vector2 Position { get; private set; }

        #region Grid

        /// <summary>
        /// Gets the grid size for normal lines.
        /// </summary>
        internal static float GridSizeNormal
        {
            get { return gridSizeNormal; }
        }

        /// <summary>
        /// Gets the grid size for the minor grid.
        /// </summary>
        internal static float GridSizeMinor
        {
            get { return gridSizeMinor; }
        }

        /// <summary>
        /// Gets the grid size for the major grid.
        /// </summary>
        internal static float GridSizeMajor
        {
            get { return gridSizeMajor; }
        }

        #endregion

        #region Zoom

        /// <summary>
        /// Gets or sets the ZoomTrim.
        /// </summary>
        internal static float ZoomTrim
        {
            get
            {
                return zoomTrim;
            }

            set
            {
                zoomTrim = value;
                Options.CameraZoomTrim = zoomTrim;
            }
        }

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
                zoom = zoomTrimmed / zoomTrim;
                LineUnit = 1 / zoomTrimmed;
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
                zoomTrimmed = zoom * zoomTrim;
                LineUnit = 1 / zoomTrimmed;
                UpdateBounds();
            }
        }

        #endregion

        #region View-port

        /// <summary>
        /// Gets the ViewPortCenter. Co-ordinates of the center of the view port.
        /// </summary>
        internal static Vector2 ViewportCenter
        {
            get { return viewportCenter; }
        }

        /// <summary>
        /// Gets or sets the view port size.
        /// </summary>
        internal static Vector2 ViewportSize
        {
            get
            {
                return viewportSize;
            }

            set
            {
                viewportSize = value;
                viewportCenter = new Vector2((int)(viewportSize.X * 0.5f), (int)(viewportSize.Y * 0.5f));
                ViewportWidth = (int)viewportSize.X;
                ViewportHeight = (int)viewportSize.Y;
                UpdateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the view port width. Width of the view port window which we need to adjust any time the player resizes the application window.
        /// </summary>
        internal static int ViewportWidth { get; set; }

        /// <summary>
        /// Gets or sets the view port height. Height of the view port window which we need to adjust any time the player resizes the application window.
        /// </summary>
        internal static int ViewportHeight { get; set; }

        /// <summary>
        /// Gets the top left normal.
        /// </summary>
        internal static Vector2 TopLeftNormal
        {
            get { return topLeftNormal; }
        }

        /// <summary>
        /// Gets the top left minor.
        /// </summary>
        internal static Vector2 TopLeftMinor
        {
            get { return topLeftMinor; }
        }

        /// <summary>
        /// Gets the top left major.
        /// </summary>
        internal static Vector2 TopLeftMajor
        {
            get { return topLeftMajor; }
        }

        /// <summary>
        /// Gets the bottom right.
        /// </summary>
        internal static Vector2 BottomRight
        {
            get { return bottomRight; }
        }

        #endregion

        #region Line Widths and Lengths

        /// <summary>
        /// Gets or sets the line unit.
        /// </summary>
        internal static float LineUnit
        {
            get
            {
                return lineUnit;
            }

            set
            {
                lineUnit = value;
                constraintWidth = lineUnit * 2;
                constraintRadius = lineUnit * 5;
                lineLengthLDLArrow = lineUnit * 8;
                lineLengthForceArrow = lineUnit * 15;

                if (lineUnit < lowerBound)
                {
                    UpdateLengthType();
                }

                if (lineUnit > upperBound)
                {
                    UpdateLengthType();
                }
            }
        }

        /// <summary>
        /// Gets the constrain radius.
        /// </summary>
        public static float ConstraintRadius
        {
            get { return constraintRadius; }
        }

        /// <summary>
        /// Gets the line length of the DLArrow.
        /// </summary>
        public static float LineLengthLDLArrow
        {
            get { return lineLengthLDLArrow; }
        }

        /// <summary>
        /// Gets the line length of the Force Arrow.
        /// </summary>
        public static float LineLengthForceArrow
        {
            get { return lineLengthForceArrow; }
        }

        /// <summary>
        /// Gets the constrain width.
        /// </summary>
        public static float ConstraintWidth
        {
            get { return constraintWidth; }
        }

        #endregion

        /// <summary>
        /// Gets or sets the largest length ratio.
        /// </summary>
        public static decimal LargestLengthRatio
        {
            get { return largestLengthRatio; }
            set { largestLengthRatio = value; }
        }

        /// <summary>
        /// Gets or sets the largest axial ratio.
        /// </summary>
        public static decimal LargestAxialRatio
        {
            get { return largestAxialRatio; }
            set { largestAxialRatio = value; }
        }

        /// <summary>
        /// Gets or sets the largest normal stress.
        /// </summary>
        public static decimal LargestNormalStress
        {
            get { return largestNormalStress; }
            set { largestNormalStress = value; }
        }

        /// <summary>
        /// The trim for the translation.
        /// </summary>
        internal static float TranslationTrim = 0.5f;

        // Line Bounds
        private static float upperBound;
        private static float lowerBound;
        private static string lengthUnitString = string.Empty;
        private static float lengthUnitFactor;
        private static float gridSizeNormal = 1f;
        private static float gridSizeMinor = 0.1f;
        private static float gridSizeMajor = 10f;
        private static float zoomTrim = 216f;
        private static float zoomTrimmed;
        private static float zoom;
        private static Vector2 viewportCenter;
        private static Vector2 viewportSize;
        private static Vector2 topLeftNormal;
        private static Vector2 topLeftMinor;
        private static Vector2 topLeftMajor;
        private static Vector2 bottomRight;
        private static Vector2 viewportCenterWorld;
        private static float lineUnit;
        private static float constraintRadius;
        private static float lineLengthLDLArrow;
        private static float lineLengthForceArrow;
        private static float constraintWidth;
        private static decimal largestLengthRatio;
        private static decimal largestAxialRatio;
        private static decimal largestNormalStress;

        /// <summary>
        /// Gets a matrix after calculating the translation, scale and centering.
        /// </summary>
        internal static Matrix3x2 TranslationMatrix
        {
            get
            {
                return Matrix3x2.CreateTranslation(Position)
                    * Matrix3x2.CreateScale(zoomTrimmed, -zoomTrimmed)
                    * Matrix3x2.CreateTranslation(ViewportCenter);
            }
        }

        /// <summary>
        /// Returns the position after calculating the movement.
        /// </summary>
        /// <param name="cameraMovement">The movement vector.</param>
        internal static void MoveCamera(Vector2 cameraMovement)
        {
            Position += new Vector2(cameraMovement.X * LineUnit * TranslationTrim, -cameraMovement.Y * LineUnit * TranslationTrim);
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
            Matrix3x2 tm;
            bool rv = Matrix3x2.Invert(TranslationMatrix, out tm);
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
            Vector2 oldCenterWorld = ScreenToWorld(viewportCenter);
            Vector2 oldDistanceWorld = scalePointWorld - oldCenterWorld;
            float oldZoom = zoom;
            float scaleChange = 1 - (zoom * delta / oldZoom);
            Position = new Vector2(Position.X + (oldDistanceWorld.X * scaleChange), Position.Y + (oldDistanceWorld.Y * scaleChange));
            Zoom = zoom * delta;
            UpdateBounds();
            oldCenterWorld = ScreenToWorld(viewportCenter);
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
                    return distance - distance % snapDistance;
                }
                else
                {
                    return distance + (snapDistance - distance % snapDistance);
                }
            }
            else
            {
                if (Math.Abs(distance % snapDistance) < snapDistance / 2)
                {
                    return distance - distance % snapDistance;
                }
                else
                {
                    return distance + (-snapDistance - distance % snapDistance);
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
        private static void UpdateBounds()
        {
            viewportCenterWorld = viewportCenter / -zoomTrimmed;
            bottomRight = new Vector2(-Position.X - viewportCenterWorld.X, -Position.Y - viewportCenterWorld.Y);
            topLeftMinor = new Vector2(
                Snap(-Position.X + viewportCenterWorld.X - gridSizeMinor, gridSizeMinor),
                Snap(-Position.Y + viewportCenterWorld.Y - gridSizeMinor, gridSizeMinor));
            topLeftNormal = new Vector2(
                Snap(-Position.X + viewportCenterWorld.X - gridSizeNormal, gridSizeNormal),
                Snap(-Position.Y + viewportCenterWorld.Y - gridSizeNormal, gridSizeNormal));
            topLeftMajor = new Vector2(
                Snap(-Position.X + viewportCenterWorld.X - gridSizeMajor, gridSizeMajor),
                Snap(-Position.Y + viewportCenterWorld.Y - gridSizeMajor, gridSizeMajor));
        }

        /// <summary>
        /// Update the length type.
        /// </summary>
        internal static void UpdateLengthType()
        {
            // Find the Smallest bound to suit the selected length type.
            switch (Options.Length)
            {
                case LengthType.Millimeter:
                    lengthUnitString = " mm";
                    if (zoom < 0.00001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        lowerBound = 0.0001f;
                        upperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        lowerBound = 0.001f;
                        upperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        lowerBound = 0.01f;
                        upperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        lowerBound = 0.1f;
                        upperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        lowerBound = 1f;
                        upperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        lowerBound = 10f;
                        upperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        lowerBound = 100f;
                        upperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        lowerBound = 1000f;
                        upperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.CentiMeter:
                    lengthUnitString = " cm";
                    if (zoom < 0.00001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        lowerBound = 0.0001f;
                        upperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        lowerBound = 0.001f;
                        upperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        lowerBound = 0.01f;
                        upperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        lowerBound = 0.1f;
                        upperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        lowerBound = 1f;
                        upperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        lowerBound = 10f;
                        upperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        lowerBound = 100f;
                        upperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        lowerBound = 1000f;
                        upperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.Meter:
                    lengthUnitString = " m";
                    if (zoom < 0.00001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        lowerBound = 0.0001f;
                        upperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        lowerBound = 0.001f;
                        upperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        lowerBound = 0.01f;
                        upperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        lowerBound = 0.1f;
                        upperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        lowerBound = 1f;
                        upperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        lowerBound = 10f;
                        upperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        lowerBound = 100f;
                        upperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        lowerBound = 1000f;
                        upperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.KiloMeter:
                    lengthUnitString = " km";
                    if (zoom < 0.00001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        lowerBound = 0.0001f;
                        upperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        lowerBound = 0.001f;
                        upperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        lowerBound = 0.01f;
                        upperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        lowerBound = 0.1f;
                        upperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        lowerBound = 1f;
                        upperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        lowerBound = 10f;
                        upperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        lowerBound = 100f;
                        upperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        lowerBound = 1000f;
                        upperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.Inch:
                    if (zoom < 0.00001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.0001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.001)
                    {
                        lowerBound = 0.0001f;
                        upperBound = 0.001f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.01)
                    {
                        lowerBound = 0.001f;
                        upperBound = 0.01f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.1)
                    {
                        lowerBound = 0.01f;
                        upperBound = 0.1f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 1)
                    {
                        lowerBound = 0.1f;
                        upperBound = 1f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 10)
                    {
                        lowerBound = 1f;
                        upperBound = 10f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 100)
                    {
                        lowerBound = 10f;
                        upperBound = 100f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 1000)
                    {
                        lowerBound = 100f;
                        upperBound = 1000f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 10000)
                    {
                        lowerBound = 1000f;
                        upperBound = 10000f;
                        gridSizeNormal = (float)Constants.MeterPerInch;
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    break;

                case LengthType.Foot:
                    if (zoom < 0.00001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.0001)
                    {
                        lowerBound = 0.00001f;
                        upperBound = 0.0001f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.001)
                    {
                        lowerBound = 0.0001f;
                        upperBound = 0.001f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.01)
                    {
                        lowerBound = 0.001f;
                        upperBound = 0.01f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.1)
                    {
                        lowerBound = 0.01f;
                        upperBound = 0.1f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 1)
                    {
                        lowerBound = 0.1f;
                        upperBound = 1f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 10)
                    {
                        lowerBound = 1f;
                        upperBound = 10f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 100)
                    {
                        lowerBound = 10f;
                        upperBound = 100f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 1000)
                    {
                        lowerBound = 100f;
                        upperBound = 1000f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 10000)
                    {
                        lowerBound = 1000f;
                        upperBound = 10000f;
                        gridSizeNormal = (float)Constants.MeterPerFoot;
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
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
            foreach (var node in Model.Nodes)
            {
                node.Value.UpdateDisplacement();
                node.Value.UpdateNodeGraphics();
            }

            foreach (var member in Model.Members)
            {
                foreach (var segment in member.Value.Segments)
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
            CenterOn(new Vector2(-viewportCenter.X, -viewportCenter.Y));
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
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = member.Value.Section.Color;
                        }
                    }

                    break;

                case 1:
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.LengthRatioColor;
                        }
                    }

                    break;

                case 2:
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.AxialRatioColor;
                        }
                    }

                    break;

                case 3:
                    foreach (var member in Model.Members)
                    {
                        foreach (var nextSegment in member.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.NormalStressColor;
                        }
                    }

                    break;
            }
        }
    }
}