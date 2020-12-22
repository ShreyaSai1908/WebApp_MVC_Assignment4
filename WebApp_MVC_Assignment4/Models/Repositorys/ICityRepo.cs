﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models.Repositorys
{
    public interface ICityRepo
    {
        public City Create(Person PersonInCity, string States, string CityName);
        public List<City> Read();
        public City Read(int id);
        public City Update(City PersonInCity);
        public bool Delete(City PersonInCity);
        
    }
}
