using System.Collections.Generic;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// SectionProfileCollection class.
    /// </summary>
    internal class SectionProfileCollection : Dictionary<string, SectionProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionProfileCollection"/> class.
        /// </summary>
        public SectionProfileCollection()
            : base()
        {
        }

        private Material currentSectionProfile;

        /// <summary>
        /// Gets or sets the current section profile.
        /// </summary>
        internal Material CurrentSectionProfile
        {
            get { return currentSectionProfile; }
            set { currentSectionProfile = value; }
        }
    }
}