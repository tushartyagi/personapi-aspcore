using System;
using System.Collections.Generic;
using System.Linq;
using PersonSaver.Entities;
using PersonSaver.Models;

namespace PersonSaver.Repositories
{
    public class PersonsRepository: IPersonsRepository
    {

        PersonsContext _context;
        
        public PersonsRepository(PersonsContext context) {
            _context = context;
        }
        
        // TODO: Add Delete operations.
        public IEnumerable<Person> Get() {
            return _context.Persons.ToList();
        }

        public Person Get(string Id) {
            return _context.Persons.FirstOrDefault(x => x.Id == Id);
        }

        public void Add(Person person) {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person) {
            throw new NotImplementedException();
        }
    }
}

    
