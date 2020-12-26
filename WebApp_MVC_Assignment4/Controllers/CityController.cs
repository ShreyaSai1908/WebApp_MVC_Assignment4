using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp_MVC_Assignment4.Models;
using WebApp_MVC_Assignment4.Models.Services;
using WebApp_MVC_Assignment4.Models.ViewModels;

namespace WebApp_MVC_Assignment4.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IPeopleService _peopleService;

        /*public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }*/

        public CityController(ICityService cityService, IPeopleService peopleService)
        {
            _cityService = cityService;
            _peopleService = peopleService;
        }

        // GET: CityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CityController/City
        public ActionResult City()
        {
            CreateCityViewModel ctyVM = new CreateCityViewModel();
            ctyVM.CityList=_cityService.All();
            return View(ctyVM);
        }

        // GET: CityController/Details/5
        [HttpGet]
        public ActionResult CityDetails(int id)
        {
            CreateCityViewModel ctyVm = new CreateCityViewModel();
            City cityDetails = _cityService.FindBy(id);
            ctyVm.CityName = cityDetails.CityName;
            ctyVm.States = cityDetails.States;
            ctyVm.PersonInCity = _cityService.FindAllPerson(id);
            return View(ctyVm);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            PeopleViewModel pplVM = _peopleService.All();
            CreateCityViewModel cityVM = new CreateCityViewModel();
            cityVM.PersonInCity = pplVM.AllPeople;
            return View(cityVM);
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {
            City city = null;

            if (ModelState.IsValid)
            {
                
                city = _cityService.Add(createCity);
                
                if (city == null)
                {
                    ModelState.AddModelError("msg", "Database Problem");
                    return View(createCity);
                }

                return RedirectToAction(nameof(City));
            }
            else
            {
                return View(createCity);
            }
                
        } 

        // GET: CityController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            PeopleViewModel pplVM = _peopleService.All();
            CreateCityViewModel cityVM = new CreateCityViewModel();
            City editCity = _cityService.FindBy(id);

            cityVM.States = editCity.States;
            cityVM.CityName = editCity.CityName;
            cityVM.PersonInCity = pplVM.AllPeople;
            cityVM.updateCityID = id;
            
            return View("Edit", cityVM);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateCityViewModel updCity)
        { 
            _cityService.Edit(updCity.updateCityID, updCity);

            return RedirectToAction(nameof(City));
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            _cityService.Remove(id);
            return RedirectToAction(nameof(City));
        }

        // POST: CityController/Delete/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _cityService.Remove(id);
            _cityService.All();
            return RedirectToAction(nameof(Create));
        }*/
    }
}
