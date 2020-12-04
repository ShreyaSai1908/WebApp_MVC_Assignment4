using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_MVC_Assignment4.Models
{
    public class PeopleService : IPeopleService
    {
        private static InMemoryPeopleRepo pr = new InMemoryPeopleRepo();

        public Person Add(CreatePersonViewModel modelData)
        {
            Person personAdded = pr.Create(modelData.FirstName, modelData.LastName, modelData.PhoneNumber, modelData.Address);
            return personAdded;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            //InMemoryPeopleRepo pr = new InMemoryPeopleRepo();
            peopleViewModel.AllPeople = pr.Read();
            return peopleViewModel;
        }
        public PeopleViewModel FindBy(PeopleViewModel pvm)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            // InMemoryPeopleRepo pr = new InMemoryPeopleRepo();

            List<Person> searchedPeople = new List<Person>();
            peopleViewModel.AllPeople = pr.Read();

            foreach (Person person in peopleViewModel.AllPeople)
            {
                if ((person.FirstName).Contains(pvm.Search) ||
                     (person.LastName).Contains(pvm.Search) ||
                      (person.Address).Contains(pvm.Search))
                {
                    searchedPeople.Add(person);
                }
            }

            peopleViewModel.AllPeople = searchedPeople;

            return peopleViewModel;
        }
        public Person FindBy(int findID)
        {
            //InMemoryPeopleRepo pr = new InMemoryPeopleRepo();

            List<Person> allPeople = new List<Person>();
            allPeople = pr.Read();

            Person searchedPerson = new Person();

            foreach (Person person in allPeople)
            {
                if (person.PersonID == findID)
                {
                    searchedPerson = person;
                }
            }

            return searchedPerson;
        }
        public Person Edit(int id, Person editPerson)
        {
            Person person = FindBy(id);

            person.FirstName = editPerson.FirstName;
            person.LastName = editPerson.LastName;
            person.PhoneNumber = editPerson.PhoneNumber;
            person.Address = editPerson.Address;

            return person;
        }
        public bool Remove(int findID)
        {
            bool result = false;
            //InMemoryPeopleRepo pr = new InMemoryPeopleRepo();

            Person removePerson = pr.Read(findID);
            result = pr.Delete(removePerson);
            return result;
        }
    }
}
