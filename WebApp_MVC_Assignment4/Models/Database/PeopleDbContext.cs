using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {

        }
        public DbSet<Person> GetPeopleList { get; set; }
        public DbSet<City> GetCitiesList { get; set; }

        public DbSet<Country> GetCountriesList { get; set; }
    }
}
