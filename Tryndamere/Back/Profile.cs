using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

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
                Profile profile = new Profile(profileFolder);

                if (profile.metaData != null)
                    returner.Add(profile);
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

        private String metaDataFile { get => profileFolder + "metadata.json"; }

        public Model.ProfileMetaData getMetaData { get => metaData; }


        private Profile(String profileFolder)
        {
            if (!File.Exists(profileFolder + "\\metadata.json"))
                return;

            try
            {
                string metadataContent = File.ReadAllText(profileFolder + "\\metadata.json");
                metaData = JsonSerializer.Deserialize<Model.ProfileMetaData>(metadataContent);
            }
            catch(JsonException e)
            {
                return;
            }
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

            File.WriteAllText(profileFolder + "metadata.json", JsonSerializer.Serialize(metaData));
        }

        public void delete()
        {
            foreach(String file in Directory.GetFiles(profileFolder))
            {
                File.Delete(file);
            }
            Directory.Delete(profileFolder);
        }
    }
}
