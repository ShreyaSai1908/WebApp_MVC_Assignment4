using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models
{
    public class PeopleViewModel
    {
        public List<Person> AllPeople { get; set; }

        public string Search { get; set; }

        public CreatePersonViewModel AddPerson { get; set; }

        public string ModelErr { get; set; }
    }
}
