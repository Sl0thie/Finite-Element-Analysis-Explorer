namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// SectionProfilesList class.
    /// </summary>
    internal static class SectionProfilesList
    {
        /// <summary>
        /// Loads the section profiles list.
        /// </summary>
        internal static void LoadList()
        {
            SectionProfile tmpSectionProfile = new SectionProfile("I Beam")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbIBeam.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageIBeam.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Rectangle")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidRectangle.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidRectangle.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Rectangle")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowRectangle.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowRectangle.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Square")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidSquare.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidSquare.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Square")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowSquare.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowSquare.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Circle")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidCircle.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidCircle.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Circle")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowCircle.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowCircle.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Elipse")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidElipse.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidCircle.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Elipse")
            {
                Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowElipse.png",
                ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowCircle.png",
            };
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);
        }
    }
}
