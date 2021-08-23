namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// SectionProfile class.
    /// </summary>
    public class SectionProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionProfile"/> class.
        /// </summary>
        public SectionProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionProfile"/> class.
        /// </summary>
        /// <param name="name">The name of the section.</param>
        public SectionProfile(string name)
        {
            this.name = name;
        }

        private string path;

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string imagePath;

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        #region Added

        private string name;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion
    }
}