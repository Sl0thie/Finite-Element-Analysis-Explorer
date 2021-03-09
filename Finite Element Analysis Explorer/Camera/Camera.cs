using System;
using System.Numerics;

namespace Finite_Element_Analysis_Explorer
{
    internal static class Camera
    {
        //Line Bounds
        private static float UpperBound;
        private static float LowerBound;

        private static string lengthUnitString = "";
        public static string LengthUnitString
        {
            get { return lengthUnitString; }
            set { lengthUnitString = value; }
        }

        private static float lengthUnitFactor;
        public static float LengthUnitFactor
        {
            get { return lengthUnitFactor; }
            set { lengthUnitFactor = value; }
        }

        // Centered Position of the Camera in pixels.
        internal static Vector2 Position { get; private set; }

        #region Grid

        private static float gridSizeNormal = 1f;
        internal static float GridSizeNormal
        {
            get { return gridSizeNormal; }
        }

        private static float gridSizeMinor = 0.1f;
        internal static float GridSizeMinor
        {
            get { return gridSizeMinor; }
        }

        private static float gridSizeMajor = 10f;
        internal static float GridSizeMajor
        {
            get { return gridSizeMajor; }
        }

        #endregion

        #region Zoom

        //private static float zoomTrim = 4320f;
        private static float zoomTrim = 216f;
        internal static float ZoomTrim
        {
            get { return zoomTrim; }
            set
            {
                zoomTrim = value;
                Options.CameraZoomTrim = zoomTrim;
            }
        }

        private static float zoomTrimmed;
        internal static float ZoomTrimmed
        {
            get { return zoomTrimmed; }
            set
            {
                zoomTrimmed = value;
                zoom = zoomTrimmed / zoomTrim;
                LineUnit = 1 / zoomTrimmed;
                UpdateBounds();
            }
        }

        // Current Zoom level with 1.0f being standard.
        private static float zoom;
        internal static float Zoom
        {
            get { return zoom; }
            set
            {
                zoom = value;
                zoomTrimmed = zoom * zoomTrim;
                LineUnit = 1 / zoomTrimmed;
                UpdateBounds();
            }
        }

        #endregion

        #region Viewport

        private static Vector2 viewportCenter;
        internal static Vector2 ViewportCenter
        {
            get { return viewportCenter; }
        }

        private static Vector2 viewportSize;
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

        /// Height and width of the viewport window which we need to adjust
        /// any time the player resizes the game window.
        internal static int ViewportWidth { get; set; }
        internal static int ViewportHeight { get; set; }

        private static Vector2 topLeftNormal;
        internal static Vector2 TopLeftNormal
        {
            get { return topLeftNormal; }
        }

        private static Vector2 topLeftMinor;
        internal static Vector2 TopLeftMinor
        {
            get { return topLeftMinor; }
        }

        private static Vector2 topLeftMajor;
        internal static Vector2 TopLeftMajor
        {
            get { return topLeftMajor; }
        }

        private static Vector2 bottomRight;
        internal static Vector2 BottomRight
        {
            get { return bottomRight; }
        }

        private static Vector2 viewportCenterWorld;

        #endregion

        #region Line Widths and Lengths

        private static float lineUnit;
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

