using MySql.Data.MySqlClient;

namespace SQLTestProject.Models
{
    public class CityModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public int Population { get; set; }

        public static CityModel GetModelFromDB(MySqlDataReader reader) 
        {
            reader.Read();
            CityModel model = new CityModel
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                CountryCode = reader.GetString(2),
                District = reader.GetString(3),
                Population = reader.GetInt32(4)
            };
            reader.Close();
            Connector.GetConnection().Close();
            return model;
        }

        public override string ToString()
        {
            return $"{Id}, \"{Name}\", \"{CountryCode}\", \"{District}\", {Population}";
        }

        public override bool Equals(object ob)
        {
            CityModel obj = (CityModel)ob;
            if (Name == obj.Name & CountryCode == obj.CountryCode & District == obj.District & Population == obj.Population) return true;
            else return false;
        }
    }
}
