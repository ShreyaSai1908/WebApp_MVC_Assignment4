using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models.ViewModels
{
    public class CreateCityViewModel
    {
        public List<City> CityList { get; set; }

        public List <Person> PersonInCity { get; set; }

        public int PersonID { get; set; }

        //public Person Person { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string States { get; set; }

    }
}
