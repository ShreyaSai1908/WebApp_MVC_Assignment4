using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_MVC_Assignment4.Models.Repositorys;

namespace WebApp_MVC_Assignment4.Models.Database
{
    public class DatabaseCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabaseCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

       
        public City Create(Person PersonInCity, string States, string CityName)
        {
            City addingCity = new City() { States= States, CityName= CityName};
            
            List<Person> personInCity = new List<Person>();
            personInCity.Add(PersonInCity);
            addingCity.PersonInCity = personInCity;

            _peopleDbContext.Add(addingCity);
            _peopleDbContext.SaveChanges();

            foreach (Person person in addingCity.PersonInCity)
            {
                _peopleDbContext.Update(person);
                _peopleDbContext.SaveChanges();
            }

            return addingCity;
        }

        public bool Delete(City city)
        {
            bool delete = true;

            if (delete == true)
            {
                _peopleDbContext.GetCitiesList.Remove(city);
                _peopleDbContext.SaveChanges();
            }

            return delete;
        }

        public List<City> Read()
        {
            return _peopleDbContext.GetCitiesList.ToList();
        }

        public City Read(int id)
         {
            return _peopleDbContext.GetCitiesList.Find(id);
        }

        public City Update(City city)
        {
            _peopleDbContext.Update(city);
            _peopleDbContext.SaveChanges();
            return (city);
        }
    }
}
