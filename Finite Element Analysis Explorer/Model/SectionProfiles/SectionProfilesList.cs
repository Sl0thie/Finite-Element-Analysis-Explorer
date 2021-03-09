using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Element_Analysis_Explorer
{
    internal static class SectionProfilesList
    {
        internal static void LoadList()
        {
            SectionProfile tmpSectionProfile = new SectionProfile("I Beam");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbIBeam.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageIBeam.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Rectangle");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidRectangle.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidRectangle.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Rectangle");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowRectangle.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowRectangle.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Square");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidSquare.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidSquare.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Square");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowSquare.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowSquare.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Circle");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidCircle.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidCircle.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Circle");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowCircle.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowCircle.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Solid Elipse");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbSolidElipse.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageSolidCircle.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);

            tmpSectionProfile = new SectionProfile("Hollow Elipse");
            tmpSectionProfile.Path = "ms-appx:///Assets/ProfileThumbs/ProfileThumbHollowElipse.png";
            tmpSectionProfile.ImagePath = "ms-appx:///Assets/SectionProfiles/ProfileImageHollowCircle.png";
            Model.SectionProfiles.Add(tmpSectionProfile.Name, tmpSectionProfile);
        }
    }
}
