using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using Tryndamere.Front;
using Tryndamere.Back;
using System.Windows;

namespace Tryndamere.Controller
{
    class ProfileChooserController : AbstractPageController
    {
        private List<Profile> profiles;

        public ProfileChooserController()
        {
            page = new ProfileChooser();

            profiles = Profile.create("Nom", "Description blablabla", "69");

            foreach(Profile profile in profiles)
            {
                ProfileButton profileButton = new ProfileButton();
                profileButton.profileName.Text = profile.getMetaData.name;
                profileButton.profileDescription.Text = profile.getMetaData.description;
                profileButton.created.Text = "Création : " + profile.getMetaData.created.ToString("d");
                profileButton.lastModified.Text = "Création : " + profile.getMetaData.lastModified.ToString("d");
                profileButton.deleteButton.Click += deleteProfile;

                Frame frame = new Frame();
                frame.Content = profileButton;
                ((ProfileChooser)page).profileListBox.Items.Add(frame);
            }
        }

        public void deleteProfile(object sender, RoutedEventArgs e)
        {

        }
    }
}
