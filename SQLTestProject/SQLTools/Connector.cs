using MySql.Data.MySqlClient;

namespace SQLTestProject
{
    public static class Connector
    {
        public static MySqlConnection GetConnection()
        {
            string ConnStr = "Server=" + ConfigManager.GetSettings(ConfigKeys.Host) + 
                ";Database=" + ConfigManager.GetSettings(ConfigKeys.Database) +
                ";port=" + ConfigManager.GetSettings(ConfigKeys.Port) + 
                ";User Id=" + ConfigManager.GetSettings(ConfigKeys.Username) + 
                ";password=" + ConfigManager.GetSettings(ConfigKeys.Password);
            return new MySqlConnection(ConnStr);
        }
    }
}
