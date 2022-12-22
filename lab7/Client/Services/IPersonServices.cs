using lab7.Shared;

namespace lab7.Client.Services
{
    public interface IPersonServices
    {
        List<Person> persons { get; set; }
        Task GetPersons();
        Task<Person> GetPerson(int id);
        Task Create(Person person);
        Task Edit(Person person, int id);
        Task Delete(int id);
    }
}
