using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models
{
    public class City
    {        
        /*private City personInCity;

        public City()
        {
        }

        public City(City personInCity, string states)
        {
            this.personInCity = personInCity;
            States = states;
        }*/

        [Key]
        public int Id { get; set; }

        public List<Person> PersonInCity { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string States { get; set; }

        public Country Country { get; set; }

    }
}
