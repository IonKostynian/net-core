using Microsoft.EntityFrameworkCore;

namespace lab6.Data
{
    public class PersonServices : IPersonServices
    {
        private readonly ReadersContext _context;
        public PersonServices(ReadersContext context)
        {
            _context = context;
        }

        public List<Person> persons { get; set; } = new List<Person>();

        public async Task GetPersons()
        {
            persons = await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                throw new Exception("No find this person");
            }
            return person;
        }

        public async Task Create(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Person person, int id)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                throw new Exception("No find this person");
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
