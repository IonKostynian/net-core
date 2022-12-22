using lab7.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace lab7.Client.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly HttpClient _httpClient;
        public PersonServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Person> persons { get; set; } = new List<Person>();

        public async Task GetPersons()
        {
            persons = await _httpClient.GetFromJsonAsync<List<Person>>("api/Person");
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _httpClient.GetFromJsonAsync<Person>("api/Person/{id}");
        }

        public async Task Create(Person person)
        {
            await _httpClient.PostAsJsonAsync<Person>("api/Person/", person);
        }

        public async Task Edit(Person person, int id)
        {
            await _httpClient.PutAsJsonAsync<Person>($"api/Person/{id}", person);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Person/{id}");
        }
    }
}
