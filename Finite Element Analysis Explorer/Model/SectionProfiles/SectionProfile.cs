namespace Finite_Element_Analysis_Explorer
{
    public class SectionProfile
    {
        public SectionProfile()
        {
        }

        public SectionProfile(string _name)
        {
            name = _name;
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        #region Added

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion
    }
}