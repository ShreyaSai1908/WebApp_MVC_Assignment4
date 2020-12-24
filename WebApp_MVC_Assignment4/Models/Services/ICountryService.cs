using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_MVC_Assignment4.Models.ViewModels;

namespace WebApp_MVC_Assignment4.Models.Services
{
    public interface ICountryService
    {
        public Country Add(CreateCountryViewModel createCountryViewModel);
        public List<Country> All();
        public Country FindBy(int id);
        public Country Edit(int id, CreateCountryViewModel edit);
        public bool Remove(int id);
        public List<City> FindAllCity(int id);
    }
}
