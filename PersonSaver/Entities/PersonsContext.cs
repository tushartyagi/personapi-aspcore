using PersonSaver.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonSaver.Entities {
    public class PersonsContext : DbContext {

        public PersonsContext(DbContextOptions options): base(options) {
            
        }

        public virtual DbSet<Person> Persons { get; set; }
    }
}
