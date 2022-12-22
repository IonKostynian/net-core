using lab7.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace lab7.Client.Services
{
    public class ReaderServices : IReaderServices
    {
        private readonly HttpClient _httpClient;
        public ReaderServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Reader> readers { get; set; } = new List<Reader>();

        public async Task GetReaders()
        {
            readers = await _httpClient.GetFromJsonAsync<List<Reader>>("api/Reader");
        }

        public async Task<Reader> GetReader(int id)
        {
            return await _httpClient.GetFromJsonAsync<Reader>("api/Reader/{id}");
        }

        public async Task Create(Reader reader)
        {
            await _httpClient.PostAsJsonAsync<Reader>("api/Reader/", reader);

        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Reader/{id}");
        }
    }
}
