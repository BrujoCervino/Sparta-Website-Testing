using Newtonsoft.Json;
using System;
using System.IO;

namespace PageObjectModels
{
    public class ConfigReader
    {
        protected static ConfigRoot configObj => JsonConvert.DeserializeObject<ConfigRoot>(File.ReadAllText(jsonFilePath));
        protected static readonly string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "Config.json";

        public static ConfigRoot GetRoot()
        {
            string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "Config.json";
            ConfigRoot configObj = JsonConvert.DeserializeObject<ConfigRoot>(File.ReadAllText(jsonFilePath));
            return configObj;
        }
    }
}