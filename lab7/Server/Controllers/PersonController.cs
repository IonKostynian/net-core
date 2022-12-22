using lab7.Server.Database;
using lab7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ReadersContext _context;
        public PersonController(ReadersContext context)
        {
            _context = context;
        }

        public List<Person> persons { get; set; } = new List<Person>();

        [HttpGet]
        public async Task GetPersons()
        {
            persons = await _context.Persons.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                throw new Exception("No find this person");
            }
            return person;
        }
        [HttpPost]
        public async Task Create(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }
        [HttpPut("{id:int}")]
        public async Task Edit(Person person, int id)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }
        [HttpDelete("{id:int}")]
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
