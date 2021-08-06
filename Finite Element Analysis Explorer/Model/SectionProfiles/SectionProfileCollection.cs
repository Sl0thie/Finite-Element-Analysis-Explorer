using System.Collections.Generic;

namespace Finite_Element_Analysis_Explorer
{
    internal class SectionProfileCollection : Dictionary<string, SectionProfile>
    {
        public SectionProfileCollection()
            : base()
        {
        }

        private Material currentSectionProfile;

        internal Material CurrentSectionProfile
        {
            get { return currentSectionProfile; }
            set { currentSectionProfile = value; }
        }
    }
}