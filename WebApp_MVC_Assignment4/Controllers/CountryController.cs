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
    public class CountryController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
                
        public CountryController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        // GET: CountryController
        public ActionResult ShowCountry()
        {
            /*CreateCountryViewModel ctyVM = new CreateCountryViewModel();

            Country cty = new Country();

            cty.CountryName = "Default Country";
            cty.CountryId = 0;

            List<Country> countryList = new List<Country>();
            countryList.Add(cty);

            ctyVM.CountryList = countryList;*/

            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            ctyVM.CountryList = _countryService.All();
            return View(ctyVM);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public ActionResult CreateCountry()
        {
            CreateCountryViewModel ctyVM = new CreateCountryViewModel();
            ctyVM.CityList=_cityService.All();
            return View(ctyVM);
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCountry(CreateCountryViewModel ctyVM)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Add(ctyVM);

                if (country == null)
                {
                    ModelState.AddModelError("msg", "Database Problem");
                    return View(ctyVM);
                }

                return RedirectToAction(nameof(ShowCountry));
            }
            else
            {
                return View(ctyVM);
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ShowCountry));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ShowCountry));
            }
            catch
            {
                return View();
            }
        }
    }
}
