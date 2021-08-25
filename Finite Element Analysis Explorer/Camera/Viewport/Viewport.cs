namespace Finite_Element_Analysis_Explorer
{
    using System.Numerics;

    /// <summary>
    /// View port class contains properties and methods for the camera view port.
    /// </summary>
    internal class Viewport
    {
        private Vector2 center;
        private Vector2 size;
        private Vector2 topLeftNormal;
        private Vector2 topLeftMinor;
        private Vector2 topLeftMajor;
        private Vector2 bottomRight;
        private Vector2 centerWorld;

        /// <summary>
        /// Gets or sets the viewPort center. Co-ordinates of the center of the view port.
        /// </summary>
        internal Vector2 Center
        {
            get { return center; }

            set { center = value; }
        }

        /// <summary>
        /// Gets or sets the center of the world.
        /// </summary>
        internal Vector2 CenterWorld
        {
            get { return centerWorld; }

            set { centerWorld = value; }
        }

        /// <summary>
        /// Gets or sets the view port size.
        /// </summary>
        internal Vector2 Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
                center = new Vector2((int)(size.X * 0.5f), (int)(size.Y * 0.5f));
                Width = (int)size.X;
                Height = (int)size.Y;
                Camera.UpdateBounds();
            }
        }

        /// <summary>
        /// Gets or sets the view port width. Width of the view port window which we need to adjust any time the player resizes the application window.
        /// </summary>
        internal int Width { get; set; }

        /// <summary>
        /// Gets or sets the view port height. Height of the view port window which we need to adjust any time the player resizes the application window.
        /// </summary>
        internal int Height { get; set; }

        /// <summary>
        /// Gets or sets the top left normal.
        /// </summary>
        internal Vector2 TopLeftNormal
        {
            get { return topLeftNormal; }

            set { topLeftNormal = value; }
        }

        /// <summary>
        /// Gets or sets the top left minor.
        /// </summary>
        internal Vector2 TopLeftMinor
        {
            get { return topLeftMinor; }

            set { topLeftMinor = value; }
        }

        /// <summary>
        /// Gets or sets the top left major.
        /// </summary>
        internal Vector2 TopLeftMajor
        {
            get { return topLeftMajor; }

            set { topLeftMajor = value; }
        }

        /// <summary>
        /// Gets or sets the bottom right.
        /// </summary>
        internal Vector2 BottomRight
        {
            get { return bottomRight; }

            set { bottomRight = value; }
        }
    }
}
