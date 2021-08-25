namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Grid class contains properties and methods for the camera's grid.
    /// </summary>
    internal class Grid
    {
        /// <summary>
        /// Gets or sets the grid size for normal lines.
        /// </summary>
        internal float SizeNormal { get; set; } = 1f;

        /// <summary>
        /// Gets or sets the grid size for the minor grid.
        /// </summary>
        internal float SizeMinor { get; set; } = 0.1f;

        /// <summary>
        /// Gets or sets the grid size for the major grid.
        /// </summary>
        internal float SizeMajor { get; set; } = 10f;
    }
}