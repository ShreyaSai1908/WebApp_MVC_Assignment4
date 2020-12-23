﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_MVC_Assignment4.Models.Repositorys;
using WebApp_MVC_Assignment4.Models.ViewModels;

namespace WebApp_MVC_Assignment4.Models.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountryViewModel createCountryViewModel)
        {
            City city=_cityRepo.Read(createCountryViewModel.CityID);
            Country country = _countryRepo.Create(city, createCountryViewModel.CountryName);

            return country;
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public Country Edit(int id, CreateCountryViewModel edit)
        {
            Country editedcountry = new Country() { CountryId = id, CountryName = edit.CountryName};

            return _countryRepo.Update(editedcountry);
        }

        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public bool Remove(int id)
        {
            return _countryRepo.Delete(FindBy(id));
        }
    }
}
