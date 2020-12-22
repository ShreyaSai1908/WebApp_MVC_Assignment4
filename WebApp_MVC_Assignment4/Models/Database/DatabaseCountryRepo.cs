using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_MVC_Assignment4.Models.Repositorys;

namespace WebApp_MVC_Assignment4.Models.Database
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabaseCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(City CityInCountry, string CountryName)
        {
            Country addingCountry = new Country() { CountryName = CountryName};

            CityInCountry.Country = addingCountry;

            List<City> cityInCountry = new List<City>();
            cityInCountry.Add(CityInCountry);
            addingCountry.CityList = cityInCountry;

            _peopleDbContext.Add(addingCountry);
            _peopleDbContext.SaveChanges();

            foreach (City city in addingCountry.CityList)
            {                 
                _peopleDbContext.Update(city);
                _peopleDbContext.SaveChanges();
            }

            return addingCountry;
        }

        public bool Delete(Country country)
        {
            throw new NotImplementedException();
        }

        public List<Country> Read()
        {
            return _peopleDbContext.GetCountriesList.ToList();
        }

        public Country Read(int id)
        {
            throw new NotImplementedException();
        }

        public Country Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
