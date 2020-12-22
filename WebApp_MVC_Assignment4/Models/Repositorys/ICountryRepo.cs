using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models.Repositorys
{
    public interface ICountryRepo
    {
        public Country Create(City CityInCountry, string CountryName);
        public List<Country> Read();
        public Country Read(int id);
        public Country Update(Country country);
        public bool Delete(Country country);
    }
}
