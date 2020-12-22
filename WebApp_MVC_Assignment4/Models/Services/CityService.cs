using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_MVC_Assignment4.Models.Repositorys;
using WebApp_MVC_Assignment4.Models.ViewModels;

namespace WebApp_MVC_Assignment4.Models.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;
        private readonly IPeopleRepo _peopleRepo;
        //private readonly ICityService _cityService;

        /*public CityService(ICityRepo cityRepo, ICityService cityService)
        {
            _cityRepo = cityRepo;
            _cityService = cityService;
        }*/

        public CityService(ICityRepo cityRepo, IPeopleRepo peopleRepo)
        {
            _cityRepo = cityRepo;
            _peopleRepo = peopleRepo;
        }

        public City Add(CreateCityViewModel createCityViewModel)
        {
            /*if (_cityService.FindBy(createCityViewModel.cityList) == null)
            {
                return null;
            }*/

            Person person = _peopleRepo.Read(createCityViewModel.PersonID);
            City city = _cityRepo.Create(person, createCityViewModel.States, createCityViewModel.CityName);

            return city;
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City Edit(int id, CreateCityViewModel edit)
        {
            City editedCity = new City() { Id = id, PersonInCity= edit.PersonInCity, States= edit.States, CityName= edit.CityName };

            return _cityRepo.Update(editedCity);
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _cityRepo.Delete(FindBy(id));
        }
    }
}
