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
            CreateCityViewModel cityVM = new CreateCityViewModel();
            cityVM.CityList=_cityService.All();
            return View(cityVM);
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            if (ModelState.IsValid)
            {
                City city = _cityService.Add(createCity);

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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
           City edit = new City();

            //to be replaced by user input
            edit.States = "EditStates";
            edit.CityName = "EditCityName";

            _cityService.Edit(id, edit);
            _cityService.All();
            return RedirectToAction(nameof(Create));
        }*/

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