                if (lineUnit < LowerBound) { UpdateLengthType(); }
                if (lineUnit > UpperBound) { UpdateLengthType(); }
            }
        }

        private static float constraintRadius;
        public static float ConstraintRadius
        {
            get { return constraintRadius; }
        }

        private static float lineLengthLDLArrow;
        public static float LineLengthLDLArrow
        {
            get { return lineLengthLDLArrow; }
        }

        private static float lineLengthForceArrow;
        public static float LineLengthForceArrow
        {
            get { return lineLengthForceArrow; }
        }

        private static float constraintWidth;
        public static float ConstraintWidth
        {
            get { return constraintWidth; }
        }

        #endregion

        internal static Matrix3x2 TranslationMatrix
        {
            get
            {
                return Matrix3x2.CreateTranslation(Position)
                    * Matrix3x2.CreateScale(zoomTrimmed, -zoomTrimmed)
                    * Matrix3x2.CreateTranslation(ViewportCenter);
            }
            //set { TranslationMatrix = value; }
        }

        internal static void MoveCamera(Vector2 cameraMovement)
        {
            Position = Position + (new Vector2(cameraMovement.X * LineUnit * translationTrim, -cameraMovement.Y * LineUnit * translationTrim));
            UpdateBounds();
        }
        internal static float translationTrim = 0.5f;

        // Center the camera on specific pixel coordinates
        internal static void CenterOn(Vector2 position)
        {
            Position = position;
            UpdateBounds();
        }

        internal static Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Matrix3x2 tm;
            bool rv = Matrix3x2.Invert(TranslationMatrix, out tm);
            return Vector2.Transform(screenPosition, tm);
        }

        internal static void ScaleDeltaScrollWheel(float delta, Vector2 scalePoint)
        {
            Vector2 scalePointWorld = ScreenToWorld(scalePoint);
            Vector2 oldCenterWorld = ScreenToWorld(viewportCenter);
            Vector2 oldDistanceWorld = scalePointWorld - oldCenterWorld;
            float oldZoom = zoom;
            float scaleChange = 1 - ((zoom * delta) / oldZoom);
            Position = new Vector2(Position.X + (oldDistanceWorld.X * scaleChange), Position.Y + (oldDistanceWorld.Y * scaleChange));
            Zoom = zoom * delta;
            UpdateBounds();
            oldCenterWorld = ScreenToWorld(viewportCenter);
        }

        #region Snap

        internal static float Snap(float distance, float snapDistance)
        {
            if (distance > 0)
            {
                if (distance % snapDistance < snapDistance / 2)
                    return distance - distance % snapDistance;
                else
                    return distance + (snapDistance - distance % snapDistance);
            }
            else
            {
                if (Math.Abs(distance % snapDistance) < snapDistance / 2)
                    return distance - distance % snapDistance;
                else
                    return distance + (-snapDistance - distance % snapDistance);
            }
        }

        #endregion

        internal static void SetupFromFile(float _zoom, Vector2 _centerOn)
        {
            CenterOn(_centerOn);
            Zoom = _zoom;
            UpdateBounds();
        }

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

        internal static void UpdateLengthType()
        {
            //Find the Smallest bound to suit the selected length type.
            switch (Options.Length)
            {
                case LengthType.Millimeter:
                    lengthUnitString = " mm";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.CentiMeter:
                    lengthUnitString = " cm";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.Meter:
                    lengthUnitString = " m";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.KiloMeter:
                    lengthUnitString = " km";
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10000m);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1000m);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 100m);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1000m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 10m);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 100m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 1m);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 10m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.1m);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        gridSizeMajor = (float)(Constants.MeterPerMeter * 1m);
                        gridSizeNormal = (float)(Constants.MeterPerMeter * 0.1m);
                        gridSizeMinor = (float)(Constants.MeterPerMeter * 0.01m);
                    }

                    break;

                case LengthType.Inch:
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        gridSizeNormal = (float)(Constants.MeterPerInch);
                        gridSizeMajor = (float)(Constants.MeterPerInch * 12);
                        gridSizeMinor = (float)(Constants.MeterPerInch / 16);
                    }
                    break;

                case LengthType.Foot:
                    if (zoom < 0.00001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.0001)
                    {
                        LowerBound = 0.00001f;
                        UpperBound = 0.0001f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.001)
                    {
                        LowerBound = 0.0001f;
                        UpperBound = 0.001f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.01)
                    {
                        LowerBound = 0.001f;
                        UpperBound = 0.01f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 0.1)
                    {
                        LowerBound = 0.01f;
                        UpperBound = 0.1f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 1)
                    {
                        LowerBound = 0.1f;
                        UpperBound = 1f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 10)
                    {
                        LowerBound = 1f;
                        UpperBound = 10f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 100)
                    {
                        LowerBound = 10f;
                        UpperBound = 100f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 1000)
                    {
                        LowerBound = 100f;
                        UpperBound = 1000f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    else if (zoom < 10000)
                    {
                        LowerBound = 1000f;
                        UpperBound = 10000f;
                        gridSizeNormal = (float)(Constants.MeterPerFoot);
                        gridSizeMajor = (float)(Constants.MeterPerFoot * 3);
                        gridSizeMinor = (float)(Constants.MeterPerFoot / 12);
                    }
                    break;
            }

            UpdateBounds();
        }

        internal static void UpdateAllGraphics()
        {
            foreach (var Item in Model.Nodes)
            {
                Item.Value.UpdateDisplacement();
                Item.Value.UpdateNodeGraphics();
            }

            foreach (var Item in Model.Members)
            {
                foreach (var nextItem in Item.Value.Segments)
                {
                    nextItem.Value.UpdateGraphicsProperties();
                }
            }
        }

        internal static void Reset()
        {
            Zoom = 0.5f;
            CenterOn(new Vector2(-viewportCenter.X, -viewportCenter.Y));
        }

        private static decimal largestLengthRatio;
        public static decimal LargestLengthRatio
        {
            get { return largestLengthRatio; }
            set { largestLengthRatio = value; }
        }

        private static decimal largestAxialRatio;
        public static decimal LargestAxialRatio
        {
            get { return largestAxialRatio; }
            set { largestAxialRatio = value; }
        }

        private static decimal largestNormalStress;
        public static decimal LargestNormalStress
        {
            get { return largestNormalStress; }
            set { largestNormalStress = value; }
        }

        internal static void UpdateSegmentColor(int colorMode)
        {
            switch (colorMode)
            {
                case 0:
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = Item.Value.Section.Color;
                        }
                    }
                    break;

                case 1:
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.LengthRatioColor;
                        }
                    }
                    break;

                case 2:
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.AxialRatioColor;
                        }
                    }
                    break;

                case 3:
                    foreach (var Item in Model.Members)
                    {
                        foreach (var nextSegment in Item.Value.Segments)
                        {
                            nextSegment.Value.CurrentColor = nextSegment.Value.NormalStressColor;
                        }
                    }
                    break;
            }
        }
    }
}