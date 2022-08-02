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

        private AddProfile addProfileWindow;

        public ProfileChooserController()
        {
            page = new ProfileChooser();

            ((ProfileChooser)page).newProfileButton.Click += openAddProfile;

            profiles = Profile.create("Nom", "Description blablabla", "69");

            resetProfileList();
        }

        private void resetProfileList()
        {
            ((ProfileChooser)page).profileListBox.Items.Clear();

            foreach (Profile profile in profiles)
            {
                ProfileButton profileButton = new ProfileButton();
                profileButton.profileName.Text = profile.getMetaData.name;
                profileButton.profileDescription.Text = profile.getMetaData.description;
                profileButton.created.Text = "Création : " + profile.getMetaData.created.ToString("d");
                profileButton.lastModified.Text = "Création : " + profile.getMetaData.lastModified.ToString("d");
                profileButton.deleteButton.Click += deleteProfile;

                Frame frame = new Frame();
                frame.Content = profileButton;
                frame.Height = 100;
                ((ProfileChooser)page).profileListBox.Items.Add(frame);
            }
        }

        public void deleteProfile(object button, RoutedEventArgs e)
        {
            Profile profileToDelete = profiles.Find(a => a.getMetaData.name == ((ProfileButton)((Grid)((Button)button).Parent).Parent).profileName.Text);

            profileToDelete.delete();

            profiles = Profile.getAll();
            resetProfileList();
        }

        public void openAddProfile(object sender, RoutedEventArgs e)
        {
            if (addProfileWindow != null && addProfileWindow.IsLoaded)
                return;

            addProfileWindow = new AddProfile();
            addProfileWindow.addButton.Click += addProfile;
            addProfileWindow.Visibility = Visibility.Visible;
        }

        public void addProfile(object sender, RoutedEventArgs e)
        {
            if (addProfileWindow.nameTxBx.Text == null || addProfileWindow.nameTxBx.Text.Length < 1)
                return;
            if (addProfileWindow.descriptionTxBx.Text == null || addProfileWindow.descriptionTxBx.Text.Length < 1)
                return;
            if (addProfileWindow.passwordTxBx.Text == null || addProfileWindow.passwordTxBx.Text.Length < 1)
                return;
            if (addProfileWindow.confirmPasswordTxBx.Text == null || addProfileWindow.confirmPasswordTxBx.Text.Length < 1)
                return;

            if (addProfileWindow.passwordTxBx.Text != addProfileWindow.confirmPasswordTxBx.Text)
                return;

            profiles = Profile.create(addProfileWindow.nameTxBx.Text, addProfileWindow.descriptionTxBx.Text, addProfileWindow.passwordTxBx.Text);

            resetProfileList();

            addProfileWindow.Close();
        }
    }
}
