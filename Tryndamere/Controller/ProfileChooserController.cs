using System;
using System.Collections.Generic;
using System.Text;
using Tryndamere.Front;
using Tryndamere.Back;

namespace Tryndamere.Controller
{
    class ProfileChooserController : AbstractPageController
    {
        private List<Profile> profiles;

        public ProfileChooserController()
        {
            page = new ProfileChooser();

            profiles = Profile.getAll();
        }
    }
}
