using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tryndamere.Back
{
    class Profile
    {

        static public List<Profile> getAll()
        {
            List<Profile> returner = new List<Profile>();

            if (!Directory.Exists("Data\\"))
            {
                Directory.CreateDirectory("Data\\");
            }

            foreach (String profileFolder in Directory.GetDirectories("Data\\"))
            {
                returner.Add(new Profile(profileFolder));
            }

            return returner;
        }

        static public List<Profile> create(String name, String description, String password)
        {

            if (!Directory.Exists("Data\\"))
            {
                Directory.CreateDirectory("Data\\");
            }

            //Si un profil au meme nom existe déjà
            if (Directory.Exists("Data\\" + name + "\\"))
            {
                return Profile.getAll();
            }

            new Profile(name, description, password);

            return Profile.getAll();
        }




        private Model.ProfileMetaData metaData;

        private String profileFolder { get => "Data\\" + metaData.name + "\\"; }


        private Profile(String profileFolder)
        {

        }

        private Profile(String name, String description, String password)
        {
            metaData = new Model.ProfileMetaData();

            metaData.name = name;
            metaData.description = description;
            metaData.created = DateTime.Now;
            metaData.lastModified = metaData.created;

            save();
        }

        private void save()
        {
            if (!Directory.Exists(profileFolder))
            {
                Directory.CreateDirectory(profileFolder);
            }


        }

        private void delete()
        {
            Directory.Delete(profileFolder);
        }
    }
}
