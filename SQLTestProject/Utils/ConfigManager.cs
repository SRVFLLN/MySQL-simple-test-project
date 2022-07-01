using Newtonsoft.Json.Linq;
using System.IO;


namespace SQLTestProject
{
    public static class ConfigManager
    {
        private static string pathToFile = "../../../Resources/Config.json";

        public static string GetSettings(ConfigKeys key) 
        {
            JObject keyValues = JObject.Parse(File.ReadAllText(pathToFile));
            switch (key) 
            {
                case ConfigKeys.Host:
                    return (string)keyValues.SelectToken("host");
                case ConfigKeys.Port:
                    return (string)keyValues.SelectToken("port");
                case ConfigKeys.Database:
                    return (string)keyValues.SelectToken("database");
                case ConfigKeys.Username:
                    return (string)keyValues.SelectToken("username");
                case ConfigKeys.Password:
                    return (string)keyValues.SelectToken("password");
                default:
                    return null;
            }
        } 
    }
}
