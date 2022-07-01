using NUnit.Framework;
using SQLTestProject.Models;

namespace SQLTestProject
{
    public class Tests
    {
        [Test]
        public void CreateRecord()
        {
            var city = new CityModel
            {
                Id = 4080,
                Name = "Gdansk",
                CountryCode = "POL",
                District = "P",
                Population = 10
            };
            Assert.AreEqual(1, CRUDActions.AddModel("city", city), "Record not added");
            var cityFromDB = CityModel.GetModelFromDB(CRUDActions.GetData("*", "city", $"WHERE NAME = \"{city.Name}\""));
            Assert.IsTrue(city.Equals(cityFromDB), "Add wrong model");
        }

        [Test]
        public void UpdateRecord() 
        {
            var countOfUpdatedRecord = CRUDActions.UpdateData("city", "District = \"Pomeranian\", Population = 470633", "Name = \"Gdansk\"");
            Assert.NotZero(countOfUpdatedRecord, "Record not updated");
        }

        [Test]
        public void DeleteRecord() 
        {
            Assert.NotZero(CRUDActions.DeleteData("city", "Name = \"Gdansk\""), "Record not deleted");
        }
    }
}