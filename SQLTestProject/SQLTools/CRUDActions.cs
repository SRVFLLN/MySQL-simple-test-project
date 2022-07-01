using MySql.Data.MySqlClient;

namespace SQLTestProject
{
    public static class CRUDActions
    {

        public static MySqlDataReader GetData(string selections, string tablename, string condition = null)
        {
            var connection = Connector.GetConnection();
            connection.Open();
            string request = $"SELECT {selections} FROM {tablename}";
            if (condition != null)
            {
                request += $" {condition}";
            }
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = request;
            var reader = command.ExecuteReader();
            return reader;
        }

        public static int AddRecord(string tablename, string insertions, string values)
        {
            using (var connection = Connector.GetConnection()) 
            {
                connection.Open();
                string request = $"INSERT INTO {tablename} ({insertions}) VALUES ({values})";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = request;
                return command.ExecuteNonQuery();
            }
        }

        public static int AddModel<T>(string tablename, T model)
        {
            using (var connection = Connector.GetConnection())
            {
                connection.Open();
                string request = $"INSERT INTO {tablename} VALUES({model})";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = request;
                return command.ExecuteNonQuery();
            }
        }

        public static int DeleteData(string tablename, string condition)
        {
            using (var connection = Connector.GetConnection())
            {
                connection.Open();
                string request = $"DELETE FROM {tablename} WHERE {condition}";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = request;
                return command.ExecuteNonQuery();
            }
        }

        public static int UpdateData(string tablename, string edit, string condiotion)
        {
            using (var connection = Connector.GetConnection())
            {
                connection.Open();
                string request = $"UPDATE {tablename} SET {edit} WHERE {condiotion}";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = request;
                return command.ExecuteNonQuery();
            }
        }
    }
}
