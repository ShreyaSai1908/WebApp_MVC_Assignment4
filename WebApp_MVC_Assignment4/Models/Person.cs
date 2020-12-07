using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models
{
    public class Person
    {        
        public int PersonID { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 9)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string Address { get; set; }

        
    }
}
