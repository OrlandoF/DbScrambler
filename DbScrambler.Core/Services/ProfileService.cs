using DbScrambler.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace DbScrambler.Core.Services
{
    public class ProfileService
    {
        const string _path = ".\\Profiles"; //TODO Move to parameters
        public Profile Read(string name)
        {
            string fullPath = Path.Combine(_path, name + ".json");
            Profile profile= JsonConvert.DeserializeObject<Profile>(File.ReadAllText(fullPath));
            return profile;
        }

        public void Save(string name, Profile profile)
        {
            string fullPath = Path.Combine(_path, name + ".json");
            string json = JsonConvert.SerializeObject(profile);
            File.WriteAllText(fullPath, json.ToString());
        }
    }
}
