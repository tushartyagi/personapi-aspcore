using System.Collections.Generic;
using PersonSaver.Models;

namespace PersonSaver.Repositories
{
    public interface IPersonsRepository
    {
        // TODO: Add Delete operations.
        IEnumerable<Person> Get();
        Person Get(string Id);
        void Add(Person person);
        void Update(Person person);
    }
}

    
