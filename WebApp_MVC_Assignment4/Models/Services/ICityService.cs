using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_MVC_Assignment4.Models.ViewModels;

namespace WebApp_MVC_Assignment4.Models.Services
{
    public interface ICityService
    {
        public City Add(CreateCityViewModel createCityViewModel);
        public List<City> All();
        public City FindBy(int id);
        public City Edit(int id, CreateCityViewModel edit);
        public bool Remove(int id);
        public List<Person> FindAllPerson(int id);

    }
}
